namespace Edge
{
    partial class FrmChangePwd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChangePwd));
            this.Label5 = new System.Windows.Forms.Label();
            this.tConfirm = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.tPassword = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.tUsername = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.tUserID = new System.Windows.Forms.TextBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.PanFooter = new System.Windows.Forms.Panel();
            this.cmdOk = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.tCurrentPwd = new System.Windows.Forms.TextBox();
            this.PanFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(5, 110);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(80, 15);
            this.Label5.TabIndex = 58;
            this.Label5.Text = "Confirm Pwd:";
            // 
            // tConfirm
            // 
            this.tConfirm.AcceptsReturn = true;
            this.tConfirm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tConfirm.Location = new System.Drawing.Point(94, 107);
            this.tConfirm.Name = "tConfirm";
            this.tConfirm.PasswordChar = '*';
            this.tConfirm.Size = new System.Drawing.Size(94, 23);
            this.tConfirm.TabIndex = 3;
            this.tConfirm.UseSystemPasswordChar = true;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(5, 84);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(60, 15);
            this.Label4.TabIndex = 57;
            this.Label4.Text = "New Pwd:";
            // 
            // tPassword
            // 
            this.tPassword.AcceptsReturn = true;
            this.tPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPassword.Location = new System.Drawing.Point(94, 81);
            this.tPassword.Name = "tPassword";
            this.tPassword.PasswordChar = '*';
            this.tPassword.Size = new System.Drawing.Size(94, 23);
            this.tPassword.TabIndex = 2;
            this.tPassword.UseSystemPasswordChar = true;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(5, 32);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(63, 15);
            this.Label2.TabIndex = 56;
            this.Label2.Text = "Username:";
            // 
            // tUsername
            // 
            this.tUsername.AcceptsReturn = true;
            this.tUsername.BackColor = System.Drawing.Color.FloralWhite;
            this.tUsername.Enabled = false;
            this.tUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tUsername.Location = new System.Drawing.Point(94, 29);
            this.tUsername.Name = "tUsername";
            this.tUsername.ReadOnly = true;
            this.tUsername.Size = new System.Drawing.Size(192, 23);
            this.tUsername.TabIndex = 54;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(5, 6);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(47, 15);
            this.Label3.TabIndex = 55;
            this.Label3.Text = "User ID:";
            // 
            // tUserID
            // 
            this.tUserID.AcceptsReturn = true;
            this.tUserID.BackColor = System.Drawing.Color.FloralWhite;
            this.tUserID.Enabled = false;
            this.tUserID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tUserID.Location = new System.Drawing.Point(94, 3);
            this.tUserID.Name = "tUserID";
            this.tUserID.ReadOnly = true;
            this.tUserID.Size = new System.Drawing.Size(94, 23);
            this.tUserID.TabIndex = 53;
            // 
            // cmdClose
            // 
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Location = new System.Drawing.Point(226, 3);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(64, 34);
            this.cmdClose.TabIndex = 46;
            this.cmdClose.Text = "&Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // PanFooter
            // 
            this.PanFooter.BackColor = System.Drawing.Color.BurlyWood;
            this.PanFooter.Controls.Add(this.cmdOk);
            this.PanFooter.Controls.Add(this.cmdClose);
            this.PanFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanFooter.Location = new System.Drawing.Point(0, 139);
            this.PanFooter.Name = "PanFooter";
            this.PanFooter.Size = new System.Drawing.Size(291, 41);
            this.PanFooter.TabIndex = 59;
            // 
            // cmdOk
            // 
            this.cmdOk.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cmdOk.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOk.Location = new System.Drawing.Point(143, 3);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(82, 34);
            this.cmdOk.TabIndex = 48;
            this.cmdOk.Text = "&Ok";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(5, 58);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(76, 15);
            this.Label1.TabIndex = 61;
            this.Label1.Text = "Current Pwd:";
            // 
            // tCurrentPwd
            // 
            this.tCurrentPwd.AcceptsReturn = true;
            this.tCurrentPwd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCurrentPwd.Location = new System.Drawing.Point(94, 55);
            this.tCurrentPwd.Name = "tCurrentPwd";
            this.tCurrentPwd.PasswordChar = '*';
            this.tCurrentPwd.Size = new System.Drawing.Size(94, 23);
            this.tCurrentPwd.TabIndex = 1;
            this.tCurrentPwd.UseSystemPasswordChar = true;
            // 
            // FrmChangePwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(291, 180);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.tConfirm);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.tPassword);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.tUsername);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.tUserID);
            this.Controls.Add(this.PanFooter);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.tCurrentPwd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmChangePwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.FrmChangePwd_Load);
            this.PanFooter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox tConfirm;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox tPassword;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox tUsername;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox tUserID;
        internal System.Windows.Forms.Button cmdClose;
        internal System.Windows.Forms.Panel PanFooter;
        internal System.Windows.Forms.Button cmdOk;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox tCurrentPwd;
    }
}