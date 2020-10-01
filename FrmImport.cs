using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
//using ADOX;
namespace FrmImport
{
    public partial class FrmImport : Form
    {
        public FrmImport()
        {
            InitializeComponent();
        }

        public static string SelectedTable = string.Empty;

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            { 

            OpenFileDialog openFileDialog1 = new OpenFileDialog();  //create openfileDialog Object
            openFileDialog1.Filter = "XML Files (*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb) |*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb";//open file format define Excel Files(.xls)|*.xls| Excel Files(.xlsx)|*.xlsx| 
            openFileDialog1.FilterIndex = 3;

            openFileDialog1.Multiselect = false;        //not allow multiline selection at the file selection level
            openFileDialog1.Title = "Select file";   //define the name of openfileDialog
            openFileDialog1.InitialDirectory = @"Desktop"; //define the initial directory

            if (openFileDialog1.ShowDialog() == DialogResult.OK)        //executing when file open
            {
                string pathName = openFileDialog1.FileName;
                string fileName = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                DataTable tbContainer = new DataTable();
                string strConn = string.Empty;
                string sheetName = fileName;

                FileInfo file = new FileInfo(pathName);
                if (!file.Exists) { throw new Exception("Error, file doesn't exists!"); }
                string extension = file.Extension;
                switch (extension)
                {
                    case ".xls":
                        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                        break;
                    case ".xlsx":
                        strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                        break;
                    default:
                        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                        break;
                }

                OleDbConnection cnnxls = new OleDbConnection(strConn);
                OleDbDataAdapter oda = new OleDbDataAdapter(string.Format("select * from [{0}$]", sheetName), cnnxls);
                oda.Fill(tbContainer);

                Dgrid.DataSource = tbContainer;

            }
            //OpenFileDialog fdlg = new OpenFileDialog();
            //fdlg.Title = "Select file";
            //fdlg.InitialDirectory = @"c:\";
            //fdlg.FileName = txtFileName.Text;
            //fdlg.Filter = "Excel Sheet(*.xls)|*.xls|All Files(*.*)|*.*";
            //fdlg.FilterIndex = 1;
            //fdlg.RestoreDirectory = true;
            //if (fdlg.ShowDialog() == DialogResult.OK)
            //{
            //    txtFileName.Text = fdlg.FileName;
            //    Import();
            //    Application.DoEvents();

        }
             catch (Exception)
            {
                MessageBox.Show("Error!");
            }

}


        //private void Import()
        //{
        //    if (txtFileName.Text.Trim() != string.Empty)
        //    {
        //        try
        //        {
        //            string[] strTables = GetTableExcel(txtFileName.Text);

        //            frmSelectTables objSelectTable = new frmSelectTables(strTables);
        //            objSelectTable.ShowDialog(this);
        //            objSelectTable.Dispose();



        //            if ((SelectedTable != string.Empty) && (SelectedTable != null))
        //            {
        //                DataTable dt = GetDataTableExcel(txtFileName.Text, SelectedTable);
        //                Dgrid.DataSource = dt.DefaultView;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message.ToString());
        //        }
        //    }
        //}

        public static DataTable GetDataTableExcel(string strFileName, string Table)
        {
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + strFileName + "; Extended Properties = \"Excel 8.0;HDR=Yes;IMEX=1\";");
            conn.Open();
            string strQuery = "SELECT * FROM [" + Table + "]";
            System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter(strQuery, conn);
            System.Data.DataSet ds = new System.Data.DataSet();
            adapter.Fill(ds);
            return ds.Tables[0];
        }

        ////public static string[] GetTableExcel(string strFileName)
        ////{
        ////    string[] strTables = new string[100];
        ////    Catalog oCatlog = new Catalog();
        ////    ADOX.Table oTable = new ADOX.Table();
        ////    ADODB.Connection oConn = new ADODB.Connection();
        ////    oConn.Open("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + strFileName + "; Extended Properties = \"Excel 8.0;HDR=Yes;IMEX=1\";", "", "", 0);
        ////    oCatlog.ActiveConnection = oConn;
        ////    if (oCatlog.Tables.Count > 0)
        ////    {
        ////        int item = 0;
        ////        foreach (ADOX.Table tab in oCatlog.Tables)
        ////        {
        ////            if (tab.Type == "TABLE")
        ////            {
        ////                strTables[item] = tab.Name;
        ////                item++;
        ////            }
        ////        }
        ////    }
        ////    return strTables;
        ////}

        private void FrmImport_Load(object sender, EventArgs e)
        {

        }
    }
}