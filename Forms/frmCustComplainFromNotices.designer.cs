namespace cf01.Forms
{
    partial class frmCustComplainFromNotices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustComplainFromNotices));
            this.btnConfirm = new System.Windows.Forms.Button();
            this.dgvNotices = new System.Windows.Forms.DataGridView();
            this.txtMo_id1 = new System.Windows.Forms.TextBox();
            this.txtMo_id2 = new System.Windows.Forms.TextBox();
            this.txtCust1 = new System.Windows.Forms.TextBox();
            this.txtNotice_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCust2 = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtDate2 = new DevExpress.XtraEditors.DateEdit();
            this.dtDate1 = new DevExpress.XtraEditors.DateEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
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
            this.ref_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bill_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customer_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seller_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.new_mo_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mo_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oc_info = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sequence_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.create_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.create_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotices)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirm.Image")));
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirm.Location = new System.Drawing.Point(504, 46);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(72, 30);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "確 定  ";
            this.btnConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // dgvNotices
            // 
            this.dgvNotices.AllowUserToAddRows = false;
            this.dgvNotices.AllowUserToDeleteRows = false;
            this.dgvNotices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNotices.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvNotices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ref_id,
            this.bill_date,
            this.customer_id,
            this.seller_id,
            this.remark,
            this.new_mo_id,
            this.mo_id,
            this.goods_id,
            this.goods_name,
            this.order_qty,
            this.unit_code,
            this.oc_info,
            this.sequence_id,
            this.create_by,
            this.create_date});
            this.dgvNotices.Location = new System.Drawing.Point(6, 135);
            this.dgvNotices.Name = "dgvNotices";
            this.dgvNotices.ReadOnly = true;
            this.dgvNotices.RowHeadersWidth = 25;
            this.dgvNotices.RowTemplate.Height = 24;
            this.dgvNotices.Size = new System.Drawing.Size(734, 578);
            this.dgvNotices.TabIndex = 1;
            this.dgvNotices.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvNotices_RowPrePaint);
            this.dgvNotices.SelectionChanged += new System.EventHandler(this.dgvNotices_SelectionChanged);
            // 
            // txtMo_id1
            // 
            this.txtMo_id1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo_id1.Location = new System.Drawing.Point(138, 15);
            this.txtMo_id1.MaxLength = 9;
            this.txtMo_id1.Name = "txtMo_id1";
            this.txtMo_id1.Size = new System.Drawing.Size(100, 22);
            this.txtMo_id1.TabIndex = 0;
            this.txtMo_id1.Leave += new System.EventHandler(this.txtMo_id1_Leave);
            // 
            // txtMo_id2
            // 
            this.txtMo_id2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo_id2.Location = new System.Drawing.Point(266, 15);
            this.txtMo_id2.MaxLength = 9;
            this.txtMo_id2.Name = "txtMo_id2";
            this.txtMo_id2.Size = new System.Drawing.Size(100, 22);
            this.txtMo_id2.TabIndex = 1;
            // 
            // txtCust1
            // 
            this.txtCust1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCust1.Location = new System.Drawing.Point(138, 43);
            this.txtCust1.MaxLength = 10;
            this.txtCust1.Name = "txtCust1";
            this.txtCust1.Size = new System.Drawing.Size(100, 22);
            this.txtCust1.TabIndex = 2;
            this.txtCust1.Leave += new System.EventHandler(this.txtCust1_Leave);
            // 
            // txtNotice_id
            // 
            this.txtNotice_id.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNotice_id.Location = new System.Drawing.Point(137, 97);
            this.txtNotice_id.MaxLength = 20;
            this.txtNotice_id.Name = "txtNotice_id";
            this.txtNotice_id.Size = new System.Drawing.Size(229, 22);
            this.txtNotice_id.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "制單更改通知單編號";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "客戶編號";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "頁數";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(244, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "~";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(244, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "~";
            // 
            // txtCust2
            // 
            this.txtCust2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCust2.Location = new System.Drawing.Point(266, 43);
            this.txtCust2.MaxLength = 10;
            this.txtCust2.Name = "txtCust2";
            this.txtCust2.Size = new System.Drawing.Size(100, 22);
            this.txtCust2.TabIndex = 3;
            // 
            // btnFind
            // 
            this.btnFind.Image = global::cf01.Properties.Resources.find;
            this.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFind.Location = new System.Drawing.Point(396, 46);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(72, 30);
            this.btnFind.TabIndex = 7;
            this.btnFind.Text = "查 找 ";
            this.btnFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = global::cf01.Properties.Resources.exit;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(608, 46);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 30);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "關 閉  ";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dtDate2);
            this.groupBox1.Controls.Add(this.dtDate1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtMo_id1);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnConfirm);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.txtMo_id2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCust1);
            this.groupBox1.Controls.Add(this.txtCust2);
            this.groupBox1.Controls.Add(this.txtNotice_id);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(734, 128);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // dtDate2
            // 
            this.dtDate2.EditValue = "";
            this.dtDate2.EnterMoveNextControl = true;
            this.dtDate2.Location = new System.Drawing.Point(266, 70);
            this.dtDate2.Name = "dtDate2";
            this.dtDate2.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.dtDate2.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.dtDate2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.dtDate2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDate2.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dtDate2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtDate2.Properties.Mask.BeepOnError = true;
            this.dtDate2.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dtDate2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtDate2.Properties.MaxLength = 10;
            this.dtDate2.Properties.NullDate = "";
            this.dtDate2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtDate2.Size = new System.Drawing.Size(100, 22);
            this.dtDate2.TabIndex = 5;
            this.dtDate2.Tag = "2";
            // 
            // dtDate1
            // 
            this.dtDate1.EditValue = "";
            this.dtDate1.EnterMoveNextControl = true;
            this.dtDate1.Location = new System.Drawing.Point(138, 70);
            this.dtDate1.Name = "dtDate1";
            this.dtDate1.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.dtDate1.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.dtDate1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.dtDate1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDate1.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dtDate1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtDate1.Properties.Mask.BeepOnError = true;
            this.dtDate1.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dtDate1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtDate1.Properties.MaxLength = 10;
            this.dtDate1.Properties.NullDate = "";
            this.dtDate1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtDate1.Size = new System.Drawing.Size(100, 22);
            this.dtDate1.TabIndex = 4;
            this.dtDate1.Tag = "2";
            this.dtDate1.Leave += new System.EventHandler(this.dtDate1_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(103, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "日期";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(244, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "~";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "測試項目";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "cdesc";
            this.dataGridViewTextBoxColumn2.HeaderText = "測試名稱";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "edesc";
            this.dataGridViewTextBoxColumn3.HeaderText = "測試名稱(英文)";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "seller_id";
            this.dataGridViewTextBoxColumn4.HeaderText = "銷售代碼";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "remark";
            this.dataGridViewTextBoxColumn5.HeaderText = "備註";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "new_mo_id";
            this.dataGridViewTextBoxColumn6.HeaderText = "新頁數";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "mo_id";
            this.dataGridViewTextBoxColumn7.HeaderText = "頁數";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "goods_id";
            this.dataGridViewTextBoxColumn8.HeaderText = "貨品代碼";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn8.Width = 130;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "goods_name";
            this.dataGridViewTextBoxColumn9.HeaderText = "貨品描述";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn9.Width = 200;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "order_qty";
            this.dataGridViewTextBoxColumn10.HeaderText = "訂單數量";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "unit_code";
            this.dataGridViewTextBoxColumn11.HeaderText = "單位";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn11.Width = 60;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "oc_info";
            this.dataGridViewTextBoxColumn12.HeaderText = "OC編號";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ref_id
            // 
            this.ref_id.DataPropertyName = "ref_id";
            this.ref_id.HeaderText = "更改通知單號";
            this.ref_id.Name = "ref_id";
            this.ref_id.ReadOnly = true;
            this.ref_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ref_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ref_id.Width = 120;
            // 
            // bill_date
            // 
            this.bill_date.DataPropertyName = "bill_date";
            this.bill_date.HeaderText = "日期";
            this.bill_date.Name = "bill_date";
            this.bill_date.ReadOnly = true;
            this.bill_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // customer_id
            // 
            this.customer_id.DataPropertyName = "customer_id";
            this.customer_id.HeaderText = "客戶編號";
            this.customer_id.Name = "customer_id";
            this.customer_id.ReadOnly = true;
            this.customer_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // seller_id
            // 
            this.seller_id.DataPropertyName = "seller_id";
            this.seller_id.HeaderText = "銷售代碼";
            this.seller_id.Name = "seller_id";
            this.seller_id.ReadOnly = true;
            this.seller_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // remark
            // 
            this.remark.DataPropertyName = "remark";
            this.remark.HeaderText = "備註";
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            this.remark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // new_mo_id
            // 
            this.new_mo_id.DataPropertyName = "new_mo_id";
            this.new_mo_id.HeaderText = "新頁數";
            this.new_mo_id.Name = "new_mo_id";
            this.new_mo_id.ReadOnly = true;
            this.new_mo_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // mo_id
            // 
            this.mo_id.DataPropertyName = "mo_id";
            this.mo_id.HeaderText = "頁數";
            this.mo_id.Name = "mo_id";
            this.mo_id.ReadOnly = true;
            this.mo_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.mo_id.Width = 80;
            // 
            // goods_id
            // 
            this.goods_id.DataPropertyName = "goods_id";
            this.goods_id.HeaderText = "貨品代碼";
            this.goods_id.Name = "goods_id";
            this.goods_id.ReadOnly = true;
            this.goods_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.goods_id.Width = 130;
            // 
            // goods_name
            // 
            this.goods_name.DataPropertyName = "goods_name";
            this.goods_name.HeaderText = "貨品描述";
            this.goods_name.Name = "goods_name";
            this.goods_name.ReadOnly = true;
            this.goods_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.goods_name.Width = 200;
            // 
            // order_qty
            // 
            this.order_qty.DataPropertyName = "order_qty";
            this.order_qty.HeaderText = "訂單數量";
            this.order_qty.Name = "order_qty";
            this.order_qty.ReadOnly = true;
            this.order_qty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // unit_code
            // 
            this.unit_code.DataPropertyName = "unit_code";
            this.unit_code.HeaderText = "單位";
            this.unit_code.Name = "unit_code";
            this.unit_code.ReadOnly = true;
            this.unit_code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.unit_code.Width = 60;
            // 
            // oc_info
            // 
            this.oc_info.DataPropertyName = "oc_info";
            this.oc_info.HeaderText = "OC編號";
            this.oc_info.Name = "oc_info";
            this.oc_info.ReadOnly = true;
            this.oc_info.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // sequence_id
            // 
            this.sequence_id.DataPropertyName = "sequence_id";
            this.sequence_id.HeaderText = "sequence_id";
            this.sequence_id.Name = "sequence_id";
            this.sequence_id.ReadOnly = true;
            this.sequence_id.Visible = false;
            // 
            // create_by
            // 
            this.create_by.DataPropertyName = "create_by";
            this.create_by.HeaderText = "Create_by";
            this.create_by.Name = "create_by";
            this.create_by.ReadOnly = true;
            this.create_by.Visible = false;
            // 
            // create_date
            // 
            this.create_date.DataPropertyName = "create_date";
            this.create_date.HeaderText = "create_date";
            this.create_date.Name = "create_date";
            this.create_date.ReadOnly = true;
            this.create_date.Visible = false;
            // 
            // frmCustComplainFromNotices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 717);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvNotices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustComplainFromNotices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCustComplainFromNotices";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCustComplainFromNotices_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotices)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.DataGridView dgvNotices;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.TextBox txtMo_id1;
        private System.Windows.Forms.TextBox txtMo_id2;
        private System.Windows.Forms.TextBox txtCust1;
        private System.Windows.Forms.TextBox txtNotice_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCust2;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.DateEdit dtDate2;
        private DevExpress.XtraEditors.DateEdit dtDate1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ref_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn bill_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn seller_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn new_mo_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn mo_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn oc_info;
        private System.Windows.Forms.DataGridViewTextBoxColumn sequence_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn create_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn create_date;
    }
}