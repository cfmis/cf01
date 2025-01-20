namespace cf01.Forms
{
    partial class frmOcAdditionalInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOcAdditionalInfo));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblOc = new System.Windows.Forms.Label();
            this.txtOc = new System.Windows.Forms.TextBox();
            this.lblMo = new System.Windows.Forms.Label();
            this.txtMo = new System.Windows.Forms.TextBox();
            this.txtAddInfo = new System.Windows.Forms.RichTextBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.btnGetDetault = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.toolStripSeparator1,
            this.btnFind,
            this.toolStripSeparator2,
            this.btnSave,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(716, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnExit
            // 
            this.btnExit.AutoSize = false;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(65, 35);
            this.btnExit.Text = "退出(&X)";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // btnFind
            // 
            this.btnFind.AutoSize = false;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(65, 35);
            this.btnFind.Text = "查找(&F)";
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 35);
            this.btnSave.Text = "儲存(&S)";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGetDetault);
            this.panel1.Controls.Add(this.txtAddInfo);
            this.panel1.Controls.Add(this.txtMo);
            this.panel1.Controls.Add(this.lblMo);
            this.panel1.Controls.Add(this.txtOc);
            this.panel1.Controls.Add(this.lblRemark);
            this.panel1.Controls.Add(this.lblOc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(716, 339);
            this.panel1.TabIndex = 1;
            // 
            // lblOc
            // 
            this.lblOc.AutoSize = true;
            this.lblOc.Location = new System.Drawing.Point(34, 15);
            this.lblOc.Name = "lblOc";
            this.lblOc.Size = new System.Drawing.Size(48, 12);
            this.lblOc.TabIndex = 0;
            this.lblOc.Text = "OC編號:";
            // 
            // txtOc
            // 
            this.txtOc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOc.Location = new System.Drawing.Point(87, 9);
            this.txtOc.MaxLength = 12;
            this.txtOc.Name = "txtOc";
            this.txtOc.Size = new System.Drawing.Size(142, 22);
            this.txtOc.TabIndex = 0;
            this.txtOc.Leave += new System.EventHandler(this.txtOc_Leave);
            // 
            // lblMo
            // 
            this.lblMo.AutoSize = true;
            this.lblMo.Location = new System.Drawing.Point(255, 15);
            this.lblMo.Name = "lblMo";
            this.lblMo.Size = new System.Drawing.Size(56, 12);
            this.lblMo.TabIndex = 0;
            this.lblMo.Text = "制單編號:";
            // 
            // txtMo
            // 
            this.txtMo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo.Location = new System.Drawing.Point(317, 9);
            this.txtMo.MaxLength = 9;
            this.txtMo.Name = "txtMo";
            this.txtMo.Size = new System.Drawing.Size(142, 22);
            this.txtMo.TabIndex = 1;
            this.txtMo.Leave += new System.EventHandler(this.txtMo_Leave);
            // 
            // txtAddInfo
            // 
            this.txtAddInfo.Location = new System.Drawing.Point(26, 73);
            this.txtAddInfo.Name = "txtAddInfo";
            this.txtAddInfo.Size = new System.Drawing.Size(588, 208);
            this.txtAddInfo.TabIndex = 2;
            this.txtAddInfo.Text = "";
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(26, 48);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(56, 12);
            this.lblRemark.TabIndex = 0;
            this.lblRemark.Text = "附加信息:";
            // 
            // btnGetDetault
            // 
            this.btnGetDetault.Location = new System.Drawing.Point(539, 43);
            this.btnGetDetault.Name = "btnGetDetault";
            this.btnGetDetault.Size = new System.Drawing.Size(75, 23);
            this.btnGetDetault.TabIndex = 3;
            this.btnGetDetault.Text = "獲取預設值";
            this.btnGetDetault.UseVisualStyleBackColor = true;
            this.btnGetDetault.Click += new System.EventHandler(this.btnGetDetault_Click);
            // 
            // frmOcAdditionalInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 519);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmOcAdditionalInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOcAdditionalInfo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtOc;
        private System.Windows.Forms.Label lblOc;
        private System.Windows.Forms.TextBox txtMo;
        private System.Windows.Forms.Label lblMo;
        private System.Windows.Forms.RichTextBox txtAddInfo;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Button btnGetDetault;
    }
}