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
    public partial class FrmCoyInfor : Form
    {
        public FrmCoyInfor()
        {
            InitializeComponent();
        }

        private void FrmCoyInfor_Load(object sender, EventArgs e)
        {
            try
            {
               
                this.Text = "Edit Organisation's Information";
                byte[] arrayLogo = null;
                tName.Text =MyModules.sysOwner;

                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand("FetchAllSystemParameters", cnSQL);
               SqlDataReader drSQL;

                cnSQL.Open();

                cmSQL.CommandText = "FetchAllSystemParameters";
                cmSQL.CommandType = CommandType.StoredProcedure;
                drSQL = cmSQL.ExecuteReader();
                if (drSQL.HasRows == false)
                {
                    MessageBox.Show("Invalid System parameter",MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Environment.Exit(1);
                }
                else
                {
                    if (drSQL.Read())
                    {
                        tAddress.Text = drSQL["Address"].ToString();
                        tPhone.Text = drSQL["Phone"].ToString();
                        temail.Text = drSQL["Email"].ToString();
                        tWebsite.Text = drSQL["wwweb"].ToString();
                        tDocFile.Text = drSQL["eDocPath"].ToString();
                        tBackupPath.Text = drSQL["BackupPath"].ToString();
                      
                        if (Convert.IsDBNull(drSQL["Logo"]) == false)
                        {
                            arrayLogo = (byte[])drSQL["Logo"];
                            if (arrayLogo.Length > 1)
                            {
                                System.IO.MemoryStream ms = new System.IO.MemoryStream(arrayLogo);
                                OwnerLogo.Image = new Bitmap(Image.FromStream(ms));
                                ms.Close();
                            }
                        }

                        
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
                     MessageBox.Show("Ooops! ERROR :" + char.ConvertFromUtf32(13) + ex, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           }

        private void CmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection cnSQL = new SqlConnection(MyModules.strConnect);
                SqlCommand cmSQL = new SqlCommand("FetchUserAccessByPwd", cnSQL);
                // SqlDataReader drSQL;

                cnSQL.Open();


                byte[] arrayLogo = { 0 };
                //byte[] arrayLogo = null;

                if ((OwnerLogo.Image == null) == false)
                {

                    using (MemoryStream m = new MemoryStream())
                    {
                        OwnerLogo.Image.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg);
                        //image.Save(m, image.RawFormat);

                        arrayLogo = m.ToArray();
                    }
                    
                }

                cmSQL.CommandText = "UpdateSysParam4CoySetup";
                cmSQL.CommandType = CommandType.StoredProcedure;
                cmSQL.Parameters.AddWithValue("@NName", tName.Text);
                cmSQL.Parameters.AddWithValue("@Address", tAddress.Text);
                cmSQL.Parameters.AddWithValue("@Phone", tPhone.Text);
                cmSQL.Parameters.AddWithValue("@Email", temail.Text);
                cmSQL.Parameters.AddWithValue("@wwweb", tWebsite.Text);
                cmSQL.Parameters.AddWithValue("@logo", arrayLogo);
                cmSQL.Parameters.AddWithValue("@eDocPath", tDocFile.Text);
                cmSQL.Parameters.AddWithValue("@BackupPath", tBackupPath.Text);

              
                cmSQL.ExecuteNonQuery();
                //cmSQL.Connection.Close()
                cmSQL.Dispose();
                // cnSQL.Close()
                //cnSQL.Dispose()

                MyModules.InitialiseEntireSystem();

                MessageBox.Show("Pls. restart...",MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                System.Environment.Exit(1);

                return;
                
        }
            catch (Exception ex)
            {
                     MessageBox.Show("Ooops! ERROR :" + char.ConvertFromUtf32(13) + ex, MyModules.strApptitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          }

        private void OwnerLogo_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.InitialDirectory =MyModules.AppPath;
            OpenFileDialog.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg";
            OpenFileDialog.FilterIndex = 2;
            if (OpenFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                string FileName = OpenFileDialog.FileName;
                if (FileName.Length == 0)
                {
                    OwnerLogo.Image = null;
                }
                else
                {
                    OwnerLogo.Image = Image.FromFile(FileName);
                }
            }
        }
      
        private void cmdGetFile_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tBackupPath.Text = FolderBrowserDialog1.SelectedPath;
            }
        }

        private void cmdGetBakPath_Click_1(object sender, EventArgs e)
        {
            if (FolderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tBackupPath.Text = FolderBrowserDialog1.SelectedPath;
            }
        }

        private void OwnerLogo_Click(object sender, EventArgs e)
        {

        }
    }
}

