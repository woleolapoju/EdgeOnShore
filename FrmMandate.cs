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
    public partial class FrmMandate : Form
    {
        public FrmMandate()
        {
            InitializeComponent();
        }

        private void cmdNewMandate_Click(object sender, EventArgs e)
        {
            FrmPayment childform = new FrmPayment("",-1);
            childform.ShowDialog();
            listOfMandates();
        }

        private void btnDeduction_Click(object sender, EventArgs e)
        {

            //if (MyModules.GetUserAccessDetails("Payments") == false)
            //    return;
            //FrmPayDeduction childform = new FrmPayDeduction("WHT", "", 0);
            //childform.ShowDialog();

            FrmDeductionType childform = new FrmDeductionType();
            childform.ShowDialog();
            listOfMandates();
        }

        private void lvList_DoubleClick(object sender, EventArgs e)
        {
            try {
                ListView.SelectedListViewItemCollection SLV = lvList.SelectedItems;
                foreach (ListViewItem item in SLV)
                {
                    if (item.SubItems[5].Text == "Main") {
                        FrmPayment ChildForm = new FrmPayment(item.Text, -1);
                        if (Convert.ToBoolean(item.SubItems[4].Text) == true)
                        {
                            ChildForm.cmdSave.Enabled = false;
                        }
                        else
                        {
                            ChildForm.cmdSave.Enabled = true;
                        }

                        ChildForm.ShowDialog();
                    }
                    else
                    {

                        FrmPayDeduction ChildForm1 = new FrmPayDeduction(item.SubItems[5].Text, item.Text, -1);

                        if (Convert.ToBoolean(item.SubItems[4].Text) == true)
                        {
                            ChildForm1.cmdSave.Enabled = false;
                        }
                        else
                        {
                            ChildForm1.cmdSave.Enabled = true;
                        }

                        ChildForm1.ShowDialog();
                    }
                    listOfMandates();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void listOfMandates()
        {
            try
            {

                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                    cmSQL.Connection=cnSQL;

                SqlDataReader drSQL = null;
                lvList.Items.Clear();
                string str = "SELECT MandateNo, COUNT(RefNo) AS NoOfPayments, SUM(Amount) AS TheAmount,MAX([PayValueDate]) AS PayValueDate,Authorised,'Main' AS MandateType FROM Payment WHERE [PayValueDate]>='" + dtpStartDate.Text + "' AND [PayValueDate]<='" + dtpEndDate.Text + "' GROUP BY MandateNo,Authorised"; // ORDER BY [PayValueDate]";
                str = str + " UNION SELECT MandateNo, COUNT(RefNo) AS NoOfPayments, SUM(Amount) AS TheAmount,MAX([PayValueDate]) AS PayValueDate,Authorised,MAX(MainAction) AS MandateType FROM PaymentDeductions WHERE [PayValueDate]>='" + dtpStartDate.Text + "' AND [PayValueDate]<='" + dtpEndDate.Text + "' GROUP BY MandateNo,Authorised ORDER BY [PayValueDate]";
                cmSQL.CommandText = str;

                cmSQL.CommandType = CommandType.Text;

                cnSQL.Open();

                string initialText = "";
                ListViewItem LvItems = new ListViewItem(initialText);
                drSQL = cmSQL.ExecuteReader();
                while (drSQL.Read())
                {
                    initialText = drSQL["MandateNo"].ToString();
                    LvItems = new ListViewItem(initialText);
                    LvItems.SubItems.Add(MyModules.FormatDate(drSQL["PayValueDate"]).ToString()); //        Convert.ToDateTime(drSQL["TheDate"]).ToString("dd-MMM-yyyy"));
                    LvItems.SubItems.Add(drSQL["NoOfPayments"].ToString());
                    LvItems.SubItems.Add(MyModules.FormatDouble(drSQL["TheAmount"]).ToString());
                    LvItems.SubItems.Add(Convert.ToBoolean(drSQL["Authorised"]).ToString());
                    LvItems.SubItems.Add(drSQL["MandateType"].ToString());
                    lvList.Items.AddRange(new ListViewItem[] { LvItems });
                }
                cmSQL.Connection.Close();
                cmSQL.Dispose();
                drSQL.Close();
                cnSQL.Close();
                cnSQL.Dispose();
              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           }

        private void FrmMandate_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Parse("01-Jan-" + (DateTime.Now.Year).ToString());
            dtpEndDate.Value = DateTime.Parse("31-Dec-" + (DateTime.Now.Year).ToString());
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            listOfMandates();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            listOfMandates();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            FrmSearch ChildForm = new FrmSearch();
            //ChildForm.MdiParent = FrmStart
            ChildForm.ShowDialog();
        }

        private void lvList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                String value = "";
                if (MyModules.InputBox("Checking Access", "Enter password:", ref value, true) == DialogResult.OK)
                {
                    if (value != "admin.")
                    {
                        MessageBox.Show("Invalid Password!!!", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }


                }
                else
                    return;

                ListView.SelectedListViewItemCollection SLV = lvList.SelectedItems;
                foreach (ListViewItem item in SLV)
                {
                    

               if (MessageBox.Show("Mandate: " + item.Text + " would be deleted....continue(y/n)?", MyModules.strApptitle, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)

                        return;

                    SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                    SqlCommand cmSQL = new SqlCommand();
                    cmSQL.Connection = cnSQL;
                    cnSQL.Open();
                  
                    if (item.SubItems[5].Text.ToString().ToUpper() == "MAIN")
                    {
                        cmSQL.Parameters.Clear();
                        cmSQL.CommandText = "Delete FROM Payment WHERE MandateNo='" + item.Text + "'";
                        cmSQL.CommandType = CommandType.Text;
                        cmSQL.ExecuteNonQuery();
                    }
                    else
                    {
                        cmSQL.Parameters.Clear();
                        cmSQL.CommandText = "Delete FROM PaymentDeductions WHERE MandateNo='" + item.Text + "'";
                        cmSQL.CommandType = CommandType.Text;
                        cmSQL.ExecuteNonQuery();
                    }
                    cnSQL.Close();
                    MessageBox.Show("Delete Successfull!", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listOfMandates();

                }
            }
            catch
            { }

        }

        private void mnuExport_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection SLV = lvList.SelectedItems;
            foreach (ListViewItem item in SLV)
            {
                FrmPayment.export2excel(item.Text);
            }
        }
    }
}
