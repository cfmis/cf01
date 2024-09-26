namespace cf01.Forms
{
    partial class frmCustomerInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerInfo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.BTNNEW = new System.Windows.Forms.ToolStripButton();
            this.BTNEDIT = new System.Windows.Forms.ToolStripButton();
            this.BTNSAVE = new System.Windows.Forms.ToolStripButton();
            this.BTNDELETE = new System.Windows.Forms.ToolStripButton();
            this.BTNCANCEL = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.gboxQuery = new System.Windows.Forms.GroupBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtCustcode_Q = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCust_en_name_Q = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCust_chs_name_Q = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mktxtCustclose = new System.Windows.Forms.MaskedTextBox();
            this.mktxtCustopen = new System.Windows.Forms.MaskedTextBox();
            this.cmbCustcurr = new System.Windows.Forms.ComboBox();
            this.txtCust_chs_add3 = new System.Windows.Forms.TextBox();
            this.txtCust_chs_add2 = new System.Windows.Forms.TextBox();
            this.txtCustpterm = new System.Windows.Forms.TextBox();
            this.txtCustemail = new System.Windows.Forms.TextBox();
            this.lblCustarea = new System.Windows.Forms.Label();
            this.txtCust_longchs_name = new System.Windows.Forms.TextBox();
            this.lblCustpterm = new System.Windows.Forms.Label();
            this.txtCustrmk = new System.Windows.Forms.TextBox();
            this.txtCust_chs_name = new System.Windows.Forms.TextBox();
            this.txtCust_chs_add1 = new System.Windows.Forms.TextBox();
            this.lblCustemail = new System.Windows.Forms.Label();
            this.txtCust_en_add3 = new System.Windows.Forms.TextBox();
            this.lblCustrmk = new System.Windows.Forms.Label();
            this.txtCustfax = new System.Windows.Forms.TextBox();
            this.lblCustclose = new System.Windows.Forms.Label();
            this.lblCust_chs_add = new System.Windows.Forms.Label();
            this.txtCusttel = new System.Windows.Forms.TextBox();
            this.lblCustcname = new System.Windows.Forms.Label();
            this.lblCustfax = new System.Windows.Forms.Label();
            this.lblCusttel = new System.Windows.Forms.Label();
            this.txtCust_en_add2 = new System.Windows.Forms.TextBox();
            this.txtcust_longen_name = new System.Windows.Forms.TextBox();
            this.txtCust_en_name = new System.Windows.Forms.TextBox();
            this.lblCustopen = new System.Windows.Forms.Label();
            this.txtCustctact = new System.Windows.Forms.TextBox();
            this.lblCustname = new System.Windows.Forms.Label();
            this.lblCustctact = new System.Windows.Forms.Label();
            this.txtCust_en_add1 = new System.Windows.Forms.TextBox();
            this.txtCusttype = new System.Windows.Forms.TextBox();
            this.lblCustcurr = new System.Windows.Forms.Label();
            this.txtCustcounn = new System.Windows.Forms.TextBox();
            this.lblCust_en_add = new System.Windows.Forms.Label();
            this.lblCusttype = new System.Windows.Forms.Label();
            this.lblCustcoun = new System.Windows.Forms.Label();
            this.txtCustcode = new System.Windows.Forms.TextBox();
            this.lblCustcode = new System.Windows.Forms.Label();
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
            this.toolStrip1.TabIndex = 2;
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
            this.splitContainer1.Panel1.Controls.Add(this.cmbArea);
            this.splitContainer1.Panel1.Controls.Add(this.gboxQuery);
            this.splitContainer1.Panel1.Controls.Add(this.mktxtCustclose);
            this.splitContainer1.Panel1.Controls.Add(this.mktxtCustopen);
            this.splitContainer1.Panel1.Controls.Add(this.cmbCustcurr);
            this.splitContainer1.Panel1.Controls.Add(this.txtCust_chs_add3);
            this.splitContainer1.Panel1.Controls.Add(this.txtCust_chs_add2);
            this.splitContainer1.Panel1.Controls.Add(this.txtCustpterm);
            this.splitContainer1.Panel1.Controls.Add(this.txtCustemail);
            this.splitContainer1.Panel1.Controls.Add(this.lblCustarea);
            this.splitContainer1.Panel1.Controls.Add(this.txtCust_longchs_name);
            this.splitContainer1.Panel1.Controls.Add(this.lblCustpterm);
            this.splitContainer1.Panel1.Controls.Add(this.txtCustrmk);
            this.splitContainer1.Panel1.Controls.Add(this.txtCust_chs_name);
            this.splitContainer1.Panel1.Controls.Add(this.txtCust_chs_add1);
            this.splitContainer1.Panel1.Controls.Add(this.lblCustemail);
            this.splitContainer1.Panel1.Controls.Add(this.txtCust_en_add3);
            this.splitContainer1.Panel1.Controls.Add(this.lblCustrmk);
            this.splitContainer1.Panel1.Controls.Add(this.txtCustfax);
            this.splitContainer1.Panel1.Controls.Add(this.lblCustclose);
            this.splitContainer1.Panel1.Controls.Add(this.lblCust_chs_add);
            this.splitContainer1.Panel1.Controls.Add(this.txtCusttel);
            this.splitContainer1.Panel1.Controls.Add(this.lblCustcname);
            this.splitContainer1.Panel1.Controls.Add(this.lblCustfax);
            this.splitContainer1.Panel1.Controls.Add(this.lblCusttel);
            this.splitContainer1.Panel1.Controls.Add(this.txtCust_en_add2);
            this.splitContainer1.Panel1.Controls.Add(this.txtcust_longen_name);
            this.splitContainer1.Panel1.Controls.Add(this.txtCust_en_name);
            this.splitContainer1.Panel1.Controls.Add(this.lblCustopen);
            this.splitContainer1.Panel1.Controls.Add(this.txtCustctact);
            this.splitContainer1.Panel1.Controls.Add(this.lblCustname);
            this.splitContainer1.Panel1.Controls.Add(this.lblCustctact);
            this.splitContainer1.Panel1.Controls.Add(this.txtCust_en_add1);
            this.splitContainer1.Panel1.Controls.Add(this.txtCusttype);
            this.splitContainer1.Panel1.Controls.Add(this.lblCustcurr);
            this.splitContainer1.Panel1.Controls.Add(this.txtCustcounn);
            this.splitContainer1.Panel1.Controls.Add(this.lblCust_en_add);
            this.splitContainer1.Panel1.Controls.Add(this.lblCusttype);
            this.splitContainer1.Panel1.Controls.Add(this.lblCustcoun);
            this.splitContainer1.Panel1.Controls.Add(this.txtCustcode);
            this.splitContainer1.Panel1.Controls.Add(this.lblCustcode);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetails);
            this.splitContainer1.Size = new System.Drawing.Size(1066, 657);
            this.splitContainer1.SplitterDistance = 274;
            this.splitContainer1.TabIndex = 3;
            // 
            // cmbArea
            // 
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(547, 183);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(208, 20);
            this.cmbArea.TabIndex = 24;
            // 
            // gboxQuery
            // 
            this.gboxQuery.Controls.Add(this.btnQuery);
            this.gboxQuery.Controls.Add(this.txtCustcode_Q);
            this.gboxQuery.Controls.Add(this.label1);
            this.gboxQuery.Controls.Add(this.txtCust_en_name_Q);
            this.gboxQuery.Controls.Add(this.label2);
            this.gboxQuery.Controls.Add(this.txtCust_chs_name_Q);
            this.gboxQuery.Controls.Add(this.label3);
            this.gboxQuery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gboxQuery.Location = new System.Drawing.Point(0, 212);
            this.gboxQuery.Name = "gboxQuery";
            this.gboxQuery.Size = new System.Drawing.Size(1064, 63);
            this.gboxQuery.TabIndex = 28;
            this.gboxQuery.TabStop = false;
            this.gboxQuery.Text = "查詢框";
            // 
            // btnQuery
            // 
            this.btnQuery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnQuery.Location = new System.Drawing.Point(899, 24);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 26;
            this.btnQuery.Text = "查詢";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtCustcode_Q
            // 
            this.txtCustcode_Q.Location = new System.Drawing.Point(83, 26);
            this.txtCustcode_Q.MaxLength = 8;
            this.txtCustcode_Q.Name = "txtCustcode_Q";
            this.txtCustcode_Q.Size = new System.Drawing.Size(140, 22);
            this.txtCustcode_Q.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "客戶ID";
            // 
            // txtCust_en_name_Q
            // 
            this.txtCust_en_name_Q.Location = new System.Drawing.Point(335, 26);
            this.txtCust_en_name_Q.Name = "txtCust_en_name_Q";
            this.txtCust_en_name_Q.Size = new System.Drawing.Size(200, 22);
            this.txtCust_en_name_Q.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "客戶名稱(EN)";
            // 
            // txtCust_chs_name_Q
            // 
            this.txtCust_chs_name_Q.Location = new System.Drawing.Point(650, 26);
            this.txtCust_chs_name_Q.Name = "txtCust_chs_name_Q";
            this.txtCust_chs_name_Q.Size = new System.Drawing.Size(200, 22);
            this.txtCust_chs_name_Q.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(565, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "客戶名稱(CHS)";
            // 
            // mktxtCustclose
            // 
            this.mktxtCustclose.Location = new System.Drawing.Point(919, 78);
            this.mktxtCustclose.Mask = "0000/00/00";
            this.mktxtCustclose.Name = "mktxtCustclose";
            this.mktxtCustclose.Size = new System.Drawing.Size(140, 22);
            this.mktxtCustclose.TabIndex = 21;
            this.mktxtCustclose.ValidatingType = typeof(System.DateTime);
            // 
            // mktxtCustopen
            // 
            this.mktxtCustopen.Location = new System.Drawing.Point(919, 42);
            this.mktxtCustopen.Mask = "0000/00/00";
            this.mktxtCustopen.Name = "mktxtCustopen";
            this.mktxtCustopen.Size = new System.Drawing.Size(140, 22);
            this.mktxtCustopen.TabIndex = 20;
            this.mktxtCustopen.ValidatingType = typeof(System.DateTime);
            // 
            // cmbCustcurr
            // 
            this.cmbCustcurr.FormattingEnabled = true;
            this.cmbCustcurr.Location = new System.Drawing.Point(919, 13);
            this.cmbCustcurr.Name = "cmbCustcurr";
            this.cmbCustcurr.Size = new System.Drawing.Size(140, 20);
            this.cmbCustcurr.TabIndex = 19;
            // 
            // txtCust_chs_add3
            // 
            this.txtCust_chs_add3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtCust_chs_add3.Location = new System.Drawing.Point(547, 141);
            this.txtCust_chs_add3.Name = "txtCust_chs_add3";
            this.txtCust_chs_add3.Size = new System.Drawing.Size(304, 22);
            this.txtCust_chs_add3.TabIndex = 17;
            this.txtCust_chs_add3.Text = "中文地址3";
            this.txtCust_chs_add3.Enter += new System.EventHandler(this.txtCust_chs_add3_Enter);
            // 
            // txtCust_chs_add2
            // 
            this.txtCust_chs_add2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtCust_chs_add2.Location = new System.Drawing.Point(547, 119);
            this.txtCust_chs_add2.Name = "txtCust_chs_add2";
            this.txtCust_chs_add2.Size = new System.Drawing.Size(304, 22);
            this.txtCust_chs_add2.TabIndex = 16;
            this.txtCust_chs_add2.Text = "中文地址2";
            this.txtCust_chs_add2.Enter += new System.EventHandler(this.txtCust_chs_add2_Enter);
            // 
            // txtCustpterm
            // 
            this.txtCustpterm.Location = new System.Drawing.Point(336, 181);
            this.txtCustpterm.Name = "txtCustpterm";
            this.txtCustpterm.Size = new System.Drawing.Size(140, 22);
            this.txtCustpterm.TabIndex = 11;
            // 
            // txtCustemail
            // 
            this.txtCustemail.Location = new System.Drawing.Point(336, 141);
            this.txtCustemail.Name = "txtCustemail";
            this.txtCustemail.Size = new System.Drawing.Size(140, 22);
            this.txtCustemail.TabIndex = 10;
            // 
            // lblCustarea
            // 
            this.lblCustarea.AutoSize = true;
            this.lblCustarea.Location = new System.Drawing.Point(508, 184);
            this.lblCustarea.Name = "lblCustarea";
            this.lblCustarea.Size = new System.Drawing.Size(29, 12);
            this.lblCustarea.TabIndex = 0;
            this.lblCustarea.Text = "區域";
            // 
            // txtCust_longchs_name
            // 
            this.txtCust_longchs_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtCust_longchs_name.Location = new System.Drawing.Point(7, 168);
            this.txtCust_longchs_name.Multiline = true;
            this.txtCust_longchs_name.Name = "txtCust_longchs_name";
            this.txtCust_longchs_name.Size = new System.Drawing.Size(277, 40);
            this.txtCust_longchs_name.TabIndex = 5;
            this.txtCust_longchs_name.Text = "客戶中文全稱";
            this.txtCust_longchs_name.Enter += new System.EventHandler(this.txtCust_longchs_name_Enter);
            // 
            // lblCustpterm
            // 
            this.lblCustpterm.AutoSize = true;
            this.lblCustpterm.Location = new System.Drawing.Point(297, 184);
            this.lblCustpterm.Name = "lblCustpterm";
            this.lblCustpterm.Size = new System.Drawing.Size(29, 12);
            this.lblCustpterm.TabIndex = 0;
            this.lblCustpterm.Text = "條款";
            // 
            // txtCustrmk
            // 
            this.txtCustrmk.Location = new System.Drawing.Point(900, 111);
            this.txtCustrmk.Multiline = true;
            this.txtCustrmk.Name = "txtCustrmk";
            this.txtCustrmk.Size = new System.Drawing.Size(159, 93);
            this.txtCustrmk.TabIndex = 22;
            // 
            // txtCust_chs_name
            // 
            this.txtCust_chs_name.Location = new System.Drawing.Point(84, 146);
            this.txtCust_chs_name.Name = "txtCust_chs_name";
            this.txtCust_chs_name.Size = new System.Drawing.Size(200, 22);
            this.txtCust_chs_name.TabIndex = 4;
            // 
            // txtCust_chs_add1
            // 
            this.txtCust_chs_add1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtCust_chs_add1.Location = new System.Drawing.Point(547, 97);
            this.txtCust_chs_add1.Name = "txtCust_chs_add1";
            this.txtCust_chs_add1.Size = new System.Drawing.Size(304, 22);
            this.txtCust_chs_add1.TabIndex = 15;
            this.txtCust_chs_add1.Text = "中文地址1";
            this.txtCust_chs_add1.Enter += new System.EventHandler(this.txtCust_chs_add1_Enter);
            // 
            // lblCustemail
            // 
            this.lblCustemail.AutoSize = true;
            this.lblCustemail.Location = new System.Drawing.Point(297, 146);
            this.lblCustemail.Name = "lblCustemail";
            this.lblCustemail.Size = new System.Drawing.Size(29, 12);
            this.lblCustemail.TabIndex = 0;
            this.lblCustemail.Text = "郵箱";
            // 
            // txtCust_en_add3
            // 
            this.txtCust_en_add3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtCust_en_add3.Location = new System.Drawing.Point(547, 53);
            this.txtCust_en_add3.Name = "txtCust_en_add3";
            this.txtCust_en_add3.Size = new System.Drawing.Size(304, 22);
            this.txtCust_en_add3.TabIndex = 14;
            this.txtCust_en_add3.Text = "英文地址3";
            this.txtCust_en_add3.Enter += new System.EventHandler(this.txtCust_en_add3_Enter);
            // 
            // lblCustrmk
            // 
            this.lblCustrmk.AutoSize = true;
            this.lblCustrmk.Location = new System.Drawing.Point(865, 117);
            this.lblCustrmk.Name = "lblCustrmk";
            this.lblCustrmk.Size = new System.Drawing.Size(29, 12);
            this.lblCustrmk.TabIndex = 0;
            this.lblCustrmk.Text = "備註";
            // 
            // txtCustfax
            // 
            this.txtCustfax.Location = new System.Drawing.Point(336, 107);
            this.txtCustfax.Name = "txtCustfax";
            this.txtCustfax.Size = new System.Drawing.Size(140, 22);
            this.txtCustfax.TabIndex = 9;
            // 
            // lblCustclose
            // 
            this.lblCustclose.AutoSize = true;
            this.lblCustclose.Location = new System.Drawing.Point(865, 84);
            this.lblCustclose.Name = "lblCustclose";
            this.lblCustclose.Size = new System.Drawing.Size(53, 12);
            this.lblCustclose.TabIndex = 0;
            this.lblCustclose.Text = "註銷時間";
            // 
            // lblCust_chs_add
            // 
            this.lblCust_chs_add.AutoSize = true;
            this.lblCust_chs_add.Location = new System.Drawing.Point(489, 100);
            this.lblCust_chs_add.Name = "lblCust_chs_add";
            this.lblCust_chs_add.Size = new System.Drawing.Size(59, 12);
            this.lblCust_chs_add.TabIndex = 0;
            this.lblCust_chs_add.Text = "地址(CHS)";
            // 
            // txtCusttel
            // 
            this.txtCusttel.Location = new System.Drawing.Point(336, 73);
            this.txtCusttel.Name = "txtCusttel";
            this.txtCusttel.Size = new System.Drawing.Size(140, 22);
            this.txtCusttel.TabIndex = 8;
            // 
            // lblCustcname
            // 
            this.lblCustcname.AutoSize = true;
            this.lblCustcname.Location = new System.Drawing.Point(5, 149);
            this.lblCustcname.Name = "lblCustcname";
            this.lblCustcname.Size = new System.Drawing.Size(83, 12);
            this.lblCustcname.TabIndex = 0;
            this.lblCustcname.Text = "客戶名稱(CHS)";
            // 
            // lblCustfax
            // 
            this.lblCustfax.AutoSize = true;
            this.lblCustfax.Location = new System.Drawing.Point(297, 112);
            this.lblCustfax.Name = "lblCustfax";
            this.lblCustfax.Size = new System.Drawing.Size(29, 12);
            this.lblCustfax.TabIndex = 0;
            this.lblCustfax.Text = "傳真";
            // 
            // lblCusttel
            // 
            this.lblCusttel.AutoSize = true;
            this.lblCusttel.Location = new System.Drawing.Point(297, 79);
            this.lblCusttel.Name = "lblCusttel";
            this.lblCusttel.Size = new System.Drawing.Size(29, 12);
            this.lblCusttel.TabIndex = 0;
            this.lblCusttel.Text = "電話";
            // 
            // txtCust_en_add2
            // 
            this.txtCust_en_add2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtCust_en_add2.Location = new System.Drawing.Point(547, 32);
            this.txtCust_en_add2.Name = "txtCust_en_add2";
            this.txtCust_en_add2.Size = new System.Drawing.Size(304, 22);
            this.txtCust_en_add2.TabIndex = 13;
            this.txtCust_en_add2.Text = "英文地址2";
            this.txtCust_en_add2.Enter += new System.EventHandler(this.txtCust_en_add2_Enter);
            // 
            // txtcust_longen_name
            // 
            this.txtcust_longen_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtcust_longen_name.Location = new System.Drawing.Point(7, 95);
            this.txtcust_longen_name.Multiline = true;
            this.txtcust_longen_name.Name = "txtcust_longen_name";
            this.txtcust_longen_name.Size = new System.Drawing.Size(277, 40);
            this.txtcust_longen_name.TabIndex = 3;
            this.txtcust_longen_name.Text = "客戶英文全稱";
            this.txtcust_longen_name.Enter += new System.EventHandler(this.txtcust_longen_name_Enter);
            // 
            // txtCust_en_name
            // 
            this.txtCust_en_name.Location = new System.Drawing.Point(84, 73);
            this.txtCust_en_name.Name = "txtCust_en_name";
            this.txtCust_en_name.Size = new System.Drawing.Size(200, 22);
            this.txtCust_en_name.TabIndex = 2;
            // 
            // lblCustopen
            // 
            this.lblCustopen.AutoSize = true;
            this.lblCustopen.Location = new System.Drawing.Point(865, 48);
            this.lblCustopen.Name = "lblCustopen";
            this.lblCustopen.Size = new System.Drawing.Size(53, 12);
            this.lblCustopen.TabIndex = 0;
            this.lblCustopen.Text = "開戶時間";
            // 
            // txtCustctact
            // 
            this.txtCustctact.Location = new System.Drawing.Point(336, 42);
            this.txtCustctact.Name = "txtCustctact";
            this.txtCustctact.Size = new System.Drawing.Size(140, 22);
            this.txtCustctact.TabIndex = 7;
            // 
            // lblCustname
            // 
            this.lblCustname.AutoSize = true;
            this.lblCustname.Location = new System.Drawing.Point(5, 76);
            this.lblCustname.Name = "lblCustname";
            this.lblCustname.Size = new System.Drawing.Size(76, 12);
            this.lblCustname.TabIndex = 0;
            this.lblCustname.Text = "客戶名稱(EN)";
            // 
            // lblCustctact
            // 
            this.lblCustctact.AutoSize = true;
            this.lblCustctact.Location = new System.Drawing.Point(297, 45);
            this.lblCustctact.Name = "lblCustctact";
            this.lblCustctact.Size = new System.Drawing.Size(41, 12);
            this.lblCustctact.TabIndex = 0;
            this.lblCustctact.Text = "聯繫人";
            // 
            // txtCust_en_add1
            // 
            this.txtCust_en_add1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtCust_en_add1.Location = new System.Drawing.Point(547, 10);
            this.txtCust_en_add1.Name = "txtCust_en_add1";
            this.txtCust_en_add1.Size = new System.Drawing.Size(304, 22);
            this.txtCust_en_add1.TabIndex = 12;
            this.txtCust_en_add1.Text = "英文地址1";
            this.txtCust_en_add1.Enter += new System.EventHandler(this.txtCust_en_add1_Enter);
            // 
            // txtCusttype
            // 
            this.txtCusttype.Location = new System.Drawing.Point(84, 42);
            this.txtCusttype.Name = "txtCusttype";
            this.txtCusttype.Size = new System.Drawing.Size(140, 22);
            this.txtCusttype.TabIndex = 1;
            // 
            // lblCustcurr
            // 
            this.lblCustcurr.AutoSize = true;
            this.lblCustcurr.Location = new System.Drawing.Point(865, 16);
            this.lblCustcurr.Name = "lblCustcurr";
            this.lblCustcurr.Size = new System.Drawing.Size(53, 12);
            this.lblCustcurr.TabIndex = 0;
            this.lblCustcurr.Text = "貨幣類型";
            // 
            // txtCustcounn
            // 
            this.txtCustcounn.Location = new System.Drawing.Point(336, 10);
            this.txtCustcounn.Name = "txtCustcounn";
            this.txtCustcounn.Size = new System.Drawing.Size(140, 22);
            this.txtCustcounn.TabIndex = 6;
            // 
            // lblCust_en_add
            // 
            this.lblCust_en_add.AutoSize = true;
            this.lblCust_en_add.Location = new System.Drawing.Point(489, 13);
            this.lblCust_en_add.Name = "lblCust_en_add";
            this.lblCust_en_add.Size = new System.Drawing.Size(52, 12);
            this.lblCust_en_add.TabIndex = 0;
            this.lblCust_en_add.Text = "地址(EN)";
            // 
            // lblCusttype
            // 
            this.lblCusttype.AutoSize = true;
            this.lblCusttype.Location = new System.Drawing.Point(5, 45);
            this.lblCusttype.Name = "lblCusttype";
            this.lblCusttype.Size = new System.Drawing.Size(53, 12);
            this.lblCusttype.TabIndex = 0;
            this.lblCusttype.Text = "客戶類型";
            // 
            // lblCustcoun
            // 
            this.lblCustcoun.AutoSize = true;
            this.lblCustcoun.Location = new System.Drawing.Point(297, 13);
            this.lblCustcoun.Name = "lblCustcoun";
            this.lblCustcoun.Size = new System.Drawing.Size(29, 12);
            this.lblCustcoun.TabIndex = 0;
            this.lblCustcoun.Text = "帳戶";
            // 
            // txtCustcode
            // 
            this.txtCustcode.Location = new System.Drawing.Point(84, 10);
            this.txtCustcode.MaxLength = 8;
            this.txtCustcode.Name = "txtCustcode";
            this.txtCustcode.Size = new System.Drawing.Size(140, 22);
            this.txtCustcode.TabIndex = 0;
            // 
            // lblCustcode
            // 
            this.lblCustcode.AutoSize = true;
            this.lblCustcode.Location = new System.Drawing.Point(5, 16);
            this.lblCustcode.Name = "lblCustcode";
            this.lblCustcode.Size = new System.Drawing.Size(41, 12);
            this.lblCustcode.TabIndex = 0;
            this.lblCustcode.Text = "客戶ID";
            // 
            // dgvDetails
            // 
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvDetails.Name = "dgvDetails";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(1062, 375);
            this.dgvDetails.TabIndex = 27;
            this.dgvDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellClick);
            // 
            // frmCustomerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 682);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmCustomerInfo";
            this.Text = "frmCustomerInfo";
            this.Load += new System.EventHandler(this.frmCustomerInfo_Load);
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
        private System.Windows.Forms.TextBox txtCust_chs_add2;
        private System.Windows.Forms.TextBox txtCustpterm;
        private System.Windows.Forms.TextBox txtCustemail;
        private System.Windows.Forms.TextBox txtCust_longchs_name;
        private System.Windows.Forms.Label lblCustpterm;
        private System.Windows.Forms.TextBox txtCust_chs_name;
        private System.Windows.Forms.Label lblCustemail;
        private System.Windows.Forms.TextBox txtCust_en_add3;
        private System.Windows.Forms.Label lblCustclose;
        private System.Windows.Forms.TextBox txtCusttel;
        private System.Windows.Forms.Label lblCustcname;
        private System.Windows.Forms.Label lblCusttel;
        private System.Windows.Forms.TextBox txtCust_en_add2;
        private System.Windows.Forms.TextBox txtCust_en_name;
        private System.Windows.Forms.Label lblCustopen;
        private System.Windows.Forms.TextBox txtCustctact;
        private System.Windows.Forms.Label lblCustname;
        private System.Windows.Forms.Label lblCustctact;
        private System.Windows.Forms.TextBox txtCust_en_add1;
        private System.Windows.Forms.TextBox txtCusttype;
        private System.Windows.Forms.Label lblCustcurr;
        private System.Windows.Forms.TextBox txtCustcounn;
        private System.Windows.Forms.Label lblCust_en_add;
        private System.Windows.Forms.Label lblCusttype;
        private System.Windows.Forms.Label lblCustcoun;
        private System.Windows.Forms.TextBox txtCustcode;
        private System.Windows.Forms.Label lblCustcode;
        private System.Windows.Forms.TextBox txtCustrmk;
        private System.Windows.Forms.TextBox txtCust_chs_add1;
        private System.Windows.Forms.Label lblCustrmk;
        private System.Windows.Forms.TextBox txtCustfax;
        private System.Windows.Forms.Label lblCust_chs_add;
        private System.Windows.Forms.Label lblCustfax;
        private System.Windows.Forms.TextBox txtcust_longen_name;
        private System.Windows.Forms.TextBox txtCust_chs_add3;
        private System.Windows.Forms.ComboBox cmbCustcurr;
        private System.Windows.Forms.MaskedTextBox mktxtCustclose;
        private System.Windows.Forms.MaskedTextBox mktxtCustopen;
        private System.Windows.Forms.GroupBox gboxQuery;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtCustcode_Q;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCust_en_name_Q;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCust_chs_name_Q;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCustarea;
        private System.Windows.Forms.ComboBox cmbArea;
    }
}