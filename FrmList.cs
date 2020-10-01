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

    public partial class FrmList : Form
    {
 
        public static string dCaption;
        public static string listQuery1;
        public static string qryPrm = "";
        public int colIndex = 0;
        private BindingSource bindingSource = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
    
        public object ReturnValue { get; set; }
        public object ReturnValue1 { get; set; }
        public FrmList(string listQuery, string dCaption)
        {
            InitializeComponent();
            this.Text = dCaption;
            listQuery1 = listQuery;

        }

   
        private void FrmList_Load(object sender, EventArgs e)
        {
            DGrid.DataSource = bindingSource;
            cboCriteria.SelectedIndex = 1;

            MyModules.applyGridTheme(DGrid);
            DGrid.RowHeadersWidth = 12;
            DGrid.ColumnHeadersHeight = 22;
            DGrid.ReadOnly = true;
            LoadLvList();
        }


        public void LoadLvList()
        {
            try
            {

                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand("FetchUserAccessByPwd", cnSQL);
                cmdOk.Visible = true;
                cmSQL.CommandType = CommandType.StoredProcedure;
                switch (listQuery1)
                {
                    case "SystemUser":
                        cmSQL.CommandText = "FetchAllUserAccess";
                        // '-------------Accounts
                        break;
                    case "ActiveSchoolList":
                        cmSQL.CommandText = "SELECT [Sn] AS RefNo,[SchName] ,[SchAddress],[State] FROM [RegisterSchool] WHERE InActive=0";
                        cmSQL.CommandType = CommandType.Text;
                        break;
                    case "AllPayRequest":
                        cmSQL.CommandText = "AC_FetchAllPayRequest";
                        cmSQL.Parameters.AddWithValue("@BillType", qryPrm);
                        break;
                 

                }

                cnSQL.Open();
                dataAdapter = new SqlDataAdapter(cmSQL); //"AC_FetchAllPaymentVouchers", strConnect)
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(this.dataAdapter);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                this.dataAdapter.Fill(table);
                this.bindingSource.DataSource = table;

                cmSQL.Dispose();

                DGrid.Refresh();

                lblCount.Text = DGrid.Rows.Count.ToString();


                //filterStatusLabel.Text = DGrid.Rows.Count.ToString + " of " + DGrid.Rows.Count.ToString


                SelColumn.Minimum = 1;
                SelColumn.Maximum = DGrid.Columns.Count;

                MyModules.formatGrid(DGrid);


                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ooops! ERROR :" + char.ConvertFromUtf32(13) + ex, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //  MessageBox.Show("Ooops! ERROR", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void PassFilter(DataGridView datagridview, string strFilter)
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
                    kj =Convert.ToInt16(SelColumn.Value) - 1;
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
            lblCount.Text = wr.ToString();
        }

private void cmdFind_Click(object sender, System.EventArgs e)
        {
            try
            {
                int x = 0;

                DataGridViewCellStyle myStyle = new DataGridViewCellStyle();
                DataGridViewCellStyle myStyle1 = new DataGridViewCellStyle();
                myStyle.ForeColor = Color.Red;
                myStyle1.ForeColor = Color.Black;
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

                while (x < DGrid.Rows.Count)
                {
                    int y = 0;
                    if (chkIgnore.Checked == true)
                    {
                        jk = DGrid.Rows[x].Cells.Count - 1;
                        kj = 0;
                    }
                    else
                    {
                        kj = Convert.ToInt16(SelColumn.Value) - 1;
                        jk = Convert.ToInt16(SelColumn.Value) - 1;
                    }
                    for (y = kj; y <= jk; y++)
                    {
                        if (!(DGrid[y, x].Value == DBNull.Value))
                        {
                            if (Microsoft.VisualBasic.CompilerServices.StringType.StrLike(DGrid[y, x].Value.ToString().ToLower(), strNewFilter.ToLower(), Microsoft.VisualBasic.CompareMethod.Binary))
                            {
                                DGrid[y, x].Style = myStyle;
                                ij = ij + 1;
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
                    MessageBox.Show("(" + ij.ToString() + ") Match Found");
                }

                return;
            }
            catch (Exception ex)
            {
                     MessageBox.Show("Ooops! ERROR :" + char.ConvertFromUtf32(13) + ex, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mnuExportToExcel_Click(object sender, System.EventArgs e)
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
                for (var j = 0; j < DGrid.ColumnCount; j++)
                {
                    oXL.Cells[1, j + 1] = DGrid.Columns[j].Name.ToString();
                }

                for (var i = 0; i < DGrid.RowCount; i++)
                {
                    if (DGrid.Rows[i].Selected == true)
                    {
                        for (var j = 0; j < DGrid.ColumnCount; j++)
                        {
                            if (Microsoft.VisualBasic.Information.IsNumeric(DGrid[j, i].Value))
                            {
                                oXL.Cells[jk + 2, j + 1].NumberFormat = "@";
                                oXL.Cells[jk + 2, j + 1] = DGrid[j, i].Value;
                            }
                            else
                            {
                                oXL.Cells[jk + 2, j + 1] = DGrid[j, i].Value;
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

        private void mnuCopyToClipboard_Click(object sender, System.EventArgs e)
        {

            DGrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;

            if (DGrid.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {

                try
                {

                    // Add the selection to the clipboard.
                    Clipboard.SetDataObject(DGrid.GetClipboardContent());

                    // Replace the text box contents with the clipboard text.
                    //Me.TextBox1.Text = Clipboard.GetText()
                    MessageBox.Show("Successfull!!",MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch 
                {
                    MessageBox.Show("The Clipboard could not be accessed. Please try again.");
                }

            }
        }


        private void DGrid_DoubleClick(object sender, EventArgs e)
        {
            if (DGrid.Tag.ToString() == "")
            {
                return;
            }
            cmdOk_Click(sender, e);
            DGrid.Tag = "";
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            switch (listQuery1)
            {
              case "SystemUser":
                this.ReturnValue = DGrid.Tag.ToString();
               this.DialogResult = DialogResult.OK;
              break;
                case "ActiveSchoolList":
                    this.ReturnValue = DGrid.Tag.ToString();
                    this.ReturnValue1 = this.Tag.ToString();
                    this.DialogResult = DialogResult.OK;
                    break;




            }

        }

     

        private void DGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {   DGrid.Tag = DGrid[0, e.RowIndex].Value;
                this.Tag = DGrid[1, e.RowIndex].Value;
                SelColumn.Value = e.ColumnIndex + 1;
                tFilter.Text = DGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
            catch
            {

            }
        }

        private void DGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tFilter_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdFilter_Click(object sender, EventArgs e)
        {
            PassFilter(DGrid, tFilter.Text);
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
 

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(this.dataAdapter);
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            this.dataAdapter.Fill(table);
            this.bindingSource.DataSource = table;

            tFilter.Text = "";
            SelColumn.Maximum = DGrid.Columns.Count;

        }

    }
}
