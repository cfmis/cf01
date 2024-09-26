namespace cf01.Forms
{
	partial class frmOrderInPut
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
            this.dgvMoInfo = new System.Windows.Forms.DataGridView();
            this.lblMo_id = new System.Windows.Forms.Label();
            this.txtMo_id = new System.Windows.Forms.TextBox();
            this.masktxtDate = new System.Windows.Forms.MaskedTextBox();
            this.lblMo_date = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtRmark = new System.Windows.Forms.TextBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtGoods_des = new System.Windows.Forms.TextBox();
            this.lblGoods_id = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblGoods_name = new System.Windows.Forms.Label();
            this.cmboxGoods_id = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDo_color = new System.Windows.Forms.TextBox();
            this.txtColor_desc = new System.Windows.Forms.TextBox();
            this.txtwithin_code = new System.Windows.Forms.TextBox();
            this.txtver = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblVer = new System.Windows.Forms.Label();
            this.txtposition_id = new System.Windows.Forms.TextBox();
            this.lblPosition_id = new System.Windows.Forms.Label();
            this.txtmould_no = new System.Windows.Forms.TextBox();
            this.lblMould_no = new System.Windows.Forms.Label();
            this.txtOrderQty = new System.Windows.Forms.TextBox();
            this.txtcmpdat = new System.Windows.Forms.MaskedTextBox();
            this.txtchkdat = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblColor_desc = new System.Windows.Forms.Label();
            this.txtNextDepName = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtSequence_id = new System.Windows.Forms.TextBox();
            this.txtNextDep = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtKeyWord = new System.Windows.Forms.TextBox();
            this.cbxCondition = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Size = new System.Drawing.Size(1151, 615);
            this.panel1.Controls.SetChildIndex(this.splitContainer1, 0);
            // 
            // dgvMoInfo
            // 
            this.dgvMoInfo.ColumnHeadersHeight = 30;
            this.dgvMoInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMoInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMoInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvMoInfo.Name = "dgvMoInfo";
            this.dgvMoInfo.RowTemplate.Height = 24;
            this.dgvMoInfo.Size = new System.Drawing.Size(1147, 308);
            this.dgvMoInfo.TabIndex = 18;
            this.dgvMoInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMoInfo_CellClick);
            // 
            // lblMo_id
            // 
            this.lblMo_id.AutoSize = true;
            this.lblMo_id.Location = new System.Drawing.Point(13, 53);
            this.lblMo_id.Name = "lblMo_id";
            this.lblMo_id.Size = new System.Drawing.Size(47, 12);
            this.lblMo_id.TabIndex = 2;
            this.lblMo_id.Text = "頁  數：";
            // 
            // txtMo_id
            // 
            this.txtMo_id.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo_id.Location = new System.Drawing.Point(77, 45);
            this.txtMo_id.MaxLength = 9;
            this.txtMo_id.Name = "txtMo_id";
            this.txtMo_id.ReadOnly = true;
            this.txtMo_id.Size = new System.Drawing.Size(200, 22);
            this.txtMo_id.TabIndex = 1;
            this.txtMo_id.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMo_id_KeyDown);
            this.txtMo_id.Leave += new System.EventHandler(this.txtMo_id_Leave);
            // 
            // masktxtDate
            // 
            this.masktxtDate.Location = new System.Drawing.Point(349, 77);
            this.masktxtDate.Mask = "0000/00/00";
            this.masktxtDate.Name = "masktxtDate";
            this.masktxtDate.PromptChar = ' ';
            this.masktxtDate.ReadOnly = true;
            this.masktxtDate.Size = new System.Drawing.Size(73, 22);
            this.masktxtDate.TabIndex = 5;
            this.masktxtDate.ValidatingType = typeof(System.DateTime);
            // 
            // lblMo_date
            // 
            this.lblMo_date.AutoSize = true;
            this.lblMo_date.Location = new System.Drawing.Point(283, 80);
            this.lblMo_date.Name = "lblMo_date";
            this.lblMo_date.Size = new System.Drawing.Size(65, 12);
            this.lblMo_date.TabIndex = 2;
            this.lblMo_date.Text = "制單日期：";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(637, 77);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.ReadOnly = true;
            this.txtQuantity.Size = new System.Drawing.Size(81, 22);
            this.txtQuantity.TabIndex = 7;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(587, 80);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(44, 12);
            this.lblQuantity.TabIndex = 2;
            this.lblQuantity.Text = "數 量：";
            // 
            // txtRmark
            // 
            this.txtRmark.Location = new System.Drawing.Point(77, 107);
            this.txtRmark.Multiline = true;
            this.txtRmark.Name = "txtRmark";
            this.txtRmark.ReadOnly = true;
            this.txtRmark.Size = new System.Drawing.Size(640, 100);
            this.txtRmark.TabIndex = 9;
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(13, 162);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(56, 12);
            this.lblRemark.TabIndex = 2;
            this.lblRemark.Text = "備     註：";
            // 
            // txtGoods_des
            // 
            this.txtGoods_des.Location = new System.Drawing.Point(77, 77);
            this.txtGoods_des.Name = "txtGoods_des";
            this.txtGoods_des.ReadOnly = true;
            this.txtGoods_des.Size = new System.Drawing.Size(200, 22);
            this.txtGoods_des.TabIndex = 4;
            // 
            // lblGoods_id
            // 
            this.lblGoods_id.AutoSize = true;
            this.lblGoods_id.Location = new System.Drawing.Point(285, 53);
            this.lblGoods_id.Name = "lblGoods_id";
            this.lblGoods_id.Size = new System.Drawing.Size(65, 12);
            this.lblGoods_id.TabIndex = 2;
            this.lblGoods_id.Text = "物料編號：";
            // 
            // txtDepartment
            // 
            this.txtDepartment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDepartment.Location = new System.Drawing.Point(77, 14);
            this.txtDepartment.MaxLength = 3;
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(88, 22);
            this.txtDepartment.TabIndex = 0;
            this.txtDepartment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDepartment_KeyDown);
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(13, 21);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(50, 12);
            this.lblDepartment.TabIndex = 2;
            this.lblDepartment.Text = "部   門：";
            // 
            // lblGoods_name
            // 
            this.lblGoods_name.AutoSize = true;
            this.lblGoods_name.Location = new System.Drawing.Point(13, 80);
            this.lblGoods_name.Name = "lblGoods_name";
            this.lblGoods_name.Size = new System.Drawing.Size(65, 12);
            this.lblGoods_name.TabIndex = 2;
            this.lblGoods_name.Text = "物料描述：";
            // 
            // cmboxGoods_id
            // 
            this.cmboxGoods_id.DropDownHeight = 168;
            this.cmboxGoods_id.Enabled = false;
            this.cmboxGoods_id.IntegralHeight = false;
            this.cmboxGoods_id.Location = new System.Drawing.Point(349, 45);
            this.cmboxGoods_id.MaxLength = 18;
            this.cmboxGoods_id.Name = "cmboxGoods_id";
            this.cmboxGoods_id.Size = new System.Drawing.Size(368, 20);
            this.cmboxGoods_id.TabIndex = 2;
            this.cmboxGoods_id.SelectedValueChanged += new System.EventHandler(this.cmboxGoods_id_SelectedValueChanged);
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
            this.splitContainer1.Panel1.Controls.Add(this.txtSequence_id);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.txtDo_color);
            this.splitContainer1.Panel1.Controls.Add(this.txtColor_desc);
            this.splitContainer1.Panel1.Controls.Add(this.txtwithin_code);
            this.splitContainer1.Panel1.Controls.Add(this.txtver);
            this.splitContainer1.Panel1.Controls.Add(this.lblID);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.lblVer);
            this.splitContainer1.Panel1.Controls.Add(this.txtposition_id);
            this.splitContainer1.Panel1.Controls.Add(this.lblPosition_id);
            this.splitContainer1.Panel1.Controls.Add(this.txtmould_no);
            this.splitContainer1.Panel1.Controls.Add(this.lblMould_no);
            this.splitContainer1.Panel1.Controls.Add(this.txtRmark);
            this.splitContainer1.Panel1.Controls.Add(this.txtOrderQty);
            this.splitContainer1.Panel1.Controls.Add(this.txtQuantity);
            this.splitContainer1.Panel1.Controls.Add(this.cmboxGoods_id);
            this.splitContainer1.Panel1.Controls.Add(this.lblQuantity);
            this.splitContainer1.Panel1.Controls.Add(this.lblMo_date);
            this.splitContainer1.Panel1.Controls.Add(this.txtcmpdat);
            this.splitContainer1.Panel1.Controls.Add(this.txtchkdat);
            this.splitContainer1.Panel1.Controls.Add(this.masktxtDate);
            this.splitContainer1.Panel1.Controls.Add(this.txtDepartment);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.lblColor_desc);
            this.splitContainer1.Panel1.Controls.Add(this.lblRemark);
            this.splitContainer1.Panel1.Controls.Add(this.txtNextDepName);
            this.splitContainer1.Panel1.Controls.Add(this.txtId);
            this.splitContainer1.Panel1.Controls.Add(this.txtNextDep);
            this.splitContainer1.Panel1.Controls.Add(this.txtGoods_des);
            this.splitContainer1.Panel1.Controls.Add(this.txtMo_id);
            this.splitContainer1.Panel1.Controls.Add(this.lblDepartment);
            this.splitContainer1.Panel1.Controls.Add(this.lblMo_id);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.lblGoods_id);
            this.splitContainer1.Panel1.Controls.Add(this.lblGoods_name);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1151, 590);
            this.splitContainer1.SplitterDistance = 236;
            this.splitContainer1.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1113, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "PCS";
            // 
            // txtDo_color
            // 
            this.txtDo_color.BackColor = System.Drawing.SystemColors.Control;
            this.txtDo_color.Location = new System.Drawing.Point(349, 213);
            this.txtDo_color.Name = "txtDo_color";
            this.txtDo_color.Size = new System.Drawing.Size(169, 22);
            this.txtDo_color.TabIndex = 16;
            // 
            // txtColor_desc
            // 
            this.txtColor_desc.BackColor = System.Drawing.SystemColors.Control;
            this.txtColor_desc.Location = new System.Drawing.Point(77, 213);
            this.txtColor_desc.Name = "txtColor_desc";
            this.txtColor_desc.Size = new System.Drawing.Size(169, 22);
            this.txtColor_desc.TabIndex = 15;
            // 
            // txtwithin_code
            // 
            this.txtwithin_code.Location = new System.Drawing.Point(970, 142);
            this.txtwithin_code.Name = "txtwithin_code";
            this.txtwithin_code.ReadOnly = true;
            this.txtwithin_code.Size = new System.Drawing.Size(46, 22);
            this.txtwithin_code.TabIndex = 3;
            this.txtwithin_code.Visible = false;
            // 
            // txtver
            // 
            this.txtver.Location = new System.Drawing.Point(785, 77);
            this.txtver.Name = "txtver";
            this.txtver.ReadOnly = true;
            this.txtver.Size = new System.Drawing.Size(46, 22);
            this.txtver.TabIndex = 3;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(730, 53);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(53, 12);
            this.lblID.TabIndex = 9;
            this.lblID.Text = "編    號：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(992, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "序號：";
            // 
            // lblVer
            // 
            this.lblVer.AutoSize = true;
            this.lblVer.Location = new System.Drawing.Point(731, 80);
            this.lblVer.Name = "lblVer";
            this.lblVer.Size = new System.Drawing.Size(53, 12);
            this.lblVer.TabIndex = 9;
            this.lblVer.Text = "版本號：";
            // 
            // txtposition_id
            // 
            this.txtposition_id.BackColor = System.Drawing.SystemColors.Control;
            this.txtposition_id.Location = new System.Drawing.Point(785, 182);
            this.txtposition_id.Name = "txtposition_id";
            this.txtposition_id.Size = new System.Drawing.Size(148, 22);
            this.txtposition_id.TabIndex = 14;
            // 
            // lblPosition_id
            // 
            this.lblPosition_id.AutoSize = true;
            this.lblPosition_id.Location = new System.Drawing.Point(723, 185);
            this.lblPosition_id.Name = "lblPosition_id";
            this.lblPosition_id.Size = new System.Drawing.Size(65, 12);
            this.lblPosition_id.TabIndex = 7;
            this.lblPosition_id.Text = "模具位置：";
            // 
            // txtmould_no
            // 
            this.txtmould_no.BackColor = System.Drawing.SystemColors.Control;
            this.txtmould_no.Location = new System.Drawing.Point(785, 142);
            this.txtmould_no.Name = "txtmould_no";
            this.txtmould_no.Size = new System.Drawing.Size(148, 22);
            this.txtmould_no.TabIndex = 13;
            // 
            // lblMould_no
            // 
            this.lblMould_no.AutoSize = true;
            this.lblMould_no.Location = new System.Drawing.Point(723, 152);
            this.lblMould_no.Name = "lblMould_no";
            this.lblMould_no.Size = new System.Drawing.Size(65, 12);
            this.lblMould_no.TabIndex = 7;
            this.lblMould_no.Text = "模具編號：";
            // 
            // txtOrderQty
            // 
            this.txtOrderQty.Location = new System.Drawing.Point(1032, 108);
            this.txtOrderQty.Name = "txtOrderQty";
            this.txtOrderQty.ReadOnly = true;
            this.txtOrderQty.Size = new System.Drawing.Size(75, 22);
            this.txtOrderQty.TabIndex = 12;
            // 
            // txtcmpdat
            // 
            this.txtcmpdat.Location = new System.Drawing.Point(508, 77);
            this.txtcmpdat.Mask = "0000/00/00";
            this.txtcmpdat.Name = "txtcmpdat";
            this.txtcmpdat.PromptChar = ' ';
            this.txtcmpdat.ReadOnly = true;
            this.txtcmpdat.Size = new System.Drawing.Size(73, 22);
            this.txtcmpdat.TabIndex = 6;
            this.txtcmpdat.ValidatingType = typeof(System.DateTime);
            // 
            // txtchkdat
            // 
            this.txtchkdat.Location = new System.Drawing.Point(958, 77);
            this.txtchkdat.Mask = "0000/00/00";
            this.txtchkdat.Name = "txtchkdat";
            this.txtchkdat.PromptChar = ' ';
            this.txtchkdat.ReadOnly = true;
            this.txtchkdat.Size = new System.Drawing.Size(149, 22);
            this.txtchkdat.TabIndex = 8;
            this.txtchkdat.ValidatingType = typeof(System.DateTime);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(252, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "下工序顏色做法:";
            // 
            // lblColor_desc
            // 
            this.lblColor_desc.AutoSize = true;
            this.lblColor_desc.Location = new System.Drawing.Point(13, 220);
            this.lblColor_desc.Name = "lblColor_desc";
            this.lblColor_desc.Size = new System.Drawing.Size(68, 12);
            this.lblColor_desc.TabIndex = 2;
            this.lblColor_desc.Text = "下工序顏色:";
            // 
            // txtNextDepName
            // 
            this.txtNextDepName.Location = new System.Drawing.Point(830, 108);
            this.txtNextDepName.Name = "txtNextDepName";
            this.txtNextDepName.ReadOnly = true;
            this.txtNextDepName.Size = new System.Drawing.Size(126, 22);
            this.txtNextDepName.TabIndex = 11;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(785, 45);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(126, 22);
            this.txtId.TabIndex = 11;
            // 
            // txtSequence_id
            // 
            this.txtSequence_id.Location = new System.Drawing.Point(1032, 45);
            this.txtSequence_id.Name = "txtSequence_id";
            this.txtSequence_id.ReadOnly = true;
            this.txtSequence_id.Size = new System.Drawing.Size(75, 22);
            this.txtSequence_id.TabIndex = 11;
            // 
            // txtNextDep
            // 
            this.txtNextDep.Location = new System.Drawing.Point(785, 108);
            this.txtNextDep.Name = "txtNextDep";
            this.txtNextDep.ReadOnly = true;
            this.txtNextDep.Size = new System.Drawing.Size(45, 22);
            this.txtNextDep.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(428, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "要求交貨期：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(968, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "訂單數量：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(731, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "下部門：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(887, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "審批日期：";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnFind);
            this.splitContainer2.Panel1.Controls.Add(this.txtKeyWord);
            this.splitContainer2.Panel1.Controls.Add(this.cbxCondition);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvMoInfo);
            this.splitContainer2.Size = new System.Drawing.Size(1147, 346);
            this.splitContainer2.SplitterDistance = 34;
            this.splitContainer2.TabIndex = 8;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(573, 5);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 17;
            this.btnFind.Text = "(查找&F)";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.Location = new System.Drawing.Point(293, 5);
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.Size = new System.Drawing.Size(274, 22);
            this.txtKeyWord.TabIndex = 16;
            // 
            // cbxCondition
            // 
            this.cbxCondition.FormattingEnabled = true;
            this.cbxCondition.Location = new System.Drawing.Point(102, 5);
            this.cbxCondition.Name = "cbxCondition";
            this.cbxCondition.Size = new System.Drawing.Size(185, 20);
            this.cbxCondition.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "查詢條件：";
            // 
            // frmOrderInPut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 615);
            this.Name = "frmOrderInPut";
            this.Text = "frmOrderInPut";
            this.Load += new System.EventHandler(this.frmOrderInPut_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoInfo)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblMo_id;
		private System.Windows.Forms.Label lblRemark;
		private System.Windows.Forms.MaskedTextBox masktxtDate;
		private System.Windows.Forms.Label lblQuantity;
		private System.Windows.Forms.TextBox txtMo_id;
		private System.Windows.Forms.TextBox txtQuantity;
		private System.Windows.Forms.TextBox txtRmark;
		private System.Windows.Forms.Label lblMo_date;
		private System.Windows.Forms.DataGridView dgvMoInfo;
		private System.Windows.Forms.Label lblGoods_id;
		private System.Windows.Forms.Label lblDepartment;
		private System.Windows.Forms.TextBox txtGoods_des;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Label lblGoods_name;
        private System.Windows.Forms.ComboBox cmboxGoods_id;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ComboBox cbxCondition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKeyWord;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.MaskedTextBox txtchkdat;
        private System.Windows.Forms.TextBox txtSequence_id;
        private System.Windows.Forms.TextBox txtNextDep;
        private System.Windows.Forms.TextBox txtOrderQty;
        private System.Windows.Forms.MaskedTextBox txtcmpdat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtposition_id;
        private System.Windows.Forms.Label lblPosition_id;
        private System.Windows.Forms.TextBox txtmould_no;
        private System.Windows.Forms.Label lblMould_no;
        private System.Windows.Forms.TextBox txtver;
        private System.Windows.Forms.Label lblVer;
        private System.Windows.Forms.TextBox txtDo_color;
        private System.Windows.Forms.TextBox txtColor_desc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblColor_desc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNextDepName;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtwithin_code;
	}
}