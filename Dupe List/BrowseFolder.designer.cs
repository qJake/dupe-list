namespace DupeList
{
    partial class BrowseFolder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowseFolder));
            this.label1 = new System.Windows.Forms.Label();
            this.tPath = new System.Windows.Forms.TextBox();
            this.bBrowse = new System.Windows.Forms.Button();
            this.FBD = new System.Windows.Forms.FolderBrowserDialog();
            this.bScan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select the folder you would like to scan:";
            // 
            // tPath
            // 
            this.tPath.BackColor = System.Drawing.SystemColors.Window;
            this.tPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPath.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tPath.Location = new System.Drawing.Point(97, 33);
            this.tPath.Name = "tPath";
            this.tPath.ReadOnly = true;
            this.tPath.Size = new System.Drawing.Size(241, 23);
            this.tPath.TabIndex = 2;
            this.tPath.Text = "No folder selected.";
            // 
            // bBrowse
            // 
            this.bBrowse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBrowse.Location = new System.Drawing.Point(16, 32);
            this.bBrowse.Name = "bBrowse";
            this.bBrowse.Size = new System.Drawing.Size(75, 24);
            this.bBrowse.TabIndex = 1;
            this.bBrowse.Text = "Browse...";
            this.bBrowse.UseVisualStyleBackColor = true;
            this.bBrowse.Click += new System.EventHandler(this.bBrowse_Click);
            // 
            // FBD
            // 
            this.FBD.ShowNewFolderButton = false;
            // 
            // bScan
            // 
            this.bScan.Enabled = false;
            this.bScan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bScan.Location = new System.Drawing.Point(223, 65);
            this.bScan.Name = "bScan";
            this.bScan.Size = new System.Drawing.Size(115, 33);
            this.bScan.TabIndex = 3;
            this.bScan.Text = "Begin Scan";
            this.bScan.UseVisualStyleBackColor = true;
            this.bScan.Click += new System.EventHandler(this.bScan_Click);
            // 
            // BrowseFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(355, 112);
            this.Controls.Add(this.bScan);
            this.Controls.Add(this.bBrowse);
            this.Controls.Add(this.tPath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BrowseFolder";
            this.Text = "DupeList - Select Folder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BrowseFolder_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tPath;
        private System.Windows.Forms.Button bBrowse;
        private System.Windows.Forms.FolderBrowserDialog FBD;
        private System.Windows.Forms.Button bScan;
    }
}

