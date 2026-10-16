using cf01.CLS;
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
        //string remote_db = DBUtility.remote_db;        
        clsPublicOfGEO clsErp = new clsPublicOfGEO();       
        DataSet dst = new DataSet();
        //DataTable dtMaster = new DataTable();
        //DataTable dtDetails1 = new DataTable();
        //DataTable dtDetails2 = new DataTable();        


        public frmCombinePart()
        {
            InitializeComponent();            
        }

        private void frmCombinePart_Load(object sender, EventArgs e)
        {
            //SetDataSource();
            ////注册关键事件
            //dgvDetails1.CurrentCellDirtyStateChanged += dgvDetails1_CurrentCellDirtyStateChanged;
            //dgvDetails1.CellValueChanged += dgvDetails1_CellValueChanged;

            // 可选：设置多选模式，允许用户通过 Ctrl/Shift 多选，但这里我们主要靠 CheckBox 控制
            dgvDetails1.MultiSelect = true;
            dgvDetails1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void SetDataSource()
        {
            //dgvMaster.DataSource = dtMaster;
            //dgvDetails1.DataSource = dtDetails1;
            //dgvDetails2.DataSource = dtDetails2;
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            if(txtMo.Text.Trim() != "")
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@mo_id",txtMo.Text.Trim())
                };
                dst = clsErp.ExecuteProcedureReturnDataSet("z_so_order_combine_data", paras, "");
                //dtMaster = dst.Tables[0];
                //dtDetails1 = dst.Tables[1];
                //dtDetails2 = dst.Tables[2];
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
                //dgvMaster.DataSource = dst.Tables[0];
                //dgvDetails1.DataSource = dst.Tables[1];
                dgvDetails2.DataSource = dst.Tables[2];
                //SetDataSource();

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
            //總單頁數信息                    
            rowIndex = dgvMaster.CurrentRow.Index;
            order_qty_sum = Convert.ToInt32(dgvMaster.Rows[rowIndex].Cells["order_qty"].Value);
            st_qty_sum = Convert.ToInt32(dgvMaster.Rows[rowIndex].Cells["qty"].Value);
            st_sec_qty_sum = decimal.Parse(dgvMaster.Rows[rowIndex].Cells["sec_qty"].Value.ToString());



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
    }
}
