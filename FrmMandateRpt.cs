using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Edge
{
    public partial class FrmMandateRpt : Form
    {
        public string TheMandateNo;
        public object frmParent;
        public string dAmount;
        public string MainAction;
        public FrmMandateRpt()
        {
            InitializeComponent();
        }

        private void FrmMandateRpt_Load(object sender, EventArgs e)
        {
            this.Text = TheMandateNo + ": Mandate Print Details";

            tMandateNo.Text = TheMandateNo;
            tAmount.Text = dAmount;

        tSignatory1.Text =MyModules.Signatory1;
        tSignatory2.Text = MyModules.Signatory2;

            GetRefNo();


        }

        private void GetRefNo()
        {
            try
            {
                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand("FetchAllSystemParameters", cnSQL);
                SqlDataReader drSQL;
                string TheRemark = "";
                cnSQL.Open();
                if (MainAction=="Main")
                cmSQL.CommandText = "SELECT top 1 Remark FROM Payment WHERE MandateNo ='" + TheMandateNo + "' AND Remark like 'RefNo: %'";
                else
                    cmSQL.CommandText = "SELECT top 1 Remark FROM PaymentDeductions WHERE MandateNo ='" + TheMandateNo + "' AND Remark like 'RefNo: %'";
                cmSQL.CommandType = System.Data.CommandType.Text;
                drSQL = cmSQL.ExecuteReader();

                if (drSQL.HasRows == false)  goto SkipIt;

                if (drSQL.Read())
                {
                    TheRemark = drSQL["Remark"].ToString();
                }
                if (TheRemark.Length > 0)
                {
                    tMandateNo.Text = TheRemark.Substring(7);
                }

                SkipIt:

                cmSQL.Connection.Close();
                cmSQL.Dispose();
                drSQL.Close();
                cnSQL.Close();
                cnSQL.Dispose();


                return;
          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK);
            }
           
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            if (tMandateNo.Text.Trim() == "")
            {
                MessageBox.Show("Pls. select mandate no", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //if (LastMandateNo == "")
            //{
            //    MessageBox.Show("Cannot determine last Mandate...pls select", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            CrystalDecisions.CrystalReports.Engine.ReportDocument RptFilename = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
          

          

            FrmRptDisplay ChildForm1 = new FrmRptDisplay();
            ChildForm1.SelFormula = "";
            if (MainAction == "Main")
            {
                RptFilename.Load(MyModules.AppPath + "ConfigDir\\Mandate.rpt");
                ChildForm1.SelFormula = " {RptPayment.MandateNo}='" + TheMandateNo + "'";
            }
            if (MainAction == "VAT")
            {
                RptFilename.Load(MyModules.AppPath + "ConfigDir\\MandateVAT.rpt");
                ChildForm1.SelFormula = " {RptPaymentDeductions.MandateNo}='" + TheMandateNo + "' AND {RptPaymentDeductions.MainAction}='VAT'";
            }
            if (MainAction == "WHT")
            {
                RptFilename.Load(MyModules.AppPath + "ConfigDir\\MandateWHT.rpt");
                ChildForm1.SelFormula = " {RptPaymentDeductions.MandateNo}='" + TheMandateNo + "' AND {RptPaymentDeductions.MainAction}='WHT'";
            }
            if (MainAction == "Stamp")
            {
                RptFilename.Load(MyModules.AppPath + "ConfigDir\\MandateStamp.rpt");
                ChildForm1.SelFormula = " {RptPaymentDeductions.MandateNo}='" + TheMandateNo + "' AND {RptPaymentDeductions.MainAction}='Stamp'";
            }


            RptFilename.DataDefinition.FormulaFields["Signatory1"].Text = "'" + tSignatory1.Text + "'";
            RptFilename.DataDefinition.FormulaFields["Signatory2"].Text = "'" + tSignatory2.Text + "'";
            RptFilename.DataDefinition.FormulaFields["RefNo"].Text = "'" + tMandateNo.Text + "'";

            ChildForm1.RptTitle = "Mandate";
            ChildForm1.RptDestination = "Screen";
            ChildForm1.myReportDocument = RptFilename;
            ChildForm1.ShowDialog();

            if (MainAction == "VAT")
            {
                FrmRptDisplay ChildForm0 = new FrmRptDisplay();
                ChildForm0.SelFormula = "";
                RptFilename.Load(MyModules.AppPath + "ConfigDir\\DeductionList.rpt");
                ChildForm0.SelFormula = " {RptPaymentDeductions.MandateNo}='" + TheMandateNo + "' AND {RptPaymentDeductions.MainAction}='VAT'";
                ChildForm0.RptTitle = "Mandate";
                ChildForm0.RptDestination = "Screen";
                ChildForm0.myReportDocument = RptFilename;
                ChildForm0.ShowDialog();
            }

                if (MyModules.Signatory1 != tSignatory1.Text || MyModules.Signatory2 != tSignatory2.Text)
            {
                SaveDefault();
                MyModules.Signatory1 = tSignatory1.Text;
                MyModules.Signatory2 = tSignatory2.Text;
            }
            if (tMandateNo.Text != "") SaveRefNo();

        }

        public void SaveDefault()
        {
            try
            {

                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand("FetchAllSystemParameters", cnSQL);
               
                cnSQL.Open();

                cmSQL.CommandText = "Update SystemParameters SET Signatory1='" + tSignatory1.Text + "', Signatory2='" + tSignatory2.Text + "'";
                cmSQL.CommandType = CommandType.Text;
                cmSQL.ExecuteNonQuery();

                cmSQL.Connection.Close();
                cmSQL.Dispose();
                cnSQL.Close();
                cnSQL.Dispose();

                return;
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            
        }


        public void SaveRefNo()
        {
            try
            {

                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand("FetchAllSystemParameters", cnSQL);

                cnSQL.Open();
                string TheStr = "RefNo: " + tMandateNo.Text ;

           
                if (MainAction == "Main")
                    cmSQL.CommandText = "UPDATE Payment SET Remark = '" + TheStr + "' WHERE MandateNo ='" + TheMandateNo + "' AND (Remark='' OR Remark is Null OR Remark like 'RefNo: %')";
                 if (MainAction == "VAT")
                    cmSQL.CommandText = "UPDATE PaymentDeductions SET Remark = '" + TheStr + "' WHERE MandateNo ='" + TheMandateNo + "' AND MainAction='VAT' AND (Remark='' OR Remark is Null OR Remark like 'RefNo: %')";
                if (MainAction == "WHT")
                    cmSQL.CommandText = "UPDATE PaymentDeductions SET Remark = '" + TheStr + "' WHERE MandateNo ='" + TheMandateNo + "' AND MainAction='WHT' AND (Remark='' OR Remark is Null OR Remark like 'RefNo: %')";
                if (MainAction == "Stamp")
                    cmSQL.CommandText = "UPDATE PaymentDeductions SET Remark = '" + TheStr + "' WHERE MandateNo ='" + TheMandateNo + "' AND MainAction='Stamp' AND (Remark='' OR Remark is Null OR Remark like 'RefNo: %')";


                cmSQL.CommandType = CommandType.Text;
                cmSQL.ExecuteNonQuery();

                cmSQL.Connection.Close();
                cmSQL.Dispose();
                cnSQL.Close();
                cnSQL.Dispose();

                return;
            }
     
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
}

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
