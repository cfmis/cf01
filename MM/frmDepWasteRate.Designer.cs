namespace cf01.MM
{
    partial class frmDepWasteRate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDepWasteRate));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lueDepId = new DevExpress.XtraEditors.LookUpEdit();
            this.txtWasteRate = new DevExpress.XtraEditors.TextEdit();
            this.lblWasteRate = new DevExpress.XtraEditors.LabelControl();
            this.lblDepId = new DevExpress.XtraEditors.LabelControl();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.colDepId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepCdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWasteRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.dgvDetails1 = new System.Windows.Forms.DataGridView();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtRate = new DevExpress.XtraEditors.TextEdit();
            this.lblRate = new DevExpress.XtraEditors.LabelControl();
            this.txtProductTypeName = new DevExpress.XtraEditors.TextEdit();
            this.lblProductTypeName = new DevExpress.XtraEditors.LabelControl();
            this.txtProductType = new DevExpress.XtraEditors.TextEdit();
            this.lblProductType = new DevExpress.XtraEditors.LabelControl();
            this.colProductType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueDepId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWasteRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductTypeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.toolStripSeparator1,
            this.btnSave,
            this.toolStripSeparator4,
            this.btnDelete,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(786, 38);
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
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 35);
            this.btnSave.Text = "儲存(&S)";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lueDepId);
            this.panelControl1.Controls.Add(this.txtWasteRate);
            this.panelControl1.Controls.Add(this.lblWasteRate);
            this.panelControl1.Controls.Add(this.lblDepId);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(780, 60);
            this.panelControl1.TabIndex = 1;
            // 
            // lueDepId
            // 
            this.lueDepId.Location = new System.Drawing.Point(38, 20);
            this.lueDepId.Name = "lueDepId";
            this.lueDepId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDepId.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dep_id", 60, "部門編號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dep_cdesc", 80, "部門描述")});
            this.lueDepId.Properties.NullText = "";
            this.lueDepId.Size = new System.Drawing.Size(115, 20);
            this.lueDepId.TabIndex = 4;
            // 
            // txtWasteRate
            // 
            this.txtWasteRate.Location = new System.Drawing.Point(221, 20);
            this.txtWasteRate.Name = "txtWasteRate";
            this.txtWasteRate.Size = new System.Drawing.Size(115, 20);
            this.txtWasteRate.TabIndex = 3;
            // 
            // lblWasteRate
            // 
            this.lblWasteRate.Location = new System.Drawing.Point(175, 23);
            this.lblWasteRate.Name = "lblWasteRate";
            this.lblWasteRate.Size = new System.Drawing.Size(40, 14);
            this.lblWasteRate.TabIndex = 2;
            this.lblWasteRate.Text = "損耗率:";
            // 
            // lblDepId
            // 
            this.lblDepId.Location = new System.Drawing.Point(4, 23);
            this.lblDepId.Name = "lblDepId";
            this.lblDepId.Size = new System.Drawing.Size(28, 14);
            this.lblDepId.TabIndex = 1;
            this.lblDepId.Text = "部門:";
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.ColumnHeadersHeight = 28;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDepId,
            this.colDepCdesc,
            this.colWasteRate});
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 60);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowHeadersWidth = 20;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(780, 435);
            this.dgvDetails.TabIndex = 2;
            this.dgvDetails.SelectionChanged += new System.EventHandler(this.dgvDetails_SelectionChanged);
            // 
            // colDepId
            // 
            this.colDepId.DataPropertyName = "DepId";
            this.colDepId.HeaderText = "部門編號";
            this.colDepId.Name = "colDepId";
            this.colDepId.ReadOnly = true;
            this.colDepId.Width = 80;
            // 
            // colDepCdesc
            // 
            this.colDepCdesc.DataPropertyName = "DepCdesc";
            this.colDepCdesc.HeaderText = "部門描述";
            this.colDepCdesc.Name = "colDepCdesc";
            this.colDepCdesc.ReadOnly = true;
            // 
            // colWasteRate
            // 
            this.colWasteRate.DataPropertyName = "WasteRate";
            this.colWasteRate.HeaderText = "損耗率";
            this.colWasteRate.Name = "colWasteRate";
            this.colWasteRate.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "DepId";
            this.dataGridViewTextBoxColumn1.HeaderText = "部門編號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DepCdesc";
            this.dataGridViewTextBoxColumn2.HeaderText = "部門描述";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "WasteRate";
            this.dataGridViewTextBoxColumn3.HeaderText = "損耗率";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 38);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(786, 524);
            this.xtraTabControl1.TabIndex = 3;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.dgvDetails);
            this.xtraTabPage1.Controls.Add(this.panelControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(780, 495);
            this.xtraTabPage1.Text = "部門損耗率設定";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.dgvDetails1);
            this.xtraTabPage2.Controls.Add(this.panelControl2);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(780, 495);
            this.xtraTabPage2.Text = "產品類型損耗率設定";
            // 
            // dgvDetails1
            // 
            this.dgvDetails1.AllowUserToAddRows = false;
            this.dgvDetails1.ColumnHeadersHeight = 28;
            this.dgvDetails1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetails1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductType,
            this.colProductTypeName,
            this.colRate});
            this.dgvDetails1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails1.Location = new System.Drawing.Point(0, 75);
            this.dgvDetails1.Name = "dgvDetails1";
            this.dgvDetails1.RowHeadersWidth = 20;
            this.dgvDetails1.RowTemplate.Height = 24;
            this.dgvDetails1.Size = new System.Drawing.Size(780, 420);
            this.dgvDetails1.TabIndex = 1;
            this.dgvDetails1.SelectionChanged += new System.EventHandler(this.dgvDetails1_SelectionChanged);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.txtRate);
            this.panelControl2.Controls.Add(this.lblRate);
            this.panelControl2.Controls.Add(this.txtProductTypeName);
            this.panelControl2.Controls.Add(this.lblProductTypeName);
            this.panelControl2.Controls.Add(this.txtProductType);
            this.panelControl2.Controls.Add(this.lblProductType);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(780, 75);
            this.panelControl2.TabIndex = 0;
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(86, 43);
            this.txtRate.Name = "txtRate";
            this.txtRate.Properties.Mask.EditMask = "n4";
            this.txtRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtRate.Size = new System.Drawing.Size(100, 20);
            this.txtRate.TabIndex = 1;
            // 
            // lblRate
            // 
            this.lblRate.Location = new System.Drawing.Point(40, 46);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(40, 14);
            this.lblRate.TabIndex = 0;
            this.lblRate.Text = "損耗率:";
            // 
            // txtProductTypeName
            // 
            this.txtProductTypeName.Location = new System.Drawing.Point(253, 17);
            this.txtProductTypeName.Name = "txtProductTypeName";
            this.txtProductTypeName.Properties.ReadOnly = true;
            this.txtProductTypeName.Size = new System.Drawing.Size(178, 20);
            this.txtProductTypeName.TabIndex = 1;
            // 
            // lblProductTypeName
            // 
            this.lblProductTypeName.Location = new System.Drawing.Point(195, 20);
            this.lblProductTypeName.Name = "lblProductTypeName";
            this.lblProductTypeName.Size = new System.Drawing.Size(52, 14);
            this.lblProductTypeName.TabIndex = 0;
            this.lblProductTypeName.Text = "類型描述:";
            // 
            // txtProductType
            // 
            this.txtProductType.Location = new System.Drawing.Point(86, 17);
            this.txtProductType.Name = "txtProductType";
            this.txtProductType.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProductType.Properties.MaxLength = 2;
            this.txtProductType.Size = new System.Drawing.Size(100, 20);
            this.txtProductType.TabIndex = 1;
            this.txtProductType.Leave += new System.EventHandler(this.txtProductType_Leave);
            // 
            // lblProductType
            // 
            this.lblProductType.Location = new System.Drawing.Point(28, 20);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(52, 14);
            this.lblProductType.TabIndex = 0;
            this.lblProductType.Text = "產品類型:";
            // 
            // colProductType
            // 
            this.colProductType.DataPropertyName = "ProductType";
            this.colProductType.HeaderText = "產品類型";
            this.colProductType.Name = "colProductType";
            this.colProductType.Width = 80;
            // 
            // colProductTypeName
            // 
            this.colProductTypeName.DataPropertyName = "ProductTypeName";
            this.colProductTypeName.HeaderText = "類型描述";
            this.colProductTypeName.Name = "colProductTypeName";
            this.colProductTypeName.Width = 120;
            // 
            // colRate
            // 
            this.colRate.DataPropertyName = "WasteRate";
            this.colRate.HeaderText = "損耗率";
            this.colRate.Name = "colRate";
            this.colRate.Width = 80;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = false;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 35);
            this.btnDelete.Text = "刪除(&D)";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // frmDepWasteRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 562);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmDepWasteRate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDepWasteRate";
            this.Load += new System.EventHandler(this.frmDepWasteRate_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueDepId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWasteRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductTypeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.DataGridView dgvDetails;
        private DevExpress.XtraEditors.TextEdit txtWasteRate;
        private DevExpress.XtraEditors.LabelControl lblWasteRate;
        private DevExpress.XtraEditors.LabelControl lblDepId;
        private DevExpress.XtraEditors.LookUpEdit lueDepId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepCdesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWasteRate;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtRate;
        private DevExpress.XtraEditors.LabelControl lblRate;
        private DevExpress.XtraEditors.TextEdit txtProductTypeName;
        private DevExpress.XtraEditors.LabelControl lblProductTypeName;
        private DevExpress.XtraEditors.TextEdit txtProductType;
        private DevExpress.XtraEditors.LabelControl lblProductType;
        private System.Windows.Forms.DataGridView dgvDetails1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRate;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}