namespace cf01.ReportForm
{
    partial class frmInv01
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
            //_Instance = null;
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInv01));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.ivm1inv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ivm1dat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ivm2seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ivm2mo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ivm2item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inm1cdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ivm2qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ivm2unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ivm2weg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoice_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty_pcs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amt_hkd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ivm1cust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cust_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ivm1owa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ivm1brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ivm1sec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cust_item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.po = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ocno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimeBox2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimeBox1 = new System.Windows.Forms.DateTimePicker();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.BTNFIND = new System.Windows.Forms.ToolStripButton();
            this.BTNEXCEL = new System.Windows.Forms.ToolStripButton();
            this.BTNPREVIEW = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(101, 143);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(156, 20);
            this.comboBox1.TabIndex = 58;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(91, 173);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 57;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox13
            // 
            this.textBox13.AcceptsTab = true;
            this.textBox13.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox13.Location = new System.Drawing.Point(378, 115);
            this.textBox13.MaxLength = 18;
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(100, 22);
            this.textBox13.TabIndex = 50;
            this.textBox13.Leave += new System.EventHandler(this.textBox13_Leave);
            // 
            // textBox7
            // 
            this.textBox7.AcceptsTab = true;
            this.textBox7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox7.Location = new System.Drawing.Point(378, 89);
            this.textBox7.MaxLength = 8;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 22);
            this.textBox7.TabIndex = 44;
            this.textBox7.Leave += new System.EventHandler(this.textBox7_Leave);
            // 
            // textBox11
            // 
            this.textBox11.AcceptsTab = true;
            this.textBox11.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox11.Location = new System.Drawing.Point(101, 115);
            this.textBox11.MaxLength = 9;
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(100, 22);
            this.textBox11.TabIndex = 48;
            this.textBox11.Leave += new System.EventHandler(this.textBox11_Leave);
            // 
            // textBox5
            // 
            this.textBox5.AcceptsTab = true;
            this.textBox5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox5.Location = new System.Drawing.Point(101, 89);
            this.textBox5.MaxLength = 8;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 41;
            this.textBox5.Leave += new System.EventHandler(this.textBox5_Leave);
            // 
            // textBox3
            // 
            this.textBox3.AcceptsTab = true;
            this.textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox3.Location = new System.Drawing.Point(683, 63);
            this.textBox3.MaxLength = 5;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 39;
            this.textBox3.Leave += new System.EventHandler(this.textBox3_Leave);
            // 
            // textBox1
            // 
            this.textBox1.AcceptsTab = true;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Location = new System.Drawing.Point(101, 63);
            this.textBox1.MaxLength = 10;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 34;
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(596, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 12);
            this.label9.TabIndex = 35;
            this.label9.Text = "客戶產品編號:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(596, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 12);
            this.label6.TabIndex = 26;
            this.label6.Text = "牌子編號:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(316, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 12);
            this.label8.TabIndex = 27;
            this.label8.Text = "產品編號:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(316, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 12);
            this.label5.TabIndex = 24;
            this.label5.Text = "洋行代號:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(41, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 12);
            this.label10.TabIndex = 25;
            this.label10.Text = "報表種類:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "制單編號:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 12);
            this.label4.TabIndex = 31;
            this.label4.Text = "客戶編號:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(596, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 12);
            this.label3.TabIndex = 32;
            this.label3.Text = "營業員:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(313, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 29;
            this.label2.Text = "發票日期:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 33;
            this.label1.Text = "發票編號:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(172, 173);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 56;
            this.button3.Text = "匯出2";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(436, 182);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(39, 12);
            this.lblMessage.TabIndex = 55;
            this.lblMessage.Text = "label11";
            this.lblMessage.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(315, 173);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 54;
            this.button2.Text = "匯出1";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(577, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 43;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetails.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ivm1inv,
            this.ivm1dat,
            this.ivm2seq,
            this.ivm2mo,
            this.ivm2item,
            this.inm1cdesc,
            this.ivm2qty,
            this.ivm2unit,
            this.ivm2weg,
            this.invoice_price,
            this.p_unit,
            this.total_sum,
            this.m_id,
            this.qty_pcs,
            this.amt_hkd,
            this.ivm1cust,
            this.cust_name,
            this.ivm1owa,
            this.ivm1brand,
            this.ivm1sec,
            this.cust_item,
            this.po,
            this.ocno});
            this.dgvDetails.Location = new System.Drawing.Point(0, 233);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(976, 352);
            this.dgvDetails.TabIndex = 30;
            // 
            // ivm1inv
            // 
            this.ivm1inv.DataPropertyName = "id";
            this.ivm1inv.HeaderText = "發票編號";
            this.ivm1inv.Name = "ivm1inv";
            this.ivm1inv.ReadOnly = true;
            // 
            // ivm1dat
            // 
            this.ivm1dat.DataPropertyName = "oi_date";
            this.ivm1dat.HeaderText = "發票日期";
            this.ivm1dat.Name = "ivm1dat";
            this.ivm1dat.ReadOnly = true;
            // 
            // ivm2seq
            // 
            this.ivm2seq.DataPropertyName = "sequence_id";
            this.ivm2seq.HeaderText = "序號";
            this.ivm2seq.Name = "ivm2seq";
            this.ivm2seq.ReadOnly = true;
            this.ivm2seq.Width = 60;
            // 
            // ivm2mo
            // 
            this.ivm2mo.DataPropertyName = "mo_id";
            this.ivm2mo.HeaderText = "制單編號";
            this.ivm2mo.Name = "ivm2mo";
            this.ivm2mo.ReadOnly = true;
            // 
            // ivm2item
            // 
            this.ivm2item.DataPropertyName = "goods_id";
            this.ivm2item.HeaderText = "產品編號";
            this.ivm2item.Name = "ivm2item";
            this.ivm2item.ReadOnly = true;
            // 
            // inm1cdesc
            // 
            this.inm1cdesc.DataPropertyName = "goods_name";
            this.inm1cdesc.HeaderText = "產品描述";
            this.inm1cdesc.Name = "inm1cdesc";
            this.inm1cdesc.ReadOnly = true;
            // 
            // ivm2qty
            // 
            this.ivm2qty.DataPropertyName = "u_invoice_qty";
            this.ivm2qty.HeaderText = "發票數量";
            this.ivm2qty.Name = "ivm2qty";
            this.ivm2qty.ReadOnly = true;
            // 
            // ivm2unit
            // 
            this.ivm2unit.DataPropertyName = "goods_unit";
            this.ivm2unit.HeaderText = "數量單位";
            this.ivm2unit.Name = "ivm2unit";
            this.ivm2unit.ReadOnly = true;
            // 
            // ivm2weg
            // 
            this.ivm2weg.DataPropertyName = "sec_qty";
            this.ivm2weg.HeaderText = "發票重量";
            this.ivm2weg.Name = "ivm2weg";
            this.ivm2weg.ReadOnly = true;
            // 
            // invoice_price
            // 
            this.invoice_price.DataPropertyName = "invoice_price";
            this.invoice_price.HeaderText = "發票單價";
            this.invoice_price.Name = "invoice_price";
            this.invoice_price.ReadOnly = true;
            // 
            // p_unit
            // 
            this.p_unit.DataPropertyName = "p_unit";
            this.p_unit.HeaderText = "單價單位";
            this.p_unit.Name = "p_unit";
            this.p_unit.ReadOnly = true;
            // 
            // total_sum
            // 
            this.total_sum.DataPropertyName = "total_sum";
            this.total_sum.HeaderText = "金額";
            this.total_sum.Name = "total_sum";
            this.total_sum.ReadOnly = true;
            // 
            // m_id
            // 
            this.m_id.DataPropertyName = "m_id";
            this.m_id.HeaderText = "貨幣代號";
            this.m_id.Name = "m_id";
            this.m_id.ReadOnly = true;
            // 
            // qty_pcs
            // 
            this.qty_pcs.DataPropertyName = "i_qty_pcs";
            this.qty_pcs.HeaderText = "數量(PCS)";
            this.qty_pcs.Name = "qty_pcs";
            this.qty_pcs.ReadOnly = true;
            // 
            // amt_hkd
            // 
            this.amt_hkd.DataPropertyName = "i_amt_hkd";
            this.amt_hkd.HeaderText = "金額(HKD)";
            this.amt_hkd.Name = "amt_hkd";
            this.amt_hkd.ReadOnly = true;
            // 
            // ivm1cust
            // 
            this.ivm1cust.DataPropertyName = "it_customer";
            this.ivm1cust.HeaderText = "客戶編號";
            this.ivm1cust.Name = "ivm1cust";
            this.ivm1cust.ReadOnly = true;
            // 
            // cust_name
            // 
            this.cust_name.DataPropertyName = "cust_name";
            this.cust_name.HeaderText = "客戶描述";
            this.cust_name.Name = "cust_name";
            this.cust_name.ReadOnly = true;
            // 
            // ivm1owa
            // 
            this.ivm1owa.DataPropertyName = "agent";
            this.ivm1owa.HeaderText = "洋行代號";
            this.ivm1owa.Name = "ivm1owa";
            this.ivm1owa.ReadOnly = true;
            // 
            // ivm1brand
            // 
            this.ivm1brand.DataPropertyName = "brand_id";
            this.ivm1brand.HeaderText = "牌子編號";
            this.ivm1brand.Name = "ivm1brand";
            this.ivm1brand.ReadOnly = true;
            // 
            // ivm1sec
            // 
            this.ivm1sec.DataPropertyName = "seller_id";
            this.ivm1sec.HeaderText = "營業員代號";
            this.ivm1sec.Name = "ivm1sec";
            this.ivm1sec.ReadOnly = true;
            // 
            // cust_item
            // 
            this.cust_item.DataPropertyName = "customer_goods";
            this.cust_item.HeaderText = "客戶產品編號";
            this.cust_item.Name = "cust_item";
            this.cust_item.ReadOnly = true;
            // 
            // po
            // 
            this.po.DataPropertyName = "contract_cid";
            this.po.HeaderText = "客戶PO";
            this.po.Name = "po";
            this.po.ReadOnly = true;
            // 
            // ocno
            // 
            this.ocno.DataPropertyName = "order_id";
            this.ocno.HeaderText = "OC編號";
            this.ocno.Name = "ocno";
            this.ocno.ReadOnly = true;
            // 
            // dateTimeBox2
            // 
            this.dateTimeBox2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeBox2.Location = new System.Drawing.Point(488, 63);
            this.dateTimeBox2.Name = "dateTimeBox2";
            this.dateTimeBox2.Size = new System.Drawing.Size(99, 22);
            this.dateTimeBox2.TabIndex = 38;
            // 
            // dateTimeBox1
            // 
            this.dateTimeBox1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeBox1.Location = new System.Drawing.Point(378, 63);
            this.dateTimeBox1.Name = "dateTimeBox1";
            this.dateTimeBox1.Size = new System.Drawing.Size(99, 22);
            this.dateTimeBox1.TabIndex = 37;
            // 
            // textBox16
            // 
            this.textBox16.AcceptsTab = true;
            this.textBox16.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox16.Location = new System.Drawing.Point(807, 115);
            this.textBox16.MaxLength = 20;
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(100, 22);
            this.textBox16.TabIndex = 53;
            // 
            // textBox10
            // 
            this.textBox10.AcceptsTab = true;
            this.textBox10.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox10.Location = new System.Drawing.Point(807, 89);
            this.textBox10.MaxLength = 8;
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(100, 22);
            this.textBox10.TabIndex = 47;
            // 
            // textBox8
            // 
            this.textBox8.AcceptsTab = true;
            this.textBox8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox8.Location = new System.Drawing.Point(487, 89);
            this.textBox8.MaxLength = 8;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 22);
            this.textBox8.TabIndex = 45;
            // 
            // textBox14
            // 
            this.textBox14.AcceptsTab = true;
            this.textBox14.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox14.Location = new System.Drawing.Point(487, 115);
            this.textBox14.MaxLength = 18;
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(100, 22);
            this.textBox14.TabIndex = 51;
            // 
            // textBox12
            // 
            this.textBox12.AcceptsTab = true;
            this.textBox12.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox12.Location = new System.Drawing.Point(210, 115);
            this.textBox12.MaxLength = 9;
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(100, 22);
            this.textBox12.TabIndex = 49;
            // 
            // textBox6
            // 
            this.textBox6.AcceptsTab = true;
            this.textBox6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox6.Location = new System.Drawing.Point(210, 89);
            this.textBox6.MaxLength = 8;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 22);
            this.textBox6.TabIndex = 42;
            // 
            // textBox4
            // 
            this.textBox4.AcceptsTab = true;
            this.textBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox4.Location = new System.Drawing.Point(807, 63);
            this.textBox4.MaxLength = 5;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 40;
            // 
            // textBox2
            // 
            this.textBox2.AcceptsTab = true;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox2.Location = new System.Drawing.Point(210, 63);
            this.textBox2.MaxLength = 10;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 36;
            // 
            // textBox15
            // 
            this.textBox15.AcceptsTab = true;
            this.textBox15.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox15.Location = new System.Drawing.Point(683, 115);
            this.textBox15.MaxLength = 20;
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(100, 22);
            this.textBox15.TabIndex = 52;
            this.textBox15.Leave += new System.EventHandler(this.textBox15_Leave);
            // 
            // textBox9
            // 
            this.textBox9.AcceptsTab = true;
            this.textBox9.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox9.Location = new System.Drawing.Point(683, 89);
            this.textBox9.MaxLength = 8;
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(100, 22);
            this.textBox9.TabIndex = 46;
            this.textBox9.Leave += new System.EventHandler(this.textBox9_Leave);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNEXIT,
            this.BTNFIND,
            this.BTNEXCEL,
            this.BTNPREVIEW});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(976, 25);
            this.toolStrip1.TabIndex = 59;
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
            // BTNFIND
            // 
            this.BTNFIND.Image = ((System.Drawing.Image)(resources.GetObject("BTNFIND.Image")));
            this.BTNFIND.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNFIND.Name = "BTNFIND";
            this.BTNFIND.Size = new System.Drawing.Size(52, 22);
            this.BTNFIND.Text = "查詢";
            this.BTNFIND.Click += new System.EventHandler(this.BTNFIND_Click);
            // 
            // BTNEXCEL
            // 
            this.BTNEXCEL.Image = ((System.Drawing.Image)(resources.GetObject("BTNEXCEL.Image")));
            this.BTNEXCEL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEXCEL.Name = "BTNEXCEL";
            this.BTNEXCEL.Size = new System.Drawing.Size(81, 22);
            this.BTNEXCEL.Text = "導出Excel";
            this.BTNEXCEL.Click += new System.EventHandler(this.BTNEXCEL_Click);
            // 
            // BTNPREVIEW
            // 
            this.BTNPREVIEW.Image = ((System.Drawing.Image)(resources.GetObject("BTNPREVIEW.Image")));
            this.BTNPREVIEW.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNPREVIEW.Name = "BTNPREVIEW";
            this.BTNPREVIEW.Size = new System.Drawing.Size(76, 22);
            this.BTNPREVIEW.Text = "打印預覽";
            this.BTNPREVIEW.Click += new System.EventHandler(this.BTNPREVIEW_Click);
            // 
            // frmInv01
            // 
            this.ClientSize = new System.Drawing.Size(976, 585);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.dateTimeBox2);
            this.Controls.Add(this.dateTimeBox1);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.textBox9);
            this.Name = "frmInv01";
            this.Load += new System.EventHandler(this.frmInv01_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn ivm1inv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ivm1dat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ivm2seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn ivm2mo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ivm2item;
        private System.Windows.Forms.DataGridViewTextBoxColumn inm1cdesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ivm2qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ivm2unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ivm2weg;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_sum;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty_pcs;
        private System.Windows.Forms.DataGridViewTextBoxColumn amt_hkd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ivm1cust;
        private System.Windows.Forms.DataGridViewTextBoxColumn cust_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ivm1owa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ivm1brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn ivm1sec;
        private System.Windows.Forms.DataGridViewTextBoxColumn cust_item;
        private System.Windows.Forms.DataGridViewTextBoxColumn po;
        private System.Windows.Forms.DataGridViewTextBoxColumn ocno;
        private System.Windows.Forms.DateTimePicker dateTimeBox2;
        private System.Windows.Forms.DateTimePicker dateTimeBox1;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripButton BTNFIND;
        private System.Windows.Forms.ToolStripButton BTNEXCEL;
        private System.Windows.Forms.ToolStripButton BTNPREVIEW;

        
    }
}
