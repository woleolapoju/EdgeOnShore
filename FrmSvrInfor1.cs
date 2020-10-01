
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.OleDb;
using system.data.SqlClient;

public class FrmSvrInfor
{

	private void cmdClose_Click(System.Object sender, System.EventArgs e)
	{
		this.Close();
	}

	private void cmdDBMain_Click(System.Object sender, System.EventArgs e)
	{
		OpenFileDialog OpenFileDialog = new OpenFileDialog();
		OpenFileDialog.InitialDirectory = My.Application.Info.DirectoryPath;
		OpenFileDialog.Filter = "DB Data Files (*.mdf)|*.mdf";
		if ((OpenFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)) {
			string FileName = OpenFileDialog.FileName;
			txtDBName.Text = FileName;
		}
	}

	private void chkWinAuthen_CheckedChanged(System.Object sender, System.EventArgs e)
	{
		if (chkWinAuthen.Checked == true) {
			txtUserID.Enabled = false;
			txtPassword.Enabled = false;
		} else {
			txtUserID.Enabled = true;
			txtPassword.Enabled = true;
		}
	}

	private void FrmSvrInfor_Load(System.Object sender, System.EventArgs e)
	{
		LoadUserTheme(this);
		PanFooter.BackColor = HeaderTheme;

		OleDbConnection cnDB = default(OleDbConnection);
		OleDbCommand cmSQL = default(OleDbCommand);
		OleDbDataReader drSQL = default(OleDbDataReader);
		this.Text = "Server Information";


		this.Width = 277;


		try {
			cnDB = new OleDbConnection(MSAccessCn);
			cnDB.Open();

			cmSQL = new OleDbCommand("SELECT * FROM SvrParam", cnDB);
			drSQL = cmSQL.ExecuteReader();

			if (drSQL.HasRows == false) {
				Interaction.MsgBox("Invalid Configuration Parameter" + Strings.Chr(13) + "System Halted", MsgBoxStyle.Information);
				System.Environment.Exit(0);
			}
			if (drSQL.Read) {
				cboServerName.Text = ChkNull(drSQL.Item("ServerName"));
				txtUserID.Text = ChkNull(drSQL.Item("UserID"));
				txtPassword.Text = ChkNull(drSQL.Item("Password"));
				txtAttachName.Text = ChkNull(drSQL.Item("AttachName"));
				chkWinAuthen.Checked = drSQL.Item("IntegratedSecurity");
				txtOwner.Text = ChkNull(drSQL.Item("Owner"));
			}

			drSQL.Close();
			cmSQL.Dispose();
			cnDB.Close();
			cnDB.Dispose();

			// LoadServer()

			// AttachDetails()

			chkWinAuthen_CheckedChanged(sender, e);

		} catch (Exception er) {
			Interaction.MsgBox(er.Message, MsgBoxStyle.Critical, strApptitle);
		}

	}
	private void FrmSvrInfor_DoubleClick(object sender, System.EventArgs e)
	{
		OleDbConnection cnDB = default(OleDbConnection);
		OleDbCommand cmSQL = default(OleDbCommand);
		OleDbDataReader drSQL = default(OleDbDataReader);
		string StrPwd = null;
		StrPwd = Interaction.InputBox("Enter Password", "Authentication");
		if (string.IsNullOrEmpty(StrPwd))
			return;


		try {
			cnDB = new OleDbConnection(MSAccessCn);
			cnDB.Open();

			cmSQL = new OleDbCommand("SELECT * FROM SvrParam", cnDB);
			drSQL = cmSQL.ExecuteReader();

			if (drSQL.HasRows == false) {
				Interaction.MsgBox("Invalid Configuration Parameter" + Strings.Chr(13) + "System Halted", MsgBoxStyle.Information);
				System.Environment.Exit(0);
			}
			if (drSQL.Read) {
				if (drSQL.Item("AdminPwd") == StrPwd | drSQL.Item("ControlPwd") == StrPwd) {
					GrpAdvance.Enabled = true;
					this.Width = 507;
				}
			}

			drSQL.Close();
			cnDB.Close();
			cmSQL.Dispose();
			cnDB.Dispose();

		} catch (Exception er) {
			Interaction.MsgBox(er.Message, MsgBoxStyle.Critical, strApptitle);
		}

	}

	private void cmdOk_Click(System.Object sender, System.EventArgs e)
	{
		string strSql = null;
		dynamic intRowsAffected = null;
		try {
			using (OleDbConnection cnOle = new OleDbConnection(MSAccessCn)) {
				cnOle.Open();
				strSql = "UPDATE SvrParam SET" + " ServerName = '" + Strings.Trim(ChkNull(cboServerName.Text)) + "'" + " ,UserID = '" + Strings.Trim(ChkNull(txtUserID.Text)) + "'" + " ,[Password] = '" + Strings.Trim(ChkNull(txtPassword.Text)) + "'" + " ,AttachName = '" + Strings.Trim(ChkNull(txtAttachName.Text)) + "'" + " ,IntegratedSecurity = " + chkWinAuthen.Checked + " ,Owner = '" + Strings.Trim(ChkNull(txtOwner.Text)) + "'";

				OleDbCommand cmOle = new OleDbCommand(strSql, cnOle);
				intRowsAffected = cmOle.ExecuteNonQuery();
				cnOle.Close();
				cmOle.Dispose();
				cnOle.Dispose();
				InitialiseEntireSystem();
				Interaction.MsgBox("Update Successfull" + Strings.Chr(13) + "Pls. Restart", MsgBoxStyle.Information, strApptitle);
				//InitialiseEntireSystem()
				System.Environment.Exit(0);
				//Me.Close()

			}

			if (intRowsAffected != 1) {
				Interaction.MsgBox("Update Failed.", MsgBoxStyle.Critical, "Update");
			}


		} catch (Exception er) {
			Interaction.MsgBox(er.Message, MsgBoxStyle.Critical, strApptitle);
		}
	}

	private void cmdAttach_Click(System.Object sender, System.EventArgs e)
	{
		 // ERROR: Not supported in C#: OnErrorStatement

		string connectStr = null;
		if (string.IsNullOrEmpty(Strings.Trim(txtDBName.Text))) {
			Interaction.MsgBox("Pls. select the database", MsgBoxStyle.Information, strApptitle);
			return;
		}
		if (chkWinAuthen.Checked) {
			connectStr = "workstation id=" + cboServerName.Text + ";packet size=4096;data source=" + cboServerName.Text + ";Integrated Security=True;initial catalog=master";
		} else {
			connectStr = "workstation id=" + cboServerName.Text + ";packet size=4096;user id=" + txtUserID.Text + ";pwd=" + txtPassword.Text + ";data source=" + cboServerName.Text + ";persist security info=False;initial catalog=master";
		}

		SqlConnection SqlCn = new SqlConnection(connectStr);
		string strConnectMaster = null;
		SqlCn.Open();
		if (Strings.Len(Strings.Trim(txtAttachName.Text)) == 0) {
			Interaction.MsgBox("Pls. choose a valid data file", MsgBoxStyle.Information, strApptitle);
			return;
		}
		 // ERROR: Not supported in C#: OnErrorStatement

		//'Dim myTrans As SqlTransaction
		//'myTrans = SqlCn.BeginTransaction(IsolationLevel.Serializable, "MyTrans")
		SqlCommand myCommand = SqlCn.CreateCommand;
		//'myCommand.Transaction = myTrans

		myCommand.CommandText = "EXEC sp_detach_db @dbname = '" + cboavaliableDB.Text + "'";
		myCommand.ExecuteNonQuery();

		 // ERROR: Not supported in C#: OnErrorStatement

		myCommand.CommandText = "EXEC sp_attach_db @dbname = N'" + txtAttachName.Text + "',@filename1 = N'" + Strings.Trim(txtDBName.Text) + "',@filename2 = N'" + Strings.Mid(Strings.Trim(txtDBName.Text), 1, Strings.InStr(Strings.Trim(txtDBName.Text), ".") - 1) + ".ldf" + "'";
		myCommand.ExecuteNonQuery();
		//'myTrans.Commit()

		myCommand.Connection.Close();
		myCommand.Dispose();
		SqlCn.Close();
		SqlCn.Dispose();
		Interaction.MsgBox("Successfully Attached", Constants.vbInformation);
		return;
		 // ERROR: Not supported in C#: ResumeStatement

		handler:
		Interaction.MsgBox(Err.Description, MsgBoxStyle.Information, strApptitle);
	}
	private void cboavaliableDB_SelectedIndexChanged(System.Object sender, System.EventArgs e)
	{
		txtAttachName.Text = cboavaliableDB.Text;
	}
	public FrmSvrInfor()
	{
		DoubleClick += FrmSvrInfor_DoubleClick;
		Load += FrmSvrInfor_Load;
	}
}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
