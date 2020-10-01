using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.IO;
namespace Edge
{
    public partial class FrmLedger : Form
    {
        private BindingSource bindingSource = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private BindingSource bindingSourceA = new BindingSource();
        private SqlDataAdapter dataAdapterA = new SqlDataAdapter();
   // String ReturnCode;
        public FrmLedger()
        {
            InitializeComponent();
        }

        private void FrmLedger_Load(object sender, EventArgs e)
        {
            DGrid.DataSource = bindingSource;
            DGridSummary.DataSource = bindingSourceA;
            this.Tag = 0;
            dtpStartDate.Value =Convert.ToDateTime( "01-Jan-" + DateTime.Now.Year.ToString());
            dtpEndDate.Value = Convert.ToDateTime(DateTime.Now.ToString());
            dtpStartDate.Checked = false;
            dtpEndDate.Checked = false;

            oLoadSchName();

            DeleteHTMTempFiles();
                
            MyModules.applyGridTheme(DGridSummary);
            MyModules.applyGridTheme(DGrid);
            DGridSummary.ReadOnly = true;
            DGrid.ReadOnly = true;
        }

        private void LoadClientBalances()
        {
            try
            {
                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;
                cnSQL.Open();
                string strQry1 = "";
                cmSQL.Parameters.Clear();
                if (RadSchool.Checked == true)
                {

                    cmSQL.CommandText = "SELECT RefNo, Name, 0 AS CR, SUM(Amount) AS DR,0-SUM(Amount) AS Balance FROM Ledger WHERE Source='SCHOOL' GROUP BY RefNo, Name";
                }
                else if (RadStudent.Checked == true)
                {

                    if (cGrp.Text != "ALL")
                    {
                        strQry1 = strQry1 + (string.IsNullOrEmpty(strQry1) ? " " : " AND ") + " SchoolID =" + MyModules.GetIt4Me(cGrp.Text," - ") ;
                    }
                    cmSQL.CommandText = "SELECT RefNo, Name, 0 AS CR, SUM(Amount) AS DR,0-SUM(Amount) AS Balance FROM Ledger WHERE Source='STUDENT' " + (string.IsNullOrEmpty(strQry1) ? "" : " AND " + strQry1) + " GROUP BY RefNo, Name";
                }
                else if (RadVendor.Checked == true)
                {
                    cmSQL.CommandText = "SELECT RefNo, Name, 0 AS CR, SUM(Amount) AS DR,0-SUM(Amount) AS Balance FROM Ledger WHERE Source='VENDOR' " + (string.IsNullOrEmpty(strQry1) ? "" : " AND " + strQry1) + " GROUP BY RefNo, Name";
                }
                else
                {
                    if (cGrp.Text != "ALL")
                    {
                        strQry1 = strQry1 + (string.IsNullOrEmpty(strQry1) ? " " : " AND ") + " RegisterVendor.Category ='" + cGrp.Text + "'";
                    }
               
                    cmSQL.CommandText = "SELECT Ledger.RefNo, Ledger.Name, 0 AS CR, SUM(Amount) AS DR,0-SUM(Amount) AS Balance FROM  Ledger LEFT OUTER JOIN RegisterVendor ON Ledger.RefNo = RegisterVendor.Sn WHERE Ledger.Source='STAFF' " + (string.IsNullOrEmpty(strQry1) ? "" : " AND " + strQry1) + " GROUP BY Ledger.RefNo, Ledger.Name";
                }

                cmSQL.CommandType = CommandType.Text;
                dataAdapterA = new SqlDataAdapter(cmSQL);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapterA);
                DataTable tableA = new DataTable();
                tableA.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapterA.Fill(tableA);
                bindingSourceA.DataSource = tableA;

                DataGridViewCellStyle myStyle = new DataGridViewCellStyle();
                DataGridViewCellStyle myStyle1 = new DataGridViewCellStyle();
                myStyle.ForeColor = Color.Red;
                myStyle.Format = "N2";
                myStyle1.Format = "N2";
                myStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                myStyle1.ForeColor = Color.Black;
                myStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
                cnSQL.Close();

                LoadDetails("-899", "sfsfsfs@@");

                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void LoadDetails(string ClientCode, string theName)
        {
            try
            {
                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                
                cmSQL.Connection = cnSQL;
                cnSQL.Open();
                cmSQL.Parameters.Clear();
                cmSQL.CommandText = "FetchPaymentDetails";
                if (RadSchool.Checked)
                {
                    cmSQL.Parameters.AddWithValue("@Source", "SCHOOL");
                }
                if (RadStudent.Checked)
                {
                    cmSQL.Parameters.AddWithValue("@Source", "STUDENT");
                }
                if (RadVendor.Checked)
                {
                    cmSQL.Parameters.AddWithValue("@Source", "VENDOR");
                }

                if (radStaff.Checked)
                {
                    cmSQL.Parameters.AddWithValue("@Source", "STAFF");
                }

                cmSQL.Parameters.AddWithValue("@RefNo", ClientCode);
                cmSQL.Parameters.AddWithValue("@TheName", theName);
                cmSQL.Parameters.AddWithValue("@StartDate", (dtpStartDate.Checked == false ? "01-Jan-1900" : dtpStartDate.Value.ToString()));
                cmSQL.Parameters.AddWithValue("@Enddate", (dtpEndDate.Checked == false ? "31-Dec-"+ (DateTime.Now.Year+50).ToString() : dtpEndDate.Value.ToString()));

        

               
                cmSQL.CommandType = CommandType.StoredProcedure;
                dataAdapter = new SqlDataAdapter(cmSQL);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                bindingSource.DataSource = table;

                //DGrid.Columns(5).Width = 250

                DataGridViewCellStyle myStyle = new DataGridViewCellStyle();
                DataGridViewCellStyle myStyle1 = new DataGridViewCellStyle();
                myStyle.ForeColor = Color.Red;
                myStyle.Format = "N2";
                myStyle1.Format = "N2";
                myStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                myStyle1.ForeColor = Color.Black;
                myStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;

      

             DGrid.Columns[2].DefaultCellStyle = myStyle1;
                //DGrid.Columns(3).DefaultCellStyle = myStyle1

                cmSQL.Dispose();
                cnSQL.Close();
                return;
            }
         catch(Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void DGridSummary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGridSummary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Tag = "";
            this.Tag = DGridSummary[0, e.RowIndex].Value;
            DGridSummary.Tag = DGridSummary[1, e.RowIndex].Value;
        }

        private void DGridSummary_DoubleClick(object sender, EventArgs e)
        {
            if (Convert.ToInt16(this.Tag) != 0)
            {
                CreateHTML(this.Tag.ToString(), DGridSummary.Tag.ToString());
                LoadDetails(this.Tag.ToString(), DGridSummary.Tag.ToString());
             }
        }

        private void CreateHTML(string ClientCode, string theName)
        {
            try
            {
                //If Trim(strAccountNo) = "" Then Exit Sub
                // Create an instance of StreamWriter to write text to a file.
                string GetHTMFileName = Microsoft.VisualBasic.FileIO.FileSystem.GetTempFileName();
                GetHTMFileName = GetHTMFileName.Substring(0, GetHTMFileName.Length - 3) + "apx";
                using (StreamWriter sw = new StreamWriter(GetHTMFileName))
                {

                    sw.WriteLine("<html>");
                    sw.WriteLine("<head>");
                    sw.WriteLine("<meta http-equiv='Content-Type' content='text/html; charset=windows-1252'>");
                    sw.WriteLine("<title>PrimeScholar</title>");
                    sw.WriteLine("<style>");
                    sw.WriteLine("<!--");
                    sw.WriteLine("BODY         { background: url('top-vb.gif') repeat-x; font-family: Verdana; font-size: 67% ; background-color:white } ");
                    sw.WriteLine(".maindiv     { background: url('side-vb.gif') repeat-y; padding-left: 30px; padding-top: 5px; position: relative; ");

                    sw.WriteLine("height: 50px }");
                    sw.WriteLine("P            { margin-top: 0; margin-bottom: 6px; line-height:130% }");
                    sw.WriteLine("H1           { margin-top: 20px; margin-bottom: 12px; font-size:190% }");
                    sw.WriteLine("H2           { color: #585F56; left: -55px; position: relative; margin-top: 21px; margin-bottom: 9px; font-size:170% ");



                    sw.WriteLine("}");
                    sw.WriteLine("H3           { margin-top: 21px; margin-bottom: 9px; font-size: 140%;  font-weight: bold}");
                    sw.WriteLine("H4           { margin-top: 18px; margin-bottom: 9px; font-size: 140%; font-weight: bold}");
                    sw.WriteLine("OL           { margin-top: 0; margin-bottom: 9px; line-height:130%}");
                    sw.WriteLine("UL           { margin-top: 0; margin-bottom: 9px; line-height:130%}");
                    sw.WriteLine("LI           { margin-top: 0; margin-bottom: 6px }");
                    sw.WriteLine("BLOCKQUOTE   { margin-left: 10px }");
                    sw.WriteLine("TABLE        { padding: 4px; BACKGROUND: white; BORDER: #DDDCD6 1px solid; BORDER-COLLAPSE: collapse; margin-");

                    sw.WriteLine("bottom: 9px; }");
                    sw.WriteLine("TR           { vertical-align: top} ");
                    sw.WriteLine("TD           { padding: 4px; font-family: Verdana; font-size: 67%; line-height: 130%} ");
                    sw.WriteLine(".contents    { line-height: 150% }");
                    sw.WriteLine("DIV.CodeBlock   { font-family: 'Courier New'; font-size: 100%; margin-bottom: 6px; BACKGROUND: #f8f7ef; BORDER: ");

                    sw.WriteLine("#eeede6 1px solid; padding: 5px; }");
                    sw.WriteLine(".CodeInline  { font-family: 'Courier New' }");
                    sw.WriteLine(".ProcedureLabel {margin-top: 5px; font-style: italic; font-weight: bold; color: #0D4CC3 } ");
                    sw.WriteLine(".FileNameCol { padding: 5px; BACKGROUND: seashell; width=200px; font-size: 60%; font-weight: bold}");
                    sw.WriteLine(".Col {padding: 5px; width=600px}");
                    sw.WriteLine("-->");
                    sw.WriteLine("</style>");
                    sw.WriteLine("</head>");

                    sw.WriteLine("<body topmargin='0' leftmargin='0' rightmargin='0'>");
                    sw.WriteLine("<div class='maindiv'>");

                    sw.WriteLine("<a name='top'>");

                    sw.WriteLine("<!-- MAIN CONTENT BEGINS -->");

                    SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                    SqlCommand cmSQL = new SqlCommand();
                    cmSQL.Connection = cnSQL;
                    SqlDataReader drSQL = null;

                    //if (RadSchool.Checked)
                    //{
                        cmSQL.CommandText = "SELECT * FROM RegisterSchool WHERE Sn=" + ClientCode;
                    //}
                    //if (RadStudent.Checked)
                    //{
                    //    cmSQL.CommandText = "SELECT * FROM RegisterStudent WHERE Sn=" + ClientCode;
                    //}
                    //if (RadVendor.Checked)
                    //{
                    //    cmSQL.CommandText = "SELECT * FROM RegisterVendor WHERE Sn=" + ClientCode;
                    //}
                    //if (radStaff.Checked)
                    //{
                    //    cmSQL.CommandText = "SELECT * FROM RegisterVendor WHERE Sn=" + ClientCode;
                    //}
                    cmSQL.CommandType = CommandType.Text;

                    cnSQL.Open();
                    drSQL = cmSQL.ExecuteReader();
                    int i = 0;
                    if (drSQL.HasRows == false)
                    {
                        goto SkipIt;
                    }
                    if (drSQL.Read())
                    {
                        sw.WriteLine("<h1>");
                        sw.WriteLine("<span style='font-size: 11pt'>BENEFICIARY INFORMATION</span><a name='top'>");

                        sw.WriteLine("</h1>");

                        sw.WriteLine("</a>");

                        sw.WriteLine("<table border='1' bordercolor= #DDDCD6 width='100%' style='border-collapse: collapse'>");
                        sw.WriteLine("<tr>");

                        for (i = 0; i < drSQL.FieldCount; i++)
                        {

                            sw.WriteLine("<tr>");

                            sw.WriteLine("<td class='FileNameCol'>" + drSQL.GetName(i) + "</td>");
                            if (drSQL[i].GetType().ToString() == "System.DateTime")
                            {
                                sw.WriteLine("<td class='Col'>" +  MyModules.FormatDate(drSQL[i]) + "</td>");
                            }
                            else if (drSQL[i].GetType().ToString() == "System.Decimal")
                            {
                                sw.WriteLine("<td class='Col'>" + MyModules.FormatDouble(drSQL[i]) + "</td>");
                            }
                            else
                            {
                                sw.WriteLine("<td class='Col'>" + MyModules.ChkNull(drSQL[i]) + "</td>");
                            }
                            sw.WriteLine("</tr>");
                        }
                    }
                    else
                    {
                        sw.WriteLine("<h1>");
                        sw.WriteLine("<span style='font-size: 11pt;color: #990000'>" + MyModules.sysOwner + "</span><a name='top'>");
                        sw.WriteLine("</h1>");
                        sw.WriteLine("<h1>");
                        sw.WriteLine("<span style='font-size: 11pt;color: #990000'>Details:</span><a name='top'>");
                        sw.WriteLine("</h1>");
                        sw.WriteLine("</a>");
                        sw.WriteLine("<table border='1' bordercolor= #DDDCD6 width='70%' style='border-collapse: collapse'>");
                        sw.WriteLine("<tr>");
                    }

                    SkipIt:
                    cmSQL.Connection.Close();
                    cmSQL.Dispose();
                    drSQL.Close();
                    cnSQL.Close();
                    cnSQL.Dispose();

                    sw.WriteLine("</table>");
                    sw.WriteLine("</p>");
                    sw.WriteLine("<h3>");
                    sw.WriteLine("<span style='font-size: 60%'>");


                    sw.WriteLine("<p>&nbsp;</p>");

                    sw.WriteLine("</div>");
                    sw.WriteLine("</body>");
                    sw.WriteLine("</html>");

                    sw.Close();

                    WebBrowser.Navigate(new Uri(GetHTMFileName));

                }

                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        //private void Navigate(string address)
        //{

        //    if (string.IsNullOrEmpty(address))
        //    {
        //        return;
        //    }
        //    if (address.Equals("about:blank"))
        //    {
        //        return;
        //    }
        //    if (!address.StartsWith("http://"))
        //    {
        //        address = address; //'"http://" &
        //    }

        //    try
        //    {
        //        WebBrowser.Navigate(new Uri(address));
        //    }
        //    catch (System.UriFormatException ex)
        //    {
        //        WebBrowser.Visible = false;
        //        MessageBox.Show("Cannot open Readme file", strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }
        //}

        private void oLoadSchName()
        {
            try
            {
                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;
                SqlDataReader drSQL = null;
               
                cmSQL.CommandText = "SELECT DISTINCT SchoolID,SchName FROM Payment WHERE Source='STUDENT' ORDER BY [SchName]";
                   
                cmSQL.CommandType = CommandType.Text;

                cnSQL.Open();
                cGrp.Items.Add("ALL");
                drSQL = cmSQL.ExecuteReader();
             
                while (drSQL.Read())
                {
                    cGrp.Items.Add(drSQL["SchoolID"] + " - " +MyModules.ChkNull(drSQL["SchName"]));
                }


                cmSQL.Connection.Close();
                cmSQL.Dispose();
                drSQL.Close();
                cnSQL.Close();
                cnSQL.Dispose();

                cGrp.Text = "ALL";
                //cGrp.SelectedIndex = 0;


                return;
         
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteHTMTempFiles()
        {

        foreach (string foundFile in Microsoft.VisualBasic.FileIO.FileSystem.GetFiles(System.IO.Path.GetTempPath(), Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly, "*.apx"))
            {
                System.IO.File.Delete(foundFile);
            }
        }

        private void RadStudent_CheckedChanged(object sender, EventArgs e)
        {

            Panel2.Visible = true;
            if (RadStudent.Checked)
                lblGrp.Text = "School";
            oLoadSchName();
           
            {
                LoadClientBalances();
            }
        }

        private void RadSchool_CheckedChanged(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            if (RadSchool.Checked)
            {
                LoadClientBalances();
            }
        }

        private void RadVendor_CheckedChanged(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            if (RadVendor.Checked)
            {
                LoadClientBalances();
            }
        }

        private void cSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (Panel2.Visible == true) LoadClientBalances();
        }

        private void lnkPrintLedger_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Convert.ToUInt16(this.Tag) == 0) return;
            ReportDocument RptFilename = new ReportDocument();
            RptFilename = new Reports.Ledger();

            //  RptFilename.Load(MyModules.AppPath + "ConfigDir\\Ledger.rpt");
            string selformular = "";
            FrmRptDisplay ChildForm = new FrmRptDisplay();
            ChildForm.RptTitle = "Ledger";
            ChildForm.RptDestination = "Screen";
            ChildForm.myReportDocument = RptFilename;
          
            if (RadSchool.Checked)
                selformular = " {RptLedger.Source}='SCHOOL' AND {RptLedger.RefNo}=" + this.Tag;
            if (RadStudent.Checked)
                selformular = " {RptLedger.Source}='STUDENT' AND {RptLedger.RefNo}=" + this.Tag;
            if (RadVendor.Checked)
                selformular = " {RptLedger.Source}='VENDOR' AND {RptLedger.RefNo}=" + this.Tag;
            if (radStaff.Checked)
                selformular = " {RptLedger.Source}='STAFF' AND {RptLedger.RefNo}=" + this.Tag;

            string tstartdate = (dtpStartDate.Checked == false ? "" : "Date(" + dtpStartDate.Value.Year + "," + dtpStartDate.Value.Month + "," + dtpStartDate.Value.Day + ")");
            string tenddate = (dtpEndDate.Checked == false ? "" : "Date(" + dtpEndDate.Value.Year + "," + dtpEndDate.Value.Month + "," + dtpEndDate.Value.Day + ")");

            if (tstartdate != "")
                selformular = selformular + (selformular==""?"": " AND " ) + " {RptLedger.PayValueDate}>=" + tstartdate;

            if (tenddate != "")
                selformular = selformular + (selformular == "" ? "" : " AND ") + " {RptLedger.PayValueDate}<=" + tenddate;

           if(selformular!="") ChildForm.SelFormula = selformular;
            ChildForm.ShowDialog();

        }

        private void radStaff_CheckedChanged(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            if (radStaff.Checked)
                lblGrp.Text = "Category";
            oLoadCategory();
            cGrp.Text = "ALL";
            {
                LoadClientBalances(); //" RegisterVendor.Category = " + cGrp.Text);
            }


        }

        private void oLoadCategory()
        {
            try
            {
                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;
                SqlDataReader drSQL = null;
                cGrp.Items.Clear();
                cmSQL.CommandText = "SELECT DISTINCT Category FROM RegisterVendor ORDER BY [Category]";

                cmSQL.CommandType = CommandType.Text;

                cnSQL.Open();
                drSQL = cmSQL.ExecuteReader();
                cGrp.Items.Add("ALL");
                while (drSQL.Read())
                {
                    cGrp.Items.Add(drSQL["Category"]);
                }


                cmSQL.Connection.Close();
                cmSQL.Dispose();
                drSQL.Close();
                cnSQL.Close();
                cnSQL.Dispose();

                //cSchool.SelectedIndex = 0;


                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            try {
                LoadDetails(this.Tag.ToString(), DGridSummary.Tag.ToString());
            }
            catch { }
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDetails(this.Tag.ToString(), DGridSummary.Tag.ToString());
            }
            catch { }
        }
    }

}
