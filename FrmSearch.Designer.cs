namespace Edge
{
    partial class FrmSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSearch));
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DbGrid = new System.Windows.Forms.DataGridView();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.cboCriteria = new System.Windows.Forms.ComboBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.tFilter = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.lblCount = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.MandateNo = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tBName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankAcctNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DbGrid)).BeginInit();
            this.Panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 3;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Controls.Add(this.DbGrid, 0, 2);
            this.TableLayoutPanel1.Controls.Add(this.Panel1, 1, 1);
            this.TableLayoutPanel1.Controls.Add(this.Panel2, 0, 1);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 3;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(1093, 530);
            this.TableLayoutPanel1.TabIndex = 9;
            // 
            // DbGrid
            // 
            this.DbGrid.AllowUserToAddRows = false;
            this.DbGrid.AllowUserToDeleteRows = false;
            this.DbGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.GhostWhite;
            this.DbGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DbGrid.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.DbGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DbGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DbGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.DbGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DbGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MandateNo,
            this.dIndex,
            this.tDate,
            this.tBName,
            this.Amount,
            this.Bank,
            this.BankAcctNo,
            this.PayType,
            this.PayDetails,
            this.Source,
            this.MainAction});
            this.TableLayoutPanel1.SetColumnSpan(this.DbGrid, 3);
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.PaleGoldenrod;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DbGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.DbGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DbGrid.Location = new System.Drawing.Point(3, 61);
            this.DbGrid.Name = "DbGrid";
            this.DbGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DbGrid.RowHeadersWidth = 10;
            this.DbGrid.Size = new System.Drawing.Size(1087, 466);
            this.DbGrid.TabIndex = 1;
            this.DbGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DbGrid_CellContentClick);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.Tan;
            this.Panel1.Controls.Add(this.cboCriteria);
            this.Panel1.Controls.Add(this.cmdSearch);
            this.Panel1.Controls.Add(this.tFilter);
            this.Panel1.Controls.Add(this.lblFilter);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Panel1.Location = new System.Drawing.Point(316, 25);
            this.Panel1.Margin = new System.Windows.Forms.Padding(3, 25, 3, 3);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(461, 30);
            this.Panel1.TabIndex = 54;
            // 
            // cboCriteria
            // 
            this.cboCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriteria.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCriteria.FormattingEnabled = true;
            this.cboCriteria.Items.AddRange(new object[] {
            "BENEFICIARY NAME",
            "AMOUNT",
            "PAYMENT DETAILS",
            "PAY TYPE",
            "BANK",
            "CURRENCY"});
            this.cboCriteria.Location = new System.Drawing.Point(5, 5);
            this.cboCriteria.Name = "cboCriteria";
            this.cboCriteria.Size = new System.Drawing.Size(139, 21);
            this.cboCriteria.TabIndex = 21;
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(381, 2);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(74, 26);
            this.cmdSearch.TabIndex = 20;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // tFilter
            // 
            this.tFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tFilter.Location = new System.Drawing.Point(147, 3);
            this.tFilter.Name = "tFilter";
            this.tFilter.Size = new System.Drawing.Size(232, 23);
            this.tFilter.TabIndex = 0;
            this.tFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tFilter_KeyPress);
            // 
            // lblFilter
            // 
            this.lblFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(114, -47);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(66, 15);
            this.lblFilter.TabIndex = 18;
            this.lblFilter.Text = "Containing";
            this.lblFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.lblCount);
            this.Panel2.Controls.Add(this.Label4);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel2.Location = new System.Drawing.Point(3, 28);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(307, 27);
            this.Panel2.TabIndex = 55;
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(64, 2);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(114, 23);
            this.lblCount.TabIndex = 573;
            this.lblCount.Text = "0";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(1, 6);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(65, 15);
            this.Label4.TabIndex = 572;
            this.Label4.Text = "List Found:";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MandateNo
            // 
            this.MandateNo.DataPropertyName = "MandateNo";
            this.MandateNo.HeaderText = "MandateNo";
            this.MandateNo.Name = "MandateNo";
            this.MandateNo.Width = 130;
            // 
            // dIndex
            // 
            this.dIndex.DataPropertyName = "dIndex";
            this.dIndex.HeaderText = "dIndex";
            this.dIndex.Name = "dIndex";
            this.dIndex.Width = 5;
            // 
            // tDate
            // 
            this.tDate.DataPropertyName = "PayValueDate";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.tDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.tDate.HeaderText = "Date";
            this.tDate.Name = "tDate";
            this.tDate.Width = 80;
            // 
            // tBName
            // 
            this.tBName.DataPropertyName = "Name";
            this.tBName.HeaderText = "Beneficiary Name";
            this.tBName.Name = "tBName";
            this.tBName.Width = 220;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.Amount.DefaultCellStyle = dataGridViewCellStyle3;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.Width = 80;
            // 
            // Bank
            // 
            this.Bank.DataPropertyName = "BankName";
            this.Bank.HeaderText = "Bank";
            this.Bank.Name = "Bank";
            this.Bank.Width = 160;
            // 
            // BankAcctNo
            // 
            this.BankAcctNo.DataPropertyName = "BankAcctNo";
            this.BankAcctNo.HeaderText = "Account No";
            this.BankAcctNo.Name = "BankAcctNo";
            // 
            // PayType
            // 
            this.PayType.DataPropertyName = "PayType";
            this.PayType.HeaderText = "Pay Type";
            this.PayType.Name = "PayType";
            this.PayType.Width = 110;
            // 
            // PayDetails
            // 
            this.PayDetails.DataPropertyName = "PayDetails";
            this.PayDetails.HeaderText = "Payment Details";
            this.PayDetails.Name = "PayDetails";
            this.PayDetails.Width = 120;
            // 
            // Source
            // 
            this.Source.DataPropertyName = "Source";
            this.Source.HeaderText = "Source";
            this.Source.Name = "Source";
            // 
            // MainAction
            // 
            this.MainAction.DataPropertyName = "MainAction";
            this.MainAction.HeaderText = "Main Action";
            this.MainAction.Name = "MainAction";
            // 
            // FrmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(1093, 530);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.Load += new System.EventHandler(this.FrmSearch_Load);
            this.TableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DbGrid)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.DataGridView DbGrid;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.ComboBox cboCriteria;
        internal System.Windows.Forms.Button cmdSearch;
        internal System.Windows.Forms.TextBox tFilter;
        internal System.Windows.Forms.Label lblFilter;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label lblCount;
        internal System.Windows.Forms.Label Label4;
        private System.Windows.Forms.DataGridViewLinkColumn MandateNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn tDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn tBName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bank;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankAcctNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayType;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source;
        private System.Windows.Forms.DataGridViewTextBoxColumn MainAction;
    }
}