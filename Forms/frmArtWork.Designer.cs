namespace cf01.Forms
{
    partial class frmArtWork
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArtWork));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.BTNNEW = new System.Windows.Forms.ToolStripButton();
            this.BTNEDIT = new System.Windows.Forms.ToolStripButton();
            this.BTNSAVE = new System.Windows.Forms.ToolStripButton();
            this.BTNDELETE = new System.Windows.Forms.ToolStripButton();
            this.BTNCANCEL = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lueGroup = new DevExpress.XtraEditors.LookUpEdit();
            this.grpBoxQuery = new System.Windows.Forms.GroupBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtAtr_code_Q = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtArt_en_desc_Q = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtArt_chs_desc_Q = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtArt_tech_document = new System.Windows.Forms.TextBox();
            this.lblArt_tech_document = new System.Windows.Forms.Label();
            this.txtArt_customer = new System.Windows.Forms.TextBox();
            this.lblArt_customer = new System.Windows.Forms.Label();
            this.txtArt_image = new System.Windows.Forms.TextBox();
            this.txtArt_chs_desc = new System.Windows.Forms.TextBox();
            this.txtArt_brand = new System.Windows.Forms.TextBox();
            this.lblArt_image = new System.Windows.Forms.Label();
            this.lblArt_chs_desc = new System.Windows.Forms.Label();
            this.lblArt_brand = new System.Windows.Forms.Label();
            this.txtArt_creater = new System.Windows.Forms.TextBox();
            this.txtArt_en_desc = new System.Windows.Forms.TextBox();
            this.lblArt_creater = new System.Windows.Forms.Label();
            this.lblArt_en_desc = new System.Windows.Forms.Label();
            this.lblArt_group = new System.Windows.Forms.Label();
            this.txtArt_code = new System.Windows.Forms.TextBox();
            this.lblArt_code = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueGroup.Properties)).BeginInit();
            this.grpBoxQuery.SuspendLayout();
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
            this.BTNCANCEL});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1088, 25);
            this.toolStrip1.TabIndex = 6;
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
            this.splitContainer1.Panel1.Controls.Add(this.grpBoxQuery);
            this.splitContainer1.Panel1.Controls.Add(this.txtArt_tech_document);
            this.splitContainer1.Panel1.Controls.Add(this.lblArt_tech_document);
            this.splitContainer1.Panel1.Controls.Add(this.txtArt_customer);
            this.splitContainer1.Panel1.Controls.Add(this.lblArt_customer);
            this.splitContainer1.Panel1.Controls.Add(this.txtArt_image);
            this.splitContainer1.Panel1.Controls.Add(this.txtArt_chs_desc);
            this.splitContainer1.Panel1.Controls.Add(this.txtArt_brand);
            this.splitContainer1.Panel1.Controls.Add(this.lblArt_image);
            this.splitContainer1.Panel1.Controls.Add(this.lblArt_chs_desc);
            this.splitContainer1.Panel1.Controls.Add(this.lblArt_brand);
            this.splitContainer1.Panel1.Controls.Add(this.txtArt_creater);
            this.splitContainer1.Panel1.Controls.Add(this.txtArt_en_desc);
            this.splitContainer1.Panel1.Controls.Add(this.lblArt_creater);
            this.splitContainer1.Panel1.Controls.Add(this.lblArt_en_desc);
            this.splitContainer1.Panel1.Controls.Add(this.lblArt_group);
            this.splitContainer1.Panel1.Controls.Add(this.txtArt_code);
            this.splitContainer1.Panel1.Controls.Add(this.lblArt_code);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetails);
            this.splitContainer1.Size = new System.Drawing.Size(1088, 558);
            this.splitContainer1.SplitterDistance = 179;
            this.splitContainer1.TabIndex = 7;
            // 
            // lueGroup
            // 
            this.lueGroup.EditValue = "";
            this.lueGroup.EnterMoveNextControl = true;
            this.lueGroup.Location = new System.Drawing.Point(466, 7);
            this.lueGroup.Name = "lueGroup";
            this.lueGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGroup.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lueGroup.Properties.DropDownRows = 15;
            this.lueGroup.Properties.MaxLength = 5;
            this.lueGroup.Properties.NullText = "";
            this.lueGroup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueGroup.Size = new System.Drawing.Size(170, 20);
            this.lueGroup.TabIndex = 15;
            this.lueGroup.Tag = "1";
            // 
            // grpBoxQuery
            // 
            this.grpBoxQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxQuery.Controls.Add(this.btnQuery);
            this.grpBoxQuery.Controls.Add(this.txtAtr_code_Q);
            this.grpBoxQuery.Controls.Add(this.label1);
            this.grpBoxQuery.Controls.Add(this.txtArt_en_desc_Q);
            this.grpBoxQuery.Controls.Add(this.label2);
            this.grpBoxQuery.Controls.Add(this.txtArt_chs_desc_Q);
            this.grpBoxQuery.Controls.Add(this.label3);
            this.grpBoxQuery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.grpBoxQuery.Location = new System.Drawing.Point(-1, 121);
            this.grpBoxQuery.Name = "grpBoxQuery";
            this.grpBoxQuery.Size = new System.Drawing.Size(1086, 56);
            this.grpBoxQuery.TabIndex = 14;
            this.grpBoxQuery.TabStop = false;
            this.grpBoxQuery.Text = "查詢框";
            // 
            // btnQuery
            // 
            this.btnQuery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnQuery.Location = new System.Drawing.Point(997, 20);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(78, 23);
            this.btnQuery.TabIndex = 12;
            this.btnQuery.Text = "查詢";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtAtr_code_Q
            // 
            this.txtAtr_code_Q.Location = new System.Drawing.Point(70, 22);
            this.txtAtr_code_Q.Name = "txtAtr_code_Q";
            this.txtAtr_code_Q.Size = new System.Drawing.Size(170, 22);
            this.txtAtr_code_Q.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "圖樣代號";
            // 
            // txtArt_en_desc_Q
            // 
            this.txtArt_en_desc_Q.Location = new System.Drawing.Point(366, 22);
            this.txtArt_en_desc_Q.Name = "txtArt_en_desc_Q";
            this.txtArt_en_desc_Q.Size = new System.Drawing.Size(250, 22);
            this.txtArt_en_desc_Q.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "英文描述";
            // 
            // txtArt_chs_desc_Q
            // 
            this.txtArt_chs_desc_Q.Location = new System.Drawing.Point(729, 22);
            this.txtArt_chs_desc_Q.Name = "txtArt_chs_desc_Q";
            this.txtArt_chs_desc_Q.Size = new System.Drawing.Size(250, 22);
            this.txtArt_chs_desc_Q.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(670, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "中文描述";
            // 
            // txtArt_tech_document
            // 
            this.txtArt_tech_document.Location = new System.Drawing.Point(728, 76);
            this.txtArt_tech_document.Name = "txtArt_tech_document";
            this.txtArt_tech_document.Size = new System.Drawing.Size(346, 22);
            this.txtArt_tech_document.TabIndex = 8;
            // 
            // lblArt_tech_document
            // 
            this.lblArt_tech_document.AutoSize = true;
            this.lblArt_tech_document.Location = new System.Drawing.Point(669, 79);
            this.lblArt_tech_document.Name = "lblArt_tech_document";
            this.lblArt_tech_document.Size = new System.Drawing.Size(53, 12);
            this.lblArt_tech_document.TabIndex = 0;
            this.lblArt_tech_document.Text = "技術文件";
            // 
            // txtArt_customer
            // 
            this.txtArt_customer.Location = new System.Drawing.Point(466, 76);
            this.txtArt_customer.Name = "txtArt_customer";
            this.txtArt_customer.Size = new System.Drawing.Size(170, 22);
            this.txtArt_customer.TabIndex = 5;
            // 
            // lblArt_customer
            // 
            this.lblArt_customer.AutoSize = true;
            this.lblArt_customer.Location = new System.Drawing.Point(407, 79);
            this.lblArt_customer.Name = "lblArt_customer";
            this.lblArt_customer.Size = new System.Drawing.Size(53, 12);
            this.lblArt_customer.TabIndex = 0;
            this.lblArt_customer.Text = "起模客戶";
            // 
            // txtArt_image
            // 
            this.txtArt_image.Location = new System.Drawing.Point(728, 42);
            this.txtArt_image.Name = "txtArt_image";
            this.txtArt_image.Size = new System.Drawing.Size(346, 22);
            this.txtArt_image.TabIndex = 7;
            // 
            // txtArt_chs_desc
            // 
            this.txtArt_chs_desc.Location = new System.Drawing.Point(93, 76);
            this.txtArt_chs_desc.Name = "txtArt_chs_desc";
            this.txtArt_chs_desc.Size = new System.Drawing.Size(270, 22);
            this.txtArt_chs_desc.TabIndex = 2;
            // 
            // txtArt_brand
            // 
            this.txtArt_brand.Location = new System.Drawing.Point(466, 42);
            this.txtArt_brand.Name = "txtArt_brand";
            this.txtArt_brand.Size = new System.Drawing.Size(170, 22);
            this.txtArt_brand.TabIndex = 4;
            // 
            // lblArt_image
            // 
            this.lblArt_image.AutoSize = true;
            this.lblArt_image.Location = new System.Drawing.Point(669, 45);
            this.lblArt_image.Name = "lblArt_image";
            this.lblArt_image.Size = new System.Drawing.Size(53, 12);
            this.lblArt_image.TabIndex = 0;
            this.lblArt_image.Text = "圖像位置";
            // 
            // lblArt_chs_desc
            // 
            this.lblArt_chs_desc.AutoSize = true;
            this.lblArt_chs_desc.Location = new System.Drawing.Point(10, 79);
            this.lblArt_chs_desc.Name = "lblArt_chs_desc";
            this.lblArt_chs_desc.Size = new System.Drawing.Size(77, 12);
            this.lblArt_chs_desc.TabIndex = 0;
            this.lblArt_chs_desc.Text = "圖樣名稱中文";
            // 
            // lblArt_brand
            // 
            this.lblArt_brand.AutoSize = true;
            this.lblArt_brand.Location = new System.Drawing.Point(407, 45);
            this.lblArt_brand.Name = "lblArt_brand";
            this.lblArt_brand.Size = new System.Drawing.Size(53, 12);
            this.lblArt_brand.TabIndex = 0;
            this.lblArt_brand.Text = "所屬牌子";
            // 
            // txtArt_creater
            // 
            this.txtArt_creater.Location = new System.Drawing.Point(728, 9);
            this.txtArt_creater.Name = "txtArt_creater";
            this.txtArt_creater.Size = new System.Drawing.Size(201, 22);
            this.txtArt_creater.TabIndex = 6;
            // 
            // txtArt_en_desc
            // 
            this.txtArt_en_desc.Location = new System.Drawing.Point(93, 42);
            this.txtArt_en_desc.Name = "txtArt_en_desc";
            this.txtArt_en_desc.Size = new System.Drawing.Size(270, 22);
            this.txtArt_en_desc.TabIndex = 1;
            // 
            // lblArt_creater
            // 
            this.lblArt_creater.AutoSize = true;
            this.lblArt_creater.Location = new System.Drawing.Point(669, 12);
            this.lblArt_creater.Name = "lblArt_creater";
            this.lblArt_creater.Size = new System.Drawing.Size(41, 12);
            this.lblArt_creater.TabIndex = 0;
            this.lblArt_creater.Text = "起模人";
            // 
            // lblArt_en_desc
            // 
            this.lblArt_en_desc.AutoSize = true;
            this.lblArt_en_desc.Location = new System.Drawing.Point(10, 45);
            this.lblArt_en_desc.Name = "lblArt_en_desc";
            this.lblArt_en_desc.Size = new System.Drawing.Size(77, 12);
            this.lblArt_en_desc.TabIndex = 0;
            this.lblArt_en_desc.Text = "圖樣描述英文";
            // 
            // lblArt_group
            // 
            this.lblArt_group.AutoSize = true;
            this.lblArt_group.Location = new System.Drawing.Point(407, 12);
            this.lblArt_group.Name = "lblArt_group";
            this.lblArt_group.Size = new System.Drawing.Size(53, 12);
            this.lblArt_group.TabIndex = 0;
            this.lblArt_group.Text = "所屬組別";
            // 
            // txtArt_code
            // 
            this.txtArt_code.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtArt_code.Location = new System.Drawing.Point(93, 9);
            this.txtArt_code.MaxLength = 7;
            this.txtArt_code.Name = "txtArt_code";
            this.txtArt_code.Size = new System.Drawing.Size(170, 22);
            this.txtArt_code.TabIndex = 0;
            // 
            // lblArt_code
            // 
            this.lblArt_code.AutoSize = true;
            this.lblArt_code.Location = new System.Drawing.Point(10, 12);
            this.lblArt_code.Name = "lblArt_code";
            this.lblArt_code.Size = new System.Drawing.Size(53, 12);
            this.lblArt_code.TabIndex = 0;
            this.lblArt_code.Text = "圖樣代號";
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
            this.dgvDetails.Size = new System.Drawing.Size(1084, 371);
            this.dgvDetails.TabIndex = 13;
            this.dgvDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellClick);
            // 
            // frmArtWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 583);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmArtWork";
            this.Text = "frmArtWork";
            this.Load += new System.EventHandler(this.frmArtWork_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueGroup.Properties)).EndInit();
            this.grpBoxQuery.ResumeLayout(false);
            this.grpBoxQuery.PerformLayout();
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
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.GroupBox grpBoxQuery;
        private System.Windows.Forms.TextBox txtArt_tech_document;
        private System.Windows.Forms.Label lblArt_tech_document;
        private System.Windows.Forms.TextBox txtArt_customer;
        private System.Windows.Forms.Label lblArt_customer;
        private System.Windows.Forms.TextBox txtArt_image;
        private System.Windows.Forms.TextBox txtArt_chs_desc;
        private System.Windows.Forms.TextBox txtArt_brand;
        private System.Windows.Forms.Label lblArt_image;
        private System.Windows.Forms.Label lblArt_chs_desc;
        private System.Windows.Forms.Label lblArt_brand;
        private System.Windows.Forms.TextBox txtArt_creater;
        private System.Windows.Forms.TextBox txtArt_en_desc;
        private System.Windows.Forms.Label lblArt_creater;
        private System.Windows.Forms.Label lblArt_en_desc;
        private System.Windows.Forms.Label lblArt_group;
        private System.Windows.Forms.TextBox txtArt_code;
        private System.Windows.Forms.Label lblArt_code;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtAtr_code_Q;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtArt_en_desc_Q;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtArt_chs_desc_Q;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LookUpEdit lueGroup;
    }
}