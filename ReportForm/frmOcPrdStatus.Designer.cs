namespace cf01.ReportForm
{
    partial class frmOcPrdStatus
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.cmbMoGroup = new System.Windows.Forms.ComboBox();
            this.lblMoGroup = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.mo_id = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.seller_id = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.btnFindCustomer = new System.Windows.Forms.Button();
            this.order_status = new System.Windows.Forms.Label();
            this.cmbCpl = new System.Windows.Forms.ComboBox();
            this.btnFindBrand = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.contract_id = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.it_customer = new System.Windows.Forms.Label();
            this.order_date = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.brand_id = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Size = new System.Drawing.Size(1076, 722);
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
            this.splitContainer1.Panel1.Controls.Add(this.dateEdit2);
            this.splitContainer1.Panel1.Controls.Add(this.dateEdit1);
            this.splitContainer1.Panel1.Controls.Add(this.cmbMoGroup);
            this.splitContainer1.Panel1.Controls.Add(this.lblMoGroup);
            this.splitContainer1.Panel1.Controls.Add(this.textBox12);
            this.splitContainer1.Panel1.Controls.Add(this.mo_id);
            this.splitContainer1.Panel1.Controls.Add(this.textBox11);
            this.splitContainer1.Panel1.Controls.Add(this.textBox10);
            this.splitContainer1.Panel1.Controls.Add(this.seller_id);
            this.splitContainer1.Panel1.Controls.Add(this.textBox9);
            this.splitContainer1.Panel1.Controls.Add(this.btnFindCustomer);
            this.splitContainer1.Panel1.Controls.Add(this.order_status);
            this.splitContainer1.Panel1.Controls.Add(this.cmbCpl);
            this.splitContainer1.Panel1.Controls.Add(this.btnFindBrand);
            this.splitContainer1.Panel1.Controls.Add(this.textBox6);
            this.splitContainer1.Panel1.Controls.Add(this.textBox5);
            this.splitContainer1.Panel1.Controls.Add(this.textBox4);
            this.splitContainer1.Panel1.Controls.Add(this.contract_id);
            this.splitContainer1.Panel1.Controls.Add(this.textBox3);
            this.splitContainer1.Panel1.Controls.Add(this.it_customer);
            this.splitContainer1.Panel1.Controls.Add(this.order_date);
            this.splitContainer1.Panel1.Controls.Add(this.textBox2);
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.brand_id);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetails);
            this.splitContainer1.Size = new System.Drawing.Size(1076, 697);
            this.splitContainer1.SplitterDistance = 133;
            this.splitContainer1.TabIndex = 3;
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(543, 10);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.dateEdit2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateEdit2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit2.Size = new System.Drawing.Size(100, 22);
            this.dateEdit2.TabIndex = 3;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(437, 10);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.dateEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(100, 22);
            this.dateEdit1.TabIndex = 2;
            this.dateEdit1.Leave += new System.EventHandler(this.dateEdit1_Leave);
            // 
            // cmbMoGroup
            // 
            this.cmbMoGroup.FormattingEnabled = true;
            this.cmbMoGroup.Location = new System.Drawing.Point(543, 87);
            this.cmbMoGroup.Name = "cmbMoGroup";
            this.cmbMoGroup.Size = new System.Drawing.Size(67, 20);
            this.cmbMoGroup.TabIndex = 13;
            // 
            // lblMoGroup
            // 
            this.lblMoGroup.AutoSize = true;
            this.lblMoGroup.Location = new System.Drawing.Point(480, 93);
            this.lblMoGroup.Name = "lblMoGroup";
            this.lblMoGroup.Size = new System.Drawing.Size(57, 12);
            this.lblMoGroup.TabIndex = 123;
            this.lblMoGroup.Text = "Mo Group:";
            // 
            // textBox12
            // 
            this.textBox12.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox12.Location = new System.Drawing.Point(543, 63);
            this.textBox12.MaxLength = 9;
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(100, 22);
            this.textBox12.TabIndex = 11;
            // 
            // mo_id
            // 
            this.mo_id.AutoSize = true;
            this.mo_id.Location = new System.Drawing.Point(352, 69);
            this.mo_id.Name = "mo_id";
            this.mo_id.Size = new System.Drawing.Size(46, 12);
            this.mo_id.TabIndex = 122;
            this.mo_id.Text = "MO No.:";
            // 
            // textBox11
            // 
            this.textBox11.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox11.Location = new System.Drawing.Point(437, 63);
            this.textBox11.MaxLength = 9;
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(100, 22);
            this.textBox11.TabIndex = 10;
            // 
            // textBox10
            // 
            this.textBox10.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox10.Location = new System.Drawing.Point(202, 63);
            this.textBox10.MaxLength = 8;
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(100, 22);
            this.textBox10.TabIndex = 9;
            // 
            // seller_id
            // 
            this.seller_id.AutoSize = true;
            this.seller_id.Location = new System.Drawing.Point(11, 66);
            this.seller_id.Name = "seller_id";
            this.seller_id.Size = new System.Drawing.Size(49, 12);
            this.seller_id.TabIndex = 121;
            this.seller_id.Text = "Seller ID:";
            // 
            // textBox9
            // 
            this.textBox9.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox9.Location = new System.Drawing.Point(96, 63);
            this.textBox9.MaxLength = 8;
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(100, 22);
            this.textBox9.TabIndex = 8;
            // 
            // btnFindCustomer
            // 
            this.btnFindCustomer.Location = new System.Drawing.Point(306, 35);
            this.btnFindCustomer.Name = "btnFindCustomer";
            this.btnFindCustomer.Size = new System.Drawing.Size(22, 23);
            this.btnFindCustomer.TabIndex = 120;
            this.btnFindCustomer.Text = "...";
            this.btnFindCustomer.UseVisualStyleBackColor = true;
            this.btnFindCustomer.Click += new System.EventHandler(this.btnFindCustomer_Click);
            // 
            // order_status
            // 
            this.order_status.AutoSize = true;
            this.order_status.Location = new System.Drawing.Point(9, 90);
            this.order_status.Name = "order_status";
            this.order_status.Size = new System.Drawing.Size(65, 12);
            this.order_status.TabIndex = 119;
            this.order_status.Text = "Order Status:";
            // 
            // cmbCpl
            // 
            this.cmbCpl.FormattingEnabled = true;
            this.cmbCpl.Location = new System.Drawing.Point(96, 88);
            this.cmbCpl.Name = "cmbCpl";
            this.cmbCpl.Size = new System.Drawing.Size(100, 20);
            this.cmbCpl.TabIndex = 12;
            // 
            // btnFindBrand
            // 
            this.btnFindBrand.Location = new System.Drawing.Point(306, 9);
            this.btnFindBrand.Name = "btnFindBrand";
            this.btnFindBrand.Size = new System.Drawing.Size(22, 23);
            this.btnFindBrand.TabIndex = 118;
            this.btnFindBrand.Text = "...";
            this.btnFindBrand.UseVisualStyleBackColor = true;
            this.btnFindBrand.Click += new System.EventHandler(this.btnFindBrand_Click);
            // 
            // textBox6
            // 
            this.textBox6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox6.Location = new System.Drawing.Point(543, 36);
            this.textBox6.MaxLength = 8;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 22);
            this.textBox6.TabIndex = 7;
            // 
            // textBox5
            // 
            this.textBox5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox5.Location = new System.Drawing.Point(437, 37);
            this.textBox5.MaxLength = 8;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 6;
            // 
            // textBox4
            // 
            this.textBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox4.Location = new System.Drawing.Point(202, 37);
            this.textBox4.MaxLength = 8;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 5;
            // 
            // contract_id
            // 
            this.contract_id.AutoSize = true;
            this.contract_id.Location = new System.Drawing.Point(352, 41);
            this.contract_id.Name = "contract_id";
            this.contract_id.Size = new System.Drawing.Size(42, 12);
            this.contract_id.TabIndex = 116;
            this.contract_id.Text = "PO No.:";
            // 
            // textBox3
            // 
            this.textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox3.Location = new System.Drawing.Point(96, 37);
            this.textBox3.MaxLength = 8;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 4;
            // 
            // it_customer
            // 
            this.it_customer.AutoSize = true;
            this.it_customer.Location = new System.Drawing.Point(11, 40);
            this.it_customer.Name = "it_customer";
            this.it_customer.Size = new System.Drawing.Size(81, 12);
            this.it_customer.TabIndex = 117;
            this.it_customer.Text = "Customer Code:";
            // 
            // order_date
            // 
            this.order_date.AutoSize = true;
            this.order_date.Location = new System.Drawing.Point(352, 13);
            this.order_date.Name = "order_date";
            this.order_date.Size = new System.Drawing.Size(59, 12);
            this.order_date.TabIndex = 115;
            this.order_date.Text = "Order Date:";
            // 
            // textBox2
            // 
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox2.Location = new System.Drawing.Point(202, 10);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Location = new System.Drawing.Point(96, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 0;
            // 
            // brand_id
            // 
            this.brand_id.AutoSize = true;
            this.brand_id.Location = new System.Drawing.Point(11, 13);
            this.brand_id.Name = "brand_id";
            this.brand_id.Size = new System.Drawing.Size(37, 12);
            this.brand_id.TabIndex = 114;
            this.brand_id.Text = "Brand:";
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(1076, 560);
            this.dgvDetails.TabIndex = 0;
            // 
            // frmOcPrdStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1076, 722);
            this.Name = "frmOcPrdStatus";
            this.Text = "frmOcPrdStatus";
            this.Load += new System.EventHandler(this.frmOcPrdStatus_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.ComboBox cmbMoGroup;
        private System.Windows.Forms.Label lblMoGroup;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Label mo_id;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label seller_id;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Button btnFindCustomer;
        private System.Windows.Forms.Label order_status;
        private System.Windows.Forms.ComboBox cmbCpl;
        private System.Windows.Forms.Button btnFindBrand;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label contract_id;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label it_customer;
        private System.Windows.Forms.Label order_date;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label brand_id;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
    }
}
