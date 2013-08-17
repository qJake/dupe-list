using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace DupeList
{
    public partial class ResultWindow : Form
    {
        ContextMenu cm = new ContextMenu();

        public ResultWindow(List<List<string>> duplicateResults)
        {
            InitializeComponent();

            MenuItem[] SelectSubitems = new MenuItem[2];
            SelectSubitems[0] = new MenuItem();
            SelectSubitems[0].Text = "First Item in Group";
            SelectSubitems[0].Click += new EventHandler(ResultWindow_Click);
            SelectSubitems[1] = new MenuItem();
            SelectSubitems[1].Text = "Second Item in Group";
            SelectSubitems[1].Click += new EventHandler(ResultWindow2_Click);

            cm.MenuItems.Add(new MenuItem("Select", SelectSubitems));

            cm.MenuItems.Add(new MenuItem("-"));
            cm.MenuItems.Add(new MenuItem("Select All", SelectAll_Click));
            cm.MenuItems.Add(new MenuItem("Select None", SelectNone_Click));
            cm.MenuItems.Add(new MenuItem("Select Inverse", SelectInverse_Click));
            cm.MenuItems.Add(new MenuItem("-"));
            cm.MenuItems.Add(new MenuItem("Delete Selected", DeleteSelected_Click));

            duplicateList.ContextMenu = cm;

            new Thread((ThreadStart)delegate()
            {
                BeginProcessing(duplicateResults);
            }).Start();
        }

        void DeleteSelected_Click(object sender, EventArgs e)
        {
            new Thread((ThreadStart)delegate()
            {
                _deleteSelected();
            }).Start();
        }

        void SelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem i in duplicateList.Items)
            {
                i.Selected = true;
            }
        }

        void SelectNone_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem i in duplicateList.Items)
            {
                i.Selected = false;
            }
        }

        void SelectInverse_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem i in duplicateList.Items)
            {
                i.Selected = !i.Selected;
            }
        }

        void ResultWindow2_Click(object sender, EventArgs e)
        {
            foreach (ListViewGroup g in duplicateList.Groups)
            {
                if (g.Items.Count > 1)
                {
                    g.Items[1].Selected = true;
                }
            }
        }

        void ResultWindow_Click(object sender, EventArgs e)
        {
            foreach (ListViewGroup g in duplicateList.Groups)
            {
                g.Items[0].Selected = true;
            }
        }

        private void BeginProcessing(List<List<string>> duplicateResults)
        {
            DoInvoke((MethodInvoker)delegate()
            {
                duplicateList.BeginUpdate();
            });

            int max = 0;
            foreach (List<string> ss in duplicateResults)
            {
                foreach (string s in ss)
                {
                    max++;
                }
            }

            ProcessProgress progress = new ProcessProgress(max, "Processing");
            DoInvoke((MethodInvoker)delegate()
            {
                progress.Show(this);
            });

            int count = 0;
            int total = 0;

            foreach (List<string> dupeGroup in duplicateResults)
            {
                FileInfo f = new FileInfo(dupeGroup[0]);

                string headerKey = Hasher.md5(Encoding.ASCII.GetBytes(f.FullName));

                DoInvoke((MethodInvoker)delegate()
                {
                    duplicateList.Groups.Add(headerKey, f.Name);
                });

                foreach (string file in dupeGroup)
                {
                    ListViewItem i = new ListViewItem(duplicateList.Groups[headerKey]);
                    i.Text = new FileInfo(file).FullName;

                    DoInvoke((MethodInvoker)delegate()
                    {
                        duplicateList.Items.Add(i);
                    });

                    count++;
                    total++;
                    if (count > 50)
                    {
                        count = 0;
                        progress.UpdateProgress(total);
                    }
                    Application.DoEvents();
                }
            }
            DoInvoke((MethodInvoker)delegate()
            {
                progress.Close();
            });

            DoInvoke((MethodInvoker)delegate()
            {
                duplicateList.EndUpdate();
            });
        }

        private void DoInvoke(MethodInvoker method)
        {
            if (duplicateList.InvokeRequired)
            {
                Invoke(method);
            }
            else
            {
                method();
            }
        }

        private void duplicateList_Resize(object sender, EventArgs e)
        {
            duplicateList.Columns[0].Width = duplicateList.Width - 10;
        }

        private void ResultWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void bSelAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem i in duplicateList.Items)
            {
                i.Checked = true;
            }
        }

        private void b_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem i in duplicateList.Items)
            {
                i.Checked = false;
            }
        }

        private void bSelInverse_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem i in duplicateList.Items)
            {
                i.Checked = !i.Checked;
            }
        }

        private void bDelSelected_Click(object sender, EventArgs e)
        {
            new Thread((ThreadStart)delegate()
            {
                _deleteFiles();
            }).Start();
        }

        private void _deleteFiles()
        {
            if (MessageBox.Show("WARNING: This will permanently delete all checked files in this list. This action cannot be undone.\r\n\r\nAre you sure you want to delete the selected files?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ProcessProgress progress = new ProcessProgress(duplicateList.Items.Count, "Deleting");
                DoInvoke((MethodInvoker)delegate()
                {
                    progress.Show(this);
                });

                List<ListViewItem> toRemove = new List<ListViewItem>();

                int total = 0;

                DoInvoke((MethodInvoker)delegate()
                {
                    foreach (ListViewItem i in duplicateList.Items)
                    {
                        if (i.Checked)
                        {
                            try
                            {
                                FileInfo f = new FileInfo(i.Text);
                                f.Delete();
                                toRemove.Add(i);
                            }
                            catch
                            {
                                // Delete failed. Skip the file.
                            }
                        }
                        total++;
                        progress.UpdateProgress(total);
                    }
                });

                DoInvoke((MethodInvoker)delegate()
                {
                    progress.Close();
                });

                ProcessProgress cleanup = new ProcessProgress(toRemove.Count, "Cleaning up");
                int count = 0;
                DoInvoke((MethodInvoker)delegate()
                {
                    cleanup.Show(this);

                    // Remove deleted files
                    duplicateList.BeginUpdate();
                    foreach (ListViewItem i in toRemove)
                    {
                        duplicateList.Items.Remove(i);
                        cleanup.UpdateProgress(count++);
                    }
                    duplicateList.EndUpdate();
                    cleanup.Close();
                });

                if (toRemove.Count != count)
                {
                    MessageBox.Show("Some files could not be deleted. These items were not removed from the list.", "Partial File Deletion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("All selected files have been deleted.", "All Files Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void _deleteSelected()
        {
            if (MessageBox.Show("WARNING: This will permanently delete all selected files in this list. This action cannot be undone.\r\n\r\nAre you sure you want to delete the selected files?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ProcessProgress progress = new ProcessProgress(duplicateList.Items.Count, "Deleting");
                DoInvoke((MethodInvoker)delegate()
                {
                    progress.Show(this);
                });

                List<ListViewItem> toRemove = new List<ListViewItem>();

                int total = 0;

                DoInvoke((MethodInvoker)delegate()
                {
                    foreach (ListViewItem i in duplicateList.Items)
                    {
                        if (i.Selected)
                        {
                            try
                            {
                                FileInfo f = new FileInfo(i.Text);
                                f.Delete();
                                toRemove.Add(i);
                            }
                            catch
                            {
                                // Delete failed. Skip the file.
                            }
                        }
                        total++;
                        progress.UpdateProgress(total);
                    }
                });

                DoInvoke((MethodInvoker)delegate()
                {
                    progress.Close();
                });

                ProcessProgress cleanup = new ProcessProgress(toRemove.Count, "Cleaning up");
                int count = 0;
                DoInvoke((MethodInvoker)delegate()
                {
                    cleanup.Show(this);

                    // Remove deleted files
                    duplicateList.BeginUpdate();
                    foreach (ListViewItem i in toRemove)
                    {
                        duplicateList.Items.Remove(i);
                        cleanup.UpdateProgress(count++);
                    }
                    duplicateList.EndUpdate();
                    cleanup.Close();
                });

                if (toRemove.Count != count)
                {
                    MessageBox.Show("Some files could not be deleted. These items were not removed from the list.", "Partial File Deletion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("All selected files have been deleted.", "All Files Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
