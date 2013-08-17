namespace DupeList
{
    partial class ResultWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultWindow));
            this.duplicateList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bDelSelected = new System.Windows.Forms.Button();
            this.bSelAll = new System.Windows.Forms.Button();
            this.b = new System.Windows.Forms.Button();
            this.bSelInverse = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // duplicateList
            // 
            this.duplicateList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.duplicateList.CheckBoxes = true;
            this.duplicateList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.duplicateList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duplicateList.FullRowSelect = true;
            this.duplicateList.GridLines = true;
            this.duplicateList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.duplicateList.Location = new System.Drawing.Point(12, 12);
            this.duplicateList.Name = "duplicateList";
            this.duplicateList.Size = new System.Drawing.Size(617, 558);
            this.duplicateList.TabIndex = 0;
            this.duplicateList.UseCompatibleStateImageBehavior = false;
            this.duplicateList.View = System.Windows.Forms.View.Details;
            this.duplicateList.Resize += new System.EventHandler(this.duplicateList_Resize);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File Name";
            this.columnHeader1.Width = 612;
            // 
            // bDelSelected
            // 
            this.bDelSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bDelSelected.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bDelSelected.Location = new System.Drawing.Point(333, 579);
            this.bDelSelected.Name = "bDelSelected";
            this.bDelSelected.Size = new System.Drawing.Size(101, 28);
            this.bDelSelected.TabIndex = 2;
            this.bDelSelected.Text = "Delete Checked";
            this.bDelSelected.UseVisualStyleBackColor = true;
            this.bDelSelected.Click += new System.EventHandler(this.bDelSelected_Click);
            // 
            // bSelAll
            // 
            this.bSelAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bSelAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSelAll.Location = new System.Drawing.Point(12, 579);
            this.bSelAll.Name = "bSelAll";
            this.bSelAll.Size = new System.Drawing.Size(101, 28);
            this.bSelAll.TabIndex = 3;
            this.bSelAll.Text = "Check All";
            this.bSelAll.UseVisualStyleBackColor = true;
            this.bSelAll.Click += new System.EventHandler(this.bSelAll_Click);
            // 
            // b
            // 
            this.b.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b.Location = new System.Drawing.Point(119, 579);
            this.b.Name = "b";
            this.b.Size = new System.Drawing.Size(101, 28);
            this.b.TabIndex = 4;
            this.b.Text = "Check None";
            this.b.UseVisualStyleBackColor = true;
            this.b.Click += new System.EventHandler(this.b_Click);
            // 
            // bSelInverse
            // 
            this.bSelInverse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bSelInverse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSelInverse.Location = new System.Drawing.Point(226, 579);
            this.bSelInverse.Name = "bSelInverse";
            this.bSelInverse.Size = new System.Drawing.Size(101, 28);
            this.bSelInverse.TabIndex = 5;
            this.bSelInverse.Text = "Check Inverse";
            this.bSelInverse.UseVisualStyleBackColor = true;
            this.bSelInverse.Click += new System.EventHandler(this.bSelInverse_Click);
            // 
            // bClose
            // 
            this.bClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bClose.Location = new System.Drawing.Point(528, 579);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(101, 28);
            this.bClose.TabIndex = 6;
            this.bClose.Text = "Close";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // ResultWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(641, 617);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.bSelInverse);
            this.Controls.Add(this.b);
            this.Controls.Add(this.bSelAll);
            this.Controls.Add(this.bDelSelected);
            this.Controls.Add(this.duplicateList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ResultWindow";
            this.Text = "Duplicate File Results";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ResultWindow_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView duplicateList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button bDelSelected;
        private System.Windows.Forms.Button bSelAll;
        private System.Windows.Forms.Button b;
        private System.Windows.Forms.Button bSelInverse;
        private System.Windows.Forms.Button bClose;
    }
}