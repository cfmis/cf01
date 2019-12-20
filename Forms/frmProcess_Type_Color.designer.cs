namespace cf01.Forms
{
    partial class frmProcess_Type_Color
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcess_Type_Color));
            this.lblAmtim = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNNEW = new System.Windows.Forms.ToolStripButton();
            this.BTNEDIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNSAVE = new System.Windows.Forms.ToolStripButton();
            this.BTNCANCEL = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNDEL = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNFIND = new System.Windows.Forms.ToolStripButton();
            this.BTNPRINT = new System.Windows.Forms.ToolStripButton();
            this.BTNEXCEL = new System.Windows.Forms.ToolStripButton();
            this.lblCrtim = new System.Windows.Forms.Label();
            this.lblCrusr = new System.Windows.Forms.Label();
            this.lblAmusr = new System.Windows.Forms.Label();
            this.txtAmtim = new DevExpress.XtraEditors.TextEdit();
            this.txtAmusr = new DevExpress.XtraEditors.TextEdit();
            this.txtCrtim = new DevExpress.XtraEditors.TextEdit();
            this.txtCrusr = new DevExpress.XtraEditors.TextEdit();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.color_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.do_color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grind_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crusr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crtim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amusr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amtim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGrind_id = new DevExpress.XtraEditors.TextEdit();
            this.txtDo_color = new DevExpress.XtraEditors.TextEdit();
            this.txtID = new DevExpress.XtraEditors.LookUpEdit();
            this.lblGrind_id = new System.Windows.Forms.Label();
            this.lblDo_color = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmtim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmusr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrtim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrusr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrind_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDo_color.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAmtim
            // 
            this.lblAmtim.Location = new System.Drawing.Point(321, 123);
            this.lblAmtim.Name = "lblAmtim";
            this.lblAmtim.Size = new System.Drawing.Size(73, 13);
            this.lblAmtim.TabIndex = 15;
            this.lblAmtim.Text = "修改日期";
            this.lblAmtim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.BTNDEL,
            this.toolStripSeparator4,
            this.BTNFIND,
            this.BTNPRINT,
            this.BTNEXCEL});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(920, 25);
            this.toolStrip1.TabIndex = 7;
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
            // BTNNEW
            // 
            this.BTNNEW.Image = ((System.Drawing.Image)(resources.GetObject("BTNNEW.Image")));
            this.BTNNEW.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNNEW.Name = "BTNNEW";
            this.BTNNEW.Size = new System.Drawing.Size(65, 22);
            this.BTNNEW.Text = "新增(&A)";
            this.BTNNEW.Click += new System.EventHandler(this.BTNNEW_Click);
            // 
            // BTNEDIT
            // 
            this.BTNEDIT.Image = ((System.Drawing.Image)(resources.GetObject("BTNEDIT.Image")));
            this.BTNEDIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEDIT.Name = "BTNEDIT";
            this.BTNEDIT.Size = new System.Drawing.Size(64, 22);
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
            this.BTNSAVE.Size = new System.Drawing.Size(63, 22);
            this.BTNSAVE.Text = "保存(&S)";
            this.BTNSAVE.Click += new System.EventHandler(this.BTNSAVE_Click);
            // 
            // BTNCANCEL
            // 
            this.BTNCANCEL.Enabled = false;
            this.BTNCANCEL.Image = ((System.Drawing.Image)(resources.GetObject("BTNCANCEL.Image")));
            this.BTNCANCEL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNCANCEL.Name = "BTNCANCEL";
            this.BTNCANCEL.Size = new System.Drawing.Size(65, 22);
            this.BTNCANCEL.Text = "取消(&C)";
            this.BTNCANCEL.Click += new System.EventHandler(this.BTNCANCEL_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // BTNDEL
            // 
            this.BTNDEL.Image = ((System.Drawing.Image)(resources.GetObject("BTNDEL.Image")));
            this.BTNDEL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNDEL.Name = "BTNDEL";
            this.BTNDEL.Size = new System.Drawing.Size(65, 22);
            this.BTNDEL.Text = "刪除(&D)";
            this.BTNDEL.Click += new System.EventHandler(this.BTNDEL_Click);
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
            this.BTNFIND.Size = new System.Drawing.Size(63, 22);
            this.BTNFIND.Text = "查詢(&F)";
            this.BTNFIND.Click += new System.EventHandler(this.BTNFIND_Click);
            // 
            // BTNPRINT
            // 
            this.BTNPRINT.Image = ((System.Drawing.Image)(resources.GetObject("BTNPRINT.Image")));
            this.BTNPRINT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNPRINT.Name = "BTNPRINT";
            this.BTNPRINT.Size = new System.Drawing.Size(63, 22);
            this.BTNPRINT.Text = "列印(&P)";
            this.BTNPRINT.Click += new System.EventHandler(this.BTNPRINT_Click);
            // 
            // BTNEXCEL
            // 
            this.BTNEXCEL.Image = ((System.Drawing.Image)(resources.GetObject("BTNEXCEL.Image")));
            this.BTNEXCEL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEXCEL.Name = "BTNEXCEL";
            this.BTNEXCEL.Size = new System.Drawing.Size(86, 22);
            this.BTNEXCEL.Text = "匯出EXCEL";
            this.BTNEXCEL.Click += new System.EventHandler(this.BTNEXCEL_Click);
            // 
            // lblCrtim
            // 
            this.lblCrtim.Location = new System.Drawing.Point(321, 95);
            this.lblCrtim.Name = "lblCrtim";
            this.lblCrtim.Size = new System.Drawing.Size(73, 13);
            this.lblCrtim.TabIndex = 13;
            this.lblCrtim.Text = "建檔日期";
            this.lblCrtim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCrusr
            // 
            this.lblCrusr.Location = new System.Drawing.Point(40, 98);
            this.lblCrusr.Name = "lblCrusr";
            this.lblCrusr.Size = new System.Drawing.Size(74, 13);
            this.lblCrusr.TabIndex = 12;
            this.lblCrusr.Text = "建檔人";
            this.lblCrusr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAmusr
            // 
            this.lblAmusr.Location = new System.Drawing.Point(40, 126);
            this.lblAmusr.Name = "lblAmusr";
            this.lblAmusr.Size = new System.Drawing.Size(74, 13);
            this.lblAmusr.TabIndex = 14;
            this.lblAmusr.Text = "修改人";
            this.lblAmusr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAmtim
            // 
            this.txtAmtim.Enabled = false;
            this.txtAmtim.Location = new System.Drawing.Point(398, 120);
            this.txtAmtim.Name = "txtAmtim";
            this.txtAmtim.Properties.ReadOnly = true;
            this.txtAmtim.Size = new System.Drawing.Size(174, 20);
            this.txtAmtim.TabIndex = 6;
            this.txtAmtim.Tag = "2";
            // 
            // txtAmusr
            // 
            this.txtAmusr.Enabled = false;
            this.txtAmusr.Location = new System.Drawing.Point(116, 122);
            this.txtAmusr.Name = "txtAmusr";
            this.txtAmusr.Properties.ReadOnly = true;
            this.txtAmusr.Size = new System.Drawing.Size(160, 20);
            this.txtAmusr.TabIndex = 5;
            this.txtAmusr.Tag = "2";
            // 
            // txtCrtim
            // 
            this.txtCrtim.Enabled = false;
            this.txtCrtim.Location = new System.Drawing.Point(397, 93);
            this.txtCrtim.Name = "txtCrtim";
            this.txtCrtim.Properties.ReadOnly = true;
            this.txtCrtim.Size = new System.Drawing.Size(175, 20);
            this.txtCrtim.TabIndex = 4;
            this.txtCrtim.Tag = "2";
            // 
            // txtCrusr
            // 
            this.txtCrusr.Enabled = false;
            this.txtCrusr.Location = new System.Drawing.Point(116, 95);
            this.txtCrusr.Name = "txtCrusr";
            this.txtCrusr.Properties.ReadOnly = true;
            this.txtCrusr.Size = new System.Drawing.Size(160, 20);
            this.txtCrusr.TabIndex = 3;
            this.txtCrusr.Tag = "2";
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetails.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.color_id,
            this.do_color,
            this.grind_id,
            this.crusr,
            this.crtim,
            this.amusr,
            this.amtim});
            this.dgvDetails.Location = new System.Drawing.Point(0, 182);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(919, 240);
            this.dgvDetails.TabIndex = 9;
            this.dgvDetails.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDetails_RowPostPaint);
            this.dgvDetails.SelectionChanged += new System.EventHandler(this.dgvDetails_SelectionChanged);
            // 
            // color_id
            // 
            this.color_id.DataPropertyName = "color_id";
            this.color_id.HeaderText = "顏色編號";
            this.color_id.Name = "color_id";
            this.color_id.ReadOnly = true;
            this.color_id.Width = 80;
            // 
            // do_color
            // 
            this.do_color.DataPropertyName = "do_color";
            this.do_color.HeaderText = "顏色做法";
            this.do_color.Name = "do_color";
            this.do_color.ReadOnly = true;
            this.do_color.Width = 350;
            // 
            // grind_id
            // 
            this.grind_id.DataPropertyName = "grind_id";
            this.grind_id.HeaderText = "研磨工序代碼";
            this.grind_id.Name = "grind_id";
            this.grind_id.ReadOnly = true;
            // 
            // crusr
            // 
            this.crusr.DataPropertyName = "crusr";
            this.crusr.HeaderText = "建檔人";
            this.crusr.Name = "crusr";
            this.crusr.ReadOnly = true;
            this.crusr.Visible = false;
            // 
            // crtim
            // 
            this.crtim.DataPropertyName = "crtim";
            this.crtim.HeaderText = "建檔日期";
            this.crtim.Name = "crtim";
            this.crtim.ReadOnly = true;
            this.crtim.Visible = false;
            // 
            // amusr
            // 
            this.amusr.DataPropertyName = "amusr";
            this.amusr.HeaderText = "修改人";
            this.amusr.Name = "amusr";
            this.amusr.ReadOnly = true;
            this.amusr.Visible = false;
            // 
            // amtim
            // 
            this.amtim.DataPropertyName = "amtim";
            this.amtim.HeaderText = "修改日期";
            this.amtim.Name = "amtim";
            this.amtim.ReadOnly = true;
            this.amtim.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtGrind_id);
            this.panel1.Controls.Add(this.txtDo_color);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.lblAmtim);
            this.panel1.Controls.Add(this.lblAmusr);
            this.panel1.Controls.Add(this.lblCrtim);
            this.panel1.Controls.Add(this.lblCrusr);
            this.panel1.Controls.Add(this.txtAmtim);
            this.panel1.Controls.Add(this.txtAmusr);
            this.panel1.Controls.Add(this.txtCrtim);
            this.panel1.Controls.Add(this.txtCrusr);
            this.panel1.Controls.Add(this.lblGrind_id);
            this.panel1.Controls.Add(this.lblDo_color);
            this.panel1.Controls.Add(this.lblID);
            this.panel1.Location = new System.Drawing.Point(1, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 153);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(277, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "(C,L,M)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGrind_id
            // 
            this.txtGrind_id.Location = new System.Drawing.Point(116, 64);
            this.txtGrind_id.Name = "txtGrind_id";
            this.txtGrind_id.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGrind_id.Properties.ReadOnly = true;
            this.txtGrind_id.Size = new System.Drawing.Size(160, 20);
            this.txtGrind_id.TabIndex = 2;
            this.txtGrind_id.Tag = "2";
            // 
            // txtDo_color
            // 
            this.txtDo_color.EnterMoveNextControl = true;
            this.txtDo_color.Location = new System.Drawing.Point(116, 36);
            this.txtDo_color.Name = "txtDo_color";
            this.txtDo_color.Properties.ReadOnly = true;
            this.txtDo_color.Size = new System.Drawing.Size(456, 20);
            this.txtDo_color.TabIndex = 1;
            this.txtDo_color.Tag = "2";
            // 
            // txtID
            // 
            this.txtID.EditValue = "";
            this.txtID.EnterMoveNextControl = true;
            this.txtID.Location = new System.Drawing.Point(116, 9);
            this.txtID.Name = "txtID";
            this.txtID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtID.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", 50, "產品類型"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cdesc", 150, "類型描述"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("do_color", 300, "顏色做法")});
            this.txtID.Properties.DropDownRows = 15;
            this.txtID.Properties.NullText = "";
            this.txtID.Properties.PopupWidth = 600;
            this.txtID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtID.Size = new System.Drawing.Size(160, 20);
            this.txtID.TabIndex = 0;
            this.txtID.Tag = "1";
            this.txtID.Leave += new System.EventHandler(this.txtID_Leave);
            // 
            // lblGrind_id
            // 
            this.lblGrind_id.Location = new System.Drawing.Point(33, 69);
            this.lblGrind_id.Name = "lblGrind_id";
            this.lblGrind_id.Size = new System.Drawing.Size(77, 13);
            this.lblGrind_id.TabIndex = 5;
            this.lblGrind_id.Text = "研磨工序代碼";
            this.lblGrind_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDo_color
            // 
            this.lblDo_color.Location = new System.Drawing.Point(19, 39);
            this.lblDo_color.Name = "lblDo_color";
            this.lblDo_color.Size = new System.Drawing.Size(91, 13);
            this.lblDo_color.TabIndex = 3;
            this.lblDo_color.Text = "顏色做法";
            this.lblDo_color.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblID
            // 
            this.lblID.ForeColor = System.Drawing.Color.Blue;
            this.lblID.Location = new System.Drawing.Point(33, 13);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(77, 13);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "顏色編號";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "prd_type";
            this.dataGridViewTextBoxColumn1.HeaderText = "產品類型";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "prd_desc";
            this.dataGridViewTextBoxColumn2.HeaderText = "產品類型描述";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "prss_type";
            this.dataGridViewTextBoxColumn3.HeaderText = "工序組別分類";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "crusr";
            this.dataGridViewTextBoxColumn4.HeaderText = "建檔人";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "crtim";
            this.dataGridViewTextBoxColumn5.HeaderText = "建檔日期";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "amusr";
            this.dataGridViewTextBoxColumn6.HeaderText = "修改人";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "amtim";
            this.dataGridViewTextBoxColumn7.HeaderText = "修改日期";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // frmProcess_Type_Color
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 423);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.panel1);
            this.Name = "frmProcess_Type_Color";
            this.Text = "frmProcessTypeColor";
            this.Load += new System.EventHandler(this.frmProcess_Type_Color_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmtim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmusr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrtim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrusr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtGrind_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDo_color.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAmtim;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BTNNEW;
        private System.Windows.Forms.ToolStripButton BTNEDIT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton BTNSAVE;
        private System.Windows.Forms.ToolStripButton BTNCANCEL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton BTNDEL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton BTNFIND;
        private System.Windows.Forms.ToolStripButton BTNPRINT;
        private System.Windows.Forms.ToolStripButton BTNEXCEL;
        private System.Windows.Forms.Label lblCrtim;
        private System.Windows.Forms.Label lblCrusr;
        private System.Windows.Forms.Label lblAmusr;
        private DevExpress.XtraEditors.TextEdit txtAmtim;
        private DevExpress.XtraEditors.TextEdit txtAmusr;
        private DevExpress.XtraEditors.TextEdit txtCrtim;
        private DevExpress.XtraEditors.TextEdit txtCrusr;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblGrind_id;
        private System.Windows.Forms.Label lblDo_color;
        private System.Windows.Forms.Label lblID;
        private DevExpress.XtraEditors.LookUpEdit txtID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DevExpress.XtraEditors.TextEdit txtDo_color;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtGrind_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn color_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn do_color;
        private System.Windows.Forms.DataGridViewTextBoxColumn grind_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn crusr;
        private System.Windows.Forms.DataGridViewTextBoxColumn crtim;
        private System.Windows.Forms.DataGridViewTextBoxColumn amusr;
        private System.Windows.Forms.DataGridViewTextBoxColumn amtim;
    }
}