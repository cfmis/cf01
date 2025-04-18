using cf01.CLS;
using cf01.MDL;
using cf01.ModuleClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cf01.Forms
{
    public partial class frmColorControl : Form
    {
        clsAppPublic clsApp = new clsAppPublic();
        BindingSource bds1 = new BindingSource();
        clsPublicOfGEO clsErp = new clsPublicOfGEO();
        MsgInfo myMsg = new MsgInfo();//實例化Messagegox用到的提示
        DataTable dtDetail = new DataTable();
        DataTable dtTemp = new DataTable();
        DataTable dtBom = new DataTable();
        string pID = "";    //臨時的主鍵值
        string editState = ""; //新增或編號的狀態


        public frmColorControl()
        {
            InitializeComponent();
        }

        private void frmColorControl_Load(object sender, EventArgs e)
        {
            dtDetail = clsSameColorControl.LoadAllData();
            SetGridDataBackgroudColor();
            bds1.DataSource = dtDetail;
            dgvDetails.DataSource = bds1;

            SetDataBindings();
        }

        private void BTNEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNNEW_Click(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count > 0)
            {
                int index = dgvDetails.CurrentRow.Index;
                frmColorControlAdd frmAdd = new frmColorControlAdd(index);// { flagCall = "Quotation" };
                frmAdd.ShowDialog();

                if (frmAdd.insertType == "")
                {
                    return;
                }
                dtTemp = dtDetail.Copy();//還原之用.
                if (frmAdd.insertType == "Bottom")
                {
                    //相當于新的記錄,直接添加至文件尾                    
                    string before_clr = GetBeforeAddBgColorValue();
                    AddNew();
                    txtBgColor.Text = (before_clr == "0") ? "1" : "0"; 
                }
                else
                {                 
                    int addIndex = frmAdd.addIndex;
                    DataGridViewRow dgrw = dgvDetails.CurrentRow;
                    DataRow newRow = dtDetail.NewRow();
                    newRow["input_date"] = dgrw.Cells["input_date"].Value.ToString();
                    newRow["serial_no"] = dgrw.Cells["serial_no"].Value.ToString();
                    newRow["seq_id"] = "";
                    newRow["mo_id"] ="";
                    newRow["sales_group"] = "";
                    newRow["goods_id"] = "";
                    newRow["remark"] = "";
                    newRow["flag_pass"] = false;
                    newRow["flag_color"] = false;
                    newRow["bgcolor"] = dgrw.Cells["bgcolor"].Value.ToString();
                    newRow["row_flag"] = "Y";     //"Y"為當前新添加的行.
                   
                    //當前行的前方或下方插入新行                    
                    dtDetail.Rows.InsertAt(newRow, addIndex);
                    //重新處理排序
                    int temp_seq_id = 0;
                    string str_temp_seq_id = "";
                    string strSerialNo = dgrw.Cells["serial_no"].Value.ToString();
                    for (int i = 0; i < dtDetail.Rows.Count; i++)
                    {
                        if (dtDetail.Rows[i]["serial_no"].ToString() == strSerialNo) //同一顏色控制組別
                        {
                            temp_seq_id += 1;
                            str_temp_seq_id = temp_seq_id.ToString("00");
                            if (dtDetail.Rows[i]["seq_id"].ToString() != str_temp_seq_id)
                            {
                                dtDetail.Rows[i]["seq_id"] = str_temp_seq_id;
                            }
                        }
                    }
                    SetCurrentRowFocus();//定位到當前新添加的行
                    //--start 設定編輯按鈕
                    SetButtonSatus(false);
                    SetObjValue.SetEditBackColor(pnlHead.Controls, true);
                    //dgvDetails.Enabled = false;//禁止修改
                    editState = "NEW";
                    txtSeq_id.Properties.ReadOnly = true;
                    txtSeq_id.BackColor = System.Drawing.Color.White;                  
                    txtID.Properties.ReadOnly = true;
                    txtID.BackColor = System.Drawing.Color.White;
                    dgvDetails.Columns["flag_pass"].ReadOnly = false;
                    dgvDetails.Columns["flag_color"].ReadOnly = false;
                    //--end
                }
            }
            else
            {                
                AddNew();
                txtBgColor.Text = "0";
            }
        }

        private void BTNEDIT_Click(object sender, EventArgs e)
        {
           this.Edit();
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            Save();           
        }

        private void BTNCANCEL_Click(object sender, EventArgs e)
        {
            bds1.CancelEdit();
            dtDetail = dtTemp.Copy();
            bds1.DataSource = dtDetail;
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(pnlHead.Controls, false);
            this.SetObjReadOnly();
            dgvDetails.Enabled = true;
            editState = "";           
        }

        private void BTNDELETE_Click(object sender, EventArgs e)
        {
            Delete();
        }    

        private void SetDataBindings()
        {            
            txtID.DataBindings.Add("Text", bds1, "id");
            txtInput_date.DataBindings.Add("EditValue", bds1, "input_date");
            txtSerialNo.DataBindings.Add("Text", bds1, "serial_no");
            txtSeq_id.DataBindings.Add("Text", bds1, "seq_id");
            txtMo_id.DataBindings.Add("Text", bds1, "mo_id");
            cmbGooidsId.DataBindings.Add("EditValue", bds1, "goods_id");
            txtSalesGroup.DataBindings.Add("Text", bds1, "sales_group");
            txtRemark.DataBindings.Add("Text", bds1, "remark");            
            txtUpdate_by.DataBindings.Add("Text", bds1, "update_by");
            txtUpdate_date.DataBindings.Add("Text", bds1, "update_date");
            txtRow_flag.DataBindings.Add("Text", bds1, "row_flag");
            txtBgColor.DataBindings.Add("Text", bds1, "bgcolor");           
                 
            //復選框的綁定           
            Binding bind = new Binding("EditValue", bds1, "flag_pass");
            bind.Format += (s, e) =>
            {               
                e.Value = e.Value;
            };
            chkFlagPass.DataBindings.Add(bind);
            Binding bindHidden = new Binding("EditValue", bds1, "flag_color");
            bindHidden.Format += (s, e) =>
            {
                e.Value = e.Value;
            };
            chkFlagColor.DataBindings.Add(bindHidden);
        }

        private void AddNew()  //新增
        {
            SetResetID();
            editState = "NEW";
            bds1.AddNew();
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(pnlHead.Controls, true);
            SetObjValue.ClearObjValue(pnlHead.Controls, "1");
            this.SetObjReadOnly();
            //dgvDetails.Enabled = false;
            dgvDetails.Columns["flag_pass"].ReadOnly = false;
            dgvDetails.Columns["flag_color"].ReadOnly = false;
            txtInput_date.EditValue = DateTime.Now.Date.ToString("yyyy-MM-dd").Substring(0, 10);
            txtSerialNo.Text = clsQuotationSample.GetSerialNo();
            txtSeq_id.Text = "01";           
        }

        private void Edit()  //編號
        {
            if (dgvDetails.RowCount == 0)           
            {
                return;
            }
            SetResetID();
            dtTemp = dtDetail.Copy();
            SetButtonSatus(false);
            SetObjValue.SetEditBackColor(pnlHead.Controls, true);
            //dgvDetails.Enabled = false;//禁止修改           
            editState = "EDIT";
            this.SetObjReadOnly();
            dgvDetails.Columns["flag_pass"].ReadOnly = false;
            dgvDetails.Columns["flag_color"].ReadOnly = false;
        }

        private void SetObjReadOnly()
        {           
            txtInput_date.Enabled = false;
            txtInput_date.BackColor = System.Drawing.Color.White;
            txtSeq_id.Properties.ReadOnly = true;
            txtSeq_id.BackColor = System.Drawing.Color.White;
            txtID.Properties.ReadOnly = true;
            txtID.BackColor = System.Drawing.Color.White;
            txtSerialNo.Properties.ReadOnly = true;
            txtSerialNo.BackColor = System.Drawing.Color.White;
            dgvDetails.Columns["flag_pass"].ReadOnly = true;
            dgvDetails.Columns["flag_color"].ReadOnly = true;
        }

        //取消還原到原始記錄位置,要用到pID進行定位
        private void SetResetID()
        {
            if (dgvDetails.Rows.Count > 0)            
            {
                pID = dgvDetails.Rows[dgvDetails.CurrentCell.RowIndex].Cells["id"].Value.ToString();
            }
        }
        private void SetButtonSatus(bool _flag)
        {
            BTNNEW.Enabled = _flag;
            BTNEDIT.Enabled = _flag;           
            BTNDELETE.Enabled = _flag;
            BTNFIND.Enabled = _flag;                                 
            BTNSAVE.Enabled = !_flag;
            BTNCANCEL.Enabled = !_flag;

            clsToolBar obj = new clsToolBar(this.Name, this.Controls);
            obj.SetToolBar();
        }
               
        private bool SaveBeforeValid() //保存前檢查
        {            
            if (txtMo_id.Text == "" || cmbGooidsId.Text == "" || txtInput_date.Text=="" ||txtSalesGroup.Text=="")
            {
                MessageBox.Show("頁數,貨品編碼,日期或組別不可爲空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool CheckSampleColorOnly(string serialNo)
        {
            bool flag = false;
            int cnt = 0;
            DataRow[] drws = dtDetail.Select($"serial_no={serialNo}");
            if (drws.Length == 0)
            {
                flag = false;
            }
            if (drws.Length == 1)
            {
                if (drws[0]["flag_color"].ToString() == "False")
                {
                    flag = false;
                }  
                else
                {
                    flag = true;
                }                                         
            }
            else
            {
                cnt = 0;
                foreach (DataRow item in drws)
                {
                    if (item["flag_color"].ToString() == "True")
                    {
                        cnt += 1;
                    }
                }
                if (cnt > 0)
                {
                    if (cnt == 1)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                else
                {
                    flag = false;
                }
            }
            if (!flag)
            {
                if (cnt > 1)                
                    MessageBox.Show($"注意：編號組別[{serialNo}]中不允許選多個跟辦色頁數!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
                else
                    MessageBox.Show($"注意:編號組別[{serialNo}]中必須指定一個跟辦色頁數!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
                return true;
        }

        public bool HasDuplicate()
        {
            //在修改的值中檢查頁數,貨品是否存在重复值组合
            bool flagRepeat = false;
            string msg = "";
            List<string> lst = new List<string>();
            for (int i = 0; i < dtDetail.Rows.Count; i++)
            {
                if (dtDetail.Rows[i].RowState == DataRowState.Modified || dtDetail.Rows[i].RowState == DataRowState.Added)
                {
                    lst.Add(dtDetail.Rows[i]["mo_id"].ToString() + " ; " + dtDetail.Rows[i]["goods_id"].ToString());
                }                   
            }
            if (lst.Count >= 2)
            {
                var duplicates = lst.GroupBy(n => n)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key)
                .ToList();
                foreach (var item in duplicates)
                {
                    msg = $"頁數,貨品存在重復:[{item}]";
                    MessageBox.Show(msg, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    flagRepeat = true;
                    break;
                }
            }
            return flagRepeat;
        }

        public bool HasDuplicateHistory()
        {
            //檢查是否存在重復的數據（頁數+貨品），當前修改的數據與歷史數據比對
            string sql_f = "", serialNo = "", seqId = "", moId = "", goodsId = "";
            bool flagRepeat = false;
            DataTable dtExists = new DataTable();
            for (int i = 0; i < dtDetail.Rows.Count; i++)
            {
                if (dtDetail.Rows[i].RowState == DataRowState.Modified || dtDetail.Rows[i].RowState == DataRowState.Added)
                {
                    moId = dtDetail.Rows[i]["mo_id"].ToString();
                    goodsId = dtDetail.Rows[i]["goods_id"].ToString();
                    serialNo = dtDetail.Rows[i]["serial_no"].ToString();
                    seqId = dtDetail.Rows[i]["seq_id"].ToString();
                    sql_f = string.Format(@"SELECT serial_no,seq_id From {0}so_order_same_color with(nolock) Where mo_id='{1}' And goods_id='{2}'",
                    DBUtility.remote_db, moId, goodsId);
                    dtExists = clsPublicOfCF01.GetDataTable(sql_f);
                    if (dtExists.Rows.Count > 0)
                    {
                        if (dtExists.Rows[0]["serial_no"].ToString() != serialNo || dtExists.Rows[0]["seq_id"].ToString() != seqId)
                        {
                            MessageBox.Show($"已存在相同的頁數[{moId}]及貨品編碼[{goodsId}]!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            flagRepeat = true;
                            break;
                        }
                    }
                }
            }
            return flagRepeat;
        }

        private void Save()
        {
            txtRemark.Focus();
            if (!SaveBeforeValid())
            {
                return;
            }
            if(!CheckSampleColorOnly(txtSerialNo.Text))
            {
                return;
            }
            if (HasDuplicate())
            {
                return;
            }
            if(HasDuplicateHistory())
            {
                return;
            }

            bds1.EndEdit();//結束修改,立即與綁定數據源一致
            bool save_flag = false,flagPass = false,flagColor = false;
            string sql_i =
            @"INSERT INTO so_order_same_color(serial_no,seq_id,input_date,mo_id,goods_id,sales_group,remark,flag_pass,flag_color,update_by,update_date)
                VALUES(@serial_no,@seq_id,@input_date,@mo_id,@goods_id,@sales_group,@remark,@flag_pass,@flag_color,@user_id,getdate())";
            string sql_u =
            @"UPDATE so_order_same_color 
            SET input_date=@input_date,serial_no=@serial_no,seq_id=@seq_id,mo_id=@mo_id,goods_id=@goods_id,sales_group=@sales_group,
            remark=@remark,flag_pass=@flag_pass,flag_color=@flag_color,update_by=@user_id,update_date=getdate()            
            WHERE id=@id";
            SqlConnection myCon = new SqlConnection(DBUtility.conn_str_dgerp2);
            myCon.Open();
            SqlTransaction myTrans = myCon.BeginTransaction();
            using (SqlCommand myCommand = new SqlCommand() { Connection = myCon, Transaction = myTrans })
            {
                try
                {
                    for (int i = 0; i < dtDetail.Rows.Count; i++)
                    {
                        if (dtDetail.Rows[i].RowState == DataRowState.Modified || dtDetail.Rows[i].RowState == DataRowState.Added)
                        {
                            myCommand.Parameters.Clear();
                            if (dtDetail.Rows[i].RowState == DataRowState.Added)
                            {
                                myCommand.CommandText = sql_i;
                            }
                            else
                            {
                                myCommand.Parameters.AddWithValue("@id", dtDetail.Rows[i]["id"].ToString());
                                myCommand.CommandText = sql_u;                             
                            }
                            myCommand.Parameters.AddWithValue("@input_date", DateTime.Parse(dtDetail.Rows[i]["input_date"].ToString()).Date.ToString("yyyy/MM/dd"));
                            myCommand.Parameters.AddWithValue("@serial_no", dtDetail.Rows[i]["serial_no"].ToString());
                            myCommand.Parameters.AddWithValue("@seq_id", dtDetail.Rows[i]["seq_id"].ToString());                            
                            myCommand.Parameters.AddWithValue("@mo_id", dtDetail.Rows[i]["mo_id"].ToString());
                            myCommand.Parameters.AddWithValue("@goods_id", dtDetail.Rows[i]["goods_id"].ToString());
                            myCommand.Parameters.AddWithValue("@sales_group", dtDetail.Rows[i]["sales_group"].ToString());
                            flagPass = (dtDetail.Rows[i]["flag_pass"].ToString() == "True")? true : false;
                            flagColor = (dtDetail.Rows[i]["flag_color"].ToString() == "True") ? true : false;
                            myCommand.Parameters.AddWithValue("@flag_pass", flagPass);
                            myCommand.Parameters.AddWithValue("@flag_color", flagColor);                           
                            myCommand.Parameters.AddWithValue("@remark", dtDetail.Rows[i]["remark"].ToString());                           
                            myCommand.Parameters.AddWithValue("@user_id", DBUtility._user_id);                          
                            myCommand.ExecuteNonQuery();
                        }
                    }
                    myTrans.Commit(); //數據提交
                    save_flag = true;
                    SetCurrentRowFocus();//定位到當前行
                    //獲取新增的ID號
                    string sql_f = ""; 
                    DataTable dt = new DataTable();
                    for (int i = 0; i < dtDetail.Rows.Count; i++)
                    {
                        if (dtDetail.Rows[i].RowState == DataRowState.Added || dtDetail.Rows[i].RowState == DataRowState.Modified)
                        {
                            sql_f = string.Format(
                            @"Select id,update_by,update_date From {0}so_order_same_color 
                            Where serial_no='{1}' And seq_id='{2}' And sales_group='{3}'", DBUtility.remote_db,
                            dtDetail.Rows[i]["serial_no"].ToString(), dtDetail.Rows[i]["seq_id"].ToString(), dtDetail.Rows[i]["sales_group"].ToString());
                            dt = clsPublicOfCF01.GetDataTable(sql_f);
                            if (dtDetail.Rows[i].RowState == DataRowState.Added)
                            {
                                dtDetail.Rows[i]["id"] = int.Parse(dt.Rows[0]["id"].ToString());                                
                                dgvDetails.Rows[i].Cells["row_flag"].Value = "";//定位結束要去掉標識,避免下次定位錯誤
                            }                            
                            dtDetail.Rows[i]["update_by"] = dt.Rows[0]["update_by"].ToString();
                            dtDetail.Rows[i]["update_date"] = DateTime.Parse(dt.Rows[0]["update_date"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                        }
                    }                   
                    dtDetail.AcceptChanges(); //清除新增或修改的狀態                    
                }
                catch (Exception E)
                {
                    myTrans.Rollback(); //數據回滾
                    save_flag = false;
                    throw new Exception(E.Message);
                }
                finally
                {
                    myCon.Close();
                    myCon.Dispose();
                    myTrans.Dispose();
                }
            }
            SetButtonSatus(true);
            SetObjValue.SetEditBackColor(pnlHead.Controls, false);
            this.SetObjReadOnly();
            dgvDetails.Enabled = true;
            this.editState = "";
            if (save_flag)
            {
                clsUtility.myMessageBox(myMsg.msgSave_ok, myMsg.msgTitle);
            }
            else
            {
                MessageBox.Show(myMsg.msgSave_error, myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void SetCurrentRowFocus()
        {
            //定位到當前行
            for (int i = 0; i < dgvDetails.RowCount; i++)
            {
                if (dgvDetails.Rows[i].Cells["row_flag"].Value.ToString() == "Y")
                {
                    dgvDetails.CurrentCell = dgvDetails.Rows[i].Cells[3]; //设置当前单元格
                    dgvDetails.Rows[i].Selected = true; //選中整行                    
                    break;
                }
            }
        }

        private void dgvDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //產生行號
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvDetails.RowHeadersWidth - 4,
                e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvDetails.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvDetails.RowHeadersDefaultCellStyle.ForeColor = Color.Black,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);


            DataGridView grd = sender as DataGridView;
            if (grd.Rows[e.RowIndex].Cells["bgcolor"].Value.ToString() == "1")
            {
                //特別單價亮藍色背景
                grd.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))); // Color.Gray;
            }
            else
            {
                grd.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }

        }

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {           
        }   

        private void Delete() //刪除當前行
        {
            if (dgvDetails.RowCount == 0 && String.IsNullOrEmpty(txtID.Text))
            {
                return;
            }
            int index = dgvDetails.CurrentRow.Index;
            DialogResult result = MessageBox.Show(myMsg.msgIsDelete, myMsg.msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
               string id = txtID.Text;
               string seq_id = txtSeq_id.Text;
               string rtn = clsSameColorControl.Delete(int.Parse(txtID.Text));              
               if (rtn == "")
               {
                    dtDetail.Rows.RemoveAt(index);
                    bds1.DataSource = dtDetail;
                    dtDetail.AcceptChanges();
                    MessageBox.Show("數據已刪除!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtDetail.AcceptChanges(); //清除新增或修改的狀態  
                }
            }
        }       

        private void SetGridDataBackgroudColor()
        {
            if (dtDetail.Rows.Count > 0)
            {
                string serial_no = dtDetail.Rows[0]["serial_no"].ToString();
                string bgcolor = dtDetail.Rows[0]["bgcolor"].ToString();
                for (int i = 0; i < dtDetail.Rows.Count; i++)
                {
                    if (serial_no != dtDetail.Rows[i]["serial_no"].ToString())//組改變時
                    {
                        if (bgcolor == "0")
                        {
                            dtDetail.Rows[i]["bgcolor"] = "1";
                            bgcolor = "1";
                        }
                        else
                        {
                            dtDetail.Rows[i]["bgcolor"] = "0";
                        }
                    }
                    else
                    {
                        dtDetail.Rows[i]["bgcolor"] = bgcolor;
                    }
                    serial_no = dtDetail.Rows[i]["serial_no"].ToString();
                }
            }
            dtDetail.AcceptChanges();//恢復正常的Rowstate狀態,否則按編輯按鈕時表格背景色會亂
        }

        private string GetBeforeAddBgColorValue()
        {
            string before_add_value = "0";
            if (dgvDetails.Rows.Count > 0)
            {
                int i = dgvDetails.Rows.Count - 1;
                before_add_value = dgvDetails.Rows[i].Cells["bgcolor"].Value.ToString();
            }
            else
            {
                before_add_value = dgvDetails.Rows[0].Cells["bgcolor"].Value.ToString();
            }           
            return before_add_value;
        }

        private void txtMo_id_Leave(object sender, EventArgs e)
        {
            if(editState !="")
            {
                if(txtMo_id.Text == "")
                {
                    return;
                }
                if (txtMo_id.Text.Trim().Length<9)
                {
                    MessageBox.Show("輸入頁數長度共有9位，請返回檢查!", myMsg.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                string sql_f = string.Format(
                @"Select a.seller_id,c.goods_id
                From {0}so_order_manage a,{0}so_order_details b with(nolock), {0}so_order_bom c with(nolock)
                Where a.within_code=b.within_code And a.id=b.id And a.ver=b.ver And
                b.within_code=c.within_code And b.id=c.id And b.ver=c.ver And b.sequence_id=c.upper_sequence And
                b.within_code='0000' And b.mo_id ='{1}' And b.state <>'2' Order by c.primary_key Desc,c.goods_id", 
                DBUtility.remote_db, txtMo_id.Text);
                dtBom = clsPublicOfCF01.GetDataTable(sql_f);
                string moType = txtMo_id.Text.Substring(2, 1);
                string sellerGroup = dtBom.Rows[0]["seller_id"].ToString().Substring(2, 1);
                if (dtBom.Rows.Count > 0)
                {
                    cmbGooidsId.Properties.Items.Clear();
                    for (int i = 0; i < dtBom.Rows.Count; i++)
                    {
                        cmbGooidsId.Properties.Items.Add(dtBom.Rows[i]["goods_id"].ToString());
                    }
                    cmbGooidsId.EditValue = dtBom.Rows[0]["goods_id"].ToString();//默認顯示面件
                    if ("P,F".Contains(moType))
                    {
                        moType = sellerGroup;
                    }
                }
                else
                    moType = "";
                txtSalesGroup.Text = moType;
                if (editState == "NEW")
                {
                    dgvDetails.CurrentRow.Cells["input_date"].Value = txtInput_date.EditValue.ToString();
                    dgvDetails.CurrentRow.Cells["serial_no"].Value = txtSerialNo.Text;
                    dgvDetails.CurrentRow.Cells["seq_id"].Value = txtSeq_id.Text;
                    dgvDetails.CurrentRow.Cells["mo_id"].Value = txtMo_id.Text;
                    dgvDetails.CurrentRow.Cells["goods_id"].Value = cmbGooidsId.EditValue.ToString();
                    dgvDetails.CurrentRow.Cells["sales_group"].Value = txtSalesGroup.Text;
                    dgvDetails.CurrentRow.Cells["flag_pass"].Value = (chkFlagPass.Checked) ? true : false;
                    dgvDetails.CurrentRow.Cells["flag_color"].Value = (chkFlagColor.Checked) ? true : false;
                    dgvDetails.CurrentRow.Cells["remark"].Value = txtRemark.Text;
                    dgvDetails.CurrentRow.Cells["update_by"].Value = txtUpdate_date.Text;
                    int index = dgvDetails.CurrentRow.Index;
                    if (index > 0)
                    {
                        //移動行，新加的行才起作用
                        index = index - 1;                        
                        dgvDetails.Rows[index].Selected = true; //選中整行  
                        dgvDetails.CurrentCell = dgvDetails.Rows[index].Cells[0];
                        dgvDetails.Rows[index + 1].Selected = true; //選中整行
                        dgvDetails.CurrentCell = dgvDetails.Rows[index + 1].Cells[0];
                    }
                }
            }
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            Find();
        }

        private void Find()
        {           
            dtDetail = clsSameColorControl.GetFindData(dtInputDate1.Text, dtInputDate2.Text, txtMoid1.Text, txtMoid2.Text, txtGoodsId1.Text, txtSalesGroup1.Text);        
            SetGridDataBackgroudColor();
            bds1.DataSource = dtDetail;
            dgvDetails.DataSource = bds1;
        }

        private void dgvDetails_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (editState == "")
            {
                return;
            }
            if (dgvDetails.CurrentRow == null)
            {
                return;
            }            
            if (dgvDetails.Columns[e.ColumnIndex].Name == "flag_pass")
            {               
                bool isFlagPass = ((bool)dgvDetails.Rows[e.RowIndex].Cells["flag_pass"].EditedFormattedValue);
                chkFlagPass.Checked = isFlagPass;
            }
            if (dgvDetails.Columns[e.ColumnIndex].Name == "flag_color")
            {
                bool isFlagColor = ((bool)dgvDetails.Rows[e.RowIndex].Cells["flag_color"].EditedFormattedValue);
                chkFlagColor.Checked = isFlagColor;
            }
        }

        private void chkFlagPass_MouseUp(object sender, MouseEventArgs e)
        {
            int index = dgvDetails.CurrentRow.Index;
            dgvDetails.CurrentRow.Cells["flag_pass"].Value = chkFlagPass.Checked;
        }

        private void chkFlagColor_MouseUp(object sender, MouseEventArgs e)
        {
            int index = dgvDetails.CurrentRow.Index;
            dgvDetails.CurrentRow.Cells["flag_color"].Value = chkFlagColor.Checked;
        }
    }
}
