namespace cf01.ReportForm
{
	partial class frmFindDataBase
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
			this.cmbFieldList = new System.Windows.Forms.ComboBox();
			this.cmbOpe = new System.Windows.Forms.ComboBox();
			this.txtKeyWord = new System.Windows.Forms.TextBox();
			this.dgvBrand = new System.Windows.Forms.DataGridView();
			this.dgvCustomer = new System.Windows.Forms.DataGridView();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvBrand)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.dgvCustomer);
			this.panel1.Controls.Add(this.cmbFieldList);
			this.panel1.Controls.Add(this.dgvBrand);
			this.panel1.Controls.Add(this.txtKeyWord);
			this.panel1.Controls.Add(this.cmbOpe);
			this.panel1.Size = new System.Drawing.Size(619, 391);
			this.panel1.Controls.SetChildIndex(this.cmbOpe, 0);
			this.panel1.Controls.SetChildIndex(this.txtKeyWord, 0);
			this.panel1.Controls.SetChildIndex(this.dgvBrand, 0);
			this.panel1.Controls.SetChildIndex(this.cmbFieldList, 0);
			this.panel1.Controls.SetChildIndex(this.dgvCustomer, 0);
			// 
			// cmbFieldList
			// 
			this.cmbFieldList.FormattingEnabled = true;
			this.cmbFieldList.Location = new System.Drawing.Point(35, 39);
			this.cmbFieldList.Name = "cmbFieldList";
			this.cmbFieldList.Size = new System.Drawing.Size(121, 20);
			this.cmbFieldList.TabIndex = 1;
			// 
			// cmbOpe
			// 
			this.cmbOpe.FormattingEnabled = true;
			this.cmbOpe.Location = new System.Drawing.Point(188, 39);
			this.cmbOpe.Name = "cmbOpe";
			this.cmbOpe.Size = new System.Drawing.Size(60, 20);
			this.cmbOpe.TabIndex = 1;
			// 
			// txtKeyWord
			// 
			this.txtKeyWord.Location = new System.Drawing.Point(272, 37);
			this.txtKeyWord.Name = "txtKeyWord";
			this.txtKeyWord.Size = new System.Drawing.Size(340, 22);
			this.txtKeyWord.TabIndex = 2;
			// 
			// dgvBrand
			// 
			this.dgvBrand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvBrand.Location = new System.Drawing.Point(4, 71);
			this.dgvBrand.Name = "dgvBrand";
			this.dgvBrand.RowTemplate.Height = 24;
			this.dgvBrand.Size = new System.Drawing.Size(610, 310);
			this.dgvBrand.TabIndex = 3;
			this.dgvBrand.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBrand_CellDoubleClick);
			// 
			// dgvCustomer
			// 
			this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCustomer.Location = new System.Drawing.Point(151, 133);
			this.dgvCustomer.Name = "dgvCustomer";
			this.dgvCustomer.RowTemplate.Height = 24;
			this.dgvCustomer.Size = new System.Drawing.Size(240, 150);
			this.dgvCustomer.TabIndex = 4;
			this.dgvCustomer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomer_CellDoubleClick);
			// 
			// frmFindDataBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(619, 391);
			this.Name = "frmFindDataBase";
			this.Text = "frmFindDataBase";
			this.Load += new System.EventHandler(this.frmFindDataBase_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvBrand)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox cmbFieldList;
		private System.Windows.Forms.ComboBox cmbOpe;
		private System.Windows.Forms.TextBox txtKeyWord;
		private System.Windows.Forms.DataGridView dgvBrand;
		private System.Windows.Forms.DataGridView dgvCustomer;
	}
}