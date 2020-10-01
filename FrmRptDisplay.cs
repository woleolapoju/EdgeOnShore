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
namespace Edge
{
   
    public partial class FrmRptDisplay : Form
    {
        public String RptFilename;
        public String SelFormula, RptDestination, RptTitle;
        public ReportDocument myReportDocument;
        public String PaperSize, POrientation;
        public FrmRptDisplay()
        {
            InitializeComponent();
        }

        private void FrmRptDisplay_Load(object sender, EventArgs e)
        {
            ConfigureCrystalReports();
            this.Text = "Report: " + RptTitle.ToUpper();

            //Dim reportPath As String = Application.StartupPath & "\" & "NorthwindCustomers.rpt"
            //myCrystalReportViewer.ReportSource = reportPath

            switch (PaperSize)
            {
                case "(Default)":
                    //myReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize
                    break;
                case "A4":
                    myReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                    break;
                case "A3":
                    myReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA3;
                    break;
                case "A5":
                    myReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                    break;
                case "B4":
                    myReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperB4;
                    break;
                case "B5":
                    myReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperB5;
                    break;
                case "Executive":
                    myReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperExecutive;
                    break;
                case "FanfoldLegal":
                    myReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperFanfoldLegalGerman;
                    break;
                case "FanfoldStandard":
                    myReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperFanfoldStdGerman;
                    break;
                case "FanfoldUS":
                    myReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperFanfoldUS;
                    break;
                case "Legal":
                    myReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLegal;
                    break;
                case "Letter":
                    myReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                    break;
            }
            switch (POrientation)
            {
                case "(Default)":
                    //myReportDocument.PrintOptions.PaperOrientation = PaperOrientation.DefaultPaperOrientation
                    break;
                case "Portrait":
                    myReportDocument.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    break;
                case "Landscape":
                    myReportDocument.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                    break;
            }


            myCrystalReportViewer.ReportSource = myReportDocument;
            if (SelFormula != "")
            {
                myCrystalReportViewer.SelectionFormula = SelFormula;
            }
            myCrystalReportViewer.Zoom(75);

        }

        private void ConfigureCrystalReports()
        {
            try
            {
                int intCounter = 0;
                CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                ConInfo.ConnectionInfo.DatabaseName =MyModules.AttachName;
                ConInfo.ConnectionInfo.ServerName = MyModules.ServerName;
                if (MyModules.IntegratedSecurity)
                {
                    ConInfo.ConnectionInfo.IntegratedSecurity = true;
                }
                else
                {
                    ConInfo.ConnectionInfo.Password = MyModules.Password;
                    ConInfo.ConnectionInfo.UserID = MyModules.UserID;
                }

                for (intCounter = 0; intCounter < myReportDocument.Database.Tables.Count; intCounter++)
                {
                    myReportDocument.Database.Tables[intCounter].ApplyLogOnInfo(ConInfo);
                }

                if (RptDestination == "Printer")
                {
                    // You can change more print options via PrintOptions property of ReportDocument
                    // myCrystalReportViewer.PrintReport()
                    myReportDocument.PrintToPrinter(1, true, 0, 0);
                    myReportDocument.Close();
                }
                return;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        }
    }
