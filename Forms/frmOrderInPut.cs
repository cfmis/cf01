using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleForm;
using cf01.ModuleClass;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using cf01.MDL;
using cf01.CLS;
namespace cf01.Forms
{
    public partial class frmOrderInPut : BaseFormMaster
    {
        private clsUtility.enumOperationType OperationType;
        private string LockUser = "";

        private List<Mo_for_jx> lsModel = new List<Mo_for_jx>();
        private DataTable dtLock = new DataTable();
        private DataTable dtMoInfo = new DataTable();

        clsCommonUse commUse = new clsCommonUse();

        public frmOrderInPut()
        {
            InitializeComponent();

            //clsPublic objPublic = new clsPublic("frmOrderInPut", this.Controls);
            //objPublic.GenerateData();

            clsControlInfoHelper cls = new clsControlInfoHelper("frmOrderInPut", this.Controls);
            cls.GenerateContorl();
        }
        private void ControlStatus()
        {

            if (toolStrip1.Tag.ToString() == "1")
            {
                this.txtDepartment.ReadOnly = false;
                this.txtMo_id.ReadOnly = false;
                this.cmboxGoods_id.Enabled = true;
                this.masktxtDate.ReadOnly = false;
                this.txtQuantity.ReadOnly = false;
                this.txtRmark.ReadOnly = false;
                this.txtcmpdat.ReadOnly = false;
                txtmould_no.ReadOnly = false;
                txtposition_id.ReadOnly = false;
                txtDo_color.ReadOnly = false;
                txtColor_desc.ReadOnly = false;
            }
            else if (toolStrip1.Tag.ToString() == "2")
            {
                this.txtDepartment.ReadOnly = true;
                this.txtMo_id.ReadOnly = true;
                this.cmboxGoods_id.Enabled = false;
                this.masktxtDate.ReadOnly = true;
                this.txtQuantity.ReadOnly = false;
                this.txtRmark.ReadOnly = false;
                this.txtcmpdat.ReadOnly = false;
                txtmould_no.ReadOnly = false;
                txtposition_id.ReadOnly = false;
                txtDo_color.ReadOnly = false;
                txtColor_desc.ReadOnly = false;
            }
            else if (toolStrip1.Tag.ToString() == "")
            {
                this.txtDepartment.ReadOnly = true;
                this.txtMo_id.ReadOnly = true;
                this.cmboxGoods_id.Enabled = false;
                this.masktxtDate.ReadOnly = true;
                this.txtQuantity.ReadOnly = true;
                this.txtRmark.ReadOnly = true;
                this.txtcmpdat.ReadOnly = true;
                txtposition_id.ReadOnly = true;
                txtposition_id.ReadOnly = true;
                txtDo_color.ReadOnly = true;
                txtColor_desc.ReadOnly = true;
            }
        }

        private void ClearControls()
        {
            //窗体控件状态切换
            //this.txtDepartment.Text = "";
            this.txtMo_id.Text = "";
            this.cmboxGoods_id.Text = "";
            this.cmboxGoods_id.SelectedIndex = -1;
            this.masktxtDate.Text = "";
            this.txtGoods_des.Text = "";
            this.txtRmark.Text = "";
            this.txtQuantity.Text = "";
            this.txtcmpdat.Text = "";
            this.txtchkdat.Text = "";
            this.txtNextDep.Text = "";
            this.txtNextDepName.Text = "";
            this.txtSequence_id.Text = "";
            this.txtOrderQty.Text = "";
            txtmould_no.Text = "";
            txtposition_id.Text = "";
            txtDo_color.Text = "";
            txtColor_desc.Text = "";
            txtver.Text = "";
            txtId.Text = "";
            txtSequence_id.Text = "";
        }

        private void BindToolStripComboBox()
        {
            this.cbxCondition.Items.Add("制單編號");
            this.cbxCondition.Items.Add("物料編號");
        }

        private void BindDataGridView(string strWhere)
        {
            string strSql = null;

            strSql = "Select mo_date, mo_id, wp_id, goods_id ,goods_name, prod_qty, rmk AS remark, cr_usr,chk_dat,order_qty,t_dat,next_wp_id,next_wp_name,color_desc,do_color";
            strSql += ",id,within_code,sequence_id,cr_tim, am_usr, am_tim, ver ";
            strSql += "  FROM mo_for_jx " + strWhere;

            try
            {
                dtMoInfo = clsPublicOfCF01.ExcuteSqlReturnDataSet(strSql, "TB_mo").Tables["TB_mo"];
                this.dgvMoInfo.DataSource = dtMoInfo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
        }

        private void frmOrderInPut_Load(object sender, EventArgs e)
        {
            txtDepartment.MaxLength = 3;
            txtMo_id.MaxLength = 9;
            this.BindToolStripComboBox();
            this.cbxCondition.SelectedIndex = 0;
            toolStrip1.Tag = "";

            MultipleColumnComboBox multiCmbox = new MultipleColumnComboBox();
            multiCmbox.DesignComboBoxColummn(cmboxGoods_id, "goods_id", "goods_name");

            OperationType = clsUtility.enumOperationType.Load;
            clsUtility.EnableToolStripButton(toolStrip1, OperationType);
        }

        public override void New()
        {
            OperationType = clsUtility.enumOperationType.Add;
            toolStrip1.Tag = "1";

            ControlStatus();
            ClearControls();

            clsUtility.EnableToolStripButton(toolStrip1, OperationType);
        }

        public override void Edit()
        {
            if (CheckIsLock())
            {
                OperationType = clsUtility.enumOperationType.Update;
                toolStrip1.Tag = "2";

                ControlStatus();
                //ClearControls();
                txtMo_id.ReadOnly = true;
                txtDepartment.ReadOnly = true;
                cmboxGoods_id.Enabled = false;

                clsUtility.EnableToolStripButton(toolStrip1, OperationType);
            }
        }

        public override void Save()
        {
            if (ValidateInput())
            {
                int Result = -1;

                Mo_for_jx objMode = new Mo_for_jx();
                objMode.mo_date = masktxtDate.Text.Trim();
                objMode.mo_id = txtMo_id.Text.Trim();
                objMode.wp_id = txtDepartment.Text.Trim();
                objMode.goods_id = cmboxGoods_id.Text.Trim();
                objMode.goods_name = txtGoods_des.Text.Trim();
                objMode.rmk = txtRmark.Text.Trim();
                objMode.id = txtId.Text;
                objMode.sequence_id = txtSequence_id.Text;
                objMode.within_code = txtwithin_code.Text;
                if (txtQuantity.Text.Trim() != "")
                    objMode.prod_qty = Convert.ToDecimal(txtQuantity.Text.Trim());
                else
                    objMode.prod_qty = 0;
                objMode.cr_tim = DateTime.Now;
                objMode.cr_usr = DBUtility._user_id;
                objMode.am_tim = DateTime.Now;
                objMode.am_usr = DBUtility._user_id;
                objMode.check_date = txtchkdat.Text;
                if (txtOrderQty.Text.Trim() != "")
                    objMode.order_qty = Convert.ToInt32(txtOrderQty.Text.Trim());
                else
                    objMode.order_qty = 0;
                objMode.next_wp_id = txtNextDep.Text.Trim();
                objMode.next_wp_name = txtNextDepName.Text.Trim();
                objMode.t_complete_date = txtcmpdat.Text.Trim();
                objMode.ver = txtver.Text.Trim();
                objMode.color_desc = txtColor_desc.Text;
                objMode.do_color = txtDo_color.Text;
                switch (OperationType)
                {
                    case clsUtility.enumOperationType.Add:
                        {
                            if (txtDepartment.Enabled == true && txtMo_id.Enabled == true)
                            {
                                try
                                {
                                    Result = clsMo_for_jx.AddMo_for_jx(objMode);
                                    if (Result > 0)
                                    {
                                        dtMoInfo = clsMo_for_jx.GetMo_for_jx(txtMo_id.Text.Trim(), txtDepartment.Text.Trim(), cmboxGoods_id.Text.Trim());
                                        dgvMoInfo.DataSource = dtMoInfo;
                                        dgvMoInfo.Refresh();
                                        txtMo_id.Focus();
                                        toolStrip1.Tag = "";
                                        this.ControlStatus();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            else
                            {
                                MessageBox.Show("请先新增数据，再进行保存操作。");
                            }
                        }
                        break;
                    case clsUtility.enumOperationType.Update:
                        {
                            try
                            {
                                Result = clsMo_for_jx.UpdateMo_for_jx(objMode);
                                if (Result > 0)
                                {
                                    dtMoInfo = clsMo_for_jx.GetMo_for_jx(txtMo_id.Text.Trim(), txtDepartment.Text.Trim(), cmboxGoods_id.Text.Trim());
                                    dgvMoInfo.DataSource = dtMoInfo;
                                    dgvMoInfo.Refresh();
                                    toolStrip1.Tag = "";
                                    this.ControlStatus();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        break;
                    default:
                        break;
                }

                if (Result > 0)
                {
                    OperationType = clsUtility.enumOperationType.Save;
                    clsUtility.EnableToolStripButton(toolStrip1, OperationType);
                }
            }
        }

        public override void Remove()
        {
            if (dgvMoInfo.Rows.Count > 0)
            {
                if (CheckIsLock())
                {
                    if (MessageBox.Show("確認刪除該條數據？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int Result = clsMo_for_jx.DelMo_for_jxLock(txtDepartment.Text.Trim(), txtMo_id.Text.Trim(), cmboxGoods_id.Text.Trim());
                        if (Result > 0)
                        {
                            ClearControls();

                            dtMoInfo = clsMo_for_jx.GetMo_for_jx(txtMo_id.Text.Trim(), txtDepartment.Text.Trim(), cmboxGoods_id.Text.Trim());
                            dgvMoInfo.DataSource = dtMoInfo;
                            dgvMoInfo.Refresh();

                            MessageBox.Show("该条数据已删除。");
                            toolStrip1.Tag = "";
                        }
                    }
                }
            }
        }

        public override void Cancel()
        {

            toolStrip1.Tag = "";
            OperationType = clsUtility.enumOperationType.Cancel;
            ControlStatus();
            ClearControls();

            clsUtility.EnableToolStripButton(toolStrip1, OperationType);
        }

        public bool ValidateInput()
        {
            if (txtMo_id.Text == "")
            {
                MessageBox.Show("請輸入頁數。");
                txtMo_id.Focus();
                return false;
            }

            if (cmboxGoods_id.Text == "")
            {
                MessageBox.Show("請輸入物料編號。");
                txtGoods_des.Focus();
                return false;
            }

            if (txtQuantity.Text == "")
            {
                MessageBox.Show("請輸入數量。");
                txtQuantity.Focus();
                return false;
            }
            if (txtDepartment.Text == "")
            {
                MessageBox.Show("請輸入部門。");
                txtDepartment.Focus();
                return false;
            }

            if (!clsPublic.CheckDate(masktxtDate.Text.Trim()))
            {
                masktxtDate.Focus();
                masktxtDate.SelectAll();
                return false;
            }

            return true;
        }

        private bool CheckIsLock()
        {
            if (dtLock.Rows.Count > 0)
            {
                MessageBox.Show("該條數據已被用戶:" + dtLock.Rows[0]["apr_usr"].ToString() + "鎖定，你無法對其操作，請先解鎖后在試。");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void dgvMoInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolStrip1.Tag.ToString() == "")
            {
                if (dgvMoInfo.Rows.Count > 0)
                {
                    if (e.RowIndex == -1)
                        return;

                    ClearControls();
                    txtMo_id.Text = dtMoInfo.Rows[e.RowIndex]["mo_id"].ToString();
                    cmboxGoods_id.Text = dtMoInfo.Rows[e.RowIndex]["goods_id"].ToString();
                    txtGoods_des.Text = dtMoInfo.Rows[e.RowIndex]["goods_name"].ToString();
                    txtDepartment.Text = dtMoInfo.Rows[e.RowIndex]["wp_id"].ToString();
                    txtQuantity.Text = dtMoInfo.Rows[e.RowIndex]["prod_qty"].ToString();
                    txtRmark.Text = dtMoInfo.Rows[e.RowIndex]["remark"].ToString();
                    masktxtDate.Text = dtMoInfo.Rows[e.RowIndex]["mo_date"].ToString();
                    txtchkdat.Text = dtMoInfo.Rows[e.RowIndex]["chk_dat"].ToString();
                    txtcmpdat.Text = dtMoInfo.Rows[e.RowIndex]["t_dat"].ToString();
                    txtOrderQty.Text = dtMoInfo.Rows[e.RowIndex]["order_qty"].ToString();
                    txtNextDep.Text = dtMoInfo.Rows[e.RowIndex]["next_wp_id"].ToString();
                    txtNextDepName.Text = dtMoInfo.Rows[e.RowIndex]["next_wp_name"].ToString();
                    txtColor_desc.Text = dtMoInfo.Rows[e.RowIndex]["color_desc"].ToString();
                    txtDo_color.Text = dtMoInfo.Rows[e.RowIndex]["do_color"].ToString();
                    txtId.Text = dtMoInfo.Rows[e.RowIndex]["id"].ToString();
                    txtSequence_id.Text = dtMoInfo.Rows[e.RowIndex]["sequence_id"].ToString();
                    txtver.Text = dtMoInfo.Rows[e.RowIndex]["ver"].ToString();
                    GetPosition(cmboxGoods_id.Text);

                    dtLock = clsMo_for_jx.CheckIsLock(txtDepartment.Text.Trim(), txtMo_id.Text.Trim(), cmboxGoods_id.Text.Trim());



                }
            }
        }

        public override void Lock()
        {
            if (CheckIsLock())
            {
                Mo_for_jx objMode = new Mo_for_jx();
                objMode.mo_id = txtMo_id.Text.Trim();
                objMode.wp_id = txtDepartment.Text.Trim();
                objMode.goods_id = cmboxGoods_id.Text.Trim();
                objMode.apr_usr = DBUtility._user_id;
                objMode.apr_tim = DateTime.Now;

                int Result = clsMo_for_jx.UpdateMo_for_jxLock(objMode);
                if (Result > 0)
                {
                    dtLock = clsMo_for_jx.CheckIsLock(txtDepartment.Text.Trim(), txtMo_id.Text.Trim(), cmboxGoods_id.Text.Trim());
                    MessageBox.Show("該條數據已鎖定。");
                }
            }
        }

        public override void Unlock()
        {
            if (dtLock.Rows.Count > 0)
            {
                LockUser = dtLock.Rows[0]["apr_usr"].ToString();
                if (DBUtility._user_id.Trim() == LockUser.Trim())
                {
                    Mo_for_jx objMode = new Mo_for_jx();
                    objMode.mo_id = txtMo_id.Text.Trim();
                    objMode.wp_id = txtDepartment.Text.Trim();
                    objMode.goods_id = cmboxGoods_id.Text.Trim();

                    int Result = clsMo_for_jx.UpdateMo_for_jxLock(objMode);
                    if (Result > 0)
                    {
                        dtLock = clsMo_for_jx.CheckIsLock(txtDepartment.Text.Trim(), txtMo_id.Text.Trim(), cmboxGoods_id.Text.Trim());
                        MessageBox.Show("該條數據已解鎖。");
                    }
                }
                else
                {
                    MessageBox.Show("對不起，你沒有權限解鎖該條數據。");
                }
            }
        }

        private void txtDepartment_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    GetGoodsDetails();
                    break;
            }
        }

        private void txtMo_id_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    GetGoodsDetails();
                    break;
            }
        }

        private void GetGoodsDetails()
        {
            DataTable dtGoodsInfo = clsMo_for_jx.GetGoods_DetailsById(txtDepartment.Text.Trim(), txtMo_id.Text.Trim(), "");
            if (dtGoodsInfo.Rows.Count > 0)
            {
                lsModel.Clear();
                for (int i = 0; i < dtGoodsInfo.Rows.Count; i++)
                {
                    Mo_for_jx objModel = new Mo_for_jx();
                    objModel.wp_id = dtGoodsInfo.Rows[i]["wp_id"].ToString();
                    objModel.mo_id = dtGoodsInfo.Rows[i]["mo_id"].ToString();
                    objModel.goods_id = dtGoodsInfo.Rows[i]["goods_id"].ToString();
                    objModel.goods_name = dtGoodsInfo.Rows[i]["name"].ToString();
                    objModel.prod_qty = (dtGoodsInfo.Rows[i]["prod_qty"].ToString() != "" ? Convert.ToInt32(dtGoodsInfo.Rows[i]["prod_qty"]) : 0);
                    objModel.bill_date = (dtGoodsInfo.Rows[i]["bill_date"].ToString() != "" ? Convert.ToDateTime(dtGoodsInfo.Rows[i]["bill_date"]).ToString("yyyy/MM/dd") : "");
                    objModel.check_date = (dtGoodsInfo.Rows[i]["check_date"].ToString() != "" ? Convert.ToDateTime(dtGoodsInfo.Rows[i]["check_date"]).ToString("yyyy/MM/dd HH:dd") : "");
                    objModel.order_qty = 0;//(dtGoodsInfo.Rows[i]["order_qty"].ToString() != "" ? Convert.ToInt32(dtGoodsInfo.Rows[i]["order_qty"]) : 0);
                    objModel.next_wp_id = dtGoodsInfo.Rows[i]["next_wp_id"].ToString();
                    objModel.next_wp_name = dtGoodsInfo.Rows[i]["next_wp_name"].ToString();
                    objModel.t_complete_date = (dtGoodsInfo.Rows[i]["t_complete_date"].ToString() != "" ? Convert.ToDateTime(dtGoodsInfo.Rows[i]["t_complete_date"]).ToString("yyyy/MM/dd") : "");
                    objModel.ver = (dtGoodsInfo.Rows[i]["ver"].ToString() != "" ? dtGoodsInfo.Rows[i]["ver"].ToString() : "");
                    objModel.id = dtGoodsInfo.Rows[i]["id"].ToString();
                    objModel.sequence_id = dtGoodsInfo.Rows[i]["sequence_id"].ToString();
                    objModel.within_code = dtGoodsInfo.Rows[i]["within_code"].ToString();
                    lsModel.Add(objModel);
                }
                BindcmboxGoodsId();
            }

        }

        void BindcmboxGoodsId()
        {
            if (lsModel.Count > 0)
            {
                DataTable dtcmboxSource = new DataTable();
                dtcmboxSource.Columns.Add(new DataColumn("goods_id", typeof(string)));
                dtcmboxSource.Columns.Add(new DataColumn("goods_name", typeof(string)));
                DataRow dr = null;
                for (int i = 0; i < lsModel.Count; i++)
                {
                    dr = dtcmboxSource.NewRow();
                    dr["goods_id"] = lsModel[i].goods_id;
                    dr["goods_name"] = lsModel[i].goods_name;
                    dtcmboxSource.Rows.Add(dr);
                }

                if (dtcmboxSource.Rows.Count > 0)
                {
                    cmboxGoods_id.DataSource = dtcmboxSource;
                    cmboxGoods_id.DisplayMember = "goods_id";
                    cmboxGoods_id.ValueMember = "goods_name";
                }
            }
        }

        private void txtMo_id_Leave(object sender, EventArgs e)
        {
            GetGoodsDetails();
        }

        private void cmboxGoods_id_SelectedValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < lsModel.Count; i++)
            {
                string strGoodsId = cmboxGoods_id.Text.ToString();
                if (txtDepartment.Text.Trim() == lsModel[i].wp_id && txtMo_id.Text.Trim() == lsModel[i].mo_id && strGoodsId == lsModel[i].goods_id)
                {
                    txtGoods_des.Text = lsModel[i].goods_name;
                    txtQuantity.Text = lsModel[i].prod_qty.ToString();
                    masktxtDate.Text = lsModel[i].bill_date.ToString();
                    txtchkdat.Text = lsModel[i].check_date.ToString();
                    txtcmpdat.Text = lsModel[i].t_complete_date.ToString();
                    txtOrderQty.Text = lsModel[i].order_qty.ToString();
                    txtNextDep.Text = lsModel[i].next_wp_id.ToString();
                    txtNextDepName.Text = lsModel[i].next_wp_name.ToString();
                    txtSequence_id.Text = lsModel[i].next_wp_name.ToString();
                    txtver.Text = lsModel[i].ver;
                    txtId.Text = lsModel[i].id;
                    txtSequence_id.Text = lsModel[i].sequence_id;
                    txtwithin_code.Text = lsModel[i].within_code;
                    GetPosition(strGoodsId);
                    GetColor(txtMo_id.Text, cmboxGoods_id.Text, txtNextDep.Text);
                    GetOrderQty(txtMo_id.Text);
                    break;
                }
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string strWhere = String.Empty;
            string strConditonName = String.Empty;

            strConditonName = this.cbxCondition.Items[this.cbxCondition.SelectedIndex].ToString();
            switch (strConditonName)
            {
                case "制單編號":

                    strWhere = " WHERE mo_id LIKE '%" + txtKeyWord.Text.Trim() + "%'";
                    this.BindDataGridView(strWhere);
                    break;

                case "物料編號":

                    strWhere = " WHERE goods_id LIKE '%" + txtKeyWord.Text.Trim() + "%'";
                    this.BindDataGridView(strWhere);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 獲取模具位置，編號
        /// </summary>
        /// <param name="pGoods_id"></param>
        private void GetPosition(string pGoods_id)
        {
            DataTable dtPosition = clsMo_for_jx.GetPosition(pGoods_id);
            if (dtPosition.Rows.Count > 0)
            {
                txtposition_id.Text = dtPosition.Rows[0]["id"].ToString();
                txtmould_no.Text = dtPosition.Rows[0]["mould_no"].ToString();
            }
        }
        private void GetColor(string mo_id, string goods_id, string next_wp_id)
        {
            txtColor_desc.Text = "";
            txtDo_color.Text = "";
            DataTable dtColor = clsMo_for_jx.GetColor(mo_id, goods_id, next_wp_id);
            if (dtColor.Rows.Count > 0)
            {
                txtColor_desc.Text = dtColor.Rows[0]["color_desc"].ToString();
                txtDo_color.Text = dtColor.Rows[0]["do_color"].ToString();
            }
        }
        private void GetOrderQty(string mo_id)
        {
            txtOrderQty.Text = "";
            DataTable dtQty = clsMo_for_jx.GetOrderQty(mo_id);
            if (dtQty.Rows.Count > 0)
            {
                txtOrderQty.Text = dtQty.Rows[0]["order_qty_pcs"].ToString();
            }
        }


    }
}
