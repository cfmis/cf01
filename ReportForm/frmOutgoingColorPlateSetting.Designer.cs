namespace cf01.ReportForm
{
    partial class frmOutgoingColorPlateSetting
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.lueVendor = new DevExpress.XtraEditors.LookUpEdit();
            this.dtpValid_date = new cf01.ModuleClass.UserDateEdit();
            this.dtpQuotation_date = new cf01.ModuleClass.UserDateEdit();
            this.cmboxUnit = new System.Windows.Forms.ComboBox();
            this.vendor_color = new System.Windows.Forms.Label();
            this.clr_desc = new System.Windows.Forms.Label();
            this.txtVendor_color = new System.Windows.Forms.TextBox();
            this.clr = new System.Windows.Forms.Label();
            this.txtColor_id = new System.Windows.Forms.TextBox();
            this.txtColor_name = new System.Windows.Forms.TextBox();
            this.p_unit = new System.Windows.Forms.Label();
            this.quotation_no = new System.Windows.Forms.Label();
            this.unit_price = new System.Windows.Forms.Label();
            this.txtQuotation_no = new System.Windows.Forms.TextBox();
            this.vendor_id = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.valid_date = new System.Windows.Forms.Label();
            this.quotation_date = new System.Windows.Forms.Label();
            this.dgvColorPlate = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueVendor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColorPlate)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Size = new System.Drawing.Size(1075, 663);
            this.panel1.Controls.SetChildIndex(this.splitContainer1, 0);
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
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxEdit1);
            this.splitContainer1.Panel1.Controls.Add(this.lookUpEdit1);
            this.splitContainer1.Panel1.Controls.Add(this.lueVendor);
            this.splitContainer1.Panel1.Controls.Add(this.dtpValid_date);
            this.splitContainer1.Panel1.Controls.Add(this.dtpQuotation_date);
            this.splitContainer1.Panel1.Controls.Add(this.cmboxUnit);
            this.splitContainer1.Panel1.Controls.Add(this.vendor_color);
            this.splitContainer1.Panel1.Controls.Add(this.clr_desc);
            this.splitContainer1.Panel1.Controls.Add(this.txtVendor_color);
            this.splitContainer1.Panel1.Controls.Add(this.clr);
            this.splitContainer1.Panel1.Controls.Add(this.txtColor_id);
            this.splitContainer1.Panel1.Controls.Add(this.txtColor_name);
            this.splitContainer1.Panel1.Controls.Add(this.p_unit);
            this.splitContainer1.Panel1.Controls.Add(this.quotation_no);
            this.splitContainer1.Panel1.Controls.Add(this.unit_price);
            this.splitContainer1.Panel1.Controls.Add(this.txtQuotation_no);
            this.splitContainer1.Panel1.Controls.Add(this.vendor_id);
            this.splitContainer1.Panel1.Controls.Add(this.txtUnitPrice);
            this.splitContainer1.Panel1.Controls.Add(this.valid_date);
            this.splitContainer1.Panel1.Controls.Add(this.quotation_date);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvColorPlate);
            this.splitContainer1.Size = new System.Drawing.Size(1075, 638);
            this.splitContainer1.SplitterDistance = 155;
            this.splitContainer1.TabIndex = 1;
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(822, 102);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Size = new System.Drawing.Size(100, 20);
            this.comboBoxEdit1.TabIndex = 26;
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.EditValue = "";
            this.lookUpEdit1.Location = new System.Drawing.Point(762, 56);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Properties.NullText = "fffff";
            this.lookUpEdit1.Properties.ReadOnly = true;
            this.lookUpEdit1.Size = new System.Drawing.Size(172, 20);
            this.lookUpEdit1.TabIndex = 25;
            // 
            // lueVendor
            // 
            this.lueVendor.EditValue = "";
            this.lueVendor.Location = new System.Drawing.Point(86, 41);
            this.lueVendor.Name = "lueVendor";
            this.lueVendor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.lueVendor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueVendor.Properties.NullText = "aaa";
            this.lueVendor.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lueVendor.Size = new System.Drawing.Size(138, 22);
            this.lueVendor.TabIndex = 24;
            // 
            // dtpValid_date
            // 
            this.dtpValid_date.Location = new System.Drawing.Point(677, 99);
            this.dtpValid_date.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpValid_date.Name = "dtpValid_date";
            this.dtpValid_date.Size = new System.Drawing.Size(103, 27);
            this.dtpValid_date.TabIndex = 23;
            // 
            // dtpQuotation_date
            // 
            this.dtpQuotation_date.Location = new System.Drawing.Point(396, 99);
            this.dtpQuotation_date.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpQuotation_date.Name = "dtpQuotation_date";
            this.dtpQuotation_date.Size = new System.Drawing.Size(103, 27);
            this.dtpQuotation_date.TabIndex = 22;
            // 
            // cmboxUnit
            // 
            this.cmboxUnit.FormattingEnabled = true;
            this.cmboxUnit.Location = new System.Drawing.Point(396, 72);
            this.cmboxUnit.Name = "cmboxUnit";
            this.cmboxUnit.Size = new System.Drawing.Size(80, 23);
            this.cmboxUnit.TabIndex = 6;
            // 
            // vendor_color
            // 
            this.vendor_color.AutoSize = true;
            this.vendor_color.Location = new System.Drawing.Point(579, 13);
            this.vendor_color.Name = "vendor_color";
            this.vendor_color.Size = new System.Drawing.Size(94, 15);
            this.vendor_color.TabIndex = 10;
            this.vendor_color.Text = "供應商顏色編號:";
            // 
            // clr_desc
            // 
            this.clr_desc.AutoSize = true;
            this.clr_desc.Location = new System.Drawing.Point(318, 13);
            this.clr_desc.Name = "clr_desc";
            this.clr_desc.Size = new System.Drawing.Size(58, 15);
            this.clr_desc.TabIndex = 8;
            this.clr_desc.Text = "顏色描述:";
            // 
            // txtVendor_color
            // 
            this.txtVendor_color.Location = new System.Drawing.Point(677, 10);
            this.txtVendor_color.Name = "txtVendor_color";
            this.txtVendor_color.Size = new System.Drawing.Size(131, 21);
            this.txtVendor_color.TabIndex = 2;
            // 
            // clr
            // 
            this.clr.AutoSize = true;
            this.clr.Location = new System.Drawing.Point(24, 13);
            this.clr.Name = "clr";
            this.clr.Size = new System.Drawing.Size(58, 15);
            this.clr.TabIndex = 9;
            this.clr.Text = "顏色編號:";
            // 
            // txtColor_id
            // 
            this.txtColor_id.Location = new System.Drawing.Point(86, 10);
            this.txtColor_id.Name = "txtColor_id";
            this.txtColor_id.Size = new System.Drawing.Size(138, 21);
            this.txtColor_id.TabIndex = 0;
            // 
            // txtColor_name
            // 
            this.txtColor_name.Location = new System.Drawing.Point(396, 10);
            this.txtColor_name.Name = "txtColor_name";
            this.txtColor_name.Size = new System.Drawing.Size(152, 21);
            this.txtColor_name.TabIndex = 1;
            // 
            // p_unit
            // 
            this.p_unit.AutoSize = true;
            this.p_unit.Location = new System.Drawing.Point(318, 77);
            this.p_unit.Name = "p_unit";
            this.p_unit.Size = new System.Drawing.Size(58, 15);
            this.p_unit.TabIndex = 4;
            this.p_unit.Text = "單價單位:";
            // 
            // quotation_no
            // 
            this.quotation_no.AutoSize = true;
            this.quotation_no.Location = new System.Drawing.Point(24, 108);
            this.quotation_no.Name = "quotation_no";
            this.quotation_no.Size = new System.Drawing.Size(58, 15);
            this.quotation_no.TabIndex = 3;
            this.quotation_no.Text = "報價單號:";
            // 
            // unit_price
            // 
            this.unit_price.AutoSize = true;
            this.unit_price.Location = new System.Drawing.Point(24, 77);
            this.unit_price.Name = "unit_price";
            this.unit_price.Size = new System.Drawing.Size(34, 15);
            this.unit_price.TabIndex = 2;
            this.unit_price.Text = "價錢:";
            // 
            // txtQuotation_no
            // 
            this.txtQuotation_no.Location = new System.Drawing.Point(86, 105);
            this.txtQuotation_no.Name = "txtQuotation_no";
            this.txtQuotation_no.Size = new System.Drawing.Size(138, 21);
            this.txtQuotation_no.TabIndex = 7;
            // 
            // vendor_id
            // 
            this.vendor_id.AutoSize = true;
            this.vendor_id.Location = new System.Drawing.Point(24, 43);
            this.vendor_id.Name = "vendor_id";
            this.vendor_id.Size = new System.Drawing.Size(46, 15);
            this.vendor_id.TabIndex = 7;
            this.vendor_id.Text = "供應商:";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(86, 74);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(138, 21);
            this.txtUnitPrice.TabIndex = 5;
            // 
            // valid_date
            // 
            this.valid_date.AutoSize = true;
            this.valid_date.Location = new System.Drawing.Point(579, 108);
            this.valid_date.Name = "valid_date";
            this.valid_date.Size = new System.Drawing.Size(58, 15);
            this.valid_date.TabIndex = 6;
            this.valid_date.Text = "生效日期:";
            // 
            // quotation_date
            // 
            this.quotation_date.AutoSize = true;
            this.quotation_date.Location = new System.Drawing.Point(318, 108);
            this.quotation_date.Name = "quotation_date";
            this.quotation_date.Size = new System.Drawing.Size(70, 15);
            this.quotation_date.TabIndex = 5;
            this.quotation_date.Text = "報價單日期:";
            // 
            // dgvColorPlate
            // 
            this.dgvColorPlate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColorPlate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvColorPlate.Location = new System.Drawing.Point(0, 0);
            this.dgvColorPlate.Name = "dgvColorPlate";
            this.dgvColorPlate.RowTemplate.Height = 24;
            this.dgvColorPlate.Size = new System.Drawing.Size(1075, 479);
            this.dgvColorPlate.TabIndex = 0;
            this.dgvColorPlate.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvColorPlate_CellClick);
            // 
            // frmOutgoingColorPlateSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 663);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Name = "frmOutgoingColorPlateSetting";
            this.Text = "frmOutgoingColorPlateSetting";
            this.Load += new System.EventHandler(this.frmOutgoingColorPlateSetting_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueVendor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColorPlate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvColorPlate;
        private System.Windows.Forms.Label vendor_color;
        private System.Windows.Forms.Label clr_desc;
        private System.Windows.Forms.TextBox txtVendor_color;
        private System.Windows.Forms.Label clr;
        private System.Windows.Forms.TextBox txtColor_id;
        private System.Windows.Forms.TextBox txtColor_name;
        private System.Windows.Forms.Label p_unit;
        private System.Windows.Forms.Label quotation_no;
        private System.Windows.Forms.Label unit_price;
        private System.Windows.Forms.TextBox txtQuotation_no;
        private System.Windows.Forms.Label vendor_id;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label valid_date;
        private System.Windows.Forms.Label quotation_date;
        private System.Windows.Forms.ComboBox cmboxUnit;
        private ModuleClass.UserDateEdit dtpQuotation_date;
        private ModuleClass.UserDateEdit dtpValid_date;
        private DevExpress.XtraEditors.LookUpEdit lueVendor;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
    }
}