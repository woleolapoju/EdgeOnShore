using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Edge
{

    public partial class FrmPayDeduction : Form
    {
        string oAction = "";
        String LastMandateNo = "";
        bool DGVhasChanged = false;
        private String MandateNo;
        int dIndex = -1;
        int ReturnCode;
        string strQryMain = "";

        public FrmPayDeduction(string dAction, String MandateNo1, int dIndex1)
        {
            InitializeComponent();
            MandateNo = "";
            MandateNo = MandateNo1;
            dIndex = dIndex1;
            oAction = dAction;
            //if (string.IsNullOrEmpty(MandateNo))
            //    chkSaveAsNew.Visible = false;
            //else
            //    chkSaveAsNew.Visible = true;
        }

        private void FrmPayDeduction_Load(object sender, EventArgs e)
        {

            switch (oAction)
            {
                case "WHT":
                    //panWHT.Visible = true;
                    //panVAT.Visible = false;
                    //panStamp.Visible = false;
                    
                    lblAction.Tag = "WHT";
                    lblAction.Text = "WHT Transactions";
                    break;
                case "VAT":
                    //panWHT.Visible = false;
                    //panVAT.Visible = true;
                    //panStamp.Visible = false;

                    lblAction.Tag = "VAT";
                    lblAction.Text = "VAT Transactions";
                    break;
                case "Stamp":
                    //panWHT.Visible = false;
                    //panVAT.Visible = false;
                    //panStamp.Visible = true;

                    lblAction.Tag = "Stamp";
                    lblAction.Text = "Stamp Transactions";
                    break;
            }

            LoadInterventionLine();
            cmdBeneficiary.Text = "VENDOR";
            MyModules.applyGridTheme(DGridList);
            DGridList.AllowUserToDeleteRows = true;

            tMandateNo.Tag = 0;
            if (!string.IsNullOrEmpty(Convert.ToString(MandateNo).Trim(' ')))
            {
                oLoadPayments(MandateNo);
                // lnkSuggest.Visible = true;
                lnkSuggest.Enabled = false;
                if (dIndex != -1)
                {
                    DGridList.Rows[dIndex - 1].Selected = true;
                    DGridList.FirstDisplayedScrollingRowIndex = DGridList.CurrentRow.Index;
                }
            }
            else
            {
                DGVhasChanged = false;

                tMandateNo.Text = MandateNo;

            }

            LoadTV();
            
           DGridList.Columns["RefNo"].Width = 5;
            DGridList.Columns["Sn"].Width = 40;
            DGridList.Columns["tName"].Width = 120;
            DGridList.Columns["Amount"].Width = 100;
            DGridList.Columns["PVNo"].Width = 100;
            DGridList.Columns["TINNo"].Width = 100;
            DGridList.Columns["PaymentDetails"].Width = 200;
            DGridList.Columns["Source"].Width = 2;
            DGridList.Columns["Source_Mandate"].Width = 100;
            DGridList.Columns["Source_Index"].Width = 100;
            DGridList.Columns["Remark"].Width = 2;
            DGridList.Columns["MainAction"].Width = 2;
            DGridList.Columns["Rate"].Width = 40;
            DGridList.Columns["InvoiceNo"].Width = 80;
            DGridList.Columns["ContractAmt"].Width = 100;
            DGridList.Columns["ContractType"].Width = 100;
            




        }

        private void LoadTV()
        {
            try
            {
                TVList.Nodes.Clear();
                lvList.Items.Clear();

                string str = "";
                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;
                SqlDataReader drSQL;


                if (cmdBeneficiary.Text == "VENDOR")
                    str = "Select DISTINCT MandateNo FROM Payment WHERE Source= 'VENDOR' AND MandateNo + CAST(dIndex as nvarchar(50)) NOT IN ( SELECT Source_MandateNo+ CAST(Source_dIndex as nvarchar(50)) FROM PaymentDeductions WHERE MainAction='" + lblAction.Tag + "') ";

                if (cmdBeneficiary.Text == "SCHOOL")
                    str = "Select DISTINCT MandateNo FROM Payment WHERE Source= 'SCHOOL' AND MandateNo + CAST(dIndex as nvarchar(50)) NOT IN ( SELECT Source_MandateNo+ CAST(Source_dIndex as nvarchar(50)) FROM PaymentDeductions WHERE MainAction='" + lblAction.Tag + "') ";

                if (cmdBeneficiary.Text == "STAFF")
                    str = "Select DISTINCT MandateNo FROM Payment WHERE Source= 'STAFF' AND MandateNo + CAST(dIndex as nvarchar(50)) NOT IN ( SELECT Source_MandateNo+ CAST(Source_dIndex as nvarchar(50)) FROM PaymentDeductions WHERE MainAction='" + lblAction.Tag + "') ";

               cmSQL.CommandText = str;
                cmSQL.CommandType = CommandType.Text;
                cnSQL.Open();
                drSQL = cmSQL.ExecuteReader();

                TVList.BeginUpdate();
                TVList.Nodes.Add("ALL", "ALL").ForeColor = Color.Red;
                while (drSQL.Read())
                {
                    if (Convert.IsDBNull(drSQL[0]) == false)
                    {
                        TVList.Nodes.Add(drSQL[0].ToString());
                    }
                   
                }

                TVList.EndUpdate();
                //cmSQL.Connection.Close()
                cmSQL.Dispose();
                drSQL.Close();
                cnSQL.Close();
                cnSQL.Dispose();

                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void cmdBeneficiary_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTV();
        }

        private void btnWHT_Click(object sender, EventArgs e)
        {
            lblAction.Tag = "WHT";
            lblAction.Text = "WHT Transactions";
            LoadTV();
        }

        private void btnVAT_Click(object sender, EventArgs e)
        {
            lblAction.Tag = "VAT";
            lblAction.Text = "VAT Transactions";
            LoadTV();
        }

        private void btnStamp_Click(object sender, EventArgs e)
        {
            lblAction.Tag = "Stamp";
            lblAction.Text = "STAMP DUTY Transactions";
            LoadTV();
        }


        public void LoadLvList(string strMandateNo)
        {
            string str = "";
            if (strMandateNo == "" || strMandateNo == null)
                return;
            try
            {
                //  strQryMain = strQ;


                if (cmdBeneficiary.Text == "SCHOOL")
                {
                    if (strMandateNo == "<ALL>")
                    {
                        str = "Select Payment.*,'' AS TINNo, RegisterSchool.SchAddress AS Address FROM Payment LEFT OUTER JOIN RegisterSchool ON Payment.Name = RegisterSchool.SchName AND Payment.RefNo = RegisterSchool.Sn WHERE Payment.Source= 'SCHOOL' AND MandateNo + CAST(dIndex as nvarchar(50)) NOT IN (SELECT Source_MandateNo+ CAST(Source_dIndex as nvarchar(50)) FROM PaymentDeductions WHERE MainAction='" + lblAction.Tag + "') ORDER BY MandateNo,dIndex";
                    }
                    else
                    {
                        str = "Select Payment.*,'' AS TINNo, RegisterSchool.SchAddress AS Address FROM Payment LEFT OUTER JOIN RegisterSchool ON Payment.Name = RegisterSchool.SchName AND Payment.RefNo = RegisterSchool.Sn WHERE Payment.Source= 'SCHOOL' AND MandateNo='" + strMandateNo + "' AND MandateNo + CAST(dIndex as nvarchar(50)) NOT IN (SELECT Source_MandateNo+ CAST(Source_dIndex as nvarchar(50)) FROM PaymentDeductions WHERE MainAction='" + lblAction.Tag + "') ORDER BY MandateNo,dIndex";

                    }
                }
                if (cmdBeneficiary.Text == "VENDOR")
                {

                    if (strMandateNo == "<ALL>")
                    {
                        str = "Select Payment.*,RegisterVendor.TINNo, RegisterVendor.Address FROM Payment LEFT OUTER JOIN RegisterVendor ON Payment.Name = RegisterVendor.Name AND Payment.RefNo = RegisterVendor.Sn WHERE Payment.Source= 'VENDOR' AND MandateNo + CAST(dIndex as nvarchar(50)) NOT IN (SELECT Source_MandateNo+ CAST(Source_dIndex as nvarchar(50)) FROM PaymentDeductions WHERE MainAction='" + lblAction.Tag + "') ORDER BY MandateNo,dIndex";
                    }
                    else
                    {
                        str = "Select Payment.*,RegisterVendor.TINNo, RegisterVendor.Address FROM Payment LEFT OUTER JOIN RegisterVendor ON Payment.Name = RegisterVendor.Name AND Payment.RefNo = RegisterVendor.Sn WHERE Payment.Source= 'VENDOR' AND MandateNo='" + strMandateNo + "' AND MandateNo + CAST(dIndex as nvarchar(50)) NOT IN (SELECT Source_MandateNo+ CAST(Source_dIndex as nvarchar(50)) FROM PaymentDeductions WHERE MainAction='" + lblAction.Tag + "') ORDER BY MandateNo,dIndex";

                    }

                    
                }
                if (cmdBeneficiary.Text == "STAFF")
                {

                    if (strMandateNo == "<ALL>")
                    {
                        str = "Select Payment.*,RegisterVendor.TINNo, RegisterVendor.Address FROM Payment LEFT OUTER JOIN RegisterVendor ON Payment.Name = RegisterVendor.Name AND Payment.RefNo = RegisterVendor.Sn WHERE Payment.Source= 'STAFF' AND MandateNo + CAST(dIndex as nvarchar(50)) NOT IN (SELECT Source_MandateNo+ CAST(Source_dIndex as nvarchar(50)) FROM PaymentDeductions WHERE MainAction='" + lblAction.Tag + "') ORDER BY MandateNo,dIndex";
                    }
                    else
                    {
                        str = "Select Payment.*,RegisterVendor.TINNo, RegisterVendor.Address FROM Payment LEFT OUTER JOIN RegisterVendor ON Payment.Name = RegisterVendor.Name AND Payment.RefNo = RegisterVendor.Sn WHERE Payment.Source= 'STAFF' AND MandateNo='" + strMandateNo + "' AND MandateNo + CAST(dIndex as nvarchar(50)) NOT IN (SELECT Source_MandateNo+ CAST(Source_dIndex as nvarchar(50)) FROM PaymentDeductions WHERE MainAction='" + lblAction.Tag + "') ORDER BY MandateNo,dIndex";

                    }
                }

                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                SqlDataReader drSQL;
                cmSQL.Connection = cnSQL;
                cmSQL.CommandType = CommandType.Text;
                cmSQL.CommandText = str;


                cnSQL.Open();


                lvList.Items.Clear();
                chkAll.Checked = false;

                drSQL = cmSQL.ExecuteReader();

                //  long j = 0;
                string initialText;
                while (drSQL.Read())
                {
                    //  j += 1

                 

                        initialText = drSQL["MandateNo"].ToString();
                    ListViewItem LvItems = new ListViewItem(initialText);
                    LvItems.SubItems.Add(drSQL["dIndex"].ToString());
                    LvItems.SubItems.Add(drSQL["RefNo"].ToString());
                    LvItems.SubItems.Add(drSQL["Name"].ToString());
                    LvItems.SubItems.Add(Convert.ToDouble(drSQL["Amount"]).ToString("##,#.##"));
                    LvItems.SubItems.Add(drSQL["PayDetails"].ToString());
                    LvItems.SubItems.Add(drSQL["PVNo"].ToString());
                    LvItems.SubItems.Add(drSQL["TinNo"].ToString());
                    LvItems.SubItems.Add(drSQL["Address"].ToString());
                    LvItems.SubItems.Add(drSQL["Source"].ToString());
                    LvItems.SubItems.Add(lblAction.Tag.ToString());
                    
                    LvItems.SubItems.Add(cmdBeneficiary.Text);

                    lvList.Items.AddRange(new ListViewItem[] { LvItems });
                }

              
                cmSQL.Dispose();
                drSQL.Close();
                cnSQL.Close();
                cnSQL.Dispose();


                lblListCount.Text = "List Count:" + lvList.Items.Count.ToString();


                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string strQry = "";
            if (e.Node.Text == "ALL")
            {
                strQry = "<ALL>";
            }
            else
            {
                strQry = e.Node.Text;
            }
            strQryMain = strQry;
            LoadLvList(strQry);
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            int i = 0;
            for (i = 0; i < lvList.Items.Count; i++)
            {
                lvList.Items[i].Checked = chkAll.Checked;
            }
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            int i = 0;
            int j = DGridList.Rows.Count - 1;
            int g = 0;
            double estimateAmt = 0;
            for (i = 0; i < lvList.Items.Count; i++)
            {
                if (lvList.Items[i].Checked)
                {

                    if (CheckIfExist(lvList.Items[i].SubItems[9].Text, lvList.Items[i].Text,Convert.ToInt16(lvList.Items[i].SubItems[1].Text)) == true)
                    {
                       MessageBox.Show("Record [" + (i+1).ToString() + "] already added ", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return;
                    }
                    estimateAmt = 0;
                    if (lblAction.Tag.ToString()=="WHT")
                        estimateAmt = (105 * Convert.ToDouble(lvList.Items[i].SubItems[4].Text) / 90) * Convert.ToDouble(tWHT.Text) / 105;
                    if (lblAction.Tag.ToString() == "VAT")
                        estimateAmt = (105 * Convert.ToDouble(lvList.Items[i].SubItems[4].Text) / 90) * Convert.ToDouble(tVAT.Text) / 105;
                    if (lblAction.Tag.ToString() == "Stamp")
                        estimateAmt = (105 * Convert.ToDouble(lvList.Items[i].SubItems[4].Text) / 90) * Convert.ToDouble(tStamp.Text) / 105;

                    DGridList.Rows.Add();
                    g = DGridList.RowCount;
                    j = g - 1;
                    DGridList["RefNo", j].Value = lvList.Items[i].SubItems[2].Text;
                    DGridList["Sn", j].Value = g;
                    DGridList["tName", j].Value = lvList.Items[i].SubItems[3].Text;
                    DGridList["Amount", j].Value = estimateAmt.ToString("##,###.##") ; //Amount
                    DGridList["PVNo", j].Value = lvList.Items[i].SubItems[6].Text;
                    DGridList["Net_Amount", j].Value = lvList.Items[i].SubItems[4].Text;
                    DGridList["PaymentDetails", j].Value = lvList.Items[i].SubItems[5].Text;
                    DGridList["Source_Mandate", j].Value = lvList.Items[i].Text;
                    DGridList["Source_Index", j].Value =  lvList.Items[i].SubItems[1].Text;
                    DGridList["Source", j].Value = lvList.Items[i].SubItems[9].Text;
                    DGridList["TINNo", j].Value = lvList.Items[i].SubItems[7].Text;
                    DGridList["MainAction", j].Value = lvList.Items[i].SubItems[10].Text;
                    DGridList["Address", j].Value = lvList.Items[i].SubItems[8].Text;
                    DGridList["ContractDate", j].Value = MyModules.FormatDate(DateTime.Now);
                    DGridList["ContractAmt", j].Value = "0";
                    DGridList["ContractType", j].Value = "";
                    
                    if (lblAction.Tag.ToString()=="WHT" )  DGridList["Rate", j].Value = tWHT.Text;
                    if (lblAction.Tag.ToString() == "VAT") DGridList["Rate", j].Value = tVAT.Text;
                    if (lblAction.Tag.ToString() == "Stamp") DGridList["Rate", j].Value = tStamp.Text;

                    DGridList["Remark", j].Value = "";
                }
            }
            
            // Dim i As Integer = 0
            for (i = 0; i < lvList.Items.Count; i++)
            {
                lvList.Items[i].Checked = false;
            }
            chkAll.Checked = false;
            calculateTotal();
            lblCount.Text = "Payment Count:" + DGridList.Rows.Count.ToString(); //GetCount() + 1

            DGridList.CurrentCell = DGridList.Rows[0].Cells["Amount"];
            DGridList.Focus();
        }


        public bool CheckIfExist(string TheSource, string dMandate, int TheRefNo)
        {
            bool tempCheckIfExist = false;
            try
            {
                tempCheckIfExist = false;
                int d = 0;
                // If TheSource = "STUDENT" Then
                for (d = 0; d < DGridList.RowCount; d++)
                {
                    if (DGridList["Source", d].Value.ToString() == TheSource && DGridList["Source_Mandate", d].Value.ToString() == dMandate && TheRefNo == Convert.ToInt16(DGridList["Source_Index", d].Value))
                    {
                        return true;
                    }
                }

                return tempCheckIfExist;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return tempCheckIfExist;
            }
        }

        private void mnuCopyAmount_Click(object sender, EventArgs e)
        {
            int h = 0;
            int dRow = Convert.ToInt32(DGridList.Tag);
            for (h = 0; h < DGridList.Rows.Count; h++)
            {
                if (Convert.ToDouble(DGridList.Rows[dRow].Cells["Amount"].Value) != 0 && Convert.ToDouble(DGridList.Rows[h].Cells["Amount"].Value) == 0) //Amount
                {
                    if (Convert.ToDouble(DGridList.Rows[h].Cells["Amount"].Value) == 0)
                    {
                        DGridList.Rows[h].Cells["Amount"].Value = DGridList.Rows[dRow].Cells["Amount"].Value;
                    }
                }
            }
            calculateTotal();
        }

        private void mnuPNVo_Click(object sender, EventArgs e)
        {
            int h = 0;
            int dRow = Convert.ToInt32(DGridList.Tag);
            for (h = 0; h < DGridList.Rows.Count; h++)
            {
                if (DGridList.Rows[dRow].Cells["PVNo"].Value.ToString() != "" && Convert.ToInt16(DGridList.Rows[h].Cells["Sn"].Value) > 0) //PVNo
                {
                    if (MyModules.ChkNull(DGridList.Rows[h].Cells["PVNo"].Value) == "")
                    {
                        DGridList.Rows[h].Cells["PVNo"].Value = DGridList.Rows[dRow].Cells["PVNo"].Value;
                    }

                }
            }
        }
        private void DGridList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DGridList.Tag = e.RowIndex;
        }

        private void DGridList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DGridList.Columns[e.ColumnIndex].Name == "Amount")
                {
                    if (Microsoft.VisualBasic.Information.IsNumeric(DGridList["Amount", e.RowIndex].Value) == false)
                    {
                        MessageBox.Show("Invalid entry...number expected", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DGridList["Amount", e.RowIndex].Value = 0;
                    }
                    else
                    {
                        DGridList["Amount", e.RowIndex].Value = Convert.ToDouble(DGridList["Amount", e.RowIndex].Value, System.Globalization.CultureInfo.InvariantCulture);
                        calculateTotal();
                    }

                }


                
  if (DGridList.Columns[e.ColumnIndex].Name == "ContractDate")
                {
                    if (Microsoft.VisualBasic.Information.IsDate(DGridList["ContractDate", e.RowIndex].Value) == false)
                    {
                        MessageBox.Show("Invalid Date entry", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DGridList["ContractDate", e.RowIndex].Value = MyModules.FormatDate(DateTime.Now);
                    }


                }

                if (DGridList.Columns[e.ColumnIndex].Name == "Rate")
                {
                    if (Microsoft.VisualBasic.Information.IsNumeric(DGridList["Rate", e.RowIndex].Value) == false)
                    {
                        MessageBox.Show("Invalid entry...number expected", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DGridList["Rate", e.RowIndex].Value = 0;
                    }
                    else
                    {
                        double estimateAmt = (105 * Convert.ToDouble(DGridList["Net_Amount", e.RowIndex].Value) / 90) * Convert.ToDouble(DGridList["Rate", e.RowIndex].Value) / 105;
                        DGridList["Amount", e.RowIndex].Value = Convert.ToDouble(estimateAmt, System.Globalization.CultureInfo.InvariantCulture);
                        calculateTotal();
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DGridList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Context == DataGridViewDataErrorContexts.Commit)
            {
                DGridList.Rows[e.RowIndex].ErrorText = e.Exception.ToString();
                e.Cancel = true;
            }
        }

        private void calculateTotal()
        {
            try
            {
                int h = 0;
                double sum = 0;
                for (h = 0; h < DGridList.Rows.Count; h++)
                {
                    sum = sum + Convert.ToDouble(DGridList["Amount", h].Value);

                }
                tTotal.Text = sum.ToString("##,#.##");

            }
            catch
            {
            }
        }

        private void DGridList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DGridList.Tag = e.RowIndex;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            DGridList.Rows.Clear();
            tMandateNo.Text = "";
            tTotal.Text = "0";
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            SqlTransaction myTrans = null; //= new SqlTransaction;
            SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
            SqlCommand cmSQL = new SqlCommand(); // cnSQL.CreateCommand;
            cmSQL.Connection = cnSQL;
            try
            {


                // SqlDataReader drSQL = null;
                // string NewMandateNo = "";

                if (string.IsNullOrEmpty(tMandateNo.Text.Trim(' ')))
                {
                    MessageBox.Show("Pls. enter Mandate No", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //if (chkSaveAsNew.Visible && chkSaveAsNew.Checked)
                //{
                //    if (tMandateNo.Text.Trim(' ') == MandateNo.Trim(' '))
                //    {
                //        MessageBox.Show("New MandateNo cannot be the same as the MandateNo it is generated from", MyModules.strApptitle);
                //        return;
                //    }
                //}

                if (CheckPayments(tMandateNo.Text) == true)
                {
                    if (MessageBox.Show("Records already exist for this Mandate No...Continue (y/n)?" + "\r" + "\n" + "If you choose to Continue, the previous would be overwritten", MyModules.strApptitle, MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                    {
                        return;
                    }
                }


                int i = 0;

                if (DGridList.Rows.Count > 0)
                {
                    for (i = 0; i < DGridList.Rows.Count; i++)
                    {
                        if (string.IsNullOrEmpty(DGridList["TINNo", i].Value.ToString().Trim(' ')))
                        {
                            MessageBox.Show("TIN Number not specified", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        //if ((DGridList["WHTAmt", i].Value == null || Convert.ToDouble(DGridList["WHTAmt", i].Value) == 0) && (DGridList["VATAmt", i].Value == null || Convert.ToDouble(DGridList["VATAmt", i].Value) == 0) && (DGridList["StampAmt", i].Value == null || Convert.ToDouble(DGridList["StampAmt", i].Value) == 0))     
                        //{
                        //    MessageBox.Show("Amount is required", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    return;
                        //}
                    }
                }

                cnSQL.Open();

                myTrans = cnSQL.BeginTransaction(IsolationLevel.Serializable);
                cmSQL.Transaction = myTrans;

                //if (chkSaveAsNew.Visible && chkSaveAsNew.Checked)
                //{
                //}
                //else
                //{
                    cmSQL.Parameters.Clear();
                    cmSQL.CommandText = "DeletePaymentDeductions";
                    cmSQL.CommandType = CommandType.StoredProcedure;
                    cmSQL.Parameters.AddWithValue("@MandateNo", MandateNo); // tMandateNo.Text);
                    cmSQL.ExecuteNonQuery();
                //}
            //    MessageBox.Show(MandateNo);

                int g = 0;
                for (i = 0; i < DGridList.Rows.Count; i++)
                {

                    if (DGridList["Amount", i].Value == null || Convert.ToDouble(DGridList["Amount", i].Value) == 0)
                    {
                    }
                    else
                    {
                        g = g + 1;
                        cmSQL.Parameters.Clear();
                        cmSQL.CommandText = "InsertPaymentDeductions";
                        cmSQL.CommandType = CommandType.StoredProcedure;
                        cmSQL.Parameters.AddWithValue("@PayValueDate",MyModules.FormatDate(dtpDate.Value));
                        cmSQL.Parameters.AddWithValue("@RefNo",((DGridList["RefNo", i].Value == null) ? "0" : DGridList["RefNo", i].Value));
                        cmSQL.Parameters.AddWithValue("@Name",((DGridList["tName", i].Value == null) ? "" : DGridList["tName", i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@PayDetails",((DGridList["PaymentDetails", i].Value == null) ? "" : DGridList["PaymentDetails", i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@PVNo", ((DGridList["PVNo", i].Value == null) ? "" : DGridList["PVNo", i].Value));
                        cmSQL.Parameters.AddWithValue("@Source_MandateNo", ((DGridList["Source_Mandate", i].Value == null) ? "" : DGridList["Source_Mandate", i].Value));
                        cmSQL.Parameters.AddWithValue("@Source_dIndex", ((DGridList["Source_Index", i].Value == null) ? "" : DGridList["Source_Index", i].Value));
                        cmSQL.Parameters.AddWithValue("@Source",((DGridList["Source", i].Value == null) ? "" : DGridList["Source", i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@Remark",((DGridList["Remark", i].Value == null) ? "" : DGridList["Remark", i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@Amount",((DGridList["Amount", i].Value == null) ? 0 : Convert.ToDouble(DGridList["Amount", i].Value)));
                        cmSQL.Parameters.AddWithValue("@dIndex",((DGridList["Sn", i].Value == null) ? "0" : DGridList["Sn", i].Value)); //g);
                        cmSQL.Parameters.AddWithValue("@MandateNo", tMandateNo.Text.ToUpper());
                        cmSQL.Parameters.AddWithValue("@Username", MyModules.sysUser);
                        cmSQL.Parameters.AddWithValue("@MainAction", ((DGridList["MainAction", i].Value == null) ? " " : DGridList["MainAction", i].Value));
                        cmSQL.Parameters.AddWithValue("@TINNo", ((DGridList["TINNo", i].Value == null) ? " " : DGridList["TINNo", i].Value));
                        cmSQL.Parameters.AddWithValue("@Address", ((DGridList["Address", i].Value == null) ? "" : DGridList["Address", i].Value));
                        cmSQL.Parameters.AddWithValue("@InvoiceNo", ((DGridList["InvoiceNo", i].Value == null) ? "" : DGridList["InvoiceNo", i].Value));
                        cmSQL.Parameters.AddWithValue("@ContractDate", ((DGridList["ContractDate", i].Value == null) ? MyModules.FormatDate(DateTime.Now) : DGridList["ContractDate", i].Value));
                        cmSQL.Parameters.AddWithValue("@ContractAmount", ((DGridList["ContractAmt", i].Value == null) ? 0 : DGridList["ContractAmt", i].Value));
                        cmSQL.Parameters.AddWithValue("@Rate", ((DGridList["Rate", i].Value == null) ? 0 : DGridList["Rate", i].Value));
                        cmSQL.Parameters.AddWithValue("@ContractType", ((DGridList["ContractType", i].Value == null) ? "" : DGridList["ContractType", i].Value));
                        cmSQL.Parameters.AddWithValue("@InterventionLine", cboInterLine.Text);
                        cmSQL.ExecuteNonQuery();
                    }
                }

                myTrans.Commit();

                cmSQL.Connection.Close();
                cmSQL.Dispose();
                cnSQL.Close();
                cnSQL.Dispose();
                if (g == 0)
                {
                    MessageBox.Show("No Record Saved", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                    LoadTV();


                DGVhasChanged = false;

                LastMandateNo = tMandateNo.Text;

                MessageBox.Show("Successful", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);


            }

            catch (Exception ex)

            {

                if (ex.Message.Contains("Violation of PRIMARY KEY constraint"))
                {

                    DialogResult response = MessageBox.Show("Records not well serialises...should I auto generate? (Yes/No)", string.Empty, MessageBoxButtons.YesNo);
                    if (response == DialogResult.Yes)
                    {
                        if (myTrans != null)
                            myTrans.Rollback();
                        for (int h = 0; h < DGridList.Rows.Count; h++)
                        {
                            DGridList["Sn", h].Value = h + 1;
                        }
                        cmdSave_Click(sender, e);
                    }
                    else
                    {
                        myTrans.Rollback();
                    }
                }
                else
                    MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }


        private bool CheckPayments(string MandateNo)
        {
            bool tempCheckPayments = false;
            try
            {

                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;
                SqlDataReader drSQL = null;
                cnSQL.Open();

                cmSQL.CommandText = "Fetch4PaymentMandateNoCheck";
                cmSQL.CommandType = CommandType.StoredProcedure;
                cmSQL.Parameters.AddWithValue("@MandateNo", MandateNo);
                drSQL = cmSQL.ExecuteReader();

                tempCheckPayments = drSQL.HasRows;

                drSQL.Close();

                cmSQL.Connection.Close();
                cmSQL.Dispose();
                cnSQL.Close();
                cnSQL.Dispose();

                return tempCheckPayments;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return tempCheckPayments;
            }
        }


        private void oLoadPayments(string MandateNo)
        {
            try
            {

                DGridList.Rows.Clear();

                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;
                SqlDataReader drSQL = null;
                cnSQL.Open();
                int j = 0;

                LastMandateNo = MandateNo;

                cmSQL.CommandText = "FetchPaymentDeduction";
                cmSQL.CommandType = CommandType.StoredProcedure;
                cmSQL.Parameters.AddWithValue("@MandateNo", MandateNo);
                drSQL = cmSQL.ExecuteReader();

                while (drSQL.Read())
                {
                    DGridList.Rows.Add();
                 
                    DGridList["RefNo", j].Value = drSQL["RefNo"];
                    DGridList["Sn", j].Value = drSQL["dIndex"];
                    DGridList["tName", j].Value = drSQL["Name"];
                    DGridList["Amount", j].Value = Convert.ToDouble(drSQL["Amount"], System.Globalization.CultureInfo.InvariantCulture);
                    DGridList["PVNo", j].Value = MyModules.ChkNull(drSQL["PVNo"]);
                    DGridList["Net_Amount", j].Value = 0;
                    DGridList["PaymentDetails", j].Value =  drSQL["PayDetails"];
                    DGridList["Source_Mandate", j].Value = drSQL["Source_MandateNo"];
                    DGridList["Source_Index", j].Value = drSQL["Source_dIndex"];
                    DGridList["Source", j].Value = drSQL["Source"];
                    DGridList["TINNo", j].Value = drSQL["TINNo"];
                    DGridList["MainAction", j].Value = drSQL["MainAction"];

                    DGridList["Address", j].Value = drSQL["Address"];
                    DGridList["InvoiceNo", j].Value = drSQL["InvoiceNo"];
                    DGridList["ContractDate", j].Value = drSQL["ContractDate"];
                    DGridList["ContractAmt", j].Value = drSQL["ContractAmount"];
                    DGridList["Rate", j].Value = drSQL["Rate"];
                    DGridList["ContractType", j].Value = drSQL["ContractType"];
                    
                    DGridList["Remark", j].Value = MyModules.ChkNull(drSQL["Remark"]);
                    
                    j = j + 1;
                    dtpDate.Value = Convert.ToDateTime(drSQL["PayValueDate"]);
                    tMandateNo.Text = MandateNo;
                    cboInterLine.Text = drSQL["InterventionLine"].ToString();
                }

                drSQL.Close();

                cmSQL.Connection.Close();
                cmSQL.Dispose();
                cnSQL.Close();
                cnSQL.Dispose();

               lblCount.Text = "Payment Count:" + DGridList.Rows.Count.ToString(); //GetCount() + 1
                dtpDate.Focus();


                calculateTotal();
                try
                {
                    DGridList.CurrentCell = DGridList.Rows[0].Cells["Amount"];
                    DGridList.Focus();
                }
                catch { }

                DGVhasChanged = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void DGridList_CellValueChanged(Object sender, DataGridViewCellEventArgs e)
        {
            DGVhasChanged = true;
        }

        private void DGridList_CurrentCellDirtyStateChanged(Object sender, EventArgs e)
        {
            DGVhasChanged = true;
        }

        private void FrmPayDeduction_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DGVhasChanged == true)
            {
                DialogResult response = MessageBox.Show("Do you want to save the changes?", string.Empty, MessageBoxButtons.YesNo);
                if (response == DialogResult.Yes)
                {
                    cmdSave_Click(sender, e);
                    e.Cancel = true;
                    DGVhasChanged = false;
                }
            }
        }

        private void lnkCleanMandate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CleanList();
        }

        public void CleanList()
        {
            try
            {

                // DGridList.Enabled = False
                DataGridViewCellStyle myStyle = new DataGridViewCellStyle();
                myStyle.BackColor = Color.Yellow;
                myStyle.ForeColor = Color.Red;

                int i = 0;
                int j = 0;
                for (i = 0; i < DGridList.RowCount; i++)
                {
                    for (j = 0; j < DGridList.Columns.Count; j++)
                    {
                        DGridList[j, i].Value = Convert.ToString(DGridList[j, i].Value).Trim(' ');
                        if (Microsoft.VisualBasic.Strings.Len(DGridList[j, i].Value) > 0)
                        {
                            if (Microsoft.VisualBasic.Strings.Asc(Microsoft.VisualBasic.Strings.Mid(DGridList[j, i].Value.ToString(), 1)) < 32 || Microsoft.VisualBasic.Strings.Asc(Microsoft.VisualBasic.Strings.Mid(DGridList[j, i].Value.ToString(), 1)) > 126)
                            {
                                DGridList[j, i].Value = Microsoft.VisualBasic.Strings.Mid(DGridList[j, i].Value.ToString(), 2);
                                DGridList[j, i].Style = myStyle;
                                //DGridList.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                            }

                            if (Microsoft.VisualBasic.Strings.Asc(Microsoft.VisualBasic.Strings.Right(DGridList[j, i].Value.ToString(), 1)) < 32 || Microsoft.VisualBasic.Strings.Asc(Microsoft.VisualBasic.Strings.Right(DGridList[j, i].Value.ToString(), 1)) > 126)
                            {
                                DGridList[j, i].Value = Microsoft.VisualBasic.Strings.Mid(DGridList[j, i].Value.ToString(), 1, Microsoft.VisualBasic.Strings.Len(DGridList[j, i].Value) - 1);
                                DGridList[j, i].Style = myStyle;
                            }

                        }
                    }
                }




            }
            catch (Exception ex)
            {
                if (Microsoft.VisualBasic.Information.Err().Number == 5 || Microsoft.VisualBasic.Information.Err().Number == 13)
                {
                    return;
                }
                else
                {
                    MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void lnkPrintMandateNo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            {
                if (tMandateNo.Text != "" && tTotal.Text != "")
                {
                    FrmMandateRpt childform = new FrmMandateRpt();
                    childform.TheMandateNo = tMandateNo.Text;
                    childform.dAmount = tTotal.Text;
                    childform.MainAction = lblAction.Tag.ToString();
                    childform.ShowDialog();
                }
                else
                    MessageBox.Show("Pls. choose a mandate", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }

        private void lnkExport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            { 
            string filename = "";
            string dPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            
                if (lblAction.Tag.ToString() == "VAT")
                {
                    filename = dPath + "\\RemitalMandateVAT_" + tMandateNo.Text + ".csv";
                    if (tMandateNo.Text.Contains("\\") || (tMandateNo.Text.Contains("/"))) filename = dPath + "\\RemitalMandateVAT_" + ".csv";
                }

                if (lblAction.Tag.ToString() == "WHT")
                {
                    filename = dPath + "\\RemitalMandateWHT_" + tMandateNo.Text + ".csv";
                    if (tMandateNo.Text.Contains("\\") || (tMandateNo.Text.Contains("/"))) filename = dPath + "\\RemitalMandateWHT_" + ".csv";
                }

                if (lblAction.Tag.ToString() == "Stamp")
                {
                    filename = dPath + "\\RemitalMandateStamp_" + tMandateNo.Text + ".csv";
                    if (tMandateNo.Text.Contains("\\") || (tMandateNo.Text.Contains("/"))) filename = dPath + "\\RemitalMandateStamp_" + ".csv";
                }



                 SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;
                SqlDataReader drSQL = null;


            

                cnSQL.Open();



                //  System.IO.File.Delete(filename);

        
            if (File.Exists(filename))
                {
                    File.Delete(filename);
                }

                System.IO.StreamWriter objWriter = new System.IO.StreamWriter(filename, true, System.Text.Encoding.UTF8);

                //-------Dummy record not to be posted-----------
                if (File.Exists(filename))
                {
                    objWriter.Write("TINNo,");
                    objWriter.Write("BeneficiaryName,");
                    objWriter.Write("Address,");
                    objWriter.Write("InvoiceNo,");
                    objWriter.Write("ContractDate,");
                    objWriter.Write("ContractDesc,");
                    objWriter.Write("ContractAmount,");
                    objWriter.Write("ContractType,");
                    objWriter.Write("Rate,");
                    objWriter.Write("Amount,");
                    objWriter.Write("TaxAuthority");
                   
                    objWriter.Write(Environment.NewLine);
                }
                //--------- End dummy record ---------

                cmSQL.CommandText = "FetchPaymentDeduction";
                cmSQL.CommandType = CommandType.StoredProcedure;
                cmSQL.Parameters.AddWithValue("@MandateNo", MandateNo);
                drSQL = cmSQL.ExecuteReader();

                while (drSQL.Read())
                {
                    if (File.Exists(filename))
                    {

             
                        objWriter.Write(drSQL["TINNo"] + ",");
                        if (drSQL["Name"].ToString().Contains(","))
                        {
                            objWriter.Write(drSQL["Name"].ToString().Replace(",", " ") + ",");
                        }
                        else
                        {
                            objWriter.Write(drSQL["Name"] + ",");
                        }

                        if (MyModules.ChkNull(drSQL["Address"]) == "")
                        {
                            objWriter.Write(0.ToString() + ","); //Address
                        }
                        else
                        {
                            objWriter.Write(drSQL["Address"].ToString() + ","); //Address
                        }


                        if (MyModules.ChkNull(drSQL["InvoiceNo"]) == "")
                        {
                            objWriter.Write(0.ToString() + ","); 
                        }
                        else
                        {
                            objWriter.Write(drSQL["InvoiceNo"].ToString() + ","); 
                        }

                        if (MyModules.ChkNull(drSQL["ContractDate"]) == "")
                        {
                            objWriter.Write(0.ToString() + ","); 
                        }
                        else
                        {
                            string ddate = Convert.ToDateTime(drSQL["ContractDate"]).ToString("dd/MM/yyyy");
                        
                           objWriter.Write(ddate.Substring(0,2)+"/" + ddate.Substring(3, 2) +"/"+ ddate.Substring(6) + ",");

                        }

                      
                        if (MyModules.ChkNull(drSQL["PayDetails"]) == "")
                        {
                            objWriter.Write(0.ToString() + ","); 
                        }
                        else
                        {
                            objWriter.Write(drSQL["PayDetails"].ToString() + ","); 
                        }

                        objWriter.Write(drSQL["ContractAmount"] + ",");

                        if (MyModules.ChkNull(drSQL["ContractType"]) == "")
                        {
                            objWriter.Write(0.ToString() + ","); 
                        }
                        else
                        {
                            objWriter.Write(drSQL["ContractType"].ToString() + ","); 
                        }

                        objWriter.Write(drSQL["Rate"] + ",");
                        objWriter.Write(drSQL["Amount"] + ",");
                        objWriter.Write("FIR");
                        objWriter.Write(Environment.NewLine);

                    }

                }
                objWriter.Close();
                //skipit:
                drSQL.Close();

                // }

                cmSQL.Connection.Close();
                cmSQL.Dispose();
                cnSQL.Close();
                cnSQL.Dispose();


                MessageBox.Show("Export Complete.....");
                return;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void lvList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ReturnCode = Convert.ToInt16(lvList.SelectedItems[0].SubItems[2].Text);
            }
            catch
            { }
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
             switch (cmdBeneficiary.Text)
            {
                case "VENDOR":

                    if (MyModules.GetUserAccessDetails("Vendor Information") == false) return;
                    FrmVendorInfor ChildForm = new FrmVendorInfor("Edit", ReturnCode, "VENDOR");
                    ChildForm.ShowDialog();
                    break;
                case "SCHOOL":
                    if (MyModules.GetUserAccessDetails("School Information") == false) return;
                    FrmSchoolInfor childform0 = new FrmSchoolInfor("Edit", ReturnCode);
                    childform0.ShowDialog();
                    break;

                case "STUDENT":
                    if (MyModules.GetUserAccessDetails("Student Information") == false) return;
                    FrmStudentInfor childform1 = new FrmStudentInfor("Edit", ReturnCode);
                    childform1.ShowDialog();
                    break;
                case "STAFF":

                    if (MyModules.GetUserAccessDetails("Vendor Information") == false) return;
                    FrmVendorInfor ChildForm2 = new FrmVendorInfor("Edit", ReturnCode, "STAFF");
                    ChildForm2.ShowDialog();
                    break;
            }

            if (strQryMain == "") return;
            LoadLvList(strQryMain);
            tFilter.Text = "";
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            if (strQryMain == "") return;
            LoadLvList(strQryMain);
            tFilter.Text = "";
        }

        private void cmdFindtxt_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                int j = 1;
                i = lvList.Items.Count - 1;
                while (i >= 0)
                {
                    if (j == 1)
                    {
                        if (Microsoft.VisualBasic.CompilerServices.StringType.StrLike(lvList.Items[i].Text.ToLower(), ("*" + tFilter.Text + "*").ToLower(), Microsoft.VisualBasic.CompareMethod.Binary))
                        {
                            lvList.Items[i].ForeColor = Color.Red; //.Selected = True
                            lvList.Items[i].EnsureVisible();
                        }
                    }
                    else
                    {
                        if (Microsoft.VisualBasic.CompilerServices.StringType.StrLike((lvList.Items[i].SubItems[j - 1].Text).ToLower(), ("*" + tFilter.Text + "*").ToLower(), Microsoft.VisualBasic.CompareMethod.Binary))
                        {
                            lvList.Items[i].ForeColor = Color.Red;
                            lvList.Items[i].EnsureVisible();
                        }
                    }
                    i = i - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void cmdFilter_Click(object sender, EventArgs e)
        {
            filterList();
        }

        private void filterList()
        {
            try
            {
                int i = 0;
                int j = 1;
                i = lvList.Items.Count - 1;
                while (i >= 0)
                {
                    if (j == 1)
                    {
                        if (!(Microsoft.VisualBasic.CompilerServices.StringType.StrLike(lvList.Items[i].Text.ToLower(), ("*" + tFilter.Text + "*").ToLower(), Microsoft.VisualBasic.CompareMethod.Binary)))
                        {
                            lvList.Items[i].Remove();
                        }
                    }
                    else
                    {
                        if (!(Microsoft.VisualBasic.CompilerServices.StringType.StrLike((lvList.Items[i].SubItems[j - 1].Text).ToLower(), ("*" + tFilter.Text + "*").ToLower(), Microsoft.VisualBasic.CompareMethod.Binary)))
                        {
                            lvList.Items[i].Remove();
                        }
                    }
                    i = i - 1;
                }
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void lnkState_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MyModules.GetUserAccessDetails("Intervention Line") == false)
                return;
            FrmInterventionLine ChildForm = new FrmInterventionLine();
            ChildForm.ShowDialog();
            LoadInterventionLine();
        }
        private void LoadInterventionLine()

        {
            try
            {

                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;
                SqlDataReader drSQL;

                cboInterLine.Items.Clear();
                cnSQL.Open();

                cmSQL.CommandText = "SELECT DISTINCT [InterventionLine] FROM InterventionLine";
                cmSQL.CommandType = CommandType.Text;
                drSQL = cmSQL.ExecuteReader();

                while (drSQL.Read())
                {
                    cboInterLine.Items.Add(drSQL["InterventionLine"].ToString());
                }

                //cmSQL.Connection.Close()
                cmSQL.Dispose();
                drSQL.Close();
                cnSQL.Close();
                //cnSQL.Dispose()


                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lnkSuggest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;
                SqlDataReader drSQL;

                cnSQL.Open();
                
                cmSQL.CommandText = "SELECT  COUNT (DISTINCT MandateNo) AS MaxMandateNo FROM PaymentDeductions";
                cmSQL.CommandType = CommandType.Text;
                drSQL = cmSQL.ExecuteReader();
                if (drSQL.Read()) tMandateNo.Text = (Convert.ToInt16(drSQL["MaxMandateNo"]) + 1).ToString();


                //cmSQL.Connection.Close()
                cmSQL.Dispose();
                drSQL.Close();
                cnSQL.Close();
                //cnSQL.Dispose()

                if (tMandateNo.Text.Length == 1)
                    tMandateNo.Text = "00" + tMandateNo.Text;
                else if (tMandateNo.Text.Length == 2)
                    tMandateNo.Text = "0" + tMandateNo.Text;

                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
