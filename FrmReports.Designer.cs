namespace Edge
{
    partial class FrmReports
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Mandate");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Payment List");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Payment Deduction List");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("School List");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Student List");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Staff List");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("Vendor List");
            this.lvRpt = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.lblfocus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkVendor = new System.Windows.Forms.CheckBox();
            this.chkStaff = new System.Windows.Forms.CheckBox();
            this.chkSchool = new System.Windows.Forms.CheckBox();
            this.chkStudent = new System.Windows.Forms.CheckBox();
            this.cboMandateNo = new System.Windows.Forms.ComboBox();
            this.lblMandateNo = new System.Windows.Forms.Label();
            this.cboGrpBy = new System.Windows.Forms.ComboBox();
            this.lblGrpBy = new System.Windows.Forms.Label();
            this.cboClose = new System.Windows.Forms.Button();
            this.cboOk = new System.Windows.Forms.Button();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStart = new System.Windows.Forms.Label();
            this.cboGrpFilter = new System.Windows.Forms.ComboBox();
            this.lblGrpFilter = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvRpt
            // 
            this.lvRpt.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lvRpt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvRpt.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvRpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRpt.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvRpt.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7});
            this.lvRpt.Location = new System.Drawing.Point(3, 3);
            this.lvRpt.Name = "lvRpt";
            this.lvRpt.Size = new System.Drawing.Size(475, 318);
            this.lvRpt.TabIndex = 0;
            this.lvRpt.UseCompatibleStateImageBehavior = false;
            this.lvRpt.View = System.Windows.Forms.View.Details;
            this.lvRpt.SelectedIndexChanged += new System.EventHandler(this.lvRpt_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Report Title";
            this.columnHeader1.Width = 442;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lvRpt, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(481, 486);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Tan;
            this.panel3.Controls.Add(this.cboGrpFilter);
            this.panel3.Controls.Add(this.lblGrpFilter);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.lblReportTitle);
            this.panel3.Controls.Add(this.lblfocus);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.cboMandateNo);
            this.panel3.Controls.Add(this.lblMandateNo);
            this.panel3.Controls.Add(this.cboGrpBy);
            this.panel3.Controls.Add(this.lblGrpBy);
            this.panel3.Controls.Add(this.cboClose);
            this.panel3.Controls.Add(this.cboOk);
            this.panel3.Controls.Add(this.dtpEndDate);
            this.panel3.Controls.Add(this.lblEnd);
            this.panel3.Controls.Add(this.dtpStartDate);
            this.panel3.Controls.Add(this.lblStart);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 327);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(475, 156);
            this.panel3.TabIndex = 269;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(444, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "RED";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(225, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Relevant criteria for selected Report are in RED";
            // 
            // lblReportTitle
            // 
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lblReportTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportTitle.ForeColor = System.Drawing.Color.Crimson;
            this.lblReportTitle.Location = new System.Drawing.Point(9, 5);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(94, 19);
            this.lblReportTitle.TabIndex = 12;
            this.lblReportTitle.Text = "Payment List";
            // 
            // lblfocus
            // 
            this.lblfocus.AutoSize = true;
            this.lblfocus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfocus.ForeColor = System.Drawing.Color.Red;
            this.lblfocus.Location = new System.Drawing.Point(230, 36);
            this.lblfocus.Name = "lblfocus";
            this.lblfocus.Size = new System.Drawing.Size(62, 13);
            this.lblfocus.TabIndex = 11;
            this.lblfocus.Text = "FOCUS ON";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkVendor);
            this.panel1.Controls.Add(this.chkStaff);
            this.panel1.Controls.Add(this.chkSchool);
            this.panel1.Controls.Add(this.chkStudent);
            this.panel1.Location = new System.Drawing.Point(225, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(77, 78);
            this.panel1.TabIndex = 10;
            // 
            // chkVendor
            // 
            this.chkVendor.AutoSize = true;
            this.chkVendor.Checked = true;
            this.chkVendor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVendor.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVendor.ForeColor = System.Drawing.Color.White;
            this.chkVendor.Location = new System.Drawing.Point(3, 57);
            this.chkVendor.Name = "chkVendor";
            this.chkVendor.Size = new System.Drawing.Size(63, 17);
            this.chkVendor.TabIndex = 3;
            this.chkVendor.Text = "Vendor";
            this.chkVendor.UseVisualStyleBackColor = true;
            // 
            // chkStaff
            // 
            this.chkStaff.AutoSize = true;
            this.chkStaff.Checked = true;
            this.chkStaff.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStaff.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStaff.ForeColor = System.Drawing.Color.White;
            this.chkStaff.Location = new System.Drawing.Point(3, 39);
            this.chkStaff.Name = "chkStaff";
            this.chkStaff.Size = new System.Drawing.Size(50, 17);
            this.chkStaff.TabIndex = 2;
            this.chkStaff.Text = "Staff";
            this.chkStaff.UseVisualStyleBackColor = true;
            // 
            // chkSchool
            // 
            this.chkSchool.AutoSize = true;
            this.chkSchool.Checked = true;
            this.chkSchool.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSchool.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSchool.ForeColor = System.Drawing.Color.White;
            this.chkSchool.Location = new System.Drawing.Point(3, 22);
            this.chkSchool.Name = "chkSchool";
            this.chkSchool.Size = new System.Drawing.Size(61, 17);
            this.chkSchool.TabIndex = 1;
            this.chkSchool.Text = "School";
            this.chkSchool.UseVisualStyleBackColor = true;
            // 
            // chkStudent
            // 
            this.chkStudent.AutoSize = true;
            this.chkStudent.Checked = true;
            this.chkStudent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStudent.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStudent.ForeColor = System.Drawing.Color.White;
            this.chkStudent.Location = new System.Drawing.Point(4, 4);
            this.chkStudent.Name = "chkStudent";
            this.chkStudent.Size = new System.Drawing.Size(67, 17);
            this.chkStudent.TabIndex = 0;
            this.chkStudent.Text = "Student";
            this.chkStudent.UseVisualStyleBackColor = true;
            // 
            // cboMandateNo
            // 
            this.cboMandateNo.FormattingEnabled = true;
            this.cboMandateNo.Location = new System.Drawing.Point(86, 130);
            this.cboMandateNo.Name = "cboMandateNo";
            this.cboMandateNo.Size = new System.Drawing.Size(130, 21);
            this.cboMandateNo.TabIndex = 9;
            // 
            // lblMandateNo
            // 
            this.lblMandateNo.AutoSize = true;
            this.lblMandateNo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMandateNo.Location = new System.Drawing.Point(9, 134);
            this.lblMandateNo.Name = "lblMandateNo";
            this.lblMandateNo.Size = new System.Drawing.Size(74, 13);
            this.lblMandateNo.TabIndex = 8;
            this.lblMandateNo.Text = "Mandate No:";
            // 
            // cboGrpBy
            // 
            this.cboGrpBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrpBy.FormattingEnabled = true;
            this.cboGrpBy.Items.AddRange(new object[] {
            "",
            "Region",
            "Category",
            "Intervention Line"});
            this.cboGrpBy.Location = new System.Drawing.Point(86, 33);
            this.cboGrpBy.Name = "cboGrpBy";
            this.cboGrpBy.Size = new System.Drawing.Size(130, 21);
            this.cboGrpBy.TabIndex = 7;
            this.cboGrpBy.SelectedIndexChanged += new System.EventHandler(this.cboGrpBy_SelectedIndexChanged);
            // 
            // lblGrpBy
            // 
            this.lblGrpBy.AutoSize = true;
            this.lblGrpBy.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrpBy.ForeColor = System.Drawing.Color.Red;
            this.lblGrpBy.Location = new System.Drawing.Point(9, 34);
            this.lblGrpBy.Name = "lblGrpBy";
            this.lblGrpBy.Size = new System.Drawing.Size(58, 13);
            this.lblGrpBy.TabIndex = 6;
            this.lblGrpBy.Text = "Group By:";
            // 
            // cboClose
            // 
            this.cboClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboClose.Location = new System.Drawing.Point(409, 33);
            this.cboClose.Name = "cboClose";
            this.cboClose.Size = new System.Drawing.Size(65, 96);
            this.cboClose.TabIndex = 5;
            this.cboClose.Text = "Close";
            this.cboClose.UseVisualStyleBackColor = true;
            this.cboClose.Click += new System.EventHandler(this.cboClose_Click);
            // 
            // cboOk
            // 
            this.cboOk.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOk.Location = new System.Drawing.Point(322, 32);
            this.cboOk.Name = "cboOk";
            this.cboOk.Size = new System.Drawing.Size(83, 98);
            this.cboOk.TabIndex = 4;
            this.cboOk.Text = "Ok";
            this.cboOk.UseVisualStyleBackColor = true;
            this.cboOk.Click += new System.EventHandler(this.cboOk_Click);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(86, 105);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.ShowCheckBox = true;
            this.dtpEndDate.Size = new System.Drawing.Size(130, 22);
            this.dtpEndDate.TabIndex = 3;
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnd.ForeColor = System.Drawing.Color.Red;
            this.lblEnd.Location = new System.Drawing.Point(9, 109);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(57, 13);
            this.lblEnd.TabIndex = 2;
            this.lblEnd.Text = "End Date:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(86, 78);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.ShowCheckBox = true;
            this.dtpStartDate.Size = new System.Drawing.Size(130, 22);
            this.dtpStartDate.TabIndex = 1;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.ForeColor = System.Drawing.Color.Red;
            this.lblStart.Location = new System.Drawing.Point(9, 81);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(61, 13);
            this.lblStart.TabIndex = 0;
            this.lblStart.Text = "Start Date:";
            // 
            // cboGrpFilter
            // 
            this.cboGrpFilter.DropDownWidth = 200;
            this.cboGrpFilter.FormattingEnabled = true;
            this.cboGrpFilter.Location = new System.Drawing.Point(86, 56);
            this.cboGrpFilter.Name = "cboGrpFilter";
            this.cboGrpFilter.Size = new System.Drawing.Size(130, 21);
            this.cboGrpFilter.TabIndex = 16;
            // 
            // lblGrpFilter
            // 
            this.lblGrpFilter.AutoSize = true;
            this.lblGrpFilter.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrpFilter.ForeColor = System.Drawing.Color.Red;
            this.lblGrpFilter.Location = new System.Drawing.Point(9, 57);
            this.lblGrpFilter.Name = "lblGrpFilter";
            this.lblGrpFilter.Size = new System.Drawing.Size(72, 13);
            this.lblGrpFilter.TabIndex = 15;
            this.lblGrpFilter.Text = "Group Filter:";
            // 
            // FrmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(481, 486);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmReports";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.FrmReports_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView lvRpt;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cboGrpBy;
        private System.Windows.Forms.Label lblGrpBy;
        private System.Windows.Forms.Button cboClose;
        private System.Windows.Forms.Button cboOk;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.ComboBox cboMandateNo;
        private System.Windows.Forms.Label lblMandateNo;
        private System.Windows.Forms.Label lblfocus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkVendor;
        private System.Windows.Forms.CheckBox chkStaff;
        private System.Windows.Forms.CheckBox chkSchool;
        private System.Windows.Forms.CheckBox chkStudent;
        private System.Windows.Forms.Label lblReportTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboGrpFilter;
        private System.Windows.Forms.Label lblGrpFilter;
    }
}