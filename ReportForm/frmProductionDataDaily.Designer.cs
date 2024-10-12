namespace cf01.ReportForm
{
    partial class frmProductionDataDaily
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductionDataDaily));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDep = new System.Windows.Forms.Label();
            this.txtDep = new System.Windows.Forms.TextBox();
            this.mskDat2 = new System.Windows.Forms.MaskedTextBox();
            this.mskDat1 = new System.Windows.Forms.MaskedTextBox();
            this.lblDat = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
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
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty_302 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty_j01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty_tot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMold_302 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMold_j01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMold_tot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHour_302 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHour_j01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHour_tot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPer_qty_302 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPer_qty_j01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPer_qty_tot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHour_std_302 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHour_std_j01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHour_std_tot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReach_std = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTran_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTran_weg = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.btnExit,
            this.toolStripSeparator1,
            this.btnFind,
            this.toolStripSeparator2,
            this.btnExp,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1254, 37);
            this.toolStrip1.TabIndex = 0;
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
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 37);
            // 
            // btnFind
            // 
            this.btnFind.AutoSize = false;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(65, 35);
            this.btnFind.Text = "查找(&F)";
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 37);
            // 
            // btnExp
            // 
            this.btnExp.AutoSize = false;
            this.btnExp.Image = ((System.Drawing.Image)(resources.GetObject("btnExp.Image")));
            this.btnExp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExp.Name = "btnExp";
            this.btnExp.Size = new System.Drawing.Size(85, 35);
            this.btnExp.Text = "匯出到Excel";
            this.btnExp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExp.Click += new System.EventHandler(this.btnExp_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 37);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dgvDetails);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1254, 684);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblDep);
            this.panel2.Controls.Add(this.txtDep);
            this.panel2.Controls.Add(this.mskDat2);
            this.panel2.Controls.Add(this.mskDat1);
            this.panel2.Controls.Add(this.lblDat);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1250, 50);
            this.panel2.TabIndex = 0;
            // 
            // lblDep
            // 
            this.lblDep.AutoSize = true;
            this.lblDep.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblDep.Location = new System.Drawing.Point(16, 13);
            this.lblDep.Name = "lblDep";
            this.lblDep.Size = new System.Drawing.Size(39, 14);
            this.lblDep.TabIndex = 13;
            this.lblDep.Text = "部門:";
            // 
            // txtDep
            // 
            this.txtDep.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDep.Location = new System.Drawing.Point(62, 8);
            this.txtDep.Name = "txtDep";
            this.txtDep.Size = new System.Drawing.Size(100, 23);
            this.txtDep.TabIndex = 12;
            // 
            // mskDat2
            // 
            this.mskDat2.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.mskDat2.Location = new System.Drawing.Point(446, 8);
            this.mskDat2.Mask = "9999/99/99";
            this.mskDat2.Name = "mskDat2";
            this.mskDat2.PromptChar = ' ';
            this.mskDat2.Size = new System.Drawing.Size(100, 23);
            this.mskDat2.TabIndex = 11;
            // 
            // mskDat1
            // 
            this.mskDat1.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.mskDat1.Location = new System.Drawing.Point(329, 8);
            this.mskDat1.Mask = "9999/99/99";
            this.mskDat1.Name = "mskDat1";
            this.mskDat1.PromptChar = ' ';
            this.mskDat1.Size = new System.Drawing.Size(100, 23);
            this.mskDat1.TabIndex = 10;
            // 
            // lblDat
            // 
            this.lblDat.AutoSize = true;
            this.lblDat.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblDat.Location = new System.Drawing.Point(261, 13);
            this.lblDat.Name = "lblDat";
            this.lblDat.Size = new System.Drawing.Size(67, 14);
            this.lblDat.TabIndex = 9;
            this.lblDat.Text = "統計日期:";
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.ColumnHeadersHeight = 30;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDat,
            this.colWeek,
            this.colQty_302,
            this.colQty_j01,
            this.colQty_tot,
            this.colMold_302,
            this.colMold_j01,
            this.colMold_tot,
            this.colHour_302,
            this.colHour_j01,
            this.colHour_tot,
            this.colPer_qty_302,
            this.colPer_qty_j01,
            this.colPer_qty_tot,
            this.colHour_std_302,
            this.colHour_std_j01,
            this.colHour_std_tot,
            this.colReach_std,
            this.colTran_qty,
            this.colTran_weg});
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 50);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowHeadersWidth = 20;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(1250, 630);
            this.dgvDetails.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "dat";
            this.dataGridViewTextBoxColumn1.HeaderText = "統計日期";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "weekofday";
            this.dataGridViewTextBoxColumn2.HeaderText = "星期";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 40;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "qty_302";
            this.dataGridViewTextBoxColumn3.HeaderText = "DG生產數";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "qty_j01";
            this.dataGridViewTextBoxColumn4.HeaderText = "JX生產數";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "qty_tot";
            this.dataGridViewTextBoxColumn5.HeaderText = "DG+JX生產數";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "mold_302";
            this.dataGridViewTextBoxColumn6.HeaderText = "DG碑數";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "mold_j01";
            this.dataGridViewTextBoxColumn7.HeaderText = "JX碑數";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "mold_tot";
            this.dataGridViewTextBoxColumn8.HeaderText = "DG+JX碑數";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "hour_302";
            this.dataGridViewTextBoxColumn9.HeaderText = "DG工時";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 80;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "hour_j01";
            this.dataGridViewTextBoxColumn10.HeaderText = "JX工時";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 80;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "hour_tot";
            this.dataGridViewTextBoxColumn11.HeaderText = "DG+JX工時";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "per_qty_302";
            this.dataGridViewTextBoxColumn12.HeaderText = "DG每碑粒數";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "per_qty_j01";
            this.dataGridViewTextBoxColumn13.HeaderText = "JX每碑粒數";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "per_qty_tot";
            this.dataGridViewTextBoxColumn14.HeaderText = "DG+JX每碑粒數";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 120;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "hour_std_302";
            this.dataGridViewTextBoxColumn15.HeaderText = "DG平均時產能";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "hour_std_j01";
            this.dataGridViewTextBoxColumn16.HeaderText = "JX平均時產能";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "hour_std_tot";
            this.dataGridViewTextBoxColumn17.HeaderText = "DG+JX平均時產能";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Width = 120;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "reach_std";
            this.dataGridViewTextBoxColumn18.HeaderText = "DG+JX達標率";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "tran_qty";
            this.dataGridViewTextBoxColumn19.HeaderText = "DG+JX移交數量";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.Width = 120;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "tran_weg";
            this.dataGridViewTextBoxColumn20.HeaderText = "DG+JX移交重量";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.Width = 120;
            // 
            // colDat
            // 
            this.colDat.DataPropertyName = "dat";
            this.colDat.HeaderText = "統計日期";
            this.colDat.Name = "colDat";
            this.colDat.ReadOnly = true;
            // 
            // colWeek
            // 
            this.colWeek.DataPropertyName = "weekofday";
            this.colWeek.HeaderText = "星期";
            this.colWeek.Name = "colWeek";
            this.colWeek.ReadOnly = true;
            this.colWeek.Width = 40;
            // 
            // colQty_302
            // 
            this.colQty_302.DataPropertyName = "qty_302";
            this.colQty_302.HeaderText = "DG生產數";
            this.colQty_302.Name = "colQty_302";
            this.colQty_302.ReadOnly = true;
            // 
            // colQty_j01
            // 
            this.colQty_j01.DataPropertyName = "qty_j01";
            this.colQty_j01.HeaderText = "JX生產數";
            this.colQty_j01.Name = "colQty_j01";
            this.colQty_j01.ReadOnly = true;
            this.colQty_j01.Width = 80;
            // 
            // colQty_tot
            // 
            this.colQty_tot.DataPropertyName = "qty_tot";
            this.colQty_tot.HeaderText = "DG+JX生產數";
            this.colQty_tot.Name = "colQty_tot";
            this.colQty_tot.ReadOnly = true;
            // 
            // colMold_302
            // 
            this.colMold_302.DataPropertyName = "mold_302";
            this.colMold_302.HeaderText = "DG碑數";
            this.colMold_302.Name = "colMold_302";
            this.colMold_302.ReadOnly = true;
            this.colMold_302.Width = 80;
            // 
            // colMold_j01
            // 
            this.colMold_j01.DataPropertyName = "mold_j01";
            this.colMold_j01.HeaderText = "JX碑數";
            this.colMold_j01.Name = "colMold_j01";
            this.colMold_j01.ReadOnly = true;
            this.colMold_j01.Width = 80;
            // 
            // colMold_tot
            // 
            this.colMold_tot.DataPropertyName = "mold_tot";
            this.colMold_tot.HeaderText = "DG+JX碑數";
            this.colMold_tot.Name = "colMold_tot";
            this.colMold_tot.ReadOnly = true;
            // 
            // colHour_302
            // 
            this.colHour_302.DataPropertyName = "hour_302";
            this.colHour_302.HeaderText = "DG工時";
            this.colHour_302.Name = "colHour_302";
            this.colHour_302.ReadOnly = true;
            this.colHour_302.Width = 80;
            // 
            // colHour_j01
            // 
            this.colHour_j01.DataPropertyName = "hour_j01";
            this.colHour_j01.HeaderText = "JX工時";
            this.colHour_j01.Name = "colHour_j01";
            this.colHour_j01.ReadOnly = true;
            this.colHour_j01.Width = 80;
            // 
            // colHour_tot
            // 
            this.colHour_tot.DataPropertyName = "hour_tot";
            this.colHour_tot.HeaderText = "DG+JX工時";
            this.colHour_tot.Name = "colHour_tot";
            this.colHour_tot.ReadOnly = true;
            // 
            // colPer_qty_302
            // 
            this.colPer_qty_302.DataPropertyName = "per_qty_302";
            this.colPer_qty_302.HeaderText = "DG每碑粒數";
            this.colPer_qty_302.Name = "colPer_qty_302";
            this.colPer_qty_302.ReadOnly = true;
            // 
            // colPer_qty_j01
            // 
            this.colPer_qty_j01.DataPropertyName = "per_qty_j01";
            this.colPer_qty_j01.HeaderText = "JX每碑粒數";
            this.colPer_qty_j01.Name = "colPer_qty_j01";
            this.colPer_qty_j01.ReadOnly = true;
            // 
            // colPer_qty_tot
            // 
            this.colPer_qty_tot.DataPropertyName = "per_qty_tot";
            this.colPer_qty_tot.HeaderText = "DG+JX每碑粒數";
            this.colPer_qty_tot.Name = "colPer_qty_tot";
            this.colPer_qty_tot.ReadOnly = true;
            this.colPer_qty_tot.Width = 120;
            // 
            // colHour_std_302
            // 
            this.colHour_std_302.DataPropertyName = "hour_std_302";
            this.colHour_std_302.HeaderText = "DG平均時產能";
            this.colHour_std_302.Name = "colHour_std_302";
            this.colHour_std_302.ReadOnly = true;
            this.colHour_std_302.Width = 120;
            // 
            // colHour_std_j01
            // 
            this.colHour_std_j01.DataPropertyName = "hour_std_j01";
            this.colHour_std_j01.HeaderText = "JX平均時產能";
            this.colHour_std_j01.Name = "colHour_std_j01";
            this.colHour_std_j01.ReadOnly = true;
            this.colHour_std_j01.Width = 120;
            // 
            // colHour_std_tot
            // 
            this.colHour_std_tot.DataPropertyName = "hour_std_tot";
            this.colHour_std_tot.HeaderText = "DG+JX平均時產能";
            this.colHour_std_tot.Name = "colHour_std_tot";
            this.colHour_std_tot.ReadOnly = true;
            this.colHour_std_tot.Width = 140;
            // 
            // colReach_std
            // 
            this.colReach_std.DataPropertyName = "reach_std";
            this.colReach_std.HeaderText = "DG+JX達標率";
            this.colReach_std.Name = "colReach_std";
            this.colReach_std.ReadOnly = true;
            // 
            // colTran_qty
            // 
            this.colTran_qty.DataPropertyName = "tran_qty";
            this.colTran_qty.HeaderText = "DG+JX移交數量";
            this.colTran_qty.Name = "colTran_qty";
            this.colTran_qty.ReadOnly = true;
            this.colTran_qty.Width = 120;
            // 
            // colTran_weg
            // 
            this.colTran_weg.DataPropertyName = "tran_weg";
            this.colTran_weg.HeaderText = "DG+JX移交重量";
            this.colTran_weg.Name = "colTran_weg";
            this.colTran_weg.ReadOnly = true;
            this.colTran_weg.Width = 120;
            // 
            // frmProductionDataDaily
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 721);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmProductionDataDaily";
            this.Text = "frmProductionDataDaily";
            this.Load += new System.EventHandler(this.frmProductionDataDaily_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnExp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblDep;
        private System.Windows.Forms.TextBox txtDep;
        private System.Windows.Forms.MaskedTextBox mskDat2;
        private System.Windows.Forms.MaskedTextBox mskDat1;
        private System.Windows.Forms.Label lblDat;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeek;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty_302;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty_j01;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty_tot;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMold_302;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMold_j01;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMold_tot;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHour_302;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHour_j01;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHour_tot;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPer_qty_302;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPer_qty_j01;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPer_qty_tot;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHour_std_302;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHour_std_j01;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHour_std_tot;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReach_std;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTran_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTran_weg;
    }
}