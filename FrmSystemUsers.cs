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
    public partial class FrmSystemUsers : Form
    {
       AppAction Action;
      private  String ReturnUser="";
        public FrmSystemUsers()
        {
            InitializeComponent();
        }

        private void FrmSystemUsers_Load(object sender, EventArgs e)
        {
           

            mnuNew.Enabled = MyModules.ModuleAdd;
            mnuEdit.Enabled = MyModules.ModuleEdit;
            mnuBrowse.Enabled = MyModules.ModuleBrowse;
            mnuDelete.Enabled = MyModules.ModuleDelete;


            MyModules.applyGridTheme(ModuleDGV);
            ModuleDGV.ReadOnly = false;
            ModuleDGV.Columns["Modules"].ReadOnly = true;
            ModuleDGV.Columns["Modules"].Width = 150;


            if (mnuNew.Enabled == true)
                mnuNew_Click(sender, e);

        }

        private void InitialiseAction()
        {

            tUserName.Text = "";
            tUserID.Text = "";
            tPwd.Text = "";
            tConfirmPwd.Text = "";
            tUserName.Focus();
            chkSelectAll.Checked = false;

            cmdOk.Visible = true;
            tUserName.Enabled = true;
            if (Action == AppAction.Add)
            {
              
                lblAction.Text = "New User";
            tUserName.Focus();
            }

            if (Action == AppAction.Delete)
            {
                lblAction.Text = "Delete User";
                 tUserName.Enabled = false;
            }
            if (Action == AppAction.Edit)
            {
                lblAction.Text = "Edit User";
                tUserName.Enabled = true;

            }
            if (Action == AppAction.Browse)
            {
                lblAction.Text = "Browse User";
                tUserName.Enabled = false;
                cmdOk.Visible = false;

            }
        }
        private void cmdOk_Click(object sender, EventArgs e)
        {

            try
            {
               SqlTransaction myTrans = null;

              
                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand("FetchAllSystemParameters", cnSQL);
                cnSQL.Open();
              

                int i = 0;
               
                if (Action== AppAction.Add)
                {
                    if (string.IsNullOrEmpty(tPwd.Text.Trim(' ')) || string.IsNullOrEmpty(tConfirmPwd.Text.Trim(' ')) || string.IsNullOrEmpty(tUserName.Text.Trim(' ')))
                    {
                        MessageBox.Show("Incomplete data", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (tPwd.Text != tConfirmPwd.Text)
                    {
                        MessageBox.Show("Inconsistent Password", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    myTrans = cnSQL.BeginTransaction();
                    cmSQL.Transaction = myTrans;

                    cmSQL.Parameters.Clear();
                    cmSQL.CommandText = "InsertUserAccess";
                    cmSQL.CommandType = CommandType.StoredProcedure;
                    cmSQL.Parameters.AddWithValue("@UserID", tUserID.Text);
                    cmSQL.Parameters.AddWithValue("@UserPassword", tPwd.Text);
                    cmSQL.Parameters.AddWithValue("@UserName", tUserName.Text);
                    cmSQL.ExecuteNonQuery();
                 
                    for (i = 0; i < ModuleDGV.RowCount; i++)
                    {
                        // Convert.ToBoolean(ModuleDGV["Open", i].Value)
                        cmSQL.Parameters.Clear();
                        cmSQL.CommandText = "InsertUserDetails";
                        cmSQL.CommandType = CommandType.StoredProcedure;
                    cmSQL.Parameters.AddWithValue("@UserID", tUserID.Text);
                        cmSQL.Parameters.AddWithValue("@ModuleID",ModuleDGV[0, i].Value);
                        cmSQL.Parameters.AddWithValue("@AllowOpen", ModuleDGV[1, i].Value);
                        cmSQL.Parameters.AddWithValue("@AllowAdd",ModuleDGV[2, i].Value);
                        cmSQL.Parameters.AddWithValue("@AllowEdit", ModuleDGV[3, i].Value);
                        cmSQL.Parameters.AddWithValue("@AllowBrowse", ModuleDGV[4, i].Value);
                        cmSQL.Parameters.AddWithValue("@AllowDelete", ModuleDGV[5, i].Value);
                        cmSQL.ExecuteNonQuery();
                    }

                    myTrans.Commit();

                    MessageBox.Show("Successfull!", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
                if (Action == AppAction.Delete)
                {
                    if (tUserName.Text.Trim().ToUpper() == "ADMIN")
                    {
                        MessageBox.Show("This User cannot be deleted", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
               
                    if (MessageBox.Show("Do You Want To Delete This Record?", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.No)
                    {
                        return;
                    }
                    cmSQL.Parameters.Clear();
                    cmSQL.CommandText = "DeleteUserAccess";
                    cmSQL.CommandType = CommandType.StoredProcedure;
                    cmSQL.Parameters.AddWithValue("@UserID", ReturnUser);
                    cmSQL.ExecuteNonQuery();
                    MessageBox.Show("Delete Successfull!", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                 
                }
                if (Action == AppAction.Edit)
                {

                    myTrans = cnSQL.BeginTransaction();
                    cmSQL.Transaction = myTrans;

                    cmSQL.Parameters.Clear();
                    cmSQL.CommandText = "DeleteUserAccess";
                    cmSQL.CommandType = CommandType.StoredProcedure;
                    cmSQL.Parameters.AddWithValue("@UserID", ReturnUser);
                    cmSQL.ExecuteNonQuery();

                    cmSQL.Parameters.Clear();
                    cmSQL.CommandText = "InsertUserAccess";
                    cmSQL.CommandType = CommandType.StoredProcedure;
                    cmSQL.Parameters.AddWithValue("@UserID", tUserID.Text);
                    cmSQL.Parameters.AddWithValue("@UserPassword", tPwd.Text);
                    cmSQL.Parameters.AddWithValue("@UserName", tUserName.Text);
                    cmSQL.ExecuteNonQuery();

                    for (i = 0; i < ModuleDGV.RowCount; i++)
                    {
                      cmSQL.Parameters.Clear();
                        cmSQL.CommandText = "InsertUserDetails";
                        cmSQL.CommandType = CommandType.StoredProcedure;
                        cmSQL.Parameters.AddWithValue("@UserID", tUserID.Text);
                        cmSQL.Parameters.AddWithValue("@ModuleID", ModuleDGV[0, i].Value);
                        cmSQL.Parameters.AddWithValue("@AllowOpen", ModuleDGV[1, i].Value);
                        cmSQL.Parameters.AddWithValue("@AllowAdd", ModuleDGV[2, i].Value);
                        cmSQL.Parameters.AddWithValue("@AllowEdit", ModuleDGV[3, i].Value);
                        cmSQL.Parameters.AddWithValue("@AllowBrowse", ModuleDGV[4, i].Value);
                        cmSQL.Parameters.AddWithValue("@AllowDelete", ModuleDGV[5, i].Value);
                        cmSQL.ExecuteNonQuery();
                    }

                    myTrans.Commit();

                    MessageBox.Show("Update Successfull!", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (mnuNew.Enabled == true)
                    mnuNew_Click(sender, e);

            }
                  catch (Exception ex)
            {
                 if (ex.ToString().Contains("Violation of PRIMARY KEY constraint"))
                       MessageBox.Show("User already exist", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                     MessageBox.Show("Ooops! ERROR :" + char.ConvertFromUtf32(13) + ex, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        
       
        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            int i = 0;
            for (i = 0; i < ModuleDGV.RowCount; i++)
            {
                if (ModuleDGV.Rows[i].Cells[1].ReadOnly == false) ModuleDGV.Rows[i].Cells[1].Value = chkSelectAll.Checked;
            if (ModuleDGV.Rows[i].Cells[2].ReadOnly==false)    ModuleDGV.Rows[i].Cells[2].Value = chkSelectAll.Checked;
                if (ModuleDGV.Rows[i].Cells[3].ReadOnly == false)  ModuleDGV.Rows[i].Cells[3].Value = chkSelectAll.Checked;
                if (ModuleDGV.Rows[i].Cells[3].ReadOnly == false)  ModuleDGV.Rows[i].Cells[4].Value = chkSelectAll.Checked;
                if (ModuleDGV.Rows[i].Cells[3].ReadOnly == false) ModuleDGV.Rows[i].Cells[5].Value = chkSelectAll.Checked;


            }

        }

    
        private void mnuNew_Click(object sender, EventArgs e)
        {

            Action = AppAction.Add;
            InitialiseAction();
            NewUser();

        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            Action = AppAction.Edit;
            InitialiseAction();
         using (var form = new FrmList("SystemUser", "List of System Users"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                  LoadModules(form.ReturnValue.ToString());
                }
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            Action = AppAction.Delete;
            InitialiseAction();
            using (var form = new FrmList("SystemUser", "List of System Users"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadModules(form.ReturnValue.ToString());
                }
            }
        }

        private void LoadModules(string dUser)
        {
            try
            {


                NewUser();
                ReturnUser = dUser;
                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand("FetchAllSystemParameters", cnSQL);
                SqlDataReader drSQL = null;

                cmSQL.CommandText = "FetchUserAccess";
                cmSQL.CommandType = CommandType.StoredProcedure;
                cmSQL.Parameters.AddWithValue("@UserID", dUser);
                cnSQL.Open();
                drSQL = cmSQL.ExecuteReader();
                while (drSQL.Read())

                {

                    tUserID.Text = drSQL["UserID"].ToString();
                    tUserName.Text = drSQL["UserName"].ToString();
                    tPwd.Text = drSQL["UserPassword"].ToString();
                    tConfirmPwd.Text = drSQL["UserPassword"].ToString();

                }

                drSQL.Close();

                cmSQL.Parameters.Clear();
                cmSQL.CommandText = "FetchUserAllModuleAccess";
                cmSQL.CommandType = CommandType.StoredProcedure;
                cmSQL.Parameters.AddWithValue("@UserID", dUser);
                drSQL = cmSQL.ExecuteReader();
                while (drSQL.Read())

                {

                    int i;
                    for (i = 0; i < ModuleDGV.RowCount; i++)
                    {
                        if (ModuleDGV[0, i].Value.ToString() == drSQL["ModuleID"].ToString())
                        {
                            ModuleDGV[1, i].Value = drSQL["AllowOpen"];
                            ModuleDGV[2, i].Value = drSQL["AllowAdd"];
                            ModuleDGV[3, i].Value = drSQL["AllowEdit"];
                            ModuleDGV[4, i].Value = drSQL["AllowBrowse"];
                            ModuleDGV[5, i].Value = drSQL["AllowDelete"];
                        }
                        
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ooops! ERROR :" + char.ConvertFromUtf32(13) + ex, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        

private void mnuBrowse_Click(object sender, EventArgs e)
        {
            Action = AppAction.Browse;
            InitialiseAction();
            using (var form = new FrmList("SystemUser", "List of System Users"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadModules(form.ReturnValue.ToString());
                }
            }
        }

        void NewUser()
        {
            int i;
            i = 0;
            ModuleDGV.Rows.Clear();
            ModuleDGV.Rows.Add();
            ModuleDGV[0, i].Value = "School Information";
            ModuleDGV[1, i].Value = 0;
            ModuleDGV[2, i].Value = 0;
            ModuleDGV[3, i].Value = 0;
            ModuleDGV[4, i].Value = 0;
            ModuleDGV[5, i].Value = 0;
            ModuleDGV.Rows.Add();
            i++;
            ModuleDGV[0, i].Value = "Student Information";
            ModuleDGV[1, i].Value = 0;
            ModuleDGV[2, i].Value = 0;
            ModuleDGV[3, i].Value = 0;
            ModuleDGV[4, i].Value = 0;
            ModuleDGV[5, i].Value = 0;
            ModuleDGV.Rows.Add();
            i++;
            ModuleDGV[0, i].Value = "Vendor Information";
            ModuleDGV[1, i].Value = 0;
            ModuleDGV[2, i].Value = 0;
            ModuleDGV[3, i].Value = 0;
            ModuleDGV[4, i].Value = 0;
            ModuleDGV[5, i].Value = 0;
            ModuleDGV.Rows.Add();
            i++;
            ModuleDGV[0, i].Value = "Payments";
            ModuleDGV[1, i].Value = 0;
            ModuleDGV[2, i].Value = 0;
            ModuleDGV[3, i].Value = 0;
            ModuleDGV[4, i].Value = 0;
            ModuleDGV[5, i].Value = 0;
            ModuleDGV.Rows.Add();
            i++;
            ModuleDGV[0, i].Value = "Authorise Mandate";
            ModuleDGV[1, i].Value = 0;
            ModuleDGV[2, i].ReadOnly = true;
            ModuleDGV[3, i].ReadOnly = true;
            ModuleDGV[4, i].ReadOnly = true;
            ModuleDGV[5, i].ReadOnly = true;
            ModuleDGV[2, i].Style.BackColor = Color.AntiqueWhite;
            ModuleDGV[3, i].Style.BackColor = Color.AntiqueWhite;
            ModuleDGV[4, i].Style.BackColor = Color.AntiqueWhite;
            ModuleDGV[5, i].Style.BackColor = Color.AntiqueWhite;
            ModuleDGV.Rows.Add();
            i++; 
            ModuleDGV[0, i].Value = "System Users";
            ModuleDGV[1, i].Value = 0;
            ModuleDGV[2, i].Value = 0;
            ModuleDGV[3, i].Value = 0;
            ModuleDGV[4, i].Value = 0;
            ModuleDGV[5, i].Value = 0;
            ModuleDGV.Rows.Add();
            i++;
            ModuleDGV[0, i].Value = "Company Information";
            ModuleDGV[1, i].Value = 0;
            ModuleDGV[2, i].ReadOnly = true;
            ModuleDGV[3, i].ReadOnly = true;
            ModuleDGV[4, i].ReadOnly = true;
            ModuleDGV[5, i].ReadOnly = true;
            ModuleDGV[2, i].Style.BackColor = Color.AntiqueWhite;
            ModuleDGV[3, i].Style.BackColor = Color.AntiqueWhite;
            ModuleDGV[4, i].Style.BackColor = Color.AntiqueWhite;
            ModuleDGV[5, i].Style.BackColor = Color.AntiqueWhite;
            ModuleDGV.Rows.Add();
            i++;
            ModuleDGV[0, i].Value = "Intervention Line";
            ModuleDGV[1, i].Value = 0;
            ModuleDGV[2, i].ReadOnly = true;
            ModuleDGV[3, i].ReadOnly = true;
            ModuleDGV[4, i].ReadOnly = true;
            ModuleDGV[5, i].ReadOnly = true;
            ModuleDGV[2, i].Style.BackColor = Color.AntiqueWhite;
            ModuleDGV[3, i].Style.BackColor = Color.AntiqueWhite;
            ModuleDGV[4, i].Style.BackColor = Color.AntiqueWhite;
            ModuleDGV[5, i].Style.BackColor = Color.AntiqueWhite;
            ModuleDGV.Rows.Add();
            i++;
            ModuleDGV[0, i].Value = "Ledger";
            ModuleDGV[1, i].Value = 0;
            ModuleDGV[2, i].ReadOnly = true;
            ModuleDGV[3, i].ReadOnly = true;
            ModuleDGV[4, i].ReadOnly = true;
            ModuleDGV[5, i].ReadOnly = true;
            ModuleDGV[2, i].Style.BackColor = Color.AntiqueWhite;
            ModuleDGV[3, i].Style.BackColor = Color.AntiqueWhite;
            ModuleDGV[4, i].Style.BackColor = Color.AntiqueWhite;
            ModuleDGV[5, i].Style.BackColor = Color.AntiqueWhite;



            for (i = 0; i < ModuleDGV.RowCount; i++)
            {

                ModuleDGV[1, i].Value = 0;
                ModuleDGV[2, i].Value = 0;
                ModuleDGV[3, i].Value = 0;
                ModuleDGV[4, i].Value = 0;
                ModuleDGV[5, i].Value = 0;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


   
    }
