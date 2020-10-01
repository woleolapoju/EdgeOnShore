using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Edge
{
    public partial class FrmChangePwd : Form
    {
        public FrmChangePwd()
        {
            InitializeComponent();
        }

        private void FrmChangePwd_Load(object sender, EventArgs e)
        {
            tUserID.Text =MyModules.sysUser;
            tUsername.Text = MyModules.sysUserName;
            tCurrentPwd.Focus();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand("FetchUserAccessByPwd", cnSQL);
               // SqlDataReader drSQL;

                if (!IsValidForm())
                {
                    return;
                }
                if (tCurrentPwd.Text !=MyModules.sysPwd)
                {
                    MessageBox.Show("Current Password is incorrect!!",MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                cnSQL.Open();

                cmSQL.CommandText = "UPDATE UserAccess SET UserPassword='" + tPassword.Text + "' WHERE UserID='" + tUserID.Text + "'";
                cmSQL.CommandType = CommandType.Text;
                cmSQL.ExecuteNonQuery();

                //cmSQL.Connection.Close()
                cmSQL.Dispose();
                cnSQL.Close();
                //cnSQL.Dispose()

                MessageBox.Show("Password changed Successfully", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                //object sender1 = null;
                //EventArgs e1 = null;
                //FrmMainMenu.radLogOff_Click(sender1, e1);

                this.Close();


                return;
      
        }
            catch(Exception ex)
            {
                MessageBox.Show("Ooops! ERROR :" + char.ConvertFromUtf32(13) + ex, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
         
        }
        private bool IsValidForm()
        {
            bool tempIsValidForm = false;
            try
            {
                tempIsValidForm = true;
                if (string.IsNullOrEmpty(tUserID.Text) || string.IsNullOrEmpty(tUsername.Text) || string.IsNullOrEmpty(tPassword.Text) || string.IsNullOrEmpty(tConfirm.Text))
                {
                    MessageBox.Show("Incomplete data for update",MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (tPassword.Text != tConfirm.Text)
                {
                    MessageBox.Show("Inconsistant Password", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                return tempIsValidForm;
              
            }
            catch (Exception ex)
            {
                     MessageBox.Show("Ooops! ERROR :" + char.ConvertFromUtf32(13) + ex, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return tempIsValidForm;
            }
          
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
