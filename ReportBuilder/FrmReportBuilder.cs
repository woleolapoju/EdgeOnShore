using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Data.Common;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Timers;

namespace Edge
{

    enum CallFor
    {
        SqlServerList,
        SqlDataBases,
        SqlTables
    }

    public partial class FrmReportBuilder : Form
    {
        private string connectionString;
        private string sqlQuery;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataAdapter adapter;
        private SqlCommandBuilder builder;
        private DataSet ds;
        private DataSet tempDataSet;
        private DataTable userTable;
        private SQLInfoEnumerator sqlInfo;
        private SqlDataReader reader;
        private delegate string[] InternalDelegate();
        private InternalDelegate intlDelg;
        private delegate void AsyncDelegate(IAsyncResult result);
        private delegate void TimerDelegate(object sender, ElapsedEventArgs e);
        private System.Timers.Timer ticker;
        private CallFor called;
        private int currentIndex;
        private bool isLastPage;
        private int totalRecords;
        private int currentPageStartRecord;
        private int currentPageEndRecord;
        private const string getTablesFromDataBase = "SELECT NAME FROM SYSOBJECTS WHERE TYPE = 'U'";

        public FrmReportBuilder()
        {
            InitializeComponent();
            btnUpdate.Enabled = false;
            sqlInfo = new SQLInfoEnumerator();
            grpDataManipulate.Enabled = false;
            btnLoadSqlServers.Select();
            btnLoadSqlServers.Focus();
            prgProgress.Minimum = 0;
            prgProgress.Maximum = 200;
            ticker = new System.Timers.Timer();
            intlDelg = new InternalDelegate(sqlInfo.EnumerateSQLServers);
            ticker.Elapsed += new ElapsedEventHandler(ticker_Elapsed);
            ticker.Interval = 250;
            cmbNoOfRecords.SelectedIndex = 0;
            btnFirst.Enabled = false;
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            btnLast.Enabled = false;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            cmbNoOfRecords.Enabled = false;

            cmbSqlServers.Items.Add(MyModules.ServerName);
            cmbSqlServers.Text = MyModules.ServerName;


            txtUserName.Text = MyModules.UserID;
            txtPassword.Text = MyModules.Password;
            cmbAllDataBases.Items.Add(MyModules.AttachName);
            cmbAllDataBases.Text = MyModules.AttachName;
            chkWinAuthen.Checked = MyModules.IntegratedSecurity;

       
            object sender = null;
            EventArgs e = null;
          //  btnGetAllDataBases_Click(sender, e);

            btnGetAllTables_Click(sender, e);

            cboCriteria.SelectedIndex = 1;
        }

        private void SetDataObjects()
        {
            connection = new SqlConnection(connectionString);
            command = new SqlCommand(sqlQuery, connection);
            adapter = new SqlDataAdapter(command);
            builder = new SqlCommandBuilder(adapter);
            ds = new DataSet("MainDataSet");
            tempDataSet = new DataSet("TempDataSet");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
         //  lblLoadedTable.Text = "Loading data from table " + cmbTables.Text.Trim();
            btnLoad.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (userTable != null)
                {
                    userTable.Clear();
                }
                userDataGridView.DataSource = null;
                userDataGridView.Rows.Clear();
                userDataGridView.Refresh();
                sqlQuery = "SELECT * FROM [" + cmbTables.Text.Trim() + "]";
                SetDataObjects();
                connection.Open();
                ticker.Start();
                adapter.Fill(tempDataSet);
                totalRecords = tempDataSet.Tables[0].Rows.Count;
                tempDataSet.Clear();
                tempDataSet.Dispose();
                adapter.Fill(ds, 0, 5, cmbTables.Text.Trim());
                userTable = ds.Tables[cmbTables.Text.Trim()];

                foreach (DataColumn dc in userTable.Columns)
                {
                    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                    column.DataPropertyName = dc.ColumnName;
                    column.HeaderText = dc.ColumnName;
                    column.Name = dc.ColumnName;
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                    column.ValueType = dc.DataType;
                    userDataGridView.Columns.Add(column);
                }
             //   lblLoadedTable.Text = "Data loaded from table: " + userTable.TableName;
                lblTotRecords.Text = "Total records: " + totalRecords;
                btnAdd.Enabled = true;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                cmbNoOfRecords.Enabled = true;

                if (cmbNoOfRecords.Text.Trim() == "ALL")
                {

                    CreateTempTable(0, totalRecords); // int.Parse(lblTotRecords.Text.Trim()));

                    btnFirst.Enabled = false;
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                    grpDataManipulate.Enabled = false;
                }
                else
                {
                    CreateTempTable(0, int.Parse(cmbNoOfRecords.Text.Trim()));
                    if (int.Parse(cmbNoOfRecords.Text.Trim()) > totalRecords)
                    {
                        btnFirst.Enabled = false;
                        btnPrevious.Enabled = false;
                        btnNext.Enabled = false;
                        btnLast.Enabled = false;
                        grpDataManipulate.Enabled = false;
                    }
                    else
                    {
                        btnFirst.Enabled = true;
                        btnPrevious.Enabled = true;
                        btnNext.Enabled = true;
                        btnLast.Enabled = true;
                        grpDataManipulate.Enabled = true;
                    }
                    //btnPrevious.Enabled = true;
                    //btnFirst.Enabled = true;
                    //btnPrevious.Enabled = true;
                    //btnNext.Enabled = true;
                    //btnLast.Enabled = true;
                   
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                connection.Close();
                btnLoad.Enabled = true;
                this.Cursor = Cursors.Default;
                prgProgress.Value = 0;
                prgProgress.Update();
                prgProgress.Refresh();
                ticker.Stop();
            }
        }

        private void CreateTempTable(int startRecord, int noOfRecords)
        {
            if (startRecord == 0 || startRecord < 0)
            {
                btnPrevious.Enabled = false;
                startRecord = 0;
            }
            int endRecord = startRecord + noOfRecords;
            if (endRecord >= totalRecords)
            {
                btnNext.Enabled = false;
                isLastPage = true;
                endRecord = totalRecords;
            }
            currentPageStartRecord = startRecord;
            currentPageEndRecord = endRecord;
            lblPageNums.Text = "Records from " + startRecord + " to "
                + endRecord + " of " + totalRecords;
            currentIndex = endRecord;

            try
            {
                userTable.Rows.Clear();
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                adapter.Fill(ds, startRecord, noOfRecords, cmbTables.Text.Trim());
                userTable = ds.Tables[cmbTables.Text.Trim()];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                connection.Close();
            }

            userDataGridView.DataSource = userTable.DefaultView;
            userDataGridView.AllowUserToResizeColumns = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                userDataGridView.ReadOnly = false;
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                adapter.Update(userTable);
                userDataGridView.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                btnUpdate.Enabled = true;
            }
            finally
            {
                btnAdd.Enabled = true;
                btnLoad.Enabled = true;
                connection.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete selected record(s)?",
                "Delete Warning", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false)
                == DialogResult.Yes)
            {
                try
                {
                    connection.Open();
                    int cnt = userDataGridView.SelectedRows.Count;
                    for (int i = 0; i < cnt; i++)
                    {
                        if (this.userDataGridView.SelectedRows.Count > 0 &&
                            this.userDataGridView.SelectedRows[0].Index !=
                            this.userDataGridView.Rows.Count - 1)
                        {
                            this.userDataGridView.Rows.RemoveAt(
                               this.userDataGridView.SelectedRows[0].Index);
                        }
                    }

                    adapter.Update(userTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    connection.Close();
                    btnLoad.Enabled = true;
                }
            }
        }

        private void btnLoadSqlServers_Click(object sender, EventArgs e)
        {
            ticker.Start();
            btnLoadSqlServers.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            cmbSqlServers.Items.Clear();
            cmbSqlServers.Items.Add(MyModules.ServerName);
            called = CallFor.SqlServerList;
            intlDelg.BeginInvoke(new AsyncCallback(CallBackMethod), intlDelg);
           
            cmbSqlServers.Text = MyModules.ServerName;

        }

        void ticker_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new TimerDelegate(ticker_Elapsed), sender, e);
            }
            else
            {
                if (prgProgress.Value == prgProgress.Maximum)
                {
                    prgProgress.Value = 0;
                }
                else
                {
                    prgProgress.Value += 20;
                }
            }
        }

        private void btnGetAllDataBases_Click(object sender, EventArgs e)
        {
            if (cmbSqlServers.Items.Count > 0 &&
                txtPassword.Text.Trim().CompareTo(string.Empty) != 0 &&
                txtUserName.Text.Trim().CompareTo(string.Empty) != 0)
            {
                ticker.Start();
                btnGetAllDataBases.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                cmbAllDataBases.Items.Clear();
                sqlInfo.SQLServer = cmbSqlServers.Text.Trim();
                sqlInfo.Username = txtUserName.Text.Trim();
                sqlInfo.Password = txtPassword.Text.Trim();
                MessageBox.Show("You may get the list sql servers if user name and password are not correct.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1, 0, false);
                intlDelg = new InternalDelegate(sqlInfo.EnumerateSQLServersDatabases);
                called = CallFor.SqlDataBases;
                intlDelg.BeginInvoke(new AsyncCallback(CallBackMethod), intlDelg);
            }
            else
            {
                MessageBox.Show("No sql servers loaded or user name or password empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, 0, false);
            }
        }

        private void btnGetAllTables_Click(object sender, EventArgs e)
        {
            if (cmbAllDataBases.Text.Trim().CompareTo(string.Empty) != 0)
            {
                btnGetAllTables.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                StringBuilder connStr = new StringBuilder();
                connStr.Append("Database=");
                connStr.Append(cmbAllDataBases.Text);
                connStr.Append(";Server=");
                connStr.Append(cmbSqlServers.Text);
                connStr.Append(";User=");
                connStr.Append(txtUserName.Text.Trim());
                connStr.Append(";Password=");
                connStr.Append(txtPassword.Text.Trim());
                connStr.Append(";Enlist=false; Asynchronous Processing=true");
                connectionString = connStr.ToString();
                sqlQuery = getTablesFromDataBase;
                SetDataObjects();
                try
                {
                    ticker.Start();
                    connection.Open();
                    command.BeginExecuteReader(new AsyncCallback(CallBackMethod),
                        command, CommandBehavior.CloseConnection);
                    called = CallFor.SqlTables;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    ticker.Stop();
                }
                finally
                {
                    btnGetAllTables.Enabled = true;
                    this.Cursor = Cursors.Default;
                }
            }
            else
            {
                MessageBox.Show("Please select database first.",
                    "No database", MessageBoxButtons.OK, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1, 0, false);
            }
        }

        private void CallBackMethod(IAsyncResult result)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new AsyncDelegate(CallBackMethod), result);
            }
            else
            {
                try
                {
                    prgProgress.Value = prgProgress.Maximum;
                    switch (called)
                    {
                        case CallFor.SqlServerList:
                            string[] sqlServers = intlDelg.EndInvoke(result);
                            cmbSqlServers.Items.AddRange(sqlServers);
                            if (cmbSqlServers.Items.Count > 0)
                            {
                                cmbSqlServers.Sorted = true;
                                cmbSqlServers.SelectedIndex = 0;
                            }
                            this.Cursor = Cursors.Default;
                            btnLoadSqlServers.Enabled = true;
                            txtUserName.Select();
                            txtUserName.Focus();
                            break;
                        case CallFor.SqlDataBases:
                            string[] sqlDatabases = intlDelg.EndInvoke(result);
                            cmbAllDataBases.Items.AddRange(sqlDatabases);
                            if (cmbAllDataBases.Items.Count > 0)
                            {
                                cmbAllDataBases.Sorted = true;
                                cmbAllDataBases.SelectedIndex = 0;
                            }
                            this.Cursor = Cursors.Default;
                            btnGetAllDataBases.Enabled = true;
                            break;
                        case CallFor.SqlTables:
                            reader = command.EndExecuteReader(result);
                            cmbTables.Items.Clear();
                            while (reader.Read())
                            {
                                cmbTables.Items.Add(reader[0].ToString());
                            }
                            if (cmbTables.Items.Count > 0)
                            {
                                cmbTables.Sorted = true;
                                cmbTables.SelectedIndex = 0;
                                grpDataManipulate.Enabled = true;
                            }
                            else
                            {
                                grpDataManipulate.Enabled = false;
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    if (called == CallFor.SqlTables)
                    {
                        btnGetAllTables.Enabled = true;
                        this.Cursor = Cursors.Default;
                    }
                    prgProgress.Value = 0;
                    prgProgress.Refresh();
                    ticker.Stop();
                }
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            CreateTempTable(0, int.Parse(cmbNoOfRecords.Text));
            btnPrevious.Enabled = false;
            btnNext.Enabled = true;
            btnLast.Enabled = true;
            isLastPage = false;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (isLastPage)
            {
                int noc = FindLastPageRecords();
                CreateTempTable((totalRecords - noc - int.Parse(cmbNoOfRecords.Text)),
                    int.Parse(cmbNoOfRecords.Text));
            }
            else
            {
                CreateTempTable((currentIndex - 2 * (int.Parse(cmbNoOfRecords.Text))),
                    int.Parse(cmbNoOfRecords.Text));
            }
            btnNext.Enabled = true;
            btnLast.Enabled = true;
            isLastPage = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            CreateTempTable(currentIndex, int.Parse(cmbNoOfRecords.Text));
            btnPrevious.Enabled = true;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int totPages = totalRecords / int.Parse(cmbNoOfRecords.Text);
            int remainingRecs = FindLastPageRecords();

            CreateTempTable(totalRecords - remainingRecs, int.Parse(cmbNoOfRecords.Text));
            btnPrevious.Enabled = true;
            btnNext.Enabled = false;
            isLastPage = true;
        }

        private int FindLastPageRecords()
        {
            return (totalRecords % int.Parse(cmbNoOfRecords.Text));
        }

        private void btnNoOfPages_Click(object sender, EventArgs e)
        {
            if (cmbNoOfRecords.Text.Trim() == "ALL")
            {

                CreateTempTable(0, totalRecords); // int.Parse(lblTotRecords.Text.Trim()));

                btnFirst.Enabled = false;
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
                btnLast.Enabled = false;
                grpDataManipulate.Enabled = false;
            }
            else
            {
                CreateTempTable(0, int.Parse(cmbNoOfRecords.Text.Trim()));
                if (int.Parse(cmbNoOfRecords.Text.Trim()) > totalRecords)
                {
                    btnFirst.Enabled = false;
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                    grpDataManipulate.Enabled = false;
                }
                else
                {
                    btnFirst.Enabled = true;
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = true;
                    btnLast.Enabled = true;
                    grpDataManipulate.Enabled = true;
                }
            }
        }

        private void FrmReportBuilder_Load(object sender, EventArgs e)
        {
            MyModules.applyGridTheme(userDataGridView);
            userDataGridView.ReadOnly = true;
        }

        private void cmbSqlServers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkWinAuthen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWinAuthen.Checked == true)
            {
                txtUserName.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtUserName.Enabled = true;
                txtPassword.Enabled = true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnLoad_Click( sender,  e);

        }

        private void panel3_DoubleClick(object sender, EventArgs e)
        {
            string value = "";
            if (MyModules.InputBox("Modification Access", "Enter Passcode:", ref value, true) == DialogResult.OK)
            {
                if (value == "L/?")
                {
                    btnAdd.Visible = true;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    userDataGridView.ReadOnly = false;
                }
            }

        }

        private void userDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
            
        {
            try {
                SelColumn.Value = e.ColumnIndex + 1;
                tFilter.Text = userDataGridView[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
            catch
            {

            }
        }

        private void cmdFilter_Click(object sender, EventArgs e)
        {
            PassFilter(userDataGridView, tFilter.Text);
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
            lblCount.Text = wr.ToString();
        }

        private void cmdFind_Click(object sender, EventArgs e)
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

                while (x < userDataGridView.Rows.Count)
                {
                    int y = 0;
                    if (chkIgnore.Checked == true)
                    {
                        jk = userDataGridView.Rows[x].Cells.Count - 1;
                        kj = 0;
                    }
                    else
                    {
                        kj = Convert.ToInt16(SelColumn.Value) - 1;
                        jk = Convert.ToInt16(SelColumn.Value) - 1;
                    }
                    for (y = kj; y <= jk; y++)
                    {
                        if (!(userDataGridView[y, x].Value == DBNull.Value))
                        {
                            if (Microsoft.VisualBasic.CompilerServices.StringType.StrLike(userDataGridView[y, x].Value.ToString().ToLower(), strNewFilter.ToLower(), Microsoft.VisualBasic.CompareMethod.Binary))
                            {
                                userDataGridView[y, x].Style = myStyle;
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

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            btnLoad_Click(sender, e);

            tFilter.Text = "";
            SelColumn.Maximum = userDataGridView.Columns.Count;
        }

        private void mnuExportToExcel_Click(object sender, EventArgs e)
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
                for (var j = 0; j < userDataGridView.ColumnCount; j++)
                {
                    oXL.Cells[1, j + 1] = userDataGridView.Columns[j].Name.ToString();
                }

                for (var i = 0; i < userDataGridView.RowCount; i++)
                {
                    if (userDataGridView.Rows[i].Selected == true)
                    {
                        for (var j = 0; j < userDataGridView.ColumnCount; j++)
                        {
                            if (Microsoft.VisualBasic.Information.IsNumeric(userDataGridView[j, i].Value))
                            {
                                oXL.Cells[jk + 2, j + 1].NumberFormat = "@";
                                oXL.Cells[jk + 2, j + 1] = userDataGridView[j, i].Value;
                            }
                            else
                            {
                                oXL.Cells[jk + 2, j + 1] = userDataGridView[j, i].Value;
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

        private void mnuCopyToClipboard_Click(object sender, EventArgs e)
        {
            userDataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;

            if (userDataGridView.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {

                try
                {

                    // Add the selection to the clipboard.
                    Clipboard.SetDataObject(userDataGridView.GetClipboardContent());

                    // Replace the text box contents with the clipboard text.
                    //Me.TextBox1.Text = Clipboard.GetText()
                    MessageBox.Show("Successfull!!", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("The Clipboard could not be accessed. Please try again.");
                }

            }
        }
    }
}