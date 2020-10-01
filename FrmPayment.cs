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
using System.IO;

namespace Edge
{
    public partial class FrmPayment : Form
    {
        private BindingSource BindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter1 = new SqlDataAdapter();
        String LastMandateNo = "";
        bool DGVhasChanged = false;
        private String MandateNo;
        int dIndex = -1;
        string strQryMain;
        int ReturnCode;
        public FrmPayment(String MandateNo1, int dIndex1)
        {
            InitializeComponent();
            MandateNo = "";
            MandateNo = MandateNo1;
            dIndex = dIndex1;
        }

        private void FrmPayment_Load(object sender, EventArgs e)
        {
            try
            {

              

                MyModules.applyGridTheme(DGridList);
                DGridList.AllowUserToDeleteRows = true;
                cmdBeneficiary.SelectedIndex = 2;
                tMandateNo.Tag = 0;

                chkWrap.Checked = true;
                //DGridList.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //DGridList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


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


                cboBudgetLine.Items.Add(Properties.Settings.Default.BudgetLine.ToString());
                cboBudgetLine.Text = Properties.Settings.Default.BudgetLine.ToString();

                LoadInterventionLine();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void cmdBeneficiary_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbCriteria.Items.Clear();
            TVList.Nodes.Clear();
            lvList.Items.Clear();
            switch (cmdBeneficiary.Text)
            {
                case "STUDENT":
                    CmbCriteria.Items.Add("Bank");
                    CmbCriteria.Items.Add("Degree");
                    CmbCriteria.Items.Add("EndYear");
                    CmbCriteria.Items.Add("School");
                    CmbCriteria.Items.Add("State of Origin");
                    CmbCriteria.Items.Add("Category");
                    CmbCriteria.SelectedIndex = 4;
                    break;
                case "SCHOOL":
                    CmbCriteria.Items.Add("State");
                    CmbCriteria.Items.Add("Category");
                    CmbCriteria.Items.Add("Region");
                    CmbCriteria.SelectedIndex = 0;
                    break;
                case "VENDOR":
                    CmbCriteria.Items.Add("Category");
                    CmbCriteria.SelectedIndex = 0;
                    break;
                case "STAFF":
                    CmbCriteria.Items.Add("Category");
                    CmbCriteria.SelectedIndex = 0;
                    break;

            }

        }


        private void LoadTV(string dChoice)
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
                if (cmdBeneficiary.Text == "STUDENT")
                {
                    switch (dChoice)
                    {
                        case "State of Origin":
                            str = "SELECT DISTINCT [State] AS dText FROM RegisterStudent WHERE RegisterStudent.InActive=0 or RegisterStudent.InActive IS NULL";
                            break;
                        case "Bank":
                            str = "SELECT DISTINCT [BankName] AS dText FROM RegisterStudent WHERE RegisterStudent.InActive=0 or RegisterStudent.InActive IS NULL";
                            break;
                        case "Degree":
                            str = "SELECT DISTINCT [Degree] AS dText FROM RegisterStudent WHERE RegisterStudent.InActive=0 or RegisterStudent.InActive IS NULL";
                            break;
                        case "EndYear":
                            str = "SELECT DISTINCT [EndYear] AS dText FROM RegisterStudent WHERE RegisterStudent.InActive=0 or RegisterStudent.InActive IS NULL";
                            break;
                        case "School":
                            // str = "SELECT DISTINCT Cast([SchoolID] AS nvarchar(50)) + ' - ' + [SchName] AS dText  FROM RegisterStudent LEFT OUTER JOIN RegisterSchool ON RegisterStudent.SchoolID = RegisterSchool.Sn WHERE RegisterStudent.InActive=0 or RegisterStudent.InActive IS NULL";
                            str = "SELECT DISTINCT Cast([SchoolID] AS nvarchar(50)) + ' - ' + [SchName] AS dText,SchName  FROM RegisterStudent WHERE RegisterStudent.InActive=0 or RegisterStudent.InActive IS NULL ORDER BY [SchName]";
                            break;
                        case "Category":
                            str = "SELECT DISTINCT [Category] AS dText FROM RegisterStudent WHERE RegisterStudent.InActive=0 or RegisterStudent.InActive IS NULL";
                            break;

                    }

                }
                if (cmdBeneficiary.Text == "SCHOOL")
                    switch (dChoice)
                    {
                        case "Category":
                            str = "SELECT DISTINCT [Category] AS dText FROM RegisterSchool WHERE RegisterSchool.InActive=0 or RegisterSchool.InActive IS NULL";
                            break;
                        case "Region":
                            str = "SELECT DISTINCT [Region] AS dText FROM RegisterSchool WHERE RegisterSchool.InActive=0 or RegisterSchool.InActive IS NULL";
                            break;
                        case "State":
                            str = "SELECT DISTINCT [State] AS dText FROM RegisterSchool WHERE RegisterSchool.InActive=0 or RegisterSchool.InActive IS NULL";
                            break;
                    }
                if (cmdBeneficiary.Text == "STAFF")
                    str = "SELECT DISTINCT [Category] FROM RegisterVendor WHERE Source='STAFF' AND (InActive=0 or InActive IS NULL)";
                if (cmdBeneficiary.Text == "VENDOR")
                    str = "SELECT DISTINCT [Category] FROM RegisterVendor WHERE Source<>'STAFF' AND (InActive=0 or InActive IS NULL)";
                TVList.Nodes.Clear();
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
                        TVList.Nodes.Add(drSQL[0].ToString(), drSQL[0].ToString());
                        //TVList.EndUpdate();
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

        public void LoadLvList(string strQ)
        {
            string str = "";
            if (strQ == "" || strQ == null)
                return;
            try
            {
                strQryMain = strQ;


                if (cmdBeneficiary.Text == "STUDENT")
                {
                    if (strQ == "<ALL>")
                    {
                        // str = "SELECT RegisterStudent.Sn AS [RefNo],[Name], [SchoolID],RegisterSchool.SchName, [Degree],[CourseOfStudy] AS [Course Of Study],[StartYear],[EndYear],RegisterStudent.State AS [State of Origin],[LGA],RegisterStudent.Address,RegisterStudent.EmailAddress AS [Email Address],RegisterStudent.Telephone,RegisterStudent.BankName,RegisterStudent.BankAcctNo,RegisterStudent.BankCode AS [Bank Code],RegisterStudent.BankAddress AS [Bank Address] ,RegisterStudent.Remark,RegisterStudent.InActive FROM RegisterStudent LEFT OUTER JOIN RegisterSchool ON RegisterStudent.SchoolID = RegisterSchool.Sn WHERE RegisterStudent.InActive=0 or RegisterStudent.InActive IS NULL";
                        str = "SELECT RegisterStudent.Sn AS [RefNo],IDNo,[Name], [SchoolID],SchName, [Degree],[CourseOfStudy] AS [Course Of Study],[StartYear],[EndYear],RegisterStudent.State AS [State of Origin],[LGA],RegisterStudent.Address,RegisterStudent.EmailAddress AS [Email Address],RegisterStudent.Telephone,RegisterStudent.BankName,RegisterStudent.BankAcctNo,RegisterStudent.BankCode AS [Bank Code],RegisterStudent.BankAddress AS [Bank Address] ,RegisterStudent.Remark,RegisterStudent.InActive FROM RegisterStudent WHERE RegisterStudent.InActive=0 or RegisterStudent.InActive IS NULL ORDER BY [Name]";
                    }
                    else
                    {
                        //str = "SELECT RegisterStudent.Sn AS [RefNo],[Name] , [SchoolID],RegisterSchool.SchName  , [Degree],[CourseOfStudy] AS [Course Of Study],[StartYear],[EndYear],RegisterStudent.State AS [State of Origin],[LGA],RegisterStudent.Address,RegisterStudent.EmailAddress AS [Email Address],RegisterStudent.Telephone ,RegisterStudent.BankName,RegisterStudent.BankAcctNo,RegisterStudent.BankCode AS [Bank Code],RegisterStudent.BankAddress AS [Bank Address] ,RegisterStudent.Remark,RegisterStudent.InActive FROM RegisterStudent LEFT OUTER JOIN RegisterSchool ON RegisterStudent.SchoolID = RegisterSchool.Sn WHERE (RegisterStudent.InActive=0 or RegisterStudent.InActive IS NULL) AND " + strQ;
                        str = "SELECT RegisterStudent.Sn AS [RefNo],IDNo,[Name] , [SchoolID],SchName, [Degree],[CourseOfStudy] AS [Course Of Study],[StartYear],[EndYear],RegisterStudent.State AS [State of Origin],[LGA],RegisterStudent.Address,RegisterStudent.EmailAddress AS [Email Address],RegisterStudent.Telephone ,RegisterStudent.BankName,RegisterStudent.BankAcctNo,RegisterStudent.BankCode AS [Bank Code],RegisterStudent.BankAddress AS [Bank Address] ,RegisterStudent.Remark,RegisterStudent.InActive FROM RegisterStudent WHERE (RegisterStudent.InActive=0 or RegisterStudent.InActive IS NULL) AND " + strQ + " ORDER BY [Name]";
                    }
                }
                if (cmdBeneficiary.Text == "SCHOOL")
                {
                    if (strQ == "<ALL>")
                    {
                        str = "SELECT [Sn] AS [RefNo],IDNo,[SchName] AS [Name] ,'' AS SchName,'' AS TINNo, [SchAddress] AS [School Address] ,[State],[EmailAddress] AS [Email Address] ,[Telephone] ,[BankName],[BankAcctNo],[BankCode] AS [Bank Code],[BankAddress] AS [Bank Address],[Remark],[InActive] FROM RegisterSchool WHERE RegisterSchool.InActive=0 or RegisterSchool.InActive IS NULL ORDER BY [SchName]";
                    }
                    else
                    {
                        str = "SELECT [Sn] AS [RefNo],IDNo,[SchName] AS [Name],'' AS SchName ,'' AS TINNo,[SchAddress] AS [School Address] ,[State],[EmailAddress] AS [Email Address] ,[Telephone] ,[BankName],[BankAcctNo],[BankCode] AS [Bank Code],[BankAddress] AS [Bank Address],[Remark],[InActive] FROM RegisterSchool WHERE (RegisterSchool.InActive=0 or RegisterSchool.InActive IS NULL) AND " + strQ + " ORDER BY [SchName]";
                    }
                }
                if (cmdBeneficiary.Text == "VENDOR")
                {
                    if (strQ == "<ALL>")
                    {
                        str = "SELECT [Sn] AS [RefNo],IDNo,[Name],'' AS SchName ,[TINNo],[Address],[EmailAddress] AS [Email Address] ,[Telephone] ,[BankName],[BankAcctNo],[BankCode] AS [Bank Code],[BankAddress] AS [Bank Address],[Remark],[InActive] FROM RegisterVendor WHERE Source<>'STAFF' AND RegisterVendor.InActive=0 or RegisterVendor.InActive IS NULL ORDER BY [Name]";
                    }
                    else
                    {
                        str = "SELECT [Sn] AS [RefNo],IDNo,[Name],'' AS SchName ,[TINNo],[Address],[EmailAddress] AS [Email Address] ,[Telephone] ,[BankName],[BankAcctNo],[BankCode] AS [Bank Code],[BankAddress] AS [Bank Address],[Remark],[InActive] FROM RegisterVendor WHERE Source<>'STAFF' AND  (RegisterVendor.InActive=0 or RegisterVendor.InActive IS NULL) AND " + strQ + " ORDER BY [Name]";
                    }
                }
                if (cmdBeneficiary.Text == "STAFF")
                {
                    if (strQ == "<ALL>")
                    {
                        str = "SELECT [Sn] AS [RefNo],IDNo,[Name],'' AS SchName ,[TINNo],[Address],[EmailAddress] AS [Email Address] ,[Telephone] ,[BankName],[BankAcctNo],[BankCode] AS [Bank Code],[BankAddress] AS [Bank Address],[Remark],[InActive] FROM RegisterVendor WHERE Source='STAFF' AND  RegisterVendor.InActive=0 or RegisterVendor.InActive IS NULL ORDER BY [Name]";
                    }
                    else
                    {
                        str = "SELECT [Sn] AS [RefNo],IDNo,[Name],'' AS SchName ,[TINNo],[Address],[EmailAddress] AS [Email Address] ,[Telephone] ,[BankName],[BankAcctNo],[BankCode] AS [Bank Code],[BankAddress] AS [Bank Address],[Remark],[InActive] FROM RegisterVendor WHERE Source='STAFF' AND  (RegisterVendor.InActive=0 or RegisterVendor.InActive IS NULL) AND " + strQ + " ORDER BY [Name]";
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

                    initialText = drSQL["Name"].ToString();
                    ListViewItem LvItems = new ListViewItem(initialText);
                    LvItems.SubItems.Add(drSQL["RefNo"].ToString());
                    LvItems.SubItems.Add(drSQL["IDNo"].ToString());
                    LvItems.SubItems.Add(drSQL["BankName"].ToString());
                    LvItems.SubItems.Add(drSQL["BankAcctNo"].ToString());


                    if (cmdBeneficiary.Text == "VENDOR" || cmdBeneficiary.Text == "STAFF" || cmdBeneficiary.Text == "SCHOOL")
                        LvItems.SubItems.Add(drSQL["TINNO"].ToString());
                    else
                        LvItems.SubItems.Add(drSQL["SchName"].ToString());

                    LvItems.SubItems.Add(cmdBeneficiary.Text);
                    LvItems.SubItems.Add(drSQL["Remark"].ToString());

                    lvList.Items.AddRange(new ListViewItem[] { LvItems });
                }

                if (cmdBeneficiary.Text == "VENDOR" || cmdBeneficiary.Text == "STAFF" || cmdBeneficiary.Text == "SCHOOL")
                    lvList.Columns[5].Text = "TINNO"; //.Width = 0;
                else
                    lvList.Columns[5].Text = "SCHOOL";
                //lvList.Columns[5].Width = 200;
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
                if (cmdBeneficiary.Text == "STUDENT")
                {
                    switch (CmbCriteria.Text.ToString())
                    {
                        case "State of Origin":
                            strQry = " RegisterStudent.State = '" + e.Node.Text + "'";
                            break;
                        case "Bank":
                            strQry = " RegisterStudent.BankName = '" + e.Node.Text + "'";
                            break;
                        case "Degree":
                            strQry = " RegisterStudent.Degree = '" + e.Node.Text + "'";
                            break;
                        case "EndYear":
                            strQry = " RegisterStudent.EndYear = " + e.Node.Text;
                            break;
                        case "School":
                            strQry = " RegisterStudent.SchoolID = " + MyModules.GetIt4Me(e.Node.Text, " - ");
                            break;
                        case "Category":
                            strQry = " RegisterStudent.Category = '" + e.Node.Text + "'";
                            break;

                    }

                }
                if (cmdBeneficiary.Text == "SCHOOL")
                    switch (CmbCriteria.Text.ToString())
                    {
                        case "Category":
                            strQry = " RegisterSchool.[Category] = '" + e.Node.Text + "'"; break;
                        case "Region":
                            strQry = " RegisterSchool.[Region] = '" + e.Node.Text + "'"; break;
                        case "State":
                            strQry = " RegisterSchool.[State] = '" + e.Node.Text + "'";
                            break;
                    }
                
                //if (cmdBeneficiary.Text == "VENDOR")
                //{
                //    LoadLvList(strQry);
                //    return;
                //}
                if (cmdBeneficiary.Text == "STAFF")
                {
                    strQry = " RegisterVendor.[Category] = '" + e.Node.Text + "'";
                }
                if (cmdBeneficiary.Text == "VENDOR")
                {
                    strQry = " RegisterVendor.[Category] = '" + e.Node.Text + "'";
                }
            }
            LoadLvList(strQry);
        }

        private void CmbCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadTV(CmbCriteria.Text);
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
            string strIN = "";
            for (i = 0; i < lvList.Items.Count; i++)
            {
                if (lvList.Items[i].Checked)
                {
                    strIN = strIN + (string.IsNullOrEmpty(strIN) ? "" : ",") + lvList.Items[i].SubItems[1].Text;
                }
            }
            if (!string.IsNullOrEmpty(strIN))
            {
                oLoadDbgrid(lvList.Items[0].SubItems[6].Text, strIN);
            }

            // Dim i As Integer = 0
            for (i = 0; i < lvList.Items.Count; i++)
            {
                lvList.Items[i].Checked = false;
            }
            chkAll.Checked = false;


        }

        private void oLoadDbgrid(string Source, string strCond)
        {
            try
            {

                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                SqlDataReader drSQL = null;
                cmSQL.Connection = cnSQL;
                cnSQL.Open();
                string strQry1 = "";
                string strQry = "";

                int j = DGridList.Rows.Count - 1;
                int g = 0;
                System.Windows.Forms.DialogResult response;
                if (Source == "STUDENT")
                {
                    //strQry = "SELECT RegisterStudent.*,SchName FROM RegisterStudent LEFT OUTER JOIN RegisterSchool ON RegisterStudent.SchoolID = RegisterSchool.Sn WHERE (RegisterStudent.InActive=0 or RegisterStudent.InActive IS NULL)  AND RegisterStudent.Sn IN (" + strCond + ")";
                    strQry = "SELECT * FROM RegisterStudent  WHERE (RegisterStudent.InActive=0 or RegisterStudent.InActive IS NULL)  AND RegisterStudent.Sn IN (" + strCond + ")";
                    strQry = strQry + strQry1 + " ORDER BY [Name],SchName";

                    cmSQL.CommandText = strQry;
                    cmSQL.CommandType = CommandType.Text;
                    drSQL = cmSQL.ExecuteReader();

                    while (drSQL.Read())
                    {
                        if (CheckIfExist(Source, Convert.ToInt16(drSQL["Sn"])) == true)
                        {
                            response = MessageBox.Show("The Student Beneficiary [" + drSQL["Name"].ToString().ToUpper() + "] Exist....Add (y/n)?", MyModules.strApptitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                            if (response == DialogResult.Cancel)
                            {
                                goto SkipItFinal;
                            }
                            if (response == DialogResult.No)
                            {
                                goto SkipIt;
                            }
                        }

                        DGridList.Rows.Add();
                        g = DGridList.RowCount;
                        j = g - 1;
                        DGridList["RefNo", j].Value = drSQL["Sn"];
                        DGridList["Sn", j].Value = g;
                        DGridList["IDNo", j].Value = drSQL["IDNo"];
                        DGridList["tName", j].Value = drSQL["Name"];
                        DGridList["Amount", j].Value = 0; //Amount
                        DGridList["Bank1", j].Value = drSQL["BankName"];
                        DGridList["Account", j].Value = drSQL["BankAcctNo"];
                        DGridList["BankCode", j].Value = drSQL["BankCode"];
                        DGridList["PayType1", j].Value = "";
                        DGridList["PaymentDetails", j].Value = ""; //paymentDetails2
                        DGridList["SchoolID", j].Value = drSQL["SchoolID"];
                        DGridList["SchName", j].Value = drSQL["SchName"];
                        DGridList["Source", j].Value = Source; //0
                        DGridList["Remark", j].Value = ""; //Remark
                        DGridList["Address", j].Value = drSQL["Address"];
                        DGridList["EmailAddress", j].Value = drSQL["EmailAddress"];
                        DGridList["Telephone", j].Value = drSQL["Telephone"];

                        SkipIt:;
                    }
                    drSQL.Close();
                }
                if (Source == "SCHOOL")
                {
                    strQry = "SELECT * FROM RegisterSchool WHERE (RegisterSchool.InActive=0 or RegisterSchool.InActive IS NULL)  AND RegisterSchool.Sn IN (" + strCond + ")";
                    strQry = strQry + strQry1 + " ORDER BY [SchName]";

                    cmSQL.CommandText = strQry;
                    cmSQL.CommandType = CommandType.Text;
                    drSQL = cmSQL.ExecuteReader();

                    while (drSQL.Read())
                    {
                        if (CheckIfExist(Source, Convert.ToInt16(drSQL["Sn"])) == true)
                        {
                            response = MessageBox.Show("The School Beneficiary [" + drSQL["SchName"].ToString().ToUpper() + "] Exist....Add (y/n)?", MyModules.strApptitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                            if (response == DialogResult.Cancel)
                            {
                                goto SkipItFinal;
                            }
                            if (response == DialogResult.No)
                            {
                                goto SkipIt2;
                            }
                        }

                        DGridList.Rows.Add();
                        g = DGridList.RowCount;
                        j = g - 1;
                        DGridList["RefNo", j].Value = drSQL["Sn"];
                        DGridList["Sn", j].Value = g;
                        DGridList["IDNo", j].Value = drSQL["IDNo"];
                        DGridList["tName", j].Value = drSQL["SchName"];
                        DGridList["Amount", j].Value = 0; //Amount
                        DGridList["Bank1", j].Value = drSQL["BankName"];
                        DGridList["Account", j].Value = drSQL["BankAcctNo"];
                        DGridList["BankCode", j].Value = drSQL["BankCode"];
                        DGridList["PayType1", j].Value = "";
                        DGridList["PaymentDetails", j].Value = ""; //paymentDetails2
                        DGridList["SchoolID", j].Value = "";
                        DGridList["SchName", j].Value = "";
                        DGridList["Source", j].Value = Source; //0
                        DGridList["Remark", j].Value = ""; //Remark
                        DGridList["Address", j].Value = drSQL["SchAddress"];
                        DGridList["EmailAddress", j].Value = drSQL["EmailAddress"];
                        DGridList["Telephone", j].Value = drSQL["Telephone"];
                        SkipIt2:;
                    }
                    drSQL.Close();
                }
                if (Source == "VENDOR")
                {
                    strQry = "SELECT * FROM RegisterVendor WHERE Source<>'STAFF' AND (InActive=0 or InActive IS NULL)  AND Sn IN (" + strCond + ")";
                    strQry = strQry + strQry1 + " ORDER BY [Name]";

                    cmSQL.CommandText = strQry;
                    cmSQL.CommandType = CommandType.Text;
                    drSQL = cmSQL.ExecuteReader();

                    while (drSQL.Read())
                    {
                        if (CheckIfExist(Source, Convert.ToInt16(drSQL["Sn"])) == true)
                        {
                            response = MessageBox.Show("The Vendor Beneficiary [" + drSQL["Name"].ToString().ToUpper() + "] Exist....Add (y/n)?", MyModules.strApptitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                            if (response == DialogResult.Cancel)
                            {
                                goto SkipItFinal;
                            }
                            if (response == DialogResult.No)
                            {
                                goto SkipIt3;
                            }
                        }

                        DGridList.Rows.Add();
                        g = DGridList.RowCount;
                        j = g - 1;
                        DGridList["RefNo", j].Value = drSQL["Sn"];
                        DGridList["Sn", j].Value = g;
                        DGridList["IDNo", j].Value = drSQL["IDNo"];
                        DGridList["tName", j].Value = drSQL["Name"];
                        DGridList["Amount", j].Value = 0; //Amount
                        DGridList["Bank1", j].Value = drSQL["BankName"];
                        DGridList["Account", j].Value = drSQL["BankAcctNo"];
                        DGridList["BankCode", j].Value = drSQL["BankCode"];
                        DGridList["PayType1", j].Value = "";
                        DGridList["PaymentDetails", j].Value = ""; //paymentDetails2
                        DGridList["SchoolID", j].Value = "";
                        DGridList["SchName", j].Value = "";
                        DGridList["Source", j].Value = Source; //0
                        DGridList["Remark", j].Value = ""; //Remark
                        DGridList["Address", j].Value = drSQL["Address"];
                        DGridList["EmailAddress", j].Value = drSQL["EmailAddress"];
                        DGridList["Telephone", j].Value = drSQL["Telephone"];
                        SkipIt3:;
                    }
                    drSQL.Close();

                }
                if (Source == "STAFF")
                {
                    strQry = "SELECT * FROM RegisterVendor WHERE Source='STAFF' AND (InActive=0 or InActive IS NULL)  AND Sn IN (" + strCond + ")";
                    strQry = strQry + strQry1 + " ORDER BY [Name]";

                    cmSQL.CommandText = strQry;
                    cmSQL.CommandType = CommandType.Text;
                    drSQL = cmSQL.ExecuteReader();

                    while (drSQL.Read())
                    {
                        if (CheckIfExist(Source, Convert.ToInt16(drSQL["Sn"])) == true)
                        {
                            response = MessageBox.Show("The Staff Beneficiary [" + drSQL["Name"].ToString().ToUpper() + "] Exist....Add (y/n)?", MyModules.strApptitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                            if (response == DialogResult.Cancel)
                            {
                                goto SkipItFinal;
                            }
                            if (response == DialogResult.No)
                            {
                                goto SkipIt3;
                            }
                        }

                        DGridList.Rows.Add();
                        g = DGridList.RowCount;
                        j = g - 1;
                        DGridList["RefNo", j].Value = drSQL["Sn"];
                        DGridList["Sn", j].Value = g;
                        DGridList["IDNo", j].Value = drSQL["IDNo"];
                        DGridList["tName", j].Value = drSQL["Name"];
                        DGridList["Amount", j].Value = 0; //Amount
                        DGridList["Bank1", j].Value = drSQL["BankName"];
                        DGridList["Account", j].Value = drSQL["BankAcctNo"];
                        DGridList["BankCode", j].Value = drSQL["BankCode"];
                        DGridList["PayType1", j].Value = "";
                        DGridList["PaymentDetails", j].Value = ""; //paymentDetails2
                        DGridList["SchoolID", j].Value = "";
                        DGridList["SchName", j].Value = "";
                        DGridList["Source", j].Value = Source; //0
                        DGridList["Remark", j].Value = ""; //Remark
                        DGridList["Address", j].Value = drSQL["Address"];
                        DGridList["EmailAddress", j].Value = drSQL["EmailAddress"];
                        DGridList["Telephone", j].Value = drSQL["Telephone"];
                        SkipIt3:;
                    }
                    drSQL.Close();

                }

                SkipItFinal:
                //DGridList.Rows(j).Cells(20).Style.BackColor = Color.PaleGoldenrod

                //drSQL.Close()

                cmSQL.Connection.Close();
                cmSQL.Dispose();
                cnSQL.Close();
                cnSQL.Dispose();


                DGridList.Columns["RefNo"].Width = 5;
                DGridList.Columns["Sn"].Width = 40;
                DGridList.Columns["IDNo"].Width = 50;
                DGridList.Columns["tName"].Width = 120;
                DGridList.Columns["Amount"].Width = 80;
                DGridList.Columns["Bank1"].Width = 120;
                DGridList.Columns["Account"].Width = 80;
                DGridList.Columns["BankCode"].Width = 50;
                DGridList.Columns["PayType1"].Width = 120;
                DGridList.Columns["PaymentDetails"].Width = 200;
                DGridList.Columns["Source"].Width = 2;
                DGridList.Columns["Remark"].Width = 120;
                DGridList.Columns["SchoolID"].Width = 2;
                DGridList.Columns["SchName"].Width = 120;
                DGridList.Columns["Address"].Width = 150;

                lblCount.Text = "Payment Count:" + DGridList.Rows.Count.ToString(); // GetCount() + 1

                ////-------------------TO RESTRICT TO LENGHT-----------------------------
                //DataGridViewCellStyle myStyle = new DataGridViewCellStyle();
                //myStyle.ForeColor = Color.Red;

                //int ik = 0;
                //for (ik = 0; ik < DGridList.RowCount; ik++)
                //{
                //    for (var i = 0; i < DGridList.ColumnCount; i++)
                //    {
                //        if ( DGridList[i, ik].Value.ToString().Length > DGridList.Columns[i].FillWeight)
                //        {
                //            DGridList[i, ik].Style = myStyle;
                //            DGridList[i, ik].Value =MyModules.Mid(DGridList[i, ik].Value.ToString(),1,Convert.ToInt16(DGridList.Columns[i].FillWeight));
                //        }
                //    }
                //}

                // DGridList.Columns(6).HeaderText = "Bank Code"

                //DGridList.Focus()
                DGridList.CurrentCell = DGridList.Rows[0].Cells["Amount"];
                DGridList.Focus();

               

                //  MyModules.formatGrid(DGridList);

                  //DGridList.Sort(DGridList.Columns["Sn"], ListSortDirection.Ascending);

                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }



        public bool CheckIfExist(string TheSource, int TheRefNo)
        {
            bool tempCheckIfExist = false;
            try
            {
                tempCheckIfExist = false;
                int d = 0;
                // If TheSource = "STUDENT" Then
                for (d = 0; d < DGridList.RowCount; d++)
                {
                    if (DGridList["Source", d].Value.ToString() == TheSource && TheRefNo == Convert.ToInt16(DGridList["RefNo", d].Value))
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

        private void cmdClear_Click(object sender, EventArgs e)
        {
            DGridList.Rows.Clear();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {



            SqlTransaction myTrans=null; //= new SqlTransaction;
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
                        if (string.IsNullOrEmpty(DGridList["Bank1", i].Value.ToString().Trim(' ')))
                        {
                            MessageBox.Show("Bank not specified", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (string.IsNullOrEmpty(DGridList["Account", i].Value.ToString().Trim(' ')))
                        {
                            MessageBox.Show("AccountNo not specified", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (string.IsNullOrEmpty(DGridList["BankCode", i].Value.ToString().Trim(' ')))
                        {
                            MessageBox.Show("Bank Code not specified", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                    }
                }

                cnSQL.Open();

               

                myTrans = cnSQL.BeginTransaction(IsolationLevel.Serializable);
                cmSQL.Transaction = myTrans;

                cmSQL.Parameters.Clear();
                cmSQL.CommandText = "DeletePayment";
                cmSQL.CommandType = CommandType.StoredProcedure;
                cmSQL.Parameters.AddWithValue("@MandateNo", MandateNo); // tMandateNo.Text);
                cmSQL.ExecuteNonQuery();

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
                        cmSQL.CommandText = "InsertPayment";
                        cmSQL.CommandType = CommandType.StoredProcedure;
                        cmSQL.Parameters.AddWithValue("@PayValueDate", MyModules.FormatDate(dtpDate.Value));
                        cmSQL.Parameters.AddWithValue("@RefNo", ((DGridList["RefNo", i].Value == null) ? "0" : DGridList["RefNo", i].Value));
                        cmSQL.Parameters.AddWithValue("@IDNo", ((DGridList["IDNo", i].Value == null) ? "" : DGridList["IDNo", i].Value));
                        cmSQL.Parameters.AddWithValue("@Name", ((DGridList["tName", i].Value == null) ? "" : DGridList["tName", i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@Address", ((DGridList["Address", i].Value == null) ? "" : DGridList["Address", i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@BankName", ((DGridList["Bank1", i].Value == null) ? "" : DGridList["Bank1", i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@BankAcctNo", ((DGridList["Account", i].Value == null) ? "" : DGridList["Account", i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@BankCode", ((DGridList["BankCode", i].Value == null) ? "" : DGridList["BankCode", i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@SchoolID", ((DGridList["SchoolID", i].Value == null) ? "" : DGridList["SchoolID", i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@SchName", ((DGridList["SchName", i].Value == null) ? "" : DGridList["SchName", i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@PayDetails", ((DGridList["PaymentDetails", i].Value == null) ? "" : DGridList["PaymentDetails", i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@Source", ((DGridList["Source", i].Value == null) ? "" : DGridList["Source", i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@Remark", ((DGridList["Remark", i].Value == null) ? "" : DGridList["Remark", i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@Amount", ((DGridList["Amount", i].Value == null) ? 0 : Convert.ToDouble(DGridList["Amount", i].Value)));
                        cmSQL.Parameters.AddWithValue("@MandateNo", tMandateNo.Text.ToUpper());
                        cmSQL.Parameters.AddWithValue("@PayType", ((DGridList["PayType1", i].Value == null) ? "" : DGridList["PayType1", i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@dIndex", ((DGridList["Sn", i].Value == null) ? "0" : DGridList["Sn", i].Value)); //g);
                        cmSQL.Parameters.AddWithValue("@Username", MyModules.sysUser);
                        cmSQL.Parameters.AddWithValue("@MandateSn", Convert.ToInt16(tMandateNo.Tag));
                        cmSQL.Parameters.AddWithValue("@MandatePrefix", " "); // dtpDate.Tag);
                        cmSQL.Parameters.AddWithValue("@EmailAddress", ((DGridList["EmailAddress", i].Value == null) ? "" : DGridList["EmailAddress", i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@Telephone", ((DGridList["Telephone", i].Value == null) ? "" : DGridList["Telephone", i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@Period", ((DGridList["Period", i].Value == null) ? "" : DGridList["Period", i].Value).ToString().ToUpper());
                        cmSQL.Parameters.AddWithValue("@PVNo", ((DGridList["PVNo", i].Value == null) ? "" : DGridList["PVNo", i].Value));
                        cmSQL.Parameters.AddWithValue("@InterventionLine", cboInterLine.Text);
                        

                        cmSQL.ExecuteNonQuery();
                    }
                }

                myTrans.Commit();

                cmSQL.Connection.Close();
                cmSQL.Dispose();
                cnSQL.Close();
                cnSQL.Dispose();
                MandateNo = tMandateNo.Text.ToUpper();
                if (g == 0)
                {
                    MessageBox.Show("No Record Saved", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                MessageBox.Show("Successful", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                DGVhasChanged = false;

                LastMandateNo = tMandateNo.Text;


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
                           DGridList["Sn", h].Value=h+1;
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

            finally
            {
                cnSQL.Close();
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


        private void DGridList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;

            DGridList.Tag = e.RowIndex;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {

                if (senderGrid.Columns[e.ColumnIndex].Name == "PayType")
                {
                    FrmChoosePayType childform = new FrmChoosePayType();
                    childform.ShowDialog();
                    if (MyModules.ReturnPayTypes == "") return;

                    FillPayType(MyModules.ReturnPayTypes, e.RowIndex, e.ColumnIndex);
                }

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


        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;
        private void DGridList_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                    !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {

                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = DGridList.DoDragDrop(
                    DGridList.Rows[rowIndexFromMouseDown],
                    DragDropEffects.Move);
                }
            }
        }

        private void DGridList_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = DGridList.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)),
                                    dragSize);
            }
            else
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void DGridList_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dDGridList_DragDrop(object sender, DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = DGridList.PointToClient(new Point(e.X, e.Y));

            // Get the row index of the item the mouse is below. 
            rowIndexOfItemUnderMouseToDrop =
                DGridList.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            // If the drag operation was a move then remove and insert the row.
            if (e.Effect == DragDropEffects.Move)
            {
                DataGridViewRow rowToMove = e.Data.GetData(
                    typeof(DataGridViewRow)) as DataGridViewRow;

                if (rowIndexOfItemUnderMouseToDrop < 0)
                {
                    return;
                }
                DGridList.Rows.RemoveAt(rowIndexFromMouseDown);
                DGridList.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rowToMove);

                for (int h = 0; h < DGridList.Rows.Count; h++)
                {
                    DGridList["Sn", h].Value = h + 1;
                }

            }
        }

        private void FrmPayment_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
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
        private void DGridList_RowsRemoved(object sender, System.Windows.Forms.DataGridViewRowsRemovedEventArgs e)
        {
            calculateTotal();
        }



        private void FillPayType(string PayType, int dRow, int dColumn)
        {
            try
            {

                // DGridList.Item(dColumn - 1, dRow).Value = PayType 'SchoolID
                DGridList["PayType1", dRow].Value = PayType;

                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

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

                cmSQL.CommandText = "FetchPayment";
                cmSQL.CommandType = CommandType.StoredProcedure;
                cmSQL.Parameters.AddWithValue("@MandateNo", MandateNo);
                drSQL = cmSQL.ExecuteReader();

                while (drSQL.Read())
                {
                    DGridList.Rows.Add();
                    DGridList["RefNo", j].Value = drSQL["RefNo"];
                    DGridList["Sn", j].Value = drSQL["dIndex"];
                    DGridList["IDNo", j].Value = drSQL["IDNo"];
                    DGridList["tName", j].Value = drSQL["Name"];
                    DGridList["Amount", j].Value = Convert.ToDouble(drSQL["Amount"], System.Globalization.CultureInfo.InvariantCulture);
                    DGridList["Bank1", j].Value = drSQL["BankName"];
                    DGridList["Account", j].Value = drSQL["BankAcctNo"];
                    DGridList["BankCode", j].Value = drSQL["BankCode"];

                    DGridList["PayType1", j].Value = drSQL["Paytype"]; //Paytype
                    DGridList["PaymentDetails", j].Value = drSQL["PayDetails"];
                    DGridList["Address", j].Value = drSQL["Address"];
                    DGridList["SchoolID", j].Value = drSQL["SchoolID"];
                    DGridList["SchName", j].Value = drSQL["SchName"];
                    DGridList["Source", j].Value = drSQL["Source"];
                    DGridList["Remark", j].Value = MyModules.ChkNull(drSQL["Remark"]);
                    DGridList["Period", j].Value = MyModules.ChkNull(drSQL["Period"]);
                    DGridList["PVNo", j].Value = MyModules.ChkNull(drSQL["PVNo"]);

                    j = j + 1;
                    dtpDate.Value = Convert.ToDateTime(drSQL["PayValueDate"]);
                    tMandateNo.Text = MandateNo;
                    cboInterLine.Text= drSQL["InterventionLine"].ToString();

                }

                drSQL.Close();

                cmSQL.Connection.Close();
                cmSQL.Dispose();
                cnSQL.Close();
                cnSQL.Dispose();

                //if (chkIfSchIncluded == false)
                //{
                //    DGridList.Columns("IDRefNo").Visible = false;
                //    DGridList.Columns("IDNo").Visible = false;
                //    DGridList.Columns("cmdIDNo").Visible = false;
                //    DGridList.Refresh();
                //}
                

                DGridList.Columns["RefNo"].Width = 5;
                DGridList.Columns["Sn"].Width = 40;
                DGridList.Columns["IDNo"].Width = 120;
                DGridList.Columns["tName"].Width = 120;
                DGridList.Columns["Amount"].Width = 100;
                DGridList.Columns["Bank1"].Width = 120;
                DGridList.Columns["Account"].Width = 80;
                DGridList.Columns["BankCode"].Width = 80;
                DGridList.Columns["PayType1"].Width = 120;
                DGridList.Columns["PaymentDetails"].Width = 120;
                DGridList.Columns["Source"].Width = 2;
                DGridList.Columns["Remark"].Width = 120;
                DGridList.Columns["SchoolID"].Width = 2;
                DGridList.Columns["SchName"].Width = 120;
                DGridList.Columns["Address"].Width = 150;
                DGridList.Columns["Period"].Width = 150;
                DGridList.Columns["PVNo"].Width = 100;


                lblCount.Text = "Payment Count:" + DGridList.Rows.Count.ToString(); //GetCount() + 1
                dtpDate.Focus();


                calculateTotal();
                try {
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

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            switch (cmdBeneficiary.Text)
            {
                case "VENDOR":

                    if (MyModules.GetUserAccessDetails("Vendor Information") == false) return;
                    FrmVendorInfor ChildForm = new FrmVendorInfor("New", 0, "VENDOR");
                    ChildForm.ShowDialog();
                    break;
                case "SCHOOL":
                    if (MyModules.GetUserAccessDetails("School Information") == false) return;
                    FrmSchoolInfor childform0 = new FrmSchoolInfor("New", 0);
                    childform0.ShowDialog();
                    break;

                case "STUDENT":
                    if (MyModules.GetUserAccessDetails("Student Information") == false) return;
                    FrmStudentInfor childform1 = new FrmStudentInfor("New", 0);
                    childform1.ShowDialog();
                    break;
                case "STAFF":
                    if (MyModules.GetUserAccessDetails("Vendor Information") == false) return;
                    FrmVendorInfor ChildForm2 = new FrmVendorInfor("New", 0, "STAFF");
                    ChildForm2.ShowDialog();
                    break;
            }
        }

        private void lvList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ReturnCode = Convert.ToInt16(lvList.SelectedItems[0].SubItems[1].Text);
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

        private void mnuNew_Click(object sender, EventArgs e)
        {
            switch (cmdBeneficiary.Text)
            {
                case "VENDOR":

                    if (MyModules.GetUserAccessDetails("Vendor Information") == false) return;
                    FrmVendorInfor ChildForm = new FrmVendorInfor("New", 0, "VENDOR");
                    ChildForm.ShowDialog();
                    break;
                case "SCHOOL":
                    if (MyModules.GetUserAccessDetails("School Information") == false) return;
                    FrmSchoolInfor childform = new FrmSchoolInfor("New", 0);
                    childform.ShowDialog();
                    break;

                case "STUDENT":
                    if (MyModules.GetUserAccessDetails("Student Information") == false) return;
                    FrmStudentInfor childform1 = new FrmStudentInfor("New", 0);
                    childform1.ShowDialog();
                    break;
                case "STAFF":

                    if (MyModules.GetUserAccessDetails("Vendor Information") == false) return;
                    FrmVendorInfor ChildForm2 = new FrmVendorInfor("New", 0, "STAFF");
                    ChildForm2.ShowDialog();
                    break;
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            switch (cmdBeneficiary.Text)
            {
                case "VENDOR":

                    if (MyModules.GetUserAccessDetails("Vendor Information") == false) return;
                    FrmVendorInfor ChildForm = new FrmVendorInfor("Delete", ReturnCode, "VENDOR");
                    ChildForm.ShowDialog();
                    break;
                case "SCHOOL":
                    if (MyModules.GetUserAccessDetails("School Information") == false) return;
                    FrmSchoolInfor childform0 = new FrmSchoolInfor("Delete", ReturnCode);
                    childform0.ShowDialog();
                    break;

                case "STUDENT":
                    if (MyModules.GetUserAccessDetails("Student Information") == false) return;
                    FrmStudentInfor childform1 = new FrmStudentInfor("Delete", ReturnCode);
                    childform1.ShowDialog();
                    break;
                case "STAFF":

                    if (MyModules.GetUserAccessDetails("Vendor Information") == false) return;
                    FrmVendorInfor ChildForm2 = new FrmVendorInfor("Delete", ReturnCode, "STAFF");
                    ChildForm2.ShowDialog();
                    break;
            }
            if (strQryMain == "") return;
            LoadLvList(strQryMain);
            tFilter.Text = "";
        }

        private void mnuBrowse_Click(object sender, EventArgs e)
        {
            switch (cmdBeneficiary.Text)
            {
                case "VENDOR":

                    if (MyModules.GetUserAccessDetails("Vendor Information") == false) return;
                    FrmVendorInfor ChildForm = new FrmVendorInfor("Browse", ReturnCode, "VENDOR");
                    ChildForm.ShowDialog();
                    break;
                case "SCHOOL":
                    if (MyModules.GetUserAccessDetails("School Information") == false) return;
                    FrmSchoolInfor childform0 = new FrmSchoolInfor("Browse", ReturnCode);
                    childform0.ShowDialog();
                    break;

                case "STUDENT":
                    if (MyModules.GetUserAccessDetails("Student Information") == false) return;
                    FrmStudentInfor childform1 = new FrmStudentInfor("Browse", ReturnCode);
                    childform1.ShowDialog();
                    break;
                case "STAFF":

                    if (MyModules.GetUserAccessDetails("Vendor Information") == false) return;
                    FrmVendorInfor ChildForm2 = new FrmVendorInfor("Browse", ReturnCode, "STAFF");
                    ChildForm2.ShowDialog();
                    break;

            }
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void mnuCopyPaymentTypes_Click(object sender, EventArgs e)
        {
            int h = 0;
            int dRow = Convert.ToInt32(DGridList.Tag);
            for (h = 0; h < DGridList.Rows.Count; h++)
            {
                if (DGridList.Rows[dRow].Cells["PayType1"].Value.ToString() != "" && Convert.ToInt16(DGridList.Rows[h].Cells["Sn"].Value) > 0) //PayType
                {
                    // if (DGridList.Rows[h].Cells["PayType1"].Value.ToString() isdbnull)

                    // if (!string.IsNullOrEmpty(DGridList.Rows[h].Cells["PayType1"].Value.ToString())) //.Trim(' ')))
                    //{
                    if (MyModules.ChkNull(DGridList.Rows[h].Cells["PayType1"].Value) == "")
                    {
                        DGridList.Rows[h].Cells["PayType1"].Value = DGridList.Rows[dRow].Cells["PayType1"].Value;
                    }
                    //}
                }
            }

        }

        private void mnuCopyPayDetail2_Click(object sender, EventArgs e)
        {
            int h = 0;
            int dRow = Convert.ToInt32(DGridList.Tag);
            for (h = 0; h < DGridList.Rows.Count; h++)
            {
                if (DGridList.Rows[dRow].Cells["PaymentDetails"].Value.ToString() != "" && Convert.ToInt16(DGridList.Rows[h].Cells["Sn"].Value) > 0) //PayType
                {
                    if (MyModules.ChkNull(DGridList.Rows[h].Cells["PaymentDetails"].Value) == "")
                    {
                        DGridList.Rows[h].Cells["PaymentDetails"].Value = DGridList.Rows[dRow].Cells["PaymentDetails"].Value;
                    }
                }
            }
        }

        private void mnuClearPaymentDetails1_Click(object sender, EventArgs e)
        {
            for (int h = 0; h < DGridList.Rows.Count; h++)
            {
                DGridList.Rows[h].Cells["PaymentDetails"].Value = "";
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
                    childform.MainAction = "Main";
                    childform.ShowDialog();
                }
                else
                    MessageBox.Show("Pls. choose a mandate", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



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

        private void lnkCleanMandate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CleanList();
        }


        private void mnuEditRecordDgrid_Click(object sender, EventArgs e)
        {

            int dRow = Convert.ToInt32(DGridList.Tag);
            if (MyModules.ChkNull(DGridList.Rows[dRow].Cells["RefNo"].Value) != "")
            {

                switch (DGridList.Rows[dRow].Cells["Source"].Value.ToString())
                {
                    case "VENDOR":

                        if (MyModules.GetUserAccessDetails("Vendor Information") == false) return;
                        FrmVendorInfor ChildForm = new FrmVendorInfor("Edit", Convert.ToInt16(DGridList.Rows[dRow].Cells["RefNo"].Value), "VENDOR");
                        ChildForm.ShowDialog();
                        oUpdateDbgrid(DGridList.Rows[dRow].Cells["Source"].Value.ToString(), Convert.ToInt16(DGridList.Rows[dRow].Cells["RefNo"].Value));
                        break;
                    case "SCHOOL":
                        if (MyModules.GetUserAccessDetails("School Information") == false) return;
                        FrmSchoolInfor childform0 = new FrmSchoolInfor("Edit", Convert.ToInt16(DGridList.Rows[dRow].Cells["RefNo"].Value));
                        childform0.ShowDialog();
                        oUpdateDbgrid(DGridList.Rows[dRow].Cells["Source"].Value.ToString(), Convert.ToInt16(DGridList.Rows[dRow].Cells["RefNo"].Value));

                        break;

                    case "STUDENT":
                        if (MyModules.GetUserAccessDetails("Student Information") == false) return;
                        FrmStudentInfor childform1 = new FrmStudentInfor("Edit", Convert.ToInt16(DGridList.Rows[dRow].Cells["RefNo"].Value));
                        childform1.ShowDialog();
                        oUpdateDbgrid(DGridList.Rows[dRow].Cells["Source"].Value.ToString(), Convert.ToInt16(DGridList.Rows[dRow].Cells["RefNo"].Value));

                        break;
                    case "STAFF":

                        if (MyModules.GetUserAccessDetails("Vendor Information") == false) return;
                        FrmVendorInfor ChildForm2 = new FrmVendorInfor("Edit", Convert.ToInt16(DGridList.Rows[dRow].Cells["RefNo"].Value), "STAFF");
                        ChildForm2.ShowDialog();
                        oUpdateDbgrid(DGridList.Rows[dRow].Cells["Source"].Value.ToString(), Convert.ToInt16(DGridList.Rows[dRow].Cells["RefNo"].Value));
                        break;
                }
            }
        }


        private void oUpdateDbgrid(string Source, int strCond)
        {
            try
            {

                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                SqlDataReader drSQL = null;
                cmSQL.Connection = cnSQL;
                cnSQL.Open();
                string strQry = "";

                int dRow = Convert.ToInt32(DGridList.Tag);
                if (Source == "STUDENT")
                {
                    // strQry = "SELECT RegisterStudent.*,RegisterSchool.SchName FROM RegisterStudent LEFT OUTER JOIN RegisterSchool ON RegisterStudent.SchoolID = RegisterSchool.Sn WHERE (RegisterStudent.InActive=0 or RegisterStudent.InActive IS NULL)  AND RegisterStudent.Sn =" + strCond;
                    strQry = "SELECT RegisterStudent.* FROM RegisterStudent WHERE (RegisterStudent.InActive=0 or RegisterStudent.InActive IS NULL)  AND RegisterStudent.Sn =" + strCond;

                    cmSQL.CommandText = strQry;
                    cmSQL.CommandType = CommandType.Text;
                    drSQL = cmSQL.ExecuteReader();

                    while (drSQL.Read())
                    {

                        DGridList["IDNo", dRow].Value = drSQL["IDNo"];
                        DGridList["tName", dRow].Value = drSQL["Name"];
                        DGridList["Bank1", dRow].Value = drSQL["BankName"];
                        DGridList["Account", dRow].Value = drSQL["BankAcctNo"];
                        DGridList["BankCode", dRow].Value = drSQL["BankCode"];
                        DGridList["SchoolID", dRow].Value = drSQL["SchoolID"];
                        DGridList["SchName", dRow].Value = drSQL["SchName"];
                        DGridList["Address", dRow].Value = drSQL["Address"];

                    }
                    drSQL.Close();
                }
                if (Source == "SCHOOL")
                {
                    strQry = "SELECT * FROM RegisterSchool WHERE (RegisterSchool.InActive=0 or RegisterSchool.InActive IS NULL)  AND RegisterSchool.Sn=" + strCond;

                    cmSQL.CommandText = strQry;
                    cmSQL.CommandType = CommandType.Text;
                    drSQL = cmSQL.ExecuteReader();

                    while (drSQL.Read())
                    {

                        DGridList["IDNo", dRow].Value = drSQL["IDNo"];
                        DGridList["tName", dRow].Value = drSQL["SchName"];
                        DGridList["Bank1", dRow].Value = drSQL["BankName"];
                        DGridList["Account", dRow].Value = drSQL["BankAcctNo"];
                        DGridList["BankCode", dRow].Value = drSQL["BankCode"];
                        DGridList["SchoolID", dRow].Value = "";
                        DGridList["SchName", dRow].Value = "";
                        DGridList["Address", dRow].Value = drSQL["SchAddress"];
                    }
                    drSQL.Close();
                }

                if (Source == "VENDOR")
                {
                    strQry = "SELECT * FROM RegisterVendor WHERE Source<>'STAFF' AND (InActive=0 or InActive IS NULL)  AND Sn=" + strCond;

                    cmSQL.CommandText = strQry;
                    cmSQL.CommandType = CommandType.Text;
                    drSQL = cmSQL.ExecuteReader();

                    while (drSQL.Read())
                    {
                        if (CheckIfExist(Source, Convert.ToInt16(drSQL["Sn"])) == true)
                        {

                            DGridList["IDNo", dRow].Value = drSQL["IDNo"];
                            DGridList["tName", dRow].Value = drSQL["Name"];
                            DGridList["Bank1", dRow].Value = drSQL["BankName"];
                            DGridList["Account", dRow].Value = drSQL["BankAcctNo"];
                            DGridList["BankCode", dRow].Value = drSQL["BankCode"];
                            DGridList["SchoolID", dRow].Value = "";
                            DGridList["SchName", dRow].Value = "";
                            DGridList["Address", dRow].Value = drSQL["Address"];

                        }
                        drSQL.Close();

                    }
                }

                if (Source == "STAFF")
                {
                    strQry = "SELECT * FROM RegisterVendor WHERE Source='STAFF' AND (InActive=0 or InActive IS NULL)  AND Sn=" + strCond;

                    cmSQL.CommandText = strQry;
                    cmSQL.CommandType = CommandType.Text;
                    drSQL = cmSQL.ExecuteReader();

                    while (drSQL.Read())
                    {
                        if (CheckIfExist(Source, Convert.ToInt16(drSQL["Sn"])) == true)
                        {

                            DGridList["IDNo", dRow].Value = drSQL["IDNo"];
                            DGridList["tName", dRow].Value = drSQL["Name"];
                            DGridList["Bank1", dRow].Value = drSQL["BankName"];
                            DGridList["Account", dRow].Value = drSQL["BankAcctNo"];
                            DGridList["BankCode", dRow].Value = drSQL["BankCode"];
                            DGridList["SchoolID", dRow].Value = "";
                            DGridList["SchName", dRow].Value = "";
                            DGridList["Address", dRow].Value = drSQL["Address"];

                        }
                        drSQL.Close();

                    }
                }

                cmSQL.Connection.Close();
                cmSQL.Dispose();
                cnSQL.Close();
                cnSQL.Dispose();



                DGridList.CurrentCell = DGridList.Rows[dRow].Cells["Amount"];
                DGridList.Focus();


                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void mnuCopyPeriod_Click(object sender, EventArgs e)
        {
            try
            {
                int h = 0;
                int dRow = Convert.ToInt32(DGridList.Tag);
                for (h = 0; h < DGridList.Rows.Count; h++)
                {
                    if (DGridList.Rows[dRow].Cells["Period"].Value.ToString() != "" && Convert.ToInt16(DGridList.Rows[h].Cells["Sn"].Value) > 0) //PayType
                    {
                        if (MyModules.ChkNull(DGridList.Rows[h].Cells["Period"].Value) == "")
                        {
                            DGridList.Rows[h].Cells["Period"].Value = DGridList.Rows[dRow].Cells["Period"].Value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void mnuGeneratePayDetails_Click(object sender, EventArgs e)
        {
            int h = 0;
            int dRow = Convert.ToInt32(DGridList.Tag);
            for (h = 0; h < DGridList.Rows.Count; h++)
            {
                if (DGridList.Rows[dRow].Cells["PaymentDetails"].Value.ToString() == "" && Convert.ToInt16(DGridList.Rows[h].Cells["Sn"].Value) > 0) //PayType
                {
                    //if (MyModules.ChkNull(DGridList.Rows[h].Cells["Period"].Value) == "")
                    //{
                    DGridList.Rows[h].Cells["PaymentDetails"].Value = (MyModules.ChkNull(DGridList.Rows[h].Cells["Period"].Value) + " " + DGridList.Rows[dRow].Cells["PayType1"].Value).Trim();
                    //}
                }
            }
        }


        private void cmdCloseIt_Click(object sender, EventArgs e)
        {
            pnlExportPay.Visible = false;
        }

        private void mnuEMandateForTSA1_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;
                SqlDataReader drSQL = null;

                cnSQL.Open();


                dynamic oExcel = null;
                oExcel = System.Activator.CreateInstance(System.Type.GetTypeFromProgID("Excel.Application"));

                string dPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                string filename = dPath + "\\GIFMISMandate_" + tMandateNo.Text + ".xls";

                //   System.IO.File.Delete(filename);


                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }

                System.IO.File.Copy(MyModules.AppPath + "ConfigDir\\" + "ExcelTemplate.xls", filename, true);

                oExcel.Workbooks.open(filename);


                oExcel.Sheets(1).Select();

                oExcel.Visible = true;

                oExcel.Cells[1, 1] = "BENEFICIARY NAME";
                oExcel.Cells[1, 2] = "BANK CODE";
                oExcel.Cells[1, 3] = "BANK ACCOUNT NO";
                oExcel.Cells[1, 4] = "AMOUNT";
                oExcel.Cells[1, 5] = "CURRENCY";
                oExcel.Cells[1, 6] = "COA ACCOUNT";
                oExcel.Cells[1, 7] = "FUND";
                // oExcel.Cells[1, 8] = "PROGRAM";
                oExcel.Cells[1, 8] = "DESCRIPTION";
                oExcel.Cells[1, 9] = "PHONE";
                oExcel.Cells[1, 10] = "EMAIL";
                oExcel.Cells[1, 11] = "REFERENCE NO";


                cmSQL.CommandText = "FetchPayment";
                cmSQL.CommandType = CommandType.StoredProcedure;
                cmSQL.Parameters.AddWithValue("@MandateNo", MandateNo);
                drSQL = cmSQL.ExecuteReader();

                // If drSQL.HasRows = False Then GoTo skipit

                int j = 2;
                //Dim k As Integer = 0
                while (drSQL.Read())
                {
                    oExcel.Cells[j, 1] = drSQL["Name"];
                    oExcel.Cells[j, 2] = drSQL["BankCode"].ToString().Substring(0, 1) == "0" ? "'" + drSQL["BankCode"].ToString() : drSQL["BankCode"];
                    oExcel.Cells[j, 3] = drSQL["BankAcctNo"].ToString().Substring(0, 1) == "0" ? "'" + drSQL["BankAcctNo"].ToString() : drSQL["BankAcctNo"];
                    oExcel.Cells[j, 4] = drSQL["Amount"];
                    oExcel.Cells[j, 5] = "NGN";
                    oExcel.Cells[j, 6] = "22921038";  //"21020101";
                    oExcel.Cells[j, 7] = "02448"; // "02430";
                                                  //  oExcel.Cells[j, 8] = "";
                    oExcel.Cells[j, 8] = drSQL["PayDetails"];

                    if (MyModules.ChkNull(drSQL["Telephone"]) == "")
                    {
                        oExcel.Cells[j, 9] = "0"; //Mobile
                    }
                    else
                    {
                        oExcel.Cells[j, 9] = drSQL["Telephone"]; //Mobile
                    }
                    if (MyModules.ChkNull(drSQL["EmailAddress"]) == "")
                    {
                        oExcel.Cells[j, 10] = "0"; //Email
                    }
                    else
                    {
                        oExcel.Cells[j, 10] = drSQL["EmailAddress"]; //Email
                    }

                    oExcel.Cells[j, 11] = "";
                    j = j + 1;
                    //  k = 1
                }
                //skipit:
                drSQL.Close();
                oExcel.Workbooks(1).Save(); //As(filename)

                //oExcel.Workbooks(1).PrintPreview()
                //End If
                oExcel.Workbooks(1).Close();
                oExcel.Quit();

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

        private void mnuEMandateForTSA2_Click(object sender, EventArgs e)
        {

            try
            {

                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;
                SqlDataReader drSQL = null;

                cnSQL.Open();


                dynamic oExcel = null;
                oExcel = System.Activator.CreateInstance(System.Type.GetTypeFromProgID("Excel.Application"));

                string dPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                string filename = dPath + "\\GIFMISMandate_" + tMandateNo.Text + ".xls";

                //   System.IO.File.Delete(filename);


                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }

                System.IO.File.Copy(MyModules.AppPath + "ConfigDir\\" + "ExcelTemplate.xls", filename, true);

                oExcel.Workbooks.open(filename);


                oExcel.Sheets(1).Select();

                oExcel.Visible = true;

                oExcel.Cells[1, 1] = "Employee";
                oExcel.Cells[1, 2] = "Bank Account";
                oExcel.Cells[1, 3] = "Description";
                oExcel.Cells[1, 4] = "Amount";
                oExcel.Cells[1, 5] = "Currency";
                oExcel.Cells[1, 6] = "Budget Line";
                oExcel.Cells[1, 7] = "Is Advance Payment";


                cmSQL.CommandText = "FetchPayment";
                cmSQL.CommandType = CommandType.StoredProcedure;
                cmSQL.Parameters.AddWithValue("@MandateNo", MandateNo);
                drSQL = cmSQL.ExecuteReader();

                // If drSQL.HasRows = False Then GoTo skipit

                int j = 2;
                //Dim k As Integer = 0
                while (drSQL.Read())
                {
                    oExcel.Cells[j, 1] = drSQL["IDNo"];
                    oExcel.Cells[j, 2] = drSQL["BankAcctNo"].ToString().Substring(0, 1) == "0" ? "'" + drSQL["BankAcctNo"].ToString() : drSQL["BankAcctNo"];
                    oExcel.Cells[j, 3] = drSQL["PayDetails"];
                    oExcel.Cells[j, 4] = drSQL["Amount"];
                    oExcel.Cells[j, 5] = "NGN";
                    oExcel.Cells[j, 6] = cboBudgetLine.Text;
                    oExcel.Cells[j, 7] = "0";

                    j = j + 1;
                    //  k = 1
                }
                //skipit:
                drSQL.Close();
                oExcel.Workbooks(1).Save(); //As(filename)

                //oExcel.Workbooks(1).PrintPreview()
                //End If
                oExcel.Workbooks(1).Close();
                oExcel.Quit();

                cmSQL.Connection.Close();
                cmSQL.Dispose();
                cnSQL.Close();
                cnSQL.Dispose();

                MessageBox.Show("Export Complete.....");


                //Save BudgetLine to Sysfile
                if (cboBudgetLine.Text.Trim().Length > 0)
                {
                    Properties.Settings.Default.BudgetLine = cboBudgetLine.Text;
                }
                Properties.Settings.Default.Save();


                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lnkExport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlExportPay.Visible = !pnlExportPay.Visible;

        }

        public static void export2excel(string dMandateNo)
        {
            try
            {

                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;
                SqlDataReader drSQL = null;


                string dPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                cnSQL.Open();


                string filename = dPath + "\\RemitalMandate_" + dMandateNo + ".csv";

                if (dMandateNo.Contains("\\") || (dMandateNo.Contains("/"))) filename = dPath + "\\RemitalMandate_" + ".csv";


                //  System.IO.File.Delete(filename);


                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }

                System.IO.StreamWriter objWriter = new System.IO.StreamWriter(filename, true, System.Text.Encoding.UTF8);

                //-------Dummy record not to be posted-----------
                if (File.Exists(filename))
                {
                    objWriter.Write("000,"); //BankCode
                    objWriter.Write("000,"); //Acct No
                    objWriter.Write(20.ToString() + ","); //AcctType
                    objWriter.Write("0,"); //Amt
                    objWriter.Write("Short Desc ,");
                    objWriter.Write("Long Desc ,");
                    objWriter.Write("Dummy,"); //Name
                    objWriter.Write(0.ToString() + ","); //Mobile
                    objWriter.Write(0.ToString() + ","); //Email
                    objWriter.Write(0.ToString() + ","); //WITHOLDING TAX(%)
                    objWriter.Write(0); //TAX OFFICE
                    objWriter.Write(Environment.NewLine);
                }
                //--------- End dummy record ---------

                cmSQL.CommandText = "FetchPayment";
                cmSQL.CommandType = CommandType.StoredProcedure;
                cmSQL.Parameters.AddWithValue("@MandateNo", dMandateNo);
                drSQL = cmSQL.ExecuteReader();

                while (drSQL.Read())
                {
                    if (File.Exists(filename))
                    {

                        //objWriter.Write(drSQL["BankName"] + ",");
                        //objWriter.Write(drSQL["BankCode"] + ",");
                        //objWriter.Write(drSQL["BankAcctNo"] + ",");
                        //objWriter.Write(20.ToString() + ",");
                        //objWriter.Write(drSQL["Amount"] + ",");
                        //objWriter.Write(drSQL["PayDetails"] + ",");
                        //objWriter.Write(drSQL["PayType"] + ",");


                        //if (drSQL["Name"].ToString().Contains(","))
                        //{
                        //    objWriter.Write(drSQL["Name"].ToString().Replace(",", " ") + ",");
                        //}
                        //else
                        //{
                        //    objWriter.Write(drSQL["Name"] + ",");
                        //}

                        //objWriter.Write(0.ToString() + ","); //Mobile
                        //objWriter.Write(0.ToString() + ","); //Email
                        //objWriter.Write(0.ToString() + ","); //WITHOLDING TAX(%)
                        //objWriter.Write(0); //TAX OFFICE
                        //objWriter.Write(Environment.NewLine);

                        objWriter.Write(drSQL["BankCode"] + ",");
                        objWriter.Write(drSQL["BankAcctNo"] + ",");
                        if (drSQL["BankCode"].ToString() == "000")
                            objWriter.Write("00" + ","); //CBN AcctType
                        else
                            objWriter.Write("20" + ","); //AcctType
                        objWriter.Write(Convert.ToDouble(drSQL["Amount"]).ToString("##.##") + ",");
                        objWriter.Write(drSQL["PayType"] + ",");
                        objWriter.Write(drSQL["PayDetails"] + ",");
                        if (drSQL["Name"].ToString().Contains(","))
                        {
                            objWriter.Write(drSQL["Name"].ToString().Replace(",", " ") + ",");
                        }
                        else
                        {
                            objWriter.Write(drSQL["Name"] + ",");
                        }

                        if (MyModules.ChkNull(drSQL["Telephone"]) == "")
                        {
                            objWriter.Write(0.ToString() + ","); //Mobile
                        }
                        else
                        {
                            objWriter.Write(drSQL["Telephone"].ToString() + ","); //Mobile
                        }
                        if (MyModules.ChkNull(drSQL["EmailAddress"]) == "")
                        {
                            objWriter.Write(0.ToString() + ","); //Email
                        }
                        else
                        {
                            objWriter.Write(drSQL["EmailAddress"].ToString() + ","); //Email
                        }
                        objWriter.Write(0.ToString() + ","); //WITHOLDING TAX(%)
                        objWriter.Write(0); //TAX OFFICE
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
        private void mnuRemital_Click(object sender, EventArgs e)
        {
            export2excel(tMandateNo.Text);
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

        private ColumnHeader SortingColumn = null;
        private void lvList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Get the new sorting column.
            ColumnHeader new_sorting_column = lvList.Columns[e.Column];

            // Figure out the new sorting order.
            System.Windows.Forms.SortOrder sort_order;
            if (SortingColumn == null)
            {
                // New column. Sort ascending.
                sort_order = System.Windows.Forms.SortOrder.Ascending;
            }
            else
            {
                // See if this is the same column.
                if (new_sorting_column == SortingColumn)
                {
                    // Same column. Switch the sort order.
                    if (SortingColumn.Text.StartsWith("> "))
                    {
                        sort_order = System.Windows.Forms.SortOrder.Descending;
                    }
                    else
                    {
                        sort_order = System.Windows.Forms.SortOrder.Ascending;
                    }
                }
                else
                {
                    // New column. Sort ascending.
                    sort_order = System.Windows.Forms.SortOrder.Ascending;
                }

                // Remove the old sort indicator.
                SortingColumn.Text = SortingColumn.Text.Substring(2);
            }

            // Display the new sort order.
            SortingColumn = new_sorting_column;
            if (sort_order == System.Windows.Forms.SortOrder.Ascending)
            {
                SortingColumn.Text = "> " + SortingColumn.Text;
            }
            else
            {
                SortingColumn.Text = "< " + SortingColumn.Text;
            }

            // Create a comparer.
            lvList.ListViewItemSorter = new ListViewComparer(e.Column, sort_order);

            // Sort.
            lvList.Sort();
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
                
                cmSQL.CommandText = "SELECT  COUNT (DISTINCT MandateNo) AS MaxMandateNo FROM Payment";

                cmSQL.CommandType = CommandType.Text;
                drSQL = cmSQL.ExecuteReader();
                if (drSQL.Read()) tMandateNo.Text = (Convert.ToInt16(drSQL["MaxMandateNo"]) + 1).ToString();

           
                //cmSQL.Connection.Close()
                cmSQL.Dispose();
                drSQL.Close();
                cnSQL.Close();
                //cnSQL.Dispose()

                if (tMandateNo.Text.Length== 1)
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

        private void cboInterLine_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkWrap_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWrap.Checked)
            {
                DGridList.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                DGridList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            }
            else
            {
                DGridList.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                DGridList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            }
        }

        private void mnuCloneSelectedRow_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            int g = DGridList.Rows.Count;

            for (int i = 0; i < DGridList.Rows.Count; i++)
            {
                if (DGridList.Rows[i].Selected == true)
                {
                    row = (DataGridViewRow)DGridList.Rows[i].Clone();
                    int intColIndex = 0;
                    foreach (DataGridViewCell cell in DGridList.Rows[i].Cells)
                    {
                        row.Cells[intColIndex].Value = cell.Value;
                        intColIndex++;
                    }
                    g++;
                
                    row.Cells[1].Value = g;
                    DGridList.Rows.Add(row);
                }
            }
            DGridList.AllowUserToAddRows = false;
            DGridList.Refresh();

        }

        private void mnugetTotalOfSeletedRows_Click(object sender, EventArgs e)
        {
            double dsum =0;
             for (int i = 0; i < DGridList.Rows.Count; i++) 
                if (DGridList.Rows[i].Selected == true) dsum = dsum + Convert.ToDouble( DGridList["amount", i].Value);

            MessageBox.Show("Sum is = " + dsum.ToString("N"),"Selected row total");
            
        }
    }

}


