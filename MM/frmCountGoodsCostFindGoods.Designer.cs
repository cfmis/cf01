namespace cf01.MM
{
    partial class frmCountGoodsCostFindGoods
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCountGoodsCostFindGoods));
            this.dgvDetails1 = new System.Windows.Forms.DataGridView();
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrdWeg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWasteWeg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUseWeg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMatItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepCdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.chkShowExistWeg = new DevExpress.XtraEditors.CheckEdit();
            this.txtProcessName = new DevExpress.XtraEditors.TextEdit();
            this.lblMaterialId = new DevExpress.XtraEditors.LabelControl();
            this.lblMaterialName = new DevExpress.XtraEditors.LabelControl();
            this.txtProcesslId = new DevExpress.XtraEditors.TextEdit();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvMatDetails = new System.Windows.Forms.DataGridView();
            this.colMatID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMatDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKgQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowExistWeg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcessName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcesslId.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDetails1
            // 
            this.dgvDetails1.AllowUserToAddRows = false;
            this.dgvDetails1.ColumnHeadersHeight = 28;
            this.dgvDetails1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetails1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductID,
            this.colProductName,
            this.colPrdWeg,
            this.colWasteWeg,
            this.colUseWeg,
            this.colMatItem,
            this.colMatName,
            this.colDepId,
            this.colDepCdesc});
            this.dgvDetails1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails1.Location = new System.Drawing.Point(3, 3);
            this.dgvDetails1.Name = "dgvDetails1";
            this.dgvDetails1.ReadOnly = true;
            this.dgvDetails1.RowHeadersWidth = 20;
            this.dgvDetails1.RowTemplate.Height = 24;
            this.dgvDetails1.Size = new System.Drawing.Size(1083, 472);
            this.dgvDetails1.TabIndex = 9;
            this.dgvDetails1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails1_CellDoubleClick);
            // 
            // colProductID
            // 
            this.colProductID.DataPropertyName = "ProductID";
            this.colProductID.HeaderText = "產品編號";
            this.colProductID.Name = "colProductID";
            this.colProductID.ReadOnly = true;
            this.colProductID.Width = 180;
            // 
            // colProductName
            // 
            this.colProductName.DataPropertyName = "ProductName";
            this.colProductName.HeaderText = "產品描述";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.Width = 260;
            // 
            // colPrdWeg
            // 
            this.colPrdWeg.DataPropertyName = "prd_weg";
            this.colPrdWeg.HeaderText = "每千PCS重量";
            this.colPrdWeg.Name = "colPrdWeg";
            this.colPrdWeg.ReadOnly = true;
            // 
            // colWasteWeg
            // 
            this.colWasteWeg.DataPropertyName = "waste_weg";
            this.colWasteWeg.HeaderText = "每千PCS損耗";
            this.colWasteWeg.Name = "colWasteWeg";
            this.colWasteWeg.ReadOnly = true;
            // 
            // colUseWeg
            // 
            this.colUseWeg.DataPropertyName = "use_weg";
            this.colUseWeg.HeaderText = "每千PCS用料";
            this.colUseWeg.Name = "colUseWeg";
            this.colUseWeg.ReadOnly = true;
            // 
            // colMatItem
            // 
            this.colMatItem.DataPropertyName = "mat_item";
            this.colMatItem.HeaderText = "原料編號";
            this.colMatItem.Name = "colMatItem";
            this.colMatItem.ReadOnly = true;
            this.colMatItem.Width = 180;
            // 
            // colMatName
            // 
            this.colMatName.DataPropertyName = "mat_name";
            this.colMatName.HeaderText = "原料描述";
            this.colMatName.Name = "colMatName";
            this.colMatName.ReadOnly = true;
            this.colMatName.Width = 260;
            // 
            // colDepId
            // 
            this.colDepId.DataPropertyName = "dep_id";
            this.colDepId.HeaderText = "開料部門";
            this.colDepId.Name = "colDepId";
            this.colDepId.ReadOnly = true;
            this.colDepId.Width = 80;
            // 
            // colDepCdesc
            // 
            this.colDepCdesc.DataPropertyName = "dep_cdesc";
            this.colDepCdesc.HeaderText = "部門描述";
            this.colDepCdesc.Name = "colDepCdesc";
            this.colDepCdesc.ReadOnly = true;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.chkShowExistWeg);
            this.panelControl2.Controls.Add(this.txtProcessName);
            this.panelControl2.Controls.Add(this.lblMaterialId);
            this.panelControl2.Controls.Add(this.lblMaterialName);
            this.panelControl2.Controls.Add(this.txtProcesslId);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 38);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1097, 70);
            this.panelControl2.TabIndex = 11;
            // 
            // chkShowExistWeg
            // 
            this.chkShowExistWeg.Location = new System.Drawing.Point(86, 43);
            this.chkShowExistWeg.Name = "chkShowExistWeg";
            this.chkShowExistWeg.Properties.AutoWidth = true;
            this.chkShowExistWeg.Properties.Caption = "顯示已設定單重的產品";
            this.chkShowExistWeg.Size = new System.Drawing.Size(142, 19);
            this.chkShowExistWeg.TabIndex = 2;
            // 
            // txtProcessName
            // 
            this.txtProcessName.Location = new System.Drawing.Point(326, 17);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProcessName.Size = new System.Drawing.Size(353, 20);
            this.txtProcessName.TabIndex = 1;
            // 
            // lblMaterialId
            // 
            this.lblMaterialId.Location = new System.Drawing.Point(28, 20);
            this.lblMaterialId.Name = "lblMaterialId";
            this.lblMaterialId.Size = new System.Drawing.Size(52, 14);
            this.lblMaterialId.TabIndex = 0;
            this.lblMaterialId.Text = "產品編號:";
            // 
            // lblMaterialName
            // 
            this.lblMaterialName.Location = new System.Drawing.Point(268, 20);
            this.lblMaterialName.Name = "lblMaterialName";
            this.lblMaterialName.Size = new System.Drawing.Size(52, 14);
            this.lblMaterialName.TabIndex = 0;
            this.lblMaterialName.Text = "產品描述:";
            // 
            // txtProcesslId
            // 
            this.txtProcesslId.Location = new System.Drawing.Point(86, 17);
            this.txtProcesslId.Name = "txtProcesslId";
            this.txtProcesslId.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProcesslId.Size = new System.Drawing.Size(177, 20);
            this.txtProcesslId.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.toolStripSeparator1,
            this.btnFind,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1097, 38);
            this.toolStrip1.TabIndex = 1;
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ProductID";
            this.dataGridViewTextBoxColumn1.HeaderText = "產品編號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 180;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ProductName";
            this.dataGridViewTextBoxColumn2.HeaderText = "產品描述";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 260;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "prd_weg";
            this.dataGridViewTextBoxColumn3.HeaderText = "每千PCS重量";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "waste_weg";
            this.dataGridViewTextBoxColumn4.HeaderText = "每千PCS損耗";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "use_weg";
            this.dataGridViewTextBoxColumn5.HeaderText = "每千PCS用料";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "mat_item";
            this.dataGridViewTextBoxColumn6.HeaderText = "原料編號";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 180;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "mat_name";
            this.dataGridViewTextBoxColumn7.HeaderText = "原料描述";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 260;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 108);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1097, 504);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvDetails1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1089, 478);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "物料編號資料";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvMatDetails);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1089, 478);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "物料單位轉換資料";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvMatDetails
            // 
            this.dgvMatDetails.AllowUserToAddRows = false;
            this.dgvMatDetails.ColumnHeadersHeight = 28;
            this.dgvMatDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMatDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMatID,
            this.colMatDesc,
            this.colKgQty});
            this.dgvMatDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMatDetails.Location = new System.Drawing.Point(3, 3);
            this.dgvMatDetails.Name = "dgvMatDetails";
            this.dgvMatDetails.ReadOnly = true;
            this.dgvMatDetails.RowHeadersWidth = 20;
            this.dgvMatDetails.RowTemplate.Height = 24;
            this.dgvMatDetails.Size = new System.Drawing.Size(1083, 472);
            this.dgvMatDetails.TabIndex = 10;
            this.dgvMatDetails.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMatDetails_CellDoubleClick);
            // 
            // colMatID
            // 
            this.colMatID.DataPropertyName = "ProductID";
            this.colMatID.HeaderText = "產品編號";
            this.colMatID.Name = "colMatID";
            this.colMatID.ReadOnly = true;
            this.colMatID.Width = 180;
            // 
            // colMatDesc
            // 
            this.colMatDesc.DataPropertyName = "ProductName";
            this.colMatDesc.HeaderText = "產品描述";
            this.colMatDesc.Name = "colMatDesc";
            this.colMatDesc.ReadOnly = true;
            this.colMatDesc.Width = 360;
            // 
            // colKgQty
            // 
            this.colKgQty.DataPropertyName = "rate";
            this.colKgQty.HeaderText = "每Kg個數";
            this.colKgQty.Name = "colKgQty";
            this.colKgQty.ReadOnly = true;
            // 
            // frmCountGoodsCostFindGoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 612);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmCountGoodsCostFindGoods";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmCountGoodsCostFindGoods";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowExistWeg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcessName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcesslId.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetails1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtProcessName;
        private DevExpress.XtraEditors.LabelControl lblMaterialId;
        private DevExpress.XtraEditors.LabelControl lblMaterialName;
        private DevExpress.XtraEditors.TextEdit txtProcesslId;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrdWeg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWasteWeg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUseWeg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepCdesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DevExpress.XtraEditors.CheckEdit chkShowExistWeg;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvMatDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKgQty;
    }
}