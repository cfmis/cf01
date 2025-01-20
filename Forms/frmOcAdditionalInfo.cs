using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;

namespace cf01.Forms
{
    public partial class frmOcAdditionalInfo : Form
    {
        private clsPublicOfGEO clsGeo = new clsPublicOfGEO();
        private string within_code = DBUtility.within_code;
        public frmOcAdditionalInfo()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            findData();
        }
        private void findData()
        {
            txtAddInfo.Focus();
            if (txtOc.Text == "" && txtMo.Text == "")
                return;

            DataTable dtOc = loadOcData();
            if (dtOc.Rows.Count > 0)
            {
                txtAddInfo.Text = dtOc.Rows[0]["add_info"].ToString().Trim();
            }
            else
            {
                txtAddInfo.Text = "";
            }
        }
        private DataTable loadOcData()
        {
            string oc_id = txtOc.Text;
            string mo_id = txtMo.Text;
            string strSql = " Select a.id,c.add_info " +
                " From so_order_manage a" +
                " Inner Join so_order_details b On a.within_code=b.within_code And a.id=b.id And a.ver=b.ver" +
                " Left Join z_so_order_info c On a.within_code=c.within_code And a.id=c.id " +
                " Where a.within_code='" + within_code + "'";
            if (oc_id != "")
                strSql += " And a.id='" + oc_id + "'";
            if (mo_id != "")
                strSql += " And b.mo_id='" + mo_id + "'";
            DataTable dtOc = clsGeo.GetDataTable(strSql);
            return dtOc;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            DataTable dtOc = loadOcData();
            if(dtOc.Rows.Count==0)
            {
                MessageBox.Show("該OC編號不存在，儲存無效!");
                txtOc.Focus();
                return;
            }
            string id = dtOc.Rows[0]["id"].ToString().Trim();
            string doc_type = "ADD_INFO";
            string add_info = txtAddInfo.Text.Trim();
            string update_by = DBUtility._user_id;
            string update_date = System.DateTime.Now.ToString("yyyy/MM/dd HH:dd:ss");
            string strSql = "Select id From z_so_order_info Where within_code='" + within_code + "' And id='" + id + "'";
            DataTable dtOcInfo = clsGeo.GetDataTable(strSql);

            if (dtOcInfo.Rows.Count == 0)
                strSql = @" Insert Into z_so_order_info (within_code,id,doc_type,add_info,update_by,update_date )" +
                    " Values (" +
                    "@within_code,@id,@doc_type,@add_info,@update_by,GETDATE()"+
                    " )";
            else
                strSql = @"Update z_so_order_info Set add_info=@add_info,update_by=@update_by,update_date=GETDATE()" +
                " Where within_code=@within_code And id=@id And doc_type=@doc_type";
            SqlParameter[] paras = new SqlParameter[]{
                        new SqlParameter("@within_code",within_code),
                        new SqlParameter("@id",id),
                        new SqlParameter("@doc_type",doc_type),
                        new SqlParameter("@add_info",add_info),
                        new SqlParameter("@update_by",update_by),
                        new SqlParameter("@update_date",update_date)
                    };
            //int result = clsGeo.ExecuteSqlUpdate(strSql);
            int result = clsGeo.ExecuteNonQuery(strSql, paras, false);
            if (result == 1)
                MessageBox.Show("儲存OC附加信息成功!");
            else
                MessageBox.Show("儲存OC附加信息失敗!");
        }

        private void txtOc_Leave(object sender, EventArgs e)
        {
            findData();
        }

        private void txtMo_Leave(object sender, EventArgs e)
        {
            findData();
        }

        private void btnGetDetault_Click(object sender, EventArgs e)
        {
            string strSql = " Select a.add_info " +
                " From z_so_order_info a " +
                " Where a.within_code='" + within_code + "' And a.id='" + "ZZZZZZZZ" + "' And a.doc_type='" + "DEFAULT" + "'";


            DataTable dtInfo = clsGeo.GetDataTable(strSql);
            if (dtInfo.Rows.Count > 0)
                txtAddInfo.Text = dtInfo.Rows[0]["add_info"].ToString().Trim();
        }
    }
}
