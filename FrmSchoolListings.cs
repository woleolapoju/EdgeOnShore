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

    public partial class FrmSchoolListings : Form
    {
        private BindingSource BindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter1 = new SqlDataAdapter();
        int ReturnCode;
        string strQryMain;
        public FrmSchoolListings()
        {
            InitializeComponent();
        }

        private void FrmSchoolListings_Load(object sender, EventArgs e)
        {
            dGrid.DataSource = BindingSource1;
            MyModules.applyGridTheme(dGrid);
            dGrid.ReadOnly = true;
            SplitContainer2.SplitterDistance = 322;
            cboCriteria.SelectedIndex = 1;
            CmbCriteria.SelectedIndex = 1;

            mnuNew.Enabled = MyModules.ModuleAdd;
            mnuEdit.Enabled = MyModules.ModuleEdit;
            mnuBrowse.Enabled = MyModules.ModuleBrowse;
            mnuDelete.Enabled = MyModules.ModuleDelete;

        }

        private void LoadTV(string dChoice)
        {
            try
            {

            
                string str = "";
                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;
                SqlDataReader drSQL;
                switch (dChoice)
                {
                    case "State":
                        str = "SELECT DISTINCT [State] AS dText FROM RegisterSchool";
                        break;
                    case "Bank":
                        str = "SELECT DISTINCT [BankName] AS dText FROM RegisterSchool";
                        break;
                    case "Category":
                        str = "SELECT DISTINCT [Category] AS dText FROM RegisterSchool";
                        break;
                    case "Region":
                        str = "SELECT DISTINCT [Region] AS dText FROM RegisterSchool";
                        break;
                }


                TV.Nodes.Clear();
                cmSQL.CommandText = str;
                cmSQL.CommandType = CommandType.Text;
                cnSQL.Open();
                drSQL = cmSQL.ExecuteReader();

                TV.BeginUpdate();
                TV.Nodes.Add("ALL", "ALL").ForeColor = Color.Red;
                while (drSQL.Read())
                {
                    if (Convert.IsDBNull(drSQL[0]) == false)
                    {
                        TV.Nodes.Add(drSQL[0].ToString(), drSQL[0].ToString());
                    }
                    TV.EndUpdate();
                }

                //cmSQL.Connection.Close()
                cmSQL.Dispose();
                drSQL.Close();
                cnSQL.Close();
                cnSQL.Dispose();

                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ooops! ERROR :" + char.ConvertFromUtf32(13) + ex, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        public void LoadLvList(string strQ)
        {
            if (strQ=="" || strQ == null)
                return;
            try
            {
                strQryMain = strQ;
                string str;
                if (strQ == "<ALL>")
                {
                    str = "SELECT [Sn] AS [RefNo],IDNo,[SchName] AS [School Name] ,[SchAddress] AS [School Address] ,[State],[EmailAddress] AS [Email Address] ,[Telephone] ,[BankName] AS [Bank Name],[BankAcctNo] AS [Account No],[BankCode] AS [Bank Code],[BankAddress] AS [Bank Address],[Remark],[InActive] FROM RegisterSchool";
                }
                else
                {
                    str = "SELECT [Sn] AS [RefNo],IDNo,[SchName] AS [School Name] ,[SchAddress] AS [School Address] ,[State],[EmailAddress] AS [Email Address] ,[Telephone] ,[BankName] AS [Bank Name],[BankAcctNo] AS [Account No],[BankCode] AS [Bank Code],[BankAddress] AS [Bank Address],[Remark],[InActive] FROM RegisterSchool WHERE " + strQ;
                }


                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;
                cmSQL.CommandType = CommandType.Text;
                cmSQL.CommandText = str;


                cnSQL.Open();
                dataAdapter1 = new SqlDataAdapter(cmSQL);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(this.dataAdapter1);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                this.dataAdapter1.Fill(table);
                this.BindingSource1.DataSource = table;

                cmSQL.Dispose();

                dGrid.Refresh();

                lblCount.Text = "List Count:"+dGrid.Rows.Count.ToString();


                //filterStatusLabel.Text = DGrid.Rows.Count.ToString + " of " + DGrid.Rows.Count.ToString


                SelColumn.Minimum = 1;
                SelColumn.Maximum = dGrid.Columns.Count;
                dGrid.Columns[1].Width = 100;
                dGrid.Columns[2].Width = 210;
                dGrid.Columns[3].Width = 210;
                dGrid.Columns[7].Width = 210;
                dGrid.Columns[10].Width = 210;
                dGrid.Columns[0].Width = 40;
                dGrid.Columns[12].Width = 50;


                MyModules.formatGrid(dGrid);


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

                switch (CmbCriteria.Text.ToString())
                {
                    case "State":
                        strQry = " [State] = '" + e.Node.Text + "'";
                        break;
                    case "Bank":
                        strQry = " BankName = '" + e.Node.Text + "'";
                        break;
                  
                    case "Category":
                        strQry = " Category = '" + e.Node.Text + "'";
                        break;
                    case "Region":
                        strQry = " Region = '" + e.Node.Text + "'";
                        break;
                }

            }
            LoadLvList(strQry);
        }

        private void FrmSchoolListings_Resize(object sender, EventArgs e)
        {
            SplitContainer2.SplitterDistance = 322;
        }
        private void dGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ReturnCode = Convert.ToInt16(dGrid[0, e.RowIndex].Value);
                dGrid.Tag = e.RowIndex;
                SelColumn.Value = e.ColumnIndex + 1;
                tFilter.Text = dGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
            catch
            {

            }
        }

        private void mnuEditStaff_Click(object sender, EventArgs e)
        {
            FrmSchoolInfor ChildForm = new FrmSchoolInfor("Edit", ReturnCode);
            ChildForm.ShowDialog();
            LoadLvList(strQryMain);

        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            FrmSchoolInfor ChildForm = new FrmSchoolInfor("Delete", ReturnCode);
            ChildForm.ShowDialog();
            LoadLvList(strQryMain);
        }

        private void mnuBrowse_Click(object sender, EventArgs e)
        {
            FrmSchoolInfor ChildForm = new FrmSchoolInfor("Browse", ReturnCode);
            ChildForm.ShowDialog();
            LoadLvList(strQryMain);
        }

        private void mnuHideColumn_Click(object sender, EventArgs e)
        {
            try
            {
                int j = 0;
                int jk = Convert.ToInt16(dGrid.Tag);
                for (j = 0; j < dGrid.Columns.Count; j++)
                {
                    if (dGrid[j, jk].Selected == true)
                    {
                        dGrid.Columns[j].Visible = false;
                    }
                }
            }
            catch
            {

            }
        }

        private void mnuShowAllColumn_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    int j = 0;
                    int jk = Convert.ToInt16(dGrid.Tag);
                    for (j = 0; j < dGrid.Columns.Count; j++)
                    {
                        if (dGrid.Columns[j].Visible == false)
                        {
                            dGrid.Columns[j].Visible = true;
                        }

                    }
                }
                catch
                {

                }
            }
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            FrmSchoolInfor ChildForm = new FrmSchoolInfor("New", 0);
            ChildForm.ShowDialog();
            LoadLvList(strQryMain);
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {

            LoadLvList(strQryMain);
            tFilter.Text = "";
            SelColumn.Maximum = dGrid.Columns.Count;

        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    int x = 0;
                    DataGridViewCellStyle myStyle = new DataGridViewCellStyle();
                    DataGridViewCellStyle myStyle1 = new DataGridViewCellStyle();
                    myStyle.BackColor = Color.MediumPurple;
                    myStyle.ForeColor = Color.White;
                    myStyle1.ForeColor = Color.Black;
                    int drow2select = 0;
                    int ij = 0;
                    int jk = 0;
                    int kj = 0;
                    string strNewFilter = "";
                    switch (cboCriteria.Text)
                    {
                        case "=":
                            strNewFilter = tFilter.Text;
                            break;
                        case "Containing":
                            strNewFilter = "*" + tFilter.Text + "*";
                            break;
                        case "Start With":
                            strNewFilter = tFilter.Text + "*";
                            break;
                        case "End with":
                            strNewFilter = "*" + tFilter.Text;
                            break;
                    }

                    while (x < dGrid.Rows.Count)
                    {
                        int y = 0;
                        if (chkIgnore.Checked == true)
                        {
                            jk = dGrid.Rows[x].Cells.Count - 1;
                            kj = 0;
                        }
                        else
                        {
                            kj = Convert.ToInt16(SelColumn.Value) - 1;
                            jk = Convert.ToInt16(SelColumn.Value) - 1;
                        }
                        for (y = kj; y <= jk; y++)
                        {
                            if (!(dGrid[y, x].Value == DBNull.Value))
                            {
                                if (Microsoft.VisualBasic.CompilerServices.StringType.StrLike(dGrid[y, x].Value.ToString().ToLower(), strNewFilter.ToLower(), Microsoft.VisualBasic.CompareMethod.Binary))
                                {
                                    dGrid[y, x].Style = myStyle;
                                    ij = ij + 1;
                                    if (drow2select == 0) drow2select = x;
                                }
                            }
                        }
                        x = x + 1;
                    }
                    if (ij == 0)
                    {
                        MessageBox.Show("Match Not Found!");
                    }
                    else
                    {
                        // dGrid.Rows[drow2select].Selected=true;
                        dGrid.CurrentCell = dGrid.Rows[drow2select].Cells[0];
                        MessageBox.Show("(" + ij.ToString() + ") Match Found");
                    }

                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ooops! ERROR :" + char.ConvertFromUtf32(13) + ex, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void PassFilter( DataGridView datagridview, string strFilter)
        {
            int i = 0;
            int j = 0;
            int jk = 0;
            int kj = 0;
            int wr = 0;
            bool containStr = false;
            // Row indexes we'll remove later on.
            List<int> deleteIndexList = new List<int>();

            string strNewFilter = "";
            switch (cboCriteria.Text)
            {
                case "=":
                    strNewFilter = strFilter;
                    break;
                case "Containing":
                    strNewFilter = "*" + strFilter + "*";
                    break;
                case "Start With":
                    strNewFilter = strFilter + "*";
                    break;
                case "End With":
                    strNewFilter = "*" + strFilter;
                    break;
            }
            while (i < datagridview.Rows.Count)
            {
                j = 0;
                containStr = false;

                if (chkIgnore.Checked == true)
                {
                    jk = datagridview.Rows[i].Cells.Count - 1;
                    kj = 0;
                }
                else
                {
                    kj = Convert.ToInt16(SelColumn.Value) - 1;
                    jk = Convert.ToInt16(SelColumn.Value) - 1;
                }
                for (j = kj; j <= jk; j++)
                {
                    if (!(datagridview[j, i].Value == null))

                    {
                        if (cboCriteria.Text == "<>")
                        {
                            if (datagridview[j, i].Value.ToString().ToLower() != strNewFilter.ToLower())

                            {
                                containStr = true;
                                wr = wr + 1;
                                break;
                            }
                        }
                        else
                        {
                            if (Microsoft.VisualBasic.CompilerServices.StringType.StrLike(datagridview[j, i].Value.ToString().ToLower(), strNewFilter.ToLower(), Microsoft.VisualBasic.CompareMethod.Binary))
                            {
                                containStr = true;
                                wr = wr + 1;
                                break;
                            }
                        }
                    }
                }
                if (!containStr)
                {
                    // Don't remove rows here or your row indexes will get out of whack!
                    // datagridview.Rows.RemoveAt(i)
                    deleteIndexList.Add(i);
                }
                i = i + 1;
            }
            // Remove rows by reversed row index order (highest removed first) to keep the indexes in whack.
            deleteIndexList.Reverse();
            foreach (int idx in deleteIndexList)
            {
                datagridview.Rows.RemoveAt(idx);
            }
            lblCount.Text ="List Count:"+ wr.ToString();
        }

        private void cmdFilter_Click(object sender, EventArgs e)
        {
            PassFilter(dGrid, tFilter.Text);
    
        }

        private void tFilter_KeyDown(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar = Keys.Enter)
            //{
            //    cmdFilter_Click(sender, e);
            //}
        }

        private void cmdPrintLIst_Click(object sender, EventArgs e)
        {
            try
            {
                dynamic oXL = System.Activator.CreateInstance(System.Type.GetTypeFromProgID("Excel.Application"));
                oXL.Visible = true;
                oXL.Workbooks.Add();

                oXL.Sheets(1).Select();

                oXL.Visible = true;

                // Format A1:D1 as bold, vertical alignment = center.
                oXL.Sheets(1).Range("A1", "AZ1").Font.Bold = true;
                // .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter

                int jk = 0;
                for (var j = 0; j < dGrid.ColumnCount; j++)
                {
                    oXL.Cells[1, j + 1] = dGrid.Columns[j].Name.ToString();
                }

                for (var i = 0; i < dGrid.RowCount; i++)
                {
                    if (dGrid.Rows[i].Selected == true)
                    {
                        for (var j = 0; j < dGrid.ColumnCount; j++)
                        {
                            if (Microsoft.VisualBasic.Information.IsNumeric(dGrid[j, i].Value))
                            {
                                oXL.Cells[jk + 2, j + 1].NumberFormat = "@";
                                oXL.Cells[jk + 2, j + 1] = dGrid[j, i].Value;
                            }
                            else
                            {
                                oXL.Cells[jk + 2, j + 1] = dGrid[j, i].Value;
                            }

                        }
                        jk = jk + 1;
                    }
                }
                // Make sure Excel is visible and give the user control
                // of Excel's lifetime.

                oXL.UserControl = true;

                // Make sure that you release object references.
                oXL.Quit();
                oXL = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ooops! ERROR :" + char.ConvertFromUtf32(13) + ex, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dGrid_DoubleClick(object sender, EventArgs e)
        {
            if (mnuEdit.Enabled == true)
            {
                FrmSchoolInfor ChildForm = new FrmSchoolInfor("Edit", ReturnCode);
                ChildForm.ShowDialog();
                LoadLvList(strQryMain);
            }
        }

        private void CmbCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTV(CmbCriteria.Text.ToString());
        }
    }
}
