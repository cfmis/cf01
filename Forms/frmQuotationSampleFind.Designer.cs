namespace cf01.Forms
{
    partial class frmQuotationSampleFind
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuotationSampleFind));
            this.dtInput_date1 = new DevExpress.XtraEditors.DateEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSeason = new DevExpress.XtraEditors.TextEdit();
            this.lblCust_code = new System.Windows.Forms.Label();
            this.txtCf_color_code = new DevExpress.XtraEditors.TextEdit();
            this.txtMo_id = new DevExpress.XtraEditors.TextEdit();
            this.txtMacys_color_code = new DevExpress.XtraEditors.TextEdit();
            this.txtPlm_code = new DevExpress.XtraEditors.TextEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCf_code = new DevExpress.XtraEditors.TextEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.txtSize = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaterial = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.dtInput_date2 = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCreate_by = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtCreate_date2 = new DevExpress.XtraEditors.DateEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.dtCreate_date1 = new DevExpress.XtraEditors.DateEdit();
            this.BTNSAVESET1 = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSearchByParam = new System.Windows.Forms.Button();
            this.pnlFindData = new System.Windows.Forms.Panel();
            this.chkFlag_ck = new DevExpress.XtraEditors.CheckEdit();
            this.txtBrand_desc = new DevExpress.XtraEditors.TextEdit();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtInput_date1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInput_date1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeason.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCf_color_code.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMacys_color_code.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlm_code.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCf_code.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaterial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInput_date2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInput_date2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_by.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreate_date2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreate_date2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreate_date1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreate_date1.Properties)).BeginInit();
            this.pnlFindData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkFlag_ck.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrand_desc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dtInput_date1
            // 
            this.dtInput_date1.EditValue = "";
            this.dtInput_date1.EnterMoveNextControl = true;
            this.dtInput_date1.Location = new System.Drawing.Point(129, 5);
            this.dtInput_date1.Name = "dtInput_date1";
            this.dtInput_date1.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.dtInput_date1.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.dtInput_date1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtInput_date1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtInput_date1.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dtInput_date1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtInput_date1.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dtInput_date1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtInput_date1.Properties.Mask.BeepOnError = true;
            this.dtInput_date1.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dtInput_date1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtInput_date1.Properties.MaxLength = 10;
            this.dtInput_date1.Size = new System.Drawing.Size(132, 20);
            this.dtInput_date1.TabIndex = 1;
            this.dtInput_date1.Tag = "";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(5, 153);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 14);
            this.label12.TabIndex = 191;
            this.label12.Text = "Macys Color Code";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSeason
            // 
            this.txtSeason.EditValue = "";
            this.txtSeason.EnterMoveNextControl = true;
            this.txtSeason.Location = new System.Drawing.Point(129, 28);
            this.txtSeason.Name = "txtSeason";
            this.txtSeason.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSeason.Properties.MaxLength = 20;
            this.txtSeason.Size = new System.Drawing.Size(291, 20);
            this.txtSeason.TabIndex = 178;
            this.txtSeason.Tag = "";
            // 
            // lblCust_code
            // 
            this.lblCust_code.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblCust_code.Location = new System.Drawing.Point(54, 29);
            this.lblCust_code.Name = "lblCust_code";
            this.lblCust_code.Size = new System.Drawing.Size(73, 15);
            this.lblCust_code.TabIndex = 186;
            this.lblCust_code.Text = "Season";
            this.lblCust_code.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCf_color_code
            // 
            this.txtCf_color_code.EditValue = "";
            this.txtCf_color_code.EnterMoveNextControl = true;
            this.txtCf_color_code.Location = new System.Drawing.Point(539, 28);
            this.txtCf_color_code.Name = "txtCf_color_code";
            this.txtCf_color_code.Properties.MaxLength = 50;
            this.txtCf_color_code.Size = new System.Drawing.Size(317, 20);
            this.txtCf_color_code.TabIndex = 185;
            this.txtCf_color_code.Tag = "";
            // 
            // txtMo_id
            // 
            this.txtMo_id.EditValue = "";
            this.txtMo_id.EnterMoveNextControl = true;
            this.txtMo_id.Location = new System.Drawing.Point(539, 5);
            this.txtMo_id.Name = "txtMo_id";
            this.txtMo_id.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo_id.Properties.MaxLength = 20;
            this.txtMo_id.Size = new System.Drawing.Size(317, 20);
            this.txtMo_id.TabIndex = 184;
            this.txtMo_id.Tag = "";
            // 
            // txtMacys_color_code
            // 
            this.txtMacys_color_code.EditValue = "";
            this.txtMacys_color_code.EnterMoveNextControl = true;
            this.txtMacys_color_code.Location = new System.Drawing.Point(129, 151);
            this.txtMacys_color_code.Name = "txtMacys_color_code";
            this.txtMacys_color_code.Properties.MaxLength = 50;
            this.txtMacys_color_code.Size = new System.Drawing.Size(291, 20);
            this.txtMacys_color_code.TabIndex = 183;
            this.txtMacys_color_code.Tag = "";
            // 
            // txtPlm_code
            // 
            this.txtPlm_code.EditValue = "";
            this.txtPlm_code.EnterMoveNextControl = true;
            this.txtPlm_code.Location = new System.Drawing.Point(129, 52);
            this.txtPlm_code.Name = "txtPlm_code";
            this.txtPlm_code.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPlm_code.Properties.MaxLength = 25;
            this.txtPlm_code.Size = new System.Drawing.Size(291, 20);
            this.txtPlm_code.TabIndex = 179;
            this.txtPlm_code.Tag = "";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label9.Location = new System.Drawing.Point(429, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 15);
            this.label9.TabIndex = 193;
            this.label9.Text = "CF Color Code";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label3.Location = new System.Drawing.Point(54, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 15);
            this.label3.TabIndex = 187;
            this.label3.Text = "PLM Code";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCf_code
            // 
            this.txtCf_code.EditValue = "";
            this.txtCf_code.EnterMoveNextControl = true;
            this.txtCf_code.Location = new System.Drawing.Point(129, 75);
            this.txtCf_code.Name = "txtCf_code";
            this.txtCf_code.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCf_code.Properties.MaxLength = 50;
            this.txtCf_code.Size = new System.Drawing.Size(291, 20);
            this.txtCf_code.TabIndex = 180;
            this.txtCf_code.Tag = "";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label13.Location = new System.Drawing.Point(429, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 15);
            this.label13.TabIndex = 192;
            this.label13.Text = "MO#";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label4.Location = new System.Drawing.Point(54, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 188;
            this.label4.Text = "CF Code";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSize
            // 
            this.lblSize.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblSize.Location = new System.Drawing.Point(54, 127);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(73, 15);
            this.lblSize.TabIndex = 190;
            this.lblSize.Text = "Size";
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSize
            // 
            this.txtSize.EditValue = "";
            this.txtSize.EnterMoveNextControl = true;
            this.txtSize.Location = new System.Drawing.Point(129, 125);
            this.txtSize.Name = "txtSize";
            this.txtSize.Properties.MaxLength = 50;
            this.txtSize.Size = new System.Drawing.Size(291, 20);
            this.txtSize.TabIndex = 182;
            this.txtSize.Tag = "";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label6.Location = new System.Drawing.Point(54, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 15);
            this.label6.TabIndex = 189;
            this.label6.Text = "Material";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMaterial
            // 
            this.txtMaterial.EditValue = "";
            this.txtMaterial.EnterMoveNextControl = true;
            this.txtMaterial.Location = new System.Drawing.Point(129, 99);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Properties.MaxLength = 50;
            this.txtMaterial.Size = new System.Drawing.Size(291, 20);
            this.txtMaterial.TabIndex = 181;
            this.txtMaterial.Tag = "";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label1.Location = new System.Drawing.Point(54, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 194;
            this.label1.Text = "Data";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtInput_date2
            // 
            this.dtInput_date2.EditValue = "";
            this.dtInput_date2.EnterMoveNextControl = true;
            this.dtInput_date2.Location = new System.Drawing.Point(288, 5);
            this.dtInput_date2.Name = "dtInput_date2";
            this.dtInput_date2.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.dtInput_date2.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.dtInput_date2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtInput_date2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtInput_date2.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dtInput_date2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtInput_date2.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dtInput_date2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtInput_date2.Properties.Mask.BeepOnError = true;
            this.dtInput_date2.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dtInput_date2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtInput_date2.Properties.MaxLength = 10;
            this.dtInput_date2.Size = new System.Drawing.Size(132, 20);
            this.dtInput_date2.TabIndex = 195;
            this.dtInput_date2.Tag = "";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label2.Location = new System.Drawing.Point(265, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 15);
            this.label2.TabIndex = 196;
            this.label2.Text = "~";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCreate_by
            // 
            this.txtCreate_by.EditValue = "";
            this.txtCreate_by.EnterMoveNextControl = true;
            this.txtCreate_by.Location = new System.Drawing.Point(539, 75);
            this.txtCreate_by.Name = "txtCreate_by";
            this.txtCreate_by.Properties.MaxLength = 50;
            this.txtCreate_by.Size = new System.Drawing.Size(317, 20);
            this.txtCreate_by.TabIndex = 197;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label5.Location = new System.Drawing.Point(429, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 15);
            this.label5.TabIndex = 198;
            this.label5.Text = "Create By";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label7.Location = new System.Drawing.Point(689, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 15);
            this.label7.TabIndex = 202;
            this.label7.Text = "~";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtCreate_date2
            // 
            this.dtCreate_date2.EditValue = "";
            this.dtCreate_date2.EnterMoveNextControl = true;
            this.dtCreate_date2.Location = new System.Drawing.Point(712, 99);
            this.dtCreate_date2.Name = "dtCreate_date2";
            this.dtCreate_date2.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.dtCreate_date2.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.dtCreate_date2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtCreate_date2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtCreate_date2.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dtCreate_date2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtCreate_date2.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dtCreate_date2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtCreate_date2.Properties.Mask.BeepOnError = true;
            this.dtCreate_date2.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dtCreate_date2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtCreate_date2.Properties.MaxLength = 10;
            this.dtCreate_date2.Size = new System.Drawing.Size(145, 20);
            this.dtCreate_date2.TabIndex = 201;
            this.dtCreate_date2.Tag = "";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label8.Location = new System.Drawing.Point(464, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 15);
            this.label8.TabIndex = 200;
            this.label8.Text = "Create Data";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtCreate_date1
            // 
            this.dtCreate_date1.EditValue = "";
            this.dtCreate_date1.EnterMoveNextControl = true;
            this.dtCreate_date1.Location = new System.Drawing.Point(539, 99);
            this.dtCreate_date1.Name = "dtCreate_date1";
            this.dtCreate_date1.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.dtCreate_date1.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.dtCreate_date1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtCreate_date1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtCreate_date1.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dtCreate_date1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtCreate_date1.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.dtCreate_date1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtCreate_date1.Properties.Mask.BeepOnError = true;
            this.dtCreate_date1.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dtCreate_date1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtCreate_date1.Properties.MaxLength = 10;
            this.dtCreate_date1.Size = new System.Drawing.Size(142, 20);
            this.dtCreate_date1.TabIndex = 199;
            this.dtCreate_date1.Tag = "";
            // 
            // BTNSAVESET1
            // 
            this.BTNSAVESET1.Image = ((System.Drawing.Image)(resources.GetObject("BTNSAVESET1.Image")));
            this.BTNSAVESET1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BTNSAVESET1.Location = new System.Drawing.Point(757, 154);
            this.BTNSAVESET1.Name = "BTNSAVESET1";
            this.BTNSAVESET1.Size = new System.Drawing.Size(87, 43);
            this.BTNSAVESET1.TabIndex = 206;
            this.BTNSAVESET1.Text = "保存查找條件";
            this.BTNSAVESET1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTNSAVESET1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTNSAVESET1.UseVisualStyleBackColor = false;
            this.BTNSAVESET1.Click += new System.EventHandler(this.BTNSAVESET1_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClear.Location = new System.Drawing.Point(629, 154);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(116, 43);
            this.btnClear.TabIndex = 205;
            this.btnClear.Text = "清除查找條件";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::cf01.Properties.Resources.exit;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.Location = new System.Drawing.Point(446, 154);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 43);
            this.btnClose.TabIndex = 204;
            this.btnClose.Text = "退 出";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearchByParam
            // 
            this.btnSearchByParam.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSearchByParam.Image = global::cf01.Properties.Resources.find;
            this.btnSearchByParam.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSearchByParam.Location = new System.Drawing.Point(538, 154);
            this.btnSearchByParam.Name = "btnSearchByParam";
            this.btnSearchByParam.Size = new System.Drawing.Size(83, 43);
            this.btnSearchByParam.TabIndex = 203;
            this.btnSearchByParam.Text = "查詢";
            this.btnSearchByParam.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearchByParam.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSearchByParam.UseVisualStyleBackColor = false;
            this.btnSearchByParam.Click += new System.EventHandler(this.btnSearchByParam_Click);
            // 
            // pnlFindData
            // 
            this.pnlFindData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlFindData.Controls.Add(this.txtBrand_desc);
            this.pnlFindData.Controls.Add(this.label10);
            this.pnlFindData.Controls.Add(this.chkFlag_ck);
            this.pnlFindData.Controls.Add(this.label13);
            this.pnlFindData.Controls.Add(this.BTNSAVESET1);
            this.pnlFindData.Controls.Add(this.dtInput_date1);
            this.pnlFindData.Controls.Add(this.btnClear);
            this.pnlFindData.Controls.Add(this.txtMaterial);
            this.pnlFindData.Controls.Add(this.btnClose);
            this.pnlFindData.Controls.Add(this.label6);
            this.pnlFindData.Controls.Add(this.btnSearchByParam);
            this.pnlFindData.Controls.Add(this.txtSize);
            this.pnlFindData.Controls.Add(this.label7);
            this.pnlFindData.Controls.Add(this.lblSize);
            this.pnlFindData.Controls.Add(this.dtCreate_date2);
            this.pnlFindData.Controls.Add(this.label4);
            this.pnlFindData.Controls.Add(this.label8);
            this.pnlFindData.Controls.Add(this.txtCf_code);
            this.pnlFindData.Controls.Add(this.dtCreate_date1);
            this.pnlFindData.Controls.Add(this.label3);
            this.pnlFindData.Controls.Add(this.txtCreate_by);
            this.pnlFindData.Controls.Add(this.label9);
            this.pnlFindData.Controls.Add(this.label5);
            this.pnlFindData.Controls.Add(this.txtPlm_code);
            this.pnlFindData.Controls.Add(this.label2);
            this.pnlFindData.Controls.Add(this.txtMacys_color_code);
            this.pnlFindData.Controls.Add(this.dtInput_date2);
            this.pnlFindData.Controls.Add(this.txtMo_id);
            this.pnlFindData.Controls.Add(this.label1);
            this.pnlFindData.Controls.Add(this.txtCf_color_code);
            this.pnlFindData.Controls.Add(this.label12);
            this.pnlFindData.Controls.Add(this.lblCust_code);
            this.pnlFindData.Controls.Add(this.txtSeason);
            this.pnlFindData.Location = new System.Drawing.Point(3, 4);
            this.pnlFindData.Name = "pnlFindData";
            this.pnlFindData.Size = new System.Drawing.Size(902, 204);
            this.pnlFindData.TabIndex = 207;
            // 
            // chkFlag_ck
            // 
            this.chkFlag_ck.Location = new System.Drawing.Point(774, 126);
            this.chkFlag_ck.Name = "chkFlag_ck";
            this.chkFlag_ck.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFlag_ck.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.chkFlag_ck.Properties.Appearance.Options.UseFont = true;
            this.chkFlag_ck.Properties.Appearance.Options.UseForeColor = true;
            this.chkFlag_ck.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.chkFlag_ck.Properties.Caption = "  C K";
            this.chkFlag_ck.Size = new System.Drawing.Size(83, 21);
            this.chkFlag_ck.TabIndex = 216;
            this.chkFlag_ck.Tag = "";
            // 
            // txtBrand_desc
            // 
            this.txtBrand_desc.EditValue = "";
            this.txtBrand_desc.EnterMoveNextControl = true;
            this.txtBrand_desc.Location = new System.Drawing.Point(539, 52);
            this.txtBrand_desc.Name = "txtBrand_desc";
            this.txtBrand_desc.Properties.MaxLength = 50;
            this.txtBrand_desc.Size = new System.Drawing.Size(317, 20);
            this.txtBrand_desc.TabIndex = 217;
            this.txtBrand_desc.Tag = "";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label10.Location = new System.Drawing.Point(464, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 15);
            this.label10.TabIndex = 218;
            this.label10.Text = "Brand Desc";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmQuotationSampleFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 220);
            this.Controls.Add(this.pnlFindData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuotationSampleFind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find Data";
            this.Load += new System.EventHandler(this.frmQuotationSampleFind_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtInput_date1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInput_date1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeason.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCf_color_code.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMacys_color_code.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlm_code.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCf_code.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaterial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInput_date2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInput_date2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_by.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreate_date2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreate_date2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreate_date1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreate_date1.Properties)).EndInit();
            this.pnlFindData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkFlag_ck.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrand_desc.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dtInput_date1;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.TextEdit txtSeason;
        private System.Windows.Forms.Label lblCust_code;
        private DevExpress.XtraEditors.TextEdit txtCf_color_code;
        private DevExpress.XtraEditors.TextEdit txtMo_id;
        private DevExpress.XtraEditors.TextEdit txtMacys_color_code;
        private DevExpress.XtraEditors.TextEdit txtPlm_code;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtCf_code;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSize;
        private DevExpress.XtraEditors.TextEdit txtSize;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtMaterial;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit dtInput_date2;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtCreate_by;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.DateEdit dtCreate_date2;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.DateEdit dtCreate_date1;
        private System.Windows.Forms.Button BTNSAVESET1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSearchByParam;
        private System.Windows.Forms.Panel pnlFindData;
        private DevExpress.XtraEditors.CheckEdit chkFlag_ck;
        private DevExpress.XtraEditors.TextEdit txtBrand_desc;
        private System.Windows.Forms.Label label10;
    }
}