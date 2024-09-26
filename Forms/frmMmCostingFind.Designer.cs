namespace cf01.Forms
{
    partial class frmMmCostingFind
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMmCostingFind));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.lblId = new DevExpress.XtraEditors.LabelControl();
            this.txtPrd_mo = new DevExpress.XtraEditors.TextEdit();
            this.lblPrd_mo = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dgvCosting = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMmcosting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrd_mo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrd_mo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCosting)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtId);
            this.panelControl1.Controls.Add(this.lblId);
            this.panelControl1.Controls.Add(this.txtPrd_mo);
            this.panelControl1.Controls.Add(this.lblPrd_mo);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 40);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(819, 67);
            this.panelControl1.TabIndex = 0;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(76, 14);
            this.txtId.Name = "txtId";
            this.txtId.Properties.Mask.EditMask = "\\p{Lu}+";
            this.txtId.Size = new System.Drawing.Size(162, 20);
            this.txtId.TabIndex = 4;
            // 
            // lblId
            // 
            this.lblId.Location = new System.Drawing.Point(22, 17);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(46, 14);
            this.lblId.TabIndex = 6;
            this.lblId.Text = "F0/編號:";
            // 
            // txtPrd_mo
            // 
            this.txtPrd_mo.Location = new System.Drawing.Point(331, 14);
            this.txtPrd_mo.Name = "txtPrd_mo";
            this.txtPrd_mo.Size = new System.Drawing.Size(162, 20);
            this.txtPrd_mo.TabIndex = 5;
            // 
            // lblPrd_mo
            // 
            this.lblPrd_mo.Location = new System.Drawing.Point(274, 17);
            this.lblPrd_mo.Name = "lblPrd_mo";
            this.lblPrd_mo.Size = new System.Drawing.Size(52, 14);
            this.lblPrd_mo.TabIndex = 7;
            this.lblPrd_mo.Text = "參考制單:";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.dgvCosting);
            this.panelControl2.Controls.Add(this.panelControl1);
            this.panelControl2.Controls.Add(this.toolStrip1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(823, 541);
            this.panelControl2.TabIndex = 1;
            // 
            // dgvCosting
            // 
            this.dgvCosting.AllowUserToAddRows = false;
            this.dgvCosting.ColumnHeadersHeight = 25;
            this.dgvCosting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCosting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colCdesc,
            this.colMmcosting,
            this.colPrd_mo});
            this.dgvCosting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCosting.Location = new System.Drawing.Point(2, 107);
            this.dgvCosting.Name = "dgvCosting";
            this.dgvCosting.ReadOnly = true;
            this.dgvCosting.RowHeadersWidth = 20;
            this.dgvCosting.RowTemplate.Height = 24;
            this.dgvCosting.Size = new System.Drawing.Size(819, 432);
            this.dgvCosting.TabIndex = 0;
            this.dgvCosting.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCosting_CellDoubleClick);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "id";
            this.colId.HeaderText = "F0/編號";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 160;
            // 
            // colCdesc
            // 
            this.colCdesc.DataPropertyName = "cdesc";
            this.colCdesc.HeaderText = "描述";
            this.colCdesc.Name = "colCdesc";
            this.colCdesc.ReadOnly = true;
            this.colCdesc.Width = 180;
            // 
            // colMmcosting
            // 
            this.colMmcosting.DataPropertyName = "mmcosting";
            this.colMmcosting.HeaderText = "F0價錢";
            this.colMmcosting.Name = "colMmcosting";
            this.colMmcosting.ReadOnly = true;
            this.colMmcosting.Width = 80;
            // 
            // colPrd_mo
            // 
            this.colPrd_mo.DataPropertyName = "prd_mo";
            this.colPrd_mo.HeaderText = "參考制單";
            this.colPrd_mo.Name = "colPrd_mo";
            this.colPrd_mo.ReadOnly = true;
            this.colPrd_mo.Width = 120;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.toolStripSeparator1,
            this.btnFind,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(2, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(819, 38);
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
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "F0/編號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 160;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "cdesc";
            this.dataGridViewTextBoxColumn2.HeaderText = "描述";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 180;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "mmcosting";
            this.dataGridViewTextBoxColumn3.HeaderText = "F0價錢";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "prd_mo";
            this.dataGridViewTextBoxColumn4.HeaderText = "參考制單";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // frmMmCostingFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 541);
            this.Controls.Add(this.panelControl2);
            this.Name = "frmMmCostingFind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmMmCostingFind";
            this.Load += new System.EventHandler(this.frmMmCostingFind_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrd_mo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCosting)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.DataGridView dgvCosting;
        private DevExpress.XtraEditors.TextEdit txtId;
        private DevExpress.XtraEditors.LabelControl lblId;
        private DevExpress.XtraEditors.TextEdit txtPrd_mo;
        private DevExpress.XtraEditors.LabelControl lblPrd_mo;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCdesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMmcosting;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrd_mo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}