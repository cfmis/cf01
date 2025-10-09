namespace cf01.Forms
{
    partial class frmGoodsRelease
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGoodsRelease));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.t_update_date = new System.Windows.Forms.Label();
            this.t_update_by = new System.Windows.Forms.Label();
            this.t_create_date = new System.Windows.Forms.Label();
            this.t_create_by = new System.Windows.Forms.Label();
            this.lblid = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtgoods_desc = new DevExpress.XtraEditors.MemoEdit();
            this.txtapproved_by = new DevExpress.XtraEditors.TextEdit();
            this.txtapply_by = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtother_desc = new DevExpress.XtraEditors.TextEdit();
            this.cbeReason = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtvendor_name = new DevExpress.XtraEditors.ButtonEdit();
            this.lueVendor_id = new DevExpress.XtraEditors.LookUpEdit();
            this.lblVendor = new System.Windows.Forms.Label();
            this.lblseriel = new System.Windows.Forms.Label();
            this.txtserial_number = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDate = new DevExpress.XtraEditors.DateEdit();
            this.txtupdate_date = new DevExpress.XtraEditors.TextEdit();
            this.txtupdate_by = new DevExpress.XtraEditors.TextEdit();
            this.txtcreate_date = new DevExpress.XtraEditors.TextEdit();
            this.txtcreate_by = new DevExpress.XtraEditors.TextEdit();
            this.luestate = new DevExpress.XtraEditors.LookUpEdit();
            this.t_state = new System.Windows.Forms.Label();
            this.txtid = new DevExpress.XtraEditors.TextEdit();
            this.txtremark = new DevExpress.XtraEditors.TextEdit();
            this.lblremark = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bds1 = new System.Windows.Forms.BindingSource(this.components);
            this.bill_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serial_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.other_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apply_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approved_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.create_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.create_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtgoods_desc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtapproved_by.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtapply_by.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtother_desc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeReason.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtvendor_name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueVendor_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtserial_number.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtupdate_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtupdate_by.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreate_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreate_by.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luestate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtid.Properties)).BeginInit();
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
            this.btnPrint});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(951, 38);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
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
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
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
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 38);
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
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 38);
            // 
            // btnPrint
            // 
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(52, 35);
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // t_update_date
            // 
            this.t_update_date.Location = new System.Drawing.Point(718, 175);
            this.t_update_date.Name = "t_update_date";
            this.t_update_date.Size = new System.Drawing.Size(60, 16);
            this.t_update_date.TabIndex = 48;
            this.t_update_date.Tag = "t_update_date";
            this.t_update_date.Text = "修改日期";
            this.t_update_date.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_update_by
            // 
            this.t_update_by.Location = new System.Drawing.Point(571, 175);
            this.t_update_by.Name = "t_update_by";
            this.t_update_by.Size = new System.Drawing.Size(47, 16);
            this.t_update_by.TabIndex = 46;
            this.t_update_by.Tag = "t_update_by";
            this.t_update_by.Text = "修改人";
            this.t_update_by.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_create_date
            // 
            this.t_create_date.Location = new System.Drawing.Point(713, 149);
            this.t_create_date.Name = "t_create_date";
            this.t_create_date.Size = new System.Drawing.Size(65, 16);
            this.t_create_date.TabIndex = 44;
            this.t_create_date.Tag = "t_create_date";
            this.t_create_date.Text = "建档日期";
            this.t_create_date.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t_create_by
            // 
            this.t_create_by.Location = new System.Drawing.Point(568, 149);
            this.t_create_by.Name = "t_create_by";
            this.t_create_by.Size = new System.Drawing.Size(51, 16);
            this.t_create_by.TabIndex = 42;
            this.t_create_by.Tag = "t_create_by";
            this.t_create_by.Text = "建档人";
            this.t_create_by.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblid
            // 
            this.lblid.Location = new System.Drawing.Point(5, 9);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(85, 16);
            this.lblid.TabIndex = 34;
            this.lblid.Tag = "t_id";
            this.lblid.Text = "編號";
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
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bill_date,
            this.serial_number,
            this.vendor_id,
            this.vendor_name,
            this.reason,
            this.other_desc,
            this.goods_desc,
            this.remark,
            this.apply_by,
            this.approved_by,
            this.create_by,
            this.create_date,
            this.update_by,
            this.update_date,
            this.state,
            this.id});
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetails.DefaultCellStyle = dataGridViewCellStyle28;
            this.dgvDetails.Location = new System.Drawing.Point(2, 260);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.ShowCellToolTips = false;
            this.dgvDetails.Size = new System.Drawing.Size(948, 349);
            this.dgvDetails.TabIndex = 50;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtgoods_desc);
            this.panel1.Controls.Add(this.txtapproved_by);
            this.panel1.Controls.Add(this.txtapply_by);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtother_desc);
            this.panel1.Controls.Add(this.cbeReason);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtvendor_name);
            this.panel1.Controls.Add(this.lueVendor_id);
            this.panel1.Controls.Add(this.lblVendor);
            this.panel1.Controls.Add(this.lblseriel);
            this.panel1.Controls.Add(this.txtserial_number);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDate);
            this.panel1.Controls.Add(this.txtupdate_date);
            this.panel1.Controls.Add(this.txtupdate_by);
            this.panel1.Controls.Add(this.txtcreate_date);
            this.panel1.Controls.Add(this.txtcreate_by);
            this.panel1.Controls.Add(this.luestate);
            this.panel1.Controls.Add(this.t_state);
            this.panel1.Controls.Add(this.txtid);
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
            this.panel1.Size = new System.Drawing.Size(947, 212);
            this.panel1.TabIndex = 53;
            // 
            // txtgoods_desc
            // 
            this.txtgoods_desc.Location = new System.Drawing.Point(92, 87);
            this.txtgoods_desc.Name = "txtgoods_desc";
            this.txtgoods_desc.Size = new System.Drawing.Size(464, 51);
            this.txtgoods_desc.TabIndex = 205;
            this.txtgoods_desc.EditValueChanged += new System.EventHandler(this.txtgoods_desc_EditValueChanged);
            // 
            // txtapproved_by
            // 
            this.txtapproved_by.Location = new System.Drawing.Point(350, 173);
            this.txtapproved_by.Name = "txtapproved_by";
            this.txtapproved_by.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtapproved_by.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtapproved_by.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtapproved_by.Properties.MaxLength = 20;
            this.txtapproved_by.Properties.ReadOnly = true;
            this.txtapproved_by.Properties.Tag = "2";
            this.txtapproved_by.Size = new System.Drawing.Size(206, 22);
            this.txtapproved_by.TabIndex = 8;
            this.txtapproved_by.Tag = "2";
            this.txtapproved_by.EditValueChanged += new System.EventHandler(this.txtapproved_by_EditValueChanged);
            // 
            // txtapply_by
            // 
            this.txtapply_by.Location = new System.Drawing.Point(92, 173);
            this.txtapply_by.Name = "txtapply_by";
            this.txtapply_by.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtapply_by.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtapply_by.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtapply_by.Properties.MaxLength = 20;
            this.txtapply_by.Properties.ReadOnly = true;
            this.txtapply_by.Properties.Tag = "2";
            this.txtapply_by.Size = new System.Drawing.Size(157, 22);
            this.txtapply_by.TabIndex = 7;
            this.txtapply_by.Tag = "2";
            this.txtapply_by.EditValueChanged += new System.EventHandler(this.txtapply_by_EditValueChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(300, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 204;
            this.label4.Tag = "t_update_by";
            this.label4.Text = "核準";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(39, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 203;
            this.label5.Tag = "t_create_by";
            this.label5.Text = "申請人";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(5, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 199;
            this.label3.Tag = "t_remark";
            this.label3.Text = "攜帶物品內容";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtother_desc
            // 
            this.txtother_desc.EditValue = "";
            this.txtother_desc.EnterMoveNextControl = true;
            this.txtother_desc.Location = new System.Drawing.Point(349, 61);
            this.txtother_desc.Name = "txtother_desc";
            this.txtother_desc.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtother_desc.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtother_desc.Properties.MaxLength = 200;
            this.txtother_desc.Properties.ReadOnly = true;
            this.txtother_desc.Size = new System.Drawing.Size(207, 20);
            this.txtother_desc.TabIndex = 4;
            this.txtother_desc.Tag = "2";
            // 
            // cbeReason
            // 
            this.cbeReason.EditValue = "";
            this.cbeReason.Location = new System.Drawing.Point(92, 61);
            this.cbeReason.Name = "cbeReason";
            this.cbeReason.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbeReason.Properties.Items.AddRange(new object[] {
            "廠商自帶",
            "委外維修",
            "租賃",
            "處理客訴",
            "報廢出售",
            "其它"});
            this.cbeReason.Size = new System.Drawing.Size(255, 20);
            this.cbeReason.TabIndex = 3;
            this.cbeReason.Tag = "2";
            this.cbeReason.EditValueChanged += new System.EventHandler(this.cbeReason_EditValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 196;
            this.label2.Tag = "t_remark";
            this.label2.Text = "事由";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtvendor_name
            // 
            this.txtvendor_name.EditValue = "";
            this.txtvendor_name.Location = new System.Drawing.Point(198, 35);
            this.txtvendor_name.Name = "txtvendor_name";
            this.txtvendor_name.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", 15, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtvendor_name.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtvendor_name.Properties.ReadOnly = true;
            this.txtvendor_name.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtvendor_name_Properties_ButtonClick);
            this.txtvendor_name.Size = new System.Drawing.Size(149, 20);
            this.txtvendor_name.TabIndex = 2;
            this.txtvendor_name.Tag = "2";
            this.txtvendor_name.Leave += new System.EventHandler(this.txtvendor_name_Leave);
            // 
            // lueVendor_id
            // 
            this.lueVendor_id.EditValue = "";
            this.lueVendor_id.Enabled = false;
            this.lueVendor_id.EnterMoveNextControl = true;
            this.lueVendor_id.Location = new System.Drawing.Point(92, 35);
            this.lueVendor_id.Name = "lueVendor_id";
            this.lueVendor_id.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.lueVendor_id.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.lueVendor_id.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueVendor_id.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lueVendor_id.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", 80, "編號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", 150, "描述")});
            this.lueVendor_id.Properties.DropDownRows = 18;
            this.lueVendor_id.Properties.MaxLength = 10;
            this.lueVendor_id.Properties.NullText = "";
            this.lueVendor_id.Properties.PopupWidth = 230;
            this.lueVendor_id.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lueVendor_id.Size = new System.Drawing.Size(104, 20);
            this.lueVendor_id.TabIndex = 1;
            this.lueVendor_id.Tag = "2";
            this.lueVendor_id.EditValueChanged += new System.EventHandler(this.lueVendor_id_EditValueChanged);
            // 
            // lblVendor
            // 
            this.lblVendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblVendor.ForeColor = System.Drawing.Color.Blue;
            this.lblVendor.Location = new System.Drawing.Point(11, 35);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(79, 17);
            this.lblVendor.TabIndex = 194;
            this.lblVendor.Text = "申請廠商";
            this.lblVendor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblseriel
            // 
            this.lblseriel.ForeColor = System.Drawing.Color.Blue;
            this.lblseriel.Location = new System.Drawing.Point(360, 8);
            this.lblseriel.Name = "lblseriel";
            this.lblseriel.Size = new System.Drawing.Size(73, 13);
            this.lblseriel.TabIndex = 191;
            this.lblseriel.Text = "序列號";
            this.lblseriel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtserial_number
            // 
            this.txtserial_number.EditValue = "";
            this.txtserial_number.Location = new System.Drawing.Point(439, 6);
            this.txtserial_number.Name = "txtserial_number";
            this.txtserial_number.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtserial_number.Properties.MaxLength = 12;
            this.txtserial_number.Properties.ReadOnly = true;
            this.txtserial_number.Size = new System.Drawing.Size(117, 20);
            this.txtserial_number.TabIndex = 192;
            this.txtserial_number.Tag = "1";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(209, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 190;
            this.label1.Tag = "t_remark";
            this.label1.Text = "日期";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDate
            // 
            this.txtDate.EditValue = "";
            this.txtDate.Enabled = false;
            this.txtDate.EnterMoveNextControl = true;
            this.txtDate.Location = new System.Drawing.Point(252, 5);
            this.txtDate.Name = "txtDate";
            this.txtDate.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.txtDate.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.txtDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtDate.Properties.Mask.BeepOnError = true;
            this.txtDate.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.txtDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtDate.Properties.MaxLength = 10;
            this.txtDate.Properties.NullDate = "";
            this.txtDate.Properties.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(95, 20);
            this.txtDate.TabIndex = 0;
            this.txtDate.Tag = "1";
            // 
            // txtupdate_date
            // 
            this.txtupdate_date.Enabled = false;
            this.txtupdate_date.Location = new System.Drawing.Point(776, 173);
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
            this.txtupdate_by.Location = new System.Drawing.Point(621, 173);
            this.txtupdate_by.Name = "txtupdate_by";
            this.txtupdate_by.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtupdate_by.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtupdate_by.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtupdate_by.Properties.ReadOnly = true;
            this.txtupdate_by.Size = new System.Drawing.Size(97, 22);
            this.txtupdate_by.TabIndex = 5;
            this.txtupdate_by.Tag = "2";
            // 
            // txtcreate_date
            // 
            this.txtcreate_date.Enabled = false;
            this.txtcreate_date.Location = new System.Drawing.Point(776, 145);
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
            this.txtcreate_by.Location = new System.Drawing.Point(621, 145);
            this.txtcreate_by.Name = "txtcreate_by";
            this.txtcreate_by.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtcreate_by.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtcreate_by.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtcreate_by.Properties.ReadOnly = true;
            this.txtcreate_by.Size = new System.Drawing.Size(96, 22);
            this.txtcreate_by.TabIndex = 3;
            this.txtcreate_by.Tag = "2";
            // 
            // luestate
            // 
            this.luestate.EditValue = "";
            this.luestate.Location = new System.Drawing.Point(439, 34);
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
            this.luestate.Properties.ReadOnly = true;
            this.luestate.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.luestate.Properties.ShowHeader = false;
            this.luestate.Properties.Tag = "2";
            this.luestate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.luestate.Size = new System.Drawing.Size(117, 22);
            this.luestate.TabIndex = 2;
            this.luestate.Tag = "2";
            this.luestate.EditValueChanged += new System.EventHandler(this.luestate_EditValueChanged);
            // 
            // t_state
            // 
            this.t_state.Location = new System.Drawing.Point(356, 36);
            this.t_state.Name = "t_state";
            this.t_state.Size = new System.Drawing.Size(77, 16);
            this.t_state.TabIndex = 188;
            this.t_state.Tag = "t_state";
            this.t_state.Text = "狀態";
            this.t_state.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtid
            // 
            this.txtid.EnterMoveNextControl = true;
            this.txtid.Location = new System.Drawing.Point(92, 7);
            this.txtid.Name = "txtid";
            this.txtid.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtid.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtid.Properties.MaxLength = 9;
            this.txtid.Properties.ReadOnly = true;
            this.txtid.Size = new System.Drawing.Size(104, 22);
            this.txtid.TabIndex = 0;
            this.txtid.Tag = "1";
            // 
            // txtremark
            // 
            this.txtremark.EditValue = "";
            this.txtremark.EnterMoveNextControl = true;
            this.txtremark.Location = new System.Drawing.Point(92, 145);
            this.txtremark.Name = "txtremark";
            this.txtremark.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtremark.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtremark.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtremark.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtremark.Properties.MaxLength = 250;
            this.txtremark.Properties.ReadOnly = true;
            this.txtremark.Size = new System.Drawing.Size(464, 22);
            this.txtremark.TabIndex = 6;
            this.txtremark.Tag = "2";
            this.txtremark.EditValueChanged += new System.EventHandler(this.txtremark_EditValueChanged);
            // 
            // lblremark
            // 
            this.lblremark.Location = new System.Drawing.Point(5, 146);
            this.lblremark.Name = "lblremark";
            this.lblremark.Size = new System.Drawing.Size(85, 16);
            this.lblremark.TabIndex = 40;
            this.lblremark.Tag = "t_remark";
            this.lblremark.Text = "備註";
            this.lblremark.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "制單編號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.ToolTipText = "t_id";
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "remark";
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle29;
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
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "remark";
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle30;
            this.dataGridViewTextBoxColumn8.HeaderText = "備註";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.ToolTipText = "t_remark";
            this.dataGridViewTextBoxColumn8.Width = 250;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "apply_by";
            this.dataGridViewTextBoxColumn9.HeaderText = "申請人";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "approved_by";
            this.dataGridViewTextBoxColumn10.HeaderText = "核準人";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "create_by";
            this.dataGridViewTextBoxColumn11.HeaderText = "建档人";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.ToolTipText = "t_create_by";
            this.dataGridViewTextBoxColumn11.Width = 90;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "create_date";
            this.dataGridViewTextBoxColumn12.HeaderText = "建档日期";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.ToolTipText = "t_create_date";
            this.dataGridViewTextBoxColumn12.Width = 152;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "update_by";
            this.dataGridViewTextBoxColumn13.HeaderText = "修改人";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.ToolTipText = "t_update_by";
            this.dataGridViewTextBoxColumn13.Width = 90;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "update_date";
            this.dataGridViewTextBoxColumn14.HeaderText = "修改日期";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.ToolTipText = "t_update_date";
            this.dataGridViewTextBoxColumn14.Width = 155;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "state";
            this.dataGridViewTextBoxColumn15.HeaderText = "State";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.ToolTipText = "t_state";
            this.dataGridViewTextBoxColumn15.Visible = false;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "mo_id";
            this.dataGridViewTextBoxColumn16.HeaderText = "編號";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.ToolTipText = "t_id";
            // 
            // bill_date
            // 
            this.bill_date.DataPropertyName = "bill_date";
            dataGridViewCellStyle26.Format = "yyyy/MM/dd";
            dataGridViewCellStyle26.NullValue = null;
            this.bill_date.DefaultCellStyle = dataGridViewCellStyle26;
            this.bill_date.HeaderText = "日期";
            this.bill_date.Name = "bill_date";
            this.bill_date.ReadOnly = true;
            this.bill_date.Width = 90;
            // 
            // serial_number
            // 
            this.serial_number.DataPropertyName = "serial_number";
            this.serial_number.HeaderText = "序列號";
            this.serial_number.Name = "serial_number";
            this.serial_number.ReadOnly = true;
            this.serial_number.Width = 80;
            // 
            // vendor_id
            // 
            this.vendor_id.DataPropertyName = "vendor_id";
            this.vendor_id.HeaderText = "供應商";
            this.vendor_id.Name = "vendor_id";
            this.vendor_id.ReadOnly = true;
            this.vendor_id.Width = 80;
            // 
            // vendor_name
            // 
            this.vendor_name.DataPropertyName = "vendor_name";
            this.vendor_name.HeaderText = "供應商名稱";
            this.vendor_name.Name = "vendor_name";
            this.vendor_name.ReadOnly = true;
            // 
            // reason
            // 
            this.reason.DataPropertyName = "reason";
            this.reason.HeaderText = "事由";
            this.reason.Name = "reason";
            this.reason.ReadOnly = true;
            this.reason.Width = 120;
            // 
            // other_desc
            // 
            this.other_desc.DataPropertyName = "other_desc";
            this.other_desc.HeaderText = "其它（事由）";
            this.other_desc.Name = "other_desc";
            this.other_desc.ReadOnly = true;
            // 
            // goods_desc
            // 
            this.goods_desc.DataPropertyName = "goods_desc";
            this.goods_desc.HeaderText = "攜帶物品";
            this.goods_desc.Name = "goods_desc";
            this.goods_desc.ReadOnly = true;
            // 
            // remark
            // 
            this.remark.DataPropertyName = "remark";
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.remark.DefaultCellStyle = dataGridViewCellStyle27;
            this.remark.HeaderText = "備註";
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            this.remark.ToolTipText = "t_remark";
            this.remark.Width = 250;
            // 
            // apply_by
            // 
            this.apply_by.DataPropertyName = "apply_by";
            this.apply_by.HeaderText = "申請人";
            this.apply_by.Name = "apply_by";
            this.apply_by.ReadOnly = true;
            // 
            // approved_by
            // 
            this.approved_by.DataPropertyName = "approved_by";
            this.approved_by.HeaderText = "核準人";
            this.approved_by.Name = "approved_by";
            this.approved_by.ReadOnly = true;
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
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "編號";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.ToolTipText = "t_id";
            // 
            // frmGoodsRelease
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 616);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Name = "frmGoodsRelease";
            this.Tag = "Forms.frmGoodsRelease";
            this.Text = "frmGoodsRelease";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGoodsRelease_FormClosed);
            this.Load += new System.EventHandler(this.frmGoodsRelease_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtgoods_desc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtapproved_by.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtapply_by.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtother_desc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeReason.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtvendor_name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueVendor_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtserial_number.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtupdate_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtupdate_by.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreate_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreate_by.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luestate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtid.Properties)).EndInit();
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
        private System.Windows.Forms.ToolStripButton btnPrint;
        private DevExpress.XtraEditors.TextEdit txtid;
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
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit txtDate;
        private System.Windows.Forms.Label lblseriel;
        private DevExpress.XtraEditors.TextEdit txtserial_number;
        private DevExpress.XtraEditors.LookUpEdit lueVendor_id;
        private System.Windows.Forms.Label lblVendor;
        private DevExpress.XtraEditors.ButtonEdit txtvendor_name;
        private DevExpress.XtraEditors.TextEdit txtapproved_by;
        private DevExpress.XtraEditors.TextEdit txtapply_by;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtother_desc;
        private DevExpress.XtraEditors.ComboBoxEdit cbeReason;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private DevExpress.XtraEditors.MemoEdit txtgoods_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn bill_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn serial_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn reason;
        private System.Windows.Forms.DataGridViewTextBoxColumn other_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn apply_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn approved_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn create_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn create_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn update_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn update_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
    }
}