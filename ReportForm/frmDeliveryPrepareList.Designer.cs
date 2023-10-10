namespace cf01.ReportForm
{
    partial class frmDeliveryPrepareList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeliveryPrepareList));
            this.txtId1 = new DevExpress.XtraEditors.TextEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGroup_no = new DevExpress.XtraEditors.TextEdit();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCreate_by2 = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCreate_by1 = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMo_id2 = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMo_id1 = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtDat2 = new DevExpress.XtraEditors.DateEdit();
            this.txtDat1 = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId2 = new DevExpress.XtraEditors.TextEdit();
            this.lblSalesGroup = new System.Windows.Forms.Label();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.group_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transfer_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mo_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.txtId1.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroup_no.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_by2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_by1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_id2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_id1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDat2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDat2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDat1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDat1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtId1
            // 
            this.txtId1.EnterMoveNextControl = true;
            this.txtId1.Location = new System.Drawing.Point(94, 19);
            this.txtId1.Name = "txtId1";
            this.txtId1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtId1.Properties.MaxLength = 20;
            this.txtId1.Size = new System.Drawing.Size(127, 20);
            this.txtId1.TabIndex = 148;
            this.txtId1.Leave += new System.EventHandler(this.txtId1_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtGroup_no);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnConfirm);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCreate_by2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCreate_by1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMo_id2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMo_id1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.txtDat2);
            this.groupBox1.Controls.Add(this.txtDat1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtId2);
            this.groupBox1.Controls.Add(this.lblSalesGroup);
            this.groupBox1.Controls.Add(this.txtId1);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(690, 154);
            this.groupBox1.TabIndex = 149;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(11, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 172;
            this.label7.Text = "組別";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGroup_no
            // 
            this.txtGroup_no.EnterMoveNextControl = true;
            this.txtGroup_no.Location = new System.Drawing.Point(94, 45);
            this.txtGroup_no.Name = "txtGroup_no";
            this.txtGroup_no.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGroup_no.Properties.MaxLength = 1;
            this.txtGroup_no.Size = new System.Drawing.Size(127, 20);
            this.txtGroup_no.TabIndex = 171;
            // 
            // btnFind
            // 
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFind.Location = new System.Drawing.Point(393, 70);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(76, 28);
            this.btnFind.TabIndex = 170;
            this.btnFind.Text = "查詢(&S)";
            this.btnFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(587, 70);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 28);
            this.btnClose.TabIndex = 169;
            this.btnClose.Text = "離開(&C)";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirm.Image")));
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirm.Location = new System.Drawing.Point(490, 70);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(76, 28);
            this.btnConfirm.TabIndex = 168;
            this.btnConfirm.Text = "確認(&O)";
            this.btnConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(230, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 13);
            this.label4.TabIndex = 167;
            this.label4.Text = "~";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCreate_by2
            // 
            this.txtCreate_by2.EnterMoveNextControl = true;
            this.txtCreate_by2.Location = new System.Drawing.Point(251, 122);
            this.txtCreate_by2.Name = "txtCreate_by2";
            this.txtCreate_by2.Properties.MaxLength = 20;
            this.txtCreate_by2.Size = new System.Drawing.Size(125, 20);
            this.txtCreate_by2.TabIndex = 166;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(11, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 165;
            this.label5.Text = "建档人";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCreate_by1
            // 
            this.txtCreate_by1.EnterMoveNextControl = true;
            this.txtCreate_by1.Location = new System.Drawing.Point(94, 121);
            this.txtCreate_by1.Name = "txtCreate_by1";
            this.txtCreate_by1.Properties.MaxLength = 20;
            this.txtCreate_by1.Size = new System.Drawing.Size(127, 20);
            this.txtCreate_by1.TabIndex = 164;
            this.txtCreate_by1.Leave += new System.EventHandler(this.txtCreate_by1_Leave);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(230, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 13);
            this.label2.TabIndex = 163;
            this.label2.Text = "~";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMo_id2
            // 
            this.txtMo_id2.EnterMoveNextControl = true;
            this.txtMo_id2.Location = new System.Drawing.Point(251, 96);
            this.txtMo_id2.Name = "txtMo_id2";
            this.txtMo_id2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo_id2.Properties.MaxLength = 10;
            this.txtMo_id2.Size = new System.Drawing.Size(125, 20);
            this.txtMo_id2.TabIndex = 162;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 161;
            this.label3.Text = "页数";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMo_id1
            // 
            this.txtMo_id1.EnterMoveNextControl = true;
            this.txtMo_id1.Location = new System.Drawing.Point(94, 95);
            this.txtMo_id1.Name = "txtMo_id1";
            this.txtMo_id1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo_id1.Properties.MaxLength = 10;
            this.txtMo_id1.Size = new System.Drawing.Size(127, 20);
            this.txtMo_id1.TabIndex = 160;
            this.txtMo_id1.Leave += new System.EventHandler(this.txtMo_id1_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(230, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 159;
            this.label6.Text = "~";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(11, 74);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(80, 13);
            this.lblDate.TabIndex = 158;
            this.lblDate.Text = "递交日期";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDat2
            // 
            this.txtDat2.EditValue = null;
            this.txtDat2.EnterMoveNextControl = true;
            this.txtDat2.Location = new System.Drawing.Point(251, 70);
            this.txtDat2.Name = "txtDat2";
            this.txtDat2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDat2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDat2.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.txtDat2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtDat2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDat2.Properties.MaxLength = 10;
            this.txtDat2.Size = new System.Drawing.Size(125, 20);
            this.txtDat2.TabIndex = 157;
            this.txtDat2.Tag = "2";
            // 
            // txtDat1
            // 
            this.txtDat1.EditValue = "";
            this.txtDat1.EnterMoveNextControl = true;
            this.txtDat1.Location = new System.Drawing.Point(94, 70);
            this.txtDat1.Name = "txtDat1";
            this.txtDat1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDat1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDat1.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.txtDat1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtDat1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDat1.Properties.MaxLength = 10;
            this.txtDat1.Size = new System.Drawing.Size(127, 20);
            this.txtDat1.TabIndex = 156;
            this.txtDat1.Tag = "2";
            this.txtDat1.Leave += new System.EventHandler(this.txtDat1_Leave);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(230, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 13);
            this.label1.TabIndex = 155;
            this.label1.Text = "~";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtId2
            // 
            this.txtId2.EnterMoveNextControl = true;
            this.txtId2.Location = new System.Drawing.Point(251, 20);
            this.txtId2.Name = "txtId2";
            this.txtId2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtId2.Properties.MaxLength = 20;
            this.txtId2.Size = new System.Drawing.Size(125, 20);
            this.txtId2.TabIndex = 154;
            // 
            // lblSalesGroup
            // 
            this.lblSalesGroup.Location = new System.Drawing.Point(11, 23);
            this.lblSalesGroup.Name = "lblSalesGroup";
            this.lblSalesGroup.Size = new System.Drawing.Size(80, 13);
            this.lblSalesGroup.TabIndex = 153;
            this.lblSalesGroup.Text = "編號";
            this.lblSalesGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.group_no,
            this.transfer_date,
            this.mo_id,
            this.Create_by});
            this.dgv1.Location = new System.Drawing.Point(12, 162);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowTemplate.Height = 24;
            this.dgv1.Size = new System.Drawing.Size(690, 277);
            this.dgv1.TabIndex = 150;
            this.dgv1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv1_CellMouseUp);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "編號";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id.Width = 120;
            // 
            // group_no
            // 
            this.group_no.DataPropertyName = "group_no";
            this.group_no.HeaderText = "組別";
            this.group_no.Name = "group_no";
            this.group_no.ReadOnly = true;
            this.group_no.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.group_no.Width = 60;
            // 
            // transfer_date
            // 
            this.transfer_date.DataPropertyName = "transfer_date";
            this.transfer_date.HeaderText = "日期";
            this.transfer_date.Name = "transfer_date";
            this.transfer_date.ReadOnly = true;
            this.transfer_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.transfer_date.Width = 90;
            // 
            // mo_id
            // 
            this.mo_id.DataPropertyName = "mo_id";
            this.mo_id.HeaderText = "頁數";
            this.mo_id.Name = "mo_id";
            this.mo_id.ReadOnly = true;
            this.mo_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Create_by
            // 
            this.Create_by.DataPropertyName = "create_by";
            this.Create_by.HeaderText = "建檔人";
            this.Create_by.Name = "Create_by";
            this.Create_by.ReadOnly = true;
            this.Create_by.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // frmDeliveryPrepareList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 451);
            this.ControlBox = false;
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDeliveryPrepareList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmDeliveryPrepareList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtId1.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroup_no.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_by2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreate_by1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_id2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMo_id1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDat2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDat2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDat1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDat1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtId1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtId2;
        private System.Windows.Forms.Label lblSalesGroup;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDate;
        private DevExpress.XtraEditors.DateEdit txtDat2;
        private DevExpress.XtraEditors.DateEdit txtDat1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtCreate_by2;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtCreate_by1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtMo_id2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtMo_id1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit txtGroup_no;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn group_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn transfer_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn mo_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create_by;
    }
}