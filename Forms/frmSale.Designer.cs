namespace cf01.Forms
{
    partial class frmSale
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSale));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.BTNNEW = new System.Windows.Forms.ToolStripButton();
            this.BTNEDIT = new System.Windows.Forms.ToolStripButton();
            this.BTNSAVE = new System.Windows.Forms.ToolStripButton();
            this.BTNDELETE = new System.Windows.Forms.ToolStripButton();
            this.BTNFIND = new System.Windows.Forms.ToolStripButton();
            this.BTNCANCEL = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lueGroup = new DevExpress.XtraEditors.LookUpEdit();
            this.lblShort_name = new System.Windows.Forms.Label();
            this.txtSale_chs_desc = new System.Windows.Forms.TextBox();
            this.lblSale_chs_desc = new System.Windows.Forms.Label();
            this.txtShort_name = new System.Windows.Forms.TextBox();
            this.txtSale_en_desc = new System.Windows.Forms.TextBox();
            this.lblSaleGroup = new System.Windows.Forms.Label();
            this.lblSale_en_desc = new System.Windows.Forms.Label();
            this.txtSalerCode = new System.Windows.Forms.TextBox();
            this.lblSaleCode = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueGroup.Properties)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(774, 25);
            this.toolStrip1.TabIndex = 3;
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
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lueGroup);
            this.splitContainer1.Panel1.Controls.Add(this.lblShort_name);
            this.splitContainer1.Panel1.Controls.Add(this.txtSale_chs_desc);
            this.splitContainer1.Panel1.Controls.Add(this.lblSale_chs_desc);
            this.splitContainer1.Panel1.Controls.Add(this.txtShort_name);
            this.splitContainer1.Panel1.Controls.Add(this.txtSale_en_desc);
            this.splitContainer1.Panel1.Controls.Add(this.lblSaleGroup);
            this.splitContainer1.Panel1.Controls.Add(this.lblSale_en_desc);
            this.splitContainer1.Panel1.Controls.Add(this.txtSalerCode);
            this.splitContainer1.Panel1.Controls.Add(this.lblSaleCode);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetails);
            this.splitContainer1.Size = new System.Drawing.Size(773, 521);
            this.splitContainer1.SplitterDistance = 93;
            this.splitContainer1.TabIndex = 4;
            // 
            // lueGroup
            // 
            this.lueGroup.EditValue = "";
            this.lueGroup.EnterMoveNextControl = true;
            this.lueGroup.Location = new System.Drawing.Point(87, 59);
            this.lueGroup.Name = "lueGroup";
            this.lueGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGroup.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lueGroup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("grp_code", "Name1"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("grp_desc", "Name2")});
            this.lueGroup.Properties.DropDownRows = 15;
            this.lueGroup.Properties.MaxLength = 5;
            this.lueGroup.Properties.NullText = "";
            this.lueGroup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueGroup.Size = new System.Drawing.Size(167, 20);
            this.lueGroup.TabIndex = 3;
            this.lueGroup.Tag = "1";
            // 
            // lblShort_name
            // 
            this.lblShort_name.AutoSize = true;
            this.lblShort_name.Location = new System.Drawing.Point(588, 17);
            this.lblShort_name.Name = "lblShort_name";
            this.lblShort_name.Size = new System.Drawing.Size(53, 12);
            this.lblShort_name.TabIndex = 5;
            this.lblShort_name.Text = "簡寫編號";
            // 
            // txtSale_chs_desc
            // 
            this.txtSale_chs_desc.Location = new System.Drawing.Point(438, 61);
            this.txtSale_chs_desc.Name = "txtSale_chs_desc";
            this.txtSale_chs_desc.Size = new System.Drawing.Size(144, 22);
            this.txtSale_chs_desc.TabIndex = 4;
            // 
            // lblSale_chs_desc
            // 
            this.lblSale_chs_desc.AutoSize = true;
            this.lblSale_chs_desc.Location = new System.Drawing.Point(344, 64);
            this.lblSale_chs_desc.Name = "lblSale_chs_desc";
            this.lblSale_chs_desc.Size = new System.Drawing.Size(95, 12);
            this.lblSale_chs_desc.TabIndex = 0;
            this.lblSale_chs_desc.Text = "營業員描述(CHS)";
            // 
            // txtShort_name
            // 
            this.txtShort_name.Location = new System.Drawing.Point(647, 14);
            this.txtShort_name.Name = "txtShort_name";
            this.txtShort_name.Size = new System.Drawing.Size(113, 22);
            this.txtShort_name.TabIndex = 2;
            // 
            // txtSale_en_desc
            // 
            this.txtSale_en_desc.Location = new System.Drawing.Point(438, 14);
            this.txtSale_en_desc.Name = "txtSale_en_desc";
            this.txtSale_en_desc.Size = new System.Drawing.Size(144, 22);
            this.txtSale_en_desc.TabIndex = 1;
            // 
            // lblSaleGroup
            // 
            this.lblSaleGroup.AutoSize = true;
            this.lblSaleGroup.Location = new System.Drawing.Point(16, 64);
            this.lblSaleGroup.Name = "lblSaleGroup";
            this.lblSaleGroup.Size = new System.Drawing.Size(53, 12);
            this.lblSaleGroup.TabIndex = 0;
            this.lblSaleGroup.Text = "所屬組別";
            // 
            // lblSale_en_desc
            // 
            this.lblSale_en_desc.AutoSize = true;
            this.lblSale_en_desc.Location = new System.Drawing.Point(344, 17);
            this.lblSale_en_desc.Name = "lblSale_en_desc";
            this.lblSale_en_desc.Size = new System.Drawing.Size(88, 12);
            this.lblSale_en_desc.TabIndex = 0;
            this.lblSale_en_desc.Text = "營業員描述(EN)";
            // 
            // txtSalerCode
            // 
            this.txtSalerCode.Location = new System.Drawing.Point(87, 14);
            this.txtSalerCode.MaxLength = 4;
            this.txtSalerCode.Name = "txtSalerCode";
            this.txtSalerCode.Size = new System.Drawing.Size(167, 22);
            this.txtSalerCode.TabIndex = 0;
            // 
            // lblSaleCode
            // 
            this.lblSaleCode.AutoSize = true;
            this.lblSaleCode.Location = new System.Drawing.Point(16, 17);
            this.lblSaleCode.Name = "lblSaleCode";
            this.lblSaleCode.Size = new System.Drawing.Size(65, 12);
            this.lblSaleCode.TabIndex = 0;
            this.lblSaleCode.Text = "營業員代號";
            // 
            // dgvDetails
            // 
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(769, 420);
            this.dgvDetails.TabIndex = 5;
            this.dgvDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellClick);
            // 
            // frmSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 546);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmSale";
            this.Text = "營業員";
            this.Load += new System.EventHandler(this.frmSale_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripButton BTNNEW;
        private System.Windows.Forms.ToolStripButton BTNEDIT;
        private System.Windows.Forms.ToolStripButton BTNSAVE;
        private System.Windows.Forms.ToolStripButton BTNDELETE;
        private System.Windows.Forms.ToolStripButton BTNCANCEL;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton BTNFIND;
        private System.Windows.Forms.TextBox txtSale_chs_desc;
        private System.Windows.Forms.Label lblSale_chs_desc;
        private System.Windows.Forms.TextBox txtSale_en_desc;
        private System.Windows.Forms.Label lblSaleGroup;
        private System.Windows.Forms.Label lblSale_en_desc;
        private System.Windows.Forms.TextBox txtSalerCode;
        private System.Windows.Forms.Label lblSaleCode;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Label lblShort_name;
        private System.Windows.Forms.TextBox txtShort_name;
        private DevExpress.XtraEditors.LookUpEdit lueGroup;
    }
}