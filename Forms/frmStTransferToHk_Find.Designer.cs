namespace cf01.Forms
{
    partial class frmStTransferToHk_Find
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStTransferToHk_Find));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnConf = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.rdState = new DevExpress.XtraEditors.RadioGroup();
            this.mtbDate2 = new System.Windows.Forms.MaskedTextBox();
            this.mtbDate1 = new System.Windows.Forms.MaskedTextBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblDate = new DevExpress.XtraEditors.LabelControl();
            this.txtMo_id2 = new DevExpress.XtraEditors.TextEdit();
            this.txtMo_id1 = new DevExpress.XtraEditors.TextEdit();
            this.txtId2 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lblMo_id = new DevExpress.XtraEditors.LabelControl();
            this.txtId1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gcDetails = new DevExpress.XtraGrid.GridControl();
            this.dgvDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransfer_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colState = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSequence_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMo_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoods_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransfer_amount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_id2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_id1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.btnConf,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(781, 35);
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
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(65, 35);
            this.toolStripButton1.Text = "查找(&F)";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // btnConf
            // 
            this.btnConf.AutoSize = false;
            this.btnConf.Image = ((System.Drawing.Image)(resources.GetObject("btnConf.Image")));
            this.btnConf.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConf.Name = "btnConf";
            this.btnConf.Size = new System.Drawing.Size(65, 35);
            this.btnConf.Text = "確認(&C)";
            this.btnConf.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConf.Click += new System.EventHandler(this.btnConf_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 35);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.rdState);
            this.panelControl1.Controls.Add(this.mtbDate2);
            this.panelControl1.Controls.Add(this.mtbDate1);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.lblDate);
            this.panelControl1.Controls.Add(this.txtMo_id2);
            this.panelControl1.Controls.Add(this.txtMo_id1);
            this.panelControl1.Controls.Add(this.txtId2);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.lblMo_id);
            this.panelControl1.Controls.Add(this.txtId1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 35);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(781, 100);
            this.panelControl1.TabIndex = 0;
            // 
            // rdState
            // 
            this.rdState.Location = new System.Drawing.Point(428, 52);
            this.rdState.Name = "rdState";
            this.rdState.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "未批準"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "已批準"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "所有")});
            this.rdState.Size = new System.Drawing.Size(284, 27);
            this.rdState.TabIndex = 6;
            // 
            // mtbDate2
            // 
            this.mtbDate2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtbDate2.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.mtbDate2.Location = new System.Drawing.Point(584, 26);
            this.mtbDate2.Mask = "0000/00/00";
            this.mtbDate2.Name = "mtbDate2";
            this.mtbDate2.PromptChar = ' ';
            this.mtbDate2.Size = new System.Drawing.Size(128, 22);
            this.mtbDate2.TabIndex = 3;
            this.mtbDate2.ValidatingType = typeof(System.DateTime);
            // 
            // mtbDate1
            // 
            this.mtbDate1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtbDate1.Location = new System.Drawing.Point(428, 26);
            this.mtbDate1.Mask = "0000/00/00";
            this.mtbDate1.Name = "mtbDate1";
            this.mtbDate1.PromptChar = ' ';
            this.mtbDate1.Size = new System.Drawing.Size(128, 22);
            this.mtbDate1.TabIndex = 2;
            this.mtbDate1.ValidatingType = typeof(System.DateTime);
            this.mtbDate1.Leave += new System.EventHandler(this.mtbDate1_Leave);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(197, 60);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(15, 14);
            this.labelControl5.TabIndex = 13;
            this.labelControl5.Text = "To";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(197, 29);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(15, 14);
            this.labelControl3.TabIndex = 13;
            this.labelControl3.Text = "To";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(561, 29);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(15, 14);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "To";
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(364, 29);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(52, 14);
            this.lblDate.TabIndex = 14;
            this.lblDate.Text = "回港日期:";
            // 
            // txtMo_id2
            // 
            this.txtMo_id2.Location = new System.Drawing.Point(218, 59);
            this.txtMo_id2.Name = "txtMo_id2";
            this.txtMo_id2.Size = new System.Drawing.Size(128, 20);
            this.txtMo_id2.TabIndex = 5;
            // 
            // txtMo_id1
            // 
            this.txtMo_id1.Location = new System.Drawing.Point(62, 59);
            this.txtMo_id1.Name = "txtMo_id1";
            this.txtMo_id1.Size = new System.Drawing.Size(128, 20);
            this.txtMo_id1.TabIndex = 4;
            this.txtMo_id1.Leave += new System.EventHandler(this.txtMo_id1_Leave);
            // 
            // txtId2
            // 
            this.txtId2.Location = new System.Drawing.Point(218, 26);
            this.txtId2.Name = "txtId2";
            this.txtId2.Size = new System.Drawing.Size(128, 20);
            this.txtId2.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(388, 60);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(28, 14);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "狀態:";
            // 
            // lblMo_id
            // 
            this.lblMo_id.Location = new System.Drawing.Point(11, 60);
            this.lblMo_id.Name = "lblMo_id";
            this.lblMo_id.Size = new System.Drawing.Size(52, 14);
            this.lblMo_id.TabIndex = 0;
            this.lblMo_id.Text = "制單編號:";
            // 
            // txtId1
            // 
            this.txtId1.Location = new System.Drawing.Point(62, 26);
            this.txtId1.Name = "txtId1";
            this.txtId1.Size = new System.Drawing.Size(128, 20);
            this.txtId1.TabIndex = 0;
            this.txtId1.Leave += new System.EventHandler(this.txtId1_Leave);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "單據編號:";
            // 
            // gcDetails
            // 
            this.gcDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDetails.Location = new System.Drawing.Point(0, 135);
            this.gcDetails.MainView = this.dgvDetails;
            this.gcDetails.Name = "gcDetails";
            this.gcDetails.Size = new System.Drawing.Size(781, 411);
            this.gcDetails.TabIndex = 2;
            this.gcDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDetails});
            // 
            // dgvDetails
            // 
            this.dgvDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colTransfer_date,
            this.colState,
            this.colSequence_id,
            this.colMo_id,
            this.colGoods_id,
            this.colTransfer_amount});
            this.dgvDetails.GridControl = this.gcDetails;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.OptionsBehavior.Editable = false;
            this.dgvDetails.OptionsSelection.MultiSelect = true;
            this.dgvDetails.OptionsView.ColumnAutoWidth = false;
            this.dgvDetails.OptionsView.ShowGroupPanel = false;
            this.dgvDetails.RowHeight = 25;
            this.dgvDetails.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvDetails_MouseDown);
            // 
            // colId
            // 
            this.colId.Caption = "單據編號";
            this.colId.FieldName = "id";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            this.colId.Width = 120;
            // 
            // colTransfer_date
            // 
            this.colTransfer_date.Caption = "回港日期";
            this.colTransfer_date.FieldName = "transfer_date";
            this.colTransfer_date.Name = "colTransfer_date";
            this.colTransfer_date.Visible = true;
            this.colTransfer_date.VisibleIndex = 1;
            // 
            // colState
            // 
            this.colState.Caption = "狀態";
            this.colState.FieldName = "state";
            this.colState.Name = "colState";
            this.colState.Visible = true;
            this.colState.VisibleIndex = 3;
            // 
            // colSequence_id
            // 
            this.colSequence_id.Caption = "序號";
            this.colSequence_id.FieldName = "sequence_id";
            this.colSequence_id.Name = "colSequence_id";
            this.colSequence_id.Visible = true;
            this.colSequence_id.VisibleIndex = 2;
            // 
            // colMo_id
            // 
            this.colMo_id.Caption = "制單編號";
            this.colMo_id.FieldName = "mo_id";
            this.colMo_id.Name = "colMo_id";
            this.colMo_id.Visible = true;
            this.colMo_id.VisibleIndex = 4;
            // 
            // colGoods_id
            // 
            this.colGoods_id.Caption = "產品編號";
            this.colGoods_id.FieldName = "goods_id";
            this.colGoods_id.Name = "colGoods_id";
            this.colGoods_id.Visible = true;
            this.colGoods_id.VisibleIndex = 5;
            this.colGoods_id.Width = 160;
            // 
            // colTransfer_amount
            // 
            this.colTransfer_amount.Caption = "數量";
            this.colTransfer_amount.FieldName = "transfer_amount";
            this.colTransfer_amount.Name = "colTransfer_amount";
            this.colTransfer_amount.Visible = true;
            this.colTransfer_amount.VisibleIndex = 6;
            // 
            // frmStTransferToHk_Find
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 546);
            this.Controls.Add(this.gcDetails);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmStTransferToHk_Find";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmStTransferToHk_Find";
            this.Load += new System.EventHandler(this.frmStTransferToHk_Find_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_id2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_id1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnConf;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtId2;
        private DevExpress.XtraEditors.TextEdit txtId1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.MaskedTextBox mtbDate2;
        private System.Windows.Forms.MaskedTextBox mtbDate1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblDate;
        private DevExpress.XtraEditors.TextEdit txtMo_id2;
        private DevExpress.XtraEditors.TextEdit txtMo_id1;
        private DevExpress.XtraEditors.LabelControl lblMo_id;
        private DevExpress.XtraEditors.RadioGroup rdState;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraGrid.GridControl gcDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDetails;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colTransfer_date;
        private DevExpress.XtraGrid.Columns.GridColumn colState;
        private DevExpress.XtraGrid.Columns.GridColumn colSequence_id;
        private DevExpress.XtraGrid.Columns.GridColumn colMo_id;
        private DevExpress.XtraGrid.Columns.GridColumn colGoods_id;
        private DevExpress.XtraGrid.Columns.GridColumn colTransfer_amount;
    }
}