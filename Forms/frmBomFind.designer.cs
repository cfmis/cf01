namespace cf01.Forms
{
    partial class frmBomFind
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBomFind));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNFIND = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNOK = new System.Windows.Forms.ToolStripButton();
            this.txtBom_id1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBom_id2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGoods_id2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGoods_id1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGoods_name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCreate_date1 = new DevExpress.XtraEditors.DateEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCreate_date2 = new DevExpress.XtraEditors.DateEdit();
            this.txtCheck_date2 = new DevExpress.XtraEditors.DateEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCheck_date1 = new DevExpress.XtraEditors.DateEdit();
            this.txtDetp_id1 = new DevExpress.XtraEditors.LookUpEdit();
            this.txtDetp_id2 = new DevExpress.XtraEditors.LookUpEdit();
            this.dgvBomFind = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxState = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dept_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dept_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_date1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_date1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_date2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_date2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheck_date2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheck_date2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheck_date1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheck_date1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetp_id1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetp_id2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBomFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxState.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNEXIT,
            this.toolStripSeparator1,
            this.BTNFIND,
            this.toolStripSeparator2,
            this.BTNOK});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1012, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BTNEXIT
            // 
            this.BTNEXIT.Image = ((System.Drawing.Image)(resources.GetObject("BTNEXIT.Image")));
            this.BTNEXIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEXIT.Name = "BTNEXIT";
            this.BTNEXIT.Size = new System.Drawing.Size(65, 22);
            this.BTNEXIT.Text = "退出(&X)";
            this.BTNEXIT.Click += new System.EventHandler(this.BTNEXIT_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // BTNFIND
            // 
            this.BTNFIND.Image = ((System.Drawing.Image)(resources.GetObject("BTNFIND.Image")));
            this.BTNFIND.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNFIND.Name = "BTNFIND";
            this.BTNFIND.Size = new System.Drawing.Size(63, 22);
            this.BTNFIND.Text = "查詢(&F)";
            this.BTNFIND.Click += new System.EventHandler(this.BTNFIND_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // BTNOK
            // 
            this.BTNOK.Image = ((System.Drawing.Image)(resources.GetObject("BTNOK.Image")));
            this.BTNOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNOK.Name = "BTNOK";
            this.BTNOK.Size = new System.Drawing.Size(65, 22);
            this.BTNOK.Text = "確認(&O)";
            this.BTNOK.Click += new System.EventHandler(this.BTNOK_Click);
            // 
            // txtBom_id1
            // 
            this.txtBom_id1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBom_id1.Location = new System.Drawing.Point(103, 62);
            this.txtBom_id1.MaxLength = 21;
            this.txtBom_id1.Name = "txtBom_id1";
            this.txtBom_id1.Size = new System.Drawing.Size(209, 22);
            this.txtBom_id1.TabIndex = 2;
            this.txtBom_id1.Leave += new System.EventHandler(this.txtBom_id1_Leave);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(28, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bom ID編號";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBom_id2
            // 
            this.txtBom_id2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBom_id2.Location = new System.Drawing.Point(341, 62);
            this.txtBom_id2.MaxLength = 21;
            this.txtBom_id2.Name = "txtBom_id2";
            this.txtBom_id2.Size = new System.Drawing.Size(209, 22);
            this.txtBom_id2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(322, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "~";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(322, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "~";
            // 
            // txtGoods_id2
            // 
            this.txtGoods_id2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGoods_id2.Location = new System.Drawing.Point(341, 88);
            this.txtGoods_id2.MaxLength = 18;
            this.txtGoods_id2.Name = "txtGoods_id2";
            this.txtGoods_id2.Size = new System.Drawing.Size(209, 22);
            this.txtGoods_id2.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(28, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "貨品編號";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGoods_id1
            // 
            this.txtGoods_id1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGoods_id1.Location = new System.Drawing.Point(103, 88);
            this.txtGoods_id1.MaxLength = 18;
            this.txtGoods_id1.Name = "txtGoods_id1";
            this.txtGoods_id1.Size = new System.Drawing.Size(209, 22);
            this.txtGoods_id1.TabIndex = 4;
            this.txtGoods_id1.Leave += new System.EventHandler(this.txtGoods_id1_Leave);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(28, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "貨品名稱";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGoods_name
            // 
            this.txtGoods_name.Location = new System.Drawing.Point(103, 115);
            this.txtGoods_name.MaxLength = 50;
            this.txtGoods_name.Name = "txtGoods_name";
            this.txtGoods_name.Size = new System.Drawing.Size(447, 22);
            this.txtGoods_name.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(322, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "~";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(28, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "部門編號";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(28, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "建檔日期";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(28, 171);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "批准日期";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCreate_date1
            // 
            this.txtCreate_date1.EditValue = null;
            this.txtCreate_date1.Location = new System.Drawing.Point(103, 141);
            this.txtCreate_date1.Name = "txtCreate_date1";
            this.txtCreate_date1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtCreate_date1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtCreate_date1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtCreate_date1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtCreate_date1.Size = new System.Drawing.Size(209, 22);
            this.txtCreate_date1.TabIndex = 7;
            this.txtCreate_date1.Leave += new System.EventHandler(this.txtCreate_date1_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(321, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 21;
            this.label11.Text = "~";
            // 
            // txtCreate_date2
            // 
            this.txtCreate_date2.EditValue = null;
            this.txtCreate_date2.Location = new System.Drawing.Point(341, 141);
            this.txtCreate_date2.Name = "txtCreate_date2";
            this.txtCreate_date2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtCreate_date2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtCreate_date2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtCreate_date2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtCreate_date2.Size = new System.Drawing.Size(209, 22);
            this.txtCreate_date2.TabIndex = 8;
            this.txtCreate_date2.Leave += new System.EventHandler(this.txtCreate_date2_Leave);
            // 
            // txtCheck_date2
            // 
            this.txtCheck_date2.EditValue = null;
            this.txtCheck_date2.Location = new System.Drawing.Point(341, 167);
            this.txtCheck_date2.Name = "txtCheck_date2";
            this.txtCheck_date2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtCheck_date2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtCheck_date2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtCheck_date2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtCheck_date2.Size = new System.Drawing.Size(209, 22);
            this.txtCheck_date2.TabIndex = 10;
            this.txtCheck_date2.Leave += new System.EventHandler(this.txtCheck_date2_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(321, 171);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 12);
            this.label12.TabIndex = 24;
            this.label12.Text = "~";
            // 
            // txtCheck_date1
            // 
            this.txtCheck_date1.EditValue = null;
            this.txtCheck_date1.Location = new System.Drawing.Point(103, 167);
            this.txtCheck_date1.Name = "txtCheck_date1";
            this.txtCheck_date1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtCheck_date1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtCheck_date1.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtCheck_date1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtCheck_date1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtCheck_date1.Size = new System.Drawing.Size(209, 22);
            this.txtCheck_date1.TabIndex = 9;
            this.txtCheck_date1.Leave += new System.EventHandler(this.txtCheck_date1_Leave);
            // 
            // txtDetp_id1
            // 
            this.txtDetp_id1.EditValue = "";
            this.txtDetp_id1.Location = new System.Drawing.Point(103, 35);
            this.txtDetp_id1.Name = "txtDetp_id1";
            this.txtDetp_id1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtDetp_id1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDetp_id1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDetp_id1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dep_id", 80, "部門編號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dep_cdesc", 150, "部門名稱")});
            this.txtDetp_id1.Properties.DropDownRows = 15;
            this.txtDetp_id1.Properties.MaxLength = 3;
            this.txtDetp_id1.Properties.NullText = "";
            this.txtDetp_id1.Properties.PopupFormMinSize = new System.Drawing.Size(230, 0);
            this.txtDetp_id1.Properties.PopupWidth = 230;
            this.txtDetp_id1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtDetp_id1.Size = new System.Drawing.Size(209, 22);
            this.txtDetp_id1.TabIndex = 0;
            this.txtDetp_id1.Tag = "2";
            this.txtDetp_id1.Click += new System.EventHandler(this.txtDetp_id1_Click);
            this.txtDetp_id1.Leave += new System.EventHandler(this.txtDetp_id1_Leave);
            // 
            // txtDetp_id2
            // 
            this.txtDetp_id2.EditValue = "";
            this.txtDetp_id2.Location = new System.Drawing.Point(341, 35);
            this.txtDetp_id2.Name = "txtDetp_id2";
            this.txtDetp_id2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtDetp_id2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDetp_id2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDetp_id2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dep_id", 80, "部門編號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dep_cdesc", 150, "部門名稱")});
            this.txtDetp_id2.Properties.DropDownRows = 15;
            this.txtDetp_id2.Properties.MaxLength = 3;
            this.txtDetp_id2.Properties.NullText = "";
            this.txtDetp_id2.Properties.PopupFormMinSize = new System.Drawing.Size(230, 0);
            this.txtDetp_id2.Properties.PopupWidth = 230;
            this.txtDetp_id2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtDetp_id2.Size = new System.Drawing.Size(209, 22);
            this.txtDetp_id2.TabIndex = 1;
            this.txtDetp_id2.Tag = "2";
            this.txtDetp_id2.Click += new System.EventHandler(this.txtDetp_id2_Click);
            // 
            // dgvBomFind
            // 
            this.dgvBomFind.AllowUserToAddRows = false;
            this.dgvBomFind.AllowUserToDeleteRows = false;
            this.dgvBomFind.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBomFind.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBomFind.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.goods_id,
            this.name,
            this.dept_id,
            this.dept_name,
            this.Create_date,
            this.check_date,
            this.state});
            this.dgvBomFind.Location = new System.Drawing.Point(2, 221);
            this.dgvBomFind.MultiSelect = false;
            this.dgvBomFind.Name = "dgvBomFind";
            this.dgvBomFind.ReadOnly = true;
            this.dgvBomFind.RowTemplate.Height = 24;
            this.dgvBomFind.Size = new System.Drawing.Size(1011, 354);
            this.dgvBomFind.TabIndex = 28;
            this.dgvBomFind.SelectionChanged += new System.EventHandler(this.dgvBomFind_SelectionChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(28, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 12);
            this.label5.TabIndex = 29;
            this.label5.Text = "批準狀態";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxState
            // 
            this.cbxState.Location = new System.Drawing.Point(103, 194);
            this.cbxState.Name = "cbxState";
            this.cbxState.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.cbxState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxState.Properties.Items.AddRange(new object[] {
            "",
            "0 -- 未批準",
            "1 -- 已批準"});
            this.cbxState.Size = new System.Drawing.Size(209, 22);
            this.cbxState.TabIndex = 30;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.FillWeight = 180F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Bom ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 180;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "goods_id";
            this.dataGridViewTextBoxColumn2.FillWeight = 170F;
            this.dataGridViewTextBoxColumn2.HeaderText = "貨品編號";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 170;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn3.FillWeight = 200F;
            this.dataGridViewTextBoxColumn3.HeaderText = "貨品名稱";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "dept_id";
            this.dataGridViewTextBoxColumn4.FillWeight = 60F;
            this.dataGridViewTextBoxColumn4.HeaderText = "部門";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "dept_name";
            this.dataGridViewTextBoxColumn5.FillWeight = 130F;
            this.dataGridViewTextBoxColumn5.HeaderText = "部門名稱";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Create_date";
            this.dataGridViewTextBoxColumn6.HeaderText = "建檔日期";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 120;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "check_date";
            this.dataGridViewTextBoxColumn7.HeaderText = "批準日期";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 120;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "state";
            this.dataGridViewTextBoxColumn8.HeaderText = "批準狀態";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 80;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.FillWeight = 160F;
            this.id.HeaderText = "Bom ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 160;
            // 
            // goods_id
            // 
            this.goods_id.DataPropertyName = "goods_id";
            this.goods_id.FillWeight = 150F;
            this.goods_id.HeaderText = "貨品編號";
            this.goods_id.Name = "goods_id";
            this.goods_id.ReadOnly = true;
            this.goods_id.Width = 150;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.FillWeight = 200F;
            this.name.HeaderText = "貨品名稱";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 200;
            // 
            // dept_id
            // 
            this.dept_id.DataPropertyName = "dept_id";
            this.dept_id.FillWeight = 55F;
            this.dept_id.HeaderText = "部門";
            this.dept_id.Name = "dept_id";
            this.dept_id.ReadOnly = true;
            this.dept_id.Width = 55;
            // 
            // dept_name
            // 
            this.dept_name.DataPropertyName = "dept_name";
            this.dept_name.FillWeight = 80F;
            this.dept_name.HeaderText = "部門名稱";
            this.dept_name.Name = "dept_name";
            this.dept_name.ReadOnly = true;
            this.dept_name.Width = 80;
            // 
            // Create_date
            // 
            this.Create_date.DataPropertyName = "Create_date";
            this.Create_date.HeaderText = "建檔日期";
            this.Create_date.Name = "Create_date";
            this.Create_date.ReadOnly = true;
            this.Create_date.Width = 120;
            // 
            // check_date
            // 
            this.check_date.DataPropertyName = "check_date";
            this.check_date.HeaderText = "批準日期";
            this.check_date.Name = "check_date";
            this.check_date.ReadOnly = true;
            this.check_date.Width = 120;
            // 
            // state
            // 
            this.state.DataPropertyName = "state";
            this.state.HeaderText = "批準狀態";
            this.state.Name = "state";
            this.state.ReadOnly = true;
            this.state.Width = 80;
            // 
            // frmBomFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 574);
            this.Controls.Add(this.cbxState);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvBomFind);
            this.Controls.Add(this.txtDetp_id2);
            this.Controls.Add(this.txtDetp_id1);
            this.Controls.Add(this.txtCheck_date2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtCheck_date1);
            this.Controls.Add(this.txtCreate_date2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCreate_date1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtGoods_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtGoods_id2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtGoods_id1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBom_id2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBom_id1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmBomFind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查詢";
            this.Load += new System.EventHandler(this.frmBomFind_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_date1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_date1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_date2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_date2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheck_date2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheck_date2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheck_date1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheck_date1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetp_id1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetp_id2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBomFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxState.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BTNFIND;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton BTNOK;
        private System.Windows.Forms.TextBox txtBom_id1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBom_id2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGoods_id2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGoods_id1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGoods_name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.DateEdit txtCreate_date1;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraEditors.DateEdit txtCreate_date2;
        private DevExpress.XtraEditors.DateEdit txtCheck_date2;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.DateEdit txtCheck_date1;
        private DevExpress.XtraEditors.LookUpEdit txtDetp_id1;
        private DevExpress.XtraEditors.LookUpEdit txtDetp_id2;
        private System.Windows.Forms.DataGridView dgvBomFind;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.ComboBoxEdit cbxState;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dept_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dept_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn check_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
    }
}