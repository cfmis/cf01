namespace cf01.Forms
{
    partial class frmTransferLoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransferLoc));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMo_id = new System.Windows.Forms.Label();
            this.lblGoods_id = new System.Windows.Forms.Label();
            this.txtMo_id = new System.Windows.Forms.TextBox();
            this.txtGoods_id = new System.Windows.Forms.TextBox();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtFdep = new System.Windows.Forms.TextBox();
            this.lblFdep = new System.Windows.Forms.Label();
            this.txtTdep = new System.Windows.Forms.TextBox();
            this.lblTdep = new System.Windows.Forms.Label();
            this.txtId2 = new System.Windows.Forms.TextBox();
            this.txtId1 = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.lblDat = new System.Windows.Forms.Label();
            this.mktDat2 = new System.Windows.Forms.MaskedTextBox();
            this.mktDat1 = new System.Windows.Forms.MaskedTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnConf = new System.Windows.Forms.Button();
            this.btnGenDoc = new System.Windows.Forms.Button();
            this.cmbTloc = new System.Windows.Forms.ComboBox();
            this.lblTloc = new System.Windows.Forms.Label();
            this.lblTdat = new System.Windows.Forms.Label();
            this.mktTdat = new System.Windows.Forms.MaskedTextBox();
            this.lblTid = new System.Windows.Forms.Label();
            this.txtTid = new System.Windows.Forms.TextBox();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.colChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCon_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMo_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGoods_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGoods_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLot_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSt_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSt_weg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTdep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFdep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkAutoSave = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClose,
            this.toolStripSeparator1,
            this.btnFind,
            this.toolStripSeparator2,
            this.btnFind1,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(944, 50);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = false;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(65, 47);
            this.btnClose.Text = "退出(&X)";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 50);
            // 
            // btnFind
            // 
            this.btnFind.AutoSize = false;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(65, 47);
            this.btnFind.Text = "查詢(&F)";
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 50);
            // 
            // btnFind1
            // 
            this.btnFind1.AutoSize = false;
            this.btnFind1.Image = ((System.Drawing.Image)(resources.GetObject("btnFind1.Image")));
            this.btnFind1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind1.Name = "btnFind1";
            this.btnFind1.Size = new System.Drawing.Size(85, 47);
            this.btnFind1.Text = "已轉倉記錄";
            this.btnFind1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFind1.Click += new System.EventHandler(this.btnFind1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 50);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.chkAutoSave);
            this.panel1.Controls.Add(this.lblMo_id);
            this.panel1.Controls.Add(this.lblGoods_id);
            this.panel1.Controls.Add(this.txtMo_id);
            this.panel1.Controls.Add(this.txtGoods_id);
            this.panel1.Controls.Add(this.txtBarCode);
            this.panel1.Controls.Add(this.lblBarcode);
            this.panel1.Controls.Add(this.txtFdep);
            this.panel1.Controls.Add(this.lblFdep);
            this.panel1.Controls.Add(this.txtTdep);
            this.panel1.Controls.Add(this.lblTdep);
            this.panel1.Controls.Add(this.txtId2);
            this.panel1.Controls.Add(this.txtId1);
            this.panel1.Controls.Add(this.lblId);
            this.panel1.Controls.Add(this.lblDat);
            this.panel1.Controls.Add(this.mktDat2);
            this.panel1.Controls.Add(this.mktDat1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 89);
            this.panel1.TabIndex = 1;
            // 
            // lblMo_id
            // 
            this.lblMo_id.AutoSize = true;
            this.lblMo_id.Location = new System.Drawing.Point(637, 33);
            this.lblMo_id.Name = "lblMo_id";
            this.lblMo_id.Size = new System.Drawing.Size(56, 12);
            this.lblMo_id.TabIndex = 11;
            this.lblMo_id.Text = "制單編號:";
            // 
            // lblGoods_id
            // 
            this.lblGoods_id.AutoSize = true;
            this.lblGoods_id.Location = new System.Drawing.Point(637, 61);
            this.lblGoods_id.Name = "lblGoods_id";
            this.lblGoods_id.Size = new System.Drawing.Size(56, 12);
            this.lblGoods_id.TabIndex = 10;
            this.lblGoods_id.Text = "物料編號:";
            // 
            // txtMo_id
            // 
            this.txtMo_id.Location = new System.Drawing.Point(700, 30);
            this.txtMo_id.Name = "txtMo_id";
            this.txtMo_id.Size = new System.Drawing.Size(213, 22);
            this.txtMo_id.TabIndex = 9;
            // 
            // txtGoods_id
            // 
            this.txtGoods_id.Location = new System.Drawing.Point(700, 58);
            this.txtGoods_id.Name = "txtGoods_id";
            this.txtGoods_id.Size = new System.Drawing.Size(213, 22);
            this.txtGoods_id.TabIndex = 8;
            // 
            // txtBarCode
            // 
            this.txtBarCode.BackColor = System.Drawing.Color.Plum;
            this.txtBarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtBarCode.Location = new System.Drawing.Point(97, 3);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(246, 23);
            this.txtBarCode.TabIndex = 7;
            this.txtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarCode_KeyDown);
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblBarcode.ForeColor = System.Drawing.Color.DarkViolet;
            this.lblBarcode.Location = new System.Drawing.Point(9, 6);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(82, 17);
            this.lblBarcode.TabIndex = 6;
            this.lblBarcode.Text = "條碼掃描區:";
            // 
            // txtFdep
            // 
            this.txtFdep.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFdep.Location = new System.Drawing.Point(486, 58);
            this.txtFdep.Name = "txtFdep";
            this.txtFdep.Size = new System.Drawing.Size(120, 22);
            this.txtFdep.TabIndex = 5;
            // 
            // lblFdep
            // 
            this.lblFdep.AutoSize = true;
            this.lblFdep.Location = new System.Drawing.Point(424, 61);
            this.lblFdep.Name = "lblFdep";
            this.lblFdep.Size = new System.Drawing.Size(56, 12);
            this.lblFdep.TabIndex = 5;
            this.lblFdep.Text = "發貨部門:";
            // 
            // txtTdep
            // 
            this.txtTdep.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTdep.Location = new System.Drawing.Point(486, 30);
            this.txtTdep.Name = "txtTdep";
            this.txtTdep.Size = new System.Drawing.Size(120, 22);
            this.txtTdep.TabIndex = 4;
            // 
            // lblTdep
            // 
            this.lblTdep.AutoSize = true;
            this.lblTdep.Location = new System.Drawing.Point(424, 33);
            this.lblTdep.Name = "lblTdep";
            this.lblTdep.Size = new System.Drawing.Size(56, 12);
            this.lblTdep.TabIndex = 5;
            this.lblTdep.Text = "收貨部門:";
            // 
            // txtId2
            // 
            this.txtId2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtId2.Location = new System.Drawing.Point(223, 58);
            this.txtId2.Name = "txtId2";
            this.txtId2.Size = new System.Drawing.Size(120, 22);
            this.txtId2.TabIndex = 3;
            // 
            // txtId1
            // 
            this.txtId1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtId1.Location = new System.Drawing.Point(97, 58);
            this.txtId1.Name = "txtId1";
            this.txtId1.Size = new System.Drawing.Size(120, 22);
            this.txtId1.TabIndex = 2;
            this.txtId1.Leave += new System.EventHandler(this.txtId1_Leave);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(35, 61);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(56, 12);
            this.lblId.TabIndex = 2;
            this.lblId.Text = "移交單號:";
            // 
            // lblDat
            // 
            this.lblDat.AutoSize = true;
            this.lblDat.Location = new System.Drawing.Point(23, 33);
            this.lblDat.Name = "lblDat";
            this.lblDat.Size = new System.Drawing.Size(68, 12);
            this.lblDat.TabIndex = 1;
            this.lblDat.Text = "移交單日期:";
            // 
            // mktDat2
            // 
            this.mktDat2.Location = new System.Drawing.Point(223, 30);
            this.mktDat2.Mask = "9999/99/99";
            this.mktDat2.Name = "mktDat2";
            this.mktDat2.PromptChar = ' ';
            this.mktDat2.Size = new System.Drawing.Size(120, 22);
            this.mktDat2.TabIndex = 1;
            // 
            // mktDat1
            // 
            this.mktDat1.Location = new System.Drawing.Point(97, 30);
            this.mktDat1.Mask = "9999/99/99";
            this.mktDat1.Name = "mktDat1";
            this.mktDat1.PromptChar = ' ';
            this.mktDat1.Size = new System.Drawing.Size(120, 22);
            this.mktDat1.TabIndex = 0;
            this.mktDat1.Leave += new System.EventHandler(this.mktDat1_Leave);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnDel);
            this.panel2.Controls.Add(this.btnConf);
            this.panel2.Controls.Add(this.btnGenDoc);
            this.panel2.Controls.Add(this.cmbTloc);
            this.panel2.Controls.Add(this.lblTloc);
            this.panel2.Controls.Add(this.lblTdat);
            this.panel2.Controls.Add(this.mktTdat);
            this.panel2.Controls.Add(this.lblTid);
            this.panel2.Controls.Add(this.txtTid);
            this.panel2.Controls.Add(this.chkSelectAll);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 139);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(944, 82);
            this.panel2.TabIndex = 2;
            // 
            // btnDel
            // 
            this.btnDel.Enabled = false;
            this.btnDel.Location = new System.Drawing.Point(226, 42);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(91, 30);
            this.btnDel.TabIndex = 9;
            this.btnDel.Text = "刪除記錄";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnConf
            // 
            this.btnConf.Enabled = false;
            this.btnConf.Location = new System.Drawing.Point(106, 42);
            this.btnConf.Name = "btnConf";
            this.btnConf.Size = new System.Drawing.Size(91, 30);
            this.btnConf.TabIndex = 8;
            this.btnConf.Text = "確認";
            this.btnConf.UseVisualStyleBackColor = true;
            this.btnConf.Click += new System.EventHandler(this.btnConf_Click);
            // 
            // btnGenDoc
            // 
            this.btnGenDoc.Location = new System.Drawing.Point(651, 4);
            this.btnGenDoc.Name = "btnGenDoc";
            this.btnGenDoc.Size = new System.Drawing.Size(91, 30);
            this.btnGenDoc.TabIndex = 7;
            this.btnGenDoc.Text = "產生新單據";
            this.btnGenDoc.UseVisualStyleBackColor = true;
            this.btnGenDoc.Click += new System.EventHandler(this.btnGenDoc_Click);
            // 
            // cmbTloc
            // 
            this.cmbTloc.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbTloc.FormattingEnabled = true;
            this.cmbTloc.Location = new System.Drawing.Point(270, 7);
            this.cmbTloc.Name = "cmbTloc";
            this.cmbTloc.Size = new System.Drawing.Size(121, 21);
            this.cmbTloc.TabIndex = 6;
            // 
            // lblTloc
            // 
            this.lblTloc.AutoSize = true;
            this.lblTloc.Location = new System.Drawing.Point(224, 11);
            this.lblTloc.Name = "lblTloc";
            this.lblTloc.Size = new System.Drawing.Size(44, 12);
            this.lblTloc.TabIndex = 5;
            this.lblTloc.Text = "轉入倉:";
            // 
            // lblTdat
            // 
            this.lblTdat.AutoSize = true;
            this.lblTdat.Location = new System.Drawing.Point(35, 11);
            this.lblTdat.Name = "lblTdat";
            this.lblTdat.Size = new System.Drawing.Size(56, 12);
            this.lblTdat.TabIndex = 4;
            this.lblTdat.Text = "轉倉日期:";
            // 
            // mktTdat
            // 
            this.mktTdat.Location = new System.Drawing.Point(97, 6);
            this.mktTdat.Mask = "9999/99/99";
            this.mktTdat.Name = "mktTdat";
            this.mktTdat.PromptChar = ' ';
            this.mktTdat.Size = new System.Drawing.Size(120, 22);
            this.mktTdat.TabIndex = 3;
            // 
            // lblTid
            // 
            this.lblTid.AutoSize = true;
            this.lblTid.Location = new System.Drawing.Point(424, 11);
            this.lblTid.Name = "lblTid";
            this.lblTid.Size = new System.Drawing.Size(56, 12);
            this.lblTid.TabIndex = 2;
            this.lblTid.Text = "轉倉單號:";
            // 
            // txtTid
            // 
            this.txtTid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTid.Location = new System.Drawing.Point(486, 6);
            this.txtTid.Name = "txtTid";
            this.txtTid.Size = new System.Drawing.Size(120, 22);
            this.txtTid.TabIndex = 1;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(13, 50);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(72, 16);
            this.chkSelectAll.TabIndex = 0;
            this.chkSelectAll.Text = "選擇全部";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.Click += new System.EventHandler(this.chkSelectAll_Click);
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.ColumnHeadersHeight = 30;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChk,
            this.colId,
            this.colCon_date,
            this.colSeq,
            this.colMo_id,
            this.colGoods_id,
            this.colGoods_name,
            this.colLot_no,
            this.colQty,
            this.colWeg,
            this.colSt_qty,
            this.colSt_weg,
            this.colTdep,
            this.colFdep});
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 221);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowHeadersWidth = 20;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(944, 524);
            this.dgvDetails.TabIndex = 4;
            // 
            // colChk
            // 
            this.colChk.HeaderText = "選取";
            this.colChk.Name = "colChk";
            this.colChk.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colChk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colChk.Width = 60;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "移交單號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "con_date";
            this.dataGridViewTextBoxColumn2.HeaderText = "移交單日期";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "sequence_id";
            this.dataGridViewTextBoxColumn3.HeaderText = "序號";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "mo_id";
            this.dataGridViewTextBoxColumn4.HeaderText = "制單編號";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "goods_id";
            this.dataGridViewTextBoxColumn5.HeaderText = "物料編號";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "goods_name";
            this.dataGridViewTextBoxColumn6.HeaderText = "物料描述";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 240;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "lot_no";
            this.dataGridViewTextBoxColumn7.HeaderText = "批號";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "con_qty";
            this.dataGridViewTextBoxColumn8.HeaderText = "數量";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 80;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "sec_qty";
            this.dataGridViewTextBoxColumn9.HeaderText = "重量";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 80;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "in_dept";
            this.dataGridViewTextBoxColumn10.HeaderText = "收貨部門";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 80;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "out_dept";
            this.dataGridViewTextBoxColumn11.HeaderText = "發貨部門";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 80;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "in_dept";
            this.dataGridViewTextBoxColumn12.HeaderText = "收貨部門";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 80;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "out_dept";
            this.dataGridViewTextBoxColumn13.HeaderText = "發貨部門";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Width = 80;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "id";
            this.colId.HeaderText = "移交單號";
            this.colId.Name = "colId";
            // 
            // colCon_date
            // 
            this.colCon_date.DataPropertyName = "con_date";
            this.colCon_date.HeaderText = "移交單日期";
            this.colCon_date.Name = "colCon_date";
            this.colCon_date.Width = 80;
            // 
            // colSeq
            // 
            this.colSeq.DataPropertyName = "sequence_id";
            this.colSeq.HeaderText = "序號";
            this.colSeq.Name = "colSeq";
            this.colSeq.Width = 60;
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
            this.colGoods_id.HeaderText = "物料編號";
            this.colGoods_id.Name = "colGoods_id";
            this.colGoods_id.Width = 160;
            // 
            // colGoods_name
            // 
            this.colGoods_name.DataPropertyName = "goods_name";
            this.colGoods_name.HeaderText = "物料描述";
            this.colGoods_name.Name = "colGoods_name";
            this.colGoods_name.Width = 240;
            // 
            // colLot_no
            // 
            this.colLot_no.DataPropertyName = "lot_no";
            this.colLot_no.HeaderText = "批號";
            this.colLot_no.Name = "colLot_no";
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "con_qty";
            this.colQty.HeaderText = "轉倉數量";
            this.colQty.Name = "colQty";
            this.colQty.Width = 60;
            // 
            // colWeg
            // 
            this.colWeg.DataPropertyName = "sec_qty";
            this.colWeg.HeaderText = "轉倉重量";
            this.colWeg.Name = "colWeg";
            this.colWeg.Width = 60;
            // 
            // colSt_qty
            // 
            this.colSt_qty.DataPropertyName = "st_qty";
            this.colSt_qty.HeaderText = "庫存數量";
            this.colSt_qty.Name = "colSt_qty";
            this.colSt_qty.Width = 60;
            // 
            // colSt_weg
            // 
            this.colSt_weg.DataPropertyName = "st_weg";
            this.colSt_weg.HeaderText = "庫存重量";
            this.colSt_weg.Name = "colSt_weg";
            this.colSt_weg.Width = 60;
            // 
            // colTdep
            // 
            this.colTdep.DataPropertyName = "in_dept";
            this.colTdep.HeaderText = "收貨部門";
            this.colTdep.Name = "colTdep";
            this.colTdep.Width = 60;
            // 
            // colFdep
            // 
            this.colFdep.DataPropertyName = "out_dept";
            this.colFdep.HeaderText = "發貨部門";
            this.colFdep.Name = "colFdep";
            this.colFdep.Width = 60;
            // 
            // chkAutoSave
            // 
            this.chkAutoSave.AutoSize = true;
            this.chkAutoSave.Location = new System.Drawing.Point(425, 8);
            this.chkAutoSave.Name = "chkAutoSave";
            this.chkAutoSave.Size = new System.Drawing.Size(132, 16);
            this.chkAutoSave.TabIndex = 12;
            this.chkAutoSave.Text = "掃描後自動儲存記錄";
            this.chkAutoSave.UseVisualStyleBackColor = true;
            // 
            // frmTransferLoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 745);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmTransferLoc";
            this.Text = "frmTransferLoc";
            this.Load += new System.EventHandler(this.frmTransferLoc_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MaskedTextBox mktDat2;
        private System.Windows.Forms.MaskedTextBox mktDat1;
        private System.Windows.Forms.Label lblDat;
        private System.Windows.Forms.TextBox txtId2;
        private System.Windows.Forms.TextBox txtId1;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.TextBox txtFdep;
        private System.Windows.Forms.Label lblFdep;
        private System.Windows.Forms.TextBox txtTdep;
        private System.Windows.Forms.Label lblTdep;
        private System.Windows.Forms.Label lblTid;
        private System.Windows.Forms.TextBox txtTid;
        private System.Windows.Forms.Label lblTdat;
        private System.Windows.Forms.MaskedTextBox mktTdat;
        private System.Windows.Forms.ComboBox cmbTloc;
        private System.Windows.Forms.Label lblTloc;
        private System.Windows.Forms.Button btnGenDoc;
        private System.Windows.Forms.Button btnConf;
        private System.Windows.Forms.ToolStripButton btnFind1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCon_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeq;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMo_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGoods_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGoods_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLot_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSt_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSt_weg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTdep;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFdep;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtMo_id;
        private System.Windows.Forms.TextBox txtGoods_id;
        private System.Windows.Forms.Label lblMo_id;
        private System.Windows.Forms.Label lblGoods_id;
        private System.Windows.Forms.CheckBox chkAutoSave;
    }
}