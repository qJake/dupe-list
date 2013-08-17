using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace DupeList
{
    public enum ScanAction
    {
        Prescan,
        Scan,
        ScanComplete
    }

    public partial class Progress : Form
    {
        string TargetFolder;
        DuplicateScanner ds;

        public Progress(string Folder)
        {
            InitializeComponent();
            TargetFolder = Folder;
        }

        private void Progress_Shown(object sender, EventArgs e)
        {
            ds = new DuplicateScanner(TargetFolder, UpdateUI);
            ds.OnFinishedProcessing += new DuplicateScanner.SwitchWindowHandler(ds_OnFinishedProcessing);
        }

        void ds_OnFinishedProcessing(List<List<string>> duplicateData)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate()
                {
                    _switchWindow(duplicateData);
                });
            }
            else
            {
                _switchWindow(duplicateData);
            }
        }

        void _switchWindow(List<List<string>> duplicateData)
        {
            ResultWindow r = new ResultWindow(duplicateData);
            r.Show();
            this.Close();
        }

        public void UpdateUI(UIDataPackage info)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate()
                {
                    _updateUI(info);
                });
            }
            else
            {
                _updateUI(info);
            }
        }

        private void _updateUI(UIDataPackage info)
        {
            if (info.CurrentAction == ScanAction.Prescan)
            {
                lStatus.Text = "Pre-scanning...";
                progressBar.Style = ProgressBarStyle.Marquee;
                lScanned.Text = String.Format("Found {0} files", info.PreliminaryFilesFound.ToString("#,##"));
            }
            else if (info.CurrentAction == ScanAction.ScanComplete)
            {
                lStatus.Text = "Scan Complete!";
            }
            else
            {
                progressBar.Style = ProgressBarStyle.Continuous;
                progressBar.Maximum = info.TotalFiles;
                progressBar.Value = info.CompletedFiles;
                lStatus.Text = "Scanning...";
                lScanned.Text = String.Format("{0} / {1} Files scanned", info.CompletedFiles, info.TotalFiles);
                lRemaining.Text = String.Format("{0} Files remaining", (info.TotalFiles - info.CompletedFiles));
                lPercent.Text = String.Format("{0}%", (int)(((float)info.CompletedFiles / (float)info.TotalFiles) * 100));
                lDuplicates.Text = String.Format("{0} Duplicate files", info.DuplicatesFound);
            }
            Application.DoEvents();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        
    }
}
