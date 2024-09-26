namespace cf01.Forms
{
    partial class frmQuotation_LabTest
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvLabTest = new System.Windows.Forms.DataGridView();
            this.txtInput = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsd_ex_fty = new DevExpress.XtraEditors.TextEdit();
            this.lblUsd_ex_fty = new System.Windows.Forms.Label();
            this.txtPriceFinish = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUnit = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQty_pcs = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRange_begin = new DevExpress.XtraEditors.TextEdit();
            this.txtRange_end = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtBrand_id = new DevExpress.XtraEditors.TextEdit();
            this.txtRate = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPriceFinish_hkd = new DevExpress.XtraEditors.TextEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brand_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.range_begin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.range_end = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost_lab_test = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price_add = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInput.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsd_ex_fty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPriceFinish.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty_pcs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRange_begin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRange_end.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrand_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPriceFinish_hkd.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLabTest
            // 
            this.dgvLabTest.AllowUserToAddRows = false;
            this.dgvLabTest.AllowUserToDeleteRows = false;
            this.dgvLabTest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLabTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLabTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prod_id,
            this.brand_id,
            this.range_begin,
            this.range_end,
            this.cost_lab_test,
            this.price_add,
            this.unit_code,
            this.remark});
            this.dgvLabTest.Location = new System.Drawing.Point(3, 256);
            this.dgvLabTest.Name = "dgvLabTest";
            this.dgvLabTest.ReadOnly = true;
            this.dgvLabTest.RowTemplate.Height = 24;
            this.dgvLabTest.Size = new System.Drawing.Size(957, 358);
            this.dgvLabTest.TabIndex = 0;
            // 
            // txtInput
            // 
            this.txtInput.EditValue = "";
            this.txtInput.EnterMoveNextControl = true;
            this.txtInput.Location = new System.Drawing.Point(171, 46);
            this.txtInput.Name = "txtInput";
            this.txtInput.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Properties.Appearance.Options.UseFont = true;
            this.txtInput.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtInput.Properties.Mask.EditMask = "n0";
            this.txtInput.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtInput.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtInput.Size = new System.Drawing.Size(195, 34);
            this.txtInput.TabIndex = 1;
            this.txtInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInput_KeyPress);
            this.txtInput.Leave += new System.EventHandler(this.txtInput_Leave);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label1.Location = new System.Drawing.Point(1, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "請輸入數量範圍：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUsd_ex_fty
            // 
            this.txtUsd_ex_fty.EditValue = "";
            this.txtUsd_ex_fty.EnterMoveNextControl = true;
            this.txtUsd_ex_fty.Location = new System.Drawing.Point(171, 85);
            this.txtUsd_ex_fty.Name = "txtUsd_ex_fty";
            this.txtUsd_ex_fty.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.txtUsd_ex_fty.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.txtUsd_ex_fty.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUsd_ex_fty.Properties.Appearance.Options.UseBackColor = true;
            this.txtUsd_ex_fty.Properties.Appearance.Options.UseFont = true;
            this.txtUsd_ex_fty.Properties.Appearance.Options.UseForeColor = true;
            this.txtUsd_ex_fty.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtUsd_ex_fty.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtUsd_ex_fty.Properties.Mask.EditMask = "n3";
            this.txtUsd_ex_fty.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtUsd_ex_fty.Properties.ReadOnly = true;
            this.txtUsd_ex_fty.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUsd_ex_fty.Size = new System.Drawing.Size(280, 34);
            this.txtUsd_ex_fty.TabIndex = 178;
            // 
            // lblUsd_ex_fty
            // 
            this.lblUsd_ex_fty.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblUsd_ex_fty.Location = new System.Drawing.Point(23, 87);
            this.lblUsd_ex_fty.Name = "lblUsd_ex_fty";
            this.lblUsd_ex_fty.Size = new System.Drawing.Size(140, 26);
            this.lblUsd_ex_fty.TabIndex = 179;
            this.lblUsd_ex_fty.Text = "USD EX-FTY：";
            this.lblUsd_ex_fty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPriceFinish
            // 
            this.txtPriceFinish.EditValue = "";
            this.txtPriceFinish.EnterMoveNextControl = true;
            this.txtPriceFinish.Location = new System.Drawing.Point(6, 11);
            this.txtPriceFinish.Name = "txtPriceFinish";
            this.txtPriceFinish.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.txtPriceFinish.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.txtPriceFinish.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.txtPriceFinish.Properties.Appearance.Options.UseBackColor = true;
            this.txtPriceFinish.Properties.Appearance.Options.UseFont = true;
            this.txtPriceFinish.Properties.Appearance.Options.UseForeColor = true;
            this.txtPriceFinish.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtPriceFinish.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPriceFinish.Properties.Mask.EditMask = "n3";
            this.txtPriceFinish.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPriceFinish.Properties.ReadOnly = true;
            this.txtPriceFinish.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPriceFinish.Size = new System.Drawing.Size(280, 34);
            this.txtPriceFinish.TabIndex = 180;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label2.Location = new System.Drawing.Point(23, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 26);
            this.label2.TabIndex = 181;
            this.label2.Text = "計算之後的單價：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(339, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(433, 26);
            this.label3.TabIndex = 182;
            this.label3.Text = "**公式：最終單價 = USD EX-FTY  + [ 測試費/範圍(開始)] + 單價應增加";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUnit
            // 
            this.txtUnit.EditValue = "";
            this.txtUnit.EnterMoveNextControl = true;
            this.txtUnit.Location = new System.Drawing.Point(368, 46);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.txtUnit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.txtUnit.Properties.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.txtUnit.Properties.Appearance.Options.UseBackColor = true;
            this.txtUnit.Properties.Appearance.Options.UseFont = true;
            this.txtUnit.Properties.Appearance.Options.UseForeColor = true;
            this.txtUnit.Properties.Appearance.Options.UseTextOptions = true;
            this.txtUnit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtUnit.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtUnit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtUnit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtUnit.Properties.ReadOnly = true;
            this.txtUnit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUnit.Size = new System.Drawing.Size(83, 34);
            this.txtUnit.TabIndex = 183;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label4.Location = new System.Drawing.Point(457, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 25);
            this.label4.TabIndex = 184;
            this.label4.Text = "=";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtQty_pcs
            // 
            this.txtQty_pcs.EditValue = "";
            this.txtQty_pcs.EnterMoveNextControl = true;
            this.txtQty_pcs.Location = new System.Drawing.Point(491, 46);
            this.txtQty_pcs.Name = "txtQty_pcs";
            this.txtQty_pcs.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.txtQty_pcs.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.txtQty_pcs.Properties.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.txtQty_pcs.Properties.Appearance.Options.UseBackColor = true;
            this.txtQty_pcs.Properties.Appearance.Options.UseFont = true;
            this.txtQty_pcs.Properties.Appearance.Options.UseForeColor = true;
            this.txtQty_pcs.Properties.Appearance.Options.UseTextOptions = true;
            this.txtQty_pcs.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtQty_pcs.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtQty_pcs.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQty_pcs.Properties.Mask.EditMask = "n3";
            this.txtQty_pcs.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtQty_pcs.Properties.ReadOnly = true;
            this.txtQty_pcs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtQty_pcs.Size = new System.Drawing.Size(120, 34);
            this.txtQty_pcs.TabIndex = 185;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label5.Location = new System.Drawing.Point(625, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 25);
            this.label5.TabIndex = 186;
            this.label5.Text = "PCS";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRange_begin
            // 
            this.txtRange_begin.EditValue = "";
            this.txtRange_begin.EnterMoveNextControl = true;
            this.txtRange_begin.Location = new System.Drawing.Point(171, 223);
            this.txtRange_begin.Name = "txtRange_begin";
            this.txtRange_begin.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.txtRange_begin.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRange_begin.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtRange_begin.Properties.Appearance.Options.UseBackColor = true;
            this.txtRange_begin.Properties.Appearance.Options.UseFont = true;
            this.txtRange_begin.Properties.Appearance.Options.UseForeColor = true;
            this.txtRange_begin.Properties.Appearance.Options.UseTextOptions = true;
            this.txtRange_begin.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtRange_begin.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtRange_begin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtRange_begin.Properties.Mask.EditMask = "n3";
            this.txtRange_begin.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtRange_begin.Properties.ReadOnly = true;
            this.txtRange_begin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRange_begin.Size = new System.Drawing.Size(115, 26);
            this.txtRange_begin.TabIndex = 187;
            // 
            // txtRange_end
            // 
            this.txtRange_end.EditValue = "";
            this.txtRange_end.EnterMoveNextControl = true;
            this.txtRange_end.Location = new System.Drawing.Point(333, 223);
            this.txtRange_end.Name = "txtRange_end";
            this.txtRange_end.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.txtRange_end.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRange_end.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtRange_end.Properties.Appearance.Options.UseBackColor = true;
            this.txtRange_end.Properties.Appearance.Options.UseFont = true;
            this.txtRange_end.Properties.Appearance.Options.UseForeColor = true;
            this.txtRange_end.Properties.Appearance.Options.UseTextOptions = true;
            this.txtRange_end.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txtRange_end.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtRange_end.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtRange_end.Properties.Mask.EditMask = "n3";
            this.txtRange_end.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtRange_end.Properties.ReadOnly = true;
            this.txtRange_end.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRange_end.Size = new System.Drawing.Size(118, 26);
            this.txtRange_end.TabIndex = 188;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 17);
            this.label6.TabIndex = 189;
            this.label6.Text = "輸入數量所屬范圍：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(295, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 17);
            this.label7.TabIndex = 190;
            this.label7.Text = "~";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(838, 35);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(73, 39);
            this.btnExit.TabIndex = 191;
            this.btnExit.Text = "退 出(&X)";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtBrand_id
            // 
            this.txtBrand_id.EditValue = "";
            this.txtBrand_id.EnterMoveNextControl = true;
            this.txtBrand_id.Location = new System.Drawing.Point(171, 6);
            this.txtBrand_id.Name = "txtBrand_id";
            this.txtBrand_id.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.txtBrand_id.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.txtBrand_id.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBrand_id.Properties.Appearance.Options.UseBackColor = true;
            this.txtBrand_id.Properties.Appearance.Options.UseFont = true;
            this.txtBrand_id.Properties.Appearance.Options.UseForeColor = true;
            this.txtBrand_id.Properties.Appearance.Options.UseTextOptions = true;
            this.txtBrand_id.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtBrand_id.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtBrand_id.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBrand_id.Properties.ReadOnly = true;
            this.txtBrand_id.Size = new System.Drawing.Size(280, 34);
            this.txtBrand_id.TabIndex = 192;
            // 
            // txtRate
            // 
            this.txtRate.EditValue = "";
            this.txtRate.EnterMoveNextControl = true;
            this.txtRate.Location = new System.Drawing.Point(39, 51);
            this.txtRate.Name = "txtRate";
            this.txtRate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.txtRate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.txtRate.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtRate.Properties.Appearance.Options.UseBackColor = true;
            this.txtRate.Properties.Appearance.Options.UseFont = true;
            this.txtRate.Properties.Appearance.Options.UseForeColor = true;
            this.txtRate.Properties.Appearance.Options.UseTextOptions = true;
            this.txtRate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtRate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtRate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtRate.Properties.Mask.EditMask = "n3";
            this.txtRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtRate.Properties.ReadOnly = true;
            this.txtRate.Size = new System.Drawing.Size(80, 34);
            this.txtRate.TabIndex = 193;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label8.Location = new System.Drawing.Point(4, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 25);
            this.label8.TabIndex = 194;
            this.label8.Text = "牌 子：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPriceFinish_hkd
            // 
            this.txtPriceFinish_hkd.EditValue = "";
            this.txtPriceFinish_hkd.EnterMoveNextControl = true;
            this.txtPriceFinish_hkd.Location = new System.Drawing.Point(168, 51);
            this.txtPriceFinish_hkd.Name = "txtPriceFinish_hkd";
            this.txtPriceFinish_hkd.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.txtPriceFinish_hkd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.txtPriceFinish_hkd.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.txtPriceFinish_hkd.Properties.Appearance.Options.UseBackColor = true;
            this.txtPriceFinish_hkd.Properties.Appearance.Options.UseFont = true;
            this.txtPriceFinish_hkd.Properties.Appearance.Options.UseForeColor = true;
            this.txtPriceFinish_hkd.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtPriceFinish_hkd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPriceFinish_hkd.Properties.Mask.EditMask = "n3";
            this.txtPriceFinish_hkd.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPriceFinish_hkd.Properties.ReadOnly = true;
            this.txtPriceFinish_hkd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPriceFinish_hkd.Size = new System.Drawing.Size(118, 34);
            this.txtPriceFinish_hkd.TabIndex = 195;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label9.Location = new System.Drawing.Point(292, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 21);
            this.label9.TabIndex = 196;
            this.label9.Text = "USD";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label10.Location = new System.Drawing.Point(292, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 21);
            this.label10.TabIndex = 197;
            this.label10.Text = "HKD";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtPriceFinish);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtRate);
            this.groupBox1.Controls.Add(this.txtPriceFinish_hkd);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(165, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(795, 93);
            this.groupBox1.TabIndex = 198;
            this.groupBox1.TabStop = false;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label11.Location = new System.Drawing.Point(125, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 25);
            this.label11.TabIndex = 198;
            this.label11.Text = "=";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label12.Location = new System.Drawing.Point(7, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 25);
            this.label12.TabIndex = 199;
            this.label12.Text = "X";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "LabTest 產品大類";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "brand_id";
            this.dataGridViewTextBoxColumn2.HeaderText = "牌子編號";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 90;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "range_begin";
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn3.HeaderText = "範圍(開始)";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "range_end";
            dataGridViewCellStyle6.Format = "N1";
            dataGridViewCellStyle6.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn4.HeaderText = "範圍(結束)";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "cost_lab_test";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn5.HeaderText = "測試費";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 90;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "price_add";
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle8.Format = "N1";
            dataGridViewCellStyle8.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn6.HeaderText = "單價增加";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 90;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "unit_code";
            this.dataGridViewTextBoxColumn7.HeaderText = "單位(數量範圍)";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Width = 120;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "remark";
            this.dataGridViewTextBoxColumn8.HeaderText = "備註";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn8.Width = 240;
            // 
            // prod_id
            // 
            this.prod_id.DataPropertyName = "prod_id";
            this.prod_id.HeaderText = "LabTest 產品大類";
            this.prod_id.Name = "prod_id";
            this.prod_id.ReadOnly = true;
            this.prod_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.prod_id.Width = 80;
            // 
            // brand_id
            // 
            this.brand_id.DataPropertyName = "brand_id";
            this.brand_id.HeaderText = "牌子編號";
            this.brand_id.Name = "brand_id";
            this.brand_id.ReadOnly = true;
            this.brand_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.brand_id.Width = 90;
            // 
            // range_begin
            // 
            this.range_begin.DataPropertyName = "range_begin";
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.range_begin.DefaultCellStyle = dataGridViewCellStyle1;
            this.range_begin.HeaderText = "範圍(開始)";
            this.range_begin.Name = "range_begin";
            this.range_begin.ReadOnly = true;
            this.range_begin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // range_end
            // 
            this.range_end.DataPropertyName = "range_end";
            dataGridViewCellStyle2.Format = "N1";
            dataGridViewCellStyle2.NullValue = null;
            this.range_end.DefaultCellStyle = dataGridViewCellStyle2;
            this.range_end.HeaderText = "範圍(結束)";
            this.range_end.Name = "range_end";
            this.range_end.ReadOnly = true;
            this.range_end.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cost_lab_test
            // 
            this.cost_lab_test.DataPropertyName = "cost_lab_test";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.cost_lab_test.DefaultCellStyle = dataGridViewCellStyle3;
            this.cost_lab_test.HeaderText = "測試費";
            this.cost_lab_test.Name = "cost_lab_test";
            this.cost_lab_test.ReadOnly = true;
            this.cost_lab_test.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cost_lab_test.Width = 90;
            // 
            // price_add
            // 
            this.price_add.DataPropertyName = "price_add";
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle4.Format = "N1";
            dataGridViewCellStyle4.NullValue = null;
            this.price_add.DefaultCellStyle = dataGridViewCellStyle4;
            this.price_add.HeaderText = "單價增加";
            this.price_add.Name = "price_add";
            this.price_add.ReadOnly = true;
            this.price_add.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.price_add.Width = 90;
            // 
            // unit_code
            // 
            this.unit_code.DataPropertyName = "unit_code";
            this.unit_code.HeaderText = "單位(數量範圍)";
            this.unit_code.Name = "unit_code";
            this.unit_code.ReadOnly = true;
            this.unit_code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.unit_code.Width = 120;
            // 
            // remark
            // 
            this.remark.DataPropertyName = "remark";
            this.remark.HeaderText = "備註";
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            this.remark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.remark.Width = 240;
            // 
            // frmQuotation_LabTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 619);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBrand_id);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRange_end);
            this.Controls.Add(this.txtRange_begin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtQty_pcs);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsd_ex_fty);
            this.Controls.Add(this.lblUsd_ex_fty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.dgvLabTest);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuotation_LabTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmQoutation_LabTest";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmQuotation_LabTest_FormClosed);
            this.Load += new System.EventHandler(this.frmQuotation_LabTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInput.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsd_ex_fty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPriceFinish.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty_pcs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRange_begin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRange_end.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrand_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPriceFinish_hkd.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLabTest;
        private DevExpress.XtraEditors.TextEdit txtInput;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtUsd_ex_fty;
        private System.Windows.Forms.Label lblUsd_ex_fty;
        private DevExpress.XtraEditors.TextEdit txtPriceFinish;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn brand_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn range_begin;
        private System.Windows.Forms.DataGridViewTextBoxColumn range_end;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost_lab_test;
        private System.Windows.Forms.DataGridViewTextBoxColumn price_add;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private DevExpress.XtraEditors.TextEdit txtUnit;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtQty_pcs;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtRange_begin;
        private DevExpress.XtraEditors.TextEdit txtRange_end;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnExit;
        private DevExpress.XtraEditors.TextEdit txtBrand_id;
        private DevExpress.XtraEditors.TextEdit txtRate;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.TextEdit txtPriceFinish_hkd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
    }
}