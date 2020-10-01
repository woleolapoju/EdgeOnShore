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
    public partial class FrmPaymentType : Form
    {
        private BindingSource BindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter1 = new SqlDataAdapter();
        public FrmPaymentType()
        {
            InitializeComponent();
        }

     
        private void FrmPaymentType_Load(object sender, EventArgs e)
        {
            this.DbGrid.DataSource = BindingSource1;
            DbGrid.AutoGenerateColumns = false;
            GetData("select * from PaymentType ORDER BY SN");
            MyModules.applyGridTheme(DbGrid);
            DbGrid.ReadOnly = false;
            DbGrid.AllowUserToAddRows = true;
            DbGrid.AllowUserToDeleteRows = true;
        }

        private void GetData(string selectCommand)
        {

            try
            {

                dataAdapter1 = new SqlDataAdapter(selectCommand,MyModules.strConnect);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(this.dataAdapter1);
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                this.dataAdapter1.Fill(table);
                this.BindingSource1.DataSource = table;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            dataAdapter1.Update((DataTable)BindingSource1.DataSource);
            MessageBox.Show("Update successfull",MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            GetData(dataAdapter1.SelectCommand.CommandText);
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dbGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            if (e.Context == DataGridViewDataErrorContexts.Commit)
            {
                DbGrid.Rows[e.RowIndex].ErrorText = e.Exception.ToString();
                e.Cancel = true;
            }

        }

        private void dbGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (DbGrid.Rows[e.RowIndex].IsNewRow)
            {

                DbGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
                DbGrid.Rows[e.RowIndex].Selected = false;

                if (!(DbGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected))
                {
                    DbGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                }
            }
            else
            {
                DbGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                if (!(DbGrid.Rows[e.RowIndex].Selected))
                {
                    DbGrid.Rows[e.RowIndex].Selected = true;
                }
            }
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            if (!DbGrid.IsCurrentCellInEditMode)
            {
                DbGrid.CurrentCell = DbGrid.Rows[DbGrid.Rows.Count - 1].Cells["Sn"];
            }

        }
    }


}
