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
    public partial class FrmSearch : Form
    {
        BindingSource bindingSource1 = new BindingSource();
        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        public FrmSearch()
        {
            InitializeComponent();
        }

        private void FrmSearch_Load(object sender, EventArgs e)
        {
            DbGrid.DataSource = bindingSource1;
            DbGrid.AutoGenerateColumns = false;

            cboCriteria.SelectedIndex = 0;

            MyModules.applyGridTheme(DbGrid);
            DbGrid.ReadOnly = true;

            DbGrid.Columns["MandateNo"].Width = 120;
            DbGrid.Columns["dIndex"].Visible=false;
            DbGrid.Columns["tDate"].Width = 80;
            DbGrid.Columns["tBName"].Width = 140;
            DbGrid.Columns["Amount"].Width = 80;
            DbGrid.Columns["Bank"].Width = 120;
            DbGrid.Columns["BankAcctNo"].Width = 100;
            DbGrid.Columns["PayType"].Width = 100;
            DbGrid.Columns["PayDetails"].Width = 150;
            DbGrid.Columns["MainAction"].Width = 80;



        }
        private void GetData(string selectCommand)
        {

            try
            {

                dataAdapter = new SqlDataAdapter(selectCommand, MyModules.strConnect);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(this.dataAdapter);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                this.dataAdapter.Fill(table);
                this.bindingSource1.DataSource = table;

                lblCount.Text = DbGrid.Rows.Count.ToString();

            }
            catch //(SqlException ex)
            {
                MessageBox.Show("Invalid Search String", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "";
                switch (cboCriteria.Text)
                {

                    case "BENEFICIARY NAME":
                        str = "SELECT MandateNo, dIndex, PayValueDate, Name, Amount, BankName, BankAcctNo, PayDetails, Source, 'Main' AS MainAction  FROM Payment WHERE [Name] like '%" + tFilter.Text + "%'";
                        str = str + " UNION SELECT MandateNo, dIndex, PayValueDate, Name, Amount, '' AS BankName, '' AS BankAcctNo, PayDetails, Source, MainAction  FROM PaymentDeductions WHERE [Name] like '%" + tFilter.Text + "%' ORDER BY MandateNo";
                        GetData(str);
                        break;
                    case "BANK":
                        str = "SELECT MandateNo, dIndex, PayValueDate, Name, Amount, BankName, BankAcctNo, PayDetails, Source, 'Main' AS MainAction  FROM Payment WHERE [BankName] like '%" + tFilter.Text + "%' ORDER BY MandateNo";
                         GetData(str);
                        break;
                    case "AMOUNT":
                        str = "SELECT MandateNo, dIndex, PayValueDate, Name, Amount, BankName, BankAcctNo, PayDetails, Source, 'Main' AS MainAction  FROM Payment WHERE [Amount] =" + tFilter.Text;
                        str = str + " UNION SELECT MandateNo, dIndex, PayValueDate, Name, Amount, '' AS BankName, '' AS BankAcctNo, PayDetails, Source, MainAction  FROM PaymentDeductions WHERE [Amount] =" + tFilter.Text + " ORDER BY MandateNo";
                        GetData(str);
                        break;
                    case "PAYMENT DETAILS":
                        str = "SELECT MandateNo, dIndex, PayValueDate, Name, Amount, BankName, BankAcctNo, PayDetails, Source, 'Main' AS MainAction  FROM Payment WHERE [PayDetails] like '%" + tFilter.Text + "%'";
                        str = str + " UNION SELECT MandateNo, dIndex, PayValueDate, Name, Amount, '' AS BankName, '' AS BankAcctNo, PayDetails, Source, MainAction  FROM PaymentDeductions WHERE [PayDetails] like '%" + tFilter.Text + "%' ORDER BY MandateNo";
                        GetData(str);
                        break;
                    case "PAY TYPE":
                        str = "SELECT MandateNo, dIndex, PayValueDate, Name, Amount, BankName, BankAcctNo, PayDetails, Source, 'Main' AS MainAction  FROM Payment WHERE [PayType] like '%" + tFilter.Text + "%' ORDER BY MandateNo";
                        GetData(str);
              
                        break;
                  
                }

                return;
            }

            catch //(SqlException ex)
            {
                MessageBox.Show("Invalid Search String", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void tFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmdSearch_Click(sender, e);
            }
        }

        private void DbGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                DbGrid.Tag = e.RowIndex;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewLinkColumn && e.RowIndex >= 0)
                {

                    if (senderGrid.Columns[e.ColumnIndex].Name == "MandateNo")
                    {

                        if (DbGrid["MainAction", e.RowIndex].Value.ToString() == "Main")
                        {
                            FrmPayment ChildForm = new FrmPayment(DbGrid[0, e.RowIndex].Value.ToString(), Convert.ToInt16(DbGrid["dIndex", e.RowIndex].Value));
                            ChildForm.cmdSave.Enabled = false;
                            ChildForm.ShowDialog();
                        }
                        else
                        {
                            FrmPayDeduction ChildForm1 = new FrmPayDeduction(DbGrid["MainAction", e.RowIndex].Value.ToString(), DbGrid[0, e.RowIndex].Value.ToString(), Convert.ToInt16(DbGrid["dIndex", e.RowIndex].Value));
                            ChildForm1.cmdSave.Enabled = false;
                            ChildForm1.ShowDialog();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
