namespace cf01.Forms
{
    partial class frmTestItemSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestItemSetting));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.MtxtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.lblIsExsit = new DevExpress.XtraEditors.LabelControl();
            this.lblRemark = new DevExpress.XtraEditors.LabelControl();
            this.lueItemType = new DevExpress.XtraEditors.LookUpEdit();
            this.lblItemType = new DevExpress.XtraEditors.LabelControl();
            this.lueTestType = new DevExpress.XtraEditors.LookUpEdit();
            this.lblType = new DevExpress.XtraEditors.LabelControl();
            this.btnDelItem = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddItem = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gvItemDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Item_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueItemId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.Item_cdesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Item_edesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Remark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Seq_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsExsit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MtxtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueItemType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTestType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItemDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueItemId)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.btnNew,
            this.btnEdit,
            this.btnSave,
            this.btnSearch,
            this.btnCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(818, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(52, 22);
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(52, 22);
            this.btnNew.Text = "新增";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(52, 22);
            this.btnEdit.Text = "編輯";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(52, 22);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(52, 22);
            this.btnSearch.Text = "查找";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(52, 22);
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.MtxtRemark);
            this.splitContainer1.Panel1.Controls.Add(this.lblIsExsit);
            this.splitContainer1.Panel1.Controls.Add(this.lblRemark);
            this.splitContainer1.Panel1.Controls.Add(this.lueItemType);
            this.splitContainer1.Panel1.Controls.Add(this.lblItemType);
            this.splitContainer1.Panel1.Controls.Add(this.lueTestType);
            this.splitContainer1.Panel1.Controls.Add(this.lblType);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnDelItem);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddItem);
            this.splitContainer1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainer1.Size = new System.Drawing.Size(818, 472);
            this.splitContainer1.SplitterDistance = 93;
            this.splitContainer1.TabIndex = 6;
            // 
            // MtxtRemark
            // 
            this.MtxtRemark.Location = new System.Drawing.Point(465, 14);
            this.MtxtRemark.Name = "MtxtRemark";
            this.MtxtRemark.Size = new System.Drawing.Size(341, 71);
            this.MtxtRemark.TabIndex = 6;
            // 
            // lblIsExsit
            // 
            this.lblIsExsit.Location = new System.Drawing.Point(589, 47);
            this.lblIsExsit.Name = "lblIsExsit";
            this.lblIsExsit.Size = new System.Drawing.Size(0, 14);
            this.lblIsExsit.TabIndex = 7;
            // 
            // lblRemark
            // 
            this.lblRemark.Location = new System.Drawing.Point(423, 17);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(36, 14);
            this.lblRemark.TabIndex = 4;
            this.lblRemark.Text = "備註：";
            // 
            // lueItemType
            // 
            this.lueItemType.Location = new System.Drawing.Point(88, 60);
            this.lueItemType.Name = "lueItemType";
            this.lueItemType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lueItemType.Properties.Appearance.Options.UseFont = true;
            this.lueItemType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueItemType.Properties.NullText = "";
            this.lueItemType.Size = new System.Drawing.Size(304, 26);
            this.lueItemType.TabIndex = 3;
            this.lueItemType.EditValueChanged += new System.EventHandler(this.lueItemType_EditValueChanged);
            // 
            // lblItemType
            // 
            this.lblItemType.Location = new System.Drawing.Point(22, 63);
            this.lblItemType.Name = "lblItemType";
            this.lblItemType.Size = new System.Drawing.Size(60, 14);
            this.lblItemType.TabIndex = 2;
            this.lblItemType.Text = "項目類型：";
            // 
            // lueTestType
            // 
            this.lueTestType.Location = new System.Drawing.Point(88, 14);
            this.lueTestType.Name = "lueTestType";
            this.lueTestType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lueTestType.Properties.Appearance.Options.UseFont = true;
            this.lueTestType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTestType.Properties.NullText = "";
            this.lueTestType.Size = new System.Drawing.Size(230, 26);
            this.lueTestType.TabIndex = 1;
            this.lueTestType.EditValueChanged += new System.EventHandler(this.lueTestType_EditValueChanged);
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(22, 17);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(60, 14);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "測試類型：";
            // 
            // btnDelItem
            // 
            this.btnDelItem.Enabled = false;
            this.btnDelItem.Image = ((System.Drawing.Image)(resources.GetObject("btnDelItem.Image")));
            this.btnDelItem.Location = new System.Drawing.Point(164, 5);
            this.btnDelItem.Name = "btnDelItem";
            this.btnDelItem.Size = new System.Drawing.Size(102, 27);
            this.btnDelItem.TabIndex = 41;
            this.btnDelItem.Text = "項目刪除(&L)";
            this.btnDelItem.Click += new System.EventHandler(this.btnDelItem_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Enabled = false;
            this.btnAddItem.Image = ((System.Drawing.Image)(resources.GetObject("btnAddItem.Image")));
            this.btnAddItem.Location = new System.Drawing.Point(22, 5);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(102, 27);
            this.btnAddItem.TabIndex = 40;
            this.btnAddItem.Text = "項目增加(&N)";
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 38);
            this.gridControl1.MainView = this.gvItemDetails;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueItemId});
            this.gridControl1.Size = new System.Drawing.Size(818, 337);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItemDetails});
            // 
            // gvItemDetails
            // 
            this.gvItemDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Item_Id,
            this.Item_cdesc,
            this.Item_edesc,
            this.Remark,
            this.Seq_id,
            this.IsExsit});
            this.gvItemDetails.GridControl = this.gridControl1;
            this.gvItemDetails.Name = "gvItemDetails";
            this.gvItemDetails.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gvItemDetails.OptionsView.ShowGroupPanel = false;
            // 
            // Item_Id
            // 
            this.Item_Id.Caption = "測試項目";
            this.Item_Id.ColumnEdit = this.lueItemId;
            this.Item_Id.FieldName = "test_item_id";
            this.Item_Id.Name = "Item_Id";
            this.Item_Id.Visible = true;
            this.Item_Id.VisibleIndex = 0;
            // 
            // lueItemId
            // 
            this.lueItemId.AutoHeight = false;
            this.lueItemId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueItemId.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("test_item_id", 40, "id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("test_item_cdesc", 120, "cdesc"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("test_item_edesc", 200, "edesc")});
            this.lueItemId.DropDownRows = 20;
            this.lueItemId.Name = "lueItemId";
            this.lueItemId.NullText = "";
            this.lueItemId.PopupFormMinSize = new System.Drawing.Size(440, 0);
            this.lueItemId.ShowHeader = false;
            this.lueItemId.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueItemId.EditValueChanged += new System.EventHandler(this.lueItemId_EditValueChanged);
            // 
            // Item_cdesc
            // 
            this.Item_cdesc.Caption = "中文描述";
            this.Item_cdesc.FieldName = "test_item_cdesc";
            this.Item_cdesc.Name = "Item_cdesc";
            this.Item_cdesc.OptionsColumn.AllowEdit = false;
            this.Item_cdesc.Visible = true;
            this.Item_cdesc.VisibleIndex = 1;
            // 
            // Item_edesc
            // 
            this.Item_edesc.Caption = "英文描述";
            this.Item_edesc.FieldName = "test_item_edesc";
            this.Item_edesc.Name = "Item_edesc";
            this.Item_edesc.OptionsColumn.AllowEdit = false;
            this.Item_edesc.Visible = true;
            this.Item_edesc.VisibleIndex = 2;
            // 
            // Remark
            // 
            this.Remark.Caption = "備註";
            this.Remark.FieldName = "remark";
            this.Remark.Name = "Remark";
            this.Remark.Visible = true;
            this.Remark.VisibleIndex = 3;
            // 
            // Seq_id
            // 
            this.Seq_id.Caption = "序號";
            this.Seq_id.FieldName = "seq_id";
            this.Seq_id.Name = "Seq_id";
            // 
            // IsExsit
            // 
            this.IsExsit.Caption = "是否已存在";
            this.IsExsit.FieldName = "isExsit";
            this.IsExsit.Name = "IsExsit";
            // 
            // frmTestItemSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(818, 497);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmTestItemSetting";
            this.Text = "測試項目設置";
            this.Load += new System.EventHandler(this.frmTestItemSetting_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MtxtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueItemType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTestType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItemDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueItemId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItemDetails;
        private DevExpress.XtraGrid.Columns.GridColumn Item_Id;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueItemId;
        private DevExpress.XtraGrid.Columns.GridColumn Item_cdesc;
        private DevExpress.XtraGrid.Columns.GridColumn Remark;
        private DevExpress.XtraEditors.LookUpEdit lueItemType;
        private DevExpress.XtraEditors.LabelControl lblItemType;
        private DevExpress.XtraEditors.LookUpEdit lueTestType;
        private DevExpress.XtraEditors.LabelControl lblType;
        private DevExpress.XtraEditors.SimpleButton btnAddItem;
        private DevExpress.XtraEditors.SimpleButton btnDelItem;
        private DevExpress.XtraEditors.MemoEdit MtxtRemark;
        private DevExpress.XtraEditors.LabelControl lblRemark;
        private DevExpress.XtraGrid.Columns.GridColumn IsExsit;
        private DevExpress.XtraEditors.LabelControl lblIsExsit;
        private DevExpress.XtraGrid.Columns.GridColumn Seq_id;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private DevExpress.XtraGrid.Columns.GridColumn Item_edesc;
    }
}