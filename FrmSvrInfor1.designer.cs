
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
partial class FrmSvrInfor1 : System.Windows.Forms.Form
{

	//Form overrides dispose to clean up the component list.
	[System.Diagnostics.DebuggerNonUserCode()]
	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null) {
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	//Required by the Windows Form Designer

	private System.ComponentModel.IContainer components;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.  
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSvrInfor));
		this.GrpServ = new System.Windows.Forms.GroupBox();
		this.cboavaliableDB = new System.Windows.Forms.ComboBox();
		this.Label5 = new System.Windows.Forms.Label();
		this.txtAttachName = new System.Windows.Forms.TextBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.cboServerName = new System.Windows.Forms.ComboBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.GrpAuthenticate = new System.Windows.Forms.GroupBox();
		this.txtPassword = new System.Windows.Forms.TextBox();
		this.txtUserID = new System.Windows.Forms.TextBox();
		this.chkWinAuthen = new System.Windows.Forms.CheckBox();
		this.Label3 = new System.Windows.Forms.Label();
		this.Label4 = new System.Windows.Forms.Label();
		this.GrpAttach = new System.Windows.Forms.GroupBox();
		this.cmdAttach = new System.Windows.Forms.Button();
		this.cmdDBMain = new System.Windows.Forms.Button();
		this.txtDBName = new System.Windows.Forms.TextBox();
		this.Label6 = new System.Windows.Forms.Label();
		this.GrpAdvance = new System.Windows.Forms.GroupBox();
		this.txtOwner = new System.Windows.Forms.TextBox();
		this.Label7 = new System.Windows.Forms.Label();
		this.cmdOk = new System.Windows.Forms.Button();
		this.cmdClose = new System.Windows.Forms.Button();
		this.PanFooter = new System.Windows.Forms.Panel();
		this.Panel2 = new System.Windows.Forms.Panel();
		this.GrpServ.SuspendLayout();
		this.GrpAuthenticate.SuspendLayout();
		this.GrpAttach.SuspendLayout();
		this.GrpAdvance.SuspendLayout();
		this.PanFooter.SuspendLayout();
		this.Panel2.SuspendLayout();
		this.SuspendLayout();
		//
		//GrpServ
		//
		this.GrpServ.Controls.Add(this.cboavaliableDB);
		this.GrpServ.Controls.Add(this.Label5);
		this.GrpServ.Controls.Add(this.txtAttachName);
		this.GrpServ.Controls.Add(this.Label2);
		this.GrpServ.Controls.Add(this.cboServerName);
		this.GrpServ.Controls.Add(this.Label1);
		this.GrpServ.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
		this.GrpServ.Location = new System.Drawing.Point(5, 0);
		this.GrpServ.Name = "GrpServ";
		this.GrpServ.Size = new System.Drawing.Size(251, 109);
		this.GrpServ.TabIndex = 0;
		this.GrpServ.TabStop = false;
		this.GrpServ.Text = "Server Infor";
		//
		//cboavaliableDB
		//
		this.cboavaliableDB.FormattingEnabled = true;
		this.cboavaliableDB.Location = new System.Drawing.Point(103, 75);
		this.cboavaliableDB.Name = "cboavaliableDB";
		this.cboavaliableDB.Size = new System.Drawing.Size(138, 23);
		this.cboavaliableDB.TabIndex = 5;
		//
		//Label5
		//
		this.Label5.AutoSize = true;
		this.Label5.Location = new System.Drawing.Point(6, 83);
		this.Label5.Name = "Label5";
		this.Label5.Size = new System.Drawing.Size(76, 15);
		this.Label5.TabIndex = 4;
		this.Label5.Text = "Available DB:";
		//
		//txtAttachName
		//
		this.txtAttachName.Location = new System.Drawing.Point(103, 47);
		this.txtAttachName.Name = "txtAttachName";
		this.txtAttachName.Size = new System.Drawing.Size(138, 23);
		this.txtAttachName.TabIndex = 3;
		//
		//Label2
		//
		this.Label2.AutoSize = true;
		this.Label2.Location = new System.Drawing.Point(6, 54);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(93, 15);
		this.Label2.TabIndex = 2;
		this.Label2.Text = "Attached Name:";
		//
		//cboServerName
		//
		this.cboServerName.FormattingEnabled = true;
		this.cboServerName.Location = new System.Drawing.Point(103, 18);
		this.cboServerName.Name = "cboServerName";
		this.cboServerName.Size = new System.Drawing.Size(138, 23);
		this.cboServerName.TabIndex = 1;
		//
		//Label1
		//
		this.Label1.AutoSize = true;
		this.Label1.Location = new System.Drawing.Point(6, 26);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(77, 15);
		this.Label1.TabIndex = 0;
		this.Label1.Text = "Server Name:";
		//
		//GrpAuthenticate
		//
		this.GrpAuthenticate.Controls.Add(this.txtPassword);
		this.GrpAuthenticate.Controls.Add(this.txtUserID);
		this.GrpAuthenticate.Controls.Add(this.chkWinAuthen);
		this.GrpAuthenticate.Controls.Add(this.Label3);
		this.GrpAuthenticate.Controls.Add(this.Label4);
		this.GrpAuthenticate.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
		this.GrpAuthenticate.Location = new System.Drawing.Point(5, 110);
		this.GrpAuthenticate.Name = "GrpAuthenticate";
		this.GrpAuthenticate.Size = new System.Drawing.Size(251, 93);
		this.GrpAuthenticate.TabIndex = 1;
		this.GrpAuthenticate.TabStop = false;
		this.GrpAuthenticate.Text = "Authentication";
		//
		//txtPassword
		//
		this.txtPassword.Location = new System.Drawing.Point(101, 64);
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.PasswordChar = global::Microsoft.VisualBasic.ChrW(42);
		this.txtPassword.Size = new System.Drawing.Size(138, 23);
		this.txtPassword.TabIndex = 5;
		//
		//txtUserID
		//
		this.txtUserID.Location = new System.Drawing.Point(101, 36);
		this.txtUserID.Name = "txtUserID";
		this.txtUserID.Size = new System.Drawing.Size(138, 23);
		this.txtUserID.TabIndex = 4;
		//
		//chkWinAuthen
		//
		this.chkWinAuthen.AutoSize = true;
		this.chkWinAuthen.Location = new System.Drawing.Point(9, 18);
		this.chkWinAuthen.Name = "chkWinAuthen";
		this.chkWinAuthen.Size = new System.Drawing.Size(157, 19);
		this.chkWinAuthen.TabIndex = 3;
		this.chkWinAuthen.Text = "Windows Authentication";
		this.chkWinAuthen.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		this.chkWinAuthen.UseVisualStyleBackColor = true;
		//
		//Label3
		//
		this.Label3.AutoSize = true;
		this.Label3.Location = new System.Drawing.Point(6, 68);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(60, 15);
		this.Label3.TabIndex = 2;
		this.Label3.Text = "Password:";
		//
		//Label4
		//
		this.Label4.AutoSize = true;
		this.Label4.Location = new System.Drawing.Point(6, 41);
		this.Label4.Name = "Label4";
		this.Label4.Size = new System.Drawing.Size(47, 15);
		this.Label4.TabIndex = 0;
		this.Label4.Text = "User ID:";
		//
		//GrpAttach
		//
		this.GrpAttach.Controls.Add(this.cmdAttach);
		this.GrpAttach.Controls.Add(this.cmdDBMain);
		this.GrpAttach.Controls.Add(this.txtDBName);
		this.GrpAttach.Controls.Add(this.Label6);
		this.GrpAttach.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
		this.GrpAttach.Location = new System.Drawing.Point(5, 207);
		this.GrpAttach.Name = "GrpAttach";
		this.GrpAttach.Size = new System.Drawing.Size(251, 78);
		this.GrpAttach.TabIndex = 2;
		this.GrpAttach.TabStop = false;
		this.GrpAttach.Text = "DB Attachment";
		//
		//cmdAttach
		//
		this.cmdAttach.Location = new System.Drawing.Point(158, 43);
		this.cmdAttach.Name = "cmdAttach";
		this.cmdAttach.Size = new System.Drawing.Size(84, 26);
		this.cmdAttach.TabIndex = 15;
		this.cmdAttach.Text = "&Attach";
		this.cmdAttach.UseVisualStyleBackColor = true;
		//
		//cmdDBMain
		//
		this.cmdDBMain.Location = new System.Drawing.Point(217, 18);
		this.cmdDBMain.Name = "cmdDBMain";
		this.cmdDBMain.Size = new System.Drawing.Size(25, 25);
		this.cmdDBMain.TabIndex = 14;
		this.cmdDBMain.Text = "...";
		this.cmdDBMain.UseVisualStyleBackColor = true;
		//
		//txtDBName
		//
		this.txtDBName.Location = new System.Drawing.Point(100, 19);
		this.txtDBName.Name = "txtDBName";
		this.txtDBName.Size = new System.Drawing.Size(117, 23);
		this.txtDBName.TabIndex = 12;
		//
		//Label6
		//
		this.Label6.AutoSize = true;
		this.Label6.Location = new System.Drawing.Point(6, 24);
		this.Label6.Name = "Label6";
		this.Label6.Size = new System.Drawing.Size(76, 15);
		this.Label6.TabIndex = 10;
		this.Label6.Text = "DB Filename:";
		//
		//GrpAdvance
		//
		this.GrpAdvance.Controls.Add(this.txtOwner);
		this.GrpAdvance.Controls.Add(this.Label7);
		this.GrpAdvance.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
		this.GrpAdvance.Location = new System.Drawing.Point(261, 0);
		this.GrpAdvance.Name = "GrpAdvance";
		this.GrpAdvance.Size = new System.Drawing.Size(225, 110);
		this.GrpAdvance.TabIndex = 3;
		this.GrpAdvance.TabStop = false;
		this.GrpAdvance.Text = "Advance Setting";
		//
		//txtOwner
		//
		this.txtOwner.Location = new System.Drawing.Point(50, 19);
		this.txtOwner.Multiline = true;
		this.txtOwner.Name = "txtOwner";
		this.txtOwner.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtOwner.Size = new System.Drawing.Size(169, 79);
		this.txtOwner.TabIndex = 5;
		//
		//Label7
		//
		this.Label7.AutoSize = true;
		this.Label7.Location = new System.Drawing.Point(3, 49);
		this.Label7.Name = "Label7";
		this.Label7.Size = new System.Drawing.Size(45, 15);
		this.Label7.TabIndex = 4;
		this.Label7.Text = "Owner:";
		//
		//cmdOk
		//
		this.cmdOk.Location = new System.Drawing.Point(5, 2);
		this.cmdOk.Name = "cmdOk";
		this.cmdOk.Size = new System.Drawing.Size(87, 37);
		this.cmdOk.TabIndex = 4;
		this.cmdOk.Text = "&Ok";
		this.cmdOk.UseVisualStyleBackColor = true;
		//
		//cmdClose
		//
		this.cmdClose.Location = new System.Drawing.Point(92, 2);
		this.cmdClose.Name = "cmdClose";
		this.cmdClose.Size = new System.Drawing.Size(68, 37);
		this.cmdClose.TabIndex = 5;
		this.cmdClose.Text = "&Close";
		this.cmdClose.UseVisualStyleBackColor = true;
		//
		//PanFooter
		//
		this.PanFooter.BackColor = System.Drawing.Color.AntiqueWhite;
		this.PanFooter.Controls.Add(this.Panel2);
		this.PanFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.PanFooter.Location = new System.Drawing.Point(0, 284);
		this.PanFooter.Name = "PanFooter";
		this.PanFooter.Size = new System.Drawing.Size(261, 41);
		this.PanFooter.TabIndex = 6;
		//
		//Panel2
		//
		this.Panel2.Controls.Add(this.cmdClose);
		this.Panel2.Controls.Add(this.cmdOk);
		this.Panel2.Dock = System.Windows.Forms.DockStyle.Right;
		this.Panel2.Location = new System.Drawing.Point(97, 0);
		this.Panel2.Name = "Panel2";
		this.Panel2.Size = new System.Drawing.Size(164, 41);
		this.Panel2.TabIndex = 7;
		//
		//FrmSvrInfor
		//
		this.AcceptButton = this.cmdOk;
		this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		this.BackColor = System.Drawing.Color.FloralWhite;
		this.ClientSize = new System.Drawing.Size(261, 325);
		this.Controls.Add(this.PanFooter);
		this.Controls.Add(this.GrpAdvance);
		this.Controls.Add(this.GrpAttach);
		this.Controls.Add(this.GrpAuthenticate);
		this.Controls.Add(this.GrpServ);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "FrmSvrInfor";
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Server Information";
		this.GrpServ.ResumeLayout(false);
		this.GrpServ.PerformLayout();
		this.GrpAuthenticate.ResumeLayout(false);
		this.GrpAuthenticate.PerformLayout();
		this.GrpAttach.ResumeLayout(false);
		this.GrpAttach.PerformLayout();
		this.GrpAdvance.ResumeLayout(false);
		this.GrpAdvance.PerformLayout();
		this.PanFooter.ResumeLayout(false);
		this.Panel2.ResumeLayout(false);
		this.ResumeLayout(false);

	}
	internal System.Windows.Forms.GroupBox GrpServ;
	internal System.Windows.Forms.TextBox txtAttachName;
	internal System.Windows.Forms.Label Label2;
	internal System.Windows.Forms.ComboBox cboServerName;
	internal System.Windows.Forms.Label Label1;
	internal System.Windows.Forms.GroupBox GrpAuthenticate;
	internal System.Windows.Forms.CheckBox chkWinAuthen;
	internal System.Windows.Forms.Label Label3;
	internal System.Windows.Forms.Label Label4;
	internal System.Windows.Forms.TextBox txtPassword;
	internal System.Windows.Forms.TextBox txtUserID;
	internal System.Windows.Forms.GroupBox GrpAttach;
	internal System.Windows.Forms.TextBox txtDBName;
	internal System.Windows.Forms.Label Label6;
	internal System.Windows.Forms.Button cmdDBMain;
	internal System.Windows.Forms.GroupBox GrpAdvance;
	internal System.Windows.Forms.TextBox txtOwner;
	internal System.Windows.Forms.Label Label7;
	internal System.Windows.Forms.Button cmdOk;
	internal System.Windows.Forms.Button cmdClose;
	internal System.Windows.Forms.Button cmdAttach;
	internal System.Windows.Forms.ComboBox cboavaliableDB;
	internal System.Windows.Forms.Label Label5;

}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
