namespace Edge
{
    partial class FrmMandateRpt
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
            this.cmdCancel = new System.Windows.Forms.Button();
            this.tMandateNo = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.tSignatory2 = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.tSignatory1 = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.cmdOk = new System.Windows.Forms.Button();
            this.tAmount = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(239, 118);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(109, 28);
            this.cmdCancel.TabIndex = 153;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // tMandateNo
            // 
            this.tMandateNo.BackColor = System.Drawing.Color.White;
            this.tMandateNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tMandateNo.Location = new System.Drawing.Point(100, 10);
            this.tMandateNo.Name = "tMandateNo";
            this.tMandateNo.Size = new System.Drawing.Size(249, 23);
            this.tMandateNo.TabIndex = 148;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(9, 16);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(49, 15);
            this.Label7.TabIndex = 147;
            this.Label7.Text = "Ref. No:";
            // 
            // tSignatory2
            // 
            this.tSignatory2.BackColor = System.Drawing.Color.White;
            this.tSignatory2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSignatory2.Location = new System.Drawing.Point(100, 87);
            this.tSignatory2.Name = "tSignatory2";
            this.tSignatory2.Size = new System.Drawing.Size(249, 23);
            this.tSignatory2.TabIndex = 144;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(8, 90);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(83, 15);
            this.Label5.TabIndex = 143;
            this.Label5.Text = "2nd Signatory:";
            // 
            // tSignatory1
            // 
            this.tSignatory1.BackColor = System.Drawing.Color.White;
            this.tSignatory1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSignatory1.Location = new System.Drawing.Point(100, 62);
            this.tSignatory1.Name = "tSignatory1";
            this.tSignatory1.Size = new System.Drawing.Size(249, 23);
            this.tSignatory1.TabIndex = 142;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(7, 65);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(78, 15);
            this.Label4.TabIndex = 141;
            this.Label4.Text = "1st Signatory:";
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(99, 119);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(109, 28);
            this.cmdOk.TabIndex = 139;
            this.cmdOk.Text = "OK";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // tAmount
            // 
            this.tAmount.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tAmount.Location = new System.Drawing.Point(100, 37);
            this.tAmount.Name = "tAmount";
            this.tAmount.ReadOnly = true;
            this.tAmount.Size = new System.Drawing.Size(147, 23);
            this.tAmount.TabIndex = 136;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(8, 41);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(86, 15);
            this.Label2.TabIndex = 135;
            this.Label2.Text = "Mandate Total:";
            // 
            // FrmMandateRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(360, 153);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.tMandateNo);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.tSignatory2);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.tSignatory1);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.tAmount);
            this.Controls.Add(this.Label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmMandateRpt";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mandate Report";
            this.Load += new System.EventHandler(this.FrmMandateRpt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.TextBox tMandateNo;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox tSignatory2;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox tSignatory1;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Button cmdOk;
        internal System.Windows.Forms.TextBox tAmount;
        internal System.Windows.Forms.Label Label2;
    }
}