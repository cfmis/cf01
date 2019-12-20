namespace cf01.ReportForm
{
    partial class frmPlan01
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlan01));
            this.txtTdep = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.rdbNoPrint = new System.Windows.Forms.RadioButton();
            this.rdbIsPrint = new System.Windows.Forms.RadioButton();
            this.rdbAllPrint = new System.Windows.Forms.RadioButton();
            this.chkReqPrdQty = new System.Windows.Forms.CheckBox();
            this.txtPrd_item1 = new System.Windows.Forms.TextBox();
            this.txtPrd_item2 = new System.Windows.Forms.TextBox();
            this.lblPrd_item = new System.Windows.Forms.Label();
            this.progressIndicatorAbout = new ProgressControls.ProgressIndicator();
            this.chkSimplePlan = new System.Windows.Forms.CheckBox();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.mkPlanDat2 = new System.Windows.Forms.MaskedTextBox();
            this.mkPlanDat1 = new System.Windows.Forms.MaskedTextBox();
            this.mkChkDat2 = new System.Windows.Forms.MaskedTextBox();
            this.mkChkDat1 = new System.Windows.Forms.MaskedTextBox();
            this.mkCmpDat2 = new System.Windows.Forms.MaskedTextBox();
            this.mkCmpDat1 = new System.Windows.Forms.MaskedTextBox();
            this.txtMo2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMo1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDep = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmdExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnExportToExce = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnArrange = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.ExpSimpePlan = new System.Windows.Forms.ToolStripButton();
            this.cmdShowData = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkArrange = new System.Windows.Forms.CheckBox();
            this.lblOldArrangeDate = new System.Windows.Forms.Label();
            this.mkOldArrangeDate = new System.Windows.Forms.MaskedTextBox();
            this.lblShowMsg = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTdep
            // 
            this.txtTdep.Location = new System.Drawing.Point(381, 63);
            this.txtTdep.Name = "txtTdep";
            this.txtTdep.Size = new System.Drawing.Size(105, 22);
            this.txtTdep.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(323, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "收貨部門:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.rdbNoPrint);
            this.flowLayoutPanel1.Controls.Add(this.rdbIsPrint);
            this.flowLayoutPanel1.Controls.Add(this.rdbAllPrint);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(74, 100);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(279, 25);
            this.flowLayoutPanel1.TabIndex = 21;
            // 
            // rdbNoPrint
            // 
            this.rdbNoPrint.AutoSize = true;
            this.rdbNoPrint.Location = new System.Drawing.Point(3, 3);
            this.rdbNoPrint.Name = "rdbNoPrint";
            this.rdbNoPrint.Size = new System.Drawing.Size(95, 16);
            this.rdbNoPrint.TabIndex = 0;
            this.rdbNoPrint.Text = "不顯示已列印";
            this.rdbNoPrint.UseVisualStyleBackColor = true;
            // 
            // rdbIsPrint
            // 
            this.rdbIsPrint.AutoSize = true;
            this.rdbIsPrint.Location = new System.Drawing.Point(104, 3);
            this.rdbIsPrint.Name = "rdbIsPrint";
            this.rdbIsPrint.Size = new System.Drawing.Size(95, 16);
            this.rdbIsPrint.TabIndex = 0;
            this.rdbIsPrint.Text = "只顯示已列印";
            this.rdbIsPrint.UseVisualStyleBackColor = true;
            // 
            // rdbAllPrint
            // 
            this.rdbAllPrint.AutoSize = true;
            this.rdbAllPrint.Checked = true;
            this.rdbAllPrint.Location = new System.Drawing.Point(205, 3);
            this.rdbAllPrint.Name = "rdbAllPrint";
            this.rdbAllPrint.Size = new System.Drawing.Size(47, 16);
            this.rdbAllPrint.TabIndex = 0;
            this.rdbAllPrint.TabStop = true;
            this.rdbAllPrint.Text = "不管";
            this.rdbAllPrint.UseVisualStyleBackColor = true;
            // 
            // chkReqPrdQty
            // 
            this.chkReqPrdQty.AutoSize = true;
            this.chkReqPrdQty.Location = new System.Drawing.Point(381, 104);
            this.chkReqPrdQty.Name = "chkReqPrdQty";
            this.chkReqPrdQty.Size = new System.Drawing.Size(156, 16);
            this.chkReqPrdQty.TabIndex = 19;
            this.chkReqPrdQty.Text = "包括：生產數為零的記錄";
            this.chkReqPrdQty.UseVisualStyleBackColor = true;
            // 
            // txtPrd_item1
            // 
            this.txtPrd_item1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrd_item1.Location = new System.Drawing.Point(681, 37);
            this.txtPrd_item1.MaxLength = 18;
            this.txtPrd_item1.Name = "txtPrd_item1";
            this.txtPrd_item1.Size = new System.Drawing.Size(216, 22);
            this.txtPrd_item1.TabIndex = 16;
            this.txtPrd_item1.Leave += new System.EventHandler(this.txtPrd_item1_Leave);
            // 
            // txtPrd_item2
            // 
            this.txtPrd_item2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrd_item2.Location = new System.Drawing.Point(681, 63);
            this.txtPrd_item2.MaxLength = 18;
            this.txtPrd_item2.Name = "txtPrd_item2";
            this.txtPrd_item2.Size = new System.Drawing.Size(216, 22);
            this.txtPrd_item2.TabIndex = 17;
            this.txtPrd_item2.Visible = false;
            // 
            // lblPrd_item
            // 
            this.lblPrd_item.AutoSize = true;
            this.lblPrd_item.Location = new System.Drawing.Point(621, 42);
            this.lblPrd_item.Name = "lblPrd_item";
            this.lblPrd_item.Size = new System.Drawing.Size(56, 12);
            this.lblPrd_item.TabIndex = 18;
            this.lblPrd_item.Text = "物料編號:";
            // 
            // progressIndicatorAbout
            // 
            this.progressIndicatorAbout.Location = new System.Drawing.Point(948, 29);
            this.progressIndicatorAbout.Name = "progressIndicatorAbout";
            this.progressIndicatorAbout.Percentage = 0F;
            this.progressIndicatorAbout.Size = new System.Drawing.Size(100, 100);
            this.progressIndicatorAbout.TabIndex = 2;
            this.progressIndicatorAbout.Text = "progressIndicator1";
            this.progressIndicatorAbout.Visible = false;
            // 
            // chkSimplePlan
            // 
            this.chkSimplePlan.AutoSize = true;
            this.chkSimplePlan.ForeColor = System.Drawing.Color.Red;
            this.chkSimplePlan.Location = new System.Drawing.Point(552, 103);
            this.chkSimplePlan.Name = "chkSimplePlan";
            this.chkSimplePlan.Size = new System.Drawing.Size(370, 16);
            this.chkSimplePlan.TabIndex = 15;
            this.chkSimplePlan.Text = "只顯示簡易計劃(完成數大於訂單數、Y單、交702部門，都不顯示)";
            this.chkSimplePlan.UseVisualStyleBackColor = true;
            this.chkSimplePlan.Click += new System.EventHandler(this.chkSimplePlan_Click);
            // 
            // cmbReportType
            // 
            this.cmbReportType.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(74, 65);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(216, 21);
            this.cmbReportType.TabIndex = 9;
            this.cmbReportType.SelectedIndexChanged += new System.EventHandler(this.cmbReportType_SelectedIndexChanged);
            // 
            // mkPlanDat2
            // 
            this.mkPlanDat2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mkPlanDat2.Location = new System.Drawing.Point(792, 10);
            this.mkPlanDat2.Mask = "0000/00/00";
            this.mkPlanDat2.Name = "mkPlanDat2";
            this.mkPlanDat2.PromptChar = ' ';
            this.mkPlanDat2.Size = new System.Drawing.Size(105, 22);
            this.mkPlanDat2.TabIndex = 4;
            this.mkPlanDat2.ValidatingType = typeof(System.DateTime);
            // 
            // mkPlanDat1
            // 
            this.mkPlanDat1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mkPlanDat1.Location = new System.Drawing.Point(681, 10);
            this.mkPlanDat1.Mask = "0000/00/00";
            this.mkPlanDat1.Name = "mkPlanDat1";
            this.mkPlanDat1.PromptChar = ' ';
            this.mkPlanDat1.Size = new System.Drawing.Size(105, 22);
            this.mkPlanDat1.TabIndex = 3;
            this.mkPlanDat1.ValidatingType = typeof(System.DateTime);
            this.mkPlanDat1.Leave += new System.EventHandler(this.mkPlanDat1_Leave);
            // 
            // mkChkDat2
            // 
            this.mkChkDat2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mkChkDat2.Location = new System.Drawing.Point(185, 37);
            this.mkChkDat2.Mask = "0000/00/00 00:00";
            this.mkChkDat2.Name = "mkChkDat2";
            this.mkChkDat2.PromptChar = ' ';
            this.mkChkDat2.Size = new System.Drawing.Size(105, 22);
            this.mkChkDat2.TabIndex = 6;
            // 
            // mkChkDat1
            // 
            this.mkChkDat1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mkChkDat1.Location = new System.Drawing.Point(74, 37);
            this.mkChkDat1.Mask = "0000/00/00 00:00";
            this.mkChkDat1.Name = "mkChkDat1";
            this.mkChkDat1.PromptChar = ' ';
            this.mkChkDat1.Size = new System.Drawing.Size(105, 22);
            this.mkChkDat1.TabIndex = 5;
            this.mkChkDat1.Leave += new System.EventHandler(this.mkChkDat1_Leave);
            // 
            // mkCmpDat2
            // 
            this.mkCmpDat2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mkCmpDat2.Location = new System.Drawing.Point(499, 10);
            this.mkCmpDat2.Mask = "0000/00/00";
            this.mkCmpDat2.Name = "mkCmpDat2";
            this.mkCmpDat2.PromptChar = ' ';
            this.mkCmpDat2.Size = new System.Drawing.Size(105, 22);
            this.mkCmpDat2.TabIndex = 2;
            this.mkCmpDat2.ValidatingType = typeof(System.DateTime);
            // 
            // mkCmpDat1
            // 
            this.mkCmpDat1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mkCmpDat1.Location = new System.Drawing.Point(381, 10);
            this.mkCmpDat1.Mask = "0000/00/00";
            this.mkCmpDat1.Name = "mkCmpDat1";
            this.mkCmpDat1.PromptChar = ' ';
            this.mkCmpDat1.Size = new System.Drawing.Size(105, 22);
            this.mkCmpDat1.TabIndex = 1;
            this.mkCmpDat1.ValidatingType = typeof(System.DateTime);
            // 
            // txtMo2
            // 
            this.txtMo2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo2.Location = new System.Drawing.Point(499, 37);
            this.txtMo2.MaxLength = 9;
            this.txtMo2.Name = "txtMo2";
            this.txtMo2.Size = new System.Drawing.Size(105, 22);
            this.txtMo2.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(323, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "制單編號:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "報表類型:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "批準日期:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(609, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "計劃單日期:";
            // 
            // txtMo1
            // 
            this.txtMo1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo1.Location = new System.Drawing.Point(381, 37);
            this.txtMo1.MaxLength = 9;
            this.txtMo1.Name = "txtMo1";
            this.txtMo1.Size = new System.Drawing.Size(105, 22);
            this.txtMo1.TabIndex = 7;
            this.txtMo1.Leave += new System.EventHandler(this.txtMo1_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "要求完成日期:";
            // 
            // txtDep
            // 
            this.txtDep.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDep.Location = new System.Drawing.Point(74, 10);
            this.txtDep.MaxLength = 3;
            this.txtDep.Name = "txtDep";
            this.txtDep.Size = new System.Drawing.Size(105, 22);
            this.txtDep.TabIndex = 0;
            this.txtDep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDep_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "部門:";
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 217);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowHeadersWidth = 18;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(1096, 455);
            this.dgvDetails.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdExit,
            this.toolStripSeparator1,
            this.cmdFind,
            this.toolStripSeparator2,
            this.tsBtnExportToExce,
            this.toolStripSeparator3,
            this.toolStripButton2,
            this.toolStripSeparator6,
            this.btnArrange,
            this.toolStripSeparator7,
            this.ExpSimpePlan,
            this.cmdShowData,
            this.toolStripSeparator5,
            this.toolStripButton1,
            this.toolStripSeparator4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1096, 38);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cmdExit
            // 
            this.cmdExit.AutoSize = false;
            this.cmdExit.Image = ((System.Drawing.Image)(resources.GetObject("cmdExit.Image")));
            this.cmdExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(75, 35);
            this.cmdExit.Text = "退出(&X)";
            this.cmdExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // cmdFind
            // 
            this.cmdFind.AutoSize = false;
            this.cmdFind.Image = ((System.Drawing.Image)(resources.GetObject("cmdFind.Image")));
            this.cmdFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.Size = new System.Drawing.Size(75, 35);
            this.cmdFind.Text = "查詢(&F)";
            this.cmdFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cmdFind.Click += new System.EventHandler(this.cmdFind_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // tsBtnExportToExce
            // 
            this.tsBtnExportToExce.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnExportToExce.Image")));
            this.tsBtnExportToExce.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnExportToExce.Name = "tsBtnExportToExce";
            this.tsBtnExportToExce.Size = new System.Drawing.Size(71, 35);
            this.tsBtnExportToExce.Text = "匯出到Excel";
            this.tsBtnExportToExce.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBtnExportToExce.Click += new System.EventHandler(this.tsBtnExportToExce_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(81, 35);
            this.toolStripButton2.Text = "匯出簡易計劃";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 38);
            // 
            // btnArrange
            // 
            this.btnArrange.AutoSize = false;
            this.btnArrange.Image = ((System.Drawing.Image)(resources.GetObject("btnArrange.Image")));
            this.btnArrange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnArrange.Name = "btnArrange";
            this.btnArrange.Size = new System.Drawing.Size(103, 35);
            this.btnArrange.Text = "匯出排期表";
            this.btnArrange.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnArrange.Click += new System.EventHandler(this.btnArrange_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 38);
            // 
            // ExpSimpePlan
            // 
            this.ExpSimpePlan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExpSimpePlan.Name = "ExpSimpePlan";
            this.ExpSimpePlan.Size = new System.Drawing.Size(185, 35);
            this.ExpSimpePlan.Text = "匯出簡易計劃(這個速度慢，不用)";
            this.ExpSimpePlan.Visible = false;
            this.ExpSimpePlan.Click += new System.EventHandler(this.ExpSimpePlan_Click);
            // 
            // cmdShowData
            // 
            this.cmdShowData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdShowData.Image = ((System.Drawing.Image)(resources.GetObject("cmdShowData.Image")));
            this.cmdShowData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdShowData.Name = "cmdShowData";
            this.cmdShowData.Size = new System.Drawing.Size(57, 35);
            this.cmdShowData.Text = "顯示報表";
            this.cmdShowData.Click += new System.EventHandler(this.cmdShowData_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(81, 35);
            this.toolStripButton1.Text = "更新制單狀態";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.txtTdep);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtDep);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.chkReqPrdQty);
            this.panel1.Controls.Add(this.txtMo1);
            this.panel1.Controls.Add(this.txtPrd_item1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtPrd_item2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblPrd_item);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.progressIndicatorAbout);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.chkSimplePlan);
            this.panel1.Controls.Add(this.txtMo2);
            this.panel1.Controls.Add(this.cmbReportType);
            this.panel1.Controls.Add(this.mkCmpDat1);
            this.panel1.Controls.Add(this.mkPlanDat2);
            this.panel1.Controls.Add(this.mkCmpDat2);
            this.panel1.Controls.Add(this.mkPlanDat1);
            this.panel1.Controls.Add(this.mkChkDat1);
            this.panel1.Controls.Add(this.mkChkDat2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1096, 179);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblShowMsg);
            this.groupBox1.Controls.Add(this.chkArrange);
            this.groupBox1.Controls.Add(this.lblOldArrangeDate);
            this.groupBox1.Controls.Add(this.mkOldArrangeDate);
            this.groupBox1.Location = new System.Drawing.Point(74, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(823, 39);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "匯出排期表，請選擇此選項";
            // 
            // chkArrange
            // 
            this.chkArrange.AutoSize = true;
            this.chkArrange.Location = new System.Drawing.Point(34, 17);
            this.chkArrange.Name = "chkArrange";
            this.chkArrange.Size = new System.Drawing.Size(84, 16);
            this.chkArrange.TabIndex = 24;
            this.chkArrange.Text = "建立排期表";
            this.chkArrange.UseVisualStyleBackColor = true;
            this.chkArrange.Click += new System.EventHandler(this.chkArrange_Click);
            // 
            // lblOldArrangeDate
            // 
            this.lblOldArrangeDate.AutoSize = true;
            this.lblOldArrangeDate.Location = new System.Drawing.Point(179, 18);
            this.lblOldArrangeDate.Name = "lblOldArrangeDate";
            this.lblOldArrangeDate.Size = new System.Drawing.Size(80, 12);
            this.lblOldArrangeDate.TabIndex = 25;
            this.lblOldArrangeDate.Text = "最後的排期表:";
            // 
            // mkOldArrangeDate
            // 
            this.mkOldArrangeDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mkOldArrangeDate.Location = new System.Drawing.Point(265, 11);
            this.mkOldArrangeDate.Mask = "0000/00/00";
            this.mkOldArrangeDate.Name = "mkOldArrangeDate";
            this.mkOldArrangeDate.PromptChar = ' ';
            this.mkOldArrangeDate.Size = new System.Drawing.Size(105, 22);
            this.mkOldArrangeDate.TabIndex = 3;
            this.mkOldArrangeDate.ValidatingType = typeof(System.DateTime);
            // 
            // lblShowMsg
            // 
            this.lblShowMsg.AutoSize = true;
            this.lblShowMsg.Location = new System.Drawing.Point(410, 18);
            this.lblShowMsg.Name = "lblShowMsg";
            this.lblShowMsg.Size = new System.Drawing.Size(218, 12);
            this.lblShowMsg.TabIndex = 26;
            this.lblShowMsg.Text = "步驟：1.建立排期表;2.查詢;3.匯出排期表";
            // 
            // frmPlan01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 672);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmPlan01";
            this.Text = "frmPlan01";
            this.Load += new System.EventHandler(this.frmPlan01_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton cmdExit;
        private System.Windows.Forms.ToolStripButton cmdFind;
        private System.Windows.Forms.TextBox txtDep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMo1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMo2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.MaskedTextBox mkCmpDat1;
        private System.Windows.Forms.MaskedTextBox mkCmpDat2;
        private System.Windows.Forms.MaskedTextBox mkChkDat1;
        private System.Windows.Forms.MaskedTextBox mkChkDat2;
        private System.Windows.Forms.MaskedTextBox mkPlanDat1;
        private System.Windows.Forms.MaskedTextBox mkPlanDat2;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label label7;
		private System.Windows.Forms.DataGridView dgvDetails;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton cmdShowData;
		private System.Windows.Forms.CheckBox chkSimplePlan;
		private System.Windows.Forms.ToolStripButton tsBtnExportToExce;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton ExpSimpePlan;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private ProgressControls.ProgressIndicator progressIndicatorAbout;
        private System.Windows.Forms.TextBox txtPrd_item1;
        private System.Windows.Forms.TextBox txtPrd_item2;
        private System.Windows.Forms.Label lblPrd_item;
        private System.Windows.Forms.CheckBox chkReqPrdQty;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton rdbNoPrint;
        private System.Windows.Forms.RadioButton rdbIsPrint;
        private System.Windows.Forms.RadioButton rdbAllPrint;
        private System.Windows.Forms.TextBox txtTdep;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.CheckBox chkArrange;
        private System.Windows.Forms.Label lblOldArrangeDate;
        private System.Windows.Forms.MaskedTextBox mkOldArrangeDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripButton btnArrange;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.Label lblShowMsg;
    }
}