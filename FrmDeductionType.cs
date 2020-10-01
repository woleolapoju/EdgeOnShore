using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Edge
{
    public partial class FrmDeductionType : Form
    {
        public FrmDeductionType()
        {
            InitializeComponent();
        }

        private void btnWHT_Click(object sender, EventArgs e)
        {
            if (MyModules.GetUserAccessDetails("Payments") == false)
                return;
            FrmPayDeduction childform = new FrmPayDeduction("WHT","",0);
            childform.ShowDialog();

           
        }

        private void btnVAT_Click(object sender, EventArgs e)
        {
            if (MyModules.GetUserAccessDetails("Payments") == false)
                return;
            FrmPayDeduction childform = new FrmPayDeduction("VAT","",0);
            childform.ShowDialog();
        }

        private void btnStamp_Click(object sender, EventArgs e)
        {
            if (MyModules.GetUserAccessDetails("Payments") == false)
                return;
            FrmPayDeduction childform = new FrmPayDeduction("Stamp","",0);
            childform.ShowDialog();
        }
    }
}
