namespace cf01.ReportForm
{
    partial class frmZipperOrder_PrintCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmZipperOrder_PrintCard));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblMo_id = new System.Windows.Forms.Label();
            this.txtMo_id = new System.Windows.Forms.TextBox();
            this.lblPrd_code = new System.Windows.Forms.Label();
            this.txtPrd_code = new System.Windows.Forms.TextBox();
            this.lblSpec = new System.Windows.Forms.Label();
            this.txtSpec = new System.Windows.Forms.TextBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblPrint_mo = new System.Windows.Forms.Label();
            this.txtPrint_mo = new System.Windows.Forms.TextBox();
            this.lblPer_pack = new System.Windows.Forms.Label();
            this.luePack_type = new DevExpress.XtraEditors.LookUpEdit();
            this.lblPack = new DevExpress.XtraEditors.LabelControl();
            this.lueGoods_unit = new DevExpress.XtraEditors.LookUpEdit();
            this.lblGoods_unit = new DevExpress.XtraEditors.LabelControl();
            this.txtQty = new DevExpress.XtraEditors.TextEdit();
            this.txtPer_pack = new DevExpress.XtraEditors.TextEdit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luePack_type.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoods_unit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPer_pack.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClose,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripSeparator3,
            this.btnPrint,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(943, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = false;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(65, 35);
            this.btnClose.Text = "退出(&X)";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(65, 35);
            this.toolStripButton1.Text = "預覽(&V)";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // btnPrint
            // 
            this.btnPrint.AutoSize = false;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(65, 35);
            this.btnPrint.Text = "列印(&P)";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // lblMo_id
            // 
            this.lblMo_id.AutoSize = true;
            this.lblMo_id.Location = new System.Drawing.Point(60, 63);
            this.lblMo_id.Name = "lblMo_id";
            this.lblMo_id.Size = new System.Drawing.Size(56, 12);
            this.lblMo_id.TabIndex = 1;
            this.lblMo_id.Text = "制單編號:";
            // 
            // txtMo_id
            // 
            this.txtMo_id.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo_id.Location = new System.Drawing.Point(122, 59);
            this.txtMo_id.MaxLength = 9;
            this.txtMo_id.Name = "txtMo_id";
            this.txtMo_id.Size = new System.Drawing.Size(128, 22);
            this.txtMo_id.TabIndex = 0;
            this.txtMo_id.Leave += new System.EventHandler(this.txtMo_id_Leave);
            // 
            // lblPrd_code
            // 
            this.lblPrd_code.AutoSize = true;
            this.lblPrd_code.Location = new System.Drawing.Point(257, 90);
            this.lblPrd_code.Name = "lblPrd_code";
            this.lblPrd_code.Size = new System.Drawing.Size(56, 12);
            this.lblPrd_code.TabIndex = 1;
            this.lblPrd_code.Text = "產品代號:";
            // 
            // txtPrd_code
            // 
            this.txtPrd_code.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrd_code.Location = new System.Drawing.Point(314, 85);
            this.txtPrd_code.Name = "txtPrd_code";
            this.txtPrd_code.Size = new System.Drawing.Size(87, 22);
            this.txtPrd_code.TabIndex = 2;
            // 
            // lblSpec
            // 
            this.lblSpec.AutoSize = true;
            this.lblSpec.Location = new System.Drawing.Point(84, 114);
            this.lblSpec.Name = "lblSpec";
            this.lblSpec.Size = new System.Drawing.Size(32, 12);
            this.lblSpec.TabIndex = 1;
            this.lblSpec.Text = "規格:";
            // 
            // txtSpec
            // 
            this.txtSpec.Location = new System.Drawing.Point(122, 111);
            this.txtSpec.Name = "txtSpec";
            this.txtSpec.Size = new System.Drawing.Size(279, 22);
            this.txtSpec.TabIndex = 3;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(6, 142);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(110, 12);
            this.lblColor.TabIndex = 1;
            this.lblColor.Text = "布帶/鏈齒/拉頭顏色:";
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(122, 139);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(279, 22);
            this.txtColor.TabIndex = 4;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(84, 170);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(32, 12);
            this.lblSize.TabIndex = 1;
            this.lblSize.Text = "尺寸:";
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(122, 167);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(279, 22);
            this.txtSize.TabIndex = 5;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(84, 198);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(32, 12);
            this.lblQty.TabIndex = 1;
            this.lblQty.Text = "數量:";
            // 
            // lblPrint_mo
            // 
            this.lblPrint_mo.AutoSize = true;
            this.lblPrint_mo.Location = new System.Drawing.Point(60, 90);
            this.lblPrint_mo.Name = "lblPrint_mo";
            this.lblPrint_mo.Size = new System.Drawing.Size(56, 12);
            this.lblPrint_mo.TabIndex = 1;
            this.lblPrint_mo.Text = "制單編號:";
            // 
            // txtPrint_mo
            // 
            this.txtPrint_mo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrint_mo.Location = new System.Drawing.Point(122, 85);
            this.txtPrint_mo.MaxLength = 0;
            this.txtPrint_mo.Name = "txtPrint_mo";
            this.txtPrint_mo.Size = new System.Drawing.Size(128, 22);
            this.txtPrint_mo.TabIndex = 1;
            this.txtPrint_mo.Leave += new System.EventHandler(this.txtMo_id_Leave);
            // 
            // lblPer_pack
            // 
            this.lblPer_pack.AutoSize = true;
            this.lblPer_pack.Location = new System.Drawing.Point(253, 227);
            this.lblPer_pack.Name = "lblPer_pack";
            this.lblPer_pack.Size = new System.Drawing.Size(56, 12);
            this.lblPer_pack.TabIndex = 1;
            this.lblPer_pack.Text = "每包數量:";
            // 
            // luePack_type
            // 
            this.luePack_type.Location = new System.Drawing.Point(122, 223);
            this.luePack_type.Name = "luePack_type";
            this.luePack_type.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luePack_type.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cdesc", 60, "描述")});
            this.luePack_type.Properties.NullText = "";
            this.luePack_type.Size = new System.Drawing.Size(128, 20);
            this.luePack_type.TabIndex = 8;
            this.luePack_type.EditValueChanged += new System.EventHandler(this.luePack_type_EditValueChanged);
            // 
            // lblPack
            // 
            this.lblPack.Location = new System.Drawing.Point(64, 225);
            this.lblPack.Name = "lblPack";
            this.lblPack.Size = new System.Drawing.Size(52, 14);
            this.lblPack.TabIndex = 8;
            this.lblPack.Text = "包裝要求:";
            // 
            // lueGoods_unit
            // 
            this.lueGoods_unit.Location = new System.Drawing.Point(314, 197);
            this.lueGoods_unit.Name = "lueGoods_unit";
            this.lueGoods_unit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGoods_unit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", 60, "描述")});
            this.lueGoods_unit.Properties.NullText = "";
            this.lueGoods_unit.Size = new System.Drawing.Size(87, 20);
            this.lueGoods_unit.TabIndex = 7;
            // 
            // lblGoods_unit
            // 
            this.lblGoods_unit.Location = new System.Drawing.Point(257, 200);
            this.lblGoods_unit.Name = "lblGoods_unit";
            this.lblGoods_unit.Size = new System.Drawing.Size(52, 14);
            this.lblGoods_unit.TabIndex = 10;
            this.lblGoods_unit.Text = "數量單位:";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(122, 197);
            this.txtQty.Name = "txtQty";
            this.txtQty.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtQty.Size = new System.Drawing.Size(128, 20);
            this.txtQty.TabIndex = 6;
            // 
            // txtPer_pack
            // 
            this.txtPer_pack.Location = new System.Drawing.Point(314, 223);
            this.txtPer_pack.Name = "txtPer_pack";
            this.txtPer_pack.Size = new System.Drawing.Size(87, 20);
            this.txtPer_pack.TabIndex = 9;
            // 
            // frmZipperOrder_PrintCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 577);
            this.Controls.Add(this.txtPer_pack);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.lueGoods_unit);
            this.Controls.Add(this.lblGoods_unit);
            this.Controls.Add(this.luePack_type);
            this.Controls.Add(this.lblPack);
            this.Controls.Add(this.lblPer_pack);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.txtSpec);
            this.Controls.Add(this.lblSpec);
            this.Controls.Add(this.txtPrd_code);
            this.Controls.Add(this.lblPrd_code);
            this.Controls.Add(this.txtPrint_mo);
            this.Controls.Add(this.lblPrint_mo);
            this.Controls.Add(this.txtMo_id);
            this.Controls.Add(this.lblMo_id);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmZipperOrder_PrintCard";
            this.Text = "frmZipperOrder_PrintCard";
            this.Load += new System.EventHandler(this.frmZipperOrder_PrintCard_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luePack_type.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueGoods_unit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPer_pack.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label lblMo_id;
        private System.Windows.Forms.TextBox txtMo_id;
        private System.Windows.Forms.Label lblPrd_code;
        private System.Windows.Forms.TextBox txtPrd_code;
        private System.Windows.Forms.Label lblSpec;
        private System.Windows.Forms.TextBox txtSpec;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Label lblPrint_mo;
        private System.Windows.Forms.TextBox txtPrint_mo;
        private System.Windows.Forms.Label lblPer_pack;
        private DevExpress.XtraEditors.LookUpEdit luePack_type;
        private DevExpress.XtraEditors.LabelControl lblPack;
        private DevExpress.XtraEditors.LookUpEdit lueGoods_unit;
        private DevExpress.XtraEditors.LabelControl lblGoods_unit;
        private DevExpress.XtraEditors.TextEdit txtQty;
        private DevExpress.XtraEditors.TextEdit txtPer_pack;
    }
}