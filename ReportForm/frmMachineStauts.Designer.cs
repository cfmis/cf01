namespace cf01.ReportForm
{
    partial class frmMachineStatus
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMachineStatus));
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lvMachineStatus = new System.Windows.Forms.ListView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.BTNFIND = new System.Windows.Forms.ToolStripButton();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.lbldept = new System.Windows.Forms.Label();
            this.cmbWorktype = new System.Windows.Forms.ComboBox();
            this.lblWorktype = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.ForeColor = System.Drawing.Color.Teal;
            this.btnPrevious.Location = new System.Drawing.Point(743, 716);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 2;
            this.btnPrevious.Text = "上一頁";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.ForeColor = System.Drawing.Color.Teal;
            this.btnNext.Location = new System.Drawing.Point(857, 716);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "下一頁";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lvMachineStatus
            // 
            this.lvMachineStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lvMachineStatus.Location = new System.Drawing.Point(660, 720);
            this.lvMachineStatus.Name = "lvMachineStatus";
            this.lvMachineStatus.Size = new System.Drawing.Size(59, 19);
            this.lvMachineStatus.TabIndex = 4;
            this.lvMachineStatus.UseCompatibleStateImageBehavior = false;
            this.lvMachineStatus.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNEXIT,
            this.BTNFIND});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(966, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BTNEXIT
            // 
            this.BTNEXIT.Image = ((System.Drawing.Image)(resources.GetObject("BTNEXIT.Image")));
            this.BTNEXIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEXIT.Name = "BTNEXIT";
            this.BTNEXIT.Size = new System.Drawing.Size(52, 22);
            this.BTNEXIT.Text = "退出";
            this.BTNEXIT.Click += new System.EventHandler(this.BTNEXIT_Click);
            // 
            // BTNFIND
            // 
            this.BTNFIND.Image = ((System.Drawing.Image)(resources.GetObject("BTNFIND.Image")));
            this.BTNFIND.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNFIND.Name = "BTNFIND";
            this.BTNFIND.Size = new System.Drawing.Size(52, 22);
            this.BTNFIND.Text = "查詢";
            this.BTNFIND.Click += new System.EventHandler(this.BTNFIND_Click);
            // 
            // cmbDept
            // 
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.Location = new System.Drawing.Point(47, 28);
            this.cmbDept.Name = "cmbDept";
            this.cmbDept.Size = new System.Drawing.Size(121, 20);
            this.cmbDept.TabIndex = 6;
            // 
            // lbldept
            // 
            this.lbldept.AutoSize = true;
            this.lbldept.Location = new System.Drawing.Point(12, 36);
            this.lbldept.Name = "lbldept";
            this.lbldept.Size = new System.Drawing.Size(29, 12);
            this.lbldept.TabIndex = 7;
            this.lbldept.Text = "部門";
            // 
            // cmbWorktype
            // 
            this.cmbWorktype.FormattingEnabled = true;
            this.cmbWorktype.Location = new System.Drawing.Point(268, 28);
            this.cmbWorktype.Name = "cmbWorktype";
            this.cmbWorktype.Size = new System.Drawing.Size(121, 20);
            this.cmbWorktype.TabIndex = 6;
            // 
            // lblWorktype
            // 
            this.lblWorktype.AutoSize = true;
            this.lblWorktype.Location = new System.Drawing.Point(209, 36);
            this.lblWorktype.Name = "lblWorktype";
            this.lblWorktype.Size = new System.Drawing.Size(53, 12);
            this.lblWorktype.TabIndex = 7;
            this.lblWorktype.Text = "工作狀態";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(0, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(966, 659);
            this.panel1.TabIndex = 8;
            // 
            // frmMachineStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 748);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblWorktype);
            this.Controls.Add(this.lbldept);
            this.Controls.Add(this.cmbWorktype);
            this.Controls.Add(this.cmbDept);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lvMachineStatus);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Name = "frmMachineStatus";
            this.Text = "frmMachineStauts";
            this.Load += new System.EventHandler(this.frmMachineStatus_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ListView lvMachineStatus;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripButton BTNFIND;
        private System.Windows.Forms.ComboBox cmbDept;
        private System.Windows.Forms.Label lbldept;
        private System.Windows.Forms.ComboBox cmbWorktype;
        private System.Windows.Forms.Label lblWorktype;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
    }
}