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
using System.Data.SqlClient;

namespace Edge
{
    public partial class FrmImportData : Form
    {
        private BindingSource BindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter1 = new SqlDataAdapter();
        public FrmImportData()
        {
            InitializeComponent();
        }

        private void FrmImportData_Load(object sender, EventArgs e)
        {
            this.DGridReal.DataSource = BindingSource1;
            //DGridReal.AutoGenerateColumns = false;
            oLoadSchName();
            MyModules.applyGridTheme(DGridReal);
            DGridReal.ReadOnly = false;
            DGridReal.AllowUserToAddRows = false;
        }

        private void cmdGetFile_Click(object sender, EventArgs e)
        {
            try
            {
                Dgrid.DataSource = null;
                Dgrid.Rows.Clear();
                Dgrid.Columns.Clear();

                OpenFileDialog openFileDialog1 = new OpenFileDialog();  //create openfileDialog Object
                openFileDialog1.Filter = "XML Files (*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb) |*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb";//open file format define Excel Files(.xls)|*.xls| Excel Files(.xlsx)|*.xlsx| 
                openFileDialog1.FilterIndex = 3;

                openFileDialog1.Multiselect = false;        //not allow multiline selection at the file selection level
                openFileDialog1.Title = "Select file";   //define the name of openfileDialog
                openFileDialog1.InitialDirectory = @"Desktop"; //define the initial directory
                cboSheet.Items.Clear();

                if (openFileDialog1.ShowDialog() == DialogResult.OK)        //executing when file open
                {
                    string pathName = openFileDialog1.FileName;
                    string fileName = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                    DataTable tbContainer = new DataTable();
                    string strConn = string.Empty;
                    txtFileName.Tag = fileName;
                    txtFileName.Text = pathName;
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

                    this.Tag = strConn;

                    GetExcelSheetNames(pathName, strConn);

                    Import(this.Tag.ToString(), txtFileName.Text, cboSheet.Text.ToString());

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void Import(string connString,string sheetName,string dSheetName)
        {
            try
            {
                Dgrid.DataSource = null;
                Dgrid.Rows.Clear();
                Dgrid.Columns.Clear();

                DataTable tbContainer = new DataTable();
                OleDbConnection cnnxls = new OleDbConnection(connString);
                //  OleDbDataAdapter oda = new OleDbDataAdapter(string.Format("select * from [{0}$]", sheetName), cnnxls);
                OleDbDataAdapter oda = new OleDbDataAdapter(string.Format("select * from [" + dSheetName + "]", sheetName), cnnxls);

                oda.Fill(tbContainer);

                Dgrid.DataSource = tbContainer;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void GetExcelSheetNames(string excelFile, string connString)
        {
            OleDbConnection objConn = null;
            System.Data.DataTable dt = null;

            try
            {
                Dgrid.DataSource = null;
                cboSheet.Items.Clear();
                cboSheet.Text = "";

      objConn = new OleDbConnection(connString);
                objConn.Open();
                dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if (dt == null)
                {
                    return;
                }

                String[] excelSheets = new String[dt.Rows.Count];
                int i = 0;

                // Add the sheet name to the string array.
                foreach (DataRow row in dt.Rows)
                {
                    cboSheet.Items.Add(row["TABLE_NAME"].ToString());
                    i++;
                }

                // Loop through all of the sheets if you want too...
                for (int j = 0; j < excelSheets.Length; j++)
                {
                    // Query each excel sheet.
                }
                cboSheet.SelectedIndex = 0;
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                // Clean up.
                if (objConn != null)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
                if (dt != null)
                {
                    dt.Dispose();
                }
            }
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            Import(this.Tag.ToString(), txtFileName.Text, cboSheet.Text.ToString());
        }

        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Dgrid.DataSource = null;
            //Dgrid.Rows.Clear();
            //Dgrid.Columns.Clear();
            cmdLoad_Click(sender, e);
        }

        private void RadStudent_CheckedChanged(object sender, EventArgs e)
        {
            panel3.Visible = true;
            if (RadStudent.Checked)
                lblGrp.Text = "School";
            oLoadSchName();
            {
                LoadRealData(" RegisterStudent.SchoolID = " + MyModules.GetIt4Me(cGrp.Text, " - "));
            }
        }

        private void RadSchool_CheckedChanged(object sender, EventArgs e)
        {
            panel3.Visible = false;
            if (RadSchool.Checked)
            {
                LoadRealData("");
            }
        }

        private void RadVendor_CheckedChanged(object sender, EventArgs e)
        {
            panel3.Visible = false;
            if (RadVendor.Checked)
            {
                LoadRealData("");
            }
        }

        private void oLoadSchName()
        {
            try
            {
                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;
                SqlDataReader drSQL = null;
                cGrp.Items.Clear();
                cmSQL.CommandText = "SELECT DISTINCT SchoolID,SchName FROM RegisterStudent UNION SELECT DISTINCT Sn AS SchoolID,SchName FROM RegisterSchool WHERE SchName NOT IN (SELECT SchName FROM RegisterStudent) ORDER BY [SchName]";

                cmSQL.CommandType = CommandType.Text;

                cnSQL.Open();
               drSQL = cmSQL.ExecuteReader();

                while (drSQL.Read())
                {
                    cGrp.Items.Add(drSQL["SchoolID"] + " - " + MyModules.ChkNull(drSQL["SchName"]));
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

        private void cSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (panel3.Visible == true && RadStudent.Checked)
                LoadRealData(" RegisterStudent.SchoolID = " + MyModules.GetIt4Me(cGrp.Text, " - "));
            if (panel3.Visible == true && radStaff.Checked)
                LoadRealData(" RegisterVendor.Category = '" + cGrp.Text +"'");
        }
        private void LoadRealData(string strQ)
        {
            string str = "";
            //if (strQ == "" || strQ == null)
            //    return;
            try
            {
                //strQryMain = strQ;
                DGridReal.DataSource = null;
                DGridReal.Rows.Clear();
                DGridReal.Columns.Clear();
                lblListCount.Text = "List Count:0" ;
                if (RadStudent.Checked==true )
                {
                    if (cGrp.Text == "") strQ="";
                        if (strQ == "")
                    {
                        str = "SELECT RegisterStudent.Sn AS [RefNo],[Name], [SchoolID],SchName, [Degree],[CourseOfStudy] AS [Course Of Study],[StartYear],[EndYear],[LGA],RegisterStudent.State AS [State of Origin],RegisterStudent.Address AS [Student Address],RegisterStudent.Telephone,RegisterStudent.EmailAddress AS [Email Address],RegisterStudent.BankName,RegisterStudent.BankAcctNo,RegisterStudent.BankCode AS [Bank Code],RegisterStudent.BankAddress AS [Bank Address],[IDNo],RegisterStudent.Remark,RegisterStudent.InActive FROM RegisterStudent ORDER BY [Name]";
                    }
                    else
                    {
                        str = "SELECT RegisterStudent.Sn AS [RefNo],[Name], [SchoolID],SchName, [Degree],[CourseOfStudy] AS [Course Of Study],[StartYear],[EndYear],[LGA],RegisterStudent.State AS [State of Origin],RegisterStudent.Address AS [Student Address],RegisterStudent.Telephone,RegisterStudent.EmailAddress AS [Email Address],RegisterStudent.BankName,RegisterStudent.BankAcctNo,RegisterStudent.BankCode AS [Bank Code],RegisterStudent.BankAddress AS [Bank Address],[IDNo],RegisterStudent.Remark,RegisterStudent.InActive FROM RegisterStudent WHERE " + strQ + " ORDER BY [Name]";
                    }
                }
                if (RadSchool.Checked == true)
                {
                     str = "SELECT [Sn] AS [RefNo],[SchName] AS [Name] , [SchAddress] AS [School Address] ,[State],[EmailAddress] AS [Email Address] ,[Telephone] ,[BankName],[BankAcctNo],[BankCode] AS [Bank Code],[BankAddress] AS [Bank Address],[IDNo],[Remark],[InActive] FROM RegisterSchool ORDER BY [SchName]";
                 }
                if (RadVendor.Checked == true)
                {

                    str = "SELECT [Sn] AS [RefNo],[Name] ,[TINNo],[Address],[EmailAddress] AS [Email Address] ,[Telephone] ,[BankName],[BankAcctNo],[BankCode] AS [Bank Code],[BankAddress] AS [Bank Address],[IDNo],[Remark],[InActive] FROM RegisterVendor WHERE Source<>'STAFF' ORDER BY [Name]";

                }
                if (radStaff.Checked == true)
                {

                    if (cGrp.Text == "") strQ="";
                    if (strQ == "")
                    {
                        str = "SELECT [Sn] AS [RefNo],[Name] ,Category,[TINNo],[Address],[EmailAddress] AS [Email Address] ,[Telephone] ,[BankName],[BankAcctNo],[BankCode] AS [Bank Code],[BankAddress] AS [Bank Address],[IDNo],[Remark],[InActive] FROM RegisterVendor WHERE Source='STAFF' ORDER BY [Name]";
                    }
                    else
                    {
                        str = "SELECT [Sn] AS [RefNo],[Name],Category ,[TINNo],[Address],[EmailAddress] AS [Email Address] ,[Telephone] ,[BankName],[BankAcctNo],[BankCode] AS [Bank Code],[BankAddress] AS [Bank Address],[IDNo],[Remark],[InActive] FROM RegisterVendor WHERE Source='STAFF' AND " + strQ + " ORDER BY [Name]";

                    }

                }

                //DataTable tbContainer = new DataTable();
                //SqlConnection cnnxls = new SqlConnection(MyModules.strConnect);
                //SqlDataAdapter oda = new SqlDataAdapter(str, cnnxls);

                //oda.Fill(tbContainer);
                //DGridReal.DataSource = tbContainer;

                dataAdapter1 = new SqlDataAdapter(str, MyModules.strConnect);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(this.dataAdapter1);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                this.dataAdapter1.Fill(table);
                this.BindingSource1.DataSource = table;

                DGridReal.DataSource = table;
                DGridReal.AllowUserToDeleteRows = true;
                lblListCount.Text = "List Count:" + DGridReal.RowCount.ToString();

                if (RadStudent.Checked == true)
                {
                    DGridReal.Columns["RefNo"].Visible = false;
                    DGridReal.Columns["SchoolID"].Visible = false;
                    //DGridReal.Columns["Remark"].Visible = false;
                    DGridReal.Columns["InActive"].Visible = false;
                }
                if (RadSchool.Checked == true)
                {
                    DGridReal.Columns["RefNo"].Visible = false;
                    //DGridReal.Columns["Remark"].Visible = false;
                    DGridReal.Columns["InActive"].Visible = false;
                }
                if (RadVendor.Checked == true)
                {
                    DGridReal.Columns["RefNo"].Visible = false;
                    //DGridReal.Columns["Remark"].Visible = false;
                    DGridReal.Columns["InActive"].Visible = false;
                }
                if (radStaff.Checked == true)
                {
                    DGridReal.Columns["RefNo"].Visible = false;
                    //DGridReal.Columns["Remark"].Visible = false;
                    DGridReal.Columns["InActive"].Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
  

    }

        private void cmdUpload_Click(object sender, EventArgs e)
        {
            try
            {

                if (RadStudent.Checked == true)
                {
                    if (Dgrid.Columns.Count != DGridReal.Columns.Count-3)
                    {
                        MessageBox.Show("Invalid Column Mapping", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    if (Dgrid.Columns.Count != DGridReal.Columns.Count-2)
                    {
                        MessageBox.Show("Invalid Column Mapping", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                if (cGrp.Text == "" && RadStudent.Checked == true)
                {
                    MessageBox.Show("Please select school", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (Dgrid.RowCount < 1)
                {
                    MessageBox.Show("No record to upload", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SqlTransaction myTrans = null;
                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;
                cnSQL.Open();


                if (RadStudent.Checked == true)
                {

                    myTrans = cnSQL.BeginTransaction();
                    cmSQL.Transaction = myTrans;
                    for (int i = 0; i < Dgrid.RowCount - 1; i++)
                    {
                        cmSQL.Parameters.Clear();
                        cmSQL.CommandText = "InsertRegisterStudent";
                        cmSQL.CommandType = CommandType.StoredProcedure;
                        cmSQL.Parameters.AddWithValue("@Sn", 0);

                        cmSQL.Parameters.AddWithValue("@Name", ((Dgrid[0, i].Value == null) ? "" : Dgrid[0, i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@Address", ((Dgrid[8, i].Value == null) ? "" : Dgrid[8, i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@State", ((Dgrid[7, i].Value == null) ? "" : Dgrid[7, i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@EmailAddress", ((Dgrid[10, i].Value == null) ? "" : Dgrid[10, i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@Telephone", ((Dgrid[9, i].Value == null) ? "" : Dgrid[9, i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@BankName", ((Dgrid[11, i].Value == null) ? "" : Dgrid[11, i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@BankAcctNo", ((Dgrid[12, i].Value == null) ? "" : Dgrid[12, i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@BankCode", ((Dgrid[13, i].Value == null) ? "" : Dgrid[13, i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@BankAddress", ((Dgrid[14, i].Value == null) ? "" : Dgrid[14, i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@Remark", ((Dgrid["Remark", i].Value == null) ? "Uploaded" : Dgrid["Remark", i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@InActive", false);
                        cmSQL.Parameters.AddWithValue("@SchoolID", MyModules.GetIt4Me(cGrp.Text, " - "));
                        cmSQL.Parameters.AddWithValue("@Degree", ((Dgrid[2, i].Value == null) ? "" : Dgrid[2, i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@CourseOfStudy", ((Dgrid[3, i].Value == null) ? "" : Dgrid[3, i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@StartYear", ((Dgrid[4, i].Value == null) ? "0" : Convert.ToInt16(Dgrid[4, i].Value).ToString()));
                        cmSQL.Parameters.AddWithValue("@EndYear", ((Dgrid[5, i].Value == null) ? "0" : Convert.ToInt16(Dgrid[5, i].Value).ToString()));
                        cmSQL.Parameters.AddWithValue("@LGA", ((Dgrid[6, i].Value == null) ? "" : Dgrid[6, i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@SchName", MyModules.Mid(cGrp.Text, Microsoft.VisualBasic.Strings.Len(MyModules.GetIt4Me(cGrp.Text, " - ")) + 3, -1));
                        cmSQL.Parameters.AddWithValue("@IDNo", ((Dgrid["IDNo", i].Value == null) ? "" : Dgrid["IDNo", i].Value).ToString().ToUpper());

                        cmSQL.ExecuteNonQuery();

                    }
                }
                    if (RadSchool.Checked == true)
                    {

                        myTrans = cnSQL.BeginTransaction();
                        cmSQL.Transaction = myTrans;
                        for (int i = 0; i < Dgrid.RowCount - 1; i++)
                        {
                            cmSQL.Parameters.Clear();



                            cmSQL.CommandText = "InsertRegisterSchool";
                            cmSQL.CommandType = CommandType.StoredProcedure;
                            cmSQL.Parameters.AddWithValue("@Sn", 0);
                         
                            cmSQL.Parameters.AddWithValue("@SchName", ((Dgrid[0, i].Value == null) ? "" : Dgrid[0, i].Value).ToString().ToUpper());
                            cmSQL.Parameters.AddWithValue("@SchAddress", ((Dgrid[1, i].Value == null) ? "" : Dgrid[1, i].Value).ToString().ToUpper());
                            cmSQL.Parameters.AddWithValue("@State", ((Dgrid[2, i].Value == null) ? "" : Dgrid[2, i].Value).ToString().ToUpper());
                            cmSQL.Parameters.AddWithValue("@EmailAddress", ((Dgrid[3, i].Value == null) ? "" : Dgrid[3, i].Value).ToString().ToUpper());
                            cmSQL.Parameters.AddWithValue("@Telephone", ((Dgrid[4, i].Value == null) ? "" : Dgrid[4, i].Value).ToString().ToUpper());
                            cmSQL.Parameters.AddWithValue("@BankName", ((Dgrid[5, i].Value == null) ? "" : Dgrid[5, i].Value).ToString().ToUpper());
                            cmSQL.Parameters.AddWithValue("@BankAcctNo", ((Dgrid[6, i].Value == null) ? "" : Dgrid[6, i].Value).ToString().ToUpper());
                            cmSQL.Parameters.AddWithValue("@BankCode", ((Dgrid[7, i].Value == null) ? "" : Dgrid[7, i].Value).ToString().ToUpper());
                            cmSQL.Parameters.AddWithValue("@BankAddress", ((Dgrid[8, i].Value == null) ? "" : Dgrid[8, i].Value).ToString().ToUpper());
                            cmSQL.Parameters.AddWithValue("@Remark",  ((Dgrid["Remark", i].Value == null) ? "Uploaded" : Dgrid["Remark", i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@InActive", false);
                            cmSQL.Parameters.AddWithValue("@IDNo", ((Dgrid["IDNo", i].Value == null) ? "" : Dgrid["IDNo", i].Value).ToString().ToUpper());

                            cmSQL.ExecuteNonQuery();
                           
                        }
                    }

                    if (RadVendor.Checked == true)
                    {

                        myTrans = cnSQL.BeginTransaction();
                        cmSQL.Transaction = myTrans;
                        for (int i = 0; i < Dgrid.RowCount - 1; i++)
                        {
                            cmSQL.Parameters.Clear();
                            cmSQL.CommandText = "InsertRegisterVendor";
                            cmSQL.CommandType = CommandType.StoredProcedure;
                            cmSQL.Parameters.AddWithValue("@Sn", 0);
                            cmSQL.Parameters.AddWithValue("@Name", ((Dgrid[0, i].Value == null) ? "" : Dgrid[0, i].Value).ToString().ToUpper());
                            cmSQL.Parameters.AddWithValue("@Address", ((Dgrid[2, i].Value == null) ? "" : Dgrid[2, i].Value).ToString().ToUpper());
                            cmSQL.Parameters.AddWithValue("@TINNo", ((Dgrid[1, i].Value == null) ? "" : Dgrid[1, i].Value).ToString().ToUpper());
                            cmSQL.Parameters.AddWithValue("@EmailAddress", ((Dgrid[3, i].Value == null) ? "" : Dgrid[3, i].Value).ToString().ToUpper());
                            cmSQL.Parameters.AddWithValue("@Telephone", ((Dgrid[4, i].Value == null) ? "" : Dgrid[4, i].Value).ToString().ToUpper());
                            cmSQL.Parameters.AddWithValue("@BankName", ((Dgrid[5, i].Value == null) ? "" : Dgrid[5, i].Value).ToString().ToUpper());
                            cmSQL.Parameters.AddWithValue("@BankAcctNo", ((Dgrid[6, i].Value == null) ? "" : Dgrid[6, i].Value).ToString().ToUpper());
                            cmSQL.Parameters.AddWithValue("@BankCode", ((Dgrid[7, i].Value == null) ? "" : Dgrid[7, i].Value).ToString().ToUpper());
                            cmSQL.Parameters.AddWithValue("@BankAddress", ((Dgrid[8, i].Value == null) ? "" : Dgrid[8, i].Value).ToString().ToUpper());
                            cmSQL.Parameters.AddWithValue("@Remark", ((Dgrid["Remark", i].Value == null) ? "Uploaded" : Dgrid["Remark", i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@Source", "VENDOR");
                            cmSQL.Parameters.AddWithValue("@InActive", false);
                            cmSQL.Parameters.AddWithValue("@Category", "");
                            cmSQL.Parameters.AddWithValue("@IDNo", ((Dgrid["IDNo", i].Value == null) ? "" : Dgrid["IDNo", i].Value).ToString().ToUpper());
                             cmSQL.ExecuteNonQuery();
                
                        }
                    }

                    if (radStaff.Checked == true)
                    {

                        myTrans = cnSQL.BeginTransaction();
                        cmSQL.Transaction = myTrans;
                        for (int i = 0; i < Dgrid.RowCount - 1; i++)
                        {
                            cmSQL.Parameters.Clear();
                            cmSQL.CommandText = "InsertRegisterVendor";
                            cmSQL.CommandType = CommandType.StoredProcedure;
                            cmSQL.Parameters.AddWithValue("@Sn", 0);
                            cmSQL.Parameters.AddWithValue("@Name", ((Dgrid[0, i].Value == null) ? "" : Dgrid[0, i].Value).ToString().ToUpper());
                            cmSQL.Parameters.AddWithValue("@Address", ((Dgrid[3, i].Value == null) ? "" : Dgrid[3, i].Value).ToString().ToUpper());
                            cmSQL.Parameters.AddWithValue("@TINNo", ((Dgrid[2, i].Value == null) ? "" : Dgrid[2, i].Value).ToString().ToUpper());
                            cmSQL.Parameters.AddWithValue("@EmailAddress", ((Dgrid[4, i].Value == null) ? "" : Dgrid[4, i].Value).ToString().ToUpper());
                            cmSQL.Parameters.AddWithValue("@Telephone", ((Dgrid[5, i].Value == null) ? "" : Dgrid[5, i].Value).ToString().ToUpper());
                            cmSQL.Parameters.AddWithValue("@BankName", ((Dgrid[6, i].Value == null) ? "" : Dgrid[6, i].Value).ToString().ToUpper());
                            cmSQL.Parameters.AddWithValue("@BankAcctNo", ((Dgrid[7, i].Value == null) ? "" : Dgrid[7, i].Value).ToString().ToUpper());
                            cmSQL.Parameters.AddWithValue("@BankCode", ((Dgrid[8, i].Value == null) ? "" : Dgrid[8, i].Value).ToString().ToUpper());
                            cmSQL.Parameters.AddWithValue("@BankAddress", ((Dgrid[9, i].Value == null) ? "" : Dgrid[9, i].Value).ToString().ToUpper());
                            cmSQL.Parameters.AddWithValue("@Remark", ((Dgrid["Remark", i].Value == null) ? "Uploaded" : Dgrid["Remark", i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@Source", "STAFF");
                            cmSQL.Parameters.AddWithValue("@InActive", false);
                            cmSQL.Parameters.AddWithValue("@Category", ((Dgrid[1, i].Value == null) ? "" : Dgrid[1, i].Value).ToString().ToUpper());
                            cmSQL.Parameters.AddWithValue("@IDNo", ((Dgrid["IDNo", i].Value == null) ? "" : Dgrid["IDNo", i].Value).ToString().ToUpper());

                        cmSQL.ExecuteNonQuery();
                            //                str = "SELECT [Sn] AS [RefNo],[Name]0 ,[TINNo]1,[Address]2,[EmailAddress]3 AS [Email Address]
                            //                    ,[Telephone]4 ,[BankName]5,[BankAcctNo]6,[BankCode]7 AS [Bank Code],[BankAddress] 8AS [Bank Address],
                            //[Remark],[InActive] FROM RegisterVendor ORDER BY [Name]";

                        }
                    }

                myTrans.Commit();

                if (RadStudent.Checked)
                {
                    LoadRealData(" RegisterStudent.SchoolID = " + MyModules.GetIt4Me(cGrp.Text, " - "));
                }
                else
                {
                    LoadRealData("");
                }
                MessageBox.Show("Successfull!", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("Violation of PRIMARY KEY constraint"))
                {
                    MessageBox.Show("Duplicate record exist", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // myTrans.Rollback();
                }
                else
                    MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void Dgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Dgrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Dgrid.Tag = Dgrid.Columns[e.ColumnIndex].Name;
            }
            catch
            {

            }
        }

        private void mnuRemoveColumn_Click(object sender, EventArgs e)
        {
            try
            {
                Dgrid.Columns.Remove(Dgrid.Tag.ToString());
                        }
            catch
            {

            }
        }

        private void mnuAddColumn_Click(object sender, EventArgs e)
        {
            try
            {
                String value = "";
                DataGridViewColumn dtCol = new DataGridViewColumn();
                if (MyModules.InputBox("Insert Column", "Enter Column Name:", ref value, false) == DialogResult.OK)
                {
                    if (value != "") dtCol.HeaderText = value;

                }

                // dtCol.Name = "ID_New";

                dtCol.CellTemplate = new DataGridViewTextBoxCell();
                Dgrid.Columns.Insert(Dgrid.Columns[Dgrid.Tag.ToString()].Index+1, dtCol);
            }
            catch
            {

            }
        }

        private void mnuInsertColumn_Click(object sender, EventArgs e)
        {
            try
            {
                String value = "";
                DataGridViewColumn dtCol = new DataGridViewColumn();
                if (MyModules.InputBox("Insert Column", "Enter Column Name:", ref value, false) == DialogResult.OK)
                {
                    if (value != "") dtCol.HeaderText = value;
                  
                }

                // dtCol.Name = "ID_New";
               
                dtCol.CellTemplate = new DataGridViewTextBoxCell();
                Dgrid.Columns.Insert(Dgrid.Columns[Dgrid.Tag.ToString()].Index, dtCol);
            }
            catch
            {

            }
        }

        private void radStaff_CheckedChanged(object sender, EventArgs e)
        {
            panel3.Visible = true;
            if (radStaff.Checked)
                lblGrp.Text = "Category";
                oLoadCategory();
            {
                LoadRealData(" RegisterVendor.Category = " + cGrp.Text);
            }
        }

  

        private void lnkUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dataAdapter1.Update((DataTable)BindingSource1.DataSource);
            MessageBox.Show("Update successfull", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
