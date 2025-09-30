namespace cf01.Forms
{
    partial class frmPlanCancel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlanCancel));
            this.txtProduction_remark = new System.Windows.Forms.RichTextBox();
            this.txtMo_id = new System.Windows.Forms.TextBox();
            this.lblMo_id = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTNEXIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BTNSAVE = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.luestate = new DevExpress.XtraEditors.LookUpEdit();
            this.t_state = new System.Windows.Forms.Label();
            this.txtPlate_remark = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.RichTextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luestate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProduction_remark
            // 
            this.txtProduction_remark.Location = new System.Drawing.Point(109, 119);
            this.txtProduction_remark.Name = "txtProduction_remark";
            this.txtProduction_remark.ReadOnly = true;
            this.txtProduction_remark.Size = new System.Drawing.Size(626, 76);
            this.txtProduction_remark.TabIndex = 1;
            this.txtProduction_remark.Text = "";
            // 
            // txtMo_id
            // 
            this.txtMo_id.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMo_id.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtMo_id.Location = new System.Drawing.Point(109, 78);
            this.txtMo_id.MaxLength = 9;
            this.txtMo_id.Name = "txtMo_id";
            this.txtMo_id.Size = new System.Drawing.Size(124, 27);
            this.txtMo_id.TabIndex = 0;
            this.txtMo_id.Leave += new System.EventHandler(this.txtMo_id_Leave);
            // 
            // lblMo_id
            // 
            this.lblMo_id.AutoSize = true;
            this.lblMo_id.Location = new System.Drawing.Point(76, 84);
            this.lblMo_id.Name = "lblMo_id";
            this.lblMo_id.Size = new System.Drawing.Size(29, 12);
            this.lblMo_id.TabIndex = 4;
            this.lblMo_id.Text = "頁數";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "生產備注";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTNEXIT,
            this.toolStripSeparator1,
            this.BTNSAVE,
            this.toolStripSeparator6});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(802, 38);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BTNEXIT
            // 
            this.BTNEXIT.AutoSize = false;
            this.BTNEXIT.Image = global::cf01.Properties.Resources.exit;
            this.BTNEXIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNEXIT.Name = "BTNEXIT";
            this.BTNEXIT.Size = new System.Drawing.Size(71, 35);
            this.BTNEXIT.Text = "退 出 (&X)";
            this.BTNEXIT.Click += new System.EventHandler(this.BTNEXIT_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // BTNSAVE
            // 
            this.BTNSAVE.Image = ((System.Drawing.Image)(resources.GetObject("BTNSAVE.Image")));
            this.BTNSAVE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNSAVE.Name = "BTNSAVE";
            this.BTNSAVE.Size = new System.Drawing.Size(116, 35);
            this.BTNSAVE.Text = "注銷生產計劃(&S)";
            this.BTNSAVE.Click += new System.EventHandler(this.BTNSAVE_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 38);
            // 
            // luestate
            // 
            this.luestate.EditValue = "";
            this.luestate.Location = new System.Drawing.Point(574, 78);
            this.luestate.Name = "luestate";
            this.luestate.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.luestate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.luestate.Properties.Appearance.Options.UseBackColor = true;
            this.luestate.Properties.Appearance.Options.UseFont = true;
            this.luestate.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.luestate.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.luestate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.luestate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luestate.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", 30, "id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", 100, "name")});
            this.luestate.Properties.ImmediatePopup = true;
            this.luestate.Properties.NullText = "";
            this.luestate.Properties.PopupWidth = 130;
            this.luestate.Properties.ReadOnly = true;
            this.luestate.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.luestate.Properties.ShowHeader = false;
            this.luestate.Properties.Tag = "2";
            this.luestate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.luestate.Size = new System.Drawing.Size(160, 28);
            this.luestate.TabIndex = 4;
            // 
            // t_state
            // 
            this.t_state.Location = new System.Drawing.Point(492, 84);
            this.t_state.Name = "t_state";
            this.t_state.Size = new System.Drawing.Size(77, 16);
            this.t_state.TabIndex = 190;
            this.t_state.Tag = "t_state";
            this.t_state.Text = "狀態";
            this.t_state.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPlate_remark
            // 
            this.txtPlate_remark.Location = new System.Drawing.Point(109, 202);
            this.txtPlate_remark.Name = "txtPlate_remark";
            this.txtPlate_remark.ReadOnly = true;
            this.txtPlate_remark.Size = new System.Drawing.Size(626, 76);
            this.txtPlate_remark.TabIndex = 2;
            this.txtPlate_remark.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 192;
            this.label2.Text = "電鍍備注";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 194;
            this.label3.Text = "計劃備注";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(108, 285);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ReadOnly = true;
            this.txtRemark.Size = new System.Drawing.Size(626, 76);
            this.txtRemark.TabIndex = 3;
            this.txtRemark.Text = "";
            // 
            // frmPlanCancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 487);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPlate_remark);
            this.Controls.Add(this.luestate);
            this.Controls.Add(this.t_state);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMo_id);
            this.Controls.Add(this.txtMo_id);
            this.Controls.Add(this.txtProduction_remark);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmPlanCancel";
            this.Text = "frmPlanCancel";
            this.Load += new System.EventHandler(this.frmPlanCancel_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luestate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox txtProduction_remark;
        private System.Windows.Forms.TextBox txtMo_id;
        private System.Windows.Forms.Label lblMo_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTNEXIT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BTNSAVE;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private DevExpress.XtraEditors.LookUpEdit luestate;
        private System.Windows.Forms.Label t_state;
        private System.Windows.Forms.RichTextBox txtPlate_remark;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtRemark;
    }
}