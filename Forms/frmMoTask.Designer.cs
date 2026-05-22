namespace cf01.Forms
{
    partial class frmMoTask
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.datTask_date = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblGoods_Cname = new System.Windows.Forms.Label();
            this.lblMsgInfo = new System.Windows.Forms.Label();
            this.lblTask_date = new System.Windows.Forms.Label();
            this.lblNext_wp_id = new System.Windows.Forms.Label();
            this.lblWp_id = new System.Windows.Forms.Label();
            this.lblGoods_id = new System.Windows.Forms.Label();
            this.lblMoID = new System.Windows.Forms.Label();
            this.txtGoods_Cname = new System.Windows.Forms.TextBox();
            this.txtNext_wp_id = new System.Windows.Forms.TextBox();
            this.txtWp_id = new System.Windows.Forms.TextBox();
            this.txtGoods_id = new System.Windows.Forms.TextBox();
            this.txtMoID = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gcDetails = new DevExpress.XtraGrid.GridControl();
            this.gvDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gclmo_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Goods_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Goods_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Wp_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Prd_qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclc_qty_ok = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcf_complete_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtRemark);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.datTask_date);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.lblGoods_Cname);
            this.panel1.Controls.Add(this.lblMsgInfo);
            this.panel1.Controls.Add(this.lblRemark);
            this.panel1.Controls.Add(this.lblTask_date);
            this.panel1.Controls.Add(this.lblNext_wp_id);
            this.panel1.Controls.Add(this.lblWp_id);
            this.panel1.Controls.Add(this.lblGoods_id);
            this.panel1.Controls.Add(this.lblMoID);
            this.panel1.Controls.Add(this.txtGoods_Cname);
            this.panel1.Controls.Add(this.txtNext_wp_id);
            this.panel1.Controls.Add(this.txtWp_id);
            this.panel1.Controls.Add(this.txtGoods_id);
            this.panel1.Controls.Add(this.txtMoID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 226);
            this.panel1.TabIndex = 0;
            // 
            // datTask_date
            // 
            this.datTask_date.CustomFormat = "yyyy/MM/dd";
            this.datTask_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datTask_date.Location = new System.Drawing.Point(90, 134);
            this.datTask_date.Name = "datTask_date";
            this.datTask_date.Size = new System.Drawing.Size(162, 22);
            this.datTask_date.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(103, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "儲存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(22, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "退出(&X)";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblGoods_Cname
            // 
            this.lblGoods_Cname.AutoSize = true;
            this.lblGoods_Cname.Location = new System.Drawing.Point(279, 82);
            this.lblGoods_Cname.Name = "lblGoods_Cname";
            this.lblGoods_Cname.Size = new System.Drawing.Size(56, 12);
            this.lblGoods_Cname.TabIndex = 1;
            this.lblGoods_Cname.Text = "貨品描述:";
            // 
            // lblMsgInfo
            // 
            this.lblMsgInfo.AutoSize = true;
            this.lblMsgInfo.Location = new System.Drawing.Point(279, 141);
            this.lblMsgInfo.Name = "lblMsgInfo";
            this.lblMsgInfo.Size = new System.Drawing.Size(133, 12);
            this.lblMsgInfo.TabIndex = 1;
            this.lblMsgInfo.Text = "(在此日期未完成通知我)";
            // 
            // lblTask_date
            // 
            this.lblTask_date.AutoSize = true;
            this.lblTask_date.Location = new System.Drawing.Point(26, 141);
            this.lblTask_date.Name = "lblTask_date";
            this.lblTask_date.Size = new System.Drawing.Size(56, 12);
            this.lblTask_date.TabIndex = 1;
            this.lblTask_date.Text = "提醒日期:";
            // 
            // lblNext_wp_id
            // 
            this.lblNext_wp_id.AutoSize = true;
            this.lblNext_wp_id.Location = new System.Drawing.Point(277, 110);
            this.lblNext_wp_id.Name = "lblNext_wp_id";
            this.lblNext_wp_id.Size = new System.Drawing.Size(56, 12);
            this.lblNext_wp_id.TabIndex = 1;
            this.lblNext_wp_id.Text = "收貨部門:";
            // 
            // lblWp_id
            // 
            this.lblWp_id.AutoSize = true;
            this.lblWp_id.Location = new System.Drawing.Point(26, 110);
            this.lblWp_id.Name = "lblWp_id";
            this.lblWp_id.Size = new System.Drawing.Size(56, 12);
            this.lblWp_id.TabIndex = 1;
            this.lblWp_id.Text = "負責部門:";
            // 
            // lblGoods_id
            // 
            this.lblGoods_id.AutoSize = true;
            this.lblGoods_id.Location = new System.Drawing.Point(26, 82);
            this.lblGoods_id.Name = "lblGoods_id";
            this.lblGoods_id.Size = new System.Drawing.Size(56, 12);
            this.lblGoods_id.TabIndex = 1;
            this.lblGoods_id.Text = "貨品編號:";
            // 
            // lblMoID
            // 
            this.lblMoID.AutoSize = true;
            this.lblMoID.Location = new System.Drawing.Point(26, 54);
            this.lblMoID.Name = "lblMoID";
            this.lblMoID.Size = new System.Drawing.Size(56, 12);
            this.lblMoID.TabIndex = 1;
            this.lblMoID.Text = "制單編號:";
            // 
            // txtGoods_Cname
            // 
            this.txtGoods_Cname.Location = new System.Drawing.Point(341, 76);
            this.txtGoods_Cname.Name = "txtGoods_Cname";
            this.txtGoods_Cname.ReadOnly = true;
            this.txtGoods_Cname.Size = new System.Drawing.Size(294, 22);
            this.txtGoods_Cname.TabIndex = 0;
            // 
            // txtNext_wp_id
            // 
            this.txtNext_wp_id.Location = new System.Drawing.Point(341, 104);
            this.txtNext_wp_id.Name = "txtNext_wp_id";
            this.txtNext_wp_id.ReadOnly = true;
            this.txtNext_wp_id.Size = new System.Drawing.Size(162, 22);
            this.txtNext_wp_id.TabIndex = 0;
            // 
            // txtWp_id
            // 
            this.txtWp_id.Location = new System.Drawing.Point(90, 104);
            this.txtWp_id.Name = "txtWp_id";
            this.txtWp_id.ReadOnly = true;
            this.txtWp_id.Size = new System.Drawing.Size(162, 22);
            this.txtWp_id.TabIndex = 0;
            // 
            // txtGoods_id
            // 
            this.txtGoods_id.Location = new System.Drawing.Point(90, 76);
            this.txtGoods_id.Name = "txtGoods_id";
            this.txtGoods_id.ReadOnly = true;
            this.txtGoods_id.Size = new System.Drawing.Size(162, 22);
            this.txtGoods_id.TabIndex = 0;
            // 
            // txtMoID
            // 
            this.txtMoID.Location = new System.Drawing.Point(90, 48);
            this.txtMoID.Name = "txtMoID";
            this.txtMoID.Size = new System.Drawing.Size(162, 22);
            this.txtMoID.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 226);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1100, 32);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "提醒的制單列表：";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gcDetails);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 258);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1100, 337);
            this.panel3.TabIndex = 2;
            // 
            // gcDetails
            // 
            this.gcDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gcDetails.Location = new System.Drawing.Point(0, 0);
            this.gcDetails.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gcDetails.MainView = this.gvDetails;
            this.gcDetails.Name = "gcDetails";
            this.gcDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gvCheck,
            this.repositoryItemButtonEdit1});
            this.gcDetails.Size = new System.Drawing.Size(1100, 337);
            this.gcDetails.TabIndex = 27;
            this.gcDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetails});
            // 
            // gvDetails
            // 
            this.gvDetails.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gvDetails.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.White;
            this.gvDetails.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvDetails.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gvDetails.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvDetails.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvDetails.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gvDetails.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvDetails.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gvDetails.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvDetails.Appearance.Row.Options.UseFont = true;
            this.gvDetails.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvDetails.Appearance.ViewCaption.Options.UseFont = true;
            this.gvDetails.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.gvDetails.Appearance.ViewCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gvDetails.AppearancePrint.Row.Options.UseTextOptions = true;
            this.gvDetails.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gvDetails.AppearancePrint.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gvDetails.ColumnPanelRowHeight = 30;
            this.gvDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gclmo_id,
            this.gridColumn1,
            this.Goods_id,
            this.Goods_name,
            this.Wp_id,
            this.gridColumn2,
            this.Prd_qty,
            this.gclc_qty_ok,
            this.gcf_complete_date,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gvDetails.FooterPanelHeight = 50;
            this.gvDetails.GridControl = this.gcDetails;
            this.gvDetails.Name = "gvDetails";
            this.gvDetails.OptionsBehavior.ReadOnly = true;
            this.gvDetails.OptionsSelection.MultiSelect = true;
            this.gvDetails.OptionsView.AllowHtmlDrawHeaders = true;
            this.gvDetails.OptionsView.ColumnAutoWidth = false;
            this.gvDetails.OptionsView.ShowGroupPanel = false;
            this.gvDetails.PaintStyleName = "Skin";
            this.gvDetails.RowHeight = 25;
            this.gvDetails.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gvDetails_SelectionChanged);
            // 
            // gclmo_id
            // 
            this.gclmo_id.Caption = "制單編號";
            this.gclmo_id.FieldName = "mo_id";
            this.gclmo_id.MaxWidth = 100;
            this.gclmo_id.Name = "gclmo_id";
            this.gclmo_id.OptionsColumn.AllowEdit = false;
            this.gclmo_id.OptionsColumn.ReadOnly = true;
            this.gclmo_id.Visible = true;
            this.gclmo_id.VisibleIndex = 0;
            this.gclmo_id.Width = 100;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "提醒日期";
            this.gridColumn1.FieldName = "task_date";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 100;
            // 
            // Goods_id
            // 
            this.Goods_id.Caption = "貨品編號";
            this.Goods_id.FieldName = "goods_id";
            this.Goods_id.Name = "Goods_id";
            this.Goods_id.OptionsColumn.AllowEdit = false;
            this.Goods_id.OptionsColumn.ReadOnly = true;
            this.Goods_id.Visible = true;
            this.Goods_id.VisibleIndex = 2;
            this.Goods_id.Width = 180;
            // 
            // Goods_name
            // 
            this.Goods_name.AppearanceCell.Options.UseTextOptions = true;
            this.Goods_name.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.Goods_name.Caption = "貨品名稱";
            this.Goods_name.FieldName = "goods_cname";
            this.Goods_name.Name = "Goods_name";
            this.Goods_name.OptionsColumn.AllowEdit = false;
            this.Goods_name.OptionsColumn.ReadOnly = true;
            this.Goods_name.Visible = true;
            this.Goods_name.VisibleIndex = 3;
            this.Goods_name.Width = 272;
            // 
            // Wp_id
            // 
            this.Wp_id.Caption = "負責部門";
            this.Wp_id.FieldName = "wp_id";
            this.Wp_id.Name = "Wp_id";
            this.Wp_id.OptionsColumn.AllowEdit = false;
            this.Wp_id.OptionsColumn.ReadOnly = true;
            this.Wp_id.Visible = true;
            this.Wp_id.VisibleIndex = 4;
            this.Wp_id.Width = 66;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "收貨部門";
            this.gridColumn2.FieldName = "next_wp_id";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 5;
            // 
            // Prd_qty
            // 
            this.Prd_qty.Caption = "計劃數量";
            this.Prd_qty.DisplayFormat.FormatString = "#,##0";
            this.Prd_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Prd_qty.FieldName = "prod_qty";
            this.Prd_qty.Name = "Prd_qty";
            this.Prd_qty.OptionsColumn.AllowEdit = false;
            this.Prd_qty.OptionsColumn.ReadOnly = true;
            this.Prd_qty.Visible = true;
            this.Prd_qty.VisibleIndex = 6;
            this.Prd_qty.Width = 69;
            // 
            // gclc_qty_ok
            // 
            this.gclc_qty_ok.Caption = "已完成數量";
            this.gclc_qty_ok.DisplayFormat.FormatString = "#,##0";
            this.gclc_qty_ok.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gclc_qty_ok.FieldName = "c_qty_ok";
            this.gclc_qty_ok.Name = "gclc_qty_ok";
            this.gclc_qty_ok.Visible = true;
            this.gclc_qty_ok.VisibleIndex = 7;
            this.gclc_qty_ok.Width = 85;
            // 
            // gcf_complete_date
            // 
            this.gcf_complete_date.Caption = "完成日期";
            this.gcf_complete_date.FieldName = "f_complete_date";
            this.gcf_complete_date.Name = "gcf_complete_date";
            this.gcf_complete_date.Visible = true;
            this.gcf_complete_date.VisibleIndex = 8;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "建立時間";
            this.gridColumn3.FieldName = "create_time";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 9;
            // 
            // gvCheck
            // 
            this.gvCheck.AutoHeight = false;
            this.gvCheck.Name = "gvCheck";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(184, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "取消(&D)";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(265, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 30);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "刷新(&F)";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "序號";
            this.gridColumn4.FieldName = "id";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "備註";
            this.gridColumn5.FieldName = "remark";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 10;
            this.gridColumn5.Width = 200;
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(50, 166);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(32, 12);
            this.lblRemark.TabIndex = 1;
            this.lblRemark.Text = "備註:";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(88, 166);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(547, 46);
            this.txtRemark.TabIndex = 7;
            this.txtRemark.Text = "";
            // 
            // frmMoTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 595);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmMoTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmMoTask";
            this.Load += new System.EventHandler(this.frmMoTask_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblMoID;
        private System.Windows.Forms.TextBox txtMoID;
        private System.Windows.Forms.Label lblGoods_Cname;
        private System.Windows.Forms.Label lblGoods_id;
        private System.Windows.Forms.TextBox txtGoods_Cname;
        private System.Windows.Forms.TextBox txtGoods_id;
        private System.Windows.Forms.Label lblWp_id;
        private System.Windows.Forms.TextBox txtWp_id;
        private System.Windows.Forms.Label lblTask_date;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DateTimePicker datTask_date;
        private System.Windows.Forms.Label lblNext_wp_id;
        private System.Windows.Forms.TextBox txtNext_wp_id;
        private System.Windows.Forms.Label lblMsgInfo;
        private DevExpress.XtraGrid.GridControl gcDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetails;
        private DevExpress.XtraGrid.Columns.GridColumn gclmo_id;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn Goods_id;
        private DevExpress.XtraGrid.Columns.GridColumn Goods_name;
        private DevExpress.XtraGrid.Columns.GridColumn Wp_id;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn Prd_qty;
        private DevExpress.XtraGrid.Columns.GridColumn gclc_qty_ok;
        private DevExpress.XtraGrid.Columns.GridColumn gcf_complete_date;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit gvCheck;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.RichTextBox txtRemark;
    }
}