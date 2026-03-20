namespace cf01.Forms
{
    partial class frmStockadiFind
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
            System.Windows.Forms.Button btnSearch;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockadiFind));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.Button btnOk;
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtId1 = new System.Windows.Forms.TextBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtCreateBy = new System.Windows.Forms.TextBox();
            this.dtCreateDate1 = new DevExpress.XtraEditors.DateEdit();
            this.dtCreateDate2 = new DevExpress.XtraEditors.DateEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSales_group = new DevExpress.XtraEditors.LabelControl();
            this.BTNSAVESET1 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtId2 = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.dteIssuesDate1 = new DevExpress.XtraEditors.DateEdit();
            this.dteIssuesDate2 = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.issues_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.group_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.create_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.create_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            btnSearch = new System.Windows.Forms.Button();
            btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreateDate1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreateDate1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreateDate2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreateDate2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteIssuesDate1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteIssuesDate1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteIssuesDate2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteIssuesDate2.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            btnSearch.Image = global::cf01.Properties.Resources.find;
            btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnSearch.Location = new System.Drawing.Point(387, 52);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(96, 34);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "  查  詢";
            btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(20, 46);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(72, 14);
            this.labelControl5.TabIndex = 222;
            this.labelControl5.Text = "內部提倉單號";
            // 
            // txtId1
            // 
            this.txtId1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtId1.Location = new System.Drawing.Point(95, 43);
            this.txtId1.MaxLength = 13;
            this.txtId1.Name = "txtId1";
            this.txtId1.Size = new System.Drawing.Size(130, 22);
            this.txtId1.TabIndex = 2;
            this.txtId1.Leave += new System.EventHandler(this.txtId1_Leave);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(200, 75);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 220;
            this.labelControl4.Text = "建檔人";
            // 
            // txtCreateBy
            // 
            this.txtCreateBy.Location = new System.Drawing.Point(242, 74);
            this.txtCreateBy.MaxLength = 20;
            this.txtCreateBy.Name = "txtCreateBy";
            this.txtCreateBy.Size = new System.Drawing.Size(130, 22);
            this.txtCreateBy.TabIndex = 5;
            // 
            // dtCreateDate1
            // 
            this.dtCreateDate1.EditValue = "";
            this.dtCreateDate1.EnterMoveNextControl = true;
            this.dtCreateDate1.Location = new System.Drawing.Point(95, 105);
            this.dtCreateDate1.Name = "dtCreateDate1";
            this.dtCreateDate1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.dtCreateDate1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtCreateDate1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtCreateDate1.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dtCreateDate1.Properties.Mask.BeepOnError = true;
            this.dtCreateDate1.Properties.Mask.EditMask = "G";
            this.dtCreateDate1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtCreateDate1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtCreateDate1.Size = new System.Drawing.Size(130, 22);
            this.dtCreateDate1.TabIndex = 6;
            this.dtCreateDate1.Tag = "2";
            this.dtCreateDate1.Leave += new System.EventHandler(this.dtCreateDate1_Leave);
            // 
            // dtCreateDate2
            // 
            this.dtCreateDate2.EditValue = "";
            this.dtCreateDate2.EnterMoveNextControl = true;
            this.dtCreateDate2.Location = new System.Drawing.Point(242, 105);
            this.dtCreateDate2.Name = "dtCreateDate2";
            this.dtCreateDate2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.dtCreateDate2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtCreateDate2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtCreateDate2.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dtCreateDate2.Properties.Mask.BeepOnError = true;
            this.dtCreateDate2.Properties.Mask.EditMask = "G";
            this.dtCreateDate2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtCreateDate2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtCreateDate2.Size = new System.Drawing.Size(130, 22);
            this.dtCreateDate2.TabIndex = 7;
            this.dtCreateDate2.Tag = "2";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(12, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 14);
            this.label3.TabIndex = 217;
            this.label3.Text = "建檔日期";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label4.Location = new System.Drawing.Point(226, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 14);
            this.label4.TabIndex = 218;
            this.label4.Text = "~";
            // 
            // lblSales_group
            // 
            this.lblSales_group.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSales_group.Location = new System.Drawing.Point(68, 76);
            this.lblSales_group.Name = "lblSales_group";
            this.lblSales_group.Size = new System.Drawing.Size(24, 14);
            this.lblSales_group.TabIndex = 213;
            this.lblSales_group.Text = "組別";
            // 
            // BTNSAVESET1
            // 
            this.BTNSAVESET1.Image = ((System.Drawing.Image)(resources.GetObject("BTNSAVESET1.Image")));
            this.BTNSAVESET1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTNSAVESET1.Location = new System.Drawing.Point(709, 52);
            this.BTNSAVESET1.Name = "BTNSAVESET1";
            this.BTNSAVESET1.Size = new System.Drawing.Size(116, 34);
            this.BTNSAVESET1.TabIndex = 10;
            this.BTNSAVESET1.Text = "保存查找條件";
            this.BTNSAVESET1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTNSAVESET1.UseVisualStyleBackColor = false;
            this.BTNSAVESET1.Click += new System.EventHandler(this.BTNSAVESET1_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::cf01.Properties.Resources.exit;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(610, 52);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 34);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "  退 出";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtId2
            // 
            this.txtId2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtId2.Location = new System.Drawing.Point(242, 43);
            this.txtId2.MaxLength = 13;
            this.txtId2.Name = "txtId2";
            this.txtId2.Size = new System.Drawing.Size(130, 22);
            this.txtId2.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(228, 46);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(9, 14);
            this.labelControl1.TabIndex = 226;
            this.labelControl1.Text = "~";
            // 
            // txtGroup
            // 
            this.txtGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGroup.Location = new System.Drawing.Point(95, 74);
            this.txtGroup.MaxLength = 1;
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(79, 22);
            this.txtGroup.TabIndex = 4;
            // 
            // dteIssuesDate1
            // 
            this.dteIssuesDate1.EditValue = "";
            this.dteIssuesDate1.EnterMoveNextControl = true;
            this.dteIssuesDate1.Location = new System.Drawing.Point(95, 13);
            this.dteIssuesDate1.Name = "dteIssuesDate1";
            this.dteIssuesDate1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.dteIssuesDate1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteIssuesDate1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dteIssuesDate1.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dteIssuesDate1.Properties.Mask.BeepOnError = true;
            this.dteIssuesDate1.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dteIssuesDate1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dteIssuesDate1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dteIssuesDate1.Size = new System.Drawing.Size(130, 22);
            this.dteIssuesDate1.TabIndex = 0;
            this.dteIssuesDate1.Tag = "2";
            this.dteIssuesDate1.Leave += new System.EventHandler(this.dteIssuesDate1_Leave);
            // 
            // dteIssuesDate2
            // 
            this.dteIssuesDate2.EditValue = "";
            this.dteIssuesDate2.EnterMoveNextControl = true;
            this.dteIssuesDate2.Location = new System.Drawing.Point(242, 13);
            this.dteIssuesDate2.Name = "dteIssuesDate2";
            this.dteIssuesDate2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.dteIssuesDate2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteIssuesDate2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dteIssuesDate2.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dteIssuesDate2.Properties.Mask.BeepOnError = true;
            this.dteIssuesDate2.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.dteIssuesDate2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dteIssuesDate2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dteIssuesDate2.Size = new System.Drawing.Size(130, 22);
            this.dteIssuesDate2.TabIndex = 1;
            this.dteIssuesDate2.Tag = "2";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 14);
            this.label1.TabIndex = 230;
            this.label1.Text = "入單日期";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label2.Location = new System.Drawing.Point(226, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 14);
            this.label2.TabIndex = 231;
            this.label2.Text = "~";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(btnOk);
            this.panel1.Controls.Add(this.dteIssuesDate1);
            this.panel1.Controls.Add(btnSearch);
            this.panel1.Controls.Add(this.dteIssuesDate2);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblSales_group);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.BTNSAVESET1);
            this.panel1.Controls.Add(this.txtGroup);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtId2);
            this.panel1.Controls.Add(this.dtCreateDate2);
            this.panel1.Controls.Add(this.labelControl5);
            this.panel1.Controls.Add(this.dtCreateDate1);
            this.panel1.Controls.Add(this.txtId1);
            this.panel1.Controls.Add(this.txtCreateBy);
            this.panel1.Controls.Add(this.labelControl4);
            this.panel1.Location = new System.Drawing.Point(8, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(833, 137);
            this.panel1.TabIndex = 232;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.issues_date,
            this.group_number,
            this.create_by,
            this.create_date});
            this.dataGridView1.Location = new System.Drawing.Point(8, 155);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(833, 307);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "內部提倉單號";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id.Width = 120;
            // 
            // issues_date
            // 
            this.issues_date.DataPropertyName = "issues_date";
            dataGridViewCellStyle25.Format = "d";
            dataGridViewCellStyle25.NullValue = null;
            this.issues_date.DefaultCellStyle = dataGridViewCellStyle25;
            this.issues_date.HeaderText = "入單日期";
            this.issues_date.Name = "issues_date";
            this.issues_date.ReadOnly = true;
            this.issues_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.issues_date.Width = 90;
            // 
            // group_number
            // 
            this.group_number.DataPropertyName = "group_number";
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.group_number.DefaultCellStyle = dataGridViewCellStyle26;
            this.group_number.HeaderText = "組別";
            this.group_number.Name = "group_number";
            this.group_number.ReadOnly = true;
            this.group_number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.group_number.Width = 80;
            // 
            // create_by
            // 
            this.create_by.DataPropertyName = "create_by";
            this.create_by.HeaderText = "建檔人";
            this.create_by.Name = "create_by";
            this.create_by.ReadOnly = true;
            this.create_by.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // create_date
            // 
            this.create_date.DataPropertyName = "create_date";
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.Format = "g";
            dataGridViewCellStyle27.NullValue = null;
            this.create_date.DefaultCellStyle = dataGridViewCellStyle27;
            this.create_date.HeaderText = "建檔日期";
            this.create_date.Name = "create_date";
            this.create_date.ReadOnly = true;
            this.create_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.create_date.Width = 160;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "內部提倉單號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "issues_date";
            dataGridViewCellStyle28.Format = "d";
            dataGridViewCellStyle28.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle28;
            this.dataGridViewTextBoxColumn2.HeaderText = "入單日期";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 90;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "group_number";
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle29;
            this.dataGridViewTextBoxColumn3.HeaderText = "組別";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "create_by";
            this.dataGridViewTextBoxColumn4.HeaderText = "建檔人";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "create_date";
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle30.Format = "g";
            dataGridViewCellStyle30.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle30;
            this.dataGridViewTextBoxColumn5.HeaderText = "建檔日期";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 160;
            // 
            // btnOk
            // 
            btnOk.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnOk.Location = new System.Drawing.Point(498, 52);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(96, 34);
            btnOk.TabIndex = 232;
            btnOk.Text = " 確 定";
            btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmStockadiFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 474);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStockadiFind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "導入內部提倉單";
            this.Load += new System.EventHandler(this.frmStockadiFind_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtCreateDate1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreateDate1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreateDate2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreateDate2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteIssuesDate1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteIssuesDate1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteIssuesDate2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteIssuesDate2.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.TextBox txtId1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.TextBox txtCreateBy;
        private DevExpress.XtraEditors.DateEdit dtCreateDate1;
        private DevExpress.XtraEditors.DateEdit dtCreateDate2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BTNSAVESET1;
        private DevExpress.XtraEditors.LabelControl lblSales_group;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtId2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox txtGroup;
        private DevExpress.XtraEditors.DateEdit dteIssuesDate1;
        private DevExpress.XtraEditors.DateEdit dteIssuesDate2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn issues_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn group_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn create_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn create_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}