namespace cf01.Forms
{
    partial class frmSetOcUnusual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetOcUnusual));
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.txtMo_id = new System.Windows.Forms.TextBox();
            this.lblMo_id = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAbnormal = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(257, 240);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(91, 29);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "退出(&X)";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(428, 240);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 29);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "    保存(&Y)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(109, 60);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(626, 134);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // txtMo_id
            // 
            this.txtMo_id.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo_id.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMo_id.Location = new System.Drawing.Point(109, 21);
            this.txtMo_id.MaxLength = 9;
            this.txtMo_id.Name = "txtMo_id";
            this.txtMo_id.Size = new System.Drawing.Size(124, 27);
            this.txtMo_id.TabIndex = 0;
            this.txtMo_id.Leave += new System.EventHandler(this.txtMo_id_Leave);
            // 
            // lblMo_id
            // 
            this.lblMo_id.AutoSize = true;
            this.lblMo_id.Location = new System.Drawing.Point(76, 24);
            this.lblMo_id.Name = "lblMo_id";
            this.lblMo_id.Size = new System.Drawing.Size(29, 12);
            this.lblMo_id.TabIndex = 4;
            this.lblMo_id.Text = "頁數";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "生產備注";
            // 
            // chkAbnormal
            // 
            this.chkAbnormal.AutoSize = true;
            this.chkAbnormal.Location = new System.Drawing.Point(315, 20);
            this.chkAbnormal.Name = "chkAbnormal";
            this.chkAbnormal.Size = new System.Drawing.Size(72, 16);
            this.chkAbnormal.TabIndex = 1;
            this.chkAbnormal.Text = "異常制單";
            this.chkAbnormal.UseVisualStyleBackColor = true;
            // 
            // frmSetOcUnusual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 400);
            this.Controls.Add(this.chkAbnormal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMo_id);
            this.Controls.Add(this.txtMo_id);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmSetOcUnusual";
            this.Text = "frmSetOcUnusual";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox txtMo_id;
        private System.Windows.Forms.Label lblMo_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAbnormal;
    }
}