namespace cf01.Forms
{
    partial class frmArrangeMoAdd
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
            this.lblPrd_dept = new System.Windows.Forms.Label();
            this.cmbArrDep = new System.Windows.Forms.ComboBox();
            this.datArrDateFrom = new System.Windows.Forms.DateTimePicker();
            this.datArrDateTo = new System.Windows.Forms.DateTimePicker();
            this.btnConfig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPrd_dept
            // 
            this.lblPrd_dept.AutoSize = true;
            this.lblPrd_dept.Location = new System.Drawing.Point(65, 68);
            this.lblPrd_dept.Name = "lblPrd_dept";
            this.lblPrd_dept.Size = new System.Drawing.Size(63, 14);
            this.lblPrd_dept.TabIndex = 24;
            this.lblPrd_dept.Text = "生產部門";
            // 
            // cmbArrDep
            // 
            this.cmbArrDep.FormattingEnabled = true;
            this.cmbArrDep.Location = new System.Drawing.Point(130, 65);
            this.cmbArrDep.Name = "cmbArrDep";
            this.cmbArrDep.Size = new System.Drawing.Size(109, 21);
            this.cmbArrDep.TabIndex = 25;
            // 
            // datArrDateFrom
            // 
            this.datArrDateFrom.Location = new System.Drawing.Point(130, 106);
            this.datArrDateFrom.Name = "datArrDateFrom";
            this.datArrDateFrom.Size = new System.Drawing.Size(200, 23);
            this.datArrDateFrom.TabIndex = 26;
            // 
            // datArrDateTo
            // 
            this.datArrDateTo.Location = new System.Drawing.Point(130, 161);
            this.datArrDateTo.Name = "datArrDateTo";
            this.datArrDateTo.Size = new System.Drawing.Size(200, 23);
            this.datArrDateTo.TabIndex = 27;
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(333, 248);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(75, 23);
            this.btnConfig.TabIndex = 28;
            this.btnConfig.Text = "確定(&C)";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // frmArrangeMoAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 426);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.datArrDateTo);
            this.Controls.Add(this.datArrDateFrom);
            this.Controls.Add(this.lblPrd_dept);
            this.Controls.Add(this.cmbArrDep);
            this.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Name = "frmArrangeMoAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmArrangeMoAdd";
            this.Load += new System.EventHandler(this.frmArrangeMoAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPrd_dept;
        private System.Windows.Forms.ComboBox cmbArrDep;
        private System.Windows.Forms.DateTimePicker datArrDateFrom;
        private System.Windows.Forms.DateTimePicker datArrDateTo;
        private System.Windows.Forms.Button btnConfig;
    }
}