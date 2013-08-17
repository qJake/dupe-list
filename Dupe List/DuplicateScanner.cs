using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Security.AccessControl;
using System.Collections;
using System.Security.Cryptography;

namespace DupeList
{
    public struct UIDataPackage
    {
        public ScanAction CurrentAction;
        public int TotalFiles;
        public int CompletedFiles;
        public int PreliminaryFilesFound;
        public int DuplicatesFound;
    }

    public class DuplicateScanner
    {
        string Location;
        public delegate void UpdateUIDelegate(UIDataPackage info);

        public delegate void SwitchWindowHandler(List<List<string>> duplicateData);
        public event SwitchWindowHandler OnFinishedProcessing;

        UpdateUIDelegate updateUI;
        UIDataPackage uiData;
        Thread scannerThread;

        

        public DuplicateScanner(string Folder, UpdateUIDelegate UIUpdateMethod)
        {
            updateUI = UIUpdateMethod;

            Trace.WriteLine("Starting scanner...");
            Location = Folder;

            scannerThread = new Thread((ThreadStart)delegate()
            {
                ScanForDuplicates(Folder);
            });
            scannerThread.Start();

            Trace.WriteLine("Thread started. Waiting...");
        }

        private void ScanForDuplicates(string loc)
        {
            uiData = new UIDataPackage();

            uiData.CurrentAction = ScanAction.Prescan;
            updateUI(uiData);

            Hashtable prelimFiles = new Hashtable();
            int FileCount = GetFileCount(loc, ref prelimFiles);

            // create list of files to scan here
            List<string> filesToScan = new List<string>();
            foreach (DictionaryEntry kv in prelimFiles)
            {
                if (((List<string>)kv.Value).Count > 1 )
                {
                    filesToScan.AddRange((List<string>)kv.Value);
                }
            }

            uiData.TotalFiles = filesToScan.Count;
            uiData.CurrentAction = ScanAction.Scan;
            updateUI(uiData);

            Hashtable result = new Hashtable();
            GetFileHashtable(filesToScan, ref result);

            uiData.CurrentAction = ScanAction.ScanComplete;
            updateUI(uiData);

            List<List<string>> dupes = new List<List<string>>();

            foreach (DictionaryEntry kv in result)
            {
                if (((List<string>)kv.Value).Count > 1)
                {
                    dupes.Add((List<string>)kv.Value);
                }
            }

            if (OnFinishedProcessing != null)
            {
                OnFinishedProcessing(dupes);
            }
        }

        private void GetFileHashtable(List<string> fileList, ref Hashtable existing)
        {
            foreach (string filename in fileList)
            {
                FileInfo file = new FileInfo(filename);
                if (!ExcludeFiles.IsExcludedFile(file.Name))
                {
                    try
                    {
                        string hash = Hasher.md5(File.ReadAllBytes(file.FullName));
                        if (existing.ContainsKey(hash))
                        {
                            ((List<string>)existing[hash]).Add(file.FullName);
                            uiData.DuplicatesFound++;
                            updateUI(uiData);
                        }
                        else
                        {
                            List<string> newFileList = new List<string>();
                            newFileList.Add(file.FullName);
                            existing.Add(hash, newFileList);
                        }
                    }
                    catch
                    {
                        // Nothing on error, if we can't do anything with the file just skip it.
                        continue;
                    }
                }
                uiData.CompletedFiles++;
                updateUI(uiData);
            }
        }



        private int GetFileCount(string dir, ref Hashtable files)
        {
            int count = 0;

            DirectoryInfo thisDir = new DirectoryInfo(dir);

            DirectoryInfo[] dirs = null;
            try
            {
                dirs = thisDir.GetDirectories();
            }
            catch (UnauthorizedAccessException)
            {
                return 0; // access denied
            }
            
            foreach (DirectoryInfo d in dirs)
            {
                try
                {
                    count += GetFileCount(d.FullName, ref files);
                }
                catch (Exception)
                {
                    // can't get file name, skip
                }
            }

            FileInfo[] f = thisDir.GetFiles();

            foreach (FileInfo file in f)
            {
                try
                {
                    if (files.ContainsKey(file.Length))
                    {
                        ((List<string>)files[file.Length]).Add(file.FullName);
                    }
                    else
                    {
                        List<string> fileList = new List<string>();
                        fileList.Add(file.FullName);
                        files.Add((long)file.Length, fileList);
                    }
                }
                catch
                {
                    // pass
                }
            }

            count += f.Length;

            AddFilesFound(f.Length);
            updateUI(uiData);

            return count;
        }

        private void AddFilesFound(int newFiles)
        {
            uiData.PreliminaryFilesFound += newFiles;
            updateUI(uiData);
        }
    }
}
