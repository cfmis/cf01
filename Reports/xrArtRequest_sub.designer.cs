namespace cf01.Reports
{
    partial class xrArtRequest_sub
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrlClr_cdesc = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlCust_clr_name = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlSeq_id = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrlClr_cdesc,
            this.xrlCust_clr_name,
            this.xrlSeq_id});
            this.Detail.HeightF = 18.75F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrlClr_cdesc
            // 
            this.xrlClr_cdesc.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrlClr_cdesc.LocationFloat = new DevExpress.Utils.PointFloat(325.3333F, 0F);
            this.xrlClr_cdesc.Name = "xrlClr_cdesc";
            this.xrlClr_cdesc.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlClr_cdesc.SizeF = new System.Drawing.SizeF(345.2084F, 18F);
            this.xrlClr_cdesc.StylePriority.UseFont = false;
            this.xrlClr_cdesc.Text = "[clr_cdesc]";
            // 
            // xrlCust_clr_name
            // 
            this.xrlCust_clr_name.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrlCust_clr_name.LocationFloat = new DevExpress.Utils.PointFloat(69.45828F, 0F);
            this.xrlCust_clr_name.Name = "xrlCust_clr_name";
            this.xrlCust_clr_name.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlCust_clr_name.SizeF = new System.Drawing.SizeF(248.9583F, 18F);
            this.xrlCust_clr_name.StylePriority.UseFont = false;
            this.xrlCust_clr_name.Text = "[cust_clr_name]";
            // 
            // xrlSeq_id
            // 
            this.xrlSeq_id.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrlSeq_id.LocationFloat = new DevExpress.Utils.PointFloat(24.66661F, 0F);
            this.xrlSeq_id.Name = "xrlSeq_id";
            this.xrlSeq_id.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlSeq_id.SizeF = new System.Drawing.SizeF(42.79166F, 18F);
            this.xrlSeq_id.StylePriority.UseFont = false;
            this.xrlSeq_id.StylePriority.UseTextAlignment = false;
            this.xrlSeq_id.Text = "[seq_id]";
            this.xrlSeq_id.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 0.8333365F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 1.666673F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrArtRequest_sub
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Margins = new System.Drawing.Printing.Margins(41, 95, 1, 2);
            this.Version = "11.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRLabel xrlClr_cdesc;
        private DevExpress.XtraReports.UI.XRLabel xrlCust_clr_name;
        private DevExpress.XtraReports.UI.XRLabel xrlSeq_id;
    }
}
