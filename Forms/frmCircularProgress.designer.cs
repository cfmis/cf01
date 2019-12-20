namespace cf01.Forms
{
    partial class frmCircularProgress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCircularProgress));
            this.lblMessage = new System.Windows.Forms.Label();
            this.progressIndicatorAbout = new ProgressControls.ProgressIndicator();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(105, 44);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(139, 26);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "正在載入.....";
            // 
            // progressIndicatorAbout
            // 
            this.progressIndicatorAbout.Location = new System.Drawing.Point(5, 3);
            this.progressIndicatorAbout.Name = "progressIndicatorAbout";
            this.progressIndicatorAbout.Percentage = 0F;
            this.progressIndicatorAbout.Size = new System.Drawing.Size(100, 100);
            this.progressIndicatorAbout.TabIndex = 0;
            this.progressIndicatorAbout.Text = "progressIndicator1";
            // 
            // frmCircularProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 105);
            this.Controls.Add(this.progressIndicatorAbout);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCircularProgress";
            this.ShowInTaskbar = false;
            this.Text = "About Progress Indicator";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProgressControls.ProgressIndicator progressIndicatorAbout;
        private System.Windows.Forms.Label lblMessage;
    }
}