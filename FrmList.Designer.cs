namespace Edge
{
    partial class FrmList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmList));
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.lblFilter = new System.Windows.Forms.Label();
            this.PanQuery = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.tFilter = new System.Windows.Forms.TextBox();
            this.cboCriteria = new System.Windows.Forms.ComboBox();
            this.SelColumn = new System.Windows.Forms.NumericUpDown();
            this.chkIgnore = new System.Windows.Forms.CheckBox();
            this.cmdFilter = new System.Windows.Forms.Button();
            this.cmdFind = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.cmdOk = new System.Windows.Forms.Button();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DGrid = new System.Windows.Forms.DataGridView();
            this.ContextExport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCopyToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.PanFooter = new System.Windows.Forms.Panel();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.cmdClose = new System.Windows.Forms.Button();
            this.PanQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelColumn)).BeginInit();
            this.TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).BeginInit();
            this.ContextExport.SuspendLayout();
            this.PanFooter.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.lblFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.Location = new System.Drawing.Point(6, 34);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(58, 13);
            this.lblFilter.TabIndex = 4;
            this.lblFilter.Text = "&Filter Text:";
            this.lblFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PanQuery
            // 
            this.PanQuery.Controls.Add(this.UsernameLabel);
            this.PanQuery.Controls.Add(this.lblFilter);
            this.PanQuery.Controls.Add(this.Label1);
            this.PanQuery.Controls.Add(this.tFilter);
            this.PanQuery.Controls.Add(this.cboCriteria);
            this.PanQuery.Controls.Add(this.SelColumn);
            this.PanQuery.Controls.Add(this.chkIgnore);
            this.PanQuery.Controls.Add(this.cmdFilter);
            this.PanQuery.Controls.Add(this.cmdFind);
            this.PanQuery.Controls.Add(this.Label3);
            this.PanQuery.Controls.Add(this.cmdRefresh);
            this.PanQuery.Controls.Add(this.lblCount);
            this.PanQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanQuery.Location = new System.Drawing.Point(0, 0);
            this.PanQuery.Name = "PanQuery";
            this.PanQuery.Size = new System.Drawing.Size(743, 57);
            this.PanQuery.TabIndex = 4;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Red;
            this.Label1.Location = new System.Drawing.Point(407, 7);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(128, 13);
            this.Label1.TabIndex = 18;
            this.Label1.Text = "Right click list to export";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tFilter
            // 
            this.tFilter.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tFilter.Location = new System.Drawing.Point(152, 28);
            this.tFilter.Name = "tFilter";
            this.tFilter.Size = new System.Drawing.Size(211, 22);
            this.tFilter.TabIndex = 5;
            this.tFilter.TextChanged += new System.EventHandler(this.tFilter_TextChanged);
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
            this.cmdFilter.Location = new System.Drawing.Point(365, 25);
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
            this.cmdFind.Location = new System.Drawing.Point(427, 25);
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.Size = new System.Drawing.Size(54, 27);
            this.cmdFind.TabIndex = 15;
            this.cmdFind.Text = "&Find";
            this.cmdFind.UseVisualStyleBackColor = true;
            this.cmdFind.Click += new System.EventHandler(this.cmdFind_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(228, 9);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(59, 13);
            this.Label3.TabIndex = 12;
            this.Label3.Text = "List Count";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label3.Visible = false;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRefresh.Location = new System.Drawing.Point(483, 25);
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
            this.lblCount.Location = new System.Drawing.Point(289, 9);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(13, 13);
            this.lblCount.TabIndex = 13;
            this.lblCount.Text = "0";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCount.Visible = false;
            // 
            // cmdOk
            // 
            this.cmdOk.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmdOk.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOk.Location = new System.Drawing.Point(1, 6);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(79, 45);
            this.cmdOk.TabIndex = 18;
            this.cmdOk.Text = "&Ok";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.TableLayoutPanel1.ColumnCount = 1;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.Controls.Add(this.DGrid, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.PanFooter, 0, 1);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 2;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(743, 581);
            this.TableLayoutPanel1.TabIndex = 2;
            // 
            // DGrid
            // 
            this.DGrid.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.DGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGrid.ContextMenuStrip = this.ContextExport;
            this.DGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGrid.Location = new System.Drawing.Point(3, 3);
            this.DGrid.Name = "DGrid";
            this.DGrid.Size = new System.Drawing.Size(737, 518);
            this.DGrid.TabIndex = 0;
            this.DGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGrid_CellClick);
            this.DGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGrid_CellContentClick);
            this.DGrid.DoubleClick += new System.EventHandler(this.DGrid_DoubleClick);
            // 
            // ContextExport
            // 
            this.ContextExport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExportToExcel,
            this.ToolStripMenuItem1,
            this.mnuCopyToClipboard});
            this.ContextExport.Name = "ContextMenuStrip1";
            this.ContextExport.Size = new System.Drawing.Size(172, 76);
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
            // PanFooter
            // 
            this.PanFooter.BackColor = System.Drawing.Color.BurlyWood;
            this.PanFooter.Controls.Add(this.Panel1);
            this.PanFooter.Controls.Add(this.PanQuery);
            this.PanFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanFooter.Location = new System.Drawing.Point(0, 524);
            this.PanFooter.Margin = new System.Windows.Forms.Padding(0);
            this.PanFooter.Name = "PanFooter";
            this.PanFooter.Size = new System.Drawing.Size(743, 57);
            this.PanFooter.TabIndex = 5;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.cmdClose);
            this.Panel1.Controls.Add(this.cmdOk);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel1.Location = new System.Drawing.Point(601, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(142, 57);
            this.Panel1.TabIndex = 3;
            // 
            // cmdClose
            // 
            this.cmdClose.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Location = new System.Drawing.Point(81, 6);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(57, 45);
            this.cmdClose.TabIndex = 19;
            this.cmdClose.Text = "&Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            // 
            // FrmList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(743, 581);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listings";
            this.Load += new System.EventHandler(this.FrmList_Load);
            this.PanQuery.ResumeLayout(false);
            this.PanQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelColumn)).EndInit();
            this.TableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).EndInit();
            this.ContextExport.ResumeLayout(false);
            this.PanFooter.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Label UsernameLabel;
        internal System.Windows.Forms.Label lblFilter;
        internal System.Windows.Forms.Panel PanQuery;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox tFilter;
        internal System.Windows.Forms.ComboBox cboCriteria;
        internal System.Windows.Forms.NumericUpDown SelColumn;
        internal System.Windows.Forms.CheckBox chkIgnore;
        internal System.Windows.Forms.Button cmdFilter;
        internal System.Windows.Forms.Button cmdFind;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button cmdRefresh;
        internal System.Windows.Forms.Label lblCount;
        internal System.Windows.Forms.Button cmdOk;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.DataGridView DGrid;
        internal System.Windows.Forms.ContextMenuStrip ContextExport;
        internal System.Windows.Forms.ToolStripMenuItem mnuExportToExcel;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem mnuCopyToClipboard;
        internal System.Windows.Forms.Panel PanFooter;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Button cmdClose;
    }
}