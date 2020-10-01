namespace FrmImportTable
{
    partial class FrmImportTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImportTables));
            this.lstViewTables = new System.Windows.Forms.ListView();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstViewTables
            // 
            this.lstViewTables.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lstViewTables.Location = new System.Drawing.Point(2, 0);
            this.lstViewTables.Name = "lstViewTables";
            this.lstViewTables.Size = new System.Drawing.Size(228, 306);
            this.lstViewTables.TabIndex = 0;
            this.lstViewTables.UseCompatibleStateImageBehavior = false;
            this.lstViewTables.View = System.Windows.Forms.View.List;
            this.lstViewTables.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstViewTables_ItemSelectionChanged);
            this.lstViewTables.SelectedIndexChanged += new System.EventHandler(this.lstViewTables_SelectedIndexChanged);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(162, 309);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(68, 33);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmSelectTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(232, 345);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lstViewTables);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
             this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectTables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Tables";
            this.Load += new System.EventHandler(this.Select_Tables_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstViewTables;
        private System.Windows.Forms.Button btnOk;
    }
}