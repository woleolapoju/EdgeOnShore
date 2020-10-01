using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edge
{
    public partial class FrmRegister : Form
    {
        AppAction Action;

        private BindingSource BindingSource1 = new BindingSource();
        public FrmRegister()
        {
            InitializeComponent();
        }
        private void FrmRegister_Load(object sender, EventArgs e)
        {
            mnuNew.Enabled = MyModules.GetUserAccessDetails("Add New Contractor", false);
            mnuEdit.Enabled = MyModules.GetUserAccessDetails("Edit Contractor", false);
            mnuDelete.Enabled = MyModules.GetUserAccessDetails("Delete Contractor", false);
            mnuBrowse.Enabled = mnuEdit.Enabled || mnuDelete.Enabled;
            dataGridViewJobs.DataSource = BindingSource1;
          if (mnuNew.Enabled)  mnuNew_Click(sender, e);

            MyModules.applyGridTheme(dataGridViewJobs);

            dataGridViewJobs.ReadOnly = false;
            dataGridViewJobs.AllowUserToAddRows = true;
            dataGridViewJobs.AllowUserToDeleteRows = true;
            dataGridViewJobs.Columns[0].Visible = false;
            dataGridViewJobs.Columns[1].Width = 100;
            dataGridViewJobs.Columns[2].Width = 250;
            dataGridViewJobs.Columns[3].Width = 100;
            dataGridViewJobs.Columns[4].Width = 60;



        }

        private void cmdGetFile_Click(object sender, EventArgs e)
        {
            if (MyModules.eDocFilePath == "")
            {
                MessageBox.Show("Please specify the path to save the eDocument" + char.ConvertFromUtf32(13) + "Using the Company Information menu", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                OpenFileDialog OpenFileDialog = new OpenFileDialog();
                OpenFileDialog.InitialDirectory = MyModules.eDocFilePath;
                OpenFileDialog.Filter = "PDF|*.pdf";
                OpenFileDialog.FilterIndex = 1;
                tFileName.Text = "";
                if (OpenFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    string FileName = OpenFileDialog.FileName;
                    tFileName.Text = FileName;
                }
            }

        }

        private void mnuNew_Click(object sender, EventArgs e)
        {

            Action = AppAction.Add;
            InitialiseAction();
        }


        private void InitialiseAction()
        {
             if (Action == AppAction.Add)
            {
                lblAction.Text = "New Record";
                cmdOk.Visible = true;
            }
             else if (Action == AppAction.Browse)
            {
                lblAction.Text = "Browse Record";
                cmdOk.Visible = false;
            }
             else if (Action == AppAction.Edit)
            {
                lblAction.Text = "Edit Record";
                cmdOk.Visible = true;
            }
            else if (Action == AppAction.Delete)
            {
                lblAction.Text = "Delete Record";
                cmdOk.Visible = true;
            }
            else if (Action == AppAction.Authorise)
            {
                lblAction.Text = "Authorise Record";
            }
            Flush();
        }


        private void Flush()
        {
            
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            Action = AppAction.Edit;
            InitialiseAction();
        }

        private void mnuBrowse_Click(object sender, EventArgs e)
        {
            Action = AppAction.Browse;
            InitialiseAction();
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            Action = AppAction.Delete;
            InitialiseAction();
        }
    }
}
