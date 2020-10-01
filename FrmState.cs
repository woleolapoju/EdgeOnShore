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
    public partial class FrmState : Form
    {
        public FrmState()
        {
            InitializeComponent();
        }

        private void FrmState_Load(object sender, EventArgs e)
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

                cmSQL.CommandText = "SELECT [State],[LGA] FROM States ORDER BY [State]";


                cnSQL.Open();
                drSQL = cmSQL.ExecuteReader();
                long j = 0;
                string initialText = null;
                while (drSQL.Read())
                {
                    j += 1;
                    initialText = j.ToString();

                    ListViewItem LvItems = new ListViewItem(initialText);

                    LvItems.SubItems.Add(drSQL["State"].ToString());
                    LvItems.SubItems.Add(drSQL["LGA"].ToString());

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

                tState.Text = lvList.SelectedItems[0].SubItems[1].Text;
                tLGA.Text = lvList.SelectedItems[0].SubItems[2].Text;
                if (MessageBox.Show("The selected record would be deleted completely" + "\r" + "Continue (y/n)", "DELETE RECORD", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cnSQL.Open();
                    cmSQL.CommandText = "DeleteState";
                    cmSQL.CommandType = CommandType.StoredProcedure;
                    cmSQL.Parameters.AddWithValue("@State", tState.Text);
                    cmSQL.Parameters.AddWithValue("@LGA", tLGA.Text);
                    cmSQL.ExecuteNonQuery();

                    cmSQL.Dispose();
                    cnSQL.Close();
                    oLoad();
                  //  tState.Text = "";
                    tLGA.Text = "";
                }
            }
            catch
            {
                MessageBox.Show(Microsoft.VisualBasic.Information.Err().Description, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }

        private void CmdOpen_Click(object sender, EventArgs e)
        {
            tState.Tag = lvList.SelectedItems[0].SubItems[1].Text;
            tLGA.Tag = lvList.SelectedItems[0].SubItems[2].Text;
            tState.Text = lvList.SelectedItems[0].SubItems[1].Text;
            tLGA.Text = lvList.SelectedItems[0].SubItems[2].Text;
        }

        private void CmdInsert_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;

                if (string.IsNullOrEmpty(tState.Text.Trim(' ')) || string.IsNullOrEmpty(tLGA.Text.Trim(' ')))
                {
                    MessageBox.Show("Incomplete data", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                cnSQL.Open();

                System.Data.SqlClient.SqlTransaction myTrans = null;
                if (string.IsNullOrEmpty(Convert.ToString(tState.Tag).Trim(' ')))
                {
                    cmSQL.CommandText = "InsertBank";
                    cmSQL.CommandType = CommandType.StoredProcedure;
                    cmSQL.Parameters.AddWithValue("@State", tState.Text);
                    cmSQL.Parameters.AddWithValue("@LGA", tLGA.Text);
                    cmSQL.ExecuteNonQuery();
                }
                else
                {

                    myTrans = cnSQL.BeginTransaction();
                    cmSQL.Transaction = myTrans;

                    cmSQL.Parameters.Clear();
                    cmSQL.CommandText = "DeleteState";
                    cmSQL.CommandType = CommandType.StoredProcedure;
                    cmSQL.Parameters.AddWithValue("@State", tState.Tag);
                    cmSQL.Parameters.AddWithValue("@LGA", tLGA.Tag);
                    cmSQL.ExecuteNonQuery();

                    cmSQL.Parameters.Clear();
                    cmSQL.CommandText = "InsertState";
                    cmSQL.CommandType = CommandType.StoredProcedure;
                    cmSQL.Parameters.AddWithValue("@State", tState.Text);
                    cmSQL.Parameters.AddWithValue("@LGA", tLGA.Text);
                    cmSQL.ExecuteNonQuery();

                    myTrans.Commit();
                }
                cmSQL.Dispose();
                cnSQL.Close();
                oLoad();
                //tState.Text = "";
                tLGA.Text = "";
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
    }
}

