namespace cf01.Forms
{
    partial class frmTestInvoiceEditInv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestInvoiceEditInv));
            this.lblID = new System.Windows.Forms.Label();
            this.txtinvoice_id_org = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtinvoice_id_target = new DevExpress.XtraEditors.TextEdit();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtinvoice_id_org.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtinvoice_id_target.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.Location = new System.Drawing.Point(12, 25);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(97, 13);
            this.lblID.TabIndex = 14;
            this.lblID.Text = "原發票編號";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtinvoice_id_org
            // 
            this.txtinvoice_id_org.EditValue = "";
            this.txtinvoice_id_org.EnterMoveNextControl = true;
            this.txtinvoice_id_org.Location = new System.Drawing.Point(115, 19);
            this.txtinvoice_id_org.Name = "txtinvoice_id_org";
            this.txtinvoice_id_org.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtinvoice_id_org.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtinvoice_id_org.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtinvoice_id_org.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtinvoice_id_org.Properties.MaxLength = 20;
            this.txtinvoice_id_org.Properties.ReadOnly = true;
            this.txtinvoice_id_org.Size = new System.Drawing.Size(153, 22);
            this.txtinvoice_id_org.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "更改為當前發票編號";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtinvoice_id_target
            // 
            this.txtinvoice_id_target.EditValue = "";
            this.txtinvoice_id_target.EnterMoveNextControl = true;
            this.txtinvoice_id_target.Location = new System.Drawing.Point(115, 49);
            this.txtinvoice_id_target.Name = "txtinvoice_id_target";
            this.txtinvoice_id_target.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.txtinvoice_id_target.Properties.Appearance.Options.UseBackColor = true;
            this.txtinvoice_id_target.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtinvoice_id_target.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtinvoice_id_target.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtinvoice_id_target.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtinvoice_id_target.Properties.MaxLength = 20;
            this.txtinvoice_id_target.Size = new System.Drawing.Size(153, 22);
            this.txtinvoice_id_target.TabIndex = 16;
            // 
            // btnOk
            // 
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(198, 86);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(70, 33);
            this.btnOk.TabIndex = 17;
            this.btnOk.Text = "確 認  ";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(115, 86);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 33);
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "退 出    ";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmTestInvoiceEditInv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 149);
            this.ControlBox = false;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtinvoice_id_target);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.txtinvoice_id_org);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTestInvoiceEditInv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modify Invoice No.";
            ((System.ComponentModel.ISupportInitialize)(this.txtinvoice_id_org.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtinvoice_id_target.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblID;
        private DevExpress.XtraEditors.TextEdit txtinvoice_id_org;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtinvoice_id_target;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnExit;
    }
}