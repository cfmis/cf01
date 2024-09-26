namespace cf01.Forms
{
    partial class frmProductionArrangeWorker
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
            this.txtArrange_id = new System.Windows.Forms.TextBox();
            this.lblWorker_id = new System.Windows.Forms.Label();
            this.txtWorker_id = new System.Windows.Forms.TextBox();
            this.lblWork_type_id = new System.Windows.Forms.Label();
            this.cmbWork_type_id = new System.Windows.Forms.ComboBox();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.colWorker_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWorker_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWork_type_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWork_type_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBtnDel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // txtArrange_id
            // 
            this.txtArrange_id.Location = new System.Drawing.Point(22, 262);
            this.txtArrange_id.Name = "txtArrange_id";
            this.txtArrange_id.Size = new System.Drawing.Size(223, 22);
            this.txtArrange_id.TabIndex = 0;
            this.txtArrange_id.Visible = false;
            // 
            // lblWorker_id
            // 
            this.lblWorker_id.AutoSize = true;
            this.lblWorker_id.Location = new System.Drawing.Point(20, 23);
            this.lblWorker_id.Name = "lblWorker_id";
            this.lblWorker_id.Size = new System.Drawing.Size(32, 12);
            this.lblWorker_id.TabIndex = 1;
            this.lblWorker_id.Text = "工號:";
            // 
            // txtWorker_id
            // 
            this.txtWorker_id.Location = new System.Drawing.Point(54, 19);
            this.txtWorker_id.Name = "txtWorker_id";
            this.txtWorker_id.Size = new System.Drawing.Size(100, 22);
            this.txtWorker_id.TabIndex = 0;
            // 
            // lblWork_type_id
            // 
            this.lblWork_type_id.AutoSize = true;
            this.lblWork_type_id.Location = new System.Drawing.Point(173, 23);
            this.lblWork_type_id.Name = "lblWork_type_id";
            this.lblWork_type_id.Size = new System.Drawing.Size(56, 12);
            this.lblWork_type_id.TabIndex = 3;
            this.lblWork_type_id.Text = "工作類型:";
            // 
            // cmbWork_type_id
            // 
            this.cmbWork_type_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWork_type_id.FormattingEnabled = true;
            this.cmbWork_type_id.Location = new System.Drawing.Point(236, 21);
            this.cmbWork_type_id.Name = "cmbWork_type_id";
            this.cmbWork_type_id.Size = new System.Drawing.Size(121, 20);
            this.cmbWork_type_id.TabIndex = 1;
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.ColumnHeadersHeight = 30;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colWorker_id,
            this.colWorker_name,
            this.colWork_type_id,
            this.colWork_type_desc,
            this.colBtnDel});
            this.dgvDetails.Location = new System.Drawing.Point(22, 60);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowHeadersWidth = 20;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(452, 196);
            this.dgvDetails.TabIndex = 5;
            this.dgvDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellContentClick);
            // 
            // colWorker_id
            // 
            this.colWorker_id.DataPropertyName = "worker_id";
            this.colWorker_id.HeaderText = "工號";
            this.colWorker_id.Name = "colWorker_id";
            this.colWorker_id.ReadOnly = true;
            this.colWorker_id.Width = 80;
            // 
            // colWorker_name
            // 
            this.colWorker_name.DataPropertyName = "hrm1name";
            this.colWorker_name.HeaderText = "姓名";
            this.colWorker_name.Name = "colWorker_name";
            this.colWorker_name.ReadOnly = true;
            this.colWorker_name.Width = 80;
            // 
            // colWork_type_id
            // 
            this.colWork_type_id.DataPropertyName = "work_type_id";
            this.colWork_type_id.HeaderText = "工作類型";
            this.colWork_type_id.Name = "colWork_type_id";
            this.colWork_type_id.ReadOnly = true;
            this.colWork_type_id.Width = 60;
            // 
            // colWork_type_desc
            // 
            this.colWork_type_desc.DataPropertyName = "work_type_desc";
            this.colWork_type_desc.HeaderText = "類型描述";
            this.colWork_type_desc.Name = "colWork_type_desc";
            this.colWork_type_desc.ReadOnly = true;
            this.colWork_type_desc.Width = 80;
            // 
            // colBtnDel
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.colBtnDel.DefaultCellStyle = dataGridViewCellStyle1;
            this.colBtnDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.colBtnDel.HeaderText = "刪除";
            this.colBtnDel.Name = "colBtnDel";
            this.colBtnDel.ReadOnly = true;
            this.colBtnDel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBtnDel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colBtnDel.Width = 60;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(372, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "添加(&A)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "worker_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "工號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "hrm1name";
            this.dataGridViewTextBoxColumn2.HeaderText = "姓名";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "work_type_id";
            this.dataGridViewTextBoxColumn3.HeaderText = "工作類型";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "work_type_desc";
            this.dataGridViewTextBoxColumn4.HeaderText = "類型描述";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "操作";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 60;
            // 
            // frmProductionArrangeWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 289);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.cmbWork_type_id);
            this.Controls.Add(this.lblWork_type_id);
            this.Controls.Add(this.txtWorker_id);
            this.Controls.Add(this.lblWorker_id);
            this.Controls.Add(this.txtArrange_id);
            this.Name = "frmProductionArrangeWorker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProductionArrangeWorker";
            this.Load += new System.EventHandler(this.frmProductionArrangeWorker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtArrange_id;
        private System.Windows.Forms.Label lblWorker_id;
        private System.Windows.Forms.TextBox txtWorker_id;
        private System.Windows.Forms.Label lblWork_type_id;
        private System.Windows.Forms.ComboBox cmbWork_type_id;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorker_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorker_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWork_type_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWork_type_desc;
        private System.Windows.Forms.DataGridViewButtonColumn colBtnDel;
    }
}