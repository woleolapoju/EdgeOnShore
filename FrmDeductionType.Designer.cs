namespace Edge
{
    partial class FrmDeductionType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDeductionType));
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnWHT = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnVAT = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnStamp = new System.Windows.Forms.Button();
            this.lblAction = new System.Windows.Forms.Label();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.panel6, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel8, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel5, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblAction, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(315, 100);
            this.tableLayoutPanel3.TabIndex = 580;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnWHT);
            this.panel6.Location = new System.Drawing.Point(3, 38);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(99, 57);
            this.panel6.TabIndex = 592;
            // 
            // btnWHT
            // 
            this.btnWHT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWHT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnWHT.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWHT.Location = new System.Drawing.Point(0, 0);
            this.btnWHT.Name = "btnWHT";
            this.btnWHT.Size = new System.Drawing.Size(99, 57);
            this.btnWHT.TabIndex = 576;
            this.btnWHT.Text = "WHT";
            this.btnWHT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWHT.UseVisualStyleBackColor = true;
            this.btnWHT.Click += new System.EventHandler(this.btnWHT_Click);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnVAT);
            this.panel8.Location = new System.Drawing.Point(108, 38);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(99, 57);
            this.panel8.TabIndex = 594;
            // 
            // btnVAT
            // 
            this.btnVAT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVAT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVAT.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnVAT.Location = new System.Drawing.Point(0, 0);
            this.btnVAT.Name = "btnVAT";
            this.btnVAT.Size = new System.Drawing.Size(99, 57);
            this.btnVAT.TabIndex = 576;
            this.btnVAT.Text = "VAT";
            this.btnVAT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVAT.UseVisualStyleBackColor = true;
            this.btnVAT.Click += new System.EventHandler(this.btnVAT_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnStamp);
            this.panel5.Location = new System.Drawing.Point(213, 38);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(99, 57);
            this.panel5.TabIndex = 593;
            // 
            // btnStamp
            // 
            this.btnStamp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStamp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStamp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStamp.Location = new System.Drawing.Point(0, 0);
            this.btnStamp.Name = "btnStamp";
            this.btnStamp.Size = new System.Drawing.Size(99, 57);
            this.btnStamp.TabIndex = 576;
            this.btnStamp.Text = "Stamp";
            this.btnStamp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStamp.UseVisualStyleBackColor = true;
            this.btnStamp.Click += new System.EventHandler(this.btnStamp_Click);
            // 
            // lblAction
            // 
            this.lblAction.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tableLayoutPanel3.SetColumnSpan(this.lblAction, 3);
            this.lblAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAction.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAction.ForeColor = System.Drawing.Color.Red;
            this.lblAction.Location = new System.Drawing.Point(3, 0);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(309, 35);
            this.lblAction.TabIndex = 588;
            this.lblAction.Tag = "WHT";
            this.lblAction.Text = "Transaction Type";
            this.lblAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmDeductionType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 100);
            this.Controls.Add(this.tableLayoutPanel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDeductionType";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deduction Type";
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel6;
        internal System.Windows.Forms.Button btnWHT;
        private System.Windows.Forms.Panel panel8;
        internal System.Windows.Forms.Button btnVAT;
        private System.Windows.Forms.Panel panel5;
        internal System.Windows.Forms.Button btnStamp;
        internal System.Windows.Forms.Label lblAction;
    }
}