namespace cf01.Forms
{
    partial class frmMoScheduleDepGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMoScheduleDepGroup));
            this.lueDep = new DevExpress.XtraEditors.LookUpEdit();
            this.lblDepGroup = new System.Windows.Forms.Label();
            this.txtPrdMo = new DevExpress.XtraEditors.TextEdit();
            this.lblPrdMo = new DevExpress.XtraEditors.LabelControl();
            this.txtPrdItem = new DevExpress.XtraEditors.TextEdit();
            this.lblPrdItem = new DevExpress.XtraEditors.LabelControl();
            this.btnConf = new DevExpress.XtraEditors.SimpleButton();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPrdItemCdesc = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtRunNum = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtLineNum = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtStdQty = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtPrdMachine = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtPrdWorker = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtFindItem = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lueFindDep = new DevExpress.XtraEditors.LookUpEdit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPrdGroup = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnSetGoodsWeight = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
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
            this.colDepId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrdItemCdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrdGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHourRunNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLineNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHourStdQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrdMachine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrdWorker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrdMo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lueDep.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdMo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdItemCdesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRunNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStdQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdMachine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdWorker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFindItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueFindDep.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdGroup.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lueDep
            // 
            this.lueDep.EditValue = "";
            this.lueDep.Location = new System.Drawing.Point(106, 17);
            this.lueDep.Name = "lueDep";
            this.lueDep.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDep.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lueDep.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dep_id", 40, "部門代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dep_cdesc", 60, "部門描述")});
            this.lueDep.Properties.NullText = "";
            this.lueDep.Size = new System.Drawing.Size(121, 20);
            this.lueDep.TabIndex = 0;
            // 
            // lblDepGroup
            // 
            this.lblDepGroup.AutoSize = true;
            this.lblDepGroup.Location = new System.Drawing.Point(44, 19);
            this.lblDepGroup.Name = "lblDepGroup";
            this.lblDepGroup.Size = new System.Drawing.Size(56, 12);
            this.lblDepGroup.TabIndex = 26;
            this.lblDepGroup.Text = "生產車間:";
            // 
            // txtPrdMo
            // 
            this.txtPrdMo.Location = new System.Drawing.Point(106, 96);
            this.txtPrdMo.Name = "txtPrdMo";
            this.txtPrdMo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrdMo.Properties.MaxLength = 9;
            this.txtPrdMo.Size = new System.Drawing.Size(121, 20);
            this.txtPrdMo.TabIndex = 9;
            // 
            // lblPrdMo
            // 
            this.lblPrdMo.Location = new System.Drawing.Point(44, 99);
            this.lblPrdMo.Name = "lblPrdMo";
            this.lblPrdMo.Size = new System.Drawing.Size(52, 14);
            this.lblPrdMo.TabIndex = 28;
            this.lblPrdMo.Text = "制單編號:";
            // 
            // txtPrdItem
            // 
            this.txtPrdItem.Location = new System.Drawing.Point(302, 17);
            this.txtPrdItem.Name = "txtPrdItem";
            this.txtPrdItem.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrdItem.Properties.MaxLength = 18;
            this.txtPrdItem.Size = new System.Drawing.Size(203, 20);
            this.txtPrdItem.TabIndex = 1;
            this.txtPrdItem.Leave += new System.EventHandler(this.txtPrdItem_Leave);
            // 
            // lblPrdItem
            // 
            this.lblPrdItem.Location = new System.Drawing.Point(244, 17);
            this.lblPrdItem.Name = "lblPrdItem";
            this.lblPrdItem.Size = new System.Drawing.Size(52, 14);
            this.lblPrdItem.TabIndex = 28;
            this.lblPrdItem.Text = "物料編號:";
            // 
            // btnConf
            // 
            this.btnConf.Location = new System.Drawing.Point(1046, 63);
            this.btnConf.Name = "btnConf";
            this.btnConf.Size = new System.Drawing.Size(75, 23);
            this.btnConf.TabIndex = 29;
            this.btnConf.Text = "確定(&C)";
            this.btnConf.Click += new System.EventHandler(this.btnConf_Click);
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AllowUserToResizeColumns = false;
            this.dgvDetails.AllowUserToResizeRows = false;
            this.dgvDetails.ColumnHeadersHeight = 30;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDepId,
            this.colPrdItem,
            this.colPrdItemCdesc,
            this.colPrdGroup,
            this.colHourRunNum,
            this.colLineNum,
            this.colHourStdQty,
            this.colPrdMachine,
            this.colPrdWorker,
            this.colPrdMo});
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 215);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowHeadersWidth = 20;
            this.dgvDetails.RowTemplate.Height = 25;
            this.dgvDetails.Size = new System.Drawing.Size(1168, 385);
            this.dgvDetails.TabIndex = 31;
            this.dgvDetails.SelectionChanged += new System.EventHandler(this.dgvDetails_SelectionChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.toolStripSeparator1,
            this.btnNew,
            this.toolStripSeparator2,
            this.btnSave,
            this.toolStripSeparator3,
            this.btnSetGoodsWeight,
            this.toolStripSeparator4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1168, 38);
            this.toolStrip1.TabIndex = 32;
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
            // btnNew
            // 
            this.btnNew.AutoSize = false;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(65, 35);
            this.btnNew.Text = "新增(&A)";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 35);
            this.btnSave.Text = "儲存(&S)";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelControl5);
            this.panel1.Controls.Add(this.labelControl8);
            this.panel1.Controls.Add(this.labelControl6);
            this.panel1.Controls.Add(this.labelControl4);
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.txtPrdMachine);
            this.panel1.Controls.Add(this.txtPrdGroup);
            this.panel1.Controls.Add(this.txtPrdWorker);
            this.panel1.Controls.Add(this.txtStdQty);
            this.panel1.Controls.Add(this.txtLineNum);
            this.panel1.Controls.Add(this.txtRunNum);
            this.panel1.Controls.Add(this.txtPrdItemCdesc);
            this.panel1.Controls.Add(this.lueDep);
            this.panel1.Controls.Add(this.lblDepGroup);
            this.panel1.Controls.Add(this.txtPrdMo);
            this.panel1.Controls.Add(this.btnConf);
            this.panel1.Controls.Add(this.txtPrdItem);
            this.panel1.Controls.Add(this.lblPrdItem);
            this.panel1.Controls.Add(this.lblPrdMo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1168, 122);
            this.panel1.TabIndex = 33;
            // 
            // txtPrdItemCdesc
            // 
            this.txtPrdItemCdesc.Location = new System.Drawing.Point(591, 17);
            this.txtPrdItemCdesc.Name = "txtPrdItemCdesc";
            this.txtPrdItemCdesc.Properties.ReadOnly = true;
            this.txtPrdItemCdesc.Size = new System.Drawing.Size(331, 20);
            this.txtPrdItemCdesc.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(529, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 31;
            this.labelControl1.Text = "物料描述:";
            // 
            // txtRunNum
            // 
            this.txtRunNum.Location = new System.Drawing.Point(106, 43);
            this.txtRunNum.Name = "txtRunNum";
            this.txtRunNum.Size = new System.Drawing.Size(121, 20);
            this.txtRunNum.TabIndex = 3;
            this.txtRunNum.Leave += new System.EventHandler(this.txtRunNum_Leave);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(48, 46);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 31;
            this.labelControl2.Text = "標準轉數:";
            // 
            // txtLineNum
            // 
            this.txtLineNum.Location = new System.Drawing.Point(302, 43);
            this.txtLineNum.Name = "txtLineNum";
            this.txtLineNum.Size = new System.Drawing.Size(121, 20);
            this.txtLineNum.TabIndex = 4;
            this.txtLineNum.Leave += new System.EventHandler(this.txtLineNum_Leave);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(256, 46);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(40, 14);
            this.labelControl3.TabIndex = 31;
            this.labelControl3.Text = "每碑數:";
            // 
            // txtStdQty
            // 
            this.txtStdQty.Location = new System.Drawing.Point(591, 43);
            this.txtStdQty.Name = "txtStdQty";
            this.txtStdQty.Size = new System.Drawing.Size(121, 20);
            this.txtStdQty.TabIndex = 5;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(529, 46);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(52, 14);
            this.labelControl4.TabIndex = 31;
            this.labelControl4.Text = "標準產量:";
            // 
            // txtPrdMachine
            // 
            this.txtPrdMachine.Location = new System.Drawing.Point(106, 69);
            this.txtPrdMachine.Name = "txtPrdMachine";
            this.txtPrdMachine.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrdMachine.Size = new System.Drawing.Size(121, 20);
            this.txtPrdMachine.TabIndex = 6;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(48, 72);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(52, 14);
            this.labelControl5.TabIndex = 31;
            this.labelControl5.Text = "生產機器:";
            // 
            // txtPrdWorker
            // 
            this.txtPrdWorker.Location = new System.Drawing.Point(302, 69);
            this.txtPrdWorker.Name = "txtPrdWorker";
            this.txtPrdWorker.Size = new System.Drawing.Size(121, 20);
            this.txtPrdWorker.TabIndex = 7;
            this.txtPrdWorker.Leave += new System.EventHandler(this.txtPrdWorker_Leave);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(244, 72);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(52, 14);
            this.labelControl6.TabIndex = 31;
            this.labelControl6.Text = "生產工號:";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(244, 16);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(52, 14);
            this.labelControl7.TabIndex = 28;
            this.labelControl7.Text = "物料編號:";
            // 
            // txtFindItem
            // 
            this.txtFindItem.Location = new System.Drawing.Point(302, 16);
            this.txtFindItem.Name = "txtFindItem";
            this.txtFindItem.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFindItem.Properties.MaxLength = 18;
            this.txtFindItem.Size = new System.Drawing.Size(203, 20);
            this.txtFindItem.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "生產車間:";
            // 
            // lueFindDep
            // 
            this.lueFindDep.EditValue = "";
            this.lueFindDep.Location = new System.Drawing.Point(106, 16);
            this.lueFindDep.Name = "lueFindDep";
            this.lueFindDep.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueFindDep.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lueFindDep.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dep_id", 40, "部門代號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dep_cdesc", 60, "部門描述")});
            this.lueFindDep.Properties.NullText = "";
            this.lueFindDep.Size = new System.Drawing.Size(121, 20);
            this.lueFindDep.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnFind);
            this.panel2.Controls.Add(this.txtFindItem);
            this.panel2.Controls.Add(this.lueFindDep);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.labelControl7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 160);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1168, 55);
            this.panel2.TabIndex = 34;
            // 
            // txtPrdGroup
            // 
            this.txtPrdGroup.Location = new System.Drawing.Point(591, 69);
            this.txtPrdGroup.Name = "txtPrdGroup";
            this.txtPrdGroup.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrdGroup.Size = new System.Drawing.Size(121, 20);
            this.txtPrdGroup.TabIndex = 8;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(533, 72);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(52, 14);
            this.labelControl8.TabIndex = 31;
            this.labelControl8.Text = "生產組別:";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(605, 13);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 29;
            this.btnFind.Text = "查找(&F)";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnSetGoodsWeight
            // 
            this.btnSetGoodsWeight.AutoSize = false;
            this.btnSetGoodsWeight.Image = ((System.Drawing.Image)(resources.GetObject("btnSetGoodsWeight.Image")));
            this.btnSetGoodsWeight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetGoodsWeight.Name = "btnSetGoodsWeight";
            this.btnSetGoodsWeight.Size = new System.Drawing.Size(100, 35);
            this.btnSetGoodsWeight.Text = "產品用料用量設定";
            this.btnSetGoodsWeight.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSetGoodsWeight.ToolTipText = "產品用料用量設定";
            this.btnSetGoodsWeight.Click += new System.EventHandler(this.btnSetGoodsWeight_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "materiel_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "原料編號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 140;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "goods_name";
            this.dataGridViewTextBoxColumn2.HeaderText = "原料描述";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 300;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "goods_cname";
            this.dataGridViewTextBoxColumn3.HeaderText = "物料描述";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 260;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "prd_group";
            this.dataGridViewTextBoxColumn4.HeaderText = "生產車間";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "hour_run_num";
            this.dataGridViewTextBoxColumn5.HeaderText = "標準轉數";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "line_num";
            this.dataGridViewTextBoxColumn6.HeaderText = "每碑數";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "hour_std_qty";
            this.dataGridViewTextBoxColumn7.HeaderText = "標準產量";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "prd_machine";
            this.dataGridViewTextBoxColumn8.HeaderText = "生產機器";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "prd_worker";
            this.dataGridViewTextBoxColumn9.HeaderText = "生產工號";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "prd_mo";
            this.dataGridViewTextBoxColumn10.HeaderText = "參考制單";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // colDepId
            // 
            this.colDepId.DataPropertyName = "dep_id";
            this.colDepId.HeaderText = "部門代號";
            this.colDepId.Name = "colDepId";
            this.colDepId.ReadOnly = true;
            this.colDepId.Width = 60;
            // 
            // colPrdItem
            // 
            this.colPrdItem.DataPropertyName = "goods_id";
            this.colPrdItem.HeaderText = "物料編號";
            this.colPrdItem.Name = "colPrdItem";
            this.colPrdItem.ReadOnly = true;
            this.colPrdItem.Width = 160;
            // 
            // colPrdItemCdesc
            // 
            this.colPrdItemCdesc.DataPropertyName = "goods_cname";
            this.colPrdItemCdesc.HeaderText = "物料描述";
            this.colPrdItemCdesc.Name = "colPrdItemCdesc";
            this.colPrdItemCdesc.ReadOnly = true;
            this.colPrdItemCdesc.Width = 300;
            // 
            // colPrdGroup
            // 
            this.colPrdGroup.DataPropertyName = "prd_group";
            this.colPrdGroup.HeaderText = "生產車間";
            this.colPrdGroup.Name = "colPrdGroup";
            this.colPrdGroup.ReadOnly = true;
            this.colPrdGroup.Width = 80;
            // 
            // colHourRunNum
            // 
            this.colHourRunNum.DataPropertyName = "hour_run_num";
            this.colHourRunNum.HeaderText = "標準轉數";
            this.colHourRunNum.Name = "colHourRunNum";
            this.colHourRunNum.ReadOnly = true;
            this.colHourRunNum.Width = 80;
            // 
            // colLineNum
            // 
            this.colLineNum.DataPropertyName = "line_num";
            this.colLineNum.HeaderText = "每碑數";
            this.colLineNum.Name = "colLineNum";
            this.colLineNum.ReadOnly = true;
            this.colLineNum.Width = 80;
            // 
            // colHourStdQty
            // 
            this.colHourStdQty.DataPropertyName = "hour_std_qty";
            this.colHourStdQty.HeaderText = "標準產量";
            this.colHourStdQty.Name = "colHourStdQty";
            this.colHourStdQty.ReadOnly = true;
            this.colHourStdQty.Width = 80;
            // 
            // colPrdMachine
            // 
            this.colPrdMachine.DataPropertyName = "prd_machine";
            this.colPrdMachine.HeaderText = "生產機器";
            this.colPrdMachine.Name = "colPrdMachine";
            this.colPrdMachine.ReadOnly = true;
            // 
            // colPrdWorker
            // 
            this.colPrdWorker.DataPropertyName = "prd_worker";
            this.colPrdWorker.HeaderText = "生產工號";
            this.colPrdWorker.Name = "colPrdWorker";
            this.colPrdWorker.ReadOnly = true;
            // 
            // colPrdMo
            // 
            this.colPrdMo.DataPropertyName = "prd_mo";
            this.colPrdMo.HeaderText = "參考制單";
            this.colPrdMo.Name = "colPrdMo";
            this.colPrdMo.ReadOnly = true;
            // 
            // frmMoScheduleDepGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 600);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMoScheduleDepGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmMoScheduleDepGroup";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMoScheduleDepGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lueDep.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdMo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdItemCdesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRunNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStdQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdMachine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdWorker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFindItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueFindDep.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdGroup.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LookUpEdit lueDep;
        private System.Windows.Forms.Label lblDepGroup;
        private DevExpress.XtraEditors.TextEdit txtPrdMo;
        private DevExpress.XtraEditors.LabelControl lblPrdMo;
        private DevExpress.XtraEditors.TextEdit txtPrdItem;
        private DevExpress.XtraEditors.LabelControl lblPrdItem;
        private DevExpress.XtraEditors.SimpleButton btnConf;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtPrdMachine;
        private DevExpress.XtraEditors.TextEdit txtStdQty;
        private DevExpress.XtraEditors.TextEdit txtLineNum;
        private DevExpress.XtraEditors.TextEdit txtRunNum;
        private DevExpress.XtraEditors.TextEdit txtPrdItemCdesc;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtPrdWorker;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtFindItem;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit lueFindDep;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtPrdGroup;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrdItemCdesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrdGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHourRunNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHourStdQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrdMachine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrdWorker;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrdMo;
        private System.Windows.Forms.ToolStripButton btnSetGoodsWeight;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}