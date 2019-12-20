namespace cf01.BaseForm
{
    partial class frmSt01
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
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.loaction_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mo_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sec_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dn_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dn_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seq_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dn_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dn_weg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cust_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.po = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oc_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oc_qty_pcs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oc_amt_hkd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seller_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seller_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carton_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lot_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_amt_hkd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(708, 48);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.dateEdit2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateEdit2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit2.Size = new System.Drawing.Size(91, 22);
            this.dateEdit2.TabIndex = 24;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(602, 48);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.dateEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dateEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(91, 22);
            this.dateEdit1.TabIndex = 23;
            this.dateEdit1.Leave += new System.EventHandler(this.dateEdit1_Leave);
            // 
            // textBox4
            // 
            this.textBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox4.Location = new System.Drawing.Point(436, 48);
            this.textBox4.MaxLength = 12;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 22;
            // 
            // textBox3
            // 
            this.textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox3.Location = new System.Drawing.Point(330, 48);
            this.textBox3.MaxLength = 12;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 21;
            this.textBox3.Leave += new System.EventHandler(this.textBox3_Leave);
            // 
            // textBox10
            // 
            this.textBox10.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox10.Location = new System.Drawing.Point(708, 79);
            this.textBox10.MaxLength = 8;
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(91, 22);
            this.textBox10.TabIndex = 30;
            // 
            // textBox8
            // 
            this.textBox8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox8.Location = new System.Drawing.Point(437, 79);
            this.textBox8.MaxLength = 5;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 22);
            this.textBox8.TabIndex = 28;
            // 
            // textBox6
            // 
            this.textBox6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox6.Location = new System.Drawing.Point(169, 76);
            this.textBox6.MaxLength = 9;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 22);
            this.textBox6.TabIndex = 26;
            // 
            // textBox2
            // 
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox2.Location = new System.Drawing.Point(169, 48);
            this.textBox2.MaxLength = 3;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 20;
            // 
            // textBox9
            // 
            this.textBox9.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox9.Location = new System.Drawing.Point(602, 79);
            this.textBox9.MaxLength = 8;
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(91, 22);
            this.textBox9.TabIndex = 29;
            this.textBox9.Leave += new System.EventHandler(this.textBox9_Leave);
            // 
            // textBox7
            // 
            this.textBox7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox7.Location = new System.Drawing.Point(331, 79);
            this.textBox7.MaxLength = 5;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 22);
            this.textBox7.TabIndex = 27;
            this.textBox7.Leave += new System.EventHandler(this.textBox7_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(542, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "回港日期:";
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.loaction_id,
            this.mo_id,
            this.goods_id,
            this.goods_name,
            this.qty,
            this.sec_qty,
            this.remark,
            this.dn_id,
            this.dn_date,
            this.seq_id,
            this.dn_qty,
            this.dn_weg,
            this.cust,
            this.cust_name,
            this.po,
            this.oc_no,
            this.oc_qty_pcs,
            this.oc_amt_hkd,
            this.seller_id,
            this.seller_name,
            this.m_id,
            this.carton_no,
            this.lot_no,
            this.unit_price,
            this.p_unit,
            this.st_amt_hkd});
            this.dgvDetails.Location = new System.Drawing.Point(2, 112);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(916, 450);
            this.dgvDetails.TabIndex = 15;
            // 
            // loaction_id
            // 
            this.loaction_id.DataPropertyName = "location_id";
            this.loaction_id.HeaderText = "倉庫";
            this.loaction_id.Name = "loaction_id";
            // 
            // mo_id
            // 
            this.mo_id.DataPropertyName = "mo_id";
            this.mo_id.HeaderText = "制單編號";
            this.mo_id.Name = "mo_id";
            // 
            // goods_id
            // 
            this.goods_id.DataPropertyName = "goods_id";
            this.goods_id.HeaderText = "物料編號";
            this.goods_id.Name = "goods_id";
            // 
            // goods_name
            // 
            this.goods_name.DataPropertyName = "goods_name";
            this.goods_name.HeaderText = "物料描述";
            this.goods_name.Name = "goods_name";
            // 
            // qty
            // 
            this.qty.DataPropertyName = "qty";
            this.qty.HeaderText = "存貨數量";
            this.qty.Name = "qty";
            // 
            // sec_qty
            // 
            this.sec_qty.DataPropertyName = "sec_qty";
            this.sec_qty.HeaderText = "存貨重量";
            this.sec_qty.Name = "sec_qty";
            // 
            // remark
            // 
            this.remark.DataPropertyName = "remark";
            this.remark.HeaderText = "貨架編號";
            this.remark.Name = "remark";
            // 
            // dn_id
            // 
            this.dn_id.DataPropertyName = "dn_id";
            this.dn_id.HeaderText = "回港單號";
            this.dn_id.Name = "dn_id";
            // 
            // dn_date
            // 
            this.dn_date.DataPropertyName = "dn_date";
            this.dn_date.HeaderText = "回港單日期";
            this.dn_date.Name = "dn_date";
            // 
            // seq_id
            // 
            this.seq_id.DataPropertyName = "dn_seq";
            this.seq_id.HeaderText = "序號";
            this.seq_id.Name = "seq_id";
            // 
            // dn_qty
            // 
            this.dn_qty.DataPropertyName = "dn_qty";
            this.dn_qty.HeaderText = "回港數量(PCS)";
            this.dn_qty.Name = "dn_qty";
            // 
            // dn_weg
            // 
            this.dn_weg.DataPropertyName = "dn_weg";
            this.dn_weg.HeaderText = "回港重量(KGS)";
            this.dn_weg.Name = "dn_weg";
            // 
            // cust
            // 
            this.cust.DataPropertyName = "cust";
            this.cust.HeaderText = "客戶編號";
            this.cust.Name = "cust";
            // 
            // cust_name
            // 
            this.cust_name.DataPropertyName = "cust_name";
            this.cust_name.HeaderText = "客戶描述";
            this.cust_name.Name = "cust_name";
            // 
            // po
            // 
            this.po.DataPropertyName = "po";
            this.po.HeaderText = "客戶PO";
            this.po.Name = "po";
            // 
            // oc_no
            // 
            this.oc_no.DataPropertyName = "oc_no";
            this.oc_no.HeaderText = "OC編號";
            this.oc_no.Name = "oc_no";
            // 
            // oc_qty_pcs
            // 
            this.oc_qty_pcs.DataPropertyName = "oc_qty_pcs";
            this.oc_qty_pcs.HeaderText = "訂單數量(PCS)";
            this.oc_qty_pcs.Name = "oc_qty_pcs";
            // 
            // oc_amt_hkd
            // 
            this.oc_amt_hkd.DataPropertyName = "oc_amt_hkd";
            this.oc_amt_hkd.HeaderText = "訂單金額(HKD)";
            this.oc_amt_hkd.Name = "oc_amt_hkd";
            // 
            // seller_id
            // 
            this.seller_id.DataPropertyName = "seller_id";
            this.seller_id.HeaderText = "營業員代號";
            this.seller_id.Name = "seller_id";
            // 
            // seller_name
            // 
            this.seller_name.DataPropertyName = "seller_name";
            this.seller_name.HeaderText = "營業員描述";
            this.seller_name.Name = "seller_name";
            // 
            // m_id
            // 
            this.m_id.DataPropertyName = "m_id";
            this.m_id.HeaderText = "貨幣代號";
            this.m_id.Name = "m_id";
            // 
            // carton_no
            // 
            this.carton_no.DataPropertyName = "carton_code";
            this.carton_no.HeaderText = "倉位";
            this.carton_no.Name = "carton_no";
            // 
            // lot_no
            // 
            this.lot_no.DataPropertyName = "lot_no";
            this.lot_no.HeaderText = "批號";
            this.lot_no.Name = "lot_no";
            // 
            // unit_price
            // 
            this.unit_price.DataPropertyName = "unit_price";
            this.unit_price.HeaderText = "訂單單價";
            this.unit_price.Name = "unit_price";
            // 
            // p_unit
            // 
            this.p_unit.DataPropertyName = "p_unit";
            this.p_unit.HeaderText = "單價單位";
            this.p_unit.Name = "p_unit";
            // 
            // st_amt_hkd
            // 
            this.st_amt_hkd.DataPropertyName = "st_amt_hkd";
            this.st_amt_hkd.HeaderText = "存貨金額(HKD)";
            this.st_amt_hkd.Name = "st_amt_hkd";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(545, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "客戶編號:";
            // 
            // textBox5
            // 
            this.textBox5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox5.Location = new System.Drawing.Point(63, 76);
            this.textBox5.MaxLength = 9;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 25;
            this.textBox5.Leave += new System.EventHandler(this.textBox5_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(274, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "營業員:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "回港單號:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "制單編號:";
            // 
            // textBox1
            // 
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Location = new System.Drawing.Point(63, 48);
            this.textBox1.MaxLength = 3;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 19;
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "貨倉:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(918, 25);
            this.toolStrip1.TabIndex = 31;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // frmSt01
            // 
            this.ClientSize = new System.Drawing.Size(918, 563);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dateEdit2);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmSt01";
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn loaction_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn mo_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn sec_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn dn_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dn_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn seq_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dn_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dn_weg;
        private System.Windows.Forms.DataGridViewTextBoxColumn cust;
        private System.Windows.Forms.DataGridViewTextBoxColumn cust_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn po;
        private System.Windows.Forms.DataGridViewTextBoxColumn oc_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn oc_qty_pcs;
        private System.Windows.Forms.DataGridViewTextBoxColumn oc_amt_hkd;
        private System.Windows.Forms.DataGridViewTextBoxColumn seller_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn seller_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn carton_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn lot_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn st_amt_hkd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;

     
    }
}
