namespace cf01.Forms
{
    partial class frmQuotationSampleEditNo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuotationSampleEditNo));
            this.txtOriginalNo = new System.Windows.Forms.TextBox();
            this.lblArtwork_path = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.makNewSerialNo = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // txtOriginalNo
            // 
            this.txtOriginalNo.Enabled = false;
            this.txtOriginalNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOriginalNo.Location = new System.Drawing.Point(118, 25);
            this.txtOriginalNo.MaxLength = 15;
            this.txtOriginalNo.Name = "txtOriginalNo";
            this.txtOriginalNo.ReadOnly = true;
            this.txtOriginalNo.Size = new System.Drawing.Size(142, 22);
            this.txtOriginalNo.TabIndex = 0;
            // 
            // lblArtwork_path
            // 
            this.lblArtwork_path.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblArtwork_path.Location = new System.Drawing.Point(14, 27);
            this.lblArtwork_path.Name = "lblArtwork_path";
            this.lblArtwork_path.Size = new System.Drawing.Size(101, 15);
            this.lblArtwork_path.TabIndex = 165;
            this.lblArtwork_path.Text = "Original Serial No.";
            this.lblArtwork_path.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label1.Location = new System.Drawing.Point(14, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 167;
            this.label1.Text = "New Serial No.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(159, 105);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(72, 28);
            this.btnOk.TabIndex = 205;
            this.btnOk.Text = "確定";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::cf01.Properties.Resources.exit;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(79, 105);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 28);
            this.btnClose.TabIndex = 206;
            this.btnClose.Text = "退 出";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // makNewSerialNo
            // 
            this.makNewSerialNo.Location = new System.Drawing.Point(118, 56);
            this.makNewSerialNo.Mask = "999999999999999";
            this.makNewSerialNo.Name = "makNewSerialNo";
            this.makNewSerialNo.Size = new System.Drawing.Size(142, 22);
            this.makNewSerialNo.TabIndex = 207;
            // 
            // frmQuotationSampleEditNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 166);
            this.ControlBox = false;
            this.Controls.Add(this.makNewSerialNo);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblArtwork_path);
            this.Controls.Add(this.txtOriginalNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmQuotationSampleEditNo";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOriginalNo;
        private System.Windows.Forms.Label lblArtwork_path;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.MaskedTextBox makNewSerialNo;
    }
}