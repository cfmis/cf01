namespace cf01.Forms
{
    partial class frmOcFindMo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOcFindMo));
            this.label1 = new System.Windows.Forms.Label();
            this.txtoc_no = new System.Windows.Forms.TextBox();
            this.dgvMoList = new System.Windows.Forms.DataGridView();
            this.flag_select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oc_remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contract_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "OC NO.";
            // 
            // txtoc_no
            // 
            this.txtoc_no.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtoc_no.Location = new System.Drawing.Point(63, 15);
            this.txtoc_no.Name = "txtoc_no";
            this.txtoc_no.ReadOnly = true;
            this.txtoc_no.Size = new System.Drawing.Size(192, 26);
            this.txtoc_no.TabIndex = 1;
            // 
            // dgvMoList
            // 
            this.dgvMoList.AllowUserToAddRows = false;
            this.dgvMoList.AllowUserToDeleteRows = false;
            this.dgvMoList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMoList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMoList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.flag_select,
            this.mo,
            this.oc_remark,
            this.contract_id});
            this.dgvMoList.Location = new System.Drawing.Point(3, 69);
            this.dgvMoList.Name = "dgvMoList";
            this.dgvMoList.RowTemplate.Height = 24;
            this.dgvMoList.Size = new System.Drawing.Size(832, 482);
            this.dgvMoList.TabIndex = 2;
            // 
            // flag_select
            // 
            this.flag_select.DataPropertyName = "flag_select";
            this.flag_select.HeaderText = " ";
            this.flag_select.Name = "flag_select";
            this.flag_select.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.flag_select.Width = 80;
            // 
            // mo
            // 
            this.mo.DataPropertyName = "mo_id";
            this.mo.HeaderText = "頁數";
            this.mo.Name = "mo";
            this.mo.ReadOnly = true;
            this.mo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.mo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.mo.Width = 120;
            // 
            // oc_remark
            // 
            this.oc_remark.DataPropertyName = "oc_remark";
            this.oc_remark.HeaderText = "OC 備註";
            this.oc_remark.Name = "oc_remark";
            this.oc_remark.ReadOnly = true;
            this.oc_remark.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.oc_remark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.oc_remark.Width = 400;
            // 
            // contract_id
            // 
            this.contract_id.DataPropertyName = "contract_id";
            this.contract_id.HeaderText = "PO NO.";
            this.contract_id.Name = "contract_id";
            this.contract_id.ReadOnly = true;
            this.contract_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.contract_id.Width = 180;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirm.Image")));
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirm.Location = new System.Drawing.Point(308, 10);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(80, 33);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "確 定  ";
            this.btnConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = global::cf01.Properties.Resources.exit;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(411, 10);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 33);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "退 出  ";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "mo_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "頁數";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "oc_remark";
            this.dataGridViewTextBoxColumn2.HeaderText = "OC 備註";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 400;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(80, 50);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(50, 18);
            this.chkSelectAll.TabIndex = 5;
            this.chkSelectAll.Text = "全選";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // frmOcFindMo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 554);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.dgvMoList);
            this.Controls.Add(this.txtoc_no);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOcFindMo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOcFindMo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmOcFindMo_FormClosed);
            this.Load += new System.EventHandler(this.frmOcFindMo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtoc_no;
        private System.Windows.Forms.DataGridView dgvMoList;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn flag_select;
        private System.Windows.Forms.DataGridViewTextBoxColumn mo;
        private System.Windows.Forms.DataGridViewTextBoxColumn oc_remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn contract_id;
        private System.Windows.Forms.CheckBox chkSelectAll;
    }
}