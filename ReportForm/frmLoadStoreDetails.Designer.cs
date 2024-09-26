namespace cf01.ReportForm
{
    partial class frmLoadStoreDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoadStoreDetails));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExpToExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkLoadLocGroup = new DevExpress.XtraEditors.CheckEdit();
            this.txtPrdMoTo = new DevExpress.XtraEditors.TextEdit();
            this.txtPrdItemTo = new DevExpress.XtraEditors.TextEdit();
            this.txtLotNoTo = new DevExpress.XtraEditors.TextEdit();
            this.txtPrdMoFrom = new DevExpress.XtraEditors.TextEdit();
            this.txtPrdItemFrom = new DevExpress.XtraEditors.TextEdit();
            this.lblPrdMo = new DevExpress.XtraEditors.LabelControl();
            this.lblPrdItem = new DevExpress.XtraEditors.LabelControl();
            this.txtLotNoFrom = new DevExpress.XtraEditors.TextEdit();
            this.lblLotNo = new DevExpress.XtraEditors.LabelControl();
            this.txtLocNo = new DevExpress.XtraEditors.TextEdit();
            this.lblLocNo = new DevExpress.XtraEditors.LabelControl();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrdItemCdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrdMo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLotNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStWeg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkLoadLocGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdMoTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdItemTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotNoTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdMoFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdItemFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotNoFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocNo.Properties)).BeginInit();
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
            this.btnExpToExcel,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1031, 38);
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
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // btnFind
            // 
            this.btnFind.AutoSize = false;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(65, 35);
            this.btnFind.Text = "查詢(&F)";
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // btnExpToExcel
            // 
            this.btnExpToExcel.AutoSize = false;
            this.btnExpToExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExpToExcel.Image")));
            this.btnExpToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExpToExcel.Name = "btnExpToExcel";
            this.btnExpToExcel.Size = new System.Drawing.Size(80, 35);
            this.btnExpToExcel.Text = "匯出到Excel";
            this.btnExpToExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExpToExcel.Click += new System.EventHandler(this.btnExpToExcel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.chkLoadLocGroup);
            this.panelControl1.Controls.Add(this.txtPrdMoTo);
            this.panelControl1.Controls.Add(this.txtPrdItemTo);
            this.panelControl1.Controls.Add(this.txtLotNoTo);
            this.panelControl1.Controls.Add(this.txtPrdMoFrom);
            this.panelControl1.Controls.Add(this.txtPrdItemFrom);
            this.panelControl1.Controls.Add(this.lblPrdMo);
            this.panelControl1.Controls.Add(this.lblPrdItem);
            this.panelControl1.Controls.Add(this.txtLotNoFrom);
            this.panelControl1.Controls.Add(this.lblLotNo);
            this.panelControl1.Controls.Add(this.txtLocNo);
            this.panelControl1.Controls.Add(this.lblLocNo);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 38);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1031, 75);
            this.panelControl1.TabIndex = 1;
            // 
            // chkLoadLocGroup
            // 
            this.chkLoadLocGroup.Location = new System.Drawing.Point(246, 11);
            this.chkLoadLocGroup.Name = "chkLoadLocGroup";
            this.chkLoadLocGroup.Properties.Caption = "按貨倉合併的記錄";
            this.chkLoadLocGroup.Size = new System.Drawing.Size(149, 19);
            this.chkLoadLocGroup.TabIndex = 2;
            // 
            // txtPrdMoTo
            // 
            this.txtPrdMoTo.Location = new System.Drawing.Point(246, 36);
            this.txtPrdMoTo.Name = "txtPrdMoTo";
            this.txtPrdMoTo.Size = new System.Drawing.Size(149, 20);
            this.txtPrdMoTo.TabIndex = 4;
            // 
            // txtPrdItemTo
            // 
            this.txtPrdItemTo.Location = new System.Drawing.Point(668, 36);
            this.txtPrdItemTo.Name = "txtPrdItemTo";
            this.txtPrdItemTo.Size = new System.Drawing.Size(188, 20);
            this.txtPrdItemTo.TabIndex = 6;
            // 
            // txtLotNoTo
            // 
            this.txtLotNoTo.Location = new System.Drawing.Point(668, 11);
            this.txtLotNoTo.Name = "txtLotNoTo";
            this.txtLotNoTo.Size = new System.Drawing.Size(188, 20);
            this.txtLotNoTo.TabIndex = 2;
            // 
            // txtPrdMoFrom
            // 
            this.txtPrdMoFrom.Location = new System.Drawing.Point(82, 36);
            this.txtPrdMoFrom.Name = "txtPrdMoFrom";
            this.txtPrdMoFrom.Size = new System.Drawing.Size(149, 20);
            this.txtPrdMoFrom.TabIndex = 3;
            this.txtPrdMoFrom.Leave += new System.EventHandler(this.txtPrdMoFrom_Leave);
            // 
            // txtPrdItemFrom
            // 
            this.txtPrdItemFrom.Location = new System.Drawing.Point(459, 36);
            this.txtPrdItemFrom.Name = "txtPrdItemFrom";
            this.txtPrdItemFrom.Size = new System.Drawing.Size(188, 20);
            this.txtPrdItemFrom.TabIndex = 5;
            this.txtPrdItemFrom.Leave += new System.EventHandler(this.txtPrdItemFrom_Leave);
            // 
            // lblPrdMo
            // 
            this.lblPrdMo.Location = new System.Drawing.Point(25, 39);
            this.lblPrdMo.Name = "lblPrdMo";
            this.lblPrdMo.Size = new System.Drawing.Size(52, 14);
            this.lblPrdMo.TabIndex = 0;
            this.lblPrdMo.Text = "制單編號:";
            // 
            // lblPrdItem
            // 
            this.lblPrdItem.Location = new System.Drawing.Point(401, 39);
            this.lblPrdItem.Name = "lblPrdItem";
            this.lblPrdItem.Size = new System.Drawing.Size(52, 14);
            this.lblPrdItem.TabIndex = 0;
            this.lblPrdItem.Text = "物料編號:";
            // 
            // txtLotNoFrom
            // 
            this.txtLotNoFrom.Location = new System.Drawing.Point(459, 11);
            this.txtLotNoFrom.Name = "txtLotNoFrom";
            this.txtLotNoFrom.Size = new System.Drawing.Size(188, 20);
            this.txtLotNoFrom.TabIndex = 1;
            this.txtLotNoFrom.Leave += new System.EventHandler(this.txtLotNoFrom_Leave);
            // 
            // lblLotNo
            // 
            this.lblLotNo.Location = new System.Drawing.Point(425, 14);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.Size = new System.Drawing.Size(28, 14);
            this.lblLotNo.TabIndex = 0;
            this.lblLotNo.Text = "批號:";
            // 
            // txtLocNo
            // 
            this.txtLocNo.Location = new System.Drawing.Point(83, 11);
            this.txtLocNo.Name = "txtLocNo";
            this.txtLocNo.Size = new System.Drawing.Size(149, 20);
            this.txtLocNo.TabIndex = 0;
            // 
            // lblLocNo
            // 
            this.lblLocNo.Location = new System.Drawing.Point(25, 14);
            this.lblLocNo.Name = "lblLocNo";
            this.lblLocNo.Size = new System.Drawing.Size(52, 14);
            this.lblLocNo.TabIndex = 0;
            this.lblLocNo.Text = "貨倉編號:";
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.ColumnHeadersHeight = 28;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLocNo,
            this.colPrdItem,
            this.colPrdItemCdesc,
            this.colPrdMo,
            this.colLotNo,
            this.colStQty,
            this.colStWeg,
            this.colStDat});
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 113);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowHeadersWidth = 20;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(1031, 541);
            this.dgvDetails.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "loc_no";
            this.dataGridViewTextBoxColumn1.HeaderText = "貨倉編號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "prd_item";
            this.dataGridViewTextBoxColumn2.HeaderText = "物料編號";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 160;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "prd_item_cdesc";
            this.dataGridViewTextBoxColumn3.HeaderText = "物料描述";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "prd_mo";
            this.dataGridViewTextBoxColumn4.HeaderText = "制單編號";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "lot_no";
            this.dataGridViewTextBoxColumn5.HeaderText = "批號";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "st_qty";
            this.dataGridViewTextBoxColumn6.HeaderText = "庫存數量";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "st_weg";
            this.dataGridViewTextBoxColumn7.HeaderText = "庫存重量";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "st_dat";
            this.dataGridViewTextBoxColumn8.HeaderText = "入倉日期";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 80;
            // 
            // colLocNo
            // 
            this.colLocNo.DataPropertyName = "loc_no";
            this.colLocNo.HeaderText = "貨倉編號";
            this.colLocNo.Name = "colLocNo";
            this.colLocNo.ReadOnly = true;
            this.colLocNo.Width = 80;
            // 
            // colPrdItem
            // 
            this.colPrdItem.DataPropertyName = "prd_item";
            this.colPrdItem.HeaderText = "物料編號";
            this.colPrdItem.Name = "colPrdItem";
            this.colPrdItem.ReadOnly = true;
            this.colPrdItem.Width = 160;
            // 
            // colPrdItemCdesc
            // 
            this.colPrdItemCdesc.DataPropertyName = "prd_item_cdesc";
            this.colPrdItemCdesc.HeaderText = "物料描述";
            this.colPrdItemCdesc.Name = "colPrdItemCdesc";
            this.colPrdItemCdesc.ReadOnly = true;
            this.colPrdItemCdesc.Width = 200;
            // 
            // colPrdMo
            // 
            this.colPrdMo.DataPropertyName = "prd_mo";
            this.colPrdMo.HeaderText = "制單編號";
            this.colPrdMo.Name = "colPrdMo";
            this.colPrdMo.ReadOnly = true;
            this.colPrdMo.Width = 80;
            // 
            // colLotNo
            // 
            this.colLotNo.DataPropertyName = "lot_no";
            this.colLotNo.HeaderText = "批號";
            this.colLotNo.Name = "colLotNo";
            this.colLotNo.ReadOnly = true;
            this.colLotNo.Width = 80;
            // 
            // colStQty
            // 
            this.colStQty.DataPropertyName = "st_qty";
            this.colStQty.HeaderText = "庫存數量";
            this.colStQty.Name = "colStQty";
            this.colStQty.ReadOnly = true;
            this.colStQty.Width = 80;
            // 
            // colStWeg
            // 
            this.colStWeg.DataPropertyName = "st_weg";
            this.colStWeg.HeaderText = "庫存重量";
            this.colStWeg.Name = "colStWeg";
            this.colStWeg.ReadOnly = true;
            this.colStWeg.Width = 80;
            // 
            // colStDat
            // 
            this.colStDat.DataPropertyName = "st_dat";
            this.colStDat.HeaderText = "入倉日期";
            this.colStDat.Name = "colStDat";
            this.colStDat.ReadOnly = true;
            this.colStDat.Width = 80;
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.Location = new System.Drawing.Point(862, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(139, 42);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "如果是按貨倉分組,要在表bs_LoadStoreDetailsLocGroup中加入。";
            this.labelControl1.Visible = false;
            // 
            // frmLoadStoreDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 654);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmLoadStoreDetails";
            this.Text = "frmLoadStoreDetails";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkLoadLocGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdMoTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdItemTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotNoTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdMoFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrdItemFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotNoFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnExpToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrdItemCdesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrdMo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLotNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStWeg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStDat;
        private DevExpress.XtraEditors.TextEdit txtPrdMoTo;
        private DevExpress.XtraEditors.TextEdit txtPrdItemTo;
        private DevExpress.XtraEditors.TextEdit txtLotNoTo;
        private DevExpress.XtraEditors.TextEdit txtPrdMoFrom;
        private DevExpress.XtraEditors.TextEdit txtPrdItemFrom;
        private DevExpress.XtraEditors.LabelControl lblPrdMo;
        private DevExpress.XtraEditors.LabelControl lblPrdItem;
        private DevExpress.XtraEditors.TextEdit txtLotNoFrom;
        private DevExpress.XtraEditors.LabelControl lblLotNo;
        private DevExpress.XtraEditors.TextEdit txtLocNo;
        private DevExpress.XtraEditors.LabelControl lblLocNo;
        private DevExpress.XtraEditors.CheckEdit chkLoadLocGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}