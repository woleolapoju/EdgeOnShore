namespace Edge
{
    partial class FrmSchoolListings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSchoolListings));
            this.SplitContainer2 = new System.Windows.Forms.SplitContainer();
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Label4 = new System.Windows.Forms.Label();
            this.cboCriteria = new System.Windows.Forms.ComboBox();
            this.cmdFind = new System.Windows.Forms.Button();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.lblFilter = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.tFilter = new System.Windows.Forms.TextBox();
            this.chkIgnore = new System.Windows.Forms.CheckBox();
            this.SelColumn = new System.Windows.Forms.NumericUpDown();
            this.cmdPrintLIst = new System.Windows.Forms.Button();
            this.cmdFilter = new System.Windows.Forms.Button();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.TV = new System.Windows.Forms.TreeView();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Label2 = new System.Windows.Forms.Label();
            this.CmbCriteria = new System.Windows.Forms.ComboBox();
            this.dGrid = new System.Windows.Forms.DataGridView();
            this.CMTask = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBrowse = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuHideColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShowAllColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnueDocuments = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).BeginInit();
            this.SplitContainer2.Panel1.SuspendLayout();
            this.SplitContainer2.Panel2.SuspendLayout();
            this.SplitContainer2.SuspendLayout();
            this.TableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelColumn)).BeginInit();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGrid)).BeginInit();
            this.CMTask.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitContainer2
            // 
            this.SplitContainer2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer2.Name = "SplitContainer2";
            // 
            // SplitContainer2.Panel1
            // 
            this.SplitContainer2.Panel1.Controls.Add(this.TableLayoutPanel2);
            // 
            // SplitContainer2.Panel2
            // 
            this.SplitContainer2.Panel2.AutoScroll = true;
            this.SplitContainer2.Panel2.Controls.Add(this.dGrid);
            this.SplitContainer2.Size = new System.Drawing.Size(1200, 661);
            this.SplitContainer2.SplitterDistance = 328;
            this.SplitContainer2.SplitterWidth = 2;
            this.SplitContainer2.TabIndex = 1;
            // 
            // TableLayoutPanel2
            // 
            this.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.TableLayoutPanel2.ColumnCount = 1;
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel2.Controls.Add(this.panel1, 0, 3);
            this.TableLayoutPanel2.Controls.Add(this.Label3, 0, 2);
            this.TableLayoutPanel2.Controls.Add(this.TV, 0, 1);
            this.TableLayoutPanel2.Controls.Add(this.Panel2, 0, 0);
            this.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 4;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel2.Size = new System.Drawing.Size(324, 657);
            this.TableLayoutPanel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Label4);
            this.panel1.Controls.Add(this.cboCriteria);
            this.panel1.Controls.Add(this.cmdFind);
            this.panel1.Controls.Add(this.UsernameLabel);
            this.panel1.Controls.Add(this.lblFilter);
            this.panel1.Controls.Add(this.lblCount);
            this.panel1.Controls.Add(this.tFilter);
            this.panel1.Controls.Add(this.chkIgnore);
            this.panel1.Controls.Add(this.SelColumn);
            this.panel1.Controls.Add(this.cmdPrintLIst);
            this.panel1.Controls.Add(this.cmdFilter);
            this.panel1.Controls.Add(this.cmdRefresh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 528);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 125);
            this.panel1.TabIndex = 2;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Label4.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.Label4.ForeColor = System.Drawing.Color.Red;
            this.Label4.Location = new System.Drawing.Point(0, 113);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(200, 12);
            this.Label4.TabIndex = 203;
            this.Label4.Text = "Hide Column(s) you DO NOT want to PRINT";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboCriteria
            // 
            this.cboCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriteria.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCriteria.FormattingEnabled = true;
            this.cboCriteria.Items.AddRange(new object[] {
            "=",
            "Containing",
            "Start With",
            "End With",
            "<>"});
            this.cboCriteria.Location = new System.Drawing.Point(67, 29);
            this.cboCriteria.Name = "cboCriteria";
            this.cboCriteria.Size = new System.Drawing.Size(76, 21);
            this.cboCriteria.TabIndex = 17;
            // 
            // cmdFind
            // 
            this.cmdFind.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFind.Location = new System.Drawing.Point(116, 59);
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.Size = new System.Drawing.Size(64, 27);
            this.cmdFind.TabIndex = 18;
            this.cmdFind.Text = "&Find";
            this.cmdFind.UseVisualStyleBackColor = true;
            this.cmdFind.Click += new System.EventHandler(this.cmdFind_Click);
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(3, 7);
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
            this.lblFilter.Location = new System.Drawing.Point(5, 33);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(58, 13);
            this.lblFilter.TabIndex = 4;
            this.lblFilter.Text = "&Filter Text:";
            this.lblFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.Brown;
            this.lblCount.Location = new System.Drawing.Point(2, 92);
            this.lblCount.Name = "lblCount";
            this.lblCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCount.Size = new System.Drawing.Size(82, 13);
            this.lblCount.TabIndex = 201;
            this.lblCount.Text = "List count : 0";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tFilter
            // 
            this.tFilter.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tFilter.Location = new System.Drawing.Point(146, 29);
            this.tFilter.Name = "tFilter";
            this.tFilter.Size = new System.Drawing.Size(163, 22);
            this.tFilter.TabIndex = 274;
            this.tFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tFilter_KeyDown);
            // 
            // chkIgnore
            // 
            this.chkIgnore.AutoSize = true;
            this.chkIgnore.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIgnore.ForeColor = System.Drawing.Color.DarkRed;
            this.chkIgnore.Location = new System.Drawing.Point(146, 7);
            this.chkIgnore.Name = "chkIgnore";
            this.chkIgnore.Size = new System.Drawing.Size(103, 17);
            this.chkIgnore.TabIndex = 16;
            this.chkIgnore.Text = "Ignore Column";
            this.chkIgnore.UseVisualStyleBackColor = true;
            // 
            // SelColumn
            // 
            this.SelColumn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelColumn.Location = new System.Drawing.Point(67, 4);
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
            // cmdPrintLIst
            // 
            this.cmdPrintLIst.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPrintLIst.Location = new System.Drawing.Point(246, 59);
            this.cmdPrintLIst.Name = "cmdPrintLIst";
            this.cmdPrintLIst.Size = new System.Drawing.Size(64, 27);
            this.cmdPrintLIst.TabIndex = 15;
            this.cmdPrintLIst.Text = "&Print List";
            this.cmdPrintLIst.UseVisualStyleBackColor = true;
            this.cmdPrintLIst.Click += new System.EventHandler(this.cmdPrintLIst_Click);
            // 
            // cmdFilter
            // 
            this.cmdFilter.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFilter.Location = new System.Drawing.Point(51, 58);
            this.cmdFilter.Name = "cmdFilter";
            this.cmdFilter.Size = new System.Drawing.Size(64, 27);
            this.cmdFilter.TabIndex = 11;
            this.cmdFilter.Text = "F&ilter";
            this.cmdFilter.UseVisualStyleBackColor = true;
            this.cmdFilter.Click += new System.EventHandler(this.cmdFilter_Click);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRefresh.Location = new System.Drawing.Point(180, 59);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(64, 27);
            this.cmdRefresh.TabIndex = 14;
            this.cmdRefresh.Text = "&Refresh";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.BurlyWood;
            this.Label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(1, 503);
            this.Label3.Margin = new System.Windows.Forms.Padding(0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(322, 21);
            this.Label3.TabIndex = 202;
            this.Label3.Text = "FILTER/SEARCH";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TV
            // 
            this.TV.BackColor = System.Drawing.Color.AntiqueWhite;
            this.TV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TV.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TV.Location = new System.Drawing.Point(2, 36);
            this.TV.Margin = new System.Windows.Forms.Padding(1);
            this.TV.Name = "TV";
            this.TV.Size = new System.Drawing.Size(320, 465);
            this.TV.TabIndex = 2;
            this.TV.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TV_AfterSelect);
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.BurlyWood;
            this.Panel2.Controls.Add(this.Label2);
            this.Panel2.Controls.Add(this.CmbCriteria);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel2.Location = new System.Drawing.Point(2, 2);
            this.Panel2.Margin = new System.Windows.Forms.Padding(1);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(320, 31);
            this.Panel2.TabIndex = 203;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(1, 5);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(65, 17);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Group By:";
            // 
            // CmbCriteria
            // 
            this.CmbCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCriteria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbCriteria.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCriteria.FormattingEnabled = true;
            this.CmbCriteria.Items.AddRange(new object[] {
            "Bank",
            "Category",
            "Region",
            "State"});
            this.CmbCriteria.Location = new System.Drawing.Point(72, 2);
            this.CmbCriteria.Name = "CmbCriteria";
            this.CmbCriteria.Size = new System.Drawing.Size(221, 25);
            this.CmbCriteria.Sorted = true;
            this.CmbCriteria.TabIndex = 2;
            this.CmbCriteria.SelectedIndexChanged += new System.EventHandler(this.CmbCriteria_SelectedIndexChanged);
            // 
            // dGrid
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.dGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dGrid.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.dGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGrid.ContextMenuStrip = this.CMTask;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.dGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGrid.Location = new System.Drawing.Point(0, 0);
            this.dGrid.Name = "dGrid";
            this.dGrid.Size = new System.Drawing.Size(866, 657);
            this.dGrid.TabIndex = 7;
            this.dGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGrid_CellClick);
            this.dGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGrid_CellContentClick);
            this.dGrid.DoubleClick += new System.EventHandler(this.dGrid_DoubleClick);
            // 
            // CMTask
            // 
            this.CMTask.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.mnuEdit,
            this.mnuDelete,
            this.mnuBrowse,
            this.ToolStripMenuItem1,
            this.mnuHideColumn,
            this.mnuShowAllColumn,
            this.ToolStripMenuItem2,
            this.mnueDocuments});
            this.CMTask.Name = "CMTask";
            this.CMTask.Size = new System.Drawing.Size(167, 192);
            // 
            // mnuNew
            // 
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.Size = new System.Drawing.Size(166, 22);
            this.mnuNew.Text = "New Record";
            this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(166, 22);
            this.mnuEdit.Text = "Edit Record";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEditStaff_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(166, 22);
            this.mnuDelete.Text = "Delete Record";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // mnuBrowse
            // 
            this.mnuBrowse.Name = "mnuBrowse";
            this.mnuBrowse.Size = new System.Drawing.Size(166, 22);
            this.mnuBrowse.Text = "Browse Record";
            this.mnuBrowse.Click += new System.EventHandler(this.mnuBrowse_Click);
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(163, 6);
            // 
            // mnuHideColumn
            // 
            this.mnuHideColumn.Name = "mnuHideColumn";
            this.mnuHideColumn.Size = new System.Drawing.Size(166, 22);
            this.mnuHideColumn.Text = "Hide Column";
            this.mnuHideColumn.Click += new System.EventHandler(this.mnuHideColumn_Click);
            // 
            // mnuShowAllColumn
            // 
            this.mnuShowAllColumn.Name = "mnuShowAllColumn";
            this.mnuShowAllColumn.Size = new System.Drawing.Size(166, 22);
            this.mnuShowAllColumn.Text = "Show All Column";
            this.mnuShowAllColumn.Click += new System.EventHandler(this.mnuShowAllColumn_Click);
            // 
            // ToolStripMenuItem2
            // 
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            this.ToolStripMenuItem2.Size = new System.Drawing.Size(163, 6);
            this.ToolStripMenuItem2.Visible = false;
            // 
            // mnueDocuments
            // 
            this.mnueDocuments.Name = "mnueDocuments";
            this.mnueDocuments.Size = new System.Drawing.Size(166, 22);
            this.mnueDocuments.Text = "eDocuments";
            this.mnueDocuments.Visible = false;
            // 
            // FrmSchoolListings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(1200, 661);
            this.Controls.Add(this.SplitContainer2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSchoolListings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "School Listings";
            this.Load += new System.EventHandler(this.FrmSchoolListings_Load);
            this.Resize += new System.EventHandler(this.FrmSchoolListings_Resize);
            this.SplitContainer2.Panel1.ResumeLayout(false);
            this.SplitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).EndInit();
            this.SplitContainer2.ResumeLayout(false);
            this.TableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelColumn)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGrid)).EndInit();
            this.CMTask.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.SplitContainer SplitContainer2;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Button cmdFind;
        internal System.Windows.Forms.ComboBox cboCriteria;
        internal System.Windows.Forms.Label lblCount;
        internal System.Windows.Forms.CheckBox chkIgnore;
        internal System.Windows.Forms.Button cmdPrintLIst;
        internal System.Windows.Forms.Button cmdRefresh;
        internal System.Windows.Forms.Button cmdFilter;
        internal System.Windows.Forms.NumericUpDown SelColumn;
        internal System.Windows.Forms.TextBox tFilter;
        internal System.Windows.Forms.Label lblFilter;
        internal System.Windows.Forms.Label UsernameLabel;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TreeView TV;
        private System.Windows.Forms.DataGridView dGrid;
        internal System.Windows.Forms.ContextMenuStrip CMTask;
        internal System.Windows.Forms.ToolStripMenuItem mnuNew;
        internal System.Windows.Forms.ToolStripMenuItem mnuEdit;
        internal System.Windows.Forms.ToolStripMenuItem mnuDelete;
        internal System.Windows.Forms.ToolStripMenuItem mnuBrowse;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem mnuHideColumn;
        internal System.Windows.Forms.ToolStripMenuItem mnuShowAllColumn;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem2;
        internal System.Windows.Forms.ToolStripMenuItem mnueDocuments;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox CmbCriteria;
    }
}