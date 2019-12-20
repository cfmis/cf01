namespace cf01.Forms
{
    partial class frmUnit
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUnit));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.BTNNEW = new System.Windows.Forms.ToolStripButton();
            this.BTNEDIT = new System.Windows.Forms.ToolStripButton();
            this.BTNSAVE = new System.Windows.Forms.ToolStripButton();
            this.BTNDELETE = new System.Windows.Forms.ToolStripButton();
            this.BTNFIND = new System.Windows.Forms.ToolStripButton();
            this.BTNCANCEL = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtUnit_Id = new System.Windows.Forms.TextBox();
            this.lblUnit_Id = new System.Windows.Forms.Label();
            this.txtCh_desc = new System.Windows.Forms.TextBox();
            this.lblCh_desc = new System.Windows.Forms.Label();
            this.txtEn_desc = new System.Windows.Forms.TextBox();
            this.lblEn_decs = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNEXIT,
            this.BTNNEW,
            this.BTNEDIT,
            this.BTNSAVE,
            this.BTNDELETE,
            this.BTNFIND,
            this.BTNCANCEL});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(714, 25);
            this.toolStrip1.TabIndex = 0;
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
            // BTNNEW
            // 
            this.BTNNEW.Image = ((System.Drawing.Image)(resources.GetObject("BTNNEW.Image")));
            this.BTNNEW.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNNEW.Name = "BTNNEW";
            this.BTNNEW.Size = new System.Drawing.Size(52, 22);
            this.BTNNEW.Text = "新增";
            this.BTNNEW.Click += new System.EventHandler(this.BTNNEW_Click);
            // 
            // BTNEDIT
            // 
            this.BTNEDIT.Image = ((System.Drawing.Image)(resources.GetObject("BTNEDIT.Image")));
            this.BTNEDIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEDIT.Name = "BTNEDIT";
            this.BTNEDIT.Size = new System.Drawing.Size(52, 22);
            this.BTNEDIT.Text = "編輯";
            this.BTNEDIT.Click += new System.EventHandler(this.BTNEDIT_Click);
            // 
            // BTNSAVE
            // 
            this.BTNSAVE.Image = ((System.Drawing.Image)(resources.GetObject("BTNSAVE.Image")));
            this.BTNSAVE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNSAVE.Name = "BTNSAVE";
            this.BTNSAVE.Size = new System.Drawing.Size(52, 22);
            this.BTNSAVE.Text = "保存";
            this.BTNSAVE.Click += new System.EventHandler(this.BTNSAVE_Click);
            // 
            // BTNDELETE
            // 
            this.BTNDELETE.Image = ((System.Drawing.Image)(resources.GetObject("BTNDELETE.Image")));
            this.BTNDELETE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNDELETE.Name = "BTNDELETE";
            this.BTNDELETE.Size = new System.Drawing.Size(52, 22);
            this.BTNDELETE.Text = "刪除";
            this.BTNDELETE.Click += new System.EventHandler(this.BTNDELETE_Click);
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
            // BTNCANCEL
            // 
            this.BTNCANCEL.Image = ((System.Drawing.Image)(resources.GetObject("BTNCANCEL.Image")));
            this.BTNCANCEL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNCANCEL.Name = "BTNCANCEL";
            this.BTNCANCEL.Size = new System.Drawing.Size(52, 22);
            this.BTNCANCEL.Text = "取消";
            this.BTNCANCEL.Click += new System.EventHandler(this.BTNCANCEL_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtUnit_Id);
            this.splitContainer1.Panel1.Controls.Add(this.lblUnit_Id);
            this.splitContainer1.Panel1.Controls.Add(this.txtCh_desc);
            this.splitContainer1.Panel1.Controls.Add(this.lblCh_desc);
            this.splitContainer1.Panel1.Controls.Add(this.txtEn_desc);
            this.splitContainer1.Panel1.Controls.Add(this.lblEn_decs);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetails);
            this.splitContainer1.Size = new System.Drawing.Size(714, 513);
            this.splitContainer1.SplitterDistance = 67;
            this.splitContainer1.TabIndex = 1;
            // 
            // txtUnit_Id
            // 
            this.txtUnit_Id.Location = new System.Drawing.Point(66, 20);
            this.txtUnit_Id.MaxLength = 3;
            this.txtUnit_Id.Name = "txtUnit_Id";
            this.txtUnit_Id.Size = new System.Drawing.Size(126, 22);
            this.txtUnit_Id.TabIndex = 1;
            // 
            // lblUnit_Id
            // 
            this.lblUnit_Id.AutoSize = true;
            this.lblUnit_Id.Location = new System.Drawing.Point(19, 26);
            this.lblUnit_Id.Name = "lblUnit_Id";
            this.lblUnit_Id.Size = new System.Drawing.Size(41, 12);
            this.lblUnit_Id.TabIndex = 2;
            this.lblUnit_Id.Text = "單位ID";
            // 
            // txtCh_desc
            // 
            this.txtCh_desc.Location = new System.Drawing.Point(552, 20);
            this.txtCh_desc.Name = "txtCh_desc";
            this.txtCh_desc.Size = new System.Drawing.Size(150, 22);
            this.txtCh_desc.TabIndex = 3;
            // 
            // lblCh_desc
            // 
            this.lblCh_desc.AutoSize = true;
            this.lblCh_desc.Location = new System.Drawing.Point(469, 26);
            this.lblCh_desc.Name = "lblCh_desc";
            this.lblCh_desc.Size = new System.Drawing.Size(77, 12);
            this.lblCh_desc.TabIndex = 0;
            this.lblCh_desc.Text = "單位中文描述";
            // 
            // txtEn_desc
            // 
            this.txtEn_desc.Location = new System.Drawing.Point(298, 20);
            this.txtEn_desc.Name = "txtEn_desc";
            this.txtEn_desc.Size = new System.Drawing.Size(150, 22);
            this.txtEn_desc.TabIndex = 2;
            // 
            // lblEn_decs
            // 
            this.lblEn_decs.AutoSize = true;
            this.lblEn_decs.Location = new System.Drawing.Point(215, 26);
            this.lblEn_decs.Name = "lblEn_decs";
            this.lblEn_decs.Size = new System.Drawing.Size(77, 12);
            this.lblEn_decs.TabIndex = 0;
            this.lblEn_decs.Text = "單位英文描述";
            // 
            // dgvDetails
            // 
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetails.Location = new System.Drawing.Point(3, 3);
            this.dgvDetails.Name = "dgvDetails";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(708, 438);
            this.dgvDetails.TabIndex = 0;
            this.dgvDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            // 
            // frmUnit
            // 
            this.ClientSize = new System.Drawing.Size(714, 538);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Name = "frmUnit";
            this.Text = "單位代號";
            this.Load += new System.EventHandler(this.frmUnit_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

      
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripButton BTNNEW;
        private System.Windows.Forms.ToolStripButton BTNEDIT;
        private System.Windows.Forms.ToolStripButton BTNSAVE;
        private System.Windows.Forms.ToolStripButton BTNFIND;
        private System.Windows.Forms.ToolStripButton BTNCANCEL;
        private System.Windows.Forms.TextBox txtCh_desc;
        private System.Windows.Forms.Label lblCh_desc;
        private System.Windows.Forms.TextBox txtEn_desc;
        private System.Windows.Forms.Label lblEn_decs;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.ToolStripButton BTNDELETE;
        private System.Windows.Forms.TextBox txtUnit_Id;
        private System.Windows.Forms.Label lblUnit_Id;
    }
}
