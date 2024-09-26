namespace cf01.Forms
{
    partial class frmQuotation_Set_Grant
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuotation_Set_Grant));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BTNFIND = new System.Windows.Forms.Button();
            this.dgvStep1 = new System.Windows.Forms.DataGridView();
            this.flag_select1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.user_id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usrer_name1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExit1 = new System.Windows.Forms.Button();
            this.btnNext1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clChk_brand = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnPrevious2 = new System.Windows.Forms.Button();
            this.btnExit2 = new System.Windows.Forms.Button();
            this.btnNext2 = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.flag_select_2_grp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clGroup_Select = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.group_id_2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.group_id_2_desc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.select_brand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clBrand_select = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.brand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnPrevious3 = new System.Windows.Forms.Button();
            this.btnExit3 = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.dgvStep3 = new System.Windows.Forms.DataGridView();
            this.user_id3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.group_id3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brand_id3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flag_old_record = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStep1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clChk_brand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clGroup_Select)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clBrand_select)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStep3)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(941, 694);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BTNFIND);
            this.tabPage1.Controls.Add(this.dgvStep1);
            this.tabPage1.Controls.Add(this.btnExit1);
            this.tabPage1.Controls.Add(this.btnNext1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(933, 668);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Step 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // BTNFIND
            // 
            this.BTNFIND.Image = ((System.Drawing.Image)(resources.GetObject("BTNFIND.Image")));
            this.BTNFIND.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTNFIND.Location = new System.Drawing.Point(113, 629);
            this.BTNFIND.Name = "BTNFIND";
            this.BTNFIND.Size = new System.Drawing.Size(129, 31);
            this.BTNFIND.TabIndex = 4;
            this.BTNFIND.Text = "已設置的權限(&F)";
            this.BTNFIND.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTNFIND.UseVisualStyleBackColor = true;
            this.BTNFIND.Click += new System.EventHandler(this.BTNFIND_Click);
            // 
            // dgvStep1
            // 
            this.dgvStep1.AllowUserToAddRows = false;
            this.dgvStep1.AllowUserToDeleteRows = false;
            this.dgvStep1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvStep1.ColumnHeadersHeight = 30;
            this.dgvStep1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.flag_select1,
            this.user_id1,
            this.usrer_name1,
            this.user_group});
            this.dgvStep1.Location = new System.Drawing.Point(6, 6);
            this.dgvStep1.Name = "dgvStep1";
            this.dgvStep1.RowTemplate.Height = 24;
            this.dgvStep1.Size = new System.Drawing.Size(921, 616);
            this.dgvStep1.TabIndex = 3;
            // 
            // flag_select1
            // 
            this.flag_select1.DataPropertyName = "flag_select";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.NullValue = false;
            this.flag_select1.DefaultCellStyle = dataGridViewCellStyle1;
            this.flag_select1.HeaderText = "選擇";
            this.flag_select1.Name = "flag_select1";
            this.flag_select1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.flag_select1.Width = 80;
            // 
            // user_id1
            // 
            this.user_id1.DataPropertyName = "user_id";
            this.user_id1.HeaderText = "用戶";
            this.user_id1.Name = "user_id1";
            this.user_id1.Width = 120;
            // 
            // usrer_name1
            // 
            this.usrer_name1.DataPropertyName = "usrer_name";
            this.usrer_name1.HeaderText = "用戶名稱";
            this.usrer_name1.Name = "usrer_name1";
            this.usrer_name1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.usrer_name1.Width = 150;
            // 
            // user_group
            // 
            this.user_group.DataPropertyName = "user_group";
            this.user_group.HeaderText = "角色組別";
            this.user_group.Name = "user_group";
            this.user_group.Width = 120;
            // 
            // btnExit1
            // 
            this.btnExit1.Image = ((System.Drawing.Image)(resources.GetObject("btnExit1.Image")));
            this.btnExit1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit1.Location = new System.Drawing.Point(588, 629);
            this.btnExit1.Name = "btnExit1";
            this.btnExit1.Size = new System.Drawing.Size(89, 31);
            this.btnExit1.TabIndex = 2;
            this.btnExit1.Text = "退 出(&X)";
            this.btnExit1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit1.UseVisualStyleBackColor = true;
            this.btnExit1.Click += new System.EventHandler(this.btnExit1_Click);
            // 
            // btnNext1
            // 
            this.btnNext1.Image = ((System.Drawing.Image)(resources.GetObject("btnNext1.Image")));
            this.btnNext1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext1.Location = new System.Drawing.Point(455, 629);
            this.btnNext1.Name = "btnNext1";
            this.btnNext1.Size = new System.Drawing.Size(89, 31);
            this.btnNext1.TabIndex = 1;
            this.btnNext1.Text = "下一步(&N)";
            this.btnNext1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext1.UseVisualStyleBackColor = true;
            this.btnNext1.Click += new System.EventHandler(this.btnNext1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gridControl2);
            this.tabPage2.Controls.Add(this.btnPrevious2);
            this.tabPage2.Controls.Add(this.btnExit2);
            this.tabPage2.Controls.Add(this.btnNext2);
            this.tabPage2.Controls.Add(this.gridControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(933, 668);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Step 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gridControl2
            // 
            this.gridControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl2.Location = new System.Drawing.Point(3, 269);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.clChk_brand});
            this.gridControl2.Size = new System.Drawing.Size(926, 357);
            this.gridControl2.TabIndex = 146;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.ColumnPanelRowHeight = 25;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn5});
            this.gridView2.CustomizationFormBounds = new System.Drawing.Rectangle(980, 449, 208, 203);
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.PaintStyleName = "Style3D";
            this.gridView2.RowHeight = 22;
            this.gridView2.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gridColumn1.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn1.Caption = "選擇";
            this.gridColumn1.ColumnEdit = this.clChk_brand;
            this.gridColumn1.FieldName = "flag_select";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.AllowSize = false;
            this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn1.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn1.OptionsFilter.AllowFilter = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 47;
            // 
            // clChk_brand
            // 
            this.clChk_brand.AutoHeight = false;
            this.clChk_brand.Name = "clChk_brand";
            this.clChk_brand.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.clChk_brand.Tag = "";
            this.clChk_brand.ValueGrayed = "";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "組別";
            this.gridColumn2.FieldName = "group_id";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.OptionsColumn.AllowSize = false;
            this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn2.OptionsFilter.AllowFilter = false;
            this.gridColumn2.Tag = "2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 44;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "牌子編號";
            this.gridColumn3.FieldName = "brand_id";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.OptionsColumn.AllowSize = false;
            this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn3.OptionsFilter.AllowFilter = false;
            this.gridColumn3.Tag = "2";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 89;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "牌子名稱";
            this.gridColumn5.FieldName = "brand_name";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowMove = false;
            this.gridColumn5.OptionsColumn.AllowSize = false;
            this.gridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn5.OptionsFilter.AllowFilter = false;
            this.gridColumn5.Tag = "2";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 252;
            // 
            // btnPrevious2
            // 
            this.btnPrevious2.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevious2.Image")));
            this.btnPrevious2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrevious2.Location = new System.Drawing.Point(284, 631);
            this.btnPrevious2.Name = "btnPrevious2";
            this.btnPrevious2.Size = new System.Drawing.Size(89, 31);
            this.btnPrevious2.TabIndex = 145;
            this.btnPrevious2.Text = "上一步(&B)";
            this.btnPrevious2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrevious2.UseVisualStyleBackColor = true;
            this.btnPrevious2.Click += new System.EventHandler(this.btnPrevious2_Click);
            // 
            // btnExit2
            // 
            this.btnExit2.Image = ((System.Drawing.Image)(resources.GetObject("btnExit2.Image")));
            this.btnExit2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit2.Location = new System.Drawing.Point(488, 631);
            this.btnExit2.Name = "btnExit2";
            this.btnExit2.Size = new System.Drawing.Size(89, 31);
            this.btnExit2.TabIndex = 144;
            this.btnExit2.Text = "退 出(&X)";
            this.btnExit2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit2.UseVisualStyleBackColor = true;
            this.btnExit2.Click += new System.EventHandler(this.btnExit2_Click);
            // 
            // btnNext2
            // 
            this.btnNext2.Image = ((System.Drawing.Image)(resources.GetObject("btnNext2.Image")));
            this.btnNext2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext2.Location = new System.Drawing.Point(387, 631);
            this.btnNext2.Name = "btnNext2";
            this.btnNext2.Size = new System.Drawing.Size(89, 31);
            this.btnNext2.TabIndex = 143;
            this.btnNext2.Text = "下一步(&N)";
            this.btnNext2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext2.UseVisualStyleBackColor = true;
            this.btnNext2.Click += new System.EventHandler(this.btnNext2_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 4);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.clBrand_select,
            this.clGroup_Select});
            this.gridControl1.Size = new System.Drawing.Size(926, 263);
            this.gridControl1.TabIndex = 141;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 25;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.flag_select_2_grp,
            this.group_id_2,
            this.group_id_2_desc,
            this.select_brand,
            this.brand});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(980, 449, 208, 203);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PaintStyleName = "Style3D";
            this.gridView1.RowHeight = 22;
            this.gridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // flag_select_2_grp
            // 
            this.flag_select_2_grp.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.flag_select_2_grp.AppearanceCell.Options.UseBackColor = true;
            this.flag_select_2_grp.Caption = "選擇";
            this.flag_select_2_grp.ColumnEdit = this.clGroup_Select;
            this.flag_select_2_grp.FieldName = "flag_select";
            this.flag_select_2_grp.Name = "flag_select_2_grp";
            this.flag_select_2_grp.OptionsColumn.AllowMove = false;
            this.flag_select_2_grp.OptionsColumn.AllowSize = false;
            this.flag_select_2_grp.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.flag_select_2_grp.OptionsFilter.AllowAutoFilter = false;
            this.flag_select_2_grp.OptionsFilter.AllowFilter = false;
            this.flag_select_2_grp.Visible = true;
            this.flag_select_2_grp.VisibleIndex = 0;
            this.flag_select_2_grp.Width = 47;
            // 
            // clGroup_Select
            // 
            this.clGroup_Select.AutoHeight = false;
            this.clGroup_Select.Name = "clGroup_Select";
            this.clGroup_Select.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.clGroup_Select.Tag = "";
            this.clGroup_Select.ValueGrayed = "";
            this.clGroup_Select.CheckedChanged += new System.EventHandler(this.clGroup_Select_CheckedChanged);
            // 
            // group_id_2
            // 
            this.group_id_2.AppearanceCell.Options.UseTextOptions = true;
            this.group_id_2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.group_id_2.Caption = "組別";
            this.group_id_2.FieldName = "group_id";
            this.group_id_2.Name = "group_id_2";
            this.group_id_2.OptionsColumn.AllowMove = false;
            this.group_id_2.OptionsColumn.AllowSize = false;
            this.group_id_2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.group_id_2.OptionsColumn.ReadOnly = true;
            this.group_id_2.OptionsFilter.AllowAutoFilter = false;
            this.group_id_2.OptionsFilter.AllowFilter = false;
            this.group_id_2.Tag = "2";
            this.group_id_2.Visible = true;
            this.group_id_2.VisibleIndex = 1;
            this.group_id_2.Width = 44;
            // 
            // group_id_2_desc
            // 
            this.group_id_2_desc.Caption = "組別名稱";
            this.group_id_2_desc.FieldName = "group_id_desc";
            this.group_id_2_desc.Name = "group_id_2_desc";
            this.group_id_2_desc.OptionsColumn.AllowEdit = false;
            this.group_id_2_desc.OptionsColumn.AllowMove = false;
            this.group_id_2_desc.OptionsColumn.AllowSize = false;
            this.group_id_2_desc.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.group_id_2_desc.OptionsColumn.ReadOnly = true;
            this.group_id_2_desc.OptionsFilter.AllowAutoFilter = false;
            this.group_id_2_desc.OptionsFilter.AllowFilter = false;
            this.group_id_2_desc.Tag = "2";
            this.group_id_2_desc.Visible = true;
            this.group_id_2_desc.VisibleIndex = 2;
            this.group_id_2_desc.Width = 88;
            // 
            // select_brand
            // 
            this.select_brand.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.select_brand.AppearanceCell.Options.UseBackColor = true;
            this.select_brand.Caption = "全部牌子";
            this.select_brand.ColumnEdit = this.clBrand_select;
            this.select_brand.FieldName = "flag_brand";
            this.select_brand.Name = "select_brand";
            this.select_brand.OptionsFilter.AllowAutoFilter = false;
            this.select_brand.OptionsFilter.AllowFilter = false;
            this.select_brand.Visible = true;
            this.select_brand.VisibleIndex = 3;
            this.select_brand.Width = 77;
            // 
            // clBrand_select
            // 
            this.clBrand_select.AutoHeight = false;
            this.clBrand_select.Name = "clBrand_select";
            this.clBrand_select.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.clBrand_select.Tag = "";
            this.clBrand_select.ValueGrayed = "";
            this.clBrand_select.CheckedChanged += new System.EventHandler(this.clBrand_select_CheckedChanged);
            this.clBrand_select.Click += new System.EventHandler(this.clBrand_select_Click);
            // 
            // brand
            // 
            this.brand.Caption = "牌子";
            this.brand.FieldName = "all_brand";
            this.brand.Name = "brand";
            this.brand.OptionsColumn.AllowMove = false;
            this.brand.OptionsColumn.AllowSize = false;
            this.brand.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.brand.OptionsColumn.ReadOnly = true;
            this.brand.OptionsFilter.AllowAutoFilter = false;
            this.brand.OptionsFilter.AllowFilter = false;
            this.brand.Tag = "2";
            this.brand.Visible = true;
            this.brand.VisibleIndex = 4;
            this.brand.Width = 171;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnDel);
            this.tabPage3.Controls.Add(this.btnPrevious3);
            this.tabPage3.Controls.Add(this.btnExit3);
            this.tabPage3.Controls.Add(this.btnFinish);
            this.tabPage3.Controls.Add(this.dgvStep3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(933, 668);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Step 3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnDel
            // 
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.Location = new System.Drawing.Point(395, 630);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(89, 32);
            this.btnDel.TabIndex = 149;
            this.btnDel.Text = "刪除(&L)";
            this.btnDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnPrevious3
            // 
            this.btnPrevious3.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevious3.Image")));
            this.btnPrevious3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrevious3.Location = new System.Drawing.Point(296, 630);
            this.btnPrevious3.Name = "btnPrevious3";
            this.btnPrevious3.Size = new System.Drawing.Size(89, 32);
            this.btnPrevious3.TabIndex = 148;
            this.btnPrevious3.Text = "上一步(&B)";
            this.btnPrevious3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrevious3.UseVisualStyleBackColor = true;
            this.btnPrevious3.Click += new System.EventHandler(this.btnPrevious3_Click);
            // 
            // btnExit3
            // 
            this.btnExit3.Image = ((System.Drawing.Image)(resources.GetObject("btnExit3.Image")));
            this.btnExit3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit3.Location = new System.Drawing.Point(594, 630);
            this.btnExit3.Name = "btnExit3";
            this.btnExit3.Size = new System.Drawing.Size(89, 32);
            this.btnExit3.TabIndex = 147;
            this.btnExit3.Text = "退 出(&X)";
            this.btnExit3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit3.UseVisualStyleBackColor = true;
            this.btnExit3.Click += new System.EventHandler(this.btnExit3_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Image = ((System.Drawing.Image)(resources.GetObject("btnFinish.Image")));
            this.btnFinish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinish.Location = new System.Drawing.Point(494, 630);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(89, 32);
            this.btnFinish.TabIndex = 146;
            this.btnFinish.Text = "完成(&F)";
            this.btnFinish.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // dgvStep3
            // 
            this.dgvStep3.AllowUserToAddRows = false;
            this.dgvStep3.AllowUserToDeleteRows = false;
            this.dgvStep3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvStep3.ColumnHeadersHeight = 30;
            this.dgvStep3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.user_id3,
            this.group_id3,
            this.brand_id3,
            this.flag_old_record});
            this.dgvStep3.Location = new System.Drawing.Point(6, 4);
            this.dgvStep3.Name = "dgvStep3";
            this.dgvStep3.ReadOnly = true;
            this.dgvStep3.RowTemplate.Height = 24;
            this.dgvStep3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStep3.Size = new System.Drawing.Size(923, 620);
            this.dgvStep3.TabIndex = 0;
            this.dgvStep3.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvStep3_RowPrePaint);
            // 
            // user_id3
            // 
            this.user_id3.DataPropertyName = "user_id";
            this.user_id3.HeaderText = "用戶";
            this.user_id3.Name = "user_id3";
            this.user_id3.ReadOnly = true;
            this.user_id3.Width = 150;
            // 
            // group_id3
            // 
            this.group_id3.DataPropertyName = "group_id";
            this.group_id3.HeaderText = "組別";
            this.group_id3.Name = "group_id3";
            this.group_id3.ReadOnly = true;
            this.group_id3.Width = 150;
            // 
            // brand_id3
            // 
            this.brand_id3.DataPropertyName = "brand_id";
            this.brand_id3.HeaderText = "牌子編號";
            this.brand_id3.Name = "brand_id3";
            this.brand_id3.ReadOnly = true;
            this.brand_id3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.brand_id3.Width = 200;
            // 
            // flag_old_record
            // 
            this.flag_old_record.DataPropertyName = "flag_old_record";
            this.flag_old_record.HeaderText = "狀態標識";
            this.flag_old_record.Name = "flag_old_record";
            this.flag_old_record.ReadOnly = true;
            this.flag_old_record.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 703);
            this.panel1.TabIndex = 1;
            // 
            // frmQuotation_Set_Grant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 707);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuotation_Set_Grant";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "報價單基礎資料組別權限設置";
            this.Load += new System.EventHandler(this.frmQuotation_Set_Grant_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStep1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clChk_brand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clGroup_Select)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clBrand_select)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStep3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNext1;
        private System.Windows.Forms.Button btnExit1;
        private System.Windows.Forms.DataGridView dgvStep1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn flag_select_2_grp;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit clGroup_Select;
        private DevExpress.XtraGrid.Columns.GridColumn group_id_2;
        private DevExpress.XtraGrid.Columns.GridColumn group_id_2_desc;
        private DevExpress.XtraGrid.Columns.GridColumn select_brand;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit clBrand_select;
        private DevExpress.XtraGrid.Columns.GridColumn brand;
        private System.Windows.Forms.Button btnPrevious2;
        private System.Windows.Forms.Button btnExit2;
        private System.Windows.Forms.Button btnNext2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnPrevious3;
        private System.Windows.Forms.Button btnExit3;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.DataGridView dgvStep3;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit clChk_brand;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn flag_select1;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn usrer_name1;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_group;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_id3;
        private System.Windows.Forms.DataGridViewTextBoxColumn group_id3;
        private System.Windows.Forms.DataGridViewTextBoxColumn brand_id3;
        private System.Windows.Forms.DataGridViewTextBoxColumn flag_old_record;
        private System.Windows.Forms.Button BTNFIND;
    }
}