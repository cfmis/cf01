using cf01.CLS;
using cf01.MDL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cf01.Forms
{
    public partial class frmCombinePart : Form
    {      
        clsPublicOfGEO clsErp = new clsPublicOfGEO();       
        DataSet dst = new DataSet();
        DataTable dtTemp = new DataTable();          


        public frmCombinePart()
        {
            InitializeComponent();            
        }

        private void frmCombinePart_Load(object sender, EventArgs e)
        {
            //注册关键事件
            //dgvDetails1.CurrentCellDirtyStateChanged += dgvDetails1_CurrentCellDirtyStateChanged;
            //dgvDetails1.CellValueChanged += dgvDetails1_CellValueChanged;

            // 可选：设置多选模式，允许用户通过 Ctrl/Shift 多选，但这里我们主要靠 CheckBox 控制
            dgvDetails1.MultiSelect = true;
            dgvDetails1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTemp.DataSource = dtTemp;
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            FindData();
        }

        private void FindData()
        {
            if (txtMo.Text.Trim() != "")
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@mo_id",txtMo.Text.Trim())
                };
                dst = clsErp.ExecuteProcedureReturnDataSet("z_so_order_combine_data", paras, "");
                if (dtTemp.Columns.Count == 0)
                {
                    //剛new出來且沒有結構
                    dtTemp = dst.Tables[1].Clone();
                }
             
                //给数据集建立主外键关系
                DataColumn parentColumn = dst.Tables[0].Columns["mo_key"];
                DataColumn childColumn = dst.Tables[1].Columns["mo_key"];
                DataRelation R1 = new DataRelation("R1", parentColumn, childColumn);
                dst.Relations.Add(R1);

                //创建 BindingSource 对象 (建议在窗体类级别声明，或在局部使用)
                BindingSource bsMaster = new BindingSource();
                BindingSource bsDetails = new BindingSource();

                //配置主表 BindingSource
                bsMaster.DataSource = dst;       // 数据源指向整个 DataSet
                bsMaster.DataMember = dst.Tables[0].TableName; // 成员指向主表名 (例如 "Table0" 或你具体的表名)

                //配置从表 BindingSource
                bsDetails.DataSource = bsMaster; // 关键点：从表的数据源指向主表的 BindingSource
                bsDetails.DataMember = "R1";     // 关键点：成员指向 DataRelation 的名称

                //绑定到 DataGridView
                dgvMaster.DataSource = bsMaster;
                dgvDetails1.DataSource = bsDetails;
                dgvDetails2.DataSource = dst.Tables[2];

                if (dst.Tables.Count == 0)
                {
                    MessageBox.Show("查找不到總單頁數的數據！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dgvMaster.Focus();
            }
        }

        /// <summary>
        /// 关键事件：当单元格内容处于“脏”状态（已修改但未提交）时触发
        /// 作用：强制立即提交 CheckBox 的更改，以便后续 CellValueChanged 能获取到最新值
        /// </summary>
        private void dgvDetails1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvDetails1.IsCurrentCellDirty)
            {                
                // 提交当前单元格的编辑状态
                dgvDetails1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        /// <summary>
        /// 单元格值改变事件
        /// 作用：根据 CheckBox 的状态选中或取消选中整行
        /// </summary>
        private void dgvDetails1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // 1.确保操作的是有效行（排除新行 -1）
            if (e.RowIndex < 0)
            {
                return;
            }
            // 2.确保操作的是第一列（CheckBox 列）
            // 建议通过列名判断，比索引更稳健
            if (dgvDetails1.Columns[e.ColumnIndex].Name != "chkSelect")
            {
                return;
            }
            if (dgvMaster.Rows.Count == 0)
            {
                return;
            }
            int rowIndex, order_qty_sum = 0, st_qty_sum = 0, select_order_qty = 0, select_order_qty_sum = 0;
            decimal st_sec_qty_sum = 0, select_sec_qty = 0, select_sec_qty_sum = 0;
            string lot_no = "";
            //總單頁數信息                    
            rowIndex = dgvMaster.CurrentRow.Index;
            order_qty_sum = Convert.ToInt32(dgvMaster.Rows[rowIndex].Cells["order_qty"].Value);
            st_qty_sum = Convert.ToInt32(dgvMaster.Rows[rowIndex].Cells["qty"].Value);
            st_sec_qty_sum = decimal.Parse(dgvMaster.Rows[rowIndex].Cells["sec_qty"].Value.ToString());
            lot_no = dgvMaster.Rows[rowIndex].Cells["lot_no"].Value.ToString();


            //分單勾選中的當前行
            DataGridViewRow row = dgvDetails1.Rows[e.RowIndex];//取當前行，chkSelect列有改動時的行對象
            //總單頁數當前行庫存是0時返回
            if (st_qty_sum == 0)
            {
                row.Selected = false; //取消勾选时：取消选中整行                
                for(int i = 0; i < dst.Tables[1].Rows.Count; i++)
                {
                    if(dst.Tables[1].Rows[i]["mo_id"].ToString() == row.Cells["mo_id1"].Value.ToString() && dst.Tables[1].Rows[i]["goods_id"].ToString() == row.Cells["goods_id1"].Value.ToString())
                    {
                        dst.Tables[1].Rows[i]["flag_select"] = false;                       
                    }
                }
                MessageBox.Show($"注意：總單頁數貨品:{dgvMaster.Rows[rowIndex].Cells["goods_id"].Value.ToString()}目前庫存數(601)為零！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                return;
            }
            // 3.获取 CheckBox 的最新值
            // 注意：使用 EditedFormattedValue 或 Value 均可，因为前面已经 CommitEdit
            bool isChecked = Convert.ToBoolean(row.Cells["chkSelect"].Value);
            select_order_qty = Convert.ToInt32(row.Cells["order_qty1"].Value);
            select_sec_qty = (st_sec_qty_sum * select_order_qty) / st_qty_sum;           
            select_sec_qty = TruncateDecimal(select_sec_qty, 2);

            if (isChecked)
            {
                row.Selected = true;  //勾选时：选中整行              
                if (txtSelect_order_qty.Text == "")
                {
                    row.Cells["sec_qty_select1"].Value = select_sec_qty;
                    select_order_qty_sum = select_order_qty;
                    select_sec_qty_sum = select_sec_qty;
                }
                else
                {
                    row.Cells["sec_qty_select1"].Value = select_sec_qty;
                    select_order_qty_sum = Convert.ToInt32(txtSelect_order_qty.Text) + select_order_qty;
                    select_sec_qty_sum = Convert.ToDecimal(txtSelect_order_sec_qty.Text) + select_sec_qty;
                }
                row.Cells["lot_no1"].Value = lot_no;
            }
            else
            {
                row.Selected = false; //取消勾选时：取消选中整行
                select_order_qty_sum = Convert.ToInt32(txtSelect_order_qty.Text) - select_order_qty;
                select_sec_qty_sum = Convert.ToDecimal(txtSelect_order_sec_qty.Text) - select_sec_qty;
                row.Cells["sec_qty_select1"].Value = 0;
            }
            txtSelect_order_qty.Text = select_order_qty_sum.ToString();
            txtSelect_order_sec_qty.Text = select_sec_qty_sum.ToString();
            //設置主頁數被分配出去的庫存數量、重量
            dgvMaster.Rows[rowIndex].Cells["qty_select"].Value = select_order_qty_sum;
            dgvMaster.Rows[rowIndex].Cells["sec_qty_select"].Value = select_sec_qty_sum;
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 保留幾位小數點(不進行四舍五入處理,直接捨弃)
        /// </summary>
        /// <param name="value">未加工前的原始值</param>
        /// <param name="decimals">保留幾位小數點位數</param>
        /// <returns></returns>
        private decimal TruncateDecimal(decimal value, int decimals)
        {
            decimal multiplier = (decimal)Math.Pow(10, decimals);
            return Math.Truncate(value * multiplier) / multiplier;
        }

        private void btnAddTemp_Click(object sender, EventArgs e)
        {
            if (dgvDetails1.Rows.Count == 0)
            {
                return;
            }
            if (dtTemp.Columns.Count == 0)
            {
                //空結構
                MessageBox.Show("請首先輸入總單頁數拼查詢出數據！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DataRow[] rws = dst.Tables[1].Select("flag_select=true");
            if (rws.Length == 0)
            {
                MessageBox.Show("注意，至少要勾選一筆分單頁數的數據！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            for (int i = 0; i < dst.Tables[0].Rows.Count; i++)
            {
                if (int.Parse(dst.Tables[0].Rows[i]["cnt"].ToString()) > 1)
                {
                    MessageBox.Show($"注意，[{dst.Tables[0].Rows[i]["goods_id"].ToString()}]庫存有多個批號,請用GEO系統轉批號功能將多個批號轉到一個批號中！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dgvMaster.Focus();
                    return;
                }                
                if (Convert.ToInt32(decimal.Parse(dst.Tables[0].Rows[i]["qty"].ToString())) < int.Parse(dst.Tables[0].Rows[i]["qty_select"].ToString()) || 
                    decimal.Parse(dst.Tables[0].Rows[i]["sec_qty"].ToString()) < decimal.Parse(dst.Tables[0].Rows[i]["sec_qty_select"].ToString())
                    )
                {
                    MessageBox.Show($"注意，[{dst.Tables[0].Rows[i]["goods_id"].ToString()}]分配數量或重量已超過庫存的數量或重量！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dgvMaster.Focus();
                    return;
                }
            }

            dst.Tables[1].Select();
            for (int i = 0; i < dst.Tables[1].Rows.Count; i++)
            {
                if (dst.Tables[1].Rows[i]["flag_select"].ToString() == "True" && dst.Tables[1].Rows[i]["flag_add"].ToString() == "False")
                {
                    DataRow row = dst.Tables[1].Rows[i];
                    row["flag_add"] = true;
                    dtTemp.ImportRow(row);
                }                
            }
            //排序
            DataView dv = dtTemp.DefaultView;
            dv.Sort = "goods_id ASC, mo_id ASC";
            dtTemp = dv.ToTable();

            dgvTemp.DataSource = dtTemp;         
            rws = null;
            tabControl1.SelectedIndex = 1;
        }

        private void btnItemDel_Click(object sender, EventArgs e)
        {
            if (dtTemp.Rows.Count == 0)
            {
                return;
            }
            int rowIndex = dgvTemp.CurrentRow.Index;
            if (rowIndex < 0)
            {
                return;
            }
            for (int i = 0; i < dst.Tables[1].Rows.Count; i++)
            {
                if (dst.Tables[1].Rows[i]["n_mo_id"].ToString() == dtTemp.Rows[rowIndex]["n_mo_id"].ToString() && 
                    dst.Tables[1].Rows[i]["mo_id"].ToString() == dtTemp.Rows[rowIndex]["mo_id"].ToString() &&
                    dst.Tables[1].Rows[i]["goods_id"].ToString() == dtTemp.Rows[rowIndex]["goods_id"].ToString())
                {
                    dst.Tables[1].Rows[i]["flag_add"] = false;
                    dst.Tables[1].Rows[i]["flag_select"] = false;
                }
            }
            dtTemp.Rows.RemoveAt(rowIndex);
        }

        private void txtMo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                FindData();
            }
        }

        private void dgvMaster_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMaster.CurrentRow != null)
            {
                int order_qty_sum = 0 ;
                decimal order_sec_qty_sum = 0;               
                for (int i = 0; i < dgvDetails1.Rows.Count; i++)
                {                   
                    if (dgvDetails1.Rows[i].Cells["chkSelect"].Value.ToString() == "True")
                    {
                        order_qty_sum += Convert.ToInt32(Convert.ToDecimal(dgvDetails1.Rows[i].Cells["order_qty1"].Value));
                        order_sec_qty_sum += Convert.ToDecimal(dgvDetails1.Rows[i].Cells["sec_qty_select1"].Value.ToString());                        
                    }
                }
                txtSelect_order_qty.Text = order_qty_sum.ToString();
                txtSelect_order_sec_qty.Text = order_sec_qty_sum.ToString();
            }
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            if (dtTemp.Rows.Count == 0)
            {
                MessageBox.Show("請首先按添加按鈕生成臨時數據！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            mdlCompinePart mdlMostly = new mdlCompinePart();
            mdlMostly.id = "";
            mdlMostly.inventory_date = clsUtility.GetCurrentDateTime().Substring(0,10);
            mdlMostly.ii_location = ""; //轉批號D:.ii_location = "601"
            mdlMostly.state = "0";
            mdlMostly.transfers_state = "0";
            mdlMostly.update_count = "1";
            mdlMostly.create_by = DBUtility._user_id;
            mdlMostly.create_date = clsUtility.GetCurrentDateTime();
            mdlMostly.update_by = mdlMostly.create_by;
            mdlMostly.update_date = mdlMostly.create_date;
            mdlMostly.department_id = "601"; //轉批號DD:.department_id = ""
            mdlMostly.origin = "1";
            mdlMostly.bill_type_no = "01";
            mdlMostly.servername = "hkserver.cferp.dbo";
            mdlMostly.turn_type = "C";  //轉批號DD:.turn_type = "D"


            int index = 0;
            List<mdlCompinePartDetails> lstDetails = new List<mdlCompinePartDetails>();
            for (int i=0;i<dtTemp.Rows.Count;i++)
            {
                index += 1;
                mdlCompinePartDetails mdlDetails = new mdlCompinePartDetails();
                mdlDetails.id = "";
                mdlDetails.sequence_id = clsPublic.GetSequenceID(index); //序號  "0001h";
                mdlDetails.goods_id = dtTemp.Rows[i]["goods_id"].ToString();
                mdlDetails.base_unit = "PCS";
                mdlDetails.unit = "PCS";
                mdlDetails.rate = 1;
                mdlDetails.ib_qty = 0; //轉批號DD:.ib_qty = decimal.Parse(dtTemp.Rows[i]["order_qty"].ToString());
                mdlDetails.i_amount = decimal.Parse(dtTemp.Rows[i]["order_qty"].ToString());//D:i_amount = decimal.Parse(dtTemp.Rows[i]["sec_qty_select"].ToString());
                mdlDetails.mo_id = dtTemp.Rows[i]["mo_id"].ToString();  //分單頁數
                mdlDetails.obligate_mo_id = dtTemp.Rows[i]["n_mo_id"].ToString(); //主單頁數
                mdlDetails.inventory_issuance = "601";
                mdlDetails.ii_code = "601";
                mdlDetails.ii_lot_no = dtTemp.Rows[i]["lot_no"].ToString();
                mdlDetails.inventory_receipt = "601";
                mdlDetails.ir_code = "601";
                mdlDetails.ir_lot_no = dtTemp.Rows[i]["lot_no"].ToString(); ;
                mdlDetails.average_cost = 0; 
                mdlDetails.state = "0";
                mdlDetails.transfers_state = "0";
                mdlDetails.ib_weight= 0; //轉批號DD:ib_weight= decimal.Parse(dtTemp.Rows[i]["sec_qty_select"].ToString());
                mdlDetails.i_weight = decimal.Parse(dtTemp.Rows[i]["sec_qty_select"].ToString()); ;//轉批號DD:.i_weight = mdlDetails.ib_weight;
                mdlDetails.only_detail = "1";
                mdlDetails.goods_id_new = ""; //轉批號DD:.goods_id_new = mdlDetails.goods_id;
                mdlDetails.goods_name_new = ""; //轉批號DD:.goods_name_new = dtTemp.Rows[i]["goods_name"].ToString();
                mdlDetails.sec_unit = ""; //轉批號DD:.sec_unit = "KG";
                lstDetails.Add(mdlDetails);
            }

            string result = clsCombinePart.Save(mdlMostly, lstDetails);
            if (result != "")
            {
                dtTemp.Clear();
                dgvTemp.DataSource = dtTemp;
                MessageBox.Show($"生成R單轉正單【{result}】操作成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHand_id.Text = result;

                //執行自動批準功能
                mdlMostly.id = result;
                result = clsCombinePart.Approve(mdlMostly, DBUtility._user_id, "1", "C");
                if (result.Substring(0, 2) == "00")
                {
                    MessageBox.Show($"【{txtHand_id.Text}】批準成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                FindData();
            }
            else
            {
                MessageBox.Show("生成R單轉正單操作失敗！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
