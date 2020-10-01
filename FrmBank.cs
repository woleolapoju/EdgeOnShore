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
    public partial class FrmBank : Form
    {
        public FrmBank()
        {
            InitializeComponent();
        }

        private void FrmBank_Load(object sender, EventArgs e)
        {
            oLoad();
        }

        private void oLoad()
        {
            try
            {
                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;
                SqlDataReader drSQL = null;

                lvList.Items.Clear();

                cmSQL.CommandText = "SELECT [Bank],[Code] FROM Bank";


                cnSQL.Open();
                drSQL = cmSQL.ExecuteReader();
                long j = 0;
                string initialText = null;
                while (drSQL.Read())
                {
                    j += 1;
                    initialText = j.ToString();

                    ListViewItem LvItems = new ListViewItem(initialText);

                    LvItems.SubItems.Add(drSQL["Bank"].ToString());
                    LvItems.SubItems.Add(drSQL["Code"].ToString());

                    lvList.Items.AddRange(new ListViewItem[] { LvItems });
                }
                //cmSQL.Connection.Close()
                cmSQL.Dispose();
                drSQL.Close();
                cnSQL.Close();
                cnSQL.Dispose();

                lblCount.Text = j.ToString();

                return;

            }
            catch
            {
                //goto errhdl;
            }

        }

        private void CmdCut_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;

                tBank.Text = lvList.SelectedItems[0].SubItems[1].Text;
                tBankCode.Text = lvList.SelectedItems[0].SubItems[2].Text;
                if (MessageBox.Show("The selected record would be deleted completely" + "\r" + "Continue (y/n)", "DELETE RECORD", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cnSQL.Open();
                    cmSQL.CommandText = "DeleteBank";
                    cmSQL.CommandType = CommandType.StoredProcedure;
                    cmSQL.Parameters.AddWithValue("@Bank", tBank.Text);
                    cmSQL.ExecuteNonQuery();

                    cmSQL.Dispose();
                    cnSQL.Close();
                    oLoad();
                    tBank.Text = "";
                    tBankCode.Text = "";
                }
            }
            catch
            {
                MessageBox.Show(Microsoft.VisualBasic.Information.Err().Description, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
       

        }

        private void CmdOpen_Click(object sender, EventArgs e)
        {
            tBank.Tag = lvList.SelectedItems[0].SubItems[1].Text;
            tBank.Text = lvList.SelectedItems[0].SubItems[1].Text;
            tBankCode.Text = lvList.SelectedItems[0].SubItems[2].Text;
        }

        private void CmdInsert_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;

                if (string.IsNullOrEmpty(tBank.Text.Trim(' ')) || string.IsNullOrEmpty(tBankCode.Text.Trim(' ')))
                {
                    MessageBox.Show("Incomplete data", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                cnSQL.Open();

                System.Data.SqlClient.SqlTransaction myTrans = null;
                if (string.IsNullOrEmpty(Convert.ToString(tBank.Tag).Trim(' ')))
                {
                    cmSQL.CommandText = "InsertBank";
                    cmSQL.CommandType = CommandType.StoredProcedure;
                    cmSQL.Parameters.AddWithValue("@Bank", tBank.Text);
                    cmSQL.Parameters.AddWithValue("@BankCode", tBankCode.Text);
                    cmSQL.ExecuteNonQuery();
                }
                else
                {

                    myTrans = cnSQL.BeginTransaction();
                    cmSQL.Transaction = myTrans;

                    cmSQL.Parameters.Clear();
                    cmSQL.CommandText = "DeleteBank";
                    cmSQL.CommandType = CommandType.StoredProcedure;
                    cmSQL.Parameters.AddWithValue("@Bank", tBank.Tag);
                    cmSQL.ExecuteNonQuery();

                    cmSQL.Parameters.Clear();
                    cmSQL.CommandText = "InsertBank";
                    cmSQL.CommandType = CommandType.StoredProcedure;
                    cmSQL.Parameters.AddWithValue("@Bank", tBank.Text);
                    cmSQL.Parameters.AddWithValue("@BankCode", tBankCode.Text);
                    cmSQL.ExecuteNonQuery();

                    cmSQL.Parameters.Clear();
                    cmSQL.CommandText = "UPDATE RegisterStudent SET BankName='" + tBank.Text + "',BankCode='" + tBankCode.Text + "' WHERE BankName='" + tBank.Tag + "'" ;
                    cmSQL.CommandType = CommandType.Text;
                    cmSQL.ExecuteNonQuery();

                    cmSQL.Parameters.Clear();
                    cmSQL.CommandText = "UPDATE RegisterSchool SET BankName='" + tBank.Text + "',BankCode='" + tBankCode.Text + "' WHERE BankName='" + tBank.Tag + "'";
                    cmSQL.CommandType = CommandType.Text;
                    cmSQL.ExecuteNonQuery();

                    cmSQL.Parameters.Clear();
                    cmSQL.CommandText = "UPDATE RegisterVendor SET BankName='" + tBank.Text + "',BankCode='" + tBankCode.Text + "' WHERE BankName='" + tBank.Tag + "'";
                    cmSQL.CommandType = CommandType.Text;
                    cmSQL.ExecuteNonQuery();


                    myTrans.Commit();
                }
                cmSQL.Dispose();
                cnSQL.Close();
                oLoad();

                tBank.Text = "";
                tBankCode.Text = "";

            }

            catch (Exception ex)
            {
                if (Microsoft.VisualBasic.Information.Err().Number == 5)
                {
                    MessageBox.Show("Pls. selected an entry to Edit", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(ex.Message.ToString(), MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tBank_TextChanged(object sender, EventArgs e)
        {

        }

        private void PanCommands_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
