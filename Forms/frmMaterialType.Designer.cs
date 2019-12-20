namespace cf01.Forms
{
    partial class frmMaterialType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaterialType));
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
            this.lblMat_group = new System.Windows.Forms.Label();
            this.txtMat_chs_desc = new System.Windows.Forms.TextBox();
            this.txtMat_code = new System.Windows.Forms.TextBox();
            this.lblMat_chs_desc = new System.Windows.Forms.Label();
            this.lblMat_code = new System.Windows.Forms.Label();
            this.txtMat_en_desc = new System.Windows.Forms.TextBox();
            this.lblMat_en_desc = new System.Windows.Forms.Label();
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
            this.toolStrip1.Size = new System.Drawing.Size(779, 25);
            this.toolStrip1.TabIndex = 4;
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
            this.splitContainer1.Panel1.Controls.Add(this.lblMat_group);
            this.splitContainer1.Panel1.Controls.Add(this.txtMat_chs_desc);
            this.splitContainer1.Panel1.Controls.Add(this.txtMat_code);
            this.splitContainer1.Panel1.Controls.Add(this.lblMat_chs_desc);
            this.splitContainer1.Panel1.Controls.Add(this.lblMat_code);
            this.splitContainer1.Panel1.Controls.Add(this.txtMat_en_desc);
            this.splitContainer1.Panel1.Controls.Add(this.lblMat_en_desc);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetails);
            this.splitContainer1.Size = new System.Drawing.Size(779, 516);
            this.splitContainer1.SplitterDistance = 94;
            this.splitContainer1.TabIndex = 5;
            // 
            // lueGroup
            // 
            this.lueGroup.EditValue = "";
            this.lueGroup.EnterMoveNextControl = true;
            this.lueGroup.Location = new System.Drawing.Point(95, 57);
            this.lueGroup.Name = "lueGroup";
            this.lueGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGroup.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lueGroup.Properties.DropDownRows = 15;
            this.lueGroup.Properties.MaxLength = 5;
            this.lueGroup.Properties.NullText = "";
            this.lueGroup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueGroup.Size = new System.Drawing.Size(172, 20);
            this.lueGroup.TabIndex = 2;
            this.lueGroup.Tag = "1";
            // 
            // lblMat_group
            // 
            this.lblMat_group.AutoSize = true;
            this.lblMat_group.Location = new System.Drawing.Point(12, 62);
            this.lblMat_group.Name = "lblMat_group";
            this.lblMat_group.Size = new System.Drawing.Size(53, 12);
            this.lblMat_group.TabIndex = 0;
            this.lblMat_group.Text = "所屬組別";
            // 
            // txtMat_chs_desc
            // 
            this.txtMat_chs_desc.Location = new System.Drawing.Point(455, 59);
            this.txtMat_chs_desc.Name = "txtMat_chs_desc";
            this.txtMat_chs_desc.Size = new System.Drawing.Size(278, 22);
            this.txtMat_chs_desc.TabIndex = 3;
            // 
            // txtMat_code
            // 
            this.txtMat_code.Location = new System.Drawing.Point(95, 12);
            this.txtMat_code.MaxLength = 2;
            this.txtMat_code.Name = "txtMat_code";
            this.txtMat_code.Size = new System.Drawing.Size(172, 22);
            this.txtMat_code.TabIndex = 0;
            // 
            // lblMat_chs_desc
            // 
            this.lblMat_chs_desc.AutoSize = true;
            this.lblMat_chs_desc.Location = new System.Drawing.Point(349, 62);
            this.lblMat_chs_desc.Name = "lblMat_chs_desc";
            this.lblMat_chs_desc.Size = new System.Drawing.Size(107, 12);
            this.lblMat_chs_desc.TabIndex = 0;
            this.lblMat_chs_desc.Text = "物料中文描述(CHS)";
            // 
            // lblMat_code
            // 
            this.lblMat_code.AutoSize = true;
            this.lblMat_code.Location = new System.Drawing.Point(12, 15);
            this.lblMat_code.Name = "lblMat_code";
            this.lblMat_code.Size = new System.Drawing.Size(77, 12);
            this.lblMat_code.TabIndex = 0;
            this.lblMat_code.Text = "物料種類編號";
            // 
            // txtMat_en_desc
            // 
            this.txtMat_en_desc.Location = new System.Drawing.Point(455, 12);
            this.txtMat_en_desc.Name = "txtMat_en_desc";
            this.txtMat_en_desc.Size = new System.Drawing.Size(278, 22);
            this.txtMat_en_desc.TabIndex = 1;
            // 
            // lblMat_en_desc
            // 
            this.lblMat_en_desc.AutoSize = true;
            this.lblMat_en_desc.Location = new System.Drawing.Point(349, 15);
            this.lblMat_en_desc.Name = "lblMat_en_desc";
            this.lblMat_en_desc.Size = new System.Drawing.Size(100, 12);
            this.lblMat_en_desc.TabIndex = 0;
            this.lblMat_en_desc.Text = "物料英文描述(EN)";
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
            this.dgvDetails.Size = new System.Drawing.Size(775, 414);
            this.dgvDetails.TabIndex = 4;
            this.dgvDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellClick);
            // 
            // frmMaterialType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 541);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMaterialType";
            this.Text = "物料種類";
            this.Load += new System.EventHandler(this.frmMaterialType_Load);
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
        private System.Windows.Forms.ToolStripButton BTNFIND;
        private System.Windows.Forms.ToolStripButton BTNCANCEL;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblMat_group;
        private System.Windows.Forms.TextBox txtMat_chs_desc;
        private System.Windows.Forms.TextBox txtMat_code;
        private System.Windows.Forms.Label lblMat_chs_desc;
        private System.Windows.Forms.Label lblMat_code;
        private System.Windows.Forms.TextBox txtMat_en_desc;
        private System.Windows.Forms.Label lblMat_en_desc;
        private System.Windows.Forms.DataGridView dgvDetails;
        private DevExpress.XtraEditors.LookUpEdit lueGroup;
    }
}