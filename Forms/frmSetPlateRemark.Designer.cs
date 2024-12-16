namespace cf01.Forms
{
    partial class frmSetPlateRemark
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetPlateRemark));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNNEW = new System.Windows.Forms.ToolStripButton();
            this.BTNEDIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNSAVE = new System.Windows.Forms.ToolStripButton();
            this.BTNCANCEL = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNDELETE = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNFIND = new System.Windows.Forms.ToolStripButton();
            this.BTNPRINT = new System.Windows.Forms.ToolStripButton();
            this.BTNEXCEL = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAmtim = new System.Windows.Forms.Label();
            this.lblAmusr = new System.Windows.Forms.Label();
            this.lblCrtim = new System.Windows.Forms.Label();
            this.lblCrusr = new System.Windows.Forms.Label();
            this.txtUpdate_date = new DevExpress.XtraEditors.TextEdit();
            this.txtUpdate_by = new DevExpress.XtraEditors.TextEdit();
            this.txtCreate_date = new DevExpress.XtraEditors.TextEdit();
            this.txtCreate_by = new DevExpress.XtraEditors.TextEdit();
            this.lblSize_rmk = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.txtMo_group = new DevExpress.XtraEditors.TextEdit();
            this.lblSize_cdesc = new System.Windows.Forms.Label();
            this.txtGoods_name = new DevExpress.XtraEditors.TextEdit();
            this.lblSize_id = new System.Windows.Forms.Label();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.txtPlate_remark = new DevExpress.XtraEditors.MemoEdit();
            this.dgvPlateRemak = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mo_group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plate_remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.create_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.create_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpdate_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpdate_by.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_by.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_group.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoods_name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlate_remark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlateRemak)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNEXIT,
            this.toolStripSeparator1,
            this.BTNNEW,
            this.BTNEDIT,
            this.toolStripSeparator2,
            this.BTNSAVE,
            this.BTNCANCEL,
            this.toolStripSeparator3,
            this.BTNDELETE,
            this.toolStripSeparator4,
            this.BTNFIND,
            this.BTNPRINT,
            this.BTNEXCEL});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(892, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BTNEXIT
            // 
            this.BTNEXIT.Image = ((System.Drawing.Image)(resources.GetObject("BTNEXIT.Image")));
            this.BTNEXIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEXIT.Name = "BTNEXIT";
            this.BTNEXIT.Size = new System.Drawing.Size(67, 22);
            this.BTNEXIT.Text = "退出(&X)";
            this.BTNEXIT.Click += new System.EventHandler(this.BTNEXIT_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // BTNNEW
            // 
            this.BTNNEW.Image = ((System.Drawing.Image)(resources.GetObject("BTNNEW.Image")));
            this.BTNNEW.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNNEW.Name = "BTNNEW";
            this.BTNNEW.Size = new System.Drawing.Size(67, 22);
            this.BTNNEW.Text = "新增(&A)";
            this.BTNNEW.Click += new System.EventHandler(this.BTNNEW_Click);
            // 
            // BTNEDIT
            // 
            this.BTNEDIT.Image = ((System.Drawing.Image)(resources.GetObject("BTNEDIT.Image")));
            this.BTNEDIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEDIT.Name = "BTNEDIT";
            this.BTNEDIT.Size = new System.Drawing.Size(66, 22);
            this.BTNEDIT.Text = "編輯(&E)";
            this.BTNEDIT.Click += new System.EventHandler(this.BTNEDIT_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // BTNSAVE
            // 
            this.BTNSAVE.Enabled = false;
            this.BTNSAVE.Image = ((System.Drawing.Image)(resources.GetObject("BTNSAVE.Image")));
            this.BTNSAVE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNSAVE.Name = "BTNSAVE";
            this.BTNSAVE.Size = new System.Drawing.Size(66, 22);
            this.BTNSAVE.Text = "保存(&S)";
            this.BTNSAVE.Click += new System.EventHandler(this.BTNSAVE_Click);
            // 
            // BTNCANCEL
            // 
            this.BTNCANCEL.Enabled = false;
            this.BTNCANCEL.Image = ((System.Drawing.Image)(resources.GetObject("BTNCANCEL.Image")));
            this.BTNCANCEL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNCANCEL.Name = "BTNCANCEL";
            this.BTNCANCEL.Size = new System.Drawing.Size(67, 22);
            this.BTNCANCEL.Text = "取消(&C)";
            this.BTNCANCEL.Click += new System.EventHandler(this.BTNCANCEL_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // BTNDELETE
            // 
            this.BTNDELETE.Image = ((System.Drawing.Image)(resources.GetObject("BTNDELETE.Image")));
            this.BTNDELETE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNDELETE.Name = "BTNDELETE";
            this.BTNDELETE.Size = new System.Drawing.Size(68, 22);
            this.BTNDELETE.Text = "刪除(&D)";
            this.BTNDELETE.Click += new System.EventHandler(this.BTNDELETE_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // BTNFIND
            // 
            this.BTNFIND.Image = ((System.Drawing.Image)(resources.GetObject("BTNFIND.Image")));
            this.BTNFIND.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNFIND.Name = "BTNFIND";
            this.BTNFIND.Size = new System.Drawing.Size(65, 22);
            this.BTNFIND.Text = "查詢(&F)";
            this.BTNFIND.Click += new System.EventHandler(this.BTNFIND_Click);
            // 
            // BTNPRINT
            // 
            this.BTNPRINT.Image = ((System.Drawing.Image)(resources.GetObject("BTNPRINT.Image")));
            this.BTNPRINT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNPRINT.Name = "BTNPRINT";
            this.BTNPRINT.Size = new System.Drawing.Size(66, 22);
            this.BTNPRINT.Text = "列印(&P)";
            this.BTNPRINT.Click += new System.EventHandler(this.BTNPRINT_Click);
            // 
            // BTNEXCEL
            // 
            this.BTNEXCEL.Image = ((System.Drawing.Image)(resources.GetObject("BTNEXCEL.Image")));
            this.BTNEXCEL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEXCEL.Name = "BTNEXCEL";
            this.BTNEXCEL.Size = new System.Drawing.Size(87, 22);
            this.BTNEXCEL.Text = "匯出EXCEL";
            this.BTNEXCEL.Click += new System.EventHandler(this.BTNEXCEL_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblAmtim);
            this.panel1.Controls.Add(this.lblAmusr);
            this.panel1.Controls.Add(this.lblCrtim);
            this.panel1.Controls.Add(this.lblCrusr);
            this.panel1.Controls.Add(this.txtUpdate_date);
            this.panel1.Controls.Add(this.txtUpdate_by);
            this.panel1.Controls.Add(this.txtCreate_date);
            this.panel1.Controls.Add(this.txtCreate_by);
            this.panel1.Controls.Add(this.lblSize_rmk);
            this.panel1.Controls.Add(this.lblGroup);
            this.panel1.Controls.Add(this.txtMo_group);
            this.panel1.Controls.Add(this.lblSize_cdesc);
            this.panel1.Controls.Add(this.txtGoods_name);
            this.panel1.Controls.Add(this.lblSize_id);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.txtPlate_remark);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 153);
            this.panel1.TabIndex = 3;
            // 
            // lblAmtim
            // 
            this.lblAmtim.Location = new System.Drawing.Point(666, 122);
            this.lblAmtim.Name = "lblAmtim";
            this.lblAmtim.Size = new System.Drawing.Size(73, 13);
            this.lblAmtim.TabIndex = 15;
            this.lblAmtim.Text = "修改日期";
            this.lblAmtim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAmusr
            // 
            this.lblAmusr.Location = new System.Drawing.Point(459, 123);
            this.lblAmusr.Name = "lblAmusr";
            this.lblAmusr.Size = new System.Drawing.Size(74, 13);
            this.lblAmusr.TabIndex = 14;
            this.lblAmusr.Text = "修改人";
            this.lblAmusr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCrtim
            // 
            this.lblCrtim.Location = new System.Drawing.Point(666, 89);
            this.lblCrtim.Name = "lblCrtim";
            this.lblCrtim.Size = new System.Drawing.Size(73, 13);
            this.lblCrtim.TabIndex = 13;
            this.lblCrtim.Text = "建檔日期";
            this.lblCrtim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCrusr
            // 
            this.lblCrusr.Location = new System.Drawing.Point(459, 90);
            this.lblCrusr.Name = "lblCrusr";
            this.lblCrusr.Size = new System.Drawing.Size(74, 13);
            this.lblCrusr.TabIndex = 12;
            this.lblCrusr.Text = "建檔人";
            this.lblCrusr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUpdate_date
            // 
            this.txtUpdate_date.Enabled = false;
            this.txtUpdate_date.Location = new System.Drawing.Point(743, 119);
            this.txtUpdate_date.Name = "txtUpdate_date";
            this.txtUpdate_date.Properties.ReadOnly = true;
            this.txtUpdate_date.Size = new System.Drawing.Size(126, 20);
            this.txtUpdate_date.TabIndex = 11;
            this.txtUpdate_date.Tag = "2";
            // 
            // txtUpdate_by
            // 
            this.txtUpdate_by.Enabled = false;
            this.txtUpdate_by.Location = new System.Drawing.Point(536, 119);
            this.txtUpdate_by.Name = "txtUpdate_by";
            this.txtUpdate_by.Properties.ReadOnly = true;
            this.txtUpdate_by.Size = new System.Drawing.Size(126, 20);
            this.txtUpdate_by.TabIndex = 10;
            this.txtUpdate_by.Tag = "2";
            // 
            // txtCreate_date
            // 
            this.txtCreate_date.Enabled = false;
            this.txtCreate_date.Location = new System.Drawing.Point(742, 87);
            this.txtCreate_date.Name = "txtCreate_date";
            this.txtCreate_date.Properties.ReadOnly = true;
            this.txtCreate_date.Size = new System.Drawing.Size(126, 20);
            this.txtCreate_date.TabIndex = 9;
            this.txtCreate_date.Tag = "2";
            // 
            // txtCreate_by
            // 
            this.txtCreate_by.Enabled = false;
            this.txtCreate_by.Location = new System.Drawing.Point(536, 87);
            this.txtCreate_by.Name = "txtCreate_by";
            this.txtCreate_by.Properties.ReadOnly = true;
            this.txtCreate_by.Size = new System.Drawing.Size(126, 20);
            this.txtCreate_by.TabIndex = 8;
            this.txtCreate_by.Tag = "2";
            // 
            // lblSize_rmk
            // 
            this.lblSize_rmk.ForeColor = System.Drawing.Color.Blue;
            this.lblSize_rmk.Location = new System.Drawing.Point(3, 88);
            this.lblSize_rmk.Name = "lblSize_rmk";
            this.lblSize_rmk.Size = new System.Drawing.Size(81, 13);
            this.lblSize_rmk.TabIndex = 7;
            this.lblSize_rmk.Text = "自定義電鍍備注";
            this.lblSize_rmk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGroup
            // 
            this.lblGroup.Location = new System.Drawing.Point(316, 18);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(51, 13);
            this.lblGroup.TabIndex = 5;
            this.lblGroup.Text = "組別";
            this.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMo_group
            // 
            this.txtMo_group.EnterMoveNextControl = true;
            this.txtMo_group.Location = new System.Drawing.Point(372, 16);
            this.txtMo_group.Name = "txtMo_group";
            this.txtMo_group.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo_group.Properties.MaxLength = 1;
            this.txtMo_group.Properties.ReadOnly = true;
            this.txtMo_group.Size = new System.Drawing.Size(75, 20);
            this.txtMo_group.TabIndex = 4;
            this.txtMo_group.Tag = "2";
            // 
            // lblSize_cdesc
            // 
            this.lblSize_cdesc.Location = new System.Drawing.Point(7, 51);
            this.lblSize_cdesc.Name = "lblSize_cdesc";
            this.lblSize_cdesc.Size = new System.Drawing.Size(77, 13);
            this.lblSize_cdesc.TabIndex = 3;
            this.lblSize_cdesc.Text = "名稱";
            this.lblSize_cdesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGoods_name
            // 
            this.txtGoods_name.Enabled = false;
            this.txtGoods_name.EnterMoveNextControl = true;
            this.txtGoods_name.Location = new System.Drawing.Point(89, 49);
            this.txtGoods_name.Name = "txtGoods_name";
            this.txtGoods_name.Properties.ReadOnly = true;
            this.txtGoods_name.Size = new System.Drawing.Size(358, 20);
            this.txtGoods_name.TabIndex = 2;
            this.txtGoods_name.Tag = "2";
            // 
            // lblSize_id
            // 
            this.lblSize_id.ForeColor = System.Drawing.Color.Blue;
            this.lblSize_id.Location = new System.Drawing.Point(7, 18);
            this.lblSize_id.Name = "lblSize_id";
            this.lblSize_id.Size = new System.Drawing.Size(77, 13);
            this.lblSize_id.TabIndex = 1;
            this.lblSize_id.Text = "貨品編號";
            this.lblSize_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtID
            // 
            this.txtID.EnterMoveNextControl = true;
            this.txtID.Location = new System.Drawing.Point(89, 16);
            this.txtID.Name = "txtID";
            this.txtID.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtID.Properties.MaxLength = 18;
            this.txtID.Size = new System.Drawing.Size(213, 20);
            this.txtID.TabIndex = 0;
            this.txtID.Tag = "2";
            this.txtID.Leave += new System.EventHandler(this.txtID_Leave);
            // 
            // txtPlate_remark
            // 
            this.txtPlate_remark.EnterMoveNextControl = true;
            this.txtPlate_remark.Location = new System.Drawing.Point(89, 87);
            this.txtPlate_remark.Name = "txtPlate_remark";
            this.txtPlate_remark.Properties.MaxLength = 255;
            this.txtPlate_remark.Properties.ReadOnly = true;
            this.txtPlate_remark.Size = new System.Drawing.Size(358, 54);
            this.txtPlate_remark.TabIndex = 6;
            this.txtPlate_remark.Tag = "2";
            // 
            // dgvPlateRemak
            // 
            this.dgvPlateRemak.AllowUserToAddRows = false;
            this.dgvPlateRemak.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPlateRemak.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvPlateRemak.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPlateRemak.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.goods_name,
            this.mo_group,
            this.plate_remark,
            this.create_by,
            this.create_date,
            this.update_by,
            this.update_date});
            this.dgvPlateRemak.Location = new System.Drawing.Point(0, 181);
            this.dgvPlateRemak.Name = "dgvPlateRemak";
            this.dgvPlateRemak.ReadOnly = true;
            this.dgvPlateRemak.RowTemplate.Height = 24;
            this.dgvPlateRemak.Size = new System.Drawing.Size(892, 239);
            this.dgvPlateRemak.TabIndex = 5;
            this.dgvPlateRemak.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvSize_RowPostPaint);
            this.dgvPlateRemak.SelectionChanged += new System.EventHandler(this.dgvSize_SelectionChanged);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "貨品編號";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 150;
            // 
            // goods_name
            // 
            this.goods_name.DataPropertyName = "goods_name";
            this.goods_name.HeaderText = "貨品描述";
            this.goods_name.Name = "goods_name";
            this.goods_name.ReadOnly = true;
            this.goods_name.Width = 250;
            // 
            // mo_group
            // 
            this.mo_group.DataPropertyName = "mo_group";
            this.mo_group.HeaderText = "組別";
            this.mo_group.Name = "mo_group";
            this.mo_group.ReadOnly = true;
            this.mo_group.Width = 80;
            // 
            // plate_remark
            // 
            this.plate_remark.DataPropertyName = "plate_remark";
            this.plate_remark.HeaderText = "電鍍備註";
            this.plate_remark.Name = "plate_remark";
            this.plate_remark.ReadOnly = true;
            this.plate_remark.Width = 200;
            // 
            // create_by
            // 
            this.create_by.DataPropertyName = "create_by";
            this.create_by.HeaderText = "建檔人";
            this.create_by.Name = "create_by";
            this.create_by.ReadOnly = true;
            this.create_by.Visible = false;
            // 
            // create_date
            // 
            this.create_date.DataPropertyName = "create_date";
            this.create_date.HeaderText = "建檔日期";
            this.create_date.Name = "create_date";
            this.create_date.ReadOnly = true;
            this.create_date.Visible = false;
            // 
            // update_by
            // 
            this.update_by.DataPropertyName = "update_by";
            this.update_by.HeaderText = "修改人";
            this.update_by.Name = "update_by";
            this.update_by.ReadOnly = true;
            this.update_by.Visible = false;
            // 
            // update_date
            // 
            this.update_date.DataPropertyName = "update_date";
            this.update_date.HeaderText = "修改日期";
            this.update_date.Name = "update_date";
            this.update_date.ReadOnly = true;
            this.update_date.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "編號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "中文名稱";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "英文名稱";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "備註";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "建檔人";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "建檔日期";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "修改人";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "修改日期";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // frmSetPlateRemark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 421);
            this.Controls.Add(this.dgvPlateRemak);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmSetPlateRemark";
            this.Text = "frmSetPlateRemark";
            this.Load += new System.EventHandler(this.frmSetPlateRemark_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtUpdate_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpdate_by.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_by.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_group.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoods_name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlate_remark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlateRemak)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BTNNEW;
        private System.Windows.Forms.ToolStripButton BTNEDIT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton BTNSAVE;
        private System.Windows.Forms.ToolStripButton BTNCANCEL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton BTNDELETE;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton BTNFIND;
        private System.Windows.Forms.ToolStripButton BTNPRINT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAmtim;
        private System.Windows.Forms.Label lblAmusr;
        private System.Windows.Forms.Label lblCrtim;
        private System.Windows.Forms.Label lblCrusr;
        private DevExpress.XtraEditors.TextEdit txtUpdate_date;
        private DevExpress.XtraEditors.TextEdit txtUpdate_by;
        private DevExpress.XtraEditors.TextEdit txtCreate_date;
        private DevExpress.XtraEditors.TextEdit txtCreate_by;
        private System.Windows.Forms.Label lblSize_rmk;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblSize_cdesc;
        private DevExpress.XtraEditors.TextEdit txtGoods_name;
        private System.Windows.Forms.Label lblSize_id;
        private DevExpress.XtraEditors.TextEdit txtID;
        private DevExpress.XtraEditors.MemoEdit txtPlate_remark;
        private System.Windows.Forms.DataGridView dgvPlateRemak;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.ToolStripButton BTNEXCEL;
        private DevExpress.XtraEditors.TextEdit txtMo_group;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn mo_group;
        private System.Windows.Forms.DataGridViewTextBoxColumn plate_remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn create_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn create_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn update_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn update_date;
    }
}