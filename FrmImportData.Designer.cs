namespace Edge
{
    partial class FrmImportData
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImportData));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdLoad = new System.Windows.Forms.Button();
            this.cboSheet = new System.Windows.Forms.ComboBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.cmdGetFile = new System.Windows.Forms.Button();
            this.lblFilename = new System.Windows.Forms.Label();
            this.Dgrid = new System.Windows.Forms.DataGridView();
            this.cntxActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInsertColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRemoveColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lnkUpdate = new System.Windows.Forms.LinkLabel();
            this.radStaff = new System.Windows.Forms.RadioButton();
            this.cmdUpload = new System.Windows.Forms.Button();
            this.lblListCount = new System.Windows.Forms.Label();
            this.RadVendor = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cGrp = new System.Windows.Forms.ComboBox();
            this.lblGrp = new System.Windows.Forms.Label();
            this.RadSchool = new System.Windows.Forms.RadioButton();
            this.RadStudent = new System.Windows.Forms.RadioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.DGridReal = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgrid)).BeginInit();
            this.cntxActions.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGridReal)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Dgrid, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(901, 343);
            this.tableLayoutPanel1.TabIndex = 30;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Controls.Add(this.cmdLoad);
            this.panel1.Controls.Add(this.cboSheet);
            this.panel1.Controls.Add(this.txtFileName);
            this.panel1.Controls.Add(this.cmdGetFile);
            this.panel1.Controls.Add(this.lblFilename);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(895, 36);
            this.panel1.TabIndex = 0;
            // 
            // cmdLoad
            // 
            this.cmdLoad.Location = new System.Drawing.Point(681, 4);
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(113, 28);
            this.cmdLoad.TabIndex = 30;
            this.cmdLoad.Text = "LOAD";
            this.cmdLoad.UseVisualStyleBackColor = true;
            this.cmdLoad.Visible = false;
            this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
            // 
            // cboSheet
            // 
            this.cboSheet.FormattingEnabled = true;
            this.cboSheet.Location = new System.Drawing.Point(479, 9);
            this.cboSheet.Name = "cboSheet";
            this.cboSheet.Size = new System.Drawing.Size(198, 21);
            this.cboSheet.TabIndex = 29;
            this.cboSheet.SelectedIndexChanged += new System.EventHandler(this.cboSheet_SelectedIndexChanged);
            // 
            // txtFileName
            // 
            this.txtFileName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.Location = new System.Drawing.Point(65, 8);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(379, 23);
            this.txtFileName.TabIndex = 28;
            // 
            // cmdGetFile
            // 
            this.cmdGetFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGetFile.Location = new System.Drawing.Point(445, 7);
            this.cmdGetFile.Name = "cmdGetFile";
            this.cmdGetFile.Size = new System.Drawing.Size(24, 25);
            this.cmdGetFile.TabIndex = 1;
            this.cmdGetFile.Text = "...";
            this.cmdGetFile.UseVisualStyleBackColor = true;
            this.cmdGetFile.Click += new System.EventHandler(this.cmdGetFile_Click);
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilename.Location = new System.Drawing.Point(3, 11);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(60, 15);
            this.lblFilename.TabIndex = 27;
            this.lblFilename.Text = "File Name";
            // 
            // Dgrid
            // 
            this.Dgrid.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.Dgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgrid.ContextMenuStrip = this.cntxActions;
            this.Dgrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dgrid.Location = new System.Drawing.Point(3, 45);
            this.Dgrid.Name = "Dgrid";
            this.Dgrid.RowHeadersWidth = 23;
            this.Dgrid.Size = new System.Drawing.Size(895, 295);
            this.Dgrid.TabIndex = 2;
            this.Dgrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgrid_CellClick);
            this.Dgrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgrid_CellContentClick);
            // 
            // cntxActions
            // 
            this.cntxActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddColumn,
            this.ToolStripMenuItem1,
            this.mnuInsertColumn,
            this.toolStripSeparator1,
            this.mnuRemoveColumn});
            this.cntxActions.Name = "ContextMenuStrip1";
            this.cntxActions.Size = new System.Drawing.Size(164, 82);
            // 
            // mnuAddColumn
            // 
            this.mnuAddColumn.Name = "mnuAddColumn";
            this.mnuAddColumn.Size = new System.Drawing.Size(163, 22);
            this.mnuAddColumn.Text = "Add Column";
            this.mnuAddColumn.Click += new System.EventHandler(this.mnuAddColumn_Click);
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(160, 6);
            // 
            // mnuInsertColumn
            // 
            this.mnuInsertColumn.Name = "mnuInsertColumn";
            this.mnuInsertColumn.Size = new System.Drawing.Size(163, 22);
            this.mnuInsertColumn.Text = "Insert Column";
            this.mnuInsertColumn.Click += new System.EventHandler(this.mnuInsertColumn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // mnuRemoveColumn
            // 
            this.mnuRemoveColumn.Name = "mnuRemoveColumn";
            this.mnuRemoveColumn.Size = new System.Drawing.Size(163, 22);
            this.mnuRemoveColumn.Text = "Remove Column";
            this.mnuRemoveColumn.Click += new System.EventHandler(this.mnuRemoveColumn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Tan;
            this.panel2.Controls.Add(this.lnkUpdate);
            this.panel2.Controls.Add(this.radStaff);
            this.panel2.Controls.Add(this.cmdUpload);
            this.panel2.Controls.Add(this.lblListCount);
            this.panel2.Controls.Add(this.RadVendor);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.RadSchool);
            this.panel2.Controls.Add(this.RadStudent);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(895, 31);
            this.panel2.TabIndex = 3;
            // 
            // lnkUpdate
            // 
            this.lnkUpdate.AutoSize = true;
            this.lnkUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkUpdate.Location = new System.Drawing.Point(532, 8);
            this.lnkUpdate.Name = "lnkUpdate";
            this.lnkUpdate.Size = new System.Drawing.Size(55, 15);
            this.lnkUpdate.TabIndex = 592;
            this.lnkUpdate.TabStop = true;
            this.lnkUpdate.Text = "UPDATE";
            this.lnkUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUpdate_LinkClicked);
            // 
            // radStaff
            // 
            this.radStaff.AutoSize = true;
            this.radStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radStaff.ForeColor = System.Drawing.Color.White;
            this.radStaff.Location = new System.Drawing.Point(198, 6);
            this.radStaff.Name = "radStaff";
            this.radStaff.Size = new System.Drawing.Size(49, 19);
            this.radStaff.TabIndex = 590;
            this.radStaff.Text = "Staff";
            this.radStaff.UseVisualStyleBackColor = true;
            this.radStaff.CheckedChanged += new System.EventHandler(this.radStaff_CheckedChanged);
            // 
            // cmdUpload
            // 
            this.cmdUpload.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdUpload.Location = new System.Drawing.Point(744, 0);
            this.cmdUpload.Name = "cmdUpload";
            this.cmdUpload.Size = new System.Drawing.Size(151, 31);
            this.cmdUpload.TabIndex = 589;
            this.cmdUpload.Text = "UPLOAD";
            this.cmdUpload.UseVisualStyleBackColor = true;
            this.cmdUpload.Click += new System.EventHandler(this.cmdUpload_Click);
            // 
            // lblListCount
            // 
            this.lblListCount.AutoSize = true;
            this.lblListCount.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblListCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListCount.ForeColor = System.Drawing.Color.Red;
            this.lblListCount.Location = new System.Drawing.Point(615, 10);
            this.lblListCount.Name = "lblListCount";
            this.lblListCount.Size = new System.Drawing.Size(14, 13);
            this.lblListCount.TabIndex = 588;
            this.lblListCount.Text = "0";
            this.lblListCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RadVendor
            // 
            this.RadVendor.AutoSize = true;
            this.RadVendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadVendor.ForeColor = System.Drawing.Color.White;
            this.RadVendor.Location = new System.Drawing.Point(134, 5);
            this.RadVendor.Name = "RadVendor";
            this.RadVendor.Size = new System.Drawing.Size(64, 19);
            this.RadVendor.TabIndex = 587;
            this.RadVendor.Text = "Vendor";
            this.RadVendor.UseVisualStyleBackColor = true;
            this.RadVendor.CheckedChanged += new System.EventHandler(this.RadVendor_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel3.Controls.Add(this.cGrp);
            this.panel3.Controls.Add(this.lblGrp);
            this.panel3.Location = new System.Drawing.Point(255, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(269, 24);
            this.panel3.TabIndex = 586;
            // 
            // cGrp
            // 
            this.cGrp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cGrp.DropDownWidth = 243;
            this.cGrp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cGrp.FormattingEnabled = true;
            this.cGrp.Location = new System.Drawing.Point(52, 1);
            this.cGrp.Name = "cGrp";
            this.cGrp.Size = new System.Drawing.Size(215, 21);
            this.cGrp.TabIndex = 2;
            this.cGrp.SelectedIndexChanged += new System.EventHandler(this.cSchool_SelectedIndexChanged);
            // 
            // lblGrp
            // 
            this.lblGrp.AutoSize = true;
            this.lblGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrp.ForeColor = System.Drawing.Color.Black;
            this.lblGrp.Location = new System.Drawing.Point(2, 5);
            this.lblGrp.Name = "lblGrp";
            this.lblGrp.Size = new System.Drawing.Size(42, 13);
            this.lblGrp.TabIndex = 561;
            this.lblGrp.Text = "School:";
            // 
            // RadSchool
            // 
            this.RadSchool.AutoSize = true;
            this.RadSchool.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadSchool.ForeColor = System.Drawing.Color.White;
            this.RadSchool.Location = new System.Drawing.Point(71, 5);
            this.RadSchool.Name = "RadSchool";
            this.RadSchool.Size = new System.Drawing.Size(63, 19);
            this.RadSchool.TabIndex = 585;
            this.RadSchool.Text = "School";
            this.RadSchool.UseVisualStyleBackColor = true;
            this.RadSchool.CheckedChanged += new System.EventHandler(this.RadSchool_CheckedChanged);
            // 
            // RadStudent
            // 
            this.RadStudent.AutoSize = true;
            this.RadStudent.Checked = true;
            this.RadStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadStudent.ForeColor = System.Drawing.Color.White;
            this.RadStudent.Location = new System.Drawing.Point(4, 5);
            this.RadStudent.Name = "RadStudent";
            this.RadStudent.Size = new System.Drawing.Size(67, 19);
            this.RadStudent.TabIndex = 584;
            this.RadStudent.TabStop = true;
            this.RadStudent.Text = "Student";
            this.RadStudent.UseVisualStyleBackColor = true;
            this.RadStudent.CheckedChanged += new System.EventHandler(this.RadStudent_CheckedChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(905, 517);
            this.splitContainer1.SplitterDistance = 347;
            this.splitContainer1.TabIndex = 31;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Tan;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.DGridReal, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(901, 162);
            this.tableLayoutPanel2.TabIndex = 32;
            // 
            // DGridReal
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.DGridReal.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGridReal.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.DGridReal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGridReal.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGridReal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGridReal.Location = new System.Drawing.Point(3, 40);
            this.DGridReal.Name = "DGridReal";
            this.DGridReal.Size = new System.Drawing.Size(895, 119);
            this.DGridReal.TabIndex = 8;
            // 
            // FrmImportData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(905, 517);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmImportData";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import Data";
            this.Load += new System.EventHandler(this.FrmImportData_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgrid)).EndInit();
            this.cntxActions.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGridReal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button cmdGetFile;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.DataGridView Dgrid;
        private System.Windows.Forms.ComboBox cboSheet;
        private System.Windows.Forms.Button cmdLoad;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.RadioButton RadVendor;
        internal System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.ComboBox cGrp;
        internal System.Windows.Forms.Label lblGrp;
        internal System.Windows.Forms.RadioButton RadSchool;
        internal System.Windows.Forms.RadioButton RadStudent;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView DGridReal;
        internal System.Windows.Forms.Label lblListCount;
        private System.Windows.Forms.Button cmdUpload;
        internal System.Windows.Forms.ContextMenuStrip cntxActions;
        internal System.Windows.Forms.ToolStripMenuItem mnuAddColumn;
        internal System.Windows.Forms.ToolStripMenuItem mnuRemoveColumn;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuInsertColumn;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.RadioButton radStaff;
        internal System.Windows.Forms.LinkLabel lnkUpdate;
    }
}