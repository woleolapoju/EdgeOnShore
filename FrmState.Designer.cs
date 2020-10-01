namespace Edge
{
    partial class FrmState
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmState));
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CmdClose = new System.Windows.Forms.Button();
            this.lvList = new System.Windows.Forms.ListView();
            this.ColSn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PanCommands = new System.Windows.Forms.Panel();
            this.CmdInsert = new System.Windows.Forms.Button();
            this.CmdCut = new System.Windows.Forms.Button();
            this.CmdOpen = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.tLGA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tState = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.lblCount = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.TableLayoutPanel1.SuspendLayout();
            this.PanCommands.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel1.Controls.Add(this.CmdClose, 0, 2);
            this.TableLayoutPanel1.Controls.Add(this.lvList, 0, 1);
            this.TableLayoutPanel1.Controls.Add(this.PanCommands, 1, 0);
            this.TableLayoutPanel1.Controls.Add(this.Panel1, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.Panel2, 0, 2);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 3;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(410, 593);
            this.TableLayoutPanel1.TabIndex = 6;
            // 
            // CmdClose
            // 
            this.CmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmdClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdClose.Location = new System.Drawing.Point(324, 566);
            this.CmdClose.Margin = new System.Windows.Forms.Padding(1);
            this.CmdClose.Name = "CmdClose";
            this.CmdClose.Size = new System.Drawing.Size(85, 26);
            this.CmdClose.TabIndex = 263;
            this.CmdClose.Text = "CLOSE";
            this.CmdClose.UseVisualStyleBackColor = true;
            // 
            // lvList
            // 
            this.lvList.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lvList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColSn,
            this.ColName,
            this.columnHeader1});
            this.TableLayoutPanel1.SetColumnSpan(this.lvList, 2);
            this.lvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvList.FullRowSelect = true;
            this.lvList.GridLines = true;
            this.lvList.Location = new System.Drawing.Point(3, 75);
            this.lvList.MultiSelect = false;
            this.lvList.Name = "lvList";
            this.lvList.Size = new System.Drawing.Size(404, 487);
            this.lvList.TabIndex = 261;
            this.lvList.UseCompatibleStateImageBehavior = false;
            this.lvList.View = System.Windows.Forms.View.Details;
            // 
            // ColSn
            // 
            this.ColSn.Text = "Sn";
            this.ColSn.Width = 29;
            // 
            // ColName
            // 
            this.ColName.Text = "State";
            this.ColName.Width = 140;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "LGA";
            this.columnHeader1.Width = 242;
            // 
            // PanCommands
            // 
            this.PanCommands.BackColor = System.Drawing.Color.Tan;
            this.PanCommands.Controls.Add(this.CmdInsert);
            this.PanCommands.Controls.Add(this.CmdCut);
            this.PanCommands.Controls.Add(this.CmdOpen);
            this.PanCommands.Location = new System.Drawing.Point(323, 0);
            this.PanCommands.Margin = new System.Windows.Forms.Padding(0);
            this.PanCommands.Name = "PanCommands";
            this.PanCommands.Size = new System.Drawing.Size(86, 70);
            this.PanCommands.TabIndex = 260;
            // 
            // CmdInsert
            // 
            this.CmdInsert.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdInsert.Location = new System.Drawing.Point(6, 3);
            this.CmdInsert.Name = "CmdInsert";
            this.CmdInsert.Size = new System.Drawing.Size(76, 36);
            this.CmdInsert.TabIndex = 11;
            this.CmdInsert.Text = "INSERT";
            this.CmdInsert.UseVisualStyleBackColor = true;
            this.CmdInsert.Click += new System.EventHandler(this.CmdInsert_Click);
            // 
            // CmdCut
            // 
            this.CmdCut.Image = global::Edge.Properties.Resources.CUT;
            this.CmdCut.Location = new System.Drawing.Point(47, 41);
            this.CmdCut.Name = "CmdCut";
            this.CmdCut.Size = new System.Drawing.Size(36, 25);
            this.CmdCut.TabIndex = 10;
            this.CmdCut.UseVisualStyleBackColor = true;
            this.CmdCut.Click += new System.EventHandler(this.CmdCut_Click);
            // 
            // CmdOpen
            // 
            this.CmdOpen.Image = global::Edge.Properties.Resources.OPEN;
            this.CmdOpen.Location = new System.Drawing.Point(6, 41);
            this.CmdOpen.Name = "CmdOpen";
            this.CmdOpen.Size = new System.Drawing.Size(36, 25);
            this.CmdOpen.TabIndex = 9;
            this.CmdOpen.UseVisualStyleBackColor = true;
            this.CmdOpen.Click += new System.EventHandler(this.CmdOpen_Click);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.Panel1.Controls.Add(this.tLGA);
            this.Panel1.Controls.Add(this.label2);
            this.Panel1.Controls.Add(this.tState);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Panel1.Location = new System.Drawing.Point(3, 3);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(317, 66);
            this.Panel1.TabIndex = 2;
            // 
            // tLGA
            // 
            this.tLGA.Location = new System.Drawing.Point(43, 35);
            this.tLGA.Name = "tLGA";
            this.tLGA.Size = new System.Drawing.Size(270, 25);
            this.tLGA.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "LGA:";
            // 
            // tState
            // 
            this.tState.Location = new System.Drawing.Point(43, 7);
            this.tState.Name = "tState";
            this.tState.Size = new System.Drawing.Size(270, 25);
            this.tState.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(1, 11);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(40, 17);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "State:";
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.lblCount);
            this.Panel2.Controls.Add(this.Label3);
            this.Panel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Panel2.Location = new System.Drawing.Point(3, 568);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(98, 22);
            this.Panel2.TabIndex = 262;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(40, 4);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(13, 13);
            this.lblCount.TabIndex = 2;
            this.lblCount.Text = "0";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(0, 5);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(42, 13);
            this.Label3.TabIndex = 1;
            this.Label3.Text = "Count:";
            // 
            // FrmState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 593);
            this.Controls.Add(this.TableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmState";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "State";
            this.Load += new System.EventHandler(this.FrmState_Load);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.PanCommands.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.Button CmdClose;
        internal System.Windows.Forms.ListView lvList;
        internal System.Windows.Forms.ColumnHeader ColSn;
        internal System.Windows.Forms.ColumnHeader ColName;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        internal System.Windows.Forms.Panel PanCommands;
        internal System.Windows.Forms.Button CmdInsert;
        internal System.Windows.Forms.Button CmdCut;
        internal System.Windows.Forms.Button CmdOpen;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.TextBox tLGA;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox tState;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label lblCount;
        internal System.Windows.Forms.Label Label3;
    }
}