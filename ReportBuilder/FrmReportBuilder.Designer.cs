namespace Edge
{
    partial class FrmReportBuilder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportBuilder));
            this.lblTotRecords = new System.Windows.Forms.Label();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.prgProgress = new System.Windows.Forms.ProgressBar();
            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.btnGetAllTables = new System.Windows.Forms.Button();
            this.btnNoOfPages = new System.Windows.Forms.Button();
            this.lblNoOfPages = new System.Windows.Forms.Label();
            this.cmbNoOfRecords = new System.Windows.Forms.ComboBox();
            this.cmbAllDataBases = new System.Windows.Forms.ComboBox();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnGetAllDataBases = new System.Windows.Forms.Button();
            this.lblPageNums = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnLoadSqlServers = new System.Windows.Forms.Button();
            this.cmbSqlServers = new System.Windows.Forms.ComboBox();
            this.grpSqlServers = new System.Windows.Forms.GroupBox();
            this.GrpAuthenticate = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.chkWinAuthen = new System.Windows.Forms.CheckBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpDataManipulate = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.userDataGridView = new System.Windows.Forms.DataGridView();
            this.PanQuery = new System.Windows.Forms.Panel();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.lblFilter = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tFilter = new System.Windows.Forms.TextBox();
            this.cboCriteria = new System.Windows.Forms.ComboBox();
            this.SelColumn = new System.Windows.Forms.NumericUpDown();
            this.chkIgnore = new System.Windows.Forms.CheckBox();
            this.cmdFilter = new System.Windows.Forms.Button();
            this.cmdFind = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.ContextExport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCopyToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.grpSqlServers.SuspendLayout();
            this.GrpAuthenticate.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpDataManipulate.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userDataGridView)).BeginInit();
            this.PanQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelColumn)).BeginInit();
            this.ContextExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTotRecords
            // 
            this.lblTotRecords.AutoSize = true;
            this.lblTotRecords.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lblTotRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotRecords.Location = new System.Drawing.Point(12, 238);
            this.lblTotRecords.Name = "lblTotRecords";
            this.lblTotRecords.Size = new System.Drawing.Size(0, 13);
            this.lblTotRecords.TabIndex = 10;
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(229, 3);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(50, 23);
            this.btnLast.TabIndex = 14;
            this.btnLast.Text = "L&ast";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(178, 4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(50, 23);
            this.btnNext.TabIndex = 13;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(126, 3);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(50, 23);
            this.btnPrevious.TabIndex = 12;
            this.btnPrevious.Text = "<<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // prgProgress
            // 
            this.prgProgress.Location = new System.Drawing.Point(2, 415);
            this.prgProgress.Name = "prgProgress";
            this.prgProgress.Size = new System.Drawing.Size(217, 23);
            this.prgProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgProgress.TabIndex = 8;
            this.prgProgress.Visible = false;
            // 
            // cmbTables
            // 
            this.cmbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTables.FormattingEnabled = true;
            this.cmbTables.Location = new System.Drawing.Point(42, 168);
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(217, 21);
            this.cmbTables.TabIndex = 7;
            // 
            // btnGetAllTables
            // 
            this.btnGetAllTables.Location = new System.Drawing.Point(2, 387);
            this.btnGetAllTables.Name = "btnGetAllTables";
            this.btnGetAllTables.Size = new System.Drawing.Size(217, 23);
            this.btnGetAllTables.TabIndex = 6;
            this.btnGetAllTables.Text = "Get All &Tables";
            this.btnGetAllTables.UseVisualStyleBackColor = true;
            this.btnGetAllTables.Visible = false;
            this.btnGetAllTables.Click += new System.EventHandler(this.btnGetAllTables_Click);
            // 
            // btnNoOfPages
            // 
            this.btnNoOfPages.Location = new System.Drawing.Point(197, 262);
            this.btnNoOfPages.Name = "btnNoOfPages";
            this.btnNoOfPages.Size = new System.Drawing.Size(40, 23);
            this.btnNoOfPages.TabIndex = 10;
            this.btnNoOfPages.Text = "&Set";
            this.btnNoOfPages.UseVisualStyleBackColor = true;
            this.btnNoOfPages.Click += new System.EventHandler(this.btnNoOfPages_Click);
            // 
            // lblNoOfPages
            // 
            this.lblNoOfPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOfPages.Location = new System.Drawing.Point(43, 260);
            this.lblNoOfPages.Name = "lblNoOfPages";
            this.lblNoOfPages.Size = new System.Drawing.Size(93, 27);
            this.lblNoOfPages.TabIndex = 7;
            this.lblNoOfPages.Text = "No. of records per page: ";
            // 
            // cmbNoOfRecords
            // 
            this.cmbNoOfRecords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNoOfRecords.FormatString = "N2";
            this.cmbNoOfRecords.FormattingEnabled = true;
            this.cmbNoOfRecords.Items.AddRange(new object[] {
            "15",
            "25",
            "35",
            "45",
            "55",
            "ALL"});
            this.cmbNoOfRecords.Location = new System.Drawing.Point(137, 263);
            this.cmbNoOfRecords.Name = "cmbNoOfRecords";
            this.cmbNoOfRecords.Size = new System.Drawing.Size(57, 21);
            this.cmbNoOfRecords.TabIndex = 9;
            // 
            // cmbAllDataBases
            // 
            this.cmbAllDataBases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAllDataBases.FormattingEnabled = true;
            this.cmbAllDataBases.Location = new System.Drawing.Point(42, 144);
            this.cmbAllDataBases.Name = "cmbAllDataBases";
            this.cmbAllDataBases.Size = new System.Drawing.Size(217, 21);
            this.cmbAllDataBases.TabIndex = 5;
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(74, 3);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(50, 23);
            this.btnFirst.TabIndex = 11;
            this.btnFirst.Text = "&First";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnGetAllDataBases
            // 
            this.btnGetAllDataBases.Location = new System.Drawing.Point(1, 363);
            this.btnGetAllDataBases.Name = "btnGetAllDataBases";
            this.btnGetAllDataBases.Size = new System.Drawing.Size(217, 23);
            this.btnGetAllDataBases.TabIndex = 4;
            this.btnGetAllDataBases.Text = "Get All &Databases";
            this.btnGetAllDataBases.UseVisualStyleBackColor = true;
            this.btnGetAllDataBases.Visible = false;
            this.btnGetAllDataBases.Click += new System.EventHandler(this.btnGetAllDataBases_Click);
            // 
            // lblPageNums
            // 
            this.lblPageNums.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPageNums.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageNums.Location = new System.Drawing.Point(368, 9);
            this.lblPageNums.Name = "lblPageNums";
            this.lblPageNums.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPageNums.Size = new System.Drawing.Size(381, 14);
            this.lblPageNums.TabIndex = 18;
            this.lblPageNums.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(42, 193);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(218, 43);
            this.btnLoad.TabIndex = 8;
            this.btnLoad.Text = "&Load data";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(168, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(6, 7);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "&Add/Update";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(87, 7);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "&Commit";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnLoadSqlServers
            // 
            this.btnLoadSqlServers.Location = new System.Drawing.Point(2, 339);
            this.btnLoadSqlServers.Name = "btnLoadSqlServers";
            this.btnLoadSqlServers.Size = new System.Drawing.Size(215, 23);
            this.btnLoadSqlServers.TabIndex = 0;
            this.btnLoadSqlServers.Text = "Get all &Sql servers  on network";
            this.btnLoadSqlServers.UseVisualStyleBackColor = true;
            this.btnLoadSqlServers.Visible = false;
            this.btnLoadSqlServers.Click += new System.EventHandler(this.btnLoadSqlServers_Click);
            // 
            // cmbSqlServers
            // 
            this.cmbSqlServers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSqlServers.FormattingEnabled = true;
            this.cmbSqlServers.Location = new System.Drawing.Point(43, 20);
            this.cmbSqlServers.Name = "cmbSqlServers";
            this.cmbSqlServers.Size = new System.Drawing.Size(217, 21);
            this.cmbSqlServers.TabIndex = 1;
            this.cmbSqlServers.SelectedIndexChanged += new System.EventHandler(this.cmbSqlServers_SelectedIndexChanged);
            // 
            // grpSqlServers
            // 
            this.grpSqlServers.Controls.Add(this.PanQuery);
            this.grpSqlServers.Controls.Add(this.lblTotRecords);
            this.grpSqlServers.Controls.Add(this.GrpAuthenticate);
            this.grpSqlServers.Controls.Add(this.prgProgress);
            this.grpSqlServers.Controls.Add(this.cmbTables);
            this.grpSqlServers.Controls.Add(this.btnGetAllTables);
            this.grpSqlServers.Controls.Add(this.cmbAllDataBases);
            this.grpSqlServers.Controls.Add(this.btnGetAllDataBases);
            this.grpSqlServers.Controls.Add(this.btnNoOfPages);
            this.grpSqlServers.Controls.Add(this.btnLoadSqlServers);
            this.grpSqlServers.Controls.Add(this.cmbNoOfRecords);
            this.grpSqlServers.Controls.Add(this.btnLoad);
            this.grpSqlServers.Controls.Add(this.lblNoOfPages);
            this.grpSqlServers.Controls.Add(this.cmbSqlServers);
            this.grpSqlServers.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpSqlServers.Location = new System.Drawing.Point(3, 3);
            this.grpSqlServers.Name = "grpSqlServers";
            this.tableLayoutPanel1.SetRowSpan(this.grpSqlServers, 2);
            this.grpSqlServers.Size = new System.Drawing.Size(338, 540);
            this.grpSqlServers.TabIndex = 8;
            this.grpSqlServers.TabStop = false;
            this.grpSqlServers.Text = "Load and login to SQL server";
            // 
            // GrpAuthenticate
            // 
            this.GrpAuthenticate.Controls.Add(this.txtPassword);
            this.GrpAuthenticate.Controls.Add(this.txtUserName);
            this.GrpAuthenticate.Controls.Add(this.chkWinAuthen);
            this.GrpAuthenticate.Controls.Add(this.Label3);
            this.GrpAuthenticate.Controls.Add(this.Label4);
            this.GrpAuthenticate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpAuthenticate.Location = new System.Drawing.Point(43, 46);
            this.GrpAuthenticate.Name = "GrpAuthenticate";
            this.GrpAuthenticate.Size = new System.Drawing.Size(218, 93);
            this.GrpAuthenticate.TabIndex = 9;
            this.GrpAuthenticate.TabStop = false;
            this.GrpAuthenticate.Text = "Authentication";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(69, 64);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(138, 23);
            this.txtPassword.TabIndex = 5;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(69, 36);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(138, 23);
            this.txtUserName.TabIndex = 4;
            // 
            // chkWinAuthen
            // 
            this.chkWinAuthen.AutoSize = true;
            this.chkWinAuthen.Location = new System.Drawing.Point(9, 18);
            this.chkWinAuthen.Name = "chkWinAuthen";
            this.chkWinAuthen.Size = new System.Drawing.Size(157, 19);
            this.chkWinAuthen.TabIndex = 3;
            this.chkWinAuthen.Text = "Windows Authentication";
            this.chkWinAuthen.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkWinAuthen.UseVisualStyleBackColor = true;
            this.chkWinAuthen.CheckedChanged += new System.EventHandler(this.chkWinAuthen_CheckedChanged);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(6, 68);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(60, 15);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Password:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(6, 41);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(47, 15);
            this.Label4.TabIndex = 0;
            this.Label4.Text = "User ID:";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grpDataManipulate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.grpSqlServers, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.userDataGridView, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1108, 589);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // grpDataManipulate
            // 
            this.grpDataManipulate.BackColor = System.Drawing.Color.Tan;
            this.grpDataManipulate.Controls.Add(this.lblPageNums);
            this.grpDataManipulate.Controls.Add(this.btnFirst);
            this.grpDataManipulate.Controls.Add(this.label1);
            this.grpDataManipulate.Controls.Add(this.btnNext);
            this.grpDataManipulate.Controls.Add(this.btnPrevious);
            this.grpDataManipulate.Controls.Add(this.btnLast);
            this.grpDataManipulate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDataManipulate.Location = new System.Drawing.Point(347, 3);
            this.grpDataManipulate.Name = "grpDataManipulate";
            this.grpDataManipulate.Size = new System.Drawing.Size(758, 32);
            this.grpDataManipulate.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Navigation:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Tan;
            this.panel3.Controls.Add(this.btnRefresh);
            this.panel3.Controls.Add(this.btnUpdate);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(347, 549);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(758, 37);
            this.panel3.TabIndex = 16;
            this.panel3.DoubleClick += new System.EventHandler(this.panel3_DoubleClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(681, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 18;
            this.btnRefresh.Text = "&REFRESH";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // userDataGridView
            // 
            this.userDataGridView.AllowUserToOrderColumns = true;
            this.userDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.userDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userDataGridView.ContextMenuStrip = this.ContextExport;
            this.userDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userDataGridView.Location = new System.Drawing.Point(347, 41);
            this.userDataGridView.Name = "userDataGridView";
            this.userDataGridView.ReadOnly = true;
            this.userDataGridView.Size = new System.Drawing.Size(758, 502);
            this.userDataGridView.TabIndex = 0;
            this.userDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userDataGridView_CellClick);
            // 
            // PanQuery
            // 
            this.PanQuery.Controls.Add(this.UsernameLabel);
            this.PanQuery.Controls.Add(this.lblFilter);
            this.PanQuery.Controls.Add(this.label2);
            this.PanQuery.Controls.Add(this.tFilter);
            this.PanQuery.Controls.Add(this.cboCriteria);
            this.PanQuery.Controls.Add(this.SelColumn);
            this.PanQuery.Controls.Add(this.chkIgnore);
            this.PanQuery.Controls.Add(this.cmdFilter);
            this.PanQuery.Controls.Add(this.cmdFind);
            this.PanQuery.Controls.Add(this.label5);
            this.PanQuery.Controls.Add(this.cmdRefresh);
            this.PanQuery.Controls.Add(this.lblCount);
            this.PanQuery.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanQuery.Location = new System.Drawing.Point(3, 452);
            this.PanQuery.Name = "PanQuery";
            this.PanQuery.Size = new System.Drawing.Size(332, 85);
            this.PanQuery.TabIndex = 11;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(6, 8);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(50, 13);
            this.UsernameLabel.TabIndex = 2;
            this.UsernameLabel.Text = "Column:";
            this.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.Location = new System.Drawing.Point(6, 31);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(58, 13);
            this.lblFilter.TabIndex = 4;
            this.lblFilter.Text = "&Filter Text:";
            this.lblFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(9, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Right click list to export";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tFilter
            // 
            this.tFilter.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tFilter.Location = new System.Drawing.Point(152, 28);
            this.tFilter.Name = "tFilter";
            this.tFilter.Size = new System.Drawing.Size(171, 22);
            this.tFilter.TabIndex = 5;
            // 
            // cboCriteria
            // 
            this.cboCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriteria.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.cboCriteria.FormattingEnabled = true;
            this.cboCriteria.Items.AddRange(new object[] {
            "=",
            "Containing",
            "Start With",
            "End With",
            "<>",
            ">=",
            "<=",
            "<",
            ">"});
            this.cboCriteria.Location = new System.Drawing.Point(72, 28);
            this.cboCriteria.Name = "cboCriteria";
            this.cboCriteria.Size = new System.Drawing.Size(78, 20);
            this.cboCriteria.TabIndex = 17;
            // 
            // SelColumn
            // 
            this.SelColumn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelColumn.Location = new System.Drawing.Point(73, 3);
            this.SelColumn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SelColumn.Name = "SelColumn";
            this.SelColumn.Size = new System.Drawing.Size(39, 22);
            this.SelColumn.TabIndex = 6;
            this.SelColumn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkIgnore
            // 
            this.chkIgnore.AutoSize = true;
            this.chkIgnore.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIgnore.ForeColor = System.Drawing.Color.DarkRed;
            this.chkIgnore.Location = new System.Drawing.Point(117, 7);
            this.chkIgnore.Name = "chkIgnore";
            this.chkIgnore.Size = new System.Drawing.Size(103, 17);
            this.chkIgnore.TabIndex = 16;
            this.chkIgnore.Text = "Ignore Column";
            this.chkIgnore.UseVisualStyleBackColor = true;
            // 
            // cmdFilter
            // 
            this.cmdFilter.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFilter.Location = new System.Drawing.Point(152, 52);
            this.cmdFilter.Name = "cmdFilter";
            this.cmdFilter.Size = new System.Drawing.Size(61, 27);
            this.cmdFilter.TabIndex = 11;
            this.cmdFilter.Text = "F&ilter";
            this.cmdFilter.UseVisualStyleBackColor = true;
            this.cmdFilter.Click += new System.EventHandler(this.cmdFilter_Click);
            // 
            // cmdFind
            // 
            this.cmdFind.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFind.Location = new System.Drawing.Point(214, 52);
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.Size = new System.Drawing.Size(54, 27);
            this.cmdFind.TabIndex = 15;
            this.cmdFind.Text = "&Find";
            this.cmdFind.UseVisualStyleBackColor = true;
            this.cmdFind.Click += new System.EventHandler(this.cmdFind_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(223, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "List Count";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Visible = false;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRefresh.Location = new System.Drawing.Point(270, 52);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(54, 27);
            this.cmdRefresh.TabIndex = 14;
            this.cmdRefresh.Text = "&Refresh";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.Red;
            this.lblCount.Location = new System.Drawing.Point(283, 9);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(13, 13);
            this.lblCount.TabIndex = 13;
            this.lblCount.Text = "0";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCount.Visible = false;
            // 
            // ContextExport
            // 
            this.ContextExport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExportToExcel,
            this.ToolStripMenuItem1,
            this.mnuCopyToClipboard});
            this.ContextExport.Name = "ContextMenuStrip1";
            this.ContextExport.Size = new System.Drawing.Size(172, 54);
            // 
            // mnuExportToExcel
            // 
            this.mnuExportToExcel.Name = "mnuExportToExcel";
            this.mnuExportToExcel.Size = new System.Drawing.Size(171, 22);
            this.mnuExportToExcel.Text = "Export to Excel";
            this.mnuExportToExcel.Click += new System.EventHandler(this.mnuExportToExcel_Click);
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(168, 6);
            // 
            // mnuCopyToClipboard
            // 
            this.mnuCopyToClipboard.Name = "mnuCopyToClipboard";
            this.mnuCopyToClipboard.Size = new System.Drawing.Size(171, 22);
            this.mnuCopyToClipboard.Text = "Copy to Clipboard";
            this.mnuCopyToClipboard.Click += new System.EventHandler(this.mnuCopyToClipboard_Click);
            // 
            // FrmReportBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(1108, 589);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmReportBuilder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Builder";
            this.Load += new System.EventHandler(this.FrmReportBuilder_Load);
            this.grpSqlServers.ResumeLayout(false);
            this.grpSqlServers.PerformLayout();
            this.GrpAuthenticate.ResumeLayout(false);
            this.GrpAuthenticate.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grpDataManipulate.ResumeLayout(false);
            this.grpDataManipulate.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userDataGridView)).EndInit();
            this.PanQuery.ResumeLayout(false);
            this.PanQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelColumn)).EndInit();
            this.ContextExport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTotRecords;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.ProgressBar prgProgress;
        private System.Windows.Forms.ComboBox cmbTables;
        private System.Windows.Forms.Button btnGetAllTables;
        private System.Windows.Forms.Button btnNoOfPages;
        private System.Windows.Forms.Label lblNoOfPages;
        private System.Windows.Forms.ComboBox cmbNoOfRecords;
        private System.Windows.Forms.ComboBox cmbAllDataBases;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnGetAllDataBases;
        private System.Windows.Forms.Label lblPageNums;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnLoadSqlServers;
        private System.Windows.Forms.ComboBox cmbSqlServers;
        private System.Windows.Forms.GroupBox grpSqlServers;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        internal System.Windows.Forms.GroupBox GrpAuthenticate;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.TextBox txtUserName;
        internal System.Windows.Forms.CheckBox chkWinAuthen;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel grpDataManipulate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView userDataGridView;
        private System.Windows.Forms.Button btnRefresh;
        internal System.Windows.Forms.Panel PanQuery;
        internal System.Windows.Forms.Label UsernameLabel;
        internal System.Windows.Forms.Label lblFilter;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox tFilter;
        internal System.Windows.Forms.ComboBox cboCriteria;
        internal System.Windows.Forms.NumericUpDown SelColumn;
        internal System.Windows.Forms.CheckBox chkIgnore;
        internal System.Windows.Forms.Button cmdFilter;
        internal System.Windows.Forms.Button cmdFind;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Button cmdRefresh;
        internal System.Windows.Forms.Label lblCount;
        internal System.Windows.Forms.ContextMenuStrip ContextExport;
        internal System.Windows.Forms.ToolStripMenuItem mnuExportToExcel;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem mnuCopyToClipboard;
    }
}