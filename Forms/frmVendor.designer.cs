namespace cf01.Forms
{
    partial class frmVendor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVendor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.BTNNEW = new System.Windows.Forms.ToolStripButton();
            this.BTNEDIT = new System.Windows.Forms.ToolStripButton();
            this.BTNSAVE = new System.Windows.Forms.ToolStripButton();
            this.BTNDELETE = new System.Windows.Forms.ToolStripButton();
            this.BTNCANCEL = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gboxQuery = new System.Windows.Forms.GroupBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtVendcode_Q = new System.Windows.Forms.TextBox();
            this.lblVendcode_Q = new System.Windows.Forms.Label();
            this.txtVend_en_name_Q = new System.Windows.Forms.TextBox();
            this.lblVendname_Q = new System.Windows.Forms.Label();
            this.txtVend_chs_name_Q = new System.Windows.Forms.TextBox();
            this.lblVendcname_Q = new System.Windows.Forms.Label();
            this.mktVendclose = new System.Windows.Forms.MaskedTextBox();
            this.mktxtVendopen = new System.Windows.Forms.MaskedTextBox();
            this.cmbVendcurr = new System.Windows.Forms.ComboBox();
            this.txtVend_chs_add3 = new System.Windows.Forms.TextBox();
            this.txtVend_chs_add2 = new System.Windows.Forms.TextBox();
            this.txtVendpterm = new System.Windows.Forms.TextBox();
            this.txtVendemail = new System.Windows.Forms.TextBox();
            this.txtVend_longchs_name = new System.Windows.Forms.TextBox();
            this.lblVendpterm = new System.Windows.Forms.Label();
            this.txtVendrmk = new System.Windows.Forms.TextBox();
            this.txtVend_chs_name = new System.Windows.Forms.TextBox();
            this.txtVend_chs_add1 = new System.Windows.Forms.TextBox();
            this.lblVendemail = new System.Windows.Forms.Label();
            this.txtVend_en_add3 = new System.Windows.Forms.TextBox();
            this.lblVendrmk = new System.Windows.Forms.Label();
            this.txtVendfax = new System.Windows.Forms.TextBox();
            this.lblVendclose = new System.Windows.Forms.Label();
            this.lblVend_chs_add = new System.Windows.Forms.Label();
            this.txtVendtel = new System.Windows.Forms.TextBox();
            this.lblVendcname = new System.Windows.Forms.Label();
            this.lblVendfax = new System.Windows.Forms.Label();
            this.lblVendtel = new System.Windows.Forms.Label();
            this.txtVend_en_add2 = new System.Windows.Forms.TextBox();
            this.txtVend_longen_name = new System.Windows.Forms.TextBox();
            this.txtVend_en_name = new System.Windows.Forms.TextBox();
            this.lblVendopen = new System.Windows.Forms.Label();
            this.txtVendctact = new System.Windows.Forms.TextBox();
            this.lblVendname = new System.Windows.Forms.Label();
            this.lblVendctact = new System.Windows.Forms.Label();
            this.txtVend_en_add1 = new System.Windows.Forms.TextBox();
            this.txtVendtype = new System.Windows.Forms.TextBox();
            this.lblVendcurr = new System.Windows.Forms.Label();
            this.txtVendcounn = new System.Windows.Forms.TextBox();
            this.lblVend_en_add = new System.Windows.Forms.Label();
            this.lblVendtype = new System.Windows.Forms.Label();
            this.lblVendcoun = new System.Windows.Forms.Label();
            this.txtVendcode = new System.Windows.Forms.TextBox();
            this.lblVendcode = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gboxQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNEXIT,
            this.BTNNEW,
            this.BTNEDIT,
            this.BTNSAVE,
            this.BTNDELETE,
            this.BTNCANCEL});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1066, 25);
            this.toolStrip1.TabIndex = 3;
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
            // BTNNEW
            // 
            this.BTNNEW.Image = ((System.Drawing.Image)(resources.GetObject("BTNNEW.Image")));
            this.BTNNEW.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNNEW.Name = "BTNNEW";
            this.BTNNEW.Size = new System.Drawing.Size(52, 22);
            this.BTNNEW.Text = "新增";
            this.BTNNEW.Click += new System.EventHandler(this.BTNNEW_Click);
            // 
            // BTNEDIT
            // 
            this.BTNEDIT.Image = ((System.Drawing.Image)(resources.GetObject("BTNEDIT.Image")));
            this.BTNEDIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEDIT.Name = "BTNEDIT";
            this.BTNEDIT.Size = new System.Drawing.Size(52, 22);
            this.BTNEDIT.Text = "編輯";
            this.BTNEDIT.Click += new System.EventHandler(this.BTNEDIT_Click);
            // 
            // BTNSAVE
            // 
            this.BTNSAVE.Image = ((System.Drawing.Image)(resources.GetObject("BTNSAVE.Image")));
            this.BTNSAVE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNSAVE.Name = "BTNSAVE";
            this.BTNSAVE.Size = new System.Drawing.Size(52, 22);
            this.BTNSAVE.Text = "保存";
            this.BTNSAVE.Click += new System.EventHandler(this.BTNSAVE_Click);
            // 
            // BTNDELETE
            // 
            this.BTNDELETE.Image = ((System.Drawing.Image)(resources.GetObject("BTNDELETE.Image")));
            this.BTNDELETE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNDELETE.Name = "BTNDELETE";
            this.BTNDELETE.Size = new System.Drawing.Size(52, 22);
            this.BTNDELETE.Text = "刪除";
            this.BTNDELETE.Click += new System.EventHandler(this.BTNDELETE_Click);
            // 
            // BTNCANCEL
            // 
            this.BTNCANCEL.Image = ((System.Drawing.Image)(resources.GetObject("BTNCANCEL.Image")));
            this.BTNCANCEL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNCANCEL.Name = "BTNCANCEL";
            this.BTNCANCEL.Size = new System.Drawing.Size(52, 22);
            this.BTNCANCEL.Text = "取消";
            this.BTNCANCEL.Click += new System.EventHandler(this.BTNCANCEL_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gboxQuery);
            this.splitContainer1.Panel1.Controls.Add(this.mktVendclose);
            this.splitContainer1.Panel1.Controls.Add(this.mktxtVendopen);
            this.splitContainer1.Panel1.Controls.Add(this.cmbVendcurr);
            this.splitContainer1.Panel1.Controls.Add(this.txtVend_chs_add3);
            this.splitContainer1.Panel1.Controls.Add(this.txtVend_chs_add2);
            this.splitContainer1.Panel1.Controls.Add(this.txtVendpterm);
            this.splitContainer1.Panel1.Controls.Add(this.txtVendemail);
            this.splitContainer1.Panel1.Controls.Add(this.txtVend_longchs_name);
            this.splitContainer1.Panel1.Controls.Add(this.lblVendpterm);
            this.splitContainer1.Panel1.Controls.Add(this.txtVendrmk);
            this.splitContainer1.Panel1.Controls.Add(this.txtVend_chs_name);
            this.splitContainer1.Panel1.Controls.Add(this.txtVend_chs_add1);
            this.splitContainer1.Panel1.Controls.Add(this.lblVendemail);
            this.splitContainer1.Panel1.Controls.Add(this.txtVend_en_add3);
            this.splitContainer1.Panel1.Controls.Add(this.lblVendrmk);
            this.splitContainer1.Panel1.Controls.Add(this.txtVendfax);
            this.splitContainer1.Panel1.Controls.Add(this.lblVendclose);
            this.splitContainer1.Panel1.Controls.Add(this.lblVend_chs_add);
            this.splitContainer1.Panel1.Controls.Add(this.txtVendtel);
            this.splitContainer1.Panel1.Controls.Add(this.lblVendcname);
            this.splitContainer1.Panel1.Controls.Add(this.lblVendfax);
            this.splitContainer1.Panel1.Controls.Add(this.lblVendtel);
            this.splitContainer1.Panel1.Controls.Add(this.txtVend_en_add2);
            this.splitContainer1.Panel1.Controls.Add(this.txtVend_longen_name);
            this.splitContainer1.Panel1.Controls.Add(this.txtVend_en_name);
            this.splitContainer1.Panel1.Controls.Add(this.lblVendopen);
            this.splitContainer1.Panel1.Controls.Add(this.txtVendctact);
            this.splitContainer1.Panel1.Controls.Add(this.lblVendname);
            this.splitContainer1.Panel1.Controls.Add(this.lblVendctact);
            this.splitContainer1.Panel1.Controls.Add(this.txtVend_en_add1);
            this.splitContainer1.Panel1.Controls.Add(this.txtVendtype);
            this.splitContainer1.Panel1.Controls.Add(this.lblVendcurr);
            this.splitContainer1.Panel1.Controls.Add(this.txtVendcounn);
            this.splitContainer1.Panel1.Controls.Add(this.lblVend_en_add);
            this.splitContainer1.Panel1.Controls.Add(this.lblVendtype);
            this.splitContainer1.Panel1.Controls.Add(this.lblVendcoun);
            this.splitContainer1.Panel1.Controls.Add(this.txtVendcode);
            this.splitContainer1.Panel1.Controls.Add(this.lblVendcode);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetails);
            this.splitContainer1.Size = new System.Drawing.Size(1066, 657);
            this.splitContainer1.SplitterDistance = 269;
            this.splitContainer1.TabIndex = 4;
            // 
            // gboxQuery
            // 
            this.gboxQuery.Controls.Add(this.btnQuery);
            this.gboxQuery.Controls.Add(this.txtVendcode_Q);
            this.gboxQuery.Controls.Add(this.lblVendcode_Q);
            this.gboxQuery.Controls.Add(this.txtVend_en_name_Q);
            this.gboxQuery.Controls.Add(this.lblVendname_Q);
            this.gboxQuery.Controls.Add(this.txtVend_chs_name_Q);
            this.gboxQuery.Controls.Add(this.lblVendcname_Q);
            this.gboxQuery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gboxQuery.Location = new System.Drawing.Point(-2, 205);
            this.gboxQuery.Name = "gboxQuery";
            this.gboxQuery.Size = new System.Drawing.Size(1064, 63);
            this.gboxQuery.TabIndex = 27;
            this.gboxQuery.TabStop = false;
            this.gboxQuery.Text = "查詢框";
            // 
            // btnQuery
            // 
            this.btnQuery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnQuery.Location = new System.Drawing.Point(899, 24);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 25;
            this.btnQuery.Text = "查詢";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtVendcode_Q
            // 
            this.txtVendcode_Q.Location = new System.Drawing.Point(83, 26);
            this.txtVendcode_Q.MaxLength = 8;
            this.txtVendcode_Q.Name = "txtVendcode_Q";
            this.txtVendcode_Q.Size = new System.Drawing.Size(140, 22);
            this.txtVendcode_Q.TabIndex = 22;
            // 
            // lblVendcode_Q
            // 
            this.lblVendcode_Q.AutoSize = true;
            this.lblVendcode_Q.Location = new System.Drawing.Point(4, 29);
            this.lblVendcode_Q.Name = "lblVendcode_Q";
            this.lblVendcode_Q.Size = new System.Drawing.Size(41, 12);
            this.lblVendcode_Q.TabIndex = 0;
            this.lblVendcode_Q.Text = "客戶ID";
            // 
            // txtVend_en_name_Q
            // 
            this.txtVend_en_name_Q.Location = new System.Drawing.Point(335, 26);
            this.txtVend_en_name_Q.Name = "txtVend_en_name_Q";
            this.txtVend_en_name_Q.Size = new System.Drawing.Size(200, 22);
            this.txtVend_en_name_Q.TabIndex = 23;
            // 
            // lblVendname_Q
            // 
            this.lblVendname_Q.AutoSize = true;
            this.lblVendname_Q.Location = new System.Drawing.Point(256, 29);
            this.lblVendname_Q.Name = "lblVendname_Q";
            this.lblVendname_Q.Size = new System.Drawing.Size(76, 12);
            this.lblVendname_Q.TabIndex = 0;
            this.lblVendname_Q.Text = "客戶名稱(EN)";
            // 
            // txtVend_chs_name_Q
            // 
            this.txtVend_chs_name_Q.Location = new System.Drawing.Point(650, 26);
            this.txtVend_chs_name_Q.Name = "txtVend_chs_name_Q";
            this.txtVend_chs_name_Q.Size = new System.Drawing.Size(200, 22);
            this.txtVend_chs_name_Q.TabIndex = 24;
            // 
            // lblVendcname_Q
            // 
            this.lblVendcname_Q.AutoSize = true;
            this.lblVendcname_Q.Location = new System.Drawing.Point(565, 29);
            this.lblVendcname_Q.Name = "lblVendcname_Q";
            this.lblVendcname_Q.Size = new System.Drawing.Size(83, 12);
            this.lblVendcname_Q.TabIndex = 0;
            this.lblVendcname_Q.Text = "客戶名稱(CHS)";
            // 
            // mktVendclose
            // 
            this.mktVendclose.Location = new System.Drawing.Point(918, 78);
            this.mktVendclose.Mask = "0000/00/00";
            this.mktVendclose.Name = "mktVendclose";
            this.mktVendclose.Size = new System.Drawing.Size(141, 22);
            this.mktVendclose.TabIndex = 20;
            this.mktVendclose.ValidatingType = typeof(System.DateTime);
            // 
            // mktxtVendopen
            // 
            this.mktxtVendopen.Location = new System.Drawing.Point(918, 41);
            this.mktxtVendopen.Mask = "0000/00/00";
            this.mktxtVendopen.Name = "mktxtVendopen";
            this.mktxtVendopen.Size = new System.Drawing.Size(141, 22);
            this.mktxtVendopen.TabIndex = 19;
            this.mktxtVendopen.ValidatingType = typeof(System.DateTime);
            // 
            // cmbVendcurr
            // 
            this.cmbVendcurr.FormattingEnabled = true;
            this.cmbVendcurr.Location = new System.Drawing.Point(918, 9);
            this.cmbVendcurr.Name = "cmbVendcurr";
            this.cmbVendcurr.Size = new System.Drawing.Size(141, 20);
            this.cmbVendcurr.TabIndex = 18;
            // 
            // txtVend_chs_add3
            // 
            this.txtVend_chs_add3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtVend_chs_add3.Location = new System.Drawing.Point(491, 140);
            this.txtVend_chs_add3.Name = "txtVend_chs_add3";
            this.txtVend_chs_add3.Size = new System.Drawing.Size(360, 22);
            this.txtVend_chs_add3.TabIndex = 17;
            this.txtVend_chs_add3.Text = "中文地址3";
            this.txtVend_chs_add3.Enter += new System.EventHandler(this.txtVend_chs_add3_Enter);
            // 
            // txtVend_chs_add2
            // 
            this.txtVend_chs_add2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtVend_chs_add2.Location = new System.Drawing.Point(491, 118);
            this.txtVend_chs_add2.Name = "txtVend_chs_add2";
            this.txtVend_chs_add2.Size = new System.Drawing.Size(360, 22);
            this.txtVend_chs_add2.TabIndex = 16;
            this.txtVend_chs_add2.Text = "中文地址2";
            this.txtVend_chs_add2.Enter += new System.EventHandler(this.txtVend_chs_add2_Enter);
            // 
            // txtVendpterm
            // 
            this.txtVendpterm.Location = new System.Drawing.Point(338, 180);
            this.txtVendpterm.Name = "txtVendpterm";
            this.txtVendpterm.Size = new System.Drawing.Size(140, 22);
            this.txtVendpterm.TabIndex = 11;
            // 
            // txtVendemail
            // 
            this.txtVendemail.Location = new System.Drawing.Point(338, 150);
            this.txtVendemail.Name = "txtVendemail";
            this.txtVendemail.Size = new System.Drawing.Size(140, 22);
            this.txtVendemail.TabIndex = 10;
            // 
            // txtVend_longchs_name
            // 
            this.txtVend_longchs_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtVend_longchs_name.Location = new System.Drawing.Point(7, 162);
            this.txtVend_longchs_name.Multiline = true;
            this.txtVend_longchs_name.Name = "txtVend_longchs_name";
            this.txtVend_longchs_name.Size = new System.Drawing.Size(277, 40);
            this.txtVend_longchs_name.TabIndex = 5;
            this.txtVend_longchs_name.Text = "供應商中文全稱";
            this.txtVend_longchs_name.Enter += new System.EventHandler(this.txtVend_longchs_name_Enter);
            // 
            // lblVendpterm
            // 
            this.lblVendpterm.AutoSize = true;
            this.lblVendpterm.Location = new System.Drawing.Point(299, 183);
            this.lblVendpterm.Name = "lblVendpterm";
            this.lblVendpterm.Size = new System.Drawing.Size(29, 12);
            this.lblVendpterm.TabIndex = 40;
            this.lblVendpterm.Text = "條款";
            // 
            // txtVendrmk
            // 
            this.txtVendrmk.Location = new System.Drawing.Point(900, 110);
            this.txtVendrmk.Multiline = true;
            this.txtVendrmk.Name = "txtVendrmk";
            this.txtVendrmk.Size = new System.Drawing.Size(159, 92);
            this.txtVendrmk.TabIndex = 21;
            // 
            // txtVend_chs_name
            // 
            this.txtVend_chs_name.Location = new System.Drawing.Point(96, 140);
            this.txtVend_chs_name.Name = "txtVend_chs_name";
            this.txtVend_chs_name.Size = new System.Drawing.Size(188, 22);
            this.txtVend_chs_name.TabIndex = 4;
            // 
            // txtVend_chs_add1
            // 
            this.txtVend_chs_add1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtVend_chs_add1.Location = new System.Drawing.Point(547, 96);
            this.txtVend_chs_add1.Name = "txtVend_chs_add1";
            this.txtVend_chs_add1.Size = new System.Drawing.Size(304, 22);
            this.txtVend_chs_add1.TabIndex = 15;
            this.txtVend_chs_add1.Text = "中文地址1";
            this.txtVend_chs_add1.Enter += new System.EventHandler(this.txtVend_chs_add1_Enter);
            // 
            // lblVendemail
            // 
            this.lblVendemail.AutoSize = true;
            this.lblVendemail.Location = new System.Drawing.Point(299, 153);
            this.lblVendemail.Name = "lblVendemail";
            this.lblVendemail.Size = new System.Drawing.Size(29, 12);
            this.lblVendemail.TabIndex = 26;
            this.lblVendemail.Text = "郵箱";
            // 
            // txtVend_en_add3
            // 
            this.txtVend_en_add3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtVend_en_add3.Location = new System.Drawing.Point(491, 53);
            this.txtVend_en_add3.Name = "txtVend_en_add3";
            this.txtVend_en_add3.Size = new System.Drawing.Size(360, 22);
            this.txtVend_en_add3.TabIndex = 14;
            this.txtVend_en_add3.Text = "英文地址3";
            this.txtVend_en_add3.Enter += new System.EventHandler(this.txtVend_en_add3_Enter);
            // 
            // lblVendrmk
            // 
            this.lblVendrmk.AutoSize = true;
            this.lblVendrmk.Location = new System.Drawing.Point(865, 116);
            this.lblVendrmk.Name = "lblVendrmk";
            this.lblVendrmk.Size = new System.Drawing.Size(29, 12);
            this.lblVendrmk.TabIndex = 25;
            this.lblVendrmk.Text = "備註";
            // 
            // txtVendfax
            // 
            this.txtVendfax.Location = new System.Drawing.Point(338, 116);
            this.txtVendfax.Name = "txtVendfax";
            this.txtVendfax.Size = new System.Drawing.Size(140, 22);
            this.txtVendfax.TabIndex = 9;
            // 
            // lblVendclose
            // 
            this.lblVendclose.AutoSize = true;
            this.lblVendclose.Location = new System.Drawing.Point(865, 81);
            this.lblVendclose.Name = "lblVendclose";
            this.lblVendclose.Size = new System.Drawing.Size(53, 12);
            this.lblVendclose.TabIndex = 24;
            this.lblVendclose.Text = "註銷時間";
            // 
            // lblVend_chs_add
            // 
            this.lblVend_chs_add.AutoSize = true;
            this.lblVend_chs_add.Location = new System.Drawing.Point(489, 99);
            this.lblVend_chs_add.Name = "lblVend_chs_add";
            this.lblVend_chs_add.Size = new System.Drawing.Size(59, 12);
            this.lblVend_chs_add.TabIndex = 31;
            this.lblVend_chs_add.Text = "地址(CHS)";
            // 
            // txtVendtel
            // 
            this.txtVendtel.Location = new System.Drawing.Point(338, 80);
            this.txtVendtel.Name = "txtVendtel";
            this.txtVendtel.Size = new System.Drawing.Size(140, 22);
            this.txtVendtel.TabIndex = 8;
            // 
            // lblVendcname
            // 
            this.lblVendcname.AutoSize = true;
            this.lblVendcname.Location = new System.Drawing.Point(1, 142);
            this.lblVendcname.Name = "lblVendcname";
            this.lblVendcname.Size = new System.Drawing.Size(95, 12);
            this.lblVendcname.TabIndex = 32;
            this.lblVendcname.Text = "供應商名稱(CHS)";
            // 
            // lblVendfax
            // 
            this.lblVendfax.AutoSize = true;
            this.lblVendfax.Location = new System.Drawing.Point(299, 119);
            this.lblVendfax.Name = "lblVendfax";
            this.lblVendfax.Size = new System.Drawing.Size(29, 12);
            this.lblVendfax.TabIndex = 30;
            this.lblVendfax.Text = "傳真";
            // 
            // lblVendtel
            // 
            this.lblVendtel.AutoSize = true;
            this.lblVendtel.Location = new System.Drawing.Point(299, 86);
            this.lblVendtel.Name = "lblVendtel";
            this.lblVendtel.Size = new System.Drawing.Size(29, 12);
            this.lblVendtel.TabIndex = 28;
            this.lblVendtel.Text = "電話";
            // 
            // txtVend_en_add2
            // 
            this.txtVend_en_add2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtVend_en_add2.Location = new System.Drawing.Point(491, 31);
            this.txtVend_en_add2.Name = "txtVend_en_add2";
            this.txtVend_en_add2.Size = new System.Drawing.Size(360, 22);
            this.txtVend_en_add2.TabIndex = 13;
            this.txtVend_en_add2.Text = "英文地址2";
            this.txtVend_en_add2.Enter += new System.EventHandler(this.txtVend_en_add2_Enter);
            // 
            // txtVend_longen_name
            // 
            this.txtVend_longen_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtVend_longen_name.Location = new System.Drawing.Point(7, 94);
            this.txtVend_longen_name.Multiline = true;
            this.txtVend_longen_name.Name = "txtVend_longen_name";
            this.txtVend_longen_name.Size = new System.Drawing.Size(277, 40);
            this.txtVend_longen_name.TabIndex = 3;
            this.txtVend_longen_name.Text = "供應商英文全稱";
            this.txtVend_longen_name.Enter += new System.EventHandler(this.txtVend_longen_name_Enter);
            // 
            // txtVend_en_name
            // 
            this.txtVend_en_name.Location = new System.Drawing.Point(100, 72);
            this.txtVend_en_name.Name = "txtVend_en_name";
            this.txtVend_en_name.Size = new System.Drawing.Size(184, 22);
            this.txtVend_en_name.TabIndex = 2;
            // 
            // lblVendopen
            // 
            this.lblVendopen.AutoSize = true;
            this.lblVendopen.Location = new System.Drawing.Point(865, 48);
            this.lblVendopen.Name = "lblVendopen";
            this.lblVendopen.Size = new System.Drawing.Size(53, 12);
            this.lblVendopen.TabIndex = 29;
            this.lblVendopen.Text = "開戶時間";
            // 
            // txtVendctact
            // 
            this.txtVendctact.Location = new System.Drawing.Point(338, 47);
            this.txtVendctact.Name = "txtVendctact";
            this.txtVendctact.Size = new System.Drawing.Size(140, 22);
            this.txtVendctact.TabIndex = 7;
            // 
            // lblVendname
            // 
            this.lblVendname.AutoSize = true;
            this.lblVendname.Location = new System.Drawing.Point(5, 75);
            this.lblVendname.Name = "lblVendname";
            this.lblVendname.Size = new System.Drawing.Size(88, 12);
            this.lblVendname.TabIndex = 23;
            this.lblVendname.Text = "供應商名稱(EN)";
            // 
            // lblVendctact
            // 
            this.lblVendctact.AutoSize = true;
            this.lblVendctact.Location = new System.Drawing.Point(296, 53);
            this.lblVendctact.Name = "lblVendctact";
            this.lblVendctact.Size = new System.Drawing.Size(41, 12);
            this.lblVendctact.TabIndex = 27;
            this.lblVendctact.Text = "聯繫人";
            // 
            // txtVend_en_add1
            // 
            this.txtVend_en_add1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtVend_en_add1.Location = new System.Drawing.Point(547, 9);
            this.txtVend_en_add1.Name = "txtVend_en_add1";
            this.txtVend_en_add1.Size = new System.Drawing.Size(304, 22);
            this.txtVend_en_add1.TabIndex = 12;
            this.txtVend_en_add1.Text = "英文地址1";
            this.txtVend_en_add1.Enter += new System.EventHandler(this.txtVend_en_add1_Enter);
            // 
            // txtVendtype
            // 
            this.txtVendtype.Location = new System.Drawing.Point(100, 41);
            this.txtVendtype.Name = "txtVendtype";
            this.txtVendtype.Size = new System.Drawing.Size(140, 22);
            this.txtVendtype.TabIndex = 1;
            // 
            // lblVendcurr
            // 
            this.lblVendcurr.AutoSize = true;
            this.lblVendcurr.Location = new System.Drawing.Point(865, 15);
            this.lblVendcurr.Name = "lblVendcurr";
            this.lblVendcurr.Size = new System.Drawing.Size(53, 12);
            this.lblVendcurr.TabIndex = 39;
            this.lblVendcurr.Text = "貨幣類型";
            // 
            // txtVendcounn
            // 
            this.txtVendcounn.Location = new System.Drawing.Point(338, 9);
            this.txtVendcounn.Name = "txtVendcounn";
            this.txtVendcounn.Size = new System.Drawing.Size(140, 22);
            this.txtVendcounn.TabIndex = 6;
            // 
            // lblVend_en_add
            // 
            this.lblVend_en_add.AutoSize = true;
            this.lblVend_en_add.Location = new System.Drawing.Point(489, 15);
            this.lblVend_en_add.Name = "lblVend_en_add";
            this.lblVend_en_add.Size = new System.Drawing.Size(52, 12);
            this.lblVend_en_add.TabIndex = 38;
            this.lblVend_en_add.Text = "地址(EN)";
            // 
            // lblVendtype
            // 
            this.lblVendtype.AutoSize = true;
            this.lblVendtype.Location = new System.Drawing.Point(5, 44);
            this.lblVendtype.Name = "lblVendtype";
            this.lblVendtype.Size = new System.Drawing.Size(65, 12);
            this.lblVendtype.TabIndex = 35;
            this.lblVendtype.Text = "供應商類型";
            // 
            // lblVendcoun
            // 
            this.lblVendcoun.AutoSize = true;
            this.lblVendcoun.Location = new System.Drawing.Point(296, 15);
            this.lblVendcoun.Name = "lblVendcoun";
            this.lblVendcoun.Size = new System.Drawing.Size(29, 12);
            this.lblVendcoun.TabIndex = 36;
            this.lblVendcoun.Text = "帳戶";
            // 
            // txtVendcode
            // 
            this.txtVendcode.Location = new System.Drawing.Point(100, 9);
            this.txtVendcode.MaxLength = 8;
            this.txtVendcode.Name = "txtVendcode";
            this.txtVendcode.Size = new System.Drawing.Size(140, 22);
            this.txtVendcode.TabIndex = 0;
            // 
            // lblVendcode
            // 
            this.lblVendcode.AutoSize = true;
            this.lblVendcode.Location = new System.Drawing.Point(5, 15);
            this.lblVendcode.Name = "lblVendcode";
            this.lblVendcode.Size = new System.Drawing.Size(53, 12);
            this.lblVendcode.TabIndex = 37;
            this.lblVendcode.Text = "供應商ID";
            // 
            // dgvDetails
            // 
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(1062, 380);
            this.dgvDetails.TabIndex = 26;
            this.dgvDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellClick);
            // 
            // frmVendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 682);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmVendor";
            this.Text = "frmVendor";
            this.Load += new System.EventHandler(this.frmVendor_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gboxQuery.ResumeLayout(false);
            this.gboxQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripButton BTNNEW;
        private System.Windows.Forms.ToolStripButton BTNEDIT;
        private System.Windows.Forms.ToolStripButton BTNSAVE;
        private System.Windows.Forms.ToolStripButton BTNDELETE;
        private System.Windows.Forms.ToolStripButton BTNCANCEL;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.ComboBox cmbVendcurr;
        private System.Windows.Forms.TextBox txtVend_chs_add3;
        private System.Windows.Forms.TextBox txtVend_chs_add2;
        private System.Windows.Forms.TextBox txtVendpterm;
        private System.Windows.Forms.TextBox txtVendemail;
        private System.Windows.Forms.TextBox txtVend_longchs_name;
        private System.Windows.Forms.Label lblVendpterm;
        private System.Windows.Forms.TextBox txtVendrmk;
        private System.Windows.Forms.TextBox txtVend_chs_name;
        private System.Windows.Forms.TextBox txtVend_chs_add1;
        private System.Windows.Forms.Label lblVendemail;
        private System.Windows.Forms.TextBox txtVend_en_add3;
        private System.Windows.Forms.Label lblVendrmk;
        private System.Windows.Forms.TextBox txtVendfax;
        private System.Windows.Forms.Label lblVendclose;
        private System.Windows.Forms.Label lblVend_chs_add;
        private System.Windows.Forms.TextBox txtVendtel;
        private System.Windows.Forms.Label lblVendcname;
        private System.Windows.Forms.Label lblVendfax;
        private System.Windows.Forms.Label lblVendtel;
        private System.Windows.Forms.TextBox txtVend_en_add2;
        private System.Windows.Forms.TextBox txtVend_longen_name;
        private System.Windows.Forms.TextBox txtVend_en_name;
        private System.Windows.Forms.Label lblVendopen;
        private System.Windows.Forms.TextBox txtVendctact;
        private System.Windows.Forms.Label lblVendname;
        private System.Windows.Forms.Label lblVendctact;
        private System.Windows.Forms.TextBox txtVend_en_add1;
        private System.Windows.Forms.TextBox txtVendtype;
        private System.Windows.Forms.Label lblVendcurr;
        private System.Windows.Forms.TextBox txtVendcounn;
        private System.Windows.Forms.Label lblVend_en_add;
        private System.Windows.Forms.Label lblVendtype;
        private System.Windows.Forms.Label lblVendcoun;
        private System.Windows.Forms.TextBox txtVendcode;
        private System.Windows.Forms.Label lblVendcode;
        private System.Windows.Forms.GroupBox gboxQuery;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtVendcode_Q;
        private System.Windows.Forms.Label lblVendcode_Q;
        private System.Windows.Forms.TextBox txtVend_en_name_Q;
        private System.Windows.Forms.Label lblVendname_Q;
        private System.Windows.Forms.TextBox txtVend_chs_name_Q;
        private System.Windows.Forms.Label lblVendcname_Q;
        private System.Windows.Forms.MaskedTextBox mktVendclose;
        private System.Windows.Forms.MaskedTextBox mktxtVendopen;
    }
}