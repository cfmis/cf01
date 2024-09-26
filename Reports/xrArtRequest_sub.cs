using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using cf01.CLS;

namespace cf01.Reports
{
    public partial class xrArtRequest_sub : DevExpress.XtraReports.UI.XtraReport
    {
        public xrArtRequest_sub()
        {
            InitializeComponent();
        }
        public void getDetail(string _id, string _ver)
        {
            string sql_f1 = String.Format("SELECT * FROM dbo.se_art_request_details with(nolock) WHERE company_code='{0}' AND art_requ_id='{1}' AND ver ='{2}'","DG",_id,_ver);
            DataTable dtArt_request = clsPublicOfCF01.GetDataTable(sql_f1);
            this.DataSource = dtArt_request;
            //xrlSeq_id.Text =GetCurrentColumnValue("seq_id").ToString();
            //xrlCust_clr_name.Text = GetCurrentColumnValue("cust_clr_name").ToString();
            //xrlClr_cdesc.Text = GetCurrentColumnValue("clr_cdesc").ToString();
        }
    }
}
