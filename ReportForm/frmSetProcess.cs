using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.CLS;
using cf01.ModuleClass;
using System.Xml;

namespace cf01.ReportForm
{
    public partial class frmSetProcess : Form
    {
        readonly MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示
        DataTable dtProcess_list = new DataTable();
        public frmSetProcess(string pDept, string pMat_goods, string pMat_goods_desc, string pGoods_id,
            string pGoods_id_desc, Boolean pisSave,string pNext_dept,string pNext_dept_name,string pProcess_group_id)
        {
            InitializeComponent();

            txtDept.Text = pDept;
            txtMat_goods.Text = pMat_goods;
            txtMat_goods_desc.Text = pMat_goods_desc;
            txtGoods_id.Text = pGoods_id;
            txtGoods_id_desc.Text = pGoods_id_desc;
            BTNSAVE.Enabled = pisSave;
            txtNext_dept.Text = pNext_dept;
            txtNext_dept_name.Text = pNext_dept_name;
            txtProcess_group_id.Text = pProcess_group_id;
        }

        private void frmSetProcess_Load(object sender, EventArgs e)
        {
            //檢查下部門貨品是否存在工序對照
            if (string.IsNullOrEmpty(txtProcess_group_id.Text))
            {
                DataTable dtProcess = clsMo_for_jx.Get_Process_Data(txtDept.Text, txtGoods_id.Text);
                if (dtProcess.Rows.Count > 0)
                {
                    txtProcess_desc.Text =
                        String.Format("{0} | {1} | {2} | {3}",
                        dtProcess.Rows[0]["cdesc"],  //因包含一空格行，所以ROWS(1)爲默認顯示的行
                        dtProcess.Rows[0]["goods_size"],
                        dtProcess.Rows[0]["process_color"],
                        dtProcess.Rows[0]["artwork_shape"]);
                    txtProcess_group_id.Text = dtProcess.Rows[0]["id"].ToString();
                    dgvDetails.DataSource = clsMo_for_jx.Get_Process_List(txtDept.Text, txtProcess_group_id.Text);
                }
            }
            else
            {
                Set_process();
            }
            
            DataTable dtAA = clsMo_for_jx.Get_Process_AA();
            txtAA.Properties.DataSource = dtAA;
            txtAA.Properties.ValueMember = "id";
            txtAA.Properties.DisplayMember = "id";
            DataTable dtBB = clsMo_for_jx.Get_Process_BB();
            txtBB.Properties.DataSource = dtBB;
            txtBB.Properties.ValueMember = "id";
            txtBB.Properties.DisplayMember = "id";
            DataTable dtCC = clsMo_for_jx.Get_Process_CC();
            txtCC.Properties.DataSource = dtCC;
            txtCC.Properties.ValueMember = "id";
            txtCC.Properties.DisplayMember = "id";

            string strGoods = txtGoods_id.Text;
            if (!string.IsNullOrEmpty(strGoods))
            {
                string strProdType = strGoods.Substring(2, 2);
                string strSizeType = strGoods.Substring(11, 3);
                string strClrType = strGoods.Substring(14, 4);

                string sql_AA = string.Format(@"SELECT ISNULL(prss_type,'') AS prss_type  FROM bs_process_type_prod with(nolock) WHERE prd_type='{0}'", strProdType);
                string sql_BB = string.Format(@"SELECT ISNULL(size_id,'') AS id,size_min,size_max FROM bs_process_type_size with(nolock) WHERE '{0}' >=size_min AND '{0}'<size_max ", strSizeType);//, strSizeType);
                string sql_CC = string.Format(@"SELECT grind_id AS id FROM bs_process_type_color with(nolock) WHERE color_id='{0}' group by grind_id", strClrType);
                txtAA.EditValue = clsPublicOfCF01.ExecuteSqlReturnObject(sql_AA);
                txtBB.EditValue = clsPublicOfCF01.ExecuteSqlReturnObject(sql_BB);
                txtCC.EditValue = clsPublicOfCF01.ExecuteSqlReturnObject(sql_CC);
                string strProcess = txtProcess_group_id.Text;
                if (!string.IsNullOrEmpty(strProcess))
                {
                    txtDD.Text = strProcess.Substring(8, 1); //凹凸字
                }
                else
                {
                    txtDD.Text = "A";
                }
            }
        }
        
        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {  
            if (string.IsNullOrEmpty(txtAA.Text) ||
              string.IsNullOrEmpty(txtBB.Text) ||
              string.IsNullOrEmpty(txtCC.Text) ||
              string.IsNullOrEmpty(txtDD.Text))
            {
                MessageBox.Show("該工序組合不可以有空格,請返回檢查!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtAA.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtProcess_group_id.Text))
            {
                MessageBox.Show("該工序編號爲空，不可保存,請返回檢查!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtAA.Focus();
                return;
            }
                        
            DataTable dt = clsMo_for_jx.Get_process_group_id(txtDept.Text, txtProcess_group_id.Text);
            if (dt.Rows.Count==0)
            {
                MessageBox.Show("該工序組別編號幷不存在!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtProcess_desc.Text = "";
                return;
            }
            clsMo_for_jx.Save_Process_Data(txtDept.Text, txtMat_goods.Text, txtGoods_id.Text,txtProcess_group_id.Text);
            frmOrderProCard.strProcess = txtProcess_group_id.Text;
            this.Close();
        }

        private void Splice_string()
        {            
            if (!string.IsNullOrEmpty(txtAA.Text) &&
               !string.IsNullOrEmpty(txtBB.Text) &&
               !string.IsNullOrEmpty(txtCC.Text) &&
               !string.IsNullOrEmpty(txtDD.Text))
            {
                txtProcess_group_id.Text = String.Format("{0}-{1}-{2}-{3}", txtAA.EditValue, txtBB.EditValue, txtCC.EditValue, txtDD.Text.Trim());
                Set_process();
            }
        }

        private void Set_process()
        {
            DataTable dt = clsMo_for_jx.Get_process_group_id(txtDept.Text, txtProcess_group_id.Text);
            if (dt.Rows.Count > 0)
            {
                txtProcess_desc.Text =
                String.Format("{0} | {1} | {2} | {3}",
                dt.Rows[0]["cdesc"],
                dt.Rows[0]["goods_size"],
                dt.Rows[0]["process_color"],
                dt.Rows[0]["artwork_shape"]);
                dgvDetails.DataSource = clsMo_for_jx.Get_Process_List(txtDept.Text, txtProcess_group_id.Text);
            }
            else
            {
                MessageBox.Show("該工序組別編號不存在!","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Exclamation); 
                txtProcess_desc.Text = "";
            }
        }

        private void txtAA_EditValueChanged(object sender, EventArgs e)
        {
            Splice_string();
        }

        private void txtBB_EditValueChanged(object sender, EventArgs e)
        {
            Splice_string();
        }

        private void txtCC_EditValueChanged(object sender, EventArgs e)
        {
            Splice_string();
        }

        private void txtDD_EditValueChanged(object sender, EventArgs e)
        {
            Splice_string();
        }

        private void txtProcess_group_id_TextChanged(object sender, EventArgs e)
        {
           DataTable dt= clsMo_for_jx.GetSet_Process_Data(txtDept.Text, txtMat_goods.Text, txtGoods_id.Text);
           if (dt.Rows.Count > 0)
           {
               txtRemark.Text = dt.Rows[0]["remark"].ToString();
           }
           else
           {
               txtRemark.Text = "";
           }           
        }


       
    }
}
