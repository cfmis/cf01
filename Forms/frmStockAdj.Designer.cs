namespace cf01.Forms
{
    partial class frmStockAdj
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockAdj));
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.sequence_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mo_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adj_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adj_sec_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lot_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ym = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upd_flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDept = new System.Windows.Forms.TextBox();
            this.mskMonth = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNFIND = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNCHECK = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNOK = new System.Windows.Forms.ToolStripButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dgv2 = new System.Windows.Forms.DataGridView();
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
            this.dataGridViewMaskedTextBoxColumn1 = new cf01.ModuleClass.DataGridViewMaskedTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location_id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sequence_id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mo_id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adj_qty1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adj_sec_qty1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lot_no1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ib_amount1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ib_weight1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ym1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_key1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upd_flag1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.BackgroundColor = System.Drawing.Color.White;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sequence_id,
            this.location_id,
            this.mo_id,
            this.goods_id,
            this.adj_qty,
            this.adj_sec_qty,
            this.lot_no,
            this.ym,
            this.p_key,
            this.upd_flag});
            this.dgv1.Location = new System.Drawing.Point(2, 96);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersWidth = 30;
            this.dgv1.RowTemplate.Height = 25;
            this.dgv1.Size = new System.Drawing.Size(949, 479);
            this.dgv1.TabIndex = 0;
            // 
            // sequence_id
            // 
            this.sequence_id.DataPropertyName = "sequence_id";
            this.sequence_id.HeaderText = "序號";
            this.sequence_id.Name = "sequence_id";
            this.sequence_id.ReadOnly = true;
            this.sequence_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sequence_id.Width = 65;
            // 
            // location_id
            // 
            this.location_id.DataPropertyName = "location_id";
            this.location_id.HeaderText = "倉庫";
            this.location_id.Name = "location_id";
            this.location_id.ReadOnly = true;
            this.location_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.location_id.Width = 60;
            // 
            // mo_id
            // 
            this.mo_id.DataPropertyName = "mo_id";
            this.mo_id.HeaderText = "頁數";
            this.mo_id.Name = "mo_id";
            this.mo_id.ReadOnly = true;
            this.mo_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.mo_id.Width = 110;
            // 
            // goods_id
            // 
            this.goods_id.DataPropertyName = "goods_id";
            this.goods_id.HeaderText = "貨品編碼";
            this.goods_id.Name = "goods_id";
            this.goods_id.ReadOnly = true;
            this.goods_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.goods_id.Width = 200;
            // 
            // adj_qty
            // 
            this.adj_qty.DataPropertyName = "adj_qty";
            this.adj_qty.HeaderText = "調整數量";
            this.adj_qty.Name = "adj_qty";
            this.adj_qty.ReadOnly = true;
            this.adj_qty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.adj_qty.Width = 120;
            // 
            // adj_sec_qty
            // 
            this.adj_sec_qty.DataPropertyName = "adj_sec_qty";
            this.adj_sec_qty.HeaderText = "調整重量";
            this.adj_sec_qty.Name = "adj_sec_qty";
            this.adj_sec_qty.ReadOnly = true;
            this.adj_sec_qty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.adj_sec_qty.Width = 110;
            // 
            // lot_no
            // 
            this.lot_no.DataPropertyName = "lot_no";
            this.lot_no.HeaderText = "批號";
            this.lot_no.Name = "lot_no";
            this.lot_no.ReadOnly = true;
            this.lot_no.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.lot_no.Width = 110;
            // 
            // ym
            // 
            this.ym.DataPropertyName = "ym";
            this.ym.HeaderText = "盤點日期";
            this.ym.Name = "ym";
            this.ym.ReadOnly = true;
            this.ym.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // p_key
            // 
            this.p_key.DataPropertyName = "p_key";
            this.p_key.HeaderText = "Pkey";
            this.p_key.Name = "p_key";
            this.p_key.ReadOnly = true;
            this.p_key.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.p_key.Visible = false;
            // 
            // upd_flag
            // 
            this.upd_flag.DataPropertyName = "upd_flag";
            this.upd_flag.HeaderText = "更新標識";
            this.upd_flag.Name = "upd_flag";
            this.upd_flag.ReadOnly = true;
            this.upd_flag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.upd_flag.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PMingLiU", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(81, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "倉庫";
            // 
            // txtDept
            // 
            this.txtDept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDept.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDept.Location = new System.Drawing.Point(124, 16);
            this.txtDept.MaxLength = 3;
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(90, 27);
            this.txtDept.TabIndex = 4;
            this.txtDept.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDept_KeyPress);
            // 
            // mskMonth
            // 
            this.mskMonth.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.mskMonth.Location = new System.Drawing.Point(302, 16);
            this.mskMonth.Mask = "0000/00";
            this.mskMonth.Name = "mskMonth";
            this.mskMonth.Size = new System.Drawing.Size(64, 27);
            this.mskMonth.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PMingLiU", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(232, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "盤點日期";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.groupBox1.Controls.Add(this.mskMonth);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDept);
            this.groupBox1.Location = new System.Drawing.Point(8, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(941, 52);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查找條件";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNEXIT,
            this.toolStripSeparator1,
            this.BTNFIND,
            this.toolStripSeparator11,
            this.BTNCHECK,
            this.toolStripSeparator7,
            this.BTNOK});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(954, 33);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BTNEXIT
            // 
            this.BTNEXIT.AutoSize = false;
            this.BTNEXIT.Image = ((System.Drawing.Image)(resources.GetObject("BTNEXIT.Image")));
            this.BTNEXIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEXIT.Name = "BTNEXIT";
            this.BTNEXIT.Size = new System.Drawing.Size(65, 30);
            this.BTNEXIT.Text = "退出(&X)";
            this.BTNEXIT.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // BTNFIND
            // 
            this.BTNFIND.Image = ((System.Drawing.Image)(resources.GetObject("BTNFIND.Image")));
            this.BTNFIND.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNFIND.Name = "BTNFIND";
            this.BTNFIND.Size = new System.Drawing.Size(66, 30);
            this.BTNFIND.Text = "查詢(1)";
            this.BTNFIND.Click += new System.EventHandler(this.BTNFIND_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 33);
            // 
            // BTNCHECK
            // 
            this.BTNCHECK.Image = ((System.Drawing.Image)(resources.GetObject("BTNCHECK.Image")));
            this.BTNCHECK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNCHECK.Name = "BTNCHECK";
            this.BTNCHECK.Size = new System.Drawing.Size(138, 30);
            this.BTNCHECK.Text = "生成調整差額數據(2)";
            this.BTNCHECK.Click += new System.EventHandler(this.BTNCHECK_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 33);
            // 
            // BTNOK
            // 
            this.BTNOK.Image = ((System.Drawing.Image)(resources.GetObject("BTNOK.Image")));
            this.BTNOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNOK.Name = "BTNOK";
            this.BTNOK.Size = new System.Drawing.Size(138, 30);
            this.BTNOK.Text = "生成自動調整數據(3)";
            this.BTNOK.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Enabled = false;
            this.progressBar1.Location = new System.Drawing.Point(472, 9);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(433, 17);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 11;
            this.progressBar1.Visible = false;
            // 
            // dgv2
            // 
            this.dgv2.AllowUserToAddRows = false;
            this.dgv2.AllowUserToDeleteRows = false;
            this.dgv2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv2.BackgroundColor = System.Drawing.Color.White;
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.location_id1,
            this.sequence_id1,
            this.mo_id1,
            this.goods_id1,
            this.adj_qty1,
            this.adj_sec_qty1,
            this.lot_no1,
            this.ib_amount1,
            this.ib_weight1,
            this.ym1,
            this.p_key1,
            this.upd_flag1});
            this.dgv2.Location = new System.Drawing.Point(2, 96);
            this.dgv2.Name = "dgv2";
            this.dgv2.ReadOnly = true;
            this.dgv2.RowHeadersWidth = 30;
            this.dgv2.RowTemplate.Height = 25;
            this.dgv2.Size = new System.Drawing.Size(949, 479);
            this.dgv2.TabIndex = 12;
            this.dgv2.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "sequence_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "序號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "location_id";
            this.dataGridViewTextBoxColumn2.HeaderText = "倉庫";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 50;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "mo_id";
            this.dataGridViewTextBoxColumn3.HeaderText = "頁數";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 130;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "goods_id";
            this.dataGridViewTextBoxColumn4.HeaderText = "貨品編碼";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "adj_qty";
            this.dataGridViewTextBoxColumn5.HeaderText = "調整數量";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 120;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "adj_sec_qty";
            this.dataGridViewTextBoxColumn6.HeaderText = "調整重量";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 120;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "lot_no";
            this.dataGridViewTextBoxColumn7.HeaderText = "批號";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Width = 110;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "ym";
            this.dataGridViewTextBoxColumn8.HeaderText = "盤點日期";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "ib_amount";
            this.dataGridViewTextBoxColumn9.HeaderText = "更新前數量";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn9.Width = 80;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "ib_weight";
            this.dataGridViewTextBoxColumn10.HeaderText = "更新前重量";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn10.Width = 80;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "sequence_id";
            this.dataGridViewTextBoxColumn11.HeaderText = "序號";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn11.Visible = false;
            this.dataGridViewTextBoxColumn11.Width = 65;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "location_id";
            this.dataGridViewTextBoxColumn12.HeaderText = "倉庫";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn12.Visible = false;
            this.dataGridViewTextBoxColumn12.Width = 60;
            // 
            // dataGridViewMaskedTextBoxColumn1
            // 
            this.dataGridViewMaskedTextBoxColumn1.DataPropertyName = "upd_flag";
            this.dataGridViewMaskedTextBoxColumn1.HeaderText = "UpdFlag";
            this.dataGridViewMaskedTextBoxColumn1.IncludeLiterals = false;
            this.dataGridViewMaskedTextBoxColumn1.IncludePrompt = false;
            this.dataGridViewMaskedTextBoxColumn1.Name = "dataGridViewMaskedTextBoxColumn1";
            this.dataGridViewMaskedTextBoxColumn1.PromptChar = '\0';
            this.dataGridViewMaskedTextBoxColumn1.ReadOnly = true;
            this.dataGridViewMaskedTextBoxColumn1.ValidatingType = null;
            this.dataGridViewMaskedTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "mo_id";
            this.dataGridViewTextBoxColumn13.HeaderText = "頁數";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn13.Width = 110;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "goods_id";
            this.dataGridViewTextBoxColumn14.HeaderText = "貨品編碼";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn14.Width = 200;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "adj_qty";
            this.dataGridViewTextBoxColumn15.HeaderText = "調整數量";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn15.Width = 120;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "adj_sec_qty";
            this.dataGridViewTextBoxColumn16.HeaderText = "調整重量";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn16.Width = 110;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "lot_no";
            this.dataGridViewTextBoxColumn17.HeaderText = "批號";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn17.Width = 110;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "ym";
            this.dataGridViewTextBoxColumn18.HeaderText = "盤點日期";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn18.Width = 110;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "p_key";
            this.dataGridViewTextBoxColumn19.HeaderText = "Pkey";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn19.Visible = false;
            this.dataGridViewTextBoxColumn19.Width = 110;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "upd_flag";
            this.dataGridViewTextBoxColumn20.HeaderText = "更新標識";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn20.Visible = false;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "p_key";
            this.dataGridViewTextBoxColumn21.HeaderText = "Pkey";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            this.dataGridViewTextBoxColumn21.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn21.Visible = false;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "upd_flag";
            this.dataGridViewTextBoxColumn22.HeaderText = "更新標識";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            this.dataGridViewTextBoxColumn22.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn22.Visible = false;
            // 
            // location_id1
            // 
            this.location_id1.DataPropertyName = "location_id";
            this.location_id1.HeaderText = "倉庫";
            this.location_id1.Name = "location_id1";
            this.location_id1.ReadOnly = true;
            this.location_id1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.location_id1.Width = 50;
            // 
            // sequence_id1
            // 
            this.sequence_id1.DataPropertyName = "sequence_id";
            this.sequence_id1.HeaderText = "序號";
            this.sequence_id1.Name = "sequence_id1";
            this.sequence_id1.ReadOnly = true;
            this.sequence_id1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sequence_id1.Width = 60;
            // 
            // mo_id1
            // 
            this.mo_id1.DataPropertyName = "mo_id";
            this.mo_id1.HeaderText = "頁數";
            this.mo_id1.Name = "mo_id1";
            this.mo_id1.ReadOnly = true;
            this.mo_id1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.mo_id1.Width = 110;
            // 
            // goods_id1
            // 
            this.goods_id1.DataPropertyName = "goods_id";
            this.goods_id1.HeaderText = "貨品編碼";
            this.goods_id1.Name = "goods_id1";
            this.goods_id1.ReadOnly = true;
            this.goods_id1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.goods_id1.Width = 200;
            // 
            // adj_qty1
            // 
            this.adj_qty1.DataPropertyName = "adj_qty";
            this.adj_qty1.HeaderText = "調整數量";
            this.adj_qty1.Name = "adj_qty1";
            this.adj_qty1.ReadOnly = true;
            this.adj_qty1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.adj_qty1.Width = 90;
            // 
            // adj_sec_qty1
            // 
            this.adj_sec_qty1.DataPropertyName = "adj_sec_qty";
            this.adj_sec_qty1.HeaderText = "調整重量";
            this.adj_sec_qty1.Name = "adj_sec_qty1";
            this.adj_sec_qty1.ReadOnly = true;
            this.adj_sec_qty1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.adj_sec_qty1.Width = 90;
            // 
            // lot_no1
            // 
            this.lot_no1.DataPropertyName = "lot_no";
            this.lot_no1.HeaderText = "批號";
            this.lot_no1.Name = "lot_no1";
            this.lot_no1.ReadOnly = true;
            this.lot_no1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.lot_no1.Width = 120;
            // 
            // ib_amount1
            // 
            this.ib_amount1.DataPropertyName = "ib_amount";
            this.ib_amount1.HeaderText = "更新前數量";
            this.ib_amount1.Name = "ib_amount1";
            this.ib_amount1.ReadOnly = true;
            this.ib_amount1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ib_amount1.Width = 80;
            // 
            // ib_weight1
            // 
            this.ib_weight1.DataPropertyName = "ib_weight";
            this.ib_weight1.HeaderText = "更新前重量";
            this.ib_weight1.Name = "ib_weight1";
            this.ib_weight1.ReadOnly = true;
            this.ib_weight1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ib_weight1.Width = 80;
            // 
            // ym1
            // 
            this.ym1.DataPropertyName = "ym";
            this.ym1.HeaderText = "YM";
            this.ym1.Name = "ym1";
            this.ym1.ReadOnly = true;
            this.ym1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ym1.Visible = false;
            // 
            // p_key1
            // 
            this.p_key1.DataPropertyName = "p_key";
            this.p_key1.HeaderText = "PKey";
            this.p_key1.Name = "p_key1";
            this.p_key1.ReadOnly = true;
            this.p_key1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.p_key1.Visible = false;
            // 
            // upd_flag1
            // 
            this.upd_flag1.DataPropertyName = "upd_flag";
            this.upd_flag1.HeaderText = "UpdFlag";
            this.upd_flag1.Name = "upd_flag1";
            this.upd_flag1.ReadOnly = true;
            this.upd_flag1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.upd_flag1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.upd_flag1.Visible = false;
            // 
            // frmStockAdj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 587);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.dgv2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmStockAdj";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量庫存調整";
            this.Load += new System.EventHandler(this.frmStockAdj_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.MaskedTextBox mskMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BTNFIND;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton BTNCHECK;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton BTNOK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sequence_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn location_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn mo_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn adj_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn adj_sec_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn lot_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn ym;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_key;
        private System.Windows.Forms.DataGridViewTextBoxColumn upd_flag;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private ModuleClass.DataGridViewMaskedTextBoxColumn dataGridViewMaskedTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn location_id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sequence_id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mo_id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn adj_qty1;
        private System.Windows.Forms.DataGridViewTextBoxColumn adj_sec_qty1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lot_no1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ib_amount1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ib_weight1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ym1;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_key1;
        private System.Windows.Forms.DataGridViewTextBoxColumn upd_flag1;
    }
}