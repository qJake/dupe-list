namespace DupeList
{
    partial class Progress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Progress));
            this.lStatus = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lScanned = new System.Windows.Forms.Label();
            this.lRemaining = new System.Windows.Forms.Label();
            this.lPercent = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bCancel = new System.Windows.Forms.Button();
            this.lDuplicates = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lStatus.Location = new System.Drawing.Point(12, 9);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(0, 15);
            this.lStatus.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 45);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(393, 20);
            this.progressBar.TabIndex = 1;
            // 
            // lScanned
            // 
            this.lScanned.AutoSize = true;
            this.lScanned.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lScanned.Location = new System.Drawing.Point(9, 80);
            this.lScanned.Name = "lScanned";
            this.lScanned.Size = new System.Drawing.Size(0, 15);
            this.lScanned.TabIndex = 2;
            // 
            // lRemaining
            // 
            this.lRemaining.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRemaining.Location = new System.Drawing.Point(232, 80);
            this.lRemaining.Name = "lRemaining";
            this.lRemaining.Size = new System.Drawing.Size(173, 15);
            this.lRemaining.TabIndex = 3;
            this.lRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lPercent
            // 
            this.lPercent.AutoSize = true;
            this.lPercent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPercent.Location = new System.Drawing.Point(194, 27);
            this.lPercent.Name = "lPercent";
            this.lPercent.Size = new System.Drawing.Size(0, 15);
            this.lPercent.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.bCancel);
            this.panel1.Location = new System.Drawing.Point(-5, 141);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 100);
            this.panel1.TabIndex = 5;
            // 
            // bCancel
            // 
            this.bCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCancel.Location = new System.Drawing.Point(319, 6);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(90, 28);
            this.bCancel.TabIndex = 0;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // lDuplicates
            // 
            this.lDuplicates.AutoSize = true;
            this.lDuplicates.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDuplicates.Location = new System.Drawing.Point(9, 104);
            this.lDuplicates.Name = "lDuplicates";
            this.lDuplicates.Size = new System.Drawing.Size(0, 15);
            this.lDuplicates.TabIndex = 6;
            // 
            // Progress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(417, 182);
            this.ControlBox = false;
            this.Controls.Add(this.lDuplicates);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lPercent);
            this.Controls.Add(this.lRemaining);
            this.Controls.Add(this.lScanned);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Progress";
            this.Text = "Progress";
            this.Shown += new System.EventHandler(this.Progress_Shown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lScanned;
        private System.Windows.Forms.Label lRemaining;
        private System.Windows.Forms.Label lPercent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label lDuplicates;
    }
}