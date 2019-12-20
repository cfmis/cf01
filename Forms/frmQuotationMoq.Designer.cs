namespace cf01.Forms
{
    partial class frmQuotationMoq
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
            this.pnlHead = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBrandEnd = new System.Windows.Forms.TextBox();
            this.txtBrandBegin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.lblSales_group = new System.Windows.Forms.Label();
            this.txtMoq = new DevExpress.XtraEditors.TextEdit();
            this.lueMoq_unit = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBrand_category = new System.Windows.Forms.Label();
            this.lblAmtim = new System.Windows.Forms.Label();
            this.lueBrand_id = new DevExpress.XtraEditors.LookUpEdit();
            this.lblAmusr = new System.Windows.Forms.Label();
            this.lblremark = new System.Windows.Forms.Label();
            this.lblCrtim = new System.Windows.Forms.Label();
            this.txtRemark = new DevExpress.XtraEditors.TextEdit();
            this.lblCrusr = new System.Windows.Forms.Label();
            this.txtCreate_by = new DevExpress.XtraEditors.TextEdit();
            this.txtUpdate_date = new DevExpress.XtraEditors.TextEdit();
            this.txtCreate_date = new DevExpress.XtraEditors.TextEdit();
            this.txtUpdate_by = new DevExpress.XtraEditors.TextEdit();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.brand_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moq_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.create_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.create_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bds1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.pnlHead.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoq.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMoq_unit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBrand_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_by.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpdate_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpdate_by.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDetails);
            this.panel1.Controls.Add(this.pnlHead);
            this.panel1.Size = new System.Drawing.Size(1055, 566);
            this.panel1.Controls.SetChildIndex(this.pnlHead, 0);
            this.panel1.Controls.SetChildIndex(this.dgvDetails, 0);
            // 
            // pnlHead
            // 
            this.pnlHead.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHead.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHead.Controls.Add(this.groupBox1);
            this.pnlHead.Controls.Add(this.pnlInput);
            this.pnlHead.Location = new System.Drawing.Point(2, 34);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(1049, 162);
            this.pnlHead.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtBrandEnd);
            this.groupBox1.Controls.Add(this.txtBrandBegin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(608, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 125);
            this.groupBox1.TabIndex = 122;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查找條件";
            // 
            // txtBrandEnd
            // 
            this.txtBrandEnd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBrandEnd.Location = new System.Drawing.Point(262, 42);
            this.txtBrandEnd.MaxLength = 20;
            this.txtBrandEnd.Name = "txtBrandEnd";
            this.txtBrandEnd.Size = new System.Drawing.Size(131, 22);
            this.txtBrandEnd.TabIndex = 114;
            // 
            // txtBrandBegin
            // 
            this.txtBrandBegin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBrandBegin.Location = new System.Drawing.Point(90, 43);
            this.txtBrandBegin.MaxLength = 20;
            this.txtBrandBegin.Name = "txtBrandBegin";
            this.txtBrandBegin.Size = new System.Drawing.Size(131, 22);
            this.txtBrandBegin.TabIndex = 113;
            this.txtBrandBegin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBrandBegin_KeyPress);
            this.txtBrandBegin.Leave += new System.EventHandler(this.txtBrandBegin_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 112;
            this.label2.Text = "~";
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(26, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 29);
            this.label3.TabIndex = 111;
            this.label3.Text = "牌子編號客戶編號";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlInput
            // 
            this.pnlInput.Controls.Add(this.lblSales_group);
            this.pnlInput.Controls.Add(this.txtMoq);
            this.pnlInput.Controls.Add(this.lueMoq_unit);
            this.pnlInput.Controls.Add(this.label1);
            this.pnlInput.Controls.Add(this.lblBrand_category);
            this.pnlInput.Controls.Add(this.lblAmtim);
            this.pnlInput.Controls.Add(this.lueBrand_id);
            this.pnlInput.Controls.Add(this.lblAmusr);
            this.pnlInput.Controls.Add(this.lblremark);
            this.pnlInput.Controls.Add(this.lblCrtim);
            this.pnlInput.Controls.Add(this.txtRemark);
            this.pnlInput.Controls.Add(this.lblCrusr);
            this.pnlInput.Controls.Add(this.txtCreate_by);
            this.pnlInput.Controls.Add(this.txtUpdate_date);
            this.pnlInput.Controls.Add(this.txtCreate_date);
            this.pnlInput.Controls.Add(this.txtUpdate_by);
            this.pnlInput.Location = new System.Drawing.Point(4, 9);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(574, 139);
            this.pnlInput.TabIndex = 121;
            // 
            // lblSales_group
            // 
            this.lblSales_group.ForeColor = System.Drawing.Color.Blue;
            this.lblSales_group.Location = new System.Drawing.Point(10, 13);
            this.lblSales_group.Name = "lblSales_group";
            this.lblSales_group.Size = new System.Drawing.Size(109, 13);
            this.lblSales_group.TabIndex = 108;
            this.lblSales_group.Text = "牌子編號/客戶編號";
            this.lblSales_group.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMoq
            // 
            this.txtMoq.EnterMoveNextControl = true;
            this.txtMoq.Location = new System.Drawing.Point(380, 32);
            this.txtMoq.Name = "txtMoq";
            this.txtMoq.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtMoq.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtMoq.Properties.Mask.EditMask = "n0";
            this.txtMoq.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMoq.Properties.MaxLength = 255;
            this.txtMoq.Properties.ReadOnly = true;
            this.txtMoq.Size = new System.Drawing.Size(175, 20);
            this.txtMoq.TabIndex = 119;
            this.txtMoq.Tag = "2";
            // 
            // lueMoq_unit
            // 
            this.lueMoq_unit.EditValue = "";
            this.lueMoq_unit.Enabled = false;
            this.lueMoq_unit.EnterMoveNextControl = true;
            this.lueMoq_unit.Location = new System.Drawing.Point(122, 32);
            this.lueMoq_unit.Name = "lueMoq_unit";
            this.lueMoq_unit.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.lueMoq_unit.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.lueMoq_unit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMoq_unit.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lueMoq_unit.Properties.DropDownRows = 13;
            this.lueMoq_unit.Properties.MaxLength = 4;
            this.lueMoq_unit.Properties.NullText = "";
            this.lueMoq_unit.Properties.PopupFormMinSize = new System.Drawing.Size(200, 0);
            this.lueMoq_unit.Properties.ShowHeader = false;
            this.lueMoq_unit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueMoq_unit.Size = new System.Drawing.Size(172, 20);
            this.lueMoq_unit.TabIndex = 106;
            this.lueMoq_unit.Tag = "2";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(321, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 120;
            this.label1.Text = "MOQ數量";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBrand_category
            // 
            this.lblBrand_category.ForeColor = System.Drawing.Color.Blue;
            this.lblBrand_category.Location = new System.Drawing.Point(8, 36);
            this.lblBrand_category.Name = "lblBrand_category";
            this.lblBrand_category.Size = new System.Drawing.Size(111, 13);
            this.lblBrand_category.TabIndex = 107;
            this.lblBrand_category.Text = "MOQ單位";
            this.lblBrand_category.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAmtim
            // 
            this.lblAmtim.Location = new System.Drawing.Point(322, 109);
            this.lblAmtim.Name = "lblAmtim";
            this.lblAmtim.Size = new System.Drawing.Size(54, 13);
            this.lblAmtim.TabIndex = 118;
            this.lblAmtim.Text = "修改日期";
            this.lblAmtim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lueBrand_id
            // 
            this.lueBrand_id.EditValue = "";
            this.lueBrand_id.Enabled = false;
            this.lueBrand_id.EnterMoveNextControl = true;
            this.lueBrand_id.Location = new System.Drawing.Point(122, 9);
            this.lueBrand_id.Name = "lueBrand_id";
            this.lueBrand_id.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.lueBrand_id.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.lueBrand_id.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueBrand_id.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lueBrand_id.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", 80, "id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cdesc", 150, "cdesc"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("type_desc", 70, "type_desc")});
            this.lueBrand_id.Properties.DropDownRows = 15;
            this.lueBrand_id.Properties.NullText = "";
            this.lueBrand_id.Properties.PopupFormMinSize = new System.Drawing.Size(200, 0);
            this.lueBrand_id.Properties.PopupWidth = 300;
            this.lueBrand_id.Properties.ShowHeader = false;
            this.lueBrand_id.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueBrand_id.Size = new System.Drawing.Size(172, 20);
            this.lueBrand_id.TabIndex = 105;
            this.lueBrand_id.Tag = "2";
            // 
            // lblAmusr
            // 
            this.lblAmusr.Location = new System.Drawing.Point(10, 109);
            this.lblAmusr.Name = "lblAmusr";
            this.lblAmusr.Size = new System.Drawing.Size(109, 13);
            this.lblAmusr.TabIndex = 117;
            this.lblAmusr.Text = "修改人";
            this.lblAmusr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblremark
            // 
            this.lblremark.Location = new System.Drawing.Point(10, 58);
            this.lblremark.Name = "lblremark";
            this.lblremark.Size = new System.Drawing.Size(109, 13);
            this.lblremark.TabIndex = 114;
            this.lblremark.Text = "備 注";
            this.lblremark.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCrtim
            // 
            this.lblCrtim.Location = new System.Drawing.Point(322, 83);
            this.lblCrtim.Name = "lblCrtim";
            this.lblCrtim.Size = new System.Drawing.Size(54, 13);
            this.lblCrtim.TabIndex = 116;
            this.lblCrtim.Text = "建檔日期";
            this.lblCrtim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRemark
            // 
            this.txtRemark.EnterMoveNextControl = true;
            this.txtRemark.Location = new System.Drawing.Point(122, 55);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtRemark.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtRemark.Properties.MaxLength = 255;
            this.txtRemark.Properties.ReadOnly = true;
            this.txtRemark.Size = new System.Drawing.Size(433, 20);
            this.txtRemark.TabIndex = 112;
            this.txtRemark.Tag = "2";
            // 
            // lblCrusr
            // 
            this.lblCrusr.Location = new System.Drawing.Point(10, 83);
            this.lblCrusr.Name = "lblCrusr";
            this.lblCrusr.Size = new System.Drawing.Size(109, 13);
            this.lblCrusr.TabIndex = 115;
            this.lblCrusr.Text = "建檔人";
            this.lblCrusr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCreate_by
            // 
            this.txtCreate_by.Enabled = false;
            this.txtCreate_by.Location = new System.Drawing.Point(122, 80);
            this.txtCreate_by.Name = "txtCreate_by";
            this.txtCreate_by.Properties.ReadOnly = true;
            this.txtCreate_by.Size = new System.Drawing.Size(172, 20);
            this.txtCreate_by.TabIndex = 109;
            this.txtCreate_by.Tag = "2";
            // 
            // txtUpdate_date
            // 
            this.txtUpdate_date.Enabled = false;
            this.txtUpdate_date.Location = new System.Drawing.Point(380, 106);
            this.txtUpdate_date.Name = "txtUpdate_date";
            this.txtUpdate_date.Properties.ReadOnly = true;
            this.txtUpdate_date.Size = new System.Drawing.Size(175, 20);
            this.txtUpdate_date.TabIndex = 113;
            this.txtUpdate_date.Tag = "2";
            // 
            // txtCreate_date
            // 
            this.txtCreate_date.Enabled = false;
            this.txtCreate_date.Location = new System.Drawing.Point(380, 80);
            this.txtCreate_date.Name = "txtCreate_date";
            this.txtCreate_date.Properties.ReadOnly = true;
            this.txtCreate_date.Size = new System.Drawing.Size(175, 20);
            this.txtCreate_date.TabIndex = 110;
            this.txtCreate_date.Tag = "2";
            // 
            // txtUpdate_by
            // 
            this.txtUpdate_by.Enabled = false;
            this.txtUpdate_by.Location = new System.Drawing.Point(122, 106);
            this.txtUpdate_by.Name = "txtUpdate_by";
            this.txtUpdate_by.Properties.ReadOnly = true;
            this.txtUpdate_by.Size = new System.Drawing.Size(172, 20);
            this.txtUpdate_by.TabIndex = 111;
            this.txtUpdate_by.Tag = "2";
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.brand_id,
            this.moq_unit,
            this.moq,
            this.remark,
            this.create_by,
            this.create_date,
            this.update_by,
            this.update_date});
            this.dgvDetails.Location = new System.Drawing.Point(2, 198);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(1050, 365);
            this.dgvDetails.TabIndex = 2;
            this.dgvDetails.SelectionChanged += new System.EventHandler(this.dgvDetails_SelectionChanged);
            // 
            // brand_id
            // 
            this.brand_id.DataPropertyName = "brand_id";
            this.brand_id.HeaderText = "牌子編號";
            this.brand_id.Name = "brand_id";
            this.brand_id.ReadOnly = true;
            this.brand_id.Width = 150;
            // 
            // moq_unit
            // 
            this.moq_unit.DataPropertyName = "moq_unit";
            this.moq_unit.HeaderText = "MOQ單位";
            this.moq_unit.Name = "moq_unit";
            this.moq_unit.ReadOnly = true;
            // 
            // moq
            // 
            this.moq.DataPropertyName = "moq";
            this.moq.HeaderText = "MOQ數量";
            this.moq.Name = "moq";
            this.moq.ReadOnly = true;
            // 
            // remark
            // 
            this.remark.DataPropertyName = "remark";
            this.remark.HeaderText = "備註";
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            this.remark.Width = 200;
            // 
            // create_by
            // 
            this.create_by.DataPropertyName = "create_by";
            this.create_by.HeaderText = "建檔人";
            this.create_by.Name = "create_by";
            this.create_by.ReadOnly = true;
            this.create_by.Visible = false;
            // 
            // create_date
            // 
            this.create_date.DataPropertyName = "create_date";
            this.create_date.HeaderText = "建檔日期";
            this.create_date.Name = "create_date";
            this.create_date.ReadOnly = true;
            this.create_date.Visible = false;
            // 
            // update_by
            // 
            this.update_by.DataPropertyName = "update_by";
            this.update_by.HeaderText = "修改人";
            this.update_by.Name = "update_by";
            this.update_by.ReadOnly = true;
            this.update_by.Visible = false;
            // 
            // update_date
            // 
            this.update_date.DataPropertyName = "update_date";
            this.update_date.HeaderText = "修改日期";
            this.update_date.Name = "update_date";
            this.update_date.ReadOnly = true;
            this.update_date.Visible = false;
            // 
            // frmQuotationMoq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1055, 566);
            this.Name = "frmQuotationMoq";
            this.Text = "frmQuotationMoq";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmQuotationMoq_FormClosed);
            this.Load += new System.EventHandler(this.frmQuotationMoq_Load);
            this.panel1.ResumeLayout(false);
            this.pnlHead.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlInput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtMoq.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMoq_unit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBrand_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_by.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpdate_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpdate_by.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHead;
        private System.Windows.Forms.Label lblSales_group;
        private DevExpress.XtraEditors.LookUpEdit lueBrand_id;
        private System.Windows.Forms.Label lblBrand_category;
        private DevExpress.XtraEditors.LookUpEdit lueMoq_unit;
        private System.Windows.Forms.Label lblAmtim;
        private System.Windows.Forms.Label lblAmusr;
        private System.Windows.Forms.Label lblCrtim;
        private System.Windows.Forms.Label lblCrusr;
        private DevExpress.XtraEditors.TextEdit txtUpdate_date;
        private DevExpress.XtraEditors.TextEdit txtUpdate_by;
        private DevExpress.XtraEditors.TextEdit txtCreate_date;
        private DevExpress.XtraEditors.TextEdit txtCreate_by;
        private DevExpress.XtraEditors.TextEdit txtRemark;
        private System.Windows.Forms.Label lblremark;
        private DevExpress.XtraEditors.TextEdit txtMoq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn brand_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn moq_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn moq;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn create_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn create_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn update_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn update_date;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.TextBox txtBrandEnd;
        private System.Windows.Forms.TextBox txtBrandBegin;
        private System.Windows.Forms.BindingSource bds1;
    }
}
