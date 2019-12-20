namespace cf01.Forms
{
    partial class frmArtEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArtEdit));
            this.myNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.BTNNEW = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNSAVE = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtChange_content = new DevExpress.XtraEditors.TextEdit();
            this.txtSeq_id = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAmtim = new System.Windows.Forms.Label();
            this.lblAmusr = new System.Windows.Forms.Label();
            this.lblCrtim = new System.Windows.Forms.Label();
            this.lblCrusr = new System.Windows.Forms.Label();
            this.txtAmtim = new DevExpress.XtraEditors.TextEdit();
            this.txtAmusr = new DevExpress.XtraEditors.TextEdit();
            this.txtCrtim = new DevExpress.XtraEditors.TextEdit();
            this.txtCrusr = new DevExpress.XtraEditors.TextEdit();
            this.txtDg_work_date = new DevExpress.XtraEditors.DateEdit();
            this.txtHk_work_date = new DevExpress.XtraEditors.DateEdit();
            this.cmbProvide_original = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtResponsible_dept = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblArtwork_id = new System.Windows.Forms.Label();
            this.myBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.myNavigator)).BeginInit();
            this.myNavigator.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtChange_content.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeq_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmtim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmusr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrtim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrusr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDg_work_date.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDg_work_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHk_work_date.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHk_work_date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProvide_original.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtResponsible_dept.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // myNavigator
            // 
            this.myNavigator.AddNewItem = null;
            this.myNavigator.AutoSize = false;
            this.myNavigator.CountItem = this.bindingNavigatorCountItem;
            this.myNavigator.DeleteItem = null;
            this.myNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNNEW,
            this.toolStripSeparator1,
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.BTNSAVE,
            this.toolStripSeparator2,
            this.BTNEXIT,
            this.toolStripSeparator3});
            this.myNavigator.Location = new System.Drawing.Point(0, 0);
            this.myNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.myNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.myNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.myNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.myNavigator.Name = "myNavigator";
            this.myNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.myNavigator.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.myNavigator.Size = new System.Drawing.Size(586, 30);
            this.myNavigator.TabIndex = 3;
            this.myNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(24, 27);
            this.bindingNavigatorCountItem.Text = "/{0}";
            this.bindingNavigatorCountItem.ToolTipText = "項目總數";
            // 
            // BTNNEW
            // 
            this.BTNNEW.Image = ((System.Drawing.Image)(resources.GetObject("BTNNEW.Image")));
            this.BTNNEW.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNNEW.Name = "BTNNEW";
            this.BTNNEW.Size = new System.Drawing.Size(89, 27);
            this.BTNNEW.Text = "項目新增(&A)";
            this.BTNNEW.Click += new System.EventHandler(this.BTNNEW_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 27);
            this.bindingNavigatorMoveFirstItem.Text = "移到最前面";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 27);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一個";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 30);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 22);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.bindingNavigatorPositionItem.ToolTipText = "目前的位置";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 27);
            this.bindingNavigatorMoveNextItem.Text = "移到下一個";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 27);
            this.bindingNavigatorMoveLastItem.Text = "移到最後面";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // BTNSAVE
            // 
            this.BTNSAVE.Image = ((System.Drawing.Image)(resources.GetObject("BTNSAVE.Image")));
            this.BTNSAVE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNSAVE.Name = "BTNSAVE";
            this.BTNSAVE.Size = new System.Drawing.Size(63, 27);
            this.BTNSAVE.Text = "保存(&S)";
            this.BTNSAVE.Click += new System.EventHandler(this.BTNSAVE_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // BTNEXIT
            // 
            this.BTNEXIT.Image = ((System.Drawing.Image)(resources.GetObject("BTNEXIT.Image")));
            this.BTNEXIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEXIT.Name = "BTNEXIT";
            this.BTNEXIT.Size = new System.Drawing.Size(65, 27);
            this.BTNEXIT.Text = "退出(&X)";
            this.BTNEXIT.Click += new System.EventHandler(this.BTNEXIT_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 30);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtChange_content);
            this.panel1.Controls.Add(this.txtSeq_id);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblAmtim);
            this.panel1.Controls.Add(this.lblAmusr);
            this.panel1.Controls.Add(this.lblCrtim);
            this.panel1.Controls.Add(this.lblCrusr);
            this.panel1.Controls.Add(this.txtAmtim);
            this.panel1.Controls.Add(this.txtAmusr);
            this.panel1.Controls.Add(this.txtCrtim);
            this.panel1.Controls.Add(this.txtCrusr);
            this.panel1.Controls.Add(this.txtDg_work_date);
            this.panel1.Controls.Add(this.txtHk_work_date);
            this.panel1.Controls.Add(this.cmbProvide_original);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtResponsible_dept);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblArtwork_id);
            this.panel1.Location = new System.Drawing.Point(-1, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(587, 244);
            this.panel1.TabIndex = 32;
            // 
            // txtChange_content
            // 
            this.txtChange_content.Location = new System.Drawing.Point(161, 145);
            this.txtChange_content.Name = "txtChange_content";
            this.txtChange_content.Size = new System.Drawing.Size(396, 20);
            this.txtChange_content.TabIndex = 4;
            // 
            // txtSeq_id
            // 
            this.txtSeq_id.Location = new System.Drawing.Point(497, 15);
            this.txtSeq_id.Name = "txtSeq_id";
            this.txtSeq_id.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeq_id.Properties.Appearance.Options.UseFont = true;
            this.txtSeq_id.Properties.ReadOnly = true;
            this.txtSeq_id.Size = new System.Drawing.Size(58, 20);
            this.txtSeq_id.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(439, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 12);
            this.label5.TabIndex = 93;
            this.label5.Text = "序號";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAmtim
            // 
            this.lblAmtim.Enabled = false;
            this.lblAmtim.Location = new System.Drawing.Point(364, 211);
            this.lblAmtim.Name = "lblAmtim";
            this.lblAmtim.Size = new System.Drawing.Size(64, 13);
            this.lblAmtim.TabIndex = 92;
            this.lblAmtim.Text = "修改日期";
            this.lblAmtim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAmtim.Visible = false;
            // 
            // lblAmusr
            // 
            this.lblAmusr.Enabled = false;
            this.lblAmusr.Location = new System.Drawing.Point(61, 211);
            this.lblAmusr.Name = "lblAmusr";
            this.lblAmusr.Size = new System.Drawing.Size(99, 13);
            this.lblAmusr.TabIndex = 91;
            this.lblAmusr.Text = "修改人";
            this.lblAmusr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAmusr.Visible = false;
            // 
            // lblCrtim
            // 
            this.lblCrtim.Enabled = false;
            this.lblCrtim.Location = new System.Drawing.Point(364, 179);
            this.lblCrtim.Name = "lblCrtim";
            this.lblCrtim.Size = new System.Drawing.Size(64, 13);
            this.lblCrtim.TabIndex = 90;
            this.lblCrtim.Text = "建檔日期";
            this.lblCrtim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCrtim.Visible = false;
            // 
            // lblCrusr
            // 
            this.lblCrusr.Enabled = false;
            this.lblCrusr.Location = new System.Drawing.Point(61, 179);
            this.lblCrusr.Name = "lblCrusr";
            this.lblCrusr.Size = new System.Drawing.Size(99, 13);
            this.lblCrusr.TabIndex = 89;
            this.lblCrusr.Text = "建檔人";
            this.lblCrusr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCrusr.Visible = false;
            // 
            // txtAmtim
            // 
            this.txtAmtim.Enabled = false;
            this.txtAmtim.Location = new System.Drawing.Point(431, 208);
            this.txtAmtim.Name = "txtAmtim";
            this.txtAmtim.Properties.ReadOnly = true;
            this.txtAmtim.Size = new System.Drawing.Size(126, 20);
            this.txtAmtim.TabIndex = 88;
            this.txtAmtim.Tag = "2";
            this.txtAmtim.Visible = false;
            // 
            // txtAmusr
            // 
            this.txtAmusr.Enabled = false;
            this.txtAmusr.Location = new System.Drawing.Point(161, 208);
            this.txtAmusr.Name = "txtAmusr";
            this.txtAmusr.Properties.ReadOnly = true;
            this.txtAmusr.Size = new System.Drawing.Size(133, 20);
            this.txtAmusr.TabIndex = 87;
            this.txtAmusr.Tag = "2";
            this.txtAmusr.Visible = false;
            // 
            // txtCrtim
            // 
            this.txtCrtim.Enabled = false;
            this.txtCrtim.Location = new System.Drawing.Point(431, 176);
            this.txtCrtim.Name = "txtCrtim";
            this.txtCrtim.Properties.ReadOnly = true;
            this.txtCrtim.Size = new System.Drawing.Size(126, 20);
            this.txtCrtim.TabIndex = 86;
            this.txtCrtim.Tag = "2";
            this.txtCrtim.Visible = false;
            // 
            // txtCrusr
            // 
            this.txtCrusr.Enabled = false;
            this.txtCrusr.Location = new System.Drawing.Point(161, 176);
            this.txtCrusr.Name = "txtCrusr";
            this.txtCrusr.Properties.ReadOnly = true;
            this.txtCrusr.Size = new System.Drawing.Size(133, 20);
            this.txtCrusr.TabIndex = 85;
            this.txtCrusr.Tag = "2";
            this.txtCrusr.Visible = false;
            // 
            // txtDg_work_date
            // 
            this.txtDg_work_date.EditValue = null;
            this.txtDg_work_date.EnterMoveNextControl = true;
            this.txtDg_work_date.Location = new System.Drawing.Point(161, 49);
            this.txtDg_work_date.Name = "txtDg_work_date";
            this.txtDg_work_date.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDg_work_date.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.txtDg_work_date.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtDg_work_date.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDg_work_date.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDg_work_date.Size = new System.Drawing.Size(135, 20);
            this.txtDg_work_date.TabIndex = 1;
            this.txtDg_work_date.Tag = "2";
            this.txtDg_work_date.Leave += new System.EventHandler(this.txtDg_work_date_Leave);
            // 
            // txtHk_work_date
            // 
            this.txtHk_work_date.EditValue = null;
            this.txtHk_work_date.EnterMoveNextControl = true;
            this.txtHk_work_date.Location = new System.Drawing.Point(161, 15);
            this.txtHk_work_date.Name = "txtHk_work_date";
            this.txtHk_work_date.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtHk_work_date.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.txtHk_work_date.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtHk_work_date.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtHk_work_date.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtHk_work_date.Size = new System.Drawing.Size(135, 20);
            this.txtHk_work_date.TabIndex = 0;
            this.txtHk_work_date.Tag = "2";
            this.txtHk_work_date.Leave += new System.EventHandler(this.txtHk_work_date_Leave);
            // 
            // cmbProvide_original
            // 
            this.cmbProvide_original.EnterMoveNextControl = true;
            this.cmbProvide_original.Location = new System.Drawing.Point(161, 81);
            this.cmbProvide_original.Name = "cmbProvide_original";
            this.cmbProvide_original.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbProvide_original.Properties.Items.AddRange(new object[] {
            "有",
            "沒有"});
            this.cmbProvide_original.Size = new System.Drawing.Size(135, 20);
            this.cmbProvide_original.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(19, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 12);
            this.label4.TabIndex = 41;
            this.label4.Text = "更改內容";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtResponsible_dept
            // 
            this.txtResponsible_dept.EnterMoveNextControl = true;
            this.txtResponsible_dept.Location = new System.Drawing.Point(161, 114);
            this.txtResponsible_dept.Name = "txtResponsible_dept";
            this.txtResponsible_dept.Size = new System.Drawing.Size(135, 20);
            this.txtResponsible_dept.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(19, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 12);
            this.label3.TabIndex = 38;
            this.label3.Text = "負責單位";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(19, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 12);
            this.label2.TabIndex = 36;
            this.label2.Text = "提供原版";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(19, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "東莞交畫稿日期";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblArtwork_id
            // 
            this.lblArtwork_id.Location = new System.Drawing.Point(19, 18);
            this.lblArtwork_id.Name = "lblArtwork_id";
            this.lblArtwork_id.Size = new System.Drawing.Size(140, 12);
            this.lblArtwork_id.TabIndex = 33;
            this.lblArtwork_id.Text = "香港上畫稿/通知更改日期";
            this.lblArtwork_id.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmArtEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 276);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.myNavigator);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmArtEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit";
            this.Load += new System.EventHandler(this.frmArtEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myNavigator)).EndInit();
            this.myNavigator.ResumeLayout(false);
            this.myNavigator.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtChange_content.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeq_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmtim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmusr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrtim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCrusr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDg_work_date.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDg_work_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHk_work_date.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHk_work_date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProvide_original.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtResponsible_dept.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingNavigator myNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton BTNNEW;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BTNSAVE;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtResponsible_dept;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblArtwork_id;
        private DevExpress.XtraEditors.ComboBoxEdit cmbProvide_original;
        private DevExpress.XtraEditors.DateEdit txtDg_work_date;
        private DevExpress.XtraEditors.DateEdit txtHk_work_date;
        private System.Windows.Forms.BindingSource myBindingSource;
        private System.Windows.Forms.Label lblAmtim;
        private System.Windows.Forms.Label lblAmusr;
        private System.Windows.Forms.Label lblCrtim;
        private System.Windows.Forms.Label lblCrusr;
        private DevExpress.XtraEditors.TextEdit txtAmtim;
        private DevExpress.XtraEditors.TextEdit txtAmusr;
        private DevExpress.XtraEditors.TextEdit txtCrtim;
        private DevExpress.XtraEditors.TextEdit txtCrusr;
        private DevExpress.XtraEditors.TextEdit txtSeq_id;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtChange_content;
    }
}