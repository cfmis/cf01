namespace cf01.Forms
{
    partial class frmSearchItemMostly
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
            this.dgvItemMostly = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCrusr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCrtim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmusr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmtim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemMostly)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvItemMostly
            // 
            this.dgvItemMostly.AllowUserToAddRows = false;
            this.dgvItemMostly.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemMostly.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colItemName,
            this.colType,
            this.colRemark,
            this.colCrusr,
            this.colCrtim,
            this.colAmusr,
            this.colAmtim});
            this.dgvItemMostly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItemMostly.Location = new System.Drawing.Point(0, 0);
            this.dgvItemMostly.Name = "dgvItemMostly";
            this.dgvItemMostly.RowHeadersWidth = 20;
            this.dgvItemMostly.RowTemplate.Height = 30;
            this.dgvItemMostly.Size = new System.Drawing.Size(743, 497);
            this.dgvItemMostly.TabIndex = 0;
            this.dgvItemMostly.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemMostly_CellDoubleClick);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "id";
            this.colId.HeaderText = "項目類型ID";
            this.colId.Name = "colId";
            // 
            // colItemName
            // 
            this.colItemName.DataPropertyName = "cdesc";
            this.colItemName.HeaderText = "項目類型名稱";
            this.colItemName.Name = "colItemName";
            this.colItemName.Width = 200;
            // 
            // colType
            // 
            this.colType.DataPropertyName = "type";
            this.colType.HeaderText = "類型ID";
            this.colType.Name = "colType";
            this.colType.Width = 70;
            // 
            // colRemark
            // 
            this.colRemark.DataPropertyName = "remark";
            this.colRemark.HeaderText = "備註";
            this.colRemark.Name = "colRemark";
            this.colRemark.Width = 150;
            // 
            // colCrusr
            // 
            this.colCrusr.DataPropertyName = "crusr";
            this.colCrusr.HeaderText = "創建人";
            this.colCrusr.Name = "colCrusr";
            // 
            // colCrtim
            // 
            this.colCrtim.DataPropertyName = "crtim";
            this.colCrtim.HeaderText = "創建時間";
            this.colCrtim.Name = "colCrtim";
            // 
            // colAmusr
            // 
            this.colAmusr.DataPropertyName = "amusr";
            this.colAmusr.HeaderText = "修改人";
            this.colAmusr.Name = "colAmusr";
            // 
            // colAmtim
            // 
            this.colAmtim.DataPropertyName = "amtim";
            this.colAmtim.HeaderText = "修改時間";
            this.colAmtim.Name = "colAmtim";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "項目類型ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "type";
            this.dataGridViewTextBoxColumn2.HeaderText = "類型ID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "cdesc";
            this.dataGridViewTextBoxColumn3.HeaderText = "項目類型名稱";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "remark";
            this.dataGridViewTextBoxColumn4.HeaderText = "備註";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "crusr";
            this.dataGridViewTextBoxColumn5.HeaderText = "創建人";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "crtim";
            this.dataGridViewTextBoxColumn6.HeaderText = "創建時間";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "amusr";
            this.dataGridViewTextBoxColumn7.HeaderText = "修改人";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "amtim";
            this.dataGridViewTextBoxColumn8.HeaderText = "修改時間";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // frmSearchItemMostly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 497);
            this.Controls.Add(this.dgvItemMostly);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchItemMostly";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmSearchItemMostly";
            this.Load += new System.EventHandler(this.frmSearchItemMostly_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemMostly)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvItemMostly;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCrusr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCrtim;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmusr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmtim;
    }
}