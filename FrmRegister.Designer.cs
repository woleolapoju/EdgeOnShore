namespace Edge
{
    partial class FrmRegister
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegister));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.PanFooter = new System.Windows.Forms.Panel();
            this.PanAction = new System.Windows.Forms.FlowLayoutPanel();
            this.mnuAction = new System.Windows.Forms.MenuStrip();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBrowse = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.lblAction = new System.Windows.Forms.Label();
            this.PanButton = new System.Windows.Forms.Panel();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdOk = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmdGetFile = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tFileName = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewJobs = new System.Windows.Forms.DataGridView();
            this.Sn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JobName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JobCategory = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ViewFile = new System.Windows.Forms.DataGridViewLinkColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.PanFooter.SuspendLayout();
            this.PanAction.SuspendLayout();
            this.mnuAction.SuspendLayout();
            this.PanButton.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJobs)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.PanFooter, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(604, 350);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Job/Contract Information";
            // 
            // PanFooter
            // 
            this.PanFooter.BackColor = System.Drawing.Color.BurlyWood;
            this.tableLayoutPanel1.SetColumnSpan(this.PanFooter, 2);
            this.PanFooter.Controls.Add(this.PanAction);
            this.PanFooter.Controls.Add(this.PanButton);
            this.PanFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanFooter.Location = new System.Drawing.Point(0, 301);
            this.PanFooter.Margin = new System.Windows.Forms.Padding(0);
            this.PanFooter.Name = "PanFooter";
            this.PanFooter.Size = new System.Drawing.Size(604, 49);
            this.PanFooter.TabIndex = 226;
            // 
            // PanAction
            // 
            this.PanAction.BackColor = System.Drawing.Color.White;
            this.PanAction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanAction.Controls.Add(this.mnuAction);
            this.PanAction.Controls.Add(this.lblAction);
            this.PanAction.Location = new System.Drawing.Point(4, 4);
            this.PanAction.Margin = new System.Windows.Forms.Padding(10);
            this.PanAction.Name = "PanAction";
            this.PanAction.Size = new System.Drawing.Size(195, 41);
            this.PanAction.TabIndex = 55;
            // 
            // mnuAction
            // 
            this.mnuAction.AllowMerge = false;
            this.mnuAction.BackColor = System.Drawing.Color.White;
            this.mnuAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.mnuEdit,
            this.mnuBrowse,
            this.mnuDelete});
            this.mnuAction.Location = new System.Drawing.Point(1, 0);
            this.mnuAction.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.mnuAction.Name = "mnuAction";
            this.mnuAction.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mnuAction.Size = new System.Drawing.Size(189, 24);
            this.mnuAction.TabIndex = 52;
            this.mnuAction.Text = "mnuAction";
            // 
            // mnuNew
            // 
            this.mnuNew.Font = new System.Drawing.Font("Tahoma", 8F);
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.Size = new System.Drawing.Size(40, 20);
            this.mnuNew.Text = "New";
            this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Font = new System.Drawing.Font("Tahoma", 8F);
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(37, 20);
            this.mnuEdit.Text = "Edit";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // mnuBrowse
            // 
            this.mnuBrowse.Font = new System.Drawing.Font("Tahoma", 8F);
            this.mnuBrowse.Name = "mnuBrowse";
            this.mnuBrowse.Size = new System.Drawing.Size(54, 20);
            this.mnuBrowse.Text = "Browse";
            this.mnuBrowse.Click += new System.EventHandler(this.mnuBrowse_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Font = new System.Drawing.Font("Tahoma", 8F);
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(50, 20);
            this.mnuDelete.Text = "Delete";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // lblAction
            // 
            this.lblAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAction.ForeColor = System.Drawing.Color.Red;
            this.lblAction.Location = new System.Drawing.Point(12, 24);
            this.lblAction.Margin = new System.Windows.Forms.Padding(12, 0, 3, 0);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(175, 14);
            this.lblAction.TabIndex = 11;
            this.lblAction.Text = "?";
            this.lblAction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PanButton
            // 
            this.PanButton.Controls.Add(this.cmdClose);
            this.PanButton.Controls.Add(this.cmdOk);
            this.PanButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanButton.Location = new System.Drawing.Point(425, 0);
            this.PanButton.Name = "PanButton";
            this.PanButton.Size = new System.Drawing.Size(179, 49);
            this.PanButton.TabIndex = 1;
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Location = new System.Drawing.Point(104, 4);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(72, 41);
            this.cmdClose.TabIndex = 17;
            this.cmdClose.Text = "&Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            // 
            // cmdOk
            // 
            this.cmdOk.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmdOk.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOk.Location = new System.Drawing.Point(3, 4);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(101, 41);
            this.cmdOk.TabIndex = 15;
            this.cmdOk.Text = "&Ok";
            this.cmdOk.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(598, 127);
            this.panel1.TabIndex = 0;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(118, 71);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(130, 25);
            this.textBox3.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Coy. RegNo:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.BurlyWood;
            this.panel3.Controls.Add(this.cmdGetFile);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.tFileName);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 98);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(598, 29);
            this.panel3.TabIndex = 2;
            // 
            // cmdGetFile
            // 
            this.cmdGetFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdGetFile.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmdGetFile.Location = new System.Drawing.Point(425, 1);
            this.cmdGetFile.Name = "cmdGetFile";
            this.cmdGetFile.Size = new System.Drawing.Size(33, 27);
            this.cmdGetFile.TabIndex = 202;
            this.cmdGetFile.Text = "...";
            this.cmdGetFile.UseVisualStyleBackColor = true;
            this.cmdGetFile.Click += new System.EventHandler(this.cmdGetFile_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 210;
            this.label6.Text = "eDocument:";
            // 
            // tFileName
            // 
            this.tFileName.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.tFileName.Location = new System.Drawing.Point(118, 2);
            this.tFileName.Name = "tFileName";
            this.tFileName.Size = new System.Drawing.Size(307, 25);
            this.tFileName.TabIndex = 201;
            this.tFileName.Tag = "RctNo";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(118, 43);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(457, 25);
            this.textBox2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Company Name:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(118, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(130, 25);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "RefNo:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewJobs);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 157);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(598, 141);
            this.panel2.TabIndex = 1;
            // 
            // dataGridViewJobs
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.dataGridViewJobs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewJobs.BackgroundColor = System.Drawing.Color.FloralWhite;
            this.dataGridViewJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewJobs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sn,
            this.Bid,
            this.JobName,
            this.JobCategory,
            this.ViewFile});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewJobs.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewJobs.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewJobs.Name = "dataGridViewJobs";
            this.dataGridViewJobs.Size = new System.Drawing.Size(598, 141);
            this.dataGridViewJobs.TabIndex = 6;
            // 
            // Sn
            // 
            this.Sn.HeaderText = "Sn";
            this.Sn.Name = "Sn";
            this.Sn.Width = 50;
            // 
            // Bid
            // 
            this.Bid.HeaderText = "BidRef";
            this.Bid.Name = "Bid";
            // 
            // JobName
            // 
            this.JobName.HeaderText = "JobName";
            this.JobName.Name = "JobName";
            this.JobName.Width = 250;
            // 
            // JobCategory
            // 
            this.JobCategory.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.JobCategory.DisplayStyleForCurrentCellOnly = true;
            this.JobCategory.HeaderText = "JobCategory";
            this.JobCategory.Items.AddRange(new object[] {
            "Works",
            "Consultancy",
            "Services"});
            this.JobCategory.Name = "JobCategory";
            // 
            // ViewFile
            // 
            this.ViewFile.HeaderText = "eDoc";
            this.ViewFile.Name = "ViewFile";
            this.ViewFile.Text = "View File";
            this.ViewFile.UseColumnTextForLinkValue = true;
            this.ViewFile.Width = 60;
            // 
            // FrmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(604, 350);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contractor Register";
            this.Load += new System.EventHandler(this.FrmRegister_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.PanFooter.ResumeLayout(false);
            this.PanAction.ResumeLayout(false);
            this.PanAction.PerformLayout();
            this.mnuAction.ResumeLayout(false);
            this.mnuAction.PerformLayout();
            this.PanButton.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJobs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewJobs;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Panel PanFooter;
        internal System.Windows.Forms.FlowLayoutPanel PanAction;
        internal System.Windows.Forms.MenuStrip mnuAction;
        internal System.Windows.Forms.ToolStripMenuItem mnuNew;
        internal System.Windows.Forms.ToolStripMenuItem mnuEdit;
        internal System.Windows.Forms.ToolStripMenuItem mnuBrowse;
        internal System.Windows.Forms.ToolStripMenuItem mnuDelete;
        internal System.Windows.Forms.Label lblAction;
        internal System.Windows.Forms.Panel PanButton;
        internal System.Windows.Forms.Button cmdClose;
        internal System.Windows.Forms.Button cmdOk;
        private System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.Button cmdGetFile;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox tFileName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bid;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobName;
        private System.Windows.Forms.DataGridViewComboBoxColumn JobCategory;
        private System.Windows.Forms.DataGridViewLinkColumn ViewFile;
    }
}