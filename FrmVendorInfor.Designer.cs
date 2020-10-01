namespace Edge
{
    partial class FrmVendorInfor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVendorInfor));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
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
            this.txtIDNo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.tTINNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tBank = new System.Windows.Forms.TextBox();
            this.lnkBank = new System.Windows.Forms.LinkLabel();
            this.tAccountNo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tEmailAddress = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tRemark = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tBankAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tBankCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cBank = new System.Windows.Forms.ComboBox();
            this.tPhone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tSchName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tRefNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cboRegion = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.PanFooter.SuspendLayout();
            this.PanAction.SuspendLayout();
            this.mnuAction.SuspendLayout();
            this.PanButton.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.PanFooter, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(615, 414);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // PanFooter
            // 
            this.PanFooter.BackColor = System.Drawing.Color.BurlyWood;
            this.tableLayoutPanel1.SetColumnSpan(this.PanFooter, 2);
            this.PanFooter.Controls.Add(this.PanAction);
            this.PanFooter.Controls.Add(this.PanButton);
            this.PanFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanFooter.Location = new System.Drawing.Point(0, 365);
            this.PanFooter.Margin = new System.Windows.Forms.Padding(0);
            this.PanFooter.Name = "PanFooter";
            this.PanFooter.Size = new System.Drawing.Size(615, 49);
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
            this.PanButton.Location = new System.Drawing.Point(436, 0);
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
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.cboRegion);
            this.panel1.Controls.Add(this.txtIDNo);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cboCategory);
            this.panel1.Controls.Add(this.tTINNo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tBank);
            this.panel1.Controls.Add(this.lnkBank);
            this.panel1.Controls.Add(this.tAccountNo);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.tEmailAddress);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.chkActive);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.tRemark);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.tBankAddress);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.tBankCode);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cBank);
            this.panel1.Controls.Add(this.tPhone);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tAddress);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tSchName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tRefNo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(609, 359);
            this.panel1.TabIndex = 0;
            // 
            // txtIDNo
            // 
            this.txtIDNo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDNo.Location = new System.Drawing.Point(129, 5);
            this.txtIDNo.Name = "txtIDNo";
            this.txtIDNo.Size = new System.Drawing.Size(150, 25);
            this.txtIDNo.TabIndex = 34;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 17);
            this.label13.TabIndex = 33;
            this.label13.Text = "IDNo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(386, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 17);
            this.label6.TabIndex = 32;
            this.label6.Text = "Category:";
            // 
            // cboCategory
            // 
            this.cboCategory.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(457, 143);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(139, 25);
            this.cboCategory.TabIndex = 31;
            // 
            // tTINNo
            // 
            this.tTINNo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tTINNo.Location = new System.Drawing.Point(129, 116);
            this.tTINNo.Name = "tTINNo";
            this.tTINNo.Size = new System.Drawing.Size(150, 25);
            this.tTINNo.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "TIN No:";
            // 
            // tBank
            // 
            this.tBank.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tBank.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBank.Location = new System.Drawing.Point(129, 172);
            this.tBank.Name = "tBank";
            this.tBank.ReadOnly = true;
            this.tBank.Size = new System.Drawing.Size(149, 25);
            this.tBank.TabIndex = 26;
            // 
            // lnkBank
            // 
            this.lnkBank.AutoSize = true;
            this.lnkBank.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lnkBank.Location = new System.Drawing.Point(7, 179);
            this.lnkBank.Name = "lnkBank";
            this.lnkBank.Size = new System.Drawing.Size(38, 17);
            this.lnkBank.TabIndex = 25;
            this.lnkBank.TabStop = true;
            this.lnkBank.Text = "Bank:";
            this.lnkBank.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBank_LinkClicked);
            // 
            // tAccountNo
            // 
            this.tAccountNo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tAccountNo.Location = new System.Drawing.Point(129, 200);
            this.tAccountNo.Name = "tAccountNo";
            this.tAccountNo.Size = new System.Drawing.Size(150, 25);
            this.tAccountNo.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 205);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 17);
            this.label12.TabIndex = 22;
            this.label12.Text = "Account No:";
            // 
            // tEmailAddress
            // 
            this.tEmailAddress.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tEmailAddress.Location = new System.Drawing.Point(129, 144);
            this.tEmailAddress.Name = "tEmailAddress";
            this.tEmailAddress.Size = new System.Drawing.Size(150, 25);
            this.tEmailAddress.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 149);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 17);
            this.label11.TabIndex = 20;
            this.label11.Text = "Email Address:";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.chkActive.Location = new System.Drawing.Point(129, 339);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(15, 14);
            this.chkActive.TabIndex = 19;
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(8, 336);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 17);
            this.label10.TabIndex = 18;
            this.label10.Text = "InActive:";
            // 
            // tRemark
            // 
            this.tRemark.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tRemark.Location = new System.Drawing.Point(129, 283);
            this.tRemark.Multiline = true;
            this.tRemark.Name = "tRemark";
            this.tRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tRemark.Size = new System.Drawing.Size(467, 52);
            this.tRemark.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 287);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "Remark:";
            // 
            // tBankAddress
            // 
            this.tBankAddress.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBankAddress.Location = new System.Drawing.Point(129, 228);
            this.tBankAddress.Multiline = true;
            this.tBankAddress.Name = "tBankAddress";
            this.tBankAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBankAddress.Size = new System.Drawing.Size(466, 52);
            this.tBankAddress.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Bank Address:";
            // 
            // tBankCode
            // 
            this.tBankCode.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tBankCode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBankCode.Location = new System.Drawing.Point(457, 171);
            this.tBankCode.Name = "tBankCode";
            this.tBankCode.Size = new System.Drawing.Size(139, 25);
            this.tBankCode.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(386, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Bank Code:";
            // 
            // cBank
            // 
            this.cBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBank.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cBank.FormattingEnabled = true;
            this.cBank.Location = new System.Drawing.Point(130, 172);
            this.cBank.Name = "cBank";
            this.cBank.Size = new System.Drawing.Size(166, 25);
            this.cBank.TabIndex = 11;
            this.cBank.SelectedIndexChanged += new System.EventHandler(this.cBank_SelectedIndexChanged);
            // 
            // tPhone
            // 
            this.tPhone.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPhone.Location = new System.Drawing.Point(457, 116);
            this.tPhone.Name = "tPhone";
            this.tPhone.Size = new System.Drawing.Size(139, 25);
            this.tPhone.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(386, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Telephone:";
            // 
            // tAddress
            // 
            this.tAddress.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tAddress.Location = new System.Drawing.Point(129, 61);
            this.tAddress.Multiline = true;
            this.tAddress.Name = "tAddress";
            this.tAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tAddress.Size = new System.Drawing.Size(467, 52);
            this.tAddress.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Address:";
            // 
            // tSchName
            // 
            this.tSchName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSchName.Location = new System.Drawing.Point(129, 33);
            this.tSchName.Name = "tSchName";
            this.tSchName.Size = new System.Drawing.Size(466, 25);
            this.tSchName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Vendor/Staff Name:";
            // 
            // tRefNo
            // 
            this.tRefNo.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tRefNo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tRefNo.Location = new System.Drawing.Point(357, 196);
            this.tRefNo.Name = "tRefNo";
            this.tRefNo.ReadOnly = true;
            this.tRefNo.Size = new System.Drawing.Size(12, 25);
            this.tRefNo.TabIndex = 1;
            this.tRefNo.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(299, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "RefNo:";
            this.label1.Visible = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(386, 202);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(52, 17);
            this.label18.TabIndex = 46;
            this.label18.Text = "Region:";
            // 
            // cboRegion
            // 
            this.cboRegion.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cboRegion.FormattingEnabled = true;
            this.cboRegion.Items.AddRange(new object[] {
            "",
            "North Central",
            "North East",
            "Norh West",
            "South East",
            "South South",
            "South West"});
            this.cboRegion.Location = new System.Drawing.Point(456, 199);
            this.cboRegion.Name = "cboRegion";
            this.cboRegion.Size = new System.Drawing.Size(140, 25);
            this.cboRegion.TabIndex = 45;
            // 
            // FrmVendorInfor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(615, 414);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmVendorInfor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vendor/Staff Information";
            this.Load += new System.EventHandler(this.FrmSchoolInfor_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.PanFooter.ResumeLayout(false);
            this.PanAction.ResumeLayout(false);
            this.PanAction.PerformLayout();
            this.mnuAction.ResumeLayout(false);
            this.mnuAction.PerformLayout();
            this.PanButton.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tSchName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tRefNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tRemark;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tBankAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tBankCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cBank;
        private System.Windows.Forms.TextBox tPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tEmailAddress;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tAccountNo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.LinkLabel lnkBank;
        private System.Windows.Forms.TextBox tBank;
        private System.Windows.Forms.TextBox tTINNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.TextBox txtIDNo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cboRegion;
    }
}