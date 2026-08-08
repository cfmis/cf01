using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using cf01.MM;

namespace cf01.Forms
{
    public partial class frmMoScheduleDepGroup : Form
    {
        public static string prd_group = "";
        public frmMoScheduleDepGroup()
        {
            InitializeComponent();
        }

        private void frmMoScheduleDepGroup_Load(object sender, EventArgs e)
        {
            InitData();
            //FindData();
        }
        private void InitData()
        {
            dgvDetails.AutoGenerateColumns = false;
            DataTable dtDep=clsBaseData.loadDep();
            lueDep.Properties.DataSource = dtDep;
            lueDep.Properties.ValueMember = "dep_id";
            lueDep.Properties.DisplayMember = "dep_cdesc";

            lueFindDep.Properties.DataSource = dtDep;
            lueFindDep.Properties.ValueMember = "dep_id";
            lueFindDep.Properties.DisplayMember = "dep_cdesc";
        }

        private void btnConf_Click(object sender, EventArgs e)
        {
            prd_group = lueDep.EditValue != null ? lueDep.EditValue.ToString().Trim() : "";
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            txtFindItem.Focus();
            Save();
        }
        private void Save()
        {
            if (!ValidData())
                return;
            string prd_dep = lueDep.EditValue != null ? lueDep.EditValue.ToString().Trim() : "";
            string prd_item = txtPrdItem.Text;
            string prd_group = txtPrdGroup.Text;
            string prd_machine = txtPrdMachine.Text;
            string prd_mo = txtPrdMo.Text;
            string prd_worker = txtPrdWorker.Text;
            int hour_run_num = txtRunNum.Text != "" ? Convert.ToInt32(txtRunNum.Text) : 0;
            int line_num = txtLineNum.Text != "" ? Convert.ToInt32(txtLineNum.Text) : 0;
            int hour_std_qty = txtStdQty.Text != "" ? Convert.ToInt32(txtStdQty.Text) : 0;
            string user_id = DBUtility._user_id;
            string now_date = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string imput_type = "1";
            string strSql = "", strSql1 = "";
            if (!GetGoods(prd_dep, prd_item))
            {
                strSql1 = @" Insert Into bs_dep_goods_group (dep_id,goods_id,prd_group,prd_machine,hour_run_num,line_num,hour_std_qty" +
                    ",prd_worker,prd_mo,create_user,create_time,update_user,update_time,imput_type )" +
                    " Values ( " +
                    "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{9}','{10}','{11}'" +
                    ")";
            }

            else
            {
                strSql1 = @" Update bs_dep_goods_group Set " +
                    "prd_group='{2}',prd_machine='{3}',hour_run_num='{4}',line_num='{5}',hour_std_qty='{6}'" +
                    ",prd_worker='{7}',prd_mo='{8}',update_user='{9}',update_time='{10}',imput_type='{11}' " +
                    " Where dep_id='{0}' And goods_id='{1}'";
            }
            strSql += string.Format(strSql1
                , prd_dep, prd_item, prd_group, prd_machine, hour_run_num, line_num, hour_std_qty, prd_worker, prd_mo
                , user_id, now_date, imput_type
                );
            string result = "";
            result = clsPublicOfCF01.ExecuteSqlUpdate(strSql);
            if(result=="")
            {
                FindData();
                MessageBox.Show("儲存成功!");
            }
            else
            {
                MessageBox.Show("儲存失敗!");
            }
        }
        private bool GetGoods(string prd_dep,string prd_item)
        {
            bool flag = false;
            string strSql = " Select goods_id From bs_dep_goods_group Where dep_id='" + prd_dep + "' And goods_id='" + prd_item + "'";
            DataTable dtGoods = clsPublicOfCF01.GetDataTable(strSql);
            if (dtGoods.Rows.Count > 0)
                flag = true;
            return flag;
        }
        private bool ValidData()
        {
            if(lueDep.EditValue.ToString() == "")
            {
                MessageBox.Show("部門編號不能為空!");
                lueDep.Focus();
                return false;
            }
            if (txtPrdItem.Text == "")
            {
                MessageBox.Show("物料編號不能為空!");
                txtPrdItem.Focus();
                return false;
            }
            return true;
        }

        private void txtRunNum_Leave(object sender, EventArgs e)
        {
            CountStdQty();
        }
        private void txtLineNum_Leave(object sender, EventArgs e)
        {
            CountStdQty();
        }
        private void CountStdQty()
        {
            int hour_run_num = 0;
            int line_num = 0;
            int std_qty = 0;
            hour_run_num = txtRunNum.Text != "" ? Convert.ToInt32(txtRunNum.Text) : 0;
            line_num = txtLineNum.Text != "" ? Convert.ToInt32(txtLineNum.Text) : 0;
            txtStdQty.Text = (hour_run_num * line_num).ToString();
        }

        private void txtPrdItem_Leave(object sender, EventArgs e)
        {
            string goods_id = txtPrdItem.Text;
            string strSql = " Select name From geo_it_goods Where id='" + goods_id + "'";
            DataTable dtGoods = clsPublicOfCF01.GetDataTable(strSql);
            if (dtGoods.Rows.Count > 0)
                txtPrdItemCdesc.Text = dtGoods.Rows[0]["name"].ToString();
            else
                txtPrdItemCdesc.Text = "";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtPrdItem.Text = "";
            txtPrdItemCdesc.Text = "";
            txtRunNum.Text = "";
            txtLineNum.Text = "1";
            txtStdQty.Text = "";
            txtPrdMachine.Text = "";
            txtPrdWorker.Text = "";
            txtPrdMo.Text = "";
            txtPrdGroup.Text = "";
            txtPrdItem.Focus();
        }

        private void txtPrdWorker_Leave(object sender, EventArgs e)
        {
            if (txtPrdWorker.Text.Trim() != "")
                txtPrdWorker.Text = txtPrdWorker.Text.PadLeft(10, '0');
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FindData();
        }
        private void FindData()
        {
            string prd_dep = lueFindDep.EditValue.ToString();
            string prd_item = txtFindItem.Text;
            string strSql = " Select a.dep_id,a.goods_id,b.name AS goods_cname,a.prd_group,a.hour_run_num,a.line_num,a.hour_std_qty,a.prd_machine,a.prd_worker,a.prd_mo" +
                " From bs_dep_goods_group a"+
                " Left Join geo_it_goods b On a.goods_id=b.id "+
                " Where a.dep_id>=''";
            if (prd_dep == "" && prd_item == "")
            {
                string now_date = System.DateTime.Now.ToString("yyyy/MM/dd");
                strSql += " And a.create_time>='" + now_date + "'";
            }
            if (prd_dep != "")
                strSql += " And a.dep_id='" + prd_dep + "'";
            if (prd_item != "")
                strSql += " And a.goods_id Like '%" + prd_item + "%'";
            strSql += " Order By a.dep_id,a.goods_id";
            DataTable dtDepGoods = clsPublicOfCF01.GetDataTable(strSql);
            dgvDetails.DataSource = dtDepGoods;
            if (dtDepGoods.Rows.Count == 0)
                MessageBox.Show("沒有找到記錄!");
        }

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dgvDetails.CurrentRow;
            if (currentRow != null)
            {
                // 例如获取某一列的值
                lueDep.EditValue = currentRow.Cells["colDepId"].Value.ToString();
                txtPrdItem.Text = currentRow.Cells["colPrdItem"].Value.ToString();
                txtPrdItemCdesc.Text = currentRow.Cells["colPrdItemCdesc"].Value.ToString();
                txtPrdGroup.Text = currentRow.Cells["colPrdGroup"].Value.ToString();
                txtRunNum.Text = currentRow.Cells["colHourRunNum"].Value.ToString();
                txtLineNum.Text = currentRow.Cells["colLineNum"].Value.ToString();
                txtStdQty.Text = currentRow.Cells["colHourStdQty"].Value.ToString();
                txtPrdMachine.Text = currentRow.Cells["colPrdMachine"].Value.ToString();
                txtPrdWorker.Text = currentRow.Cells["colPrdWorker"].Value.ToString();
                txtPrdMo.Text = currentRow.Cells["colPrdMo"].Value.ToString();
            }

        }

        private void btnSetGoodsWeight_Click(object sender, EventArgs e)
        {
            frmSetProductWeight.getProductId = txtPrdItem.Text;
            frmSetProductWeight frm = new frmSetProductWeight();
            frm.ShowDialog();
            frm.Dispose();
        }
    }
}
