namespace Edge
{
    partial class FrmCoyInfor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCoyInfor));
            this.cmdGetFile = new System.Windows.Forms.Button();
            this.Label15 = new System.Windows.Forms.Label();
            this.tDocFile = new System.Windows.Forms.TextBox();
            this.FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cmdGetBakPath = new System.Windows.Forms.Button();
            this.Label8 = new System.Windows.Forms.Label();
            this.tBackupPath = new System.Windows.Forms.TextBox();
            this.PanFooter = new System.Windows.Forms.Panel();
            this.CmdCancel = new System.Windows.Forms.Button();
            this.cmdOk = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.tWebsite = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.temail = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.tPhone = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.tAddress = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.tName = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.OwnerLogo = new System.Windows.Forms.PictureBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.PanFooter.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OwnerLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdGetFile
            // 
            this.cmdGetFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdGetFile.Location = new System.Drawing.Point(297, 175);
            this.cmdGetFile.Name = "cmdGetFile";
            this.cmdGetFile.Size = new System.Drawing.Size(27, 25);
            this.cmdGetFile.TabIndex = 267;
            this.cmdGetFile.Text = "...";
            this.cmdGetFile.UseVisualStyleBackColor = true;
            this.cmdGetFile.Click += new System.EventHandler(this.cmdGetFile_Click);
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label15.Location = new System.Drawing.Point(9, 179);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(64, 15);
            this.Label15.TabIndex = 265;
            this.Label15.Text = "eDoc Path:";
            // 
            // tDocFile
            // 
            this.tDocFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tDocFile.Location = new System.Drawing.Point(97, 176);
            this.tDocFile.Name = "tDocFile";
            this.tDocFile.Size = new System.Drawing.Size(199, 23);
            this.tDocFile.TabIndex = 266;
            // 
            // cmdGetBakPath
            // 
            this.cmdGetBakPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdGetBakPath.Location = new System.Drawing.Point(297, 200);
            this.cmdGetBakPath.Name = "cmdGetBakPath";
            this.cmdGetBakPath.Size = new System.Drawing.Size(27, 25);
            this.cmdGetBakPath.TabIndex = 270;
            this.cmdGetBakPath.Text = "...";
            this.cmdGetBakPath.UseVisualStyleBackColor = true;
            this.cmdGetBakPath.Click += new System.EventHandler(this.cmdGetBakPath_Click_1);
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.Location = new System.Drawing.Point(9, 204);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(76, 15);
            this.Label8.TabIndex = 268;
            this.Label8.Text = "Backup Path:";
            // 
            // tBackupPath
            // 
            this.tBackupPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBackupPath.Location = new System.Drawing.Point(97, 201);
            this.tBackupPath.Name = "tBackupPath";
            this.tBackupPath.Size = new System.Drawing.Size(199, 23);
            this.tBackupPath.TabIndex = 269;
            // 
            // PanFooter
            // 
            this.PanFooter.BackColor = System.Drawing.Color.BurlyWood;
            this.PanFooter.Controls.Add(this.CmdCancel);
            this.PanFooter.Controls.Add(this.cmdOk);
            this.PanFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanFooter.Location = new System.Drawing.Point(0, 236);
            this.PanFooter.Name = "PanFooter";
            this.PanFooter.Size = new System.Drawing.Size(530, 43);
            this.PanFooter.TabIndex = 273;
            // 
            // CmdCancel
            // 
            this.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCancel.Location = new System.Drawing.Point(447, 4);
            this.CmdCancel.Name = "CmdCancel";
            this.CmdCancel.Size = new System.Drawing.Size(80, 36);
            this.CmdCancel.TabIndex = 19;
            this.CmdCancel.Text = "&Close";
            this.CmdCancel.UseVisualStyleBackColor = true;
            this.CmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
            // 
            // cmdOk
            // 
            this.cmdOk.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmdOk.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOk.Location = new System.Drawing.Point(367, 4);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(80, 36);
            this.cmdOk.TabIndex = 20;
            this.cmdOk.Text = "&Ok";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(9, 154);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(56, 15);
            this.Label5.TabIndex = 258;
            this.Label5.Text = "Web Site:";
            // 
            // tWebsite
            // 
            this.tWebsite.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tWebsite.Location = new System.Drawing.Point(97, 151);
            this.tWebsite.Name = "tWebsite";
            this.tWebsite.Size = new System.Drawing.Size(226, 23);
            this.tWebsite.TabIndex = 259;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(9, 129);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(44, 15);
            this.Label4.TabIndex = 256;
            this.Label4.Text = "E-mail:";
            // 
            // temail
            // 
            this.temail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temail.Location = new System.Drawing.Point(97, 126);
            this.temail.Name = "temail";
            this.temail.Size = new System.Drawing.Size(226, 23);
            this.temail.TabIndex = 257;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(9, 104);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(44, 15);
            this.Label2.TabIndex = 254;
            this.Label2.Text = "Phone:";
            // 
            // tPhone
            // 
            this.tPhone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPhone.Location = new System.Drawing.Point(97, 101);
            this.tPhone.Name = "tPhone";
            this.tPhone.Size = new System.Drawing.Size(226, 23);
            this.tPhone.TabIndex = 255;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(9, 56);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(52, 15);
            this.Label1.TabIndex = 252;
            this.Label1.Text = "Address:";
            // 
            // tAddress
            // 
            this.tAddress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tAddress.Location = new System.Drawing.Point(97, 52);
            this.tAddress.Multiline = true;
            this.tAddress.Name = "tAddress";
            this.tAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tAddress.Size = new System.Drawing.Size(226, 47);
            this.tAddress.TabIndex = 253;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(9, 13);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(42, 15);
            this.Label3.TabIndex = 250;
            this.Label3.Text = "Name:";
            // 
            // tName
            // 
            this.tName.AcceptsReturn = true;
            this.tName.Enabled = false;
            this.tName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tName.Location = new System.Drawing.Point(97, 10);
            this.tName.Multiline = true;
            this.tName.Name = "tName";
            this.tName.Size = new System.Drawing.Size(226, 40);
            this.tName.TabIndex = 251;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(330, 7);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(34, 15);
            this.Label6.TabIndex = 260;
            this.Label6.Text = "Logo";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.OwnerLogo);
            this.GroupBox1.Controls.Add(this.Label14);
            this.GroupBox1.Controls.Add(this.Label13);
            this.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GroupBox1.Location = new System.Drawing.Point(372, 4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(147, 147);
            this.GroupBox1.TabIndex = 261;
            this.GroupBox1.TabStop = false;
            // 
            // OwnerLogo
            // 
            this.OwnerLogo.AccessibleDescription = "";
            this.OwnerLogo.Location = new System.Drawing.Point(2, 9);
            this.OwnerLogo.Name = "OwnerLogo";
            this.OwnerLogo.Size = new System.Drawing.Size(143, 134);
            this.OwnerLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OwnerLogo.TabIndex = 17;
            this.OwnerLogo.TabStop = false;
            this.OwnerLogo.Click += new System.EventHandler(this.OwnerLogo_Click);
            this.OwnerLogo.DoubleClick += new System.EventHandler(this.OwnerLogo_DoubleClick);
            // 
            // Label14
            // 
            this.Label14.Location = new System.Drawing.Point(-86, 177);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(79, 30);
            this.Label14.TabIndex = 129;
            this.Label14.Text = "Header Pictures";
            // 
            // Label13
            // 
            this.Label13.Location = new System.Drawing.Point(-85, 125);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(79, 39);
            this.Label13.TabIndex = 127;
            this.Label13.Text = "Selectable Body Pictures";
            // 
            // FrmCoyInfor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(530, 279);
            this.Controls.Add(this.cmdGetFile);
            this.Controls.Add(this.Label15);
            this.Controls.Add(this.tDocFile);
            this.Controls.Add(this.cmdGetBakPath);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.tBackupPath);
            this.Controls.Add(this.PanFooter);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.tWebsite);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.temail);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.tPhone);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.tAddress);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.tName);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCoyInfor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Organisation Information";
            this.Load += new System.EventHandler(this.FrmCoyInfor_Load);
            this.PanFooter.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OwnerLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button cmdGetFile;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.TextBox tDocFile;
        internal System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog1;
        internal System.Windows.Forms.Button cmdGetBakPath;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.TextBox tBackupPath;
        internal System.Windows.Forms.Panel PanFooter;
        internal System.Windows.Forms.Button CmdCancel;
        internal System.Windows.Forms.Button cmdOk;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox tWebsite;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox temail;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox tPhone;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox tAddress;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox tName;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.PictureBox OwnerLogo;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label Label13;
    }
}