namespace Edge
{
    partial class FrmMandate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMandate));
            this.TableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lvList = new System.Windows.Forms.ListView();
            this.ColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CMTask = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.btnDeduction = new System.Windows.Forms.Button();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.PanMandate = new System.Windows.Forms.Panel();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.Label3 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.Label15 = new System.Windows.Forms.Label();
            this.cmdNewMandate = new System.Windows.Forms.Button();
            this.CmdCancel = new System.Windows.Forms.Button();
            this.TableLayoutPanel3.SuspendLayout();
            this.CMTask.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.PanMandate.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel3
            // 
            this.TableLayoutPanel3.ColumnCount = 1;
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel3.Controls.Add(this.lvList, 0, 0);
            this.TableLayoutPanel3.Controls.Add(this.Panel1, 0, 1);
            this.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel3.Name = "TableLayoutPanel3";
            this.TableLayoutPanel3.RowCount = 2;
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel3.Size = new System.Drawing.Size(684, 511);
            this.TableLayoutPanel3.TabIndex = 98;
            // 
            // lvList
            // 
            this.lvList.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lvList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader,
            this.ColumnHeader2,
            this.ColumnHeader1,
            this.ColumnHeader3,
            this.ColumnHeader5,
            this.columnHeader4});
            this.lvList.ContextMenuStrip = this.CMTask;
            this.lvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvList.FullRowSelect = true;
            this.lvList.GridLines = true;
            this.lvList.Location = new System.Drawing.Point(3, 3);
            this.lvList.MultiSelect = false;
            this.lvList.Name = "lvList";
            this.lvList.Size = new System.Drawing.Size(678, 447);
            this.lvList.TabIndex = 23;
            this.lvList.UseCompatibleStateImageBehavior = false;
            this.lvList.View = System.Windows.Forms.View.Details;
            this.lvList.SelectedIndexChanged += new System.EventHandler(this.lvList_SelectedIndexChanged);
            this.lvList.DoubleClick += new System.EventHandler(this.lvList_DoubleClick);
            // 
            // ColumnHeader
            // 
            this.ColumnHeader.Text = "Mandate Number";
            this.ColumnHeader.Width = 181;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Date";
            this.ColumnHeader2.Width = 107;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "NoOfPayments";
            this.ColumnHeader1.Width = 95;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Total Amount";
            this.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader3.Width = 133;
            // 
            // ColumnHeader5
            // 
            this.ColumnHeader5.Text = "Authorised";
            this.ColumnHeader5.Width = 82;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Type";
            // 
            // CMTask
            // 
            this.CMTask.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDelete,
            this.toolStripMenuItem1,
            this.mnuExport});
            this.CMTask.Name = "CMTask";
            this.CMTask.Size = new System.Drawing.Size(176, 54);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(175, 22);
            this.mnuDelete.Text = "Delete Record";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 6);
            // 
            // mnuExport
            // 
            this.mnuExport.Name = "mnuExport";
            this.mnuExport.Size = new System.Drawing.Size(175, 22);
            this.mnuExport.Text = "EXPORT MANDATE";
            this.mnuExport.Click += new System.EventHandler(this.mnuExport_Click);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.Tan;
            this.Panel1.Controls.Add(this.btnDeduction);
            this.Panel1.Controls.Add(this.cmdSearch);
            this.Panel1.Controls.Add(this.PanMandate);
            this.Panel1.Controls.Add(this.cmdNewMandate);
            this.Panel1.Controls.Add(this.CmdCancel);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Panel1.Location = new System.Drawing.Point(3, 456);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(678, 52);
            this.Panel1.TabIndex = 24;
            // 
            // btnDeduction
            // 
            this.btnDeduction.BackColor = System.Drawing.Color.Lavender;
            this.btnDeduction.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeduction.Location = new System.Drawing.Point(342, 0);
            this.btnDeduction.Name = "btnDeduction";
            this.btnDeduction.Size = new System.Drawing.Size(111, 52);
            this.btnDeduction.TabIndex = 246;
            this.btnDeduction.Text = "&NEW DEDUCTION";
            this.btnDeduction.UseVisualStyleBackColor = true;
            this.btnDeduction.Click += new System.EventHandler(this.btnDeduction_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.BackColor = System.Drawing.Color.Lavender;
            this.cmdSearch.Location = new System.Drawing.Point(453, 0);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(102, 52);
            this.cmdSearch.TabIndex = 245;
            this.cmdSearch.Text = "&SEARCH";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // PanMandate
            // 
            this.PanMandate.BackColor = System.Drawing.Color.Transparent;
            this.PanMandate.Controls.Add(this.dtpEndDate);
            this.PanMandate.Controls.Add(this.Label3);
            this.PanMandate.Controls.Add(this.dtpStartDate);
            this.PanMandate.Controls.Add(this.Label15);
            this.PanMandate.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanMandate.Location = new System.Drawing.Point(0, 0);
            this.PanMandate.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.PanMandate.Name = "PanMandate";
            this.PanMandate.Size = new System.Drawing.Size(167, 52);
            this.PanMandate.TabIndex = 244;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(61, 27);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(102, 22);
            this.dtpEndDate.TabIndex = 246;
            this.dtpEndDate.Tag = "Date";
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Label3.ForeColor = System.Drawing.Color.White;
            this.Label3.Location = new System.Drawing.Point(0, 30);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(57, 15);
            this.Label3.TabIndex = 245;
            this.Label3.Text = "End Date:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(61, 3);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(102, 22);
            this.dtpStartDate.TabIndex = 244;
            this.dtpStartDate.Tag = "Date";
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Label15.ForeColor = System.Drawing.Color.White;
            this.Label15.Location = new System.Drawing.Point(0, 6);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(61, 15);
            this.Label15.TabIndex = 235;
            this.Label15.Text = "Start Date:";
            // 
            // cmdNewMandate
            // 
            this.cmdNewMandate.BackColor = System.Drawing.Color.Lavender;
            this.cmdNewMandate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNewMandate.Location = new System.Drawing.Point(224, 0);
            this.cmdNewMandate.Name = "cmdNewMandate";
            this.cmdNewMandate.Size = new System.Drawing.Size(118, 52);
            this.cmdNewMandate.TabIndex = 22;
            this.cmdNewMandate.Text = "&NEW MANDATE";
            this.cmdNewMandate.UseVisualStyleBackColor = true;
            this.cmdNewMandate.Click += new System.EventHandler(this.cmdNewMandate_Click);
            // 
            // CmdCancel
            // 
            this.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.CmdCancel.Location = new System.Drawing.Point(602, 0);
            this.CmdCancel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.CmdCancel.Name = "CmdCancel";
            this.CmdCancel.Size = new System.Drawing.Size(76, 52);
            this.CmdCancel.TabIndex = 21;
            this.CmdCancel.Text = "&Close";
            this.CmdCancel.UseVisualStyleBackColor = true;
            // 
            // FrmMandate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(684, 511);
            this.Controls.Add(this.TableLayoutPanel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMandate";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mandate";
            this.Load += new System.EventHandler(this.FrmMandate_Load);
            this.TableLayoutPanel3.ResumeLayout(false);
            this.CMTask.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.PanMandate.ResumeLayout(false);
            this.PanMandate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel3;
        internal System.Windows.Forms.ListView lvList;
        internal System.Windows.Forms.ColumnHeader ColumnHeader;
        internal System.Windows.Forms.ColumnHeader ColumnHeader2;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader3;
        internal System.Windows.Forms.ColumnHeader ColumnHeader5;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Button cmdSearch;
        internal System.Windows.Forms.Panel PanMandate;
        internal System.Windows.Forms.DateTimePicker dtpEndDate;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.DateTimePicker dtpStartDate;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.Button cmdNewMandate;
        internal System.Windows.Forms.Button CmdCancel;
        internal System.Windows.Forms.ContextMenuStrip CMTask;
        internal System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        internal System.Windows.Forms.Button btnDeduction;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuExport;
    }
}