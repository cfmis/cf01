namespace cf01.Forms
{
    partial class frmDgdDeliverGoods_Find
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDgdDeliverGoods_Find));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnConf = new System.Windows.Forms.ToolStripButton();
            this.gcDetails = new DevExpress.XtraGrid.GridControl();
            this.dgvDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShip_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSequence_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMo_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoods_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colU_invoice_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGoods_unit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSec_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBox_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblId = new DevExpress.XtraEditors.LabelControl();
            this.lblDate = new DevExpress.XtraEditors.LabelControl();
            this.lblMo_id = new DevExpress.XtraEditors.LabelControl();
            this.txtId1 = new DevExpress.XtraEditors.TextEdit();
            this.txtMo_id1 = new DevExpress.XtraEditors.TextEdit();
            this.txtId2 = new DevExpress.XtraEditors.TextEdit();
            this.txtMo_id2 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtPono = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtOcno = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dtDate2 = new DevExpress.XtraEditors.DateEdit();
            this.dtDate1 = new DevExpress.XtraEditors.DateEdit();
            this.order_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pono = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_id1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_id2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPono.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOcno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClose,
            this.toolStripSeparator1,
            this.btnFind,
            this.toolStripSeparator2,
            this.btnConf});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1052, 38);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = false;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(65, 35);
            this.btnClose.Text = "退出(&X)";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.btnFind.Text = "查找(&F)";
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
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
            // gcDetails
            // 
            this.gcDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDetails.Location = new System.Drawing.Point(0, 109);
            this.gcDetails.MainView = this.dgvDetails;
            this.gcDetails.Name = "gcDetails";
            this.gcDetails.Size = new System.Drawing.Size(1052, 504);
            this.gcDetails.TabIndex = 3;
            this.gcDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDetails});
            // 
            // dgvDetails
            // 
            this.dgvDetails.ColumnPanelRowHeight = 30;
            this.dgvDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colShip_date,
            this.colSequence_id,
            this.colMo_id,
            this.colGoods_id,
            this.colU_invoice_qty,
            this.colGoods_unit,
            this.colSec_qty,
            this.colBox_no,
            this.order_id,
            this.pono});
            this.dgvDetails.GridControl = this.gcDetails;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.OptionsSelection.MultiSelect = true;
            this.dgvDetails.OptionsView.ColumnAutoWidth = false;
            this.dgvDetails.OptionsView.ShowGroupPanel = false;
            this.dgvDetails.RowHeight = 30;
            this.dgvDetails.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvDetails_MouseDown);
            // 
            // colId
            // 
            this.colId.Caption = "裝箱單號";
            this.colId.FieldName = "id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.ReadOnly = true;
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            this.colId.Width = 100;
            // 
            // colShip_date
            // 
            this.colShip_date.Caption = "送貨日期";
            this.colShip_date.FieldName = "ship_date";
            this.colShip_date.Name = "colShip_date";
            this.colShip_date.OptionsColumn.AllowEdit = false;
            this.colShip_date.OptionsColumn.ReadOnly = true;
            this.colShip_date.Visible = true;
            this.colShip_date.VisibleIndex = 1;
            this.colShip_date.Width = 80;
            // 
            // colSequence_id
            // 
            this.colSequence_id.Caption = "序號";
            this.colSequence_id.FieldName = "sequence_id";
            this.colSequence_id.Name = "colSequence_id";
            this.colSequence_id.OptionsColumn.AllowEdit = false;
            this.colSequence_id.OptionsColumn.ReadOnly = true;
            this.colSequence_id.Visible = true;
            this.colSequence_id.VisibleIndex = 2;
            this.colSequence_id.Width = 60;
            // 
            // colMo_id
            // 
            this.colMo_id.Caption = "制單編號";
            this.colMo_id.FieldName = "mo_id";
            this.colMo_id.Name = "colMo_id";
            this.colMo_id.OptionsColumn.AllowEdit = false;
            this.colMo_id.OptionsColumn.ReadOnly = true;
            this.colMo_id.Visible = true;
            this.colMo_id.VisibleIndex = 3;
            this.colMo_id.Width = 80;
            // 
            // colGoods_id
            // 
            this.colGoods_id.Caption = "產品編號";
            this.colGoods_id.FieldName = "goods_id";
            this.colGoods_id.Name = "colGoods_id";
            this.colGoods_id.OptionsColumn.AllowEdit = false;
            this.colGoods_id.OptionsColumn.ReadOnly = true;
            this.colGoods_id.Visible = true;
            this.colGoods_id.VisibleIndex = 4;
            this.colGoods_id.Width = 120;
            // 
            // colU_invoice_qty
            // 
            this.colU_invoice_qty.Caption = "送貨數量";
            this.colU_invoice_qty.FieldName = "u_invoice_qty";
            this.colU_invoice_qty.Name = "colU_invoice_qty";
            this.colU_invoice_qty.OptionsColumn.AllowEdit = false;
            this.colU_invoice_qty.OptionsColumn.ReadOnly = true;
            this.colU_invoice_qty.Visible = true;
            this.colU_invoice_qty.VisibleIndex = 5;
            this.colU_invoice_qty.Width = 80;
            // 
            // colGoods_unit
            // 
            this.colGoods_unit.Caption = "數量單位";
            this.colGoods_unit.FieldName = "goods_unit";
            this.colGoods_unit.Name = "colGoods_unit";
            this.colGoods_unit.OptionsColumn.AllowEdit = false;
            this.colGoods_unit.OptionsColumn.ReadOnly = true;
            this.colGoods_unit.Visible = true;
            this.colGoods_unit.VisibleIndex = 6;
            this.colGoods_unit.Width = 60;
            // 
            // colSec_qty
            // 
            this.colSec_qty.Caption = "重量";
            this.colSec_qty.FieldName = "sec_qty";
            this.colSec_qty.Name = "colSec_qty";
            this.colSec_qty.OptionsColumn.ReadOnly = true;
            this.colSec_qty.Visible = true;
            this.colSec_qty.VisibleIndex = 7;
            // 
            // colBox_no
            // 
            this.colBox_no.AppearanceCell.Options.UseTextOptions = true;
            this.colBox_no.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBox_no.Caption = "箱號";
            this.colBox_no.FieldName = "box_no";
            this.colBox_no.Name = "colBox_no";
            this.colBox_no.OptionsColumn.ReadOnly = true;
            this.colBox_no.Visible = true;
            this.colBox_no.VisibleIndex = 8;
            // 
            // lblId
            // 
            this.lblId.Location = new System.Drawing.Point(27, 15);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(52, 14);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "裝箱單號:";
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(325, 15);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(52, 14);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "送貨日期:";
            // 
            // lblMo_id
            // 
            this.lblMo_id.Location = new System.Drawing.Point(27, 41);
            this.lblMo_id.Name = "lblMo_id";
            this.lblMo_id.Size = new System.Drawing.Size(52, 14);
            this.lblMo_id.TabIndex = 0;
            this.lblMo_id.Text = "制單編號:";
            // 
            // txtId1
            // 
            this.txtId1.EnterMoveNextControl = true;
            this.txtId1.Location = new System.Drawing.Point(85, 12);
            this.txtId1.Name = "txtId1";
            this.txtId1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtId1.Properties.MaxLength = 12;
            this.txtId1.Size = new System.Drawing.Size(100, 20);
            this.txtId1.TabIndex = 0;
            this.txtId1.Leave += new System.EventHandler(this.txtId1_Leave);
            // 
            // txtMo_id1
            // 
            this.txtMo_id1.EnterMoveNextControl = true;
            this.txtMo_id1.Location = new System.Drawing.Point(85, 38);
            this.txtMo_id1.Name = "txtMo_id1";
            this.txtMo_id1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo_id1.Properties.MaxLength = 9;
            this.txtMo_id1.Size = new System.Drawing.Size(100, 20);
            this.txtMo_id1.TabIndex = 4;
            this.txtMo_id1.Leave += new System.EventHandler(this.txtMo_id1_Leave);
            // 
            // txtId2
            // 
            this.txtId2.EnterMoveNextControl = true;
            this.txtId2.Location = new System.Drawing.Point(209, 12);
            this.txtId2.Name = "txtId2";
            this.txtId2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtId2.Properties.MaxLength = 12;
            this.txtId2.Size = new System.Drawing.Size(100, 20);
            this.txtId2.TabIndex = 1;
            // 
            // txtMo_id2
            // 
            this.txtMo_id2.EnterMoveNextControl = true;
            this.txtMo_id2.Location = new System.Drawing.Point(209, 38);
            this.txtMo_id2.Name = "txtMo_id2";
            this.txtMo_id2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo_id2.Properties.MaxLength = 9;
            this.txtMo_id2.Size = new System.Drawing.Size(100, 20);
            this.txtMo_id2.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(192, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(8, 14);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "--";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(192, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(8, 14);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "--";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtPono);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.txtOcno);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.dtDate2);
            this.panelControl1.Controls.Add(this.dtDate1);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtMo_id2);
            this.panelControl1.Controls.Add(this.txtId2);
            this.panelControl1.Controls.Add(this.txtMo_id1);
            this.panelControl1.Controls.Add(this.txtId1);
            this.panelControl1.Controls.Add(this.lblMo_id);
            this.panelControl1.Controls.Add(this.lblDate);
            this.panelControl1.Controls.Add(this.lblId);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 38);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1052, 71);
            this.panelControl1.TabIndex = 1;
            // 
            // txtPono
            // 
            this.txtPono.EnterMoveNextControl = true;
            this.txtPono.Location = new System.Drawing.Point(582, 40);
            this.txtPono.Name = "txtPono";
            this.txtPono.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPono.Properties.MaxLength = 20;
            this.txtPono.Size = new System.Drawing.Size(142, 20);
            this.txtPono.TabIndex = 201;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(534, 43);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(45, 14);
            this.labelControl5.TabIndex = 200;
            this.labelControl5.Text = "PO NO.:";
            // 
            // txtOcno
            // 
            this.txtOcno.EnterMoveNextControl = true;
            this.txtOcno.Location = new System.Drawing.Point(384, 40);
            this.txtOcno.Name = "txtOcno";
            this.txtOcno.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOcno.Properties.MaxLength = 20;
            this.txtOcno.Size = new System.Drawing.Size(142, 20);
            this.txtOcno.TabIndex = 199;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(326, 43);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 14);
            this.labelControl4.TabIndex = 198;
            this.labelControl4.Text = "OC 編號:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(548, 15);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(8, 14);
            this.labelControl3.TabIndex = 197;
            this.labelControl3.Text = "--";
            // 
            // dtDate2
            // 
            this.dtDate2.EditValue = "";
            this.dtDate2.EnterMoveNextControl = true;
            this.dtDate2.Location = new System.Drawing.Point(583, 12);
            this.dtDate2.Name = "dtDate2";
            this.dtDate2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.dtDate2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDate2.Properties.Mask.BeepOnError = true;
            this.dtDate2.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.dtDate2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtDate2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtDate2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtDate2.Size = new System.Drawing.Size(141, 22);
            this.dtDate2.TabIndex = 196;
            this.dtDate2.Tag = "2";
            // 
            // dtDate1
            // 
            this.dtDate1.EditValue = "";
            this.dtDate1.EnterMoveNextControl = true;
            this.dtDate1.Location = new System.Drawing.Point(384, 12);
            this.dtDate1.Name = "dtDate1";
            this.dtDate1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.dtDate1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDate1.Properties.Mask.BeepOnError = true;
            this.dtDate1.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.dtDate1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtDate1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtDate1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtDate1.Size = new System.Drawing.Size(142, 22);
            this.dtDate1.TabIndex = 195;
            this.dtDate1.Tag = "2";
            this.dtDate1.Leave += new System.EventHandler(this.dtDate1_Leave);
            // 
            // order_id
            // 
            this.order_id.Caption = "OC No.";
            this.order_id.FieldName = "order_id";
            this.order_id.Name = "order_id";
            this.order_id.OptionsColumn.AllowEdit = false;
            this.order_id.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.order_id.OptionsColumn.ReadOnly = true;
            this.order_id.Visible = true;
            this.order_id.VisibleIndex = 9;
            this.order_id.Width = 150;
            // 
            // pono
            // 
            this.pono.Caption = "PO No.";
            this.pono.FieldName = "pono";
            this.pono.Name = "pono";
            this.pono.OptionsColumn.AllowEdit = false;
            this.pono.OptionsColumn.AllowMove = false;
            this.pono.OptionsColumn.ReadOnly = true;
            this.pono.Visible = true;
            this.pono.VisibleIndex = 10;
            this.pono.Width = 131;
            // 
            // frmDgdDeliverGoods_Find
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 613);
            this.Controls.Add(this.gcDetails);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmDgdDeliverGoods_Find";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDgdDeliverGoods_Find";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_id1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_id2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPono.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOcno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private DevExpress.XtraGrid.GridControl gcDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDetails;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colShip_date;
        private DevExpress.XtraGrid.Columns.GridColumn colSequence_id;
        private DevExpress.XtraGrid.Columns.GridColumn colMo_id;
        private DevExpress.XtraGrid.Columns.GridColumn colGoods_id;
        private DevExpress.XtraGrid.Columns.GridColumn colU_invoice_qty;
        private DevExpress.XtraGrid.Columns.GridColumn colGoods_unit;
        private DevExpress.XtraGrid.Columns.GridColumn colSec_qty;
        private System.Windows.Forms.ToolStripButton btnConf;
        private DevExpress.XtraGrid.Columns.GridColumn colBox_no;
        private DevExpress.XtraEditors.LabelControl lblId;
        private DevExpress.XtraEditors.LabelControl lblDate;
        private DevExpress.XtraEditors.LabelControl lblMo_id;
        private DevExpress.XtraEditors.TextEdit txtId1;
        private DevExpress.XtraEditors.TextEdit txtMo_id1;
        private DevExpress.XtraEditors.TextEdit txtId2;
        private DevExpress.XtraEditors.TextEdit txtMo_id2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.DateEdit dtDate2;
        private DevExpress.XtraEditors.DateEdit dtDate1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtPono;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtOcno;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraGrid.Columns.GridColumn order_id;
        private DevExpress.XtraGrid.Columns.GridColumn pono;
    }
}