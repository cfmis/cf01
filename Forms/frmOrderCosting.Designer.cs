namespace cf01.Forms
{
    partial class frmOrderCosting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderCosting));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.rdbIsCosting = new System.Windows.Forms.RadioButton();
            this.rdbNoCosting = new System.Windows.Forms.RadioButton();
            this.txtItem_to = new DevExpress.XtraEditors.TextEdit();
            this.txtItem_from = new DevExpress.XtraEditors.TextEdit();
            this.txtMo_to = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtMo_from = new DevExpress.XtraEditors.TextEdit();
            this.lblPrd_mo = new DevExpress.XtraEditors.LabelControl();
            this.txtDate_to = new DevExpress.XtraEditors.TextEdit();
            this.txtDate_from = new DevExpress.XtraEditors.TextEdit();
            this.lblOrder_date = new DevExpress.XtraEditors.LabelControl();
            this.dgvOrderCosting = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMo_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGoods_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGoods_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMmCosting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmt_hkd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmt_def = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmt_def_per = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty_pcs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrder_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGoods_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnit_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colP_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCust_cname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem_to.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem_from.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_to.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_from.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate_to.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate_from.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderCosting)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.toolStripSeparator1,
            this.btnFind,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(865, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnExit
            // 
            this.btnExit.AutoSize = false;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(65, 35);
            this.btnExit.Text = "退出(&X)";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // btnFind
            // 
            this.btnFind.AutoSize = false;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(65, 35);
            this.btnFind.Text = "查詢(&F)";
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panel1);
            this.panelControl1.Controls.Add(this.txtItem_to);
            this.panelControl1.Controls.Add(this.txtItem_from);
            this.panelControl1.Controls.Add(this.txtMo_to);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtMo_from);
            this.panelControl1.Controls.Add(this.lblPrd_mo);
            this.panelControl1.Controls.Add(this.txtDate_to);
            this.panelControl1.Controls.Add(this.txtDate_from);
            this.panelControl1.Controls.Add(this.lblOrder_date);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 38);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(865, 100);
            this.panelControl1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rdbAll);
            this.panel1.Controls.Add(this.rdbIsCosting);
            this.panel1.Controls.Add(this.rdbNoCosting);
            this.panel1.Location = new System.Drawing.Point(446, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 29);
            this.panel1.TabIndex = 9;
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Location = new System.Drawing.Point(203, 7);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(47, 16);
            this.rdbAll.TabIndex = 10;
            this.rdbAll.Text = "所有";
            this.rdbAll.UseVisualStyleBackColor = true;
            // 
            // rdbIsCosting
            // 
            this.rdbIsCosting.AutoSize = true;
            this.rdbIsCosting.Checked = true;
            this.rdbIsCosting.Location = new System.Drawing.Point(11, 7);
            this.rdbIsCosting.Name = "rdbIsCosting";
            this.rdbIsCosting.Size = new System.Drawing.Size(83, 16);
            this.rdbIsCosting.TabIndex = 9;
            this.rdbIsCosting.TabStop = true;
            this.rdbIsCosting.Text = "已設定成本";
            this.rdbIsCosting.UseVisualStyleBackColor = true;
            // 
            // rdbNoCosting
            // 
            this.rdbNoCosting.AutoSize = true;
            this.rdbNoCosting.Location = new System.Drawing.Point(100, 7);
            this.rdbNoCosting.Name = "rdbNoCosting";
            this.rdbNoCosting.Size = new System.Drawing.Size(83, 16);
            this.rdbNoCosting.TabIndex = 8;
            this.rdbNoCosting.Text = "未設定成本";
            this.rdbNoCosting.UseVisualStyleBackColor = true;
            // 
            // txtItem_to
            // 
            this.txtItem_to.Location = new System.Drawing.Point(237, 41);
            this.txtItem_to.Name = "txtItem_to";
            this.txtItem_to.Size = new System.Drawing.Size(144, 20);
            this.txtItem_to.TabIndex = 5;
            // 
            // txtItem_from
            // 
            this.txtItem_from.Location = new System.Drawing.Point(87, 41);
            this.txtItem_from.Name = "txtItem_from";
            this.txtItem_from.Size = new System.Drawing.Size(144, 20);
            this.txtItem_from.TabIndex = 4;
            this.txtItem_from.Leave += new System.EventHandler(this.txtItem_from_Leave);
            // 
            // txtMo_to
            // 
            this.txtMo_to.Location = new System.Drawing.Point(603, 15);
            this.txtMo_to.Name = "txtMo_to";
            this.txtMo_to.Size = new System.Drawing.Size(144, 20);
            this.txtMo_to.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(30, 44);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "產品編號:";
            // 
            // txtMo_from
            // 
            this.txtMo_from.Location = new System.Drawing.Point(446, 15);
            this.txtMo_from.Name = "txtMo_from";
            this.txtMo_from.Size = new System.Drawing.Size(144, 20);
            this.txtMo_from.TabIndex = 2;
            this.txtMo_from.Leave += new System.EventHandler(this.txtMo_from_Leave);
            // 
            // lblPrd_mo
            // 
            this.lblPrd_mo.Location = new System.Drawing.Point(389, 18);
            this.lblPrd_mo.Name = "lblPrd_mo";
            this.lblPrd_mo.Size = new System.Drawing.Size(52, 14);
            this.lblPrd_mo.TabIndex = 5;
            this.lblPrd_mo.Text = "制單編號:";
            // 
            // txtDate_to
            // 
            this.txtDate_to.Location = new System.Drawing.Point(237, 15);
            this.txtDate_to.Name = "txtDate_to";
            this.txtDate_to.Properties.Mask.EditMask = "9999/99/99";
            this.txtDate_to.Size = new System.Drawing.Size(144, 20);
            this.txtDate_to.TabIndex = 1;
            // 
            // txtDate_from
            // 
            this.txtDate_from.Location = new System.Drawing.Point(87, 15);
            this.txtDate_from.Name = "txtDate_from";
            this.txtDate_from.Properties.Mask.EditMask = "9999/99/99";
            this.txtDate_from.Size = new System.Drawing.Size(144, 20);
            this.txtDate_from.TabIndex = 0;
            this.txtDate_from.Leave += new System.EventHandler(this.txtDate_from_Leave);
            // 
            // lblOrder_date
            // 
            this.lblOrder_date.Location = new System.Drawing.Point(30, 18);
            this.lblOrder_date.Name = "lblOrder_date";
            this.lblOrder_date.Size = new System.Drawing.Size(52, 14);
            this.lblOrder_date.TabIndex = 2;
            this.lblOrder_date.Text = "訂單日期:";
            // 
            // dgvOrderCosting
            // 
            this.dgvOrderCosting.AllowUserToAddRows = false;
            this.dgvOrderCosting.ColumnHeadersHeight = 25;
            this.dgvOrderCosting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOrderCosting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMo_id,
            this.colGoods_id,
            this.colGoods_name,
            this.colMmCosting,
            this.colAmt_hkd,
            this.colAmt_def,
            this.colAmt_def_per,
            this.colQty_pcs,
            this.colOrder_qty,
            this.colGoods_unit,
            this.colUnit_price,
            this.colP_unit,
            this.colMid,
            this.colOrderDate,
            this.colCust,
            this.colCust_cname,
            this.colBrand});
            this.dgvOrderCosting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderCosting.Location = new System.Drawing.Point(0, 138);
            this.dgvOrderCosting.Name = "dgvOrderCosting";
            this.dgvOrderCosting.RowHeadersWidth = 20;
            this.dgvOrderCosting.RowTemplate.Height = 24;
            this.dgvOrderCosting.Size = new System.Drawing.Size(865, 421);
            this.dgvOrderCosting.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "mo_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "制單編號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "goods_id";
            this.dataGridViewTextBoxColumn2.HeaderText = "產品編號";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 160;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "goods_cname";
            this.dataGridViewTextBoxColumn3.HeaderText = "產品描述";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 180;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "qty_pcs";
            this.dataGridViewTextBoxColumn4.HeaderText = "數量(PCS)";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "amt_hkd";
            this.dataGridViewTextBoxColumn5.HeaderText = "成本价";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "amt_hkd";
            this.dataGridViewTextBoxColumn6.HeaderText = "金額(HKD)";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "qty_pcs";
            this.dataGridViewTextBoxColumn7.HeaderText = "金額對比";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "order_qty";
            this.dataGridViewTextBoxColumn8.HeaderText = "訂單數量";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "goods_unit";
            this.dataGridViewTextBoxColumn9.HeaderText = "數量單位";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 80;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "unit_price";
            this.dataGridViewTextBoxColumn10.HeaderText = "訂單單價";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 80;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "p_unit";
            this.dataGridViewTextBoxColumn11.HeaderText = "單價單位";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 80;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "m_id";
            this.dataGridViewTextBoxColumn12.HeaderText = "貨幣代號";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 80;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "order_date";
            this.dataGridViewTextBoxColumn13.HeaderText = "訂單日期";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Width = 80;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "it_customer";
            this.dataGridViewTextBoxColumn14.HeaderText = "客戶編號";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Width = 80;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "cust_cname";
            this.dataGridViewTextBoxColumn15.HeaderText = "客戶描述";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.Width = 180;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "brand_id";
            this.dataGridViewTextBoxColumn16.HeaderText = "牌子編號";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Width = 180;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "brand_id";
            this.dataGridViewTextBoxColumn17.HeaderText = "牌子編號";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            // 
            // colMo_id
            // 
            this.colMo_id.DataPropertyName = "mo_id";
            this.colMo_id.HeaderText = "制單編號";
            this.colMo_id.Name = "colMo_id";
            // 
            // colGoods_id
            // 
            this.colGoods_id.DataPropertyName = "goods_id";
            this.colGoods_id.HeaderText = "產品編號";
            this.colGoods_id.Name = "colGoods_id";
            this.colGoods_id.Width = 160;
            // 
            // colGoods_name
            // 
            this.colGoods_name.DataPropertyName = "goods_name";
            this.colGoods_name.HeaderText = "產品描述";
            this.colGoods_name.Name = "colGoods_name";
            this.colGoods_name.Width = 180;
            // 
            // colMmCosting
            // 
            this.colMmCosting.DataPropertyName = "mmcosting";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.colMmCosting.DefaultCellStyle = dataGridViewCellStyle1;
            this.colMmCosting.HeaderText = "成本价";
            this.colMmCosting.Name = "colMmCosting";
            // 
            // colAmt_hkd
            // 
            this.colAmt_hkd.DataPropertyName = "amt_hkd";
            this.colAmt_hkd.HeaderText = "金額(HKD)";
            this.colAmt_hkd.Name = "colAmt_hkd";
            // 
            // colAmt_def
            // 
            this.colAmt_def.DataPropertyName = "amt_def";
            this.colAmt_def.HeaderText = "金額對比(HKD)";
            this.colAmt_def.Name = "colAmt_def";
            // 
            // colAmt_def_per
            // 
            this.colAmt_def_per.DataPropertyName = "amt_def_per";
            this.colAmt_def_per.HeaderText = "差額百分比(%)";
            this.colAmt_def_per.Name = "colAmt_def_per";
            // 
            // colQty_pcs
            // 
            this.colQty_pcs.DataPropertyName = "qty_pcs";
            this.colQty_pcs.HeaderText = "數量(PCS)";
            this.colQty_pcs.Name = "colQty_pcs";
            // 
            // colOrder_qty
            // 
            this.colOrder_qty.DataPropertyName = "order_qty";
            this.colOrder_qty.HeaderText = "訂單數量";
            this.colOrder_qty.Name = "colOrder_qty";
            // 
            // colGoods_unit
            // 
            this.colGoods_unit.DataPropertyName = "goods_unit";
            this.colGoods_unit.HeaderText = "數量單位";
            this.colGoods_unit.Name = "colGoods_unit";
            this.colGoods_unit.Width = 80;
            // 
            // colUnit_price
            // 
            this.colUnit_price.DataPropertyName = "unit_price";
            this.colUnit_price.HeaderText = "訂單單價";
            this.colUnit_price.Name = "colUnit_price";
            this.colUnit_price.Width = 80;
            // 
            // colP_unit
            // 
            this.colP_unit.DataPropertyName = "p_unit";
            this.colP_unit.HeaderText = "單價單位";
            this.colP_unit.Name = "colP_unit";
            this.colP_unit.Width = 80;
            // 
            // colMid
            // 
            this.colMid.DataPropertyName = "m_id";
            this.colMid.HeaderText = "貨幣代號";
            this.colMid.Name = "colMid";
            this.colMid.Width = 80;
            // 
            // colOrderDate
            // 
            this.colOrderDate.DataPropertyName = "order_date";
            this.colOrderDate.HeaderText = "訂單日期";
            this.colOrderDate.Name = "colOrderDate";
            this.colOrderDate.Width = 80;
            // 
            // colCust
            // 
            this.colCust.DataPropertyName = "it_customer";
            this.colCust.HeaderText = "客戶編號";
            this.colCust.Name = "colCust";
            // 
            // colCust_cname
            // 
            this.colCust_cname.DataPropertyName = "cust_cname";
            this.colCust_cname.HeaderText = "客戶描述";
            this.colCust_cname.Name = "colCust_cname";
            this.colCust_cname.Width = 180;
            // 
            // colBrand
            // 
            this.colBrand.DataPropertyName = "brand_id";
            this.colBrand.HeaderText = "牌子編號";
            this.colBrand.Name = "colBrand";
            // 
            // frmOrderCosting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 559);
            this.Controls.Add(this.dgvOrderCosting);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmOrderCosting";
            this.Text = "frmOrderCosting";
            this.Load += new System.EventHandler(this.frmOrderCosting_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem_to.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem_from.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_to.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_from.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate_to.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate_from.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderCosting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.DataGridView dgvOrderCosting;
        private DevExpress.XtraEditors.TextEdit txtDate_to;
        private DevExpress.XtraEditors.TextEdit txtDate_from;
        private DevExpress.XtraEditors.LabelControl lblOrder_date;
        private DevExpress.XtraEditors.TextEdit txtMo_to;
        private DevExpress.XtraEditors.TextEdit txtMo_from;
        private DevExpress.XtraEditors.LabelControl lblPrd_mo;
        private DevExpress.XtraEditors.TextEdit txtItem_to;
        private DevExpress.XtraEditors.TextEdit txtItem_from;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.RadioButton rdbIsCosting;
        private System.Windows.Forms.RadioButton rdbNoCosting;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMo_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGoods_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGoods_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMmCosting;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmt_hkd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmt_def;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmt_def_per;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty_pcs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrder_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGoods_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnit_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn colP_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCust;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCust_cname;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrand;
    }
}