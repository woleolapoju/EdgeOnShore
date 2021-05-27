using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace Edge
{
    public partial class FrmReports : Form
    {
        public FrmReports()
        {
            InitializeComponent();
        }

        private void lvRpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblReportTitle.Text = lvRpt.SelectedItems[0].Text;
                lblStart.ForeColor = Color.Black;
                lblEnd.ForeColor = Color.Black;
                lblGrpBy.ForeColor = Color.Black;
                lblGrpFilter.ForeColor = Color.Black;
                lblfocus.ForeColor = Color.Black;
                lblMandateNo.ForeColor = Color.Black;

                switch (lblReportTitle.Text)
                {
                    case "Mandate":
                        lblMandateNo.ForeColor = Color.Red;
                        break;
                    case "Payment List (Layout 1)":
                        lblStart.ForeColor = Color.Red;
                        lblEnd.ForeColor = Color.Red;
                        lblGrpBy.ForeColor = Color.Red;
                        lblfocus.ForeColor = Color.Red;
                        lblGrpFilter.ForeColor = Color.Red;
                        break;
                    case "Payment List (Layout 2)":
                        lblStart.ForeColor = Color.Red;
                        lblEnd.ForeColor = Color.Red;
                        lblGrpBy.ForeColor = Color.Red;
                        lblfocus.ForeColor = Color.Red;
                        lblGrpFilter.ForeColor = Color.Red;
                        break;
                    case "Payment Deduction List":
                        lblStart.ForeColor = Color.Red;
                        lblEnd.ForeColor = Color.Red;
                        break;
                    case "Student List":
                        lblGrpBy.ForeColor = Color.Red;
                        lblGrpFilter.ForeColor = Color.Red;
                        break;
                    case "School List":
                        lblGrpBy.ForeColor = Color.Red;
                        lblGrpFilter.ForeColor = Color.Red;
                        break;
                    case "Staff List":
                        lblGrpBy.ForeColor = Color.Red;
                        lblGrpFilter.ForeColor = Color.Red;
                        break;
                    case "Vendor List":
                        lblGrpBy.ForeColor = Color.Red;
                        lblGrpFilter.ForeColor = Color.Red;
                        break;
                }

            }
            catch
            { }
        }

        private void cboClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmReports_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = Convert.ToDateTime("01-Jan-" + DateTime.Now.Year.ToString());
            dtpEndDate.Value = Convert.ToDateTime(DateTime.Now.ToString());
        }

        private void cboGrpBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrpFilter();
        }

       private void FillGrpFilter()
        {
            string strQry = "";
            cboGrpFilter.Items.Clear();
            cboGrpFilter.Items.Add("<ALL>");
        
            switch (cboGrpBy.Text)
            {
                case "Region":
                    switch (lblReportTitle.Text)
                    {
                        case "Payment List":
                            strQry = "SELECT DISTINCT Region FROM PaymentWithRegionAndCategory";
                            break;
                        case "School List":
                            strQry = "SELECT DISTINCT Region FROM RegisterSchool";
                            break;
                        case "Student List":
                            strQry = "SELECT DISTINCT Region FROM RegisterStudent";
                            break;
                        case "Staff List":
                            strQry = "SELECT DISTINCT Region FROM RegisterVendor WHERE Source='STAFF'";
                            break;
                        case "Vendor List":
                            strQry = "SELECT DISTINCT Region FROM RegisterVendor WHERE Source<>'STAFF'";
                            break;
                    }
                    break;
                case "Category":
                    switch (lblReportTitle.Text)
                    {
                        case "Payment List":
                            strQry = "SELECT DISTINCT Category FROM PaymentWithRegionAndCategory";
                            break;
                        case "School List":
                            strQry = "SELECT DISTINCT Category FROM RegisterSchool";
                            break;
                        case "Student List":
                            strQry = "SELECT DISTINCT Category FROM RegisterStudent";
                            break;
                        case "Staff List":
                            strQry = "SELECT DISTINCT Category FROM RegisterVendor WHERE Source='STAFF'";
                            break;
                        case "Vendor List":
                            strQry = "SELECT DISTINCT Category FROM RegisterVendor WHERE Source<>'STAFF'";
                            break;
                    }
                    break;

                case "Intervention Line":
                    switch (lblReportTitle.Text)
                    {
                        case "Payment List":
                            strQry = "SELECT DISTINCT InterventionLine FROM PaymentWithRegionAndCategory";
                            break;
                        case "School List":
                            MessageBox.Show("Not Applicable for this Report");
                            return;
                        case "Student List":
                            MessageBox.Show("Not Applicable for this Report");
                            return;
                        case "Staff List":
                            MessageBox.Show("Not Applicable for this Report");
                            return;
                        case "Vendor List":
                            MessageBox.Show("Not Applicable for this Report");
                            return;
                    }
                    break;
                default:
                        return;
            }

            try
            {

                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;
                SqlDataReader drSQL;
               
                cnSQL.Open();
               
                cmSQL.CommandText = strQry;
                cmSQL.CommandType = CommandType.Text;
                drSQL = cmSQL.ExecuteReader();

                while (drSQL.Read())
                {
                    cboGrpFilter.Items.Add(drSQL[0].ToString());
                }


                //cmSQL.Connection.Close()
                cmSQL.Dispose();
                drSQL.Close();
                cnSQL.Close();
                //cnSQL.Dispose()

                cboGrpFilter.SelectedIndex = 0;

                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void cboOk_Click(object sender, EventArgs e)
        {
            string selformular = "";
            ReportDocument RptFilename = new ReportDocument();

            string tstartdate = (dtpStartDate.Checked == false ? "" : "Date(" + dtpStartDate.Value.Year + "," + dtpStartDate.Value.Month + "," + dtpStartDate.Value.Day + ")");
            string tenddate = (dtpEndDate.Checked == false ? "" : "Date(" + dtpEndDate.Value.Year + "," + dtpEndDate.Value.Month + "," + dtpEndDate.Value.Day + ")");

            switch (lblReportTitle.Text)
            {
                case "Payment List (Layout 1)":
                    RptFilename = new Reports.PaymentList();
                    if (chkSchool.Checked)
                        selformular = " {RptPaymentWithRegionAndCategory.Source}='SCHOOL'";
                    if (chkStudent.Checked)
                        selformular = selformular + (selformular == "" ? "" : " OR ") + " {RptPaymentWithRegionAndCategory.Source}='STUDENT'";
                    if (chkVendor.Checked)
                        selformular = selformular + (selformular == "" ? "" : " OR ") +  " {RptPaymentWithRegionAndCategory.Source}='VENDOR'";
                    if (chkStaff.Checked)
                        selformular = selformular + (selformular == "" ? "" : " OR ") +  " {RptPaymentWithRegionAndCategory.Source}='STAFF'";

                    if (selformular != "")
                        selformular = "(" + selformular + ")";

                    if (tstartdate != "")
                        selformular = selformular + (selformular == "" ? "" : " AND ") + " {RptPaymentWithRegionAndCategory.PayValueDate}>=" + tstartdate;

                    if (tenddate != "")
                        selformular = selformular + (selformular == "" ? "" : " AND ") + " {RptPaymentWithRegionAndCategory.PayValueDate}<=" + tenddate;

                    if (cboGrpFilter.Text != "<ALL>" && cboGrpBy.Text=="Region")
                        selformular = selformular + (selformular == "" ? "" : " AND ") + " {RptPaymentWithRegionAndCategory.Region}='" + cboGrpFilter.Text + "'";
                    if (cboGrpFilter.Text != "<ALL>" && cboGrpBy.Text == "Category")
                        selformular = selformular + (selformular == "" ? "" : " AND ") + " {RptPaymentWithRegionAndCategory.Category}='" + cboGrpFilter.Text + "'";
                    if (cboGrpFilter.Text != "<ALL>" && cboGrpBy.Text == "Intervention Line")
                        selformular = selformular + (selformular == "" ? "" : " AND ") + " {RptPaymentWithRegionAndCategory.InterventionLine}='" + cboGrpFilter.Text + "'";

                    switch (cboGrpBy.Text)
                    {
                        case "Region":
                            RptFilename.DataDefinition.FormulaFields["Grp"].Text = "{RptPaymentWithRegionAndCategory.Region}";
                            break;
                          case  "Category":
                            RptFilename.DataDefinition.FormulaFields["Grp"].Text = "{RptPaymentWithRegionAndCategory.Category}";
                            break;
                        case "Intervention Line":
                            RptFilename.DataDefinition.FormulaFields["Grp"].Text = "{RptPaymentWithRegionAndCategory.InterventionLine}";
                            break;
                        default:
                            RptFilename.DataDefinition.FormulaFields["Grp"].Text = "";
                            break;
                    }
                    break;
                case "Payment List (Layout 2)":
                    RptFilename = new Reports.PaymentList2();
                    if (chkSchool.Checked)
                        selformular = " {RptPaymentWithRegionAndCategory.Source}='SCHOOL'";
                    if (chkStudent.Checked)
                        selformular = selformular + (selformular == "" ? "" : " OR ") + " {RptPaymentWithRegionAndCategory.Source}='STUDENT'";
                    if (chkVendor.Checked)
                        selformular = selformular + (selformular == "" ? "" : " OR ") + " {RptPaymentWithRegionAndCategory.Source}='VENDOR'";
                    if (chkStaff.Checked)
                        selformular = selformular + (selformular == "" ? "" : " OR ") + " {RptPaymentWithRegionAndCategory.Source}='STAFF'";

                    if (selformular != "")
                        selformular = "(" + selformular + ")";

                    if (tstartdate != "")
                        selformular = selformular + (selformular == "" ? "" : " AND ") + " {RptPaymentWithRegionAndCategory.PayValueDate}>=" + tstartdate;

                    if (tenddate != "")
                        selformular = selformular + (selformular == "" ? "" : " AND ") + " {RptPaymentWithRegionAndCategory.PayValueDate}<=" + tenddate;

                    if (cboGrpFilter.Text != "<ALL>" && cboGrpBy.Text == "Region")
                        selformular = selformular + (selformular == "" ? "" : " AND ") + " {RptPaymentWithRegionAndCategory.Region}='" + cboGrpFilter.Text + "'";
                    if (cboGrpFilter.Text != "<ALL>" && cboGrpBy.Text == "Category")
                        selformular = selformular + (selformular == "" ? "" : " AND ") + " {RptPaymentWithRegionAndCategory.Category}='" + cboGrpFilter.Text + "'";
                    if (cboGrpFilter.Text != "<ALL>" && cboGrpBy.Text == "Intervention Line")
                        selformular = selformular + (selformular == "" ? "" : " AND ") + " {RptPaymentWithRegionAndCategory.InterventionLine}='" + cboGrpFilter.Text + "'";

                    switch (cboGrpBy.Text)
                    {
                        case "Region":
                            RptFilename.DataDefinition.FormulaFields["Grp"].Text = "{RptPaymentWithRegionAndCategory.Region}";
                            break;
                        case "Category":
                            RptFilename.DataDefinition.FormulaFields["Grp"].Text = "{RptPaymentWithRegionAndCategory.Category}";
                            break;
                        case "Intervention Line":
                            RptFilename.DataDefinition.FormulaFields["Grp"].Text = "{RptPaymentWithRegionAndCategory.InterventionLine}";
                            break;
                        default:
                            RptFilename.DataDefinition.FormulaFields["Grp"].Text = "";
                            break;
                    }
                    break;

                case "School List":
                    RptFilename = new Reports.SchoolList();
                    if (cboGrpFilter.Text != "<ALL>" && cboGrpBy.Text == "Region")
                        selformular = selformular + (selformular == "" ? "" : " AND ") + " {RptRegisterSchool.Region}='" + cboGrpFilter.Text + "'";
                    if (cboGrpFilter.Text != "<ALL>" && cboGrpBy.Text == "Category")
                        selformular = selformular + (selformular == "" ? "" : " AND ") + " {RptRegisterSchool.Category}='" + cboGrpFilter.Text + "'";
                   
                    switch (cboGrpBy.Text)
                    {
                        case "Region":
                            RptFilename.DataDefinition.FormulaFields["Grp"].Text = "{RptRegisterSchool.Region}";
                            break;
                        case "Category":
                            RptFilename.DataDefinition.FormulaFields["Grp"].Text = "{RptRegisterSchool.Category}";
                            break;
                        default:
                            RptFilename.DataDefinition.FormulaFields["Grp"].Text = "";
                            break;
                    }

                    break;
                case "Student List":
                    RptFilename = new Reports.StudentList();
                    if (cboGrpFilter.Text != "<ALL>" && cboGrpBy.Text == "Region")
                        selformular = selformular + (selformular == "" ? "" : " AND ") + " {RptRegisterStudent.Region}='" + cboGrpFilter.Text + "'";
                    if (cboGrpFilter.Text != "<ALL>" && cboGrpBy.Text == "Category")
                        selformular = selformular + (selformular == "" ? "" : " AND ") + " {RptRegisterStudent.Category}='" + cboGrpFilter.Text + "'";

                    switch (cboGrpBy.Text)
                    {
                        case "Region":
                            RptFilename.DataDefinition.FormulaFields["Grp"].Text = "{RptRegisterStudent.Region}";
                            break;
                        case "Category":
                            RptFilename.DataDefinition.FormulaFields["Grp"].Text = "{RptRegisterStudent.Category}";
                            break;
                        default:
                            RptFilename.DataDefinition.FormulaFields["Grp"].Text = "";
                            break;
                    }
                    break;
                case "Staff List":
                    RptFilename = new Reports.VendorList();
                    selformular = " {RptRegisterVendor.Source}='STAFF'";
                    if (cboGrpFilter.Text != "<ALL>" && cboGrpBy.Text == "Region")
                        selformular = selformular + (selformular == "" ? "" : " AND ") + " {RptRegisterVendor.Region}='" + cboGrpFilter.Text + "'";
                    if (cboGrpFilter.Text != "<ALL>" && cboGrpBy.Text == "Category")
                        selformular = selformular + (selformular == "" ? "" : " AND ") + " {RptRegisterVendor.Category}='" + cboGrpFilter.Text + "'";

                    switch (cboGrpBy.Text)
                    {
                        case "Region":
                            RptFilename.DataDefinition.FormulaFields["Grp"].Text = "{RptRegisterVendor.Region}";
                            break;
                        case "Category":
                            RptFilename.DataDefinition.FormulaFields["Grp"].Text = "{RptRegisterVendor.Category}";
                            break;
                        default:
                            RptFilename.DataDefinition.FormulaFields["Grp"].Text = "";
                            break;
                    }
                    break;
                case "Vendor List":
                    RptFilename = new Reports.VendorList();
                    selformular = " {RptRegisterVendor.Source}='VENDOR'";
                    if (cboGrpFilter.Text != "<ALL>" && cboGrpBy.Text == "Region")
                        selformular = selformular + (selformular == "" ? "" : " AND ") + " {RptRegisterVendor.Region}='" + cboGrpFilter.Text + "'";
                    if (cboGrpFilter.Text != "<ALL>" && cboGrpBy.Text == "Category")
                        selformular = selformular + (selformular == "" ? "" : " AND ") + " {RptRegisterVendor.Category}='" + cboGrpFilter.Text + "'";

                    switch (cboGrpBy.Text)
                    {
                        case "Region":
                            RptFilename.DataDefinition.FormulaFields["Grp"].Text = "{RptRegisterVendor.Region}";
                            break;
                        case "Category":
                            RptFilename.DataDefinition.FormulaFields["Grp"].Text = "{RptRegisterVendor.Category}";
                            break;
                        default:
                            RptFilename.DataDefinition.FormulaFields["Grp"].Text = "";
                            break;
                    }
                    break;
                case "Mandate":
                    FrmMandateRpt childform = new FrmMandateRpt();
                    childform.TheMandateNo = cboMandateNo.Text;
                    childform.dAmount = "0";
                    childform.MainAction = "Main";
                    childform.ShowDialog();
                    return;
                case "Payment Deduction List":
                    RptFilename = new Reports.PaymentDeductionList();
                    if (tstartdate != "")
                        selformular = selformular + (selformular == "" ? "" : " AND ") + " {RptPaymentDeductions.PayValueDate}>=" + tstartdate;

                    if (tenddate != "")
                        selformular = selformular + (selformular == "" ? "" : " AND ") + " {RptPaymentDeductions.PayValueDate}<=" + tenddate;

                    break;
                default:
                    MessageBox.Show("Pls. select a report option");
                    return;
            }

            FrmRptDisplay ChildForm = new FrmRptDisplay();
            ChildForm.RptTitle = lblReportTitle.Text;
            ChildForm.RptDestination = "Screen";
            ChildForm.myReportDocument = RptFilename;

            //MessageBox.Show(selformular);

            if (selformular != "") ChildForm.SelFormula = selformular;
            ChildForm.ShowDialog();
        }
    }
}
