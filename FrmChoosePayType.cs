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
    public partial class FrmChoosePayType : Form
    {
        String SelectedPayTypes;
        public FrmChoosePayType()
        {
            InitializeComponent();
        }

        private void FrmChoosePayType_Load(object sender, EventArgs e)
        {
            LoadLvList();
        }

        public void LoadLvList()
        {
            try
            {
                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;
                SqlDataReader drSQL = null;

                lvList.Items.Clear();
                cmSQL.CommandText = "select Sn, PaymentType from PaymentType ORDER BY SN";
                cmSQL.CommandType = CommandType.Text;

                cnSQL.Open();
                drSQL = cmSQL.ExecuteReader();
                long j = 0;
                string initialText = null;
                while (drSQL.Read())
                {
                    j += 1;

                    initialText = drSQL["PaymentType"].ToString();
                    ListViewItem LvItems = new ListViewItem(initialText);

                    lvList.Items.AddRange(new ListViewItem[] { LvItems });
                }
                drSQL.Close();
                cmSQL.Connection.Close();
                cmSQL.Dispose();

                cnSQL.Close();
                cnSQL.Dispose();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            MyModules.ReturnPayTypes = "";
            this.Close();
        }

        private void mnuPayType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmPaymentType ChildForm = new FrmPaymentType();
            ChildForm.ShowDialog();
            LoadLvList();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            SelectedPayTypes = "";
            int i = 0;
            for (i = 0; i < lvList.Items.Count; i++)
            {
                if (lvList.Items[i].Checked)
                {
                    SelectedPayTypes = SelectedPayTypes + ((SelectedPayTypes != "") ? " : " : "") + lvList.Items[i].Text;
                }
            }
           MyModules.ReturnPayTypes= SelectedPayTypes;
            this.Close();

        }
    }
}
