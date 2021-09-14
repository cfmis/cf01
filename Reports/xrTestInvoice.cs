namespace cf01.Reports
{
    public partial class xrTestInvoice : DevExpress.XtraReports.UI.XtraReport
    {
        public xrTestInvoice()
        {
            InitializeComponent();           
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if(GetCurrentColumnValue("confirm_ac").ToString()=="True")
            {
                xrCheckBox1.Checked = true;
            }else
            {
                xrCheckBox1.Checked = false;
            }
        }
    }
}
