﻿using System;
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
    public partial class FrmStudentInfor : Form
    {
        int ReturnCode1;
        string Action1;
        AppAction Action;
        public FrmStudentInfor(string Action, int ReturnCode = 0)
        {
            InitializeComponent();
            ReturnCode1 = ReturnCode;
            Action1 = Action;
        }

        private void FrmStudentInfor_Load(object sender, EventArgs e)
        {
            mnuNew.Enabled = MyModules.ModuleAdd;
            mnuEdit.Enabled = MyModules.ModuleEdit;
            mnuBrowse.Enabled = MyModules.ModuleBrowse;
            mnuDelete.Enabled = MyModules.ModuleDelete;
            LoadStates();
            LoadBanks();
            LoadCourses();
            LoadDegree();
            LoadCategory();
            numEnd.Value = 2010;
            numStart.Value = 2010;
            if (Action1 != "" && ReturnCode1 != 0)
            {
                if (Action1 == "Edit")
                {
                    Action = AppAction.Edit;
                    InitialiseAction();
                }
                if (Action1 == "Delete")
                {
                    Action = AppAction.Delete;
                    InitialiseAction();
                }
                if (Action1 == "Browse")
                {
                    Action = AppAction.Browse;
                    InitialiseAction();
                }
                oLoad(ReturnCode1);
            }
            else
            {
                if (mnuNew.Enabled == true)
                    mnuNew_Click(sender, e);
            }
        }

        private void InitialiseAction()
        {
            cmdOk.Visible = true;
            flush();
            if (Action == AppAction.Add)
            {
                lblAction.Text = "New Record";
            }

            if (Action == AppAction.Delete)
            {
                lblAction.Text = "Delete Record";
            }
            if (Action == AppAction.Edit)
            {
                lblAction.Text = "Edit Record";
            }
            if (Action == AppAction.Browse)
            {
                lblAction.Text = "Browse Record";
                cmdOk.Visible = false;
            }
        }

        private void flush()
        {
            tRefNo.Text = "";
            tStudentName.Text = "";
            tAddress.Text = "";
            tPhone.Text = "";
            tEmailAddress.Text = "";
            cState.Text = "";
            cBank.Text = "";
            tBankCode.Text = "";
            tAccountNo.Text = "";
            tBankAddress.Text = "";
            tRemark.Text = "";
            chkActive.Checked = false;
            tSchoolID.Text = "";
            tSchName.Text = "";
            cCourse.Text = "";
            cDegree.Text = "";
            txtIDNo.Text = "";
        }

        private void oLoad(int ReturnStr)

        {
            try
            {

                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;
                SqlDataReader drSQL;

                cnSQL.Open();

                cmSQL.CommandText = "FetchRegisterStudent";
                cmSQL.Parameters.AddWithValue("@Sn", ReturnStr);
                cmSQL.CommandType = CommandType.StoredProcedure;
                drSQL = cmSQL.ExecuteReader();
                if (drSQL.HasRows == false)
                {
                    MessageBox.Show("Record not found", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Environment.Exit(1);
                }
                else
                {
                    if (drSQL.Read())
                    {
                        tRefNo.Text = drSQL["Sn"].ToString();
                        tStudentName.Text = drSQL["Name"].ToString();
                        tAddress.Text = drSQL["Address"].ToString();
                        tPhone.Text = drSQL["Telephone"].ToString();
                        tEmailAddress.Text = drSQL["EmailAddress"].ToString();
                        cState.Text = drSQL["State"].ToString();
                        tBank.Text = drSQL["BankName"].ToString();
                        tBankCode.Text = drSQL["BankCode"].ToString();
                        tAccountNo.Text = drSQL["BankAcctNo"].ToString();
                        tBankAddress.Text = drSQL["BankAddress"].ToString();
                        tRemark.Text = drSQL["Remark"].ToString();
                        chkActive.Checked = Convert.ToBoolean(drSQL["InActive"]);
                        tSchoolID.Text = drSQL["SchoolID"].ToString();
                        tSchName.Text = drSQL["SchName"].ToString();
                        cCourse.Text = drSQL["CourseOfStudy"].ToString();
                        cDegree.Text = drSQL["Degree"].ToString();
                        numStart.Text = drSQL["StartYear"].ToString();
                        numEnd.Text = drSQL["EndYear"].ToString();
                        txtIDNo.Text = drSQL["IDNo"].ToString();
                        cboCategory.Text = drSQL["Category"].ToString();
                        cboRegion.Text = drSQL["Region"].ToString();
                    }
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

        private void mnuNew_Click(object sender, EventArgs e)
        {
            Action = AppAction.Add;
            InitialiseAction();
            flush();
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            String value = "";
            if (MyModules.InputBox("Student Information", "Enter RefNo:", ref value, false) == DialogResult.OK)
            {
                if (value == "") return;
                if (Convert.ToInt16(value) != 0)
                {
                    Action = AppAction.Edit;
                    InitialiseAction();
                    oLoad(Convert.ToInt16(value));
                }
            }

        }

        private void mnuBrowse_Click(object sender, EventArgs e)
        {
            String value = "";
            if (MyModules.InputBox("Student Information", "Enter RefNo:", ref value, false) == DialogResult.OK)
            {
                if (value == "") return;
                if (Convert.ToInt16(value) != 0)
                {
                    Action = AppAction.Browse;
                    InitialiseAction();
                    oLoad(Convert.ToInt16(value));
                }
            }
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            String value = "";
            if (MyModules.InputBox("Student Information", "Enter RefNo:", ref value, false) == DialogResult.OK)
            {
                if (value == "") return;
                if (Convert.ToInt16(value) != 0)
                {
                    Action = AppAction.Delete;
                    InitialiseAction();
                    oLoad(Convert.ToInt16(value));
                }
            }
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            try
            {
                SqlTransaction myTrans = null;


                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;
                cnSQL.Open();

                if (Action != AppAction.Delete)
                {
                    if (string.IsNullOrEmpty(tStudentName.Text.Trim(' ')) || string.IsNullOrEmpty(tBank.Text.Trim(' ')) || string.IsNullOrEmpty(tAccountNo.Text.Trim(' ')))
                    {
                        MessageBox.Show("Incomplete data", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                if (Action == AppAction.Add)
                {

                    myTrans = cnSQL.BeginTransaction();
                    cmSQL.Transaction = myTrans;

                    cmSQL.Parameters.Clear();
                    cmSQL.CommandText = "InsertRegisterStudent";
                    cmSQL.CommandType = CommandType.StoredProcedure;
                    cmSQL.Parameters.AddWithValue("@Sn", 0);
                    cmSQL.Parameters.AddWithValue("@Name", tStudentName.Text);
                    cmSQL.Parameters.AddWithValue("@Address", tAddress.Text);
                    cmSQL.Parameters.AddWithValue("@State", cState.Text);
                    cmSQL.Parameters.AddWithValue("@EmailAddress", tEmailAddress.Text);
                    cmSQL.Parameters.AddWithValue("@Telephone", tPhone.Text);
                    cmSQL.Parameters.AddWithValue("@BankName", tBank.Text);
                    cmSQL.Parameters.AddWithValue("@BankAcctNo", tAccountNo.Text);
                    cmSQL.Parameters.AddWithValue("@BankCode", tBankCode.Text);
                    cmSQL.Parameters.AddWithValue("@BankAddress", tBankAddress.Text);
                    cmSQL.Parameters.AddWithValue("@Remark", tRemark.Text);
                    cmSQL.Parameters.AddWithValue("@InActive", chkActive.Checked);
                    cmSQL.Parameters.AddWithValue("@SchoolID", tSchoolID.Text);
                    cmSQL.Parameters.AddWithValue("@Degree", cDegree.Text);
                    cmSQL.Parameters.AddWithValue("@CourseOfStudy", cCourse.Text);
                    cmSQL.Parameters.AddWithValue("@StartYear", numStart.Value);
                    cmSQL.Parameters.AddWithValue("@EndYear", numEnd.Value);
                    cmSQL.Parameters.AddWithValue("@LGA", cLGA.Text);
                    cmSQL.Parameters.AddWithValue("@SchName", tSchName.Text);
                    cmSQL.Parameters.AddWithValue("@IDNo", txtIDNo.Text);
                    cmSQL.Parameters.AddWithValue("@Category", cboCategory.Text);
                    cmSQL.Parameters.AddWithValue("@Region", cboRegion.Text);
                    cmSQL.ExecuteNonQuery();


                    myTrans.Commit();

                   // MessageBox.Show("Successfull!", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                if (Action == AppAction.Delete)
                {


                    if (MessageBox.Show("Do You Want To Delete This Record?", MyModules.strApptitle, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    {
                        return;
                    }
                    cmSQL.Parameters.Clear();
                    cmSQL.CommandText = "Delete FROM RegisterStudent WHERE Sn=" + ReturnCode1;
                    cmSQL.CommandType = CommandType.Text;
                    cmSQL.ExecuteNonQuery();
                    MessageBox.Show("Delete Successfull!", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (Action1 != "") this.Close();
                }
                if (Action == AppAction.Edit)
                {

                    myTrans = cnSQL.BeginTransaction();
                    cmSQL.Transaction = myTrans;

                    cmSQL.Parameters.Clear();
                    cmSQL.CommandText = "Delete FROM RegisterStudent WHERE Sn=" + ReturnCode1;
                    cmSQL.CommandType = CommandType.Text;
                    cmSQL.ExecuteNonQuery();

                    cmSQL.Parameters.Clear();
                    cmSQL.CommandText = "InsertRegisterStudent";
                    cmSQL.CommandType = CommandType.StoredProcedure;
                    cmSQL.Parameters.AddWithValue("@Sn", ReturnCode1);
                    cmSQL.Parameters.AddWithValue("@Name", tStudentName.Text);
                    cmSQL.Parameters.AddWithValue("@Address", tAddress.Text);
                    cmSQL.Parameters.AddWithValue("@State", cState.Text);
                    cmSQL.Parameters.AddWithValue("@EmailAddress", tEmailAddress.Text);
                    cmSQL.Parameters.AddWithValue("@Telephone", tPhone.Text);
                    cmSQL.Parameters.AddWithValue("@BankName", tBank.Text);
                    cmSQL.Parameters.AddWithValue("@BankAcctNo", tAccountNo.Text);
                    cmSQL.Parameters.AddWithValue("@BankCode", tBankCode.Text);
                    cmSQL.Parameters.AddWithValue("@BankAddress", tBankAddress.Text);
                    cmSQL.Parameters.AddWithValue("@Remark", tRemark.Text);
                    cmSQL.Parameters.AddWithValue("@InActive", chkActive.Checked);
                    cmSQL.Parameters.AddWithValue("@SchoolID", tSchoolID.Text);
                    cmSQL.Parameters.AddWithValue("@Degree", cDegree.Text);
                    cmSQL.Parameters.AddWithValue("@CourseOfStudy", cCourse.Text);
                    cmSQL.Parameters.AddWithValue("@StartYear", numStart.Value);
                    cmSQL.Parameters.AddWithValue("@EndYear", numEnd.Value);
                    cmSQL.Parameters.AddWithValue("@LGA", cLGA.Text);
                    cmSQL.Parameters.AddWithValue("@SchName", tSchName.Text);
                    cmSQL.Parameters.AddWithValue("@IDNo", txtIDNo.Text);
                    cmSQL.Parameters.AddWithValue("@Category", cboCategory.Text);
                    cmSQL.Parameters.AddWithValue("@Region", cboRegion.Text);
                    cmSQL.ExecuteNonQuery();


                    myTrans.Commit();

                    MessageBox.Show("Update Successfull!", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (Action1 != "") this.Close();
                }

                if (mnuNew.Enabled == true)
                    mnuNew_Click(sender, e);

            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("Violation of PRIMARY KEY constraint"))
                    MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }


        private void LoadStates()

        {
            try
            {

                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;
                SqlDataReader drSQL;

                cnSQL.Open();

                cmSQL.CommandText = "SELECT DISTINCT [State] FROM [States]";
                cmSQL.CommandType = CommandType.Text;
                drSQL = cmSQL.ExecuteReader();

                while (drSQL.Read())
                {
                    cState.Items.Add(drSQL["State"].ToString());
                }


                //cmSQL.Connection.Close()
                cmSQL.Dispose();
                drSQL.Close();
                cnSQL.Close();
                //cnSQL.Dispose()

                cState.SelectedIndex = 0;

                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadLGA(string dState)

        {
            try
            {

                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;
                SqlDataReader drSQL;

                cnSQL.Open();

                cmSQL.CommandText = "SELECT DISTINCT [LGA] FROM [States] WHERE [State]='" + dState + "'";
                cmSQL.CommandType = CommandType.Text;
                drSQL = cmSQL.ExecuteReader();

                cLGA.Items.Clear();
                while (drSQL.Read())
                {
                    cLGA.Items.Add(drSQL["LGA"].ToString());
                }


                //cmSQL.Connection.Close()
                cmSQL.Dispose();
                drSQL.Close();
                cnSQL.Close();
                //cnSQL.Dispose()

                cLGA.SelectedIndex = 0;

                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void LoadBanks()

        {
            try
            {

                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;
                SqlDataReader drSQL;

                cnSQL.Open();

                cmSQL.CommandText = "SELECT DISTINCT [Bank],[Code] FROM [Bank]";
                cmSQL.CommandType = CommandType.Text;
                drSQL = cmSQL.ExecuteReader();

                while (drSQL.Read())
                {
                    cBank.Items.Add(drSQL["Bank"].ToString() + " - " + drSQL["Code"].ToString());
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

        private void LoadCourses()

        {
            try
            {

                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;
                SqlDataReader drSQL;
                cCourse.Items.Clear();
                cnSQL.Open();

                cmSQL.CommandText = "SELECT DISTINCT CourseOfStudy FROM [RegisterStudent]";
                cmSQL.CommandType = CommandType.Text;
                drSQL = cmSQL.ExecuteReader();

                while (drSQL.Read())
                {
                    cCourse.Items.Add(drSQL["CourseOfStudy"].ToString() );
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
        private void LoadDegree()

        {
            try
            {

                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;
                SqlDataReader drSQL;
                cDegree.Items.Clear();
                cnSQL.Open();

                cmSQL.CommandText = "SELECT DISTINCT Degree FROM [RegisterStudent]";
                cmSQL.CommandType = CommandType.Text;
                drSQL = cmSQL.ExecuteReader();

                while (drSQL.Read())
                {
                    cDegree.Items.Add(drSQL["Degree"].ToString());
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


        private void cBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            tBank.Text = MyModules.GetIt4Me(cBank.Text, " - ");
            tBankCode.Text = MyModules.Mid(cBank.Text, Microsoft.VisualBasic.Strings.Len(tBank.Text) + 3, -1);
        }

        private void lnkBank_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (mnuEdit.Enabled == true && mnuDelete.Enabled == true)
            {
                FrmBank childform = new FrmBank();
                childform.ShowDialog();
            }
            else
                MessageBox.Show("Access Denied", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lnkState_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            {
                if (mnuEdit.Enabled == true && mnuDelete.Enabled == true)
                {
                    FrmState childform = new FrmState();
                    childform.ShowDialog();
                }
                else
                    MessageBox.Show("Access Denied", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lnkSchool_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MyModules.GetUserAccessDetails("School Information") == false)
                return;
            FrmSchoolInfor ChildForm = new FrmSchoolInfor("New", 0);
            ChildForm.ShowDialog();
        }

        private void cmdSchool_Click(object sender, EventArgs e)
        {
            using (var form = new FrmList("ActiveSchoolList", "List of All Active School"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tSchoolID.Text=form.ReturnValue.ToString();
                    tSchName.Text = form.ReturnValue1.ToString();

                }
            }
        }

        private void cState_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLGA(cState.Text.ToString());
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadCategory()

        {
            try
            {

                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand();
                cmSQL.Connection = cnSQL;
                SqlDataReader drSQL;

                cnSQL.Open();

                cmSQL.CommandText = "SELECT DISTINCT [Category] FROM RegisterStudent";
                cmSQL.CommandType = CommandType.Text;
                drSQL = cmSQL.ExecuteReader();

                while (drSQL.Read())
                {
                    cboCategory.Items.Add(drSQL["Category"].ToString());
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
    }
}