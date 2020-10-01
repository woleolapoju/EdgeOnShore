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
using System.Data.OleDb;

namespace Edge
{

    public partial class FrmMainMenu : Form
    {
        public FrmMainMenu()
        {
            InitializeComponent();
        }

        private void mnuAdminTools_Click(object sender, EventArgs e)
        {
            if (MyModules.sysUser == "")
            {
                return;
            }
            panAdminTools.Visible = !panAdminTools.Visible;
            if (panAdminTools.Visible)
            {
                PanAdmin.BackColor = Color.Gainsboro;
                PanAdmin.BackColor = Color.FromArgb(100, 255, 255, 255);
                panAdminTools.BackColor = Color.Transparent;
                lblAdmin.Visible = false;
            }
            else
            {
                PanAdmin.BackColor = Color.Transparent;
                lblAdmin.Visible = true;
            }
            


        }

        private void FrmMainMenu_Load(object sender, EventArgs e)
        {
            try {
                panAdminTools.BackColor = Color.Transparent;
                panUser.BackColor = Color.FromArgb(100, 255, 255, 255);
                panPwd.BackColor = Color.FromArgb(100, 0, 0, 0);
                // mnuAdminTools.BackColor = Color.FromArgb(100, 255, 255, 255);
                //lblAdmin.BackColor = Color.FromArgb(100, 0, 0, 0);

                lblOwner.Text = MyModules.sysOwner;
                

                if (MyModules.UserLogo.Length > 1)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(MyModules.UserLogo);
                    OwnerLogo.Image = new Bitmap(Image.FromStream(ms));
                    ms.Close();
                }

               txtUserID.Text = Edge.Properties.Settings.Default.ApexUser;
                if (txtUserID.Text != "") txtPwd.Focus();
            }
            catch
            {

            }
        }

        private void mnuContractorInfor_Click(object sender, EventArgs e)
        {
            if (MyModules.sysUser == "")
            {
                return;
            }
            panContractorInfor.Visible = !panContractorInfor.Visible;
            if (panContractorInfor.Visible)
            {
                panContractor.BackColor = Color.Gainsboro;
                panContractor.BackColor = Color.FromArgb(100, 255, 255, 255);
                panContractorInfor.BackColor = Color.Transparent;
                lblContractorInfor.Visible = false;
            }
            else
            {
                panContractor.BackColor = Color.Transparent;
                lblContractorInfor.Visible = true;
            }


        }

        private void mnuPayments_Click(object sender, EventArgs e)
        {
            if (MyModules.sysUser == "")
            {
                return;
            }
            panPaymentMnu.Visible = !panPaymentMnu.Visible;
            if (panPaymentMnu.Visible)
            {
                panPayment.BackColor = Color.Gainsboro;
                panPayment.BackColor = Color.FromArgb(100, 255, 255, 255);
                panPaymentMnu.BackColor = Color.Transparent;
                lblPayment.Visible = false;
            }
            else
            {
                panPayment.BackColor = Color.Transparent;
                lblPayment.Visible = true;
            }

        }

        private void mnuReports_Click(object sender, EventArgs e)
        {
            if (MyModules.sysUser == "")
            {
                return;
            }
            panReportMnu.Visible = !panReportMnu.Visible;
            if (panReportMnu.Visible)
            {
                panReport.BackColor = Color.Gainsboro;
                panReport.BackColor = Color.FromArgb(100, 255, 255, 255);
                panReportMnu.BackColor = Color.Transparent;
                lblReport.Visible = false;
            }
            else
            {
                panReport.BackColor = Color.Transparent;
                lblReport.Visible = true;
            }

        }
        private void mnuExit_Click(object sender, EventArgs e)
        {
            //if (MyModules.sysUser == "")
            //{
            //    return;
            //}
            panExitMnu.Visible = !panExitMnu.Visible;
            if (panExitMnu.Visible)
            {
                panExit.BackColor = Color.Gainsboro;
                panExit.BackColor = Color.FromArgb(100, 255, 255, 255);
                panExitMnu.BackColor = Color.Transparent;
                lblExit.Visible = false;
            }
            else
            {
                panExit.BackColor = Color.Transparent;
                lblExit.Visible = true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            GetValidUser();
        }

        private void GetValidUser()
        { 
            try
            {

                if (txtUserID.Text=="" || txtPwd.Text =="")
                {
                    MessageBox.Show("Please enter login details", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int nooflogins = 0;

                    SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);  
                   SqlCommand cmSQL = new SqlCommand("FetchUserAccessByPwd", cnSQL);
                   SqlDataReader drSQL;

                cnSQL.Open();

                cmSQL.CommandText = "FetchUserAccessByPwd";
                cmSQL.CommandType = CommandType.StoredProcedure;
                cmSQL.Parameters.AddWithValue("@UserID", txtUserID.Text);
                cmSQL.Parameters.AddWithValue("@UserPwd", txtPwd.Text);

                drSQL = cmSQL.ExecuteReader();

                if (drSQL.HasRows == false)
                {

                    //    
                    MessageBox.Show("Invalid User Login Information" + char.ConvertFromUtf32(13) + "Access Denied",
                                 MyModules.strApptitle, MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);


                    if (nooflogins == 3)
                        {
                        Environment.Exit(0);
                        //Application.Exit();
                    }

           else
                     {
                        nooflogins += 1;
                      drSQL.Close();
                        return;

                    }
        

                }


                if (drSQL.Read())
                {

                    MyModules.sysUserName = drSQL["UserID"].ToString();

                    MyModules.sysUser = drSQL["UserID"].ToString();

                    MyModules.sysPwd = txtPwd.Text;

                    panUser.Visible = false;
                    panOwner.Visible = true;

                    lblSysUsername.Text = "System User" + char.ConvertFromUtf32(13) + MyModules.sysUserName; 

                }

                drSQL.Close();
                cnSQL.Close();  


             // On Error Resume Next
             //Save UserID to Sysfile
              if (chkSaveUserID.Checked == true)
                {
                    if (txtUserID.Text.Length > 0 )
                    {
                        Edge.Properties.Settings.Default.ApexUser = txtUserID.Text;
                       
                    }   
                 }
                else
                {
                    Edge.Properties.Settings.Default.ApexUser = "";
                }

                Edge.Properties.Settings.Default.Save();


                for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                {
                    if (Application.OpenForms[i].Name != "FrmMainMenu")
                        Application.OpenForms[i].Close();
                }


                //On Error GoTo handler


                //My.Application.DoEvents()

                //FrmMain.oLoadUserImage(sysUser)

                //My.Application.DoEvents()

                //'FrmMain.lblUserName.Text = sysUserName

                //If UCase(sysOwner) <> UCase(strOwnerFromServer) Then
                //    cmSQL.CommandText = "UPDATE SystemParameters SET NName='" & sysOwner & "'"
                //    cmSQL.CommandType = CommandType.Text
                //    cmSQL.ExecuteNonQuery()
                //End If
                //drSQL.Close()
                //'cmSQL.Connection.Close()
                //cmSQL.Dispose()


            }

            catch (Exception ex)
            {
               MessageBox.Show(ex.Message,MyModules.strApptitle, MessageBoxButtons.OK,MessageBoxIcon.Information);
          
            }

        }

        public void radLogOff_Click(object sender, EventArgs e)
        {
            MyModules.sysUser = "";
            panUser.Visible = true;
            txtUserID.Focus();
            panOwner.Visible = false;

            panAdminTools.Visible = false;
            panContractorInfor.Visible = false;
            panPaymentMnu.Visible = false;
            panReportMnu.Visible = false;

            PanAdmin.BackColor = Color.Transparent;
            lblAdmin.Visible = true;
            panContractor.BackColor = Color.Transparent;
            lblContractorInfor.Visible = true;
            panPayment.BackColor = Color.Transparent;
            lblPayment.Visible = true;
            panReport.BackColor = Color.Transparent;
            lblReport.Visible = true;
            txtPwd.Text = "";
        }

        private void radExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
            //Application.Exit();
        }

        private void radContractorListings_Click(object sender, EventArgs e)
        {

        }


        private void mnuServerInformation_Click(object sender, EventArgs e)
        {
            FrmSvrInfor childform = new FrmSvrInfor();
            childform.ShowDialog();
            

        }

        private void txtUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)

            {
                if (txtPwd.Text.Trim() == "" || txtUserID.Text.Trim() == "")
                {
                    MessageBox.Show("Incomplete Login Infor.", MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                GetValidUser();
                return;


               // char.ConvertFromUtf32(13)
            }
        }

        private void radServerInfor_Click(object sender, EventArgs e)
        {
            FrmSvrInfor childform = new FrmSvrInfor();
            childform.ShowDialog();
        }


        private void radChangePwd_Click(object sender, EventArgs e)
        {
            FrmChangePwd childform = new FrmChangePwd();
            childform.ShowDialog();
        }

        private void radCoyInfor_Click(object sender, EventArgs e)
        {
            if (MyModules.GetUserAccessDetails("Company Information") == false)
                return;
            FrmCoyInfor childform = new FrmCoyInfor();
            childform.ShowDialog();
        }

        private void radSystemUsers_Click(object sender, EventArgs e)
        {
            if (MyModules.GetUserAccessDetails("System Users") == false)
                return;
            FrmSystemUsers childform = new FrmSystemUsers();
            childform.ShowDialog();
        }



        private void radReportBuilder_Click(object sender, EventArgs e)
        {
            FrmReportBuilder childform = new FrmReportBuilder();
            childform.ShowDialog();
        }

        private void radSchool_Click(object sender, EventArgs e)
        {
            if (MyModules.GetUserAccessDetails("School Information") == false)
                return;
            FrmSchoolListings childform = new FrmSchoolListings();
            childform.Show();
        }

        private void radStudent_ClickChanged(object sender, EventArgs e)
        {
            if (MyModules.GetUserAccessDetails("Student Information") == false)
                return;
            FrmStudentListings childform = new FrmStudentListings();
            childform.Show();
        }

        private void radVendor_ClickChanged(object sender, EventArgs e)
        {
            if (MyModules.GetUserAccessDetails("Vendor Information") == false)
                return;
            FrmVendorListings childform = new FrmVendorListings("VENDOR");
            childform.Show();
        }

        private void radSystemUsers_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radServerInfor_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radStudent_CheckedChanged(object sender, EventArgs e)
        {

        }

  
        private void radMandate_Click(object sender, EventArgs e)
        {
            if (MyModules.GetUserAccessDetails("Payments") == false)
                return;
            FrmMandate childform = new FrmMandate();
            childform.ShowDialog();
        }

        private void radVendor_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadPayment_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadLedger_Click(object sender, EventArgs e)
        {
            if (MyModules.GetUserAccessDetails("Ledger") == false)
                return;
            FrmLedger childform = new FrmLedger();
            childform.Show();
        }

        private void RadLedger_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panContractor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblAdmin_Click(object sender, EventArgs e)
        {

        }

        private void panContractorInfor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radImport_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radImport_Click(object sender, EventArgs e)
        {
            if (MyModules.GetUserAccessDetails("System Users") == false)
                return;

            FrmImportData childform = new FrmImportData();
            childform.ShowDialog();
        }

        private void radStaff_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radStaff_Click(object sender, EventArgs e)
        {
            if (MyModules.GetUserAccessDetails("Vendor Information") == false)
                return;
            FrmVendorListings childform = new FrmVendorListings("STAFF");
            childform.Show();

        }

        private void radSchool_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radReport_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadDeductions_Click(object sender, EventArgs e)
        {
            if (MyModules.GetUserAccessDetails("Payments") == false)
                return;
            FrmDeductionType childform = new FrmDeductionType();
            childform.ShowDialog();
        }

        private void RadDeductions_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radReport_Click(object sender, EventArgs e)
        {
            FrmReports childform = new FrmReports();
            childform.ShowDialog();
        }
    }


}
