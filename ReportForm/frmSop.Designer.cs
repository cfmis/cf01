namespace cf01.ReportForm
{
    partial class frmSop
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtStyle2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStyle1 = new System.Windows.Forms.TextBox();
            this.txtId2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.dtDat1 = new DevExpress.XtraEditors.DateEdit();
            this.dtDat2 = new DevExpress.XtraEditors.DateEdit();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtId1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.flag_select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sop1no1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sop1dat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sop1style = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sop1cname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkSelect = new DevExpress.XtraEditors.CheckEdit();
            this.dgvExcel = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDat1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDat1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDat2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDat2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelect.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtStyle2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtStyle1);
            this.groupBox1.Controls.Add(this.txtId2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label36);
            this.groupBox1.Controls.Add(this.dtDat1);
            this.groupBox1.Controls.Add(this.dtDat2);
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.txtId1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(875, 133);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查找";
            // 
            // txtStyle2
            // 
            this.txtStyle2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStyle2.Location = new System.Drawing.Point(212, 100);
            this.txtStyle2.MaxLength = 20;
            this.txtStyle2.Name = "txtStyle2";
            this.txtStyle2.Size = new System.Drawing.Size(110, 22);
            this.txtStyle2.TabIndex = 175;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(190, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 16);
            this.label4.TabIndex = 174;
            this.label4.Text = "~";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 173;
            this.label5.Text = "成衣型號";
            // 
            // txtStyle1
            // 
            this.txtStyle1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStyle1.Location = new System.Drawing.Point(79, 99);
            this.txtStyle1.MaxLength = 20;
            this.txtStyle1.Name = "txtStyle1";
            this.txtStyle1.Size = new System.Drawing.Size(109, 22);
            this.txtStyle1.TabIndex = 172;
            this.txtStyle1.Leave += new System.EventHandler(this.txtStyle1_Leave);
            // 
            // txtId2
            // 
            this.txtId2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtId2.Location = new System.Drawing.Point(212, 72);
            this.txtId2.MaxLength = 12;
            this.txtId2.Name = "txtId2";
            this.txtId2.Size = new System.Drawing.Size(110, 22);
            this.txtId2.TabIndex = 171;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(190, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 16);
            this.label3.TabIndex = 170;
            this.label3.Text = "~";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 169;
            this.label2.Text = "單據編號";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("PMingLiU", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label36.Location = new System.Drawing.Point(190, 45);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(17, 16);
            this.label36.TabIndex = 168;
            this.label36.Text = "~";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtDat1
            // 
            this.dtDat1.EditValue = "";
            this.dtDat1.EnterMoveNextControl = true;
            this.dtDat1.Location = new System.Drawing.Point(79, 44);
            this.dtDat1.Name = "dtDat1";
            this.dtDat1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.dtDat1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDat1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtDat1.Properties.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.dtDat1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtDat1.Properties.EditFormat.FormatString = "yyyy/MM/dd";
            this.dtDat1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtDat1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtDat1.Properties.MaxLength = 10;
            this.dtDat1.Size = new System.Drawing.Size(109, 22);
            this.dtDat1.TabIndex = 166;
            this.dtDat1.Leave += new System.EventHandler(this.dtDat1_Leave);
            // 
            // dtDat2
            // 
            this.dtDat2.EditValue = "";
            this.dtDat2.EnterMoveNextControl = true;
            this.dtDat2.Location = new System.Drawing.Point(212, 44);
            this.dtDat2.Name = "dtDat2";
            this.dtDat2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.dtDat2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDat2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtDat2.Properties.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.dtDat2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtDat2.Properties.EditFormat.FormatString = "yyyy/MM/dd";
            this.dtDat2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtDat2.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.dtDat2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtDat2.Properties.MaxLength = 10;
            this.dtDat2.Size = new System.Drawing.Size(110, 22);
            this.dtDat2.TabIndex = 167;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(244, 10);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 26);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "匯出EXCEL";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(162, 10);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(70, 26);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "查找";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(79, 10);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 26);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtId1
            // 
            this.txtId1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtId1.Location = new System.Drawing.Point(79, 71);
            this.txtId1.MaxLength = 12;
            this.txtId1.Name = "txtId1";
            this.txtId1.Size = new System.Drawing.Size(109, 22);
            this.txtId1.TabIndex = 1;
            this.txtId1.Leave += new System.EventHandler(this.txtId1_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "單據日期";
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.flag_select,
            this.sop1no1,
            this.sop1dat,
            this.sop1style,
            this.sop1cname});
            this.dgvDetails.Location = new System.Drawing.Point(2, 164);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(882, 321);
            this.dgvDetails.TabIndex = 209;
            // 
            // flag_select
            // 
            this.flag_select.DataPropertyName = "flag_select";
            this.flag_select.HeaderText = "選取";
            this.flag_select.Name = "flag_select";
            this.flag_select.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.flag_select.Width = 70;
            // 
            // sop1no1
            // 
            this.sop1no1.DataPropertyName = "sop1no";
            this.sop1no1.HeaderText = "單據編號";
            this.sop1no1.Name = "sop1no1";
            this.sop1no1.ReadOnly = true;
            this.sop1no1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sop1no1.Width = 130;
            // 
            // sop1dat
            // 
            this.sop1dat.DataPropertyName = "sop1dat";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.sop1dat.DefaultCellStyle = dataGridViewCellStyle2;
            this.sop1dat.HeaderText = "單據日期";
            this.sop1dat.Name = "sop1dat";
            this.sop1dat.ReadOnly = true;
            this.sop1dat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sop1dat.Width = 90;
            // 
            // sop1style
            // 
            this.sop1style.DataPropertyName = "sop1style";
            this.sop1style.HeaderText = "成衣型號";
            this.sop1style.Name = "sop1style";
            this.sop1style.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sop1style.Width = 150;
            // 
            // sop1cname
            // 
            this.sop1cname.DataPropertyName = "sop1cname";
            this.sop1cname.HeaderText = "制衣廠";
            this.sop1cname.Name = "sop1cname";
            this.sop1cname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sop1cname.Width = 300;
            // 
            // chkSelect
            // 
            this.chkSelect.Location = new System.Drawing.Point(63, 135);
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Properties.Caption = "全選";
            this.chkSelect.Size = new System.Drawing.Size(48, 19);
            this.chkSelect.TabIndex = 210;
            this.chkSelect.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chkSelect_MouseUp);
            // 
            // dgvExcel
            // 
            this.dgvExcel.AllowUserToAddRows = false;
            this.dgvExcel.AllowUserToDeleteRows = false;
            this.dgvExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExcel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExcel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgvExcel.Location = new System.Drawing.Point(3, 184);
            this.dgvExcel.Name = "dgvExcel";
            this.dgvExcel.RowTemplate.Height = 24;
            this.dgvExcel.Size = new System.Drawing.Size(875, 289);
            this.dgvExcel.TabIndex = 211;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "sop1no";
            this.dataGridViewTextBoxColumn1.HeaderText = "單據編號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 130;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "sop1dat";
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn2.HeaderText = "單據日期";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 90;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "sop1style";
            this.dataGridViewTextBoxColumn3.HeaderText = "成衣型號";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "sop1cname";
            this.dataGridViewTextBoxColumn4.HeaderText = "制衣廠";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 300;
            // 
            // frmSop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 485);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.chkSelect);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvExcel);
            this.Name = "frmSop";
            this.Text = "DMS";
            this.Load += new System.EventHandler(this.frmSop_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDat1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDat1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDat2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDat2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelect.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtId1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStyle2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStyle1;
        private System.Windows.Forms.TextBox txtId2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label36;
        private DevExpress.XtraEditors.DateEdit dtDat1;
        private DevExpress.XtraEditors.DateEdit dtDat2;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.DataGridViewCheckBoxColumn flag_select;
        private System.Windows.Forms.DataGridViewTextBoxColumn sop1no1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sop1dat;
        private System.Windows.Forms.DataGridViewTextBoxColumn sop1style;
        private System.Windows.Forms.DataGridViewTextBoxColumn sop1cname;
        private DevExpress.XtraEditors.CheckEdit chkSelect;
        private System.Windows.Forms.DataGridView dgvExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}