namespace cf01.Forms
{
    partial class frmWorking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWorking));
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblWk_kind = new System.Windows.Forms.Label();
            this.txtWk_kind = new DevExpress.XtraEditors.LookUpEdit();
            this.txtDept_desc = new DevExpress.XtraEditors.TextEdit();
            this.lblDept = new System.Windows.Forms.Label();
            this.txtDept = new DevExpress.XtraEditors.LookUpEdit();
            this.lblAmtim = new System.Windows.Forms.Label();
            this.lblAmusr = new System.Windows.Forms.Label();
            this.lblCrtim = new System.Windows.Forms.Label();
            this.lblCrusr = new System.Windows.Forms.Label();
            this.txtAmtim = new DevExpress.XtraEditors.TextEdit();
            this.txtAmusr = new DevExpress.XtraEditors.TextEdit();
            this.txtCrtim = new DevExpress.XtraEditors.TextEdit();
            this.txtCrusr = new DevExpress.XtraEditors.TextEdit();
            this.lblRemark = new System.Windows.Forms.Label();
            this.lblEdesc = new System.Windows.Forms.Label();
            this.txtEdesc = new DevExpress.XtraEditors.TextEdit();
            this.lblCdesc = new System.Windows.Forms.Label();
            this.txtCdesc = new DevExpress.XtraEditors.TextEdit();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNNEW = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNEDIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNSAVE = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNCANCEL = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNDEL = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNFIND = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNPRINT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNEXCEL = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWk_kind.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDept_desc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDept.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmtim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmusr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrtim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrusr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCdesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetails.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetails.Location = new System.Drawing.Point(1, 180);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(910, 324);
            this.dgvDetails.TabIndex = 12;
            this.dgvDetails.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDetails_RowPostPaint);
            this.dgvDetails.SelectionChanged += new System.EventHandler(this.dgvDetails_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblWk_kind);
            this.panel1.Controls.Add(this.txtWk_kind);
            this.panel1.Controls.Add(this.txtDept_desc);
            this.panel1.Controls.Add(this.lblDept);
            this.panel1.Controls.Add(this.txtDept);
            this.panel1.Controls.Add(this.lblAmtim);
            this.panel1.Controls.Add(this.lblAmusr);
            this.panel1.Controls.Add(this.lblCrtim);
            this.panel1.Controls.Add(this.lblCrusr);
            this.panel1.Controls.Add(this.txtAmtim);
            this.panel1.Controls.Add(this.txtAmusr);
            this.panel1.Controls.Add(this.txtCrtim);
            this.panel1.Controls.Add(this.txtCrusr);
            this.panel1.Controls.Add(this.lblRemark);
            this.panel1.Controls.Add(this.lblEdesc);
            this.panel1.Controls.Add(this.txtEdesc);
            this.panel1.Controls.Add(this.lblCdesc);
            this.panel1.Controls.Add(this.txtCdesc);
            this.panel1.Controls.Add(this.lblID);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.txtRemark);
            this.panel1.Location = new System.Drawing.Point(1, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(910, 153);
            this.panel1.TabIndex = 14;
            // 
            // lblWk_kind
            // 
            this.lblWk_kind.Location = new System.Drawing.Point(496, 13);
            this.lblWk_kind.Name = "lblWk_kind";
            this.lblWk_kind.Size = new System.Drawing.Size(70, 13);
            this.lblWk_kind.TabIndex = 36;
            this.lblWk_kind.Text = "工序種類";
            this.lblWk_kind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWk_kind
            // 
            this.txtWk_kind.EditValue = "";
            this.txtWk_kind.Enabled = false;
            this.txtWk_kind.EnterMoveNextControl = true;
            this.txtWk_kind.Location = new System.Drawing.Point(569, 10);
            this.txtWk_kind.Name = "txtWk_kind";
            this.txtWk_kind.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtWk_kind.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtWk_kind.Properties.DropDownRows = 5;
            this.txtWk_kind.Properties.MaxLength = 1;
            this.txtWk_kind.Properties.NullText = "";
            this.txtWk_kind.Properties.ShowHeader = false;
            this.txtWk_kind.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtWk_kind.Size = new System.Drawing.Size(140, 20);
            this.txtWk_kind.TabIndex = 35;
            this.txtWk_kind.Tag = "2";
            // 
            // txtDept_desc
            // 
            this.txtDept_desc.Enabled = false;
            this.txtDept_desc.EnterMoveNextControl = true;
            this.txtDept_desc.Location = new System.Drawing.Point(365, 10);
            this.txtDept_desc.Name = "txtDept_desc";
            this.txtDept_desc.Properties.ReadOnly = true;
            this.txtDept_desc.Size = new System.Drawing.Size(107, 20);
            this.txtDept_desc.TabIndex = 8;
            this.txtDept_desc.Tag = "2";
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(188, 13);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(70, 13);
            this.lblDept.TabIndex = 22;
            this.lblDept.Text = "部門";
            this.lblDept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDept
            // 
            this.txtDept.EditValue = "";
            this.txtDept.Enabled = false;
            this.txtDept.EnterMoveNextControl = true;
            this.txtDept.Location = new System.Drawing.Point(261, 10);
            this.txtDept.Name = "txtDept";
            this.txtDept.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDept.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDept.Properties.DropDownRows = 15;
            this.txtDept.Properties.MaxLength = 3;
            this.txtDept.Properties.NullText = "";
            this.txtDept.Properties.ShowHeader = false;
            this.txtDept.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtDept.Size = new System.Drawing.Size(104, 20);
            this.txtDept.TabIndex = 2;
            this.txtDept.Tag = "2";
            this.txtDept.Leave += new System.EventHandler(this.txtDept_Leave);
            // 
            // lblAmtim
            // 
            this.lblAmtim.Location = new System.Drawing.Point(493, 120);
            this.lblAmtim.Name = "lblAmtim";
            this.lblAmtim.Size = new System.Drawing.Size(73, 13);
            this.lblAmtim.TabIndex = 15;
            this.lblAmtim.Text = "修改日期";
            this.lblAmtim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAmusr
            // 
            this.lblAmusr.Location = new System.Drawing.Point(493, 91);
            this.lblAmusr.Name = "lblAmusr";
            this.lblAmusr.Size = new System.Drawing.Size(73, 13);
            this.lblAmusr.TabIndex = 14;
            this.lblAmusr.Text = "修改人";
            this.lblAmusr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCrtim
            // 
            this.lblCrtim.Location = new System.Drawing.Point(493, 65);
            this.lblCrtim.Name = "lblCrtim";
            this.lblCrtim.Size = new System.Drawing.Size(73, 13);
            this.lblCrtim.TabIndex = 13;
            this.lblCrtim.Text = "建檔日期";
            this.lblCrtim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCrusr
            // 
            this.lblCrusr.Location = new System.Drawing.Point(493, 39);
            this.lblCrusr.Name = "lblCrusr";
            this.lblCrusr.Size = new System.Drawing.Size(73, 12);
            this.lblCrusr.TabIndex = 12;
            this.lblCrusr.Text = "建檔人";
            this.lblCrusr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAmtim
            // 
            this.txtAmtim.Enabled = false;
            this.txtAmtim.Location = new System.Drawing.Point(569, 117);
            this.txtAmtim.Name = "txtAmtim";
            this.txtAmtim.Properties.ReadOnly = true;
            this.txtAmtim.Size = new System.Drawing.Size(140, 20);
            this.txtAmtim.TabIndex = 19;
            this.txtAmtim.Tag = "2";
            // 
            // txtAmusr
            // 
            this.txtAmusr.Enabled = false;
            this.txtAmusr.Location = new System.Drawing.Point(569, 90);
            this.txtAmusr.Name = "txtAmusr";
            this.txtAmusr.Properties.ReadOnly = true;
            this.txtAmusr.Size = new System.Drawing.Size(140, 20);
            this.txtAmusr.TabIndex = 18;
            this.txtAmusr.Tag = "2";
            // 
            // txtCrtim
            // 
            this.txtCrtim.Enabled = false;
            this.txtCrtim.Location = new System.Drawing.Point(569, 62);
            this.txtCrtim.Name = "txtCrtim";
            this.txtCrtim.Properties.ReadOnly = true;
            this.txtCrtim.Size = new System.Drawing.Size(140, 20);
            this.txtCrtim.TabIndex = 17;
            this.txtCrtim.Tag = "2";
            // 
            // txtCrusr
            // 
            this.txtCrusr.Enabled = false;
            this.txtCrusr.Location = new System.Drawing.Point(569, 36);
            this.txtCrusr.Name = "txtCrusr";
            this.txtCrusr.Properties.ReadOnly = true;
            this.txtCrusr.Size = new System.Drawing.Size(140, 20);
            this.txtCrusr.TabIndex = 16;
            this.txtCrusr.Tag = "2";
            // 
            // lblRemark
            // 
            this.lblRemark.Location = new System.Drawing.Point(3, 88);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(81, 13);
            this.lblRemark.TabIndex = 7;
            this.lblRemark.Text = "備注";
            this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEdesc
            // 
            this.lblEdesc.Location = new System.Drawing.Point(7, 63);
            this.lblEdesc.Name = "lblEdesc";
            this.lblEdesc.Size = new System.Drawing.Size(77, 13);
            this.lblEdesc.TabIndex = 5;
            this.lblEdesc.Text = "英文名稱";
            this.lblEdesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEdesc
            // 
            this.txtEdesc.EnterMoveNextControl = true;
            this.txtEdesc.Location = new System.Drawing.Point(89, 61);
            this.txtEdesc.Name = "txtEdesc";
            this.txtEdesc.Properties.ReadOnly = true;
            this.txtEdesc.Size = new System.Drawing.Size(383, 20);
            this.txtEdesc.TabIndex = 6;
            this.txtEdesc.Tag = "2";
            // 
            // lblCdesc
            // 
            this.lblCdesc.Location = new System.Drawing.Point(7, 38);
            this.lblCdesc.Name = "lblCdesc";
            this.lblCdesc.Size = new System.Drawing.Size(77, 13);
            this.lblCdesc.TabIndex = 3;
            this.lblCdesc.Text = "中文名稱";
            this.lblCdesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCdesc
            // 
            this.txtCdesc.EnterMoveNextControl = true;
            this.txtCdesc.Location = new System.Drawing.Point(89, 36);
            this.txtCdesc.Name = "txtCdesc";
            this.txtCdesc.Properties.ReadOnly = true;
            this.txtCdesc.Size = new System.Drawing.Size(383, 20);
            this.txtCdesc.TabIndex = 4;
            this.txtCdesc.Tag = "2";
            // 
            // lblID
            // 
            this.lblID.Location = new System.Drawing.Point(6, 13);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(77, 13);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "編號";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtID
            // 
            this.txtID.EnterMoveNextControl = true;
            this.txtID.Location = new System.Drawing.Point(89, 10);
            this.txtID.Name = "txtID";
            this.txtID.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtID.Properties.MaxLength = 10;
            this.txtID.Size = new System.Drawing.Size(93, 20);
            this.txtID.TabIndex = 1;
            this.txtID.Tag = "1";
            this.txtID.Leave += new System.EventHandler(this.txtID_Leave);
            // 
            // txtRemark
            // 
            this.txtRemark.EnterMoveNextControl = true;
            this.txtRemark.Location = new System.Drawing.Point(89, 87);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Properties.MaxLength = 255;
            this.txtRemark.Properties.ReadOnly = true;
            this.txtRemark.Size = new System.Drawing.Size(383, 50);
            this.txtRemark.TabIndex = 15;
            this.txtRemark.Tag = "2";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNEXIT,
            this.toolStripSeparator1,
            this.BTNNEW,
            this.toolStripSeparator5,
            this.BTNEDIT,
            this.toolStripSeparator2,
            this.BTNSAVE,
            this.toolStripSeparator6,
            this.BTNCANCEL,
            this.toolStripSeparator3,
            this.BTNDEL,
            this.toolStripSeparator4,
            this.BTNFIND,
            this.toolStripSeparator7,
            this.BTNPRINT,
            this.toolStripSeparator8,
            this.BTNEXCEL});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(912, 25);
            this.toolStrip1.TabIndex = 13;
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
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
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
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
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
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
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
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
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
            // frmWorking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 505);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmWorking";
            this.Text = "frmWorking";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmWorking_FormClosed);
            this.Load += new System.EventHandler(this.frmWorking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtWk_kind.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDept_desc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDept.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmtim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmusr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrtim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrusr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCdesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.TextEdit txtDept_desc;
        private System.Windows.Forms.Label lblDept;
        private DevExpress.XtraEditors.LookUpEdit txtDept;
        private System.Windows.Forms.Label lblAmtim;
        private System.Windows.Forms.Label lblAmusr;
        private System.Windows.Forms.Label lblCrtim;
        private System.Windows.Forms.Label lblCrusr;
        private DevExpress.XtraEditors.TextEdit txtAmtim;
        private DevExpress.XtraEditors.TextEdit txtAmusr;
        private DevExpress.XtraEditors.TextEdit txtCrtim;
        private DevExpress.XtraEditors.TextEdit txtCrusr;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Label lblEdesc;
        private DevExpress.XtraEditors.TextEdit txtEdesc;
        private System.Windows.Forms.Label lblCdesc;
        private DevExpress.XtraEditors.TextEdit txtCdesc;
        private System.Windows.Forms.Label lblID;
        private DevExpress.XtraEditors.TextEdit txtID;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BTNNEW;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton BTNEDIT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton BTNSAVE;
        private System.Windows.Forms.ToolStripButton BTNCANCEL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton BTNDEL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton BTNFIND;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton BTNPRINT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton BTNEXCEL;
        private System.Windows.Forms.Label lblWk_kind;
        private DevExpress.XtraEditors.LookUpEdit txtWk_kind;
    }
}