using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Edge
{
    public partial class FrmSvrInfor : Form
    {
        public FrmSvrInfor()
        {
            InitializeComponent();
        }

        private void FrmSvrInfor_Load(object sender, EventArgs e)
        {

            string value = "";
            if (MyModules.InputBox("Access", "Enter Password:", ref value, true) == DialogResult.OK )
            {
               if (value!="Admin." || value=="")
                {
                    MessageBox.Show("Access Denied!");
                    this.Close();
                }
            }
            else
                this.Close();

            OleDbConnection cnDB = default(OleDbConnection);
            OleDbCommand cmSQL = default(OleDbCommand);
            OleDbDataReader drSQL = default(OleDbDataReader);
            this.Text = "Server Information";


            this.Width = 277;


            try
            {
                cnDB = new OleDbConnection(MyModules.MSAccessCn);
                cnDB.Open();

                cmSQL = new OleDbCommand("SELECT * FROM SvrParam", cnDB);
                drSQL = cmSQL.ExecuteReader();

                if (drSQL.HasRows == false)
                {
                    MessageBox.Show("Invalid Configuration Parameter" + "\r" + "System Halted", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Environment.Exit(0);
                }
                if (drSQL.Read())
                {
                    cboServerName.Text = drSQL["ServerName"].ToString();
                    txtUserID.Text = drSQL["UserID"].ToString();
                    txtPassword.Text = drSQL["Password"].ToString();
                    txtAttachName.Text = drSQL["AttachName"].ToString();
                    chkWinAuthen.Checked = Convert.ToBoolean(drSQL["IntegratedSecurity"]);
                    txtOwner.Text = drSQL["Owner"].ToString();
                }

                drSQL.Close();
                cmSQL.Dispose();
                cnDB.Close();
                cnDB.Dispose();

                // LoadServer()

                // AttachDetails()

                chkWinAuthen_CheckedChanged(sender, e);

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkWinAuthen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWinAuthen.Checked == true)
            {
                txtUserID.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtUserID.Enabled = true;
                txtPassword.Enabled = true;
            }
        }

        private void cmdDBMain_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.InitialDirectory = MyModules.AppPath;
            OpenFileDialog.Filter = "DB Data Files (*.mdf)|*.mdf";
            if ((OpenFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK))
            {
                string FileName = OpenFileDialog.FileName;
                txtDBName.Text = FileName;
            }
        }


        private void FrmSvrInfor_DoubleClick(object sender, System.EventArgs e)
        {
            OleDbConnection cnDB = default(OleDbConnection);
            OleDbCommand cmSQL = default(OleDbCommand);
            OleDbDataReader drSQL = default(OleDbDataReader);
            string StrPwd = null;
            StrPwd = Microsoft.VisualBasic.Interaction.InputBox("Enter Password", "Authentication");

            if (string.IsNullOrEmpty(StrPwd))
                return;


            try
            {
                cnDB = new OleDbConnection(MyModules.MSAccessCn);
                cnDB.Open();

                cmSQL = new OleDbCommand("SELECT * FROM SvrParam", cnDB);
                drSQL = cmSQL.ExecuteReader();

                if (drSQL.HasRows == false)
                {
                    MessageBox.Show("Invalid Configuration Parameter" + char.ConvertFromUtf32(13) + "System Halted", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Environment.Exit(0);
                }
                if (drSQL.Read())
                {
                    if (drSQL["AdminPwd"].ToString() == StrPwd || drSQL["ControlPwd"].ToString() == StrPwd)
                    {
                        GrpAdvance.Enabled = true;
                        this.Width = 507;
                    }
                }

                drSQL.Close();
                cnDB.Close();
                cmSQL.Dispose();
                cnDB.Dispose();

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            string strSql = null;
            dynamic intRowsAffected = null;
            try
            {
                using (OleDbConnection cnOle = new OleDbConnection(MyModules.MSAccessCn))
                {
                    cnOle.Open();
                    strSql = "UPDATE SvrParam SET [ServerName] = '" + cboServerName.Text.Trim() + "', [UserID] = '" + txtUserID.Text.Trim() + "' ,[Password] = '" + txtPassword.Text.Trim() + "' ,[AttachName] = '" + txtAttachName.Text.Trim() + "',[IntegratedSecurity] = " + chkWinAuthen.Checked + " ,[Owner] = '" + txtOwner.Text.Trim() + "'";

                    OleDbCommand cmOle = new OleDbCommand(strSql, cnOle);
                    intRowsAffected = cmOle.ExecuteNonQuery();
                    cnOle.Close();
                    cmOle.Dispose();
                    cnOle.Dispose();
                    MyModules.InitialiseEntireSystem();
                    MessageBox.Show("Update Successfull" + char.ConvertFromUtf32(13) + "Pls. Restart", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //InitialiseEntireSystem()
                    System.Environment.Exit(0);
                    //Me.Close()

                }

                if (intRowsAffected != 1)
                {
                    MessageBox.Show("Update Failed.", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmdAttach_Click(object sender, EventArgs e)
        {
            try
            {
                string connectStr = null;
                if (string.IsNullOrEmpty(txtDBName.Text.Trim()))
                {
                    MessageBox.Show("Pls. select the database", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (chkWinAuthen.Checked)
                {
                    connectStr = "workstation id=" + cboServerName.Text + ";packet size=4096;data source=" + cboServerName.Text + ";Integrated Security=True;initial catalog=master";
                }
                else
                {
                    connectStr = "workstation id=" + cboServerName.Text + ";packet size=4096;user id=" + txtUserID.Text + ";pwd=" + txtPassword.Text + ";data source=" + cboServerName.Text + ";persist security info=False;initial catalog=master";
                }

                SqlConnection SqlCn = new SqlConnection(connectStr);
                SqlCn.Open();
                if (txtAttachName.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Pls. choose a valid data file", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // ERROR: Not supported in C#: OnErrorStatement

                //'Dim myTrans As SqlTransaction
                //'myTrans = SqlCn.BeginTransaction(IsolationLevel.Serializable, "MyTrans")
                SqlCommand myCommand = new SqlCommand("FetchUserAccessByPwd", SqlCn);




                //'myCommand.Transaction = myTrans

                myCommand.CommandText = "EXEC sp_detach_db @dbname = '" + cboavaliableDB.Text + "'";
                myCommand.ExecuteNonQuery();

                // ERROR: Not supported in C#: OnErrorStatement

                myCommand.CommandText = "EXEC sp_attach_db @dbname = N'" + txtAttachName.Text + "',@filename1 = N'" + txtDBName.Text.Trim() + "',@filename2 = N'" + MyModules.Mid((txtDBName.Text.Trim()), 1, Microsoft.VisualBasic.Strings.InStr(txtDBName.Text.Trim(), ".") - 1) + ".ldf" + "'";
                myCommand.ExecuteNonQuery();
                //'myTrans.Commit()

                myCommand.Connection.Close();
                myCommand.Dispose();
                SqlCn.Close();
                SqlCn.Dispose();
                MessageBox.Show("Successfully Attached", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cboavaliableDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAttachName.Text = cboavaliableDB.Text;
        }

        private void PanFooter_DoubleClick(object sender, System.EventArgs e)
        {
            OleDbConnection cnDB = default(OleDbConnection);
            OleDbCommand cmSQL = default(OleDbCommand);
            OleDbDataReader drSQL = default(OleDbDataReader);
            string StrPwd = null;
            StrPwd = Microsoft.VisualBasic.Interaction.InputBox("Enter Password", "Authentication");

            if (string.IsNullOrEmpty(StrPwd))
                return;


            try
            {
                cnDB = new OleDbConnection(MyModules.MSAccessCn);
                cnDB.Open();

                cmSQL = new OleDbCommand("SELECT * FROM SvrParam", cnDB);
                drSQL = cmSQL.ExecuteReader();

                if (drSQL.HasRows == false)
                {
                    MessageBox.Show("Invalid Configuration Parameter" + char.ConvertFromUtf32(13) + "System Halted", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Environment.Exit(0);
                }
                if (drSQL.Read())
                {
                    if (drSQL["AdminPwd"].ToString() == StrPwd || drSQL["ControlPwd"].ToString() == StrPwd)
                    {
                        GrpAdvance.Enabled = true;
                        this.Width = 507;
                    }
                }

                drSQL.Close();
                cnDB.Close();
                cmSQL.Dispose();
                cnDB.Dispose();

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
