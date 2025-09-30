namespace cf01.Forms
{
    partial class frmMoComplete
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMoComplete));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.t_update_date = new System.Windows.Forms.Label();
            this.t_update_by = new System.Windows.Forms.Label();
            this.t_create_date = new System.Windows.Forms.Label();
            this.t_create_by = new System.Windows.Forms.Label();
            this.lblid = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtupdate_date = new DevExpress.XtraEditors.TextEdit();
            this.txtupdate_by = new DevExpress.XtraEditors.TextEdit();
            this.txtcreate_date = new DevExpress.XtraEditors.TextEdit();
            this.txtcreate_by = new DevExpress.XtraEditors.TextEdit();
            this.luestate = new DevExpress.XtraEditors.LookUpEdit();
            this.t_state = new System.Windows.Forms.Label();
            this.txtmo_id = new DevExpress.XtraEditors.TextEdit();
            this.txtremark = new DevExpress.XtraEditors.TextEdit();
            this.lblremark = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.bds1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mo_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.create_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.create_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtupdate_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtupdate_by.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreate_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreate_by.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luestate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmo_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtremark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.toolStripSeparator1,
            this.btnNew,
            this.toolStripSeparator4,
            this.btnEdit,
            this.toolStripSeparator2,
            this.btnDelete,
            this.toolStripSeparator3,
            this.btnSave,
            this.toolStripSeparator6,
            this.btnUndo,
            this.toolStripSeparator5,
            this.btnFind});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(951, 38);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 38);
            // 
            // btnFind
            // 
            this.btnFind.Enabled = false;
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(51, 35);
            this.btnFind.Text = "查找(&F)";
            this.btnFind.Visible = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // t_update_date
            // 
            this.t_update_date.Location = new System.Drawing.Point(656, 63);
            this.t_update_date.Name = "t_update_date";
            this.t_update_date.Size = new System.Drawing.Size(60, 16);
            this.t_update_date.TabIndex = 48;
            this.t_update_date.Tag = "t_update_date";
            this.t_update_date.Text = "修改日期";
            this.t_update_date.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_update_by
            // 
            this.t_update_by.Location = new System.Drawing.Point(449, 63);
            this.t_update_by.Name = "t_update_by";
            this.t_update_by.Size = new System.Drawing.Size(77, 16);
            this.t_update_by.TabIndex = 46;
            this.t_update_by.Tag = "t_update_by";
            this.t_update_by.Text = "修改人";
            this.t_update_by.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_create_date
            // 
            this.t_create_date.Location = new System.Drawing.Point(219, 63);
            this.t_create_date.Name = "t_create_date";
            this.t_create_date.Size = new System.Drawing.Size(65, 16);
            this.t_create_date.TabIndex = 44;
            this.t_create_date.Tag = "t_create_date";
            this.t_create_date.Text = "建档日期";
            this.t_create_date.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_create_by
            // 
            this.t_create_by.Location = new System.Drawing.Point(12, 63);
            this.t_create_by.Name = "t_create_by";
            this.t_create_by.Size = new System.Drawing.Size(78, 16);
            this.t_create_by.TabIndex = 42;
            this.t_create_by.Tag = "t_create_by";
            this.t_create_by.Text = "建档人";
            this.t_create_by.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblid
            // 
            this.lblid.ForeColor = System.Drawing.Color.Blue;
            this.lblid.Location = new System.Drawing.Point(5, 9);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(85, 16);
            this.lblid.TabIndex = 34;
            this.lblid.Tag = "t_id";
            this.lblid.Text = "制單編號";
            this.lblid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mo_id,
            this.remark,
            this.create_by,
            this.create_date,
            this.update_by,
            this.update_date,
            this.state});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetails.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetails.Location = new System.Drawing.Point(2, 168);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.ShowCellToolTips = false;
            this.dgvDetails.Size = new System.Drawing.Size(948, 441);
            this.dgvDetails.TabIndex = 50;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtupdate_date);
            this.panel1.Controls.Add(this.txtupdate_by);
            this.panel1.Controls.Add(this.txtcreate_date);
            this.panel1.Controls.Add(this.txtcreate_by);
            this.panel1.Controls.Add(this.luestate);
            this.panel1.Controls.Add(this.t_state);
            this.panel1.Controls.Add(this.txtmo_id);
            this.panel1.Controls.Add(this.txtremark);
            this.panel1.Controls.Add(this.lblid);
            this.panel1.Controls.Add(this.t_update_date);
            this.panel1.Controls.Add(this.lblremark);
            this.panel1.Controls.Add(this.t_update_by);
            this.panel1.Controls.Add(this.t_create_by);
            this.panel1.Controls.Add(this.t_create_date);
            this.panel1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.panel1.Location = new System.Drawing.Point(3, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(947, 125);
            this.panel1.TabIndex = 53;
            // 
            // txtupdate_date
            // 
            this.txtupdate_date.Enabled = false;
            this.txtupdate_date.Location = new System.Drawing.Point(720, 61);
            this.txtupdate_date.Name = "txtupdate_date";
            this.txtupdate_date.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtupdate_date.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtupdate_date.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtupdate_date.Properties.ReadOnly = true;
            this.txtupdate_date.Size = new System.Drawing.Size(160, 22);
            this.txtupdate_date.TabIndex = 6;
            this.txtupdate_date.Tag = "2";
            // 
            // txtupdate_by
            // 
            this.txtupdate_by.Enabled = false;
            this.txtupdate_by.Location = new System.Drawing.Point(528, 61);
            this.txtupdate_by.Name = "txtupdate_by";
            this.txtupdate_by.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtupdate_by.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtupdate_by.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtupdate_by.Properties.ReadOnly = true;
            this.txtupdate_by.Size = new System.Drawing.Size(124, 22);
            this.txtupdate_by.TabIndex = 5;
            this.txtupdate_by.Tag = "2";
            // 
            // txtcreate_date
            // 
            this.txtcreate_date.Enabled = false;
            this.txtcreate_date.Location = new System.Drawing.Point(287, 61);
            this.txtcreate_date.Name = "txtcreate_date";
            this.txtcreate_date.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtcreate_date.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtcreate_date.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtcreate_date.Properties.ReadOnly = true;
            this.txtcreate_date.Size = new System.Drawing.Size(160, 22);
            this.txtcreate_date.TabIndex = 4;
            this.txtcreate_date.Tag = "2";
            // 
            // txtcreate_by
            // 
            this.txtcreate_by.Enabled = false;
            this.txtcreate_by.Location = new System.Drawing.Point(92, 61);
            this.txtcreate_by.Name = "txtcreate_by";
            this.txtcreate_by.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtcreate_by.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtcreate_by.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtcreate_by.Properties.ReadOnly = true;
            this.txtcreate_by.Size = new System.Drawing.Size(124, 22);
            this.txtcreate_by.TabIndex = 3;
            this.txtcreate_by.Tag = "2";
            // 
            // luestate
            // 
            this.luestate.EditValue = "";
            this.luestate.Enabled = false;
            this.luestate.Location = new System.Drawing.Point(720, 7);
            this.luestate.Name = "luestate";
            this.luestate.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.luestate.Properties.Appearance.Options.UseBackColor = true;
            this.luestate.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.luestate.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.luestate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.luestate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luestate.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", 30, "id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", 100, "name")});
            this.luestate.Properties.ImmediatePopup = true;
            this.luestate.Properties.NullText = "";
            this.luestate.Properties.PopupWidth = 130;
            this.luestate.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.luestate.Properties.ShowHeader = false;
            this.luestate.Properties.Tag = "2";
            this.luestate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.luestate.Size = new System.Drawing.Size(160, 22);
            this.luestate.TabIndex = 2;
            this.luestate.Tag = "2";
            this.luestate.EditValueChanged += new System.EventHandler(this.luestate_EditValueChanged);
            // 
            // t_state
            // 
            this.t_state.Location = new System.Drawing.Point(639, 9);
            this.t_state.Name = "t_state";
            this.t_state.Size = new System.Drawing.Size(77, 16);
            this.t_state.TabIndex = 188;
            this.t_state.Tag = "t_state";
            this.t_state.Text = "狀態";
            this.t_state.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtmo_id
            // 
            this.txtmo_id.EnterMoveNextControl = true;
            this.txtmo_id.Location = new System.Drawing.Point(92, 7);
            this.txtmo_id.Name = "txtmo_id";
            this.txtmo_id.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtmo_id.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtmo_id.Properties.MaxLength = 9;
            this.txtmo_id.Properties.ReadOnly = true;
            this.txtmo_id.Size = new System.Drawing.Size(124, 22);
            this.txtmo_id.TabIndex = 0;
            this.txtmo_id.Tag = "2";
            this.txtmo_id.Leave += new System.EventHandler(this.txtmo_id_Leave);
            // 
            // txtremark
            // 
            this.txtremark.EditValue = "";
            this.txtremark.EnterMoveNextControl = true;
            this.txtremark.Location = new System.Drawing.Point(92, 34);
            this.txtremark.Name = "txtremark";
            this.txtremark.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtremark.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtremark.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtremark.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtremark.Properties.MaxLength = 250;
            this.txtremark.Properties.ReadOnly = true;
            this.txtremark.Size = new System.Drawing.Size(788, 22);
            this.txtremark.TabIndex = 1;
            this.txtremark.Tag = "2";
            // 
            // lblremark
            // 
            this.lblremark.Location = new System.Drawing.Point(5, 35);
            this.lblremark.Name = "lblremark";
            this.lblremark.Size = new System.Drawing.Size(85, 16);
            this.lblremark.TabIndex = 40;
            this.lblremark.Tag = "t_remark";
            this.lblremark.Text = "備註";
            this.lblremark.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnExit
            // 
            this.btnExit.AutoSize = false;
            this.btnExit.Image = global::cf01.Properties.Resources.exit;
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(71, 35);
            this.btnExit.Text = "退 出 (&X)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(77, 35);
            this.btnNew.Text = " 新 增(&N)";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(76, 35);
            this.btnEdit.Text = " 修 改(&E)";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(69, 35);
            this.btnDelete.Text = "刪除(&D)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 35);
            this.btnSave.Text = " 保  存(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Enabled = false;
            this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(73, 35);
            this.btnUndo.Text = "恢 復(&U)";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "制單編號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.ToolTipText = "t_id";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "remark";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn2.HeaderText = "備註";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.ToolTipText = "t_remark";
            this.dataGridViewTextBoxColumn2.Width = 250;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "create_by";
            this.dataGridViewTextBoxColumn3.HeaderText = "建档人";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.ToolTipText = "t_create_by";
            this.dataGridViewTextBoxColumn3.Width = 90;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "create_date";
            this.dataGridViewTextBoxColumn4.HeaderText = "建档日期";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.ToolTipText = "t_create_date";
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "update_by";
            this.dataGridViewTextBoxColumn5.HeaderText = "修改人";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.ToolTipText = "t_update_by";
            this.dataGridViewTextBoxColumn5.Width = 90;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "update_date";
            this.dataGridViewTextBoxColumn6.HeaderText = "修改日期";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.ToolTipText = "t_update_date";
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "state";
            this.dataGridViewTextBoxColumn7.HeaderText = "State";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.ToolTipText = "t_state";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // mo_id
            // 
            this.mo_id.DataPropertyName = "mo_id";
            this.mo_id.HeaderText = "制單編號";
            this.mo_id.Name = "mo_id";
            this.mo_id.ReadOnly = true;
            this.mo_id.ToolTipText = "t_id";
            // 
            // remark
            // 
            this.remark.DataPropertyName = "remark";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.remark.DefaultCellStyle = dataGridViewCellStyle2;
            this.remark.HeaderText = "備註";
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            this.remark.ToolTipText = "t_remark";
            this.remark.Width = 250;
            // 
            // create_by
            // 
            this.create_by.DataPropertyName = "create_by";
            this.create_by.HeaderText = "建档人";
            this.create_by.Name = "create_by";
            this.create_by.ReadOnly = true;
            this.create_by.ToolTipText = "t_create_by";
            this.create_by.Width = 90;
            // 
            // create_date
            // 
            this.create_date.DataPropertyName = "create_date";
            this.create_date.HeaderText = "建档日期";
            this.create_date.Name = "create_date";
            this.create_date.ReadOnly = true;
            this.create_date.ToolTipText = "t_create_date";
            this.create_date.Width = 152;
            // 
            // update_by
            // 
            this.update_by.DataPropertyName = "update_by";
            this.update_by.HeaderText = "修改人";
            this.update_by.Name = "update_by";
            this.update_by.ReadOnly = true;
            this.update_by.ToolTipText = "t_update_by";
            this.update_by.Width = 90;
            // 
            // update_date
            // 
            this.update_date.DataPropertyName = "update_date";
            this.update_date.HeaderText = "修改日期";
            this.update_date.Name = "update_date";
            this.update_date.ReadOnly = true;
            this.update_date.ToolTipText = "t_update_date";
            this.update_date.Width = 155;
            // 
            // state
            // 
            this.state.DataPropertyName = "state";
            this.state.HeaderText = "State";
            this.state.Name = "state";
            this.state.ReadOnly = true;
            this.state.ToolTipText = "t_state";
            this.state.Visible = false;
            // 
            // frmMoComplete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 616);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Name = "frmMoComplete";
            this.Tag = "Forms.frmMoComplete";
            this.Text = "frmMoComplete";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMoComplete_FormClosed);
            this.Load += new System.EventHandler(this.frmMoComplete_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtupdate_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtupdate_by.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreate_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreate_by.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luestate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmo_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtremark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.Label t_update_date;
        private System.Windows.Forms.Label t_update_by;
        private System.Windows.Forms.Label t_create_date;
        private System.Windows.Forms.Label t_create_by;
        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.BindingSource bds1;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnFind;
        private DevExpress.XtraEditors.TextEdit txtmo_id;
        private DevExpress.XtraEditors.LookUpEdit luestate;
        private System.Windows.Forms.Label t_state;
        private DevExpress.XtraEditors.TextEdit txtupdate_date;
        private DevExpress.XtraEditors.TextEdit txtupdate_by;
        private DevExpress.XtraEditors.TextEdit txtcreate_date;
        private DevExpress.XtraEditors.TextEdit txtcreate_by;
        private DevExpress.XtraEditors.TextEdit txtremark;
        private System.Windows.Forms.Label lblremark;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn mo_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn create_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn create_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn update_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn update_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
    }
}