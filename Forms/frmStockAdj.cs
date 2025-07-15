using cf01.CLS;
using cf01.MDL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace cf01.Forms
{
    public partial class frmStockAdj : Form
    {
        private static clsPublicOfGEO clsConErp = new clsPublicOfGEO();
        DataTable dtAdj = new DataTable();
        DataTable dtAdjTemp = new DataTable();
        DataTable dtStlotno = new DataTable();
        DataTable dtSt = new DataTable();
        DataTable dtAdjUpdate = new DataTable();

        public frmStockAdj()
        {
            InitializeComponent();            
        }

        private void frmStockAdj_Load(object sender, EventArgs e)
        {            
            dgv1.DataSource = dtAdj;
        }   

        private void btnExit_Click(object sender, EventArgs e)
        {           
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (dgv2.Rows.Count > 0)
            {
                //權限檢查
                string locationId = txtDept.Text.Trim();
                if(locationId == "")
                {
                    MessageBox.Show("倉庫編號不可為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string userId = DBUtility._user_id;
                if (userId == "")
                {
                    MessageBox.Show("登入用戶不可為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string strSql = $"Select location_id From cd_storehouse_popedom Where within_code='0000' And user_id = '{userId}' And location_id ='{locationId}'";
                if(userId.ToUpper() != "ADMIN")
                {
                    if (clsConErp.ExecuteSqlReturnObject(strSql) == "")
                    {
                        MessageBox.Show($"當前用戶【{userId}】沒有倉庫【{locationId}】的操作權限!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (MessageBox.Show($"確認要對【{locationId}】倉進行批量庫存調整？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                if (dtSt.Rows.Count > 0)
                {
                    MessageBox.Show($"請首先清空GEO中【{txtDept.Text}】倉的庫存!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //是示查詢進度
                frmProgress wForm = new frmProgress();
                new Thread((ThreadStart)delegate
                {
                    wForm.TopMost = true;
                    wForm.ShowDialog();
                }).Start();
                //*********
                string result = StockAdj();
                //*********
                wForm.Invoke((EventHandler)delegate { wForm.Close(); });
                
                if (result.Substring(0, 2) == "00")
                {
                    //批準庫存調整數據及批準成功
                    MessageBox.Show("庫存批量自動調整成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FindData();
                    dgv1.Visible = true;
                    dgv2.Visible = false;
                    dtAdjTemp.Clear();
                    dtAdjUpdate.Clear();
                }
                else
                {
                    MessageBox.Show("庫存批量自動調整失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("請首先生成調整差額數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string StockAdj()
        {
            string locationId = txtDept.Text.Trim();     
            st_adjustment_mostly headData = new st_adjustment_mostly();
            headData.id = clsTransferout.GetMaxIDStock("ST02", 4);
            headData.department_id = locationId;
            headData.date = DateTime.Now.Date.ToString("yyyy/MM/dd");
            headData.mode = "1";
            headData.state = "0";
            headData.transfers_state = "0";
            headData.update_count = "1";
            headData.create_by = DBUtility._user_id;
            headData.servername = "hkserver.cferp.dbo";
            headData.adjust_reason = "12";
            headData.head_status = "NEW";
            string lotNo = "";
            List<st_a_subordination> lstDetailData1 = new List<st_a_subordination>();
            for (int i = 0; i < dtAdjUpdate.Rows.Count; i++)
            {
                if (dtAdjUpdate.Rows[i]["flag_del"].ToString() == "Y")
                {
                    continue;
                }
                else
                {
                    st_a_subordination lstMd = new st_a_subordination();
                    lstMd.id = headData.id;
                    lstMd.sequence_id = ""; //dtAdjUpdate.Rows[i]["sequence_id"].ToString();
                    lstMd.mo_id = dtAdjUpdate.Rows[i]["mo_id"].ToString();
                    lstMd.goods_id = dtAdjUpdate.Rows[i]["goods_id"].ToString();
                    lstMd.goods_name = "";
                    lstMd.color = "";
                    lstMd.location = locationId;
                    lstMd.carton_code = locationId;
                    lstMd.unit = "PCS";
                    lstMd.qty = decimal.Parse(dtAdjUpdate.Rows[i]["adj_qty"].ToString());
                    lstMd.sec_qty = decimal.Parse(dtAdjUpdate.Rows[i]["adj_sec_qty"].ToString());
                    lotNo = dtAdjUpdate.Rows[i]["lot_no"].ToString();
                    if (string.IsNullOrEmpty(lotNo))
                    {
                        lotNo = clsPublic.GetDeptLotNo(locationId, locationId);//自動生成批號
                    }
                    lstMd.lot_no = lotNo;
                    lstMd.ib_amount = decimal.Parse(dtAdjUpdate.Rows[i]["ib_amount"].ToString());
                    lstMd.ib_weight = decimal.Parse(dtAdjUpdate.Rows[i]["ib_weight"].ToString());
                    lstMd.price = 0;
                    lstMd.transfers_state = "0";
                    lstMd.sec_unit = "KG";
                    lstMd.remark = "";
                    lstMd.row_status = "NEW";
                    lstDetailData1.Add(lstMd);
                }
            }           
            //保存并批準庫存調整數據,
            string result = clsTransferout.SaveAdjData(headData, lstDetailData1, DBUtility._user_id);
            if (result.Substring(0, 2) == "00")
            {
                string locId = txtDept.Text.Trim();
                string yearMonth = mskMonth.Text;
                string sql_u = string.Format(
                @"Update dgcf_pad.dbo.product_inventory Set upd_flag ='1'
                WHERE loc_id='{0}' And st_month='{1}' And ISNULL(upd_flag,'0')='0'", locId, yearMonth);
                clsPublicOfCF01.ExecuteSqlUpdate(sql_u);               
                for (int i=0;i<dtAdj.Rows.Count;i++)
                {
                    dtAdj.Rows[i]["upd_flag"] = "1";                    
                }
                dtAdj.AcceptChanges();
            }
            return result;
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            FindData();
        }

        private void FindData()
        {
            dgv1.Visible = true;
            dgv2.Visible = false;
            dtAdjTemp.Clear();
            dtAdjUpdate.Clear();
            if (txtDept.Text.Trim() == "")
            {
                MessageBox.Show("倉庫不可為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDept.Focus();
                return;
            }
            if (mskMonth.Text.Trim() == "/")
            {
                MessageBox.Show("盤點日期不可為空!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskMonth.Focus();
                return;
            }
            string sql =
            @"Select loc_id As location_id,mo_id,goods_id,Sum(st_qty) As adj_qty,Sum(st_weg) As adj_sec_qty,
            st_month As ym,'' As lot_no,Max(upd_flag) as upd_flag
            From dgcf_pad.dbo.product_inventory WHERE goods_id<>'' And Isnull(upd_flag,'0')='0'";
            if (txtDept.Text.Trim() != "")
            {
                sql += $" And loc_id='{txtDept.Text.Trim()}'";
            }
            if (mskMonth.Text.Trim() != "/")
            {
                sql += $" And st_month='{mskMonth.Text.Trim()}'";
            }
            sql += " Group by st_month,loc_id,mo_id,goods_id Order by st_month,loc_id,mo_id,goods_id";
            dtAdj = clsPublicOfCF01.GetDataTable(sql);
            dgv1.DataSource = dtAdj;
            if (dtAdj.Rows.Count == 0)
            {
                MessageBox.Show("無符合查找條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //庫存明細有批號
            //--start 測試環境設置備註
            //DBUtility.remote_db = "dgerp4.cferp.dbo.";
            //clsPublicOfGEO公共類的數據庫連接要改成以下代碼：
            //private string strConn="server=192.168.3.14;database =cferp;uid =sa;pwd=268709;"; //測試環境使用    
            //--end 測試環境設置備註
                         
            sql = string.Format(
            @"SELECT '' as sequence_id,location_id,mo_id,goods_id,lot_no,qty,sec_qty 
            FROM {0}st_details_lot 
            WHERE within_code='0000' AND location_id='{1}' AND carton_code='{1}' AND (qty>0 OR sec_qty>0) AND LEN(RTRIM(goods_id))>=18 AND state='0'
            ORDER BY location_id,mo_id,goods_id,update_date,lot_no", DBUtility.remote_db, txtDept.Text.Trim());
            dtStlotno = clsPublicOfCF01.GetDataTable(sql);
            //庫存匯總無批號
            sql = string.Format(
            @"SELECT location_id,mo_id,goods_id,Sum(qty) as qty,Sum(sec_qty) as sec_qty
            FROM {0}st_details_lot 
            WHERE within_code='0000' AND location_id='{1}' AND carton_code='{1}' AND (qty>0 OR sec_qty>0) AND LEN(RTRIM(goods_id))>=18 AND state='0'
            Group By location_id,mo_id,goods_id
            ORDER BY location_id,mo_id,goods_id", DBUtility.remote_db, txtDept.Text.Trim());
            dtSt = clsPublicOfCF01.GetDataTable(sql);
        }

        private void BTNCHECK_Click(object sender, EventArgs e)
        {
            if (dgv1.RowCount == 0)
            {
                return;
            }
            dtAdj.Columns.Add("flag_del", typeof(string));
            dtAdjTemp = dtAdj.Clone();
            dtAdjTemp.Columns.Add("ib_amount", typeof(decimal));
            dtAdjTemp.Columns.Add("ib_weight", typeof(decimal));            
            string filter = string.Empty, location = string.Empty, moId = string.Empty, goodsId = string.Empty, lotNo = string.Empty;
            decimal adjQty = 0, adjWeg = 0, tmpWeg = 0, tmpQty = 0, tmpIbamount = 0, tmpIbweight = 0;
            decimal stQty = 0, stWeg = 0;
            DataRow[] aryDr;
            DataRow[] aryDrLotNo;
            DataRow dr;
            
            //標記倉庫，頁數，貨品編號，數量，重量與GEO庫存中一樣的，這類數據不用調整
            for (int i = 0; i < dtAdj.Rows.Count; i++)
            {
                location = dtAdj.Rows[i]["location_id"].ToString();
                moId = dtAdj.Rows[i]["mo_id"].ToString();
                goodsId = dtAdj.Rows[i]["goods_id"].ToString();
                adjQty = decimal.Parse(dtAdj.Rows[i]["adj_qty"].ToString());
                adjWeg = decimal.Parse(dtAdj.Rows[i]["adj_sec_qty"].ToString());
                for(int j=0;j< dtSt.Rows.Count;j++)
                {
                    if(location == dtSt.Rows[j]["location_id"].ToString().Trim() && 
                        moId == dtSt.Rows[j]["mo_id"].ToString().Trim() &&
                        goodsId == dtAdj.Rows[i]["goods_id"].ToString() && 
                        adjQty == decimal.Parse(dtSt.Rows[j]["qty"].ToString()) &&
                        adjWeg == decimal.Parse(dtSt.Rows[j]["sec_qty"].ToString()))
                    {
                        dtAdj.Rows[i]["flag_del"] = "Y";
                        break;
                    }
                }
               // dtSt.Select();
                //aryDr = dtSt.Select($"location_id='{location}' And mo_id='{moId}' And goods_id='{goodsId}' and qty={adjQty} and sec_qty={adjWeg}");
                //if (aryDr.Length > 0)
                //{
                //    dtAdj.Rows[i]["flag_del"] = "Y";
                //}
            }
            dtAdj.AcceptChanges();

            Graphics g = progressBar1.CreateGraphics();
            System.Drawing.Font mf = new System.Drawing.Font("Arial", 9);
            Brush mb = System.Drawing.Brushes.White;
            System.Drawing.Point mp = new System.Drawing.Point(10, 0);

            progressBar1.Enabled = true;
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Step = 1;
            progressBar1.Maximum = dtAdj.Rows.Count;

            //dtAdj:當月盤點實點數，dtSt：電腦數
            for (int i = 0; i < dtAdj.Rows.Count; i++)
            {
                //---
                progressBar1.Value += progressBar1.Step;
                if (progressBar1.Value == progressBar1.Maximum)
                {
                    progressBar1.Enabled = false;
                    progressBar1.Visible = false;
                }
                g.DrawString("正在生成調整差額數據...", mf, mb, mp);
                System.Windows.Forms.Application.DoEvents();
                //---

                location = dtAdj.Rows[i]["location_id"].ToString().Trim();
                moId = dtAdj.Rows[i]["mo_id"].ToString().Trim();
                goodsId = dtAdj.Rows[i]["goods_id"].ToString().Trim();
                adjQty = decimal.Parse(dtAdj.Rows[i]["adj_qty"].ToString());
                adjWeg = decimal.Parse(dtAdj.Rows[i]["adj_sec_qty"].ToString());


                if (dtAdj.Rows[i]["flag_del"].ToString() == "Y")
                {
                    dr = dtAdjTemp.NewRow();
                    dr["location_id"] = location;
                    dr["mo_id"] = moId;
                    dr["goods_id"] = goodsId;
                    dr["adj_qty"] = tmpQty;
                    dr["adj_sec_qty"] = tmpWeg;
                    dr["lot_no"] = "";
                    dr["ib_amount"] = 0;//調整前數量
                    dr["ib_weight"] = 0;//調整前重量
                    dr["flag_del"] = "Y";//保留GEO原始庫存標識
                    dtAdjTemp.Rows.Add(dr);
                }


                dtSt.Select();
                aryDr = dtSt.Select($"location_id='{location}' And mo_id='{moId}' And goods_id='{goodsId}'"); //如有匹配數據，通常只有一條記錄

                if (aryDr.Length > 0)  //實點有數，庫存也有數
                {
                    stQty = decimal.Parse(aryDr[0]["qty"].ToString()); //當前頁數，貨品編號庫存數量
                    stWeg = decimal.Parse(aryDr[0]["sec_qty"].ToString());//當前頁數，貨品編號庫存重量;
                    if (adjQty == stQty && adjWeg == stWeg)
                    {
                        //實點數量、實點重量均等于電腦數量、電腦重量
                        continue;
                        //dr = dtAdjTemp.NewRow();
                        //dr["location_id"] = location;
                        //dr["mo_id"] = moId;
                        //dr["goods_id"] = goodsId;
                        //dr["adj_qty"] = 0;
                        //dr["adj_sec_qty"] = 0;
                        //dr["lot_no"] = "";
                        //dr["ib_amount"] = 0;//調整前數量
                        //dr["ib_weight"] = 0;//調整前重量
                        //dr["flag_del"] = "Y";//保留GEO原始庫存標識
                        //dtAdjTemp.Rows.Add(dr);
                    }
                    else
                    {
                        //第1種情況
                        if (adjQty > stQty && adjWeg > stWeg)
                        {
                            //實點數量、實點重量均大于電腦數量、電腦重量
                            tmpQty = adjQty - stQty;     //數量差額,大于0
                            tmpWeg = adjWeg - stWeg; //重量差額,大于0
                            lotNo = clsPublic.GetDeptLotNo(location, location);              //自動生成批號
                            dr = dtAdjTemp.NewRow();
                            dr["location_id"] = location;
                            dr["mo_id"] = moId;
                            dr["goods_id"] = goodsId;
                            dr["adj_qty"] = tmpQty;
                            dr["adj_sec_qty"] = tmpWeg;
                            dr["lot_no"] = lotNo;
                            dr["ib_amount"] = 0;//調整前數量
                            dr["ib_weight"] = 0;//調整前重量
                            dtAdjTemp.Rows.Add(dr);
                        }//--enf of 1

                        //--start第2~8種情況共用
                        dtStlotno.Select();
                        aryDrLotNo = dtStlotno.Select($"location_id='{location}' And mo_id='{moId}' And goods_id='{goodsId}'");
                        //--end

                        //第2種情況
                        if (adjQty < stQty && adjWeg < stWeg)
                        {
                            //a.)處理實點數量<電腦數量
                            //--start 20250618 allen 處理電腦數量大于實點數量,要將電腦數中多出來的數量調走(-)  
                            //例如實點數量是500,電腦數是兩個批次，一個批次100,另一個批次是700， 數量差額是300要調走                                  
                            adjQty = stQty - adjQty;//差額數量，正數
                            for (int ii = 0; ii < aryDrLotNo.Length; ii++)
                            {
                                //調走電腦數中的數量
                                tmpWeg = 0;
                                lotNo = aryDrLotNo[ii]["lot_no"].ToString();
                                tmpIbamount = decimal.Parse(aryDrLotNo[ii]["qty"].ToString());//調整前數量
                                tmpIbweight = decimal.Parse(aryDrLotNo[ii]["sec_qty"].ToString());//調整前重量
                                if (decimal.Parse(aryDrLotNo[ii]["qty"].ToString()) >= Math.Abs(adjQty))
                                {
                                    //當前電腦數中的當前批次足夠扣除數量，直接在當前批次中扣除                                            
                                    tmpQty = -Math.Abs(adjQty);//負數                                            
                                    dr = dtAdjTemp.NewRow();
                                    dr["location_id"] = location;
                                    dr["mo_id"] = moId;
                                    dr["goods_id"] = goodsId;
                                    dr["adj_qty"] = tmpQty;
                                    dr["adj_sec_qty"] = tmpWeg;
                                    dr["lot_no"] = lotNo;
                                    dr["ib_amount"] = tmpIbamount; //調整前數量
                                    dr["ib_weight"] = tmpIbweight; //調整前重量
                                    dtAdjTemp.Rows.Add(dr);
                                    break;
                                }
                                else
                                {
                                    //當前電腦數中的當前批次數量不夠扣除，需要在多個批次中扣除                                           
                                    adjQty = -(Math.Abs(adjQty) - decimal.Parse(aryDrLotNo[ii]["qty"].ToString())); //300-100=200 還有-200留到下一個批次中扣減
                                    tmpQty = -decimal.Parse(aryDrLotNo[ii]["qty"].ToString());//直接全部扣減當前批次的數量
                                    dr = dtAdjTemp.NewRow();
                                    dr["location_id"] = location;
                                    dr["mo_id"] = moId;
                                    dr["goods_id"] = goodsId;
                                    dr["adj_qty"] = tmpQty; //負數，例如：-100
                                    dr["adj_sec_qty"] = tmpWeg;
                                    dr["lot_no"] = lotNo;
                                    dr["ib_amount"] = tmpIbamount; //調整前數量
                                    dr["ib_weight"] = tmpIbweight; //調整前重量
                                    dtAdjTemp.Rows.Add(dr);
                                }
                            } // end for 循環

                            //b.)處理實點重量<電腦重量
                            //--start 20250618 allen 處理電腦重量大于實點重量,要將電腦數中多出來的重量調走(-)
                            adjWeg = adjWeg - stWeg;//差額重量,負數
                            for (int ii = 0; ii < aryDrLotNo.Length; ii++)
                            {
                                //調走電腦數中的重量
                                tmpQty = 0;
                                lotNo = aryDrLotNo[ii]["lot_no"].ToString();
                                tmpIbamount = decimal.Parse(aryDrLotNo[ii]["qty"].ToString());//調整前數量
                                tmpIbweight = decimal.Parse(aryDrLotNo[ii]["sec_qty"].ToString());//調整前重量
                                if (decimal.Parse(aryDrLotNo[ii]["sec_qty"].ToString()) >= Math.Abs(adjWeg))
                                {
                                    //當前電腦數中的當前批次足夠扣除重量，直接在當前批次中扣除                                       
                                    tmpWeg = -Math.Abs(adjWeg);//負數
                                    dr = dtAdjTemp.NewRow();
                                    dr["location_id"] = location;
                                    dr["mo_id"] = moId;
                                    dr["goods_id"] = goodsId;
                                    dr["adj_qty"] = tmpQty;
                                    dr["adj_sec_qty"] = tmpWeg;
                                    dr["lot_no"] = lotNo;
                                    dr["ib_amount"] = tmpIbamount; //調整前數量
                                    dr["ib_weight"] = tmpIbweight; //調整前重量
                                    dtAdjTemp.Rows.Add(dr);
                                    break;
                                }
                                else
                                {
                                    //當前電腦數中的當前批次重量不夠扣除，需要在多個批次中扣除
                                    //例如實點重量是3KG,電腦數是兩個批次，一個批次2KG,另一個批次是4                                        
                                    adjWeg = -(Math.Abs(adjWeg) - decimal.Parse(aryDrLotNo[ii]["sec_qty"].ToString()));  //3-2=1 還有-1留到下一個批次中扣減
                                    tmpWeg = -decimal.Parse(aryDrLotNo[ii]["sec_qty"].ToString());        //直接全部扣減當前批次的重量                                       
                                    dr = dtAdjTemp.NewRow();
                                    dr["location_id"] = location;
                                    dr["mo_id"] = moId;
                                    dr["goods_id"] = goodsId;
                                    dr["adj_qty"] = tmpQty;
                                    dr["adj_sec_qty"] = tmpWeg; //負數，例如：-2
                                    dr["lot_no"] = lotNo;
                                    dr["ib_amount"] = tmpIbamount; //調整前數量
                                    dr["ib_weight"] = tmpIbweight; //調整前重量
                                    dtAdjTemp.Rows.Add(dr);
                                }
                            } // end for 循環
                            //--end 20250618 allen處理電腦重量大于實點重量
                        }

                        //第3種情況
                        if (adjQty > stQty && adjWeg < stWeg)
                        {
                            //1.)處理實點數量>=電腦數量 
                            //直接調數量(+),在期中的一個批號中增加庫存數量
                            tmpQty = adjQty - stQty; //數量差額,大于0
                            tmpWeg = 0;
                            tmpIbamount = decimal.Parse(aryDrLotNo[0]["qty"].ToString());//調整前數量
                            tmpIbweight = decimal.Parse(aryDrLotNo[0]["sec_qty"].ToString());//調整前重量;
                            lotNo = aryDrLotNo[0]["lot_no"].ToString();
                            dr = dtAdjTemp.NewRow();
                            dr["location_id"] = location;
                            dr["mo_id"] = moId;
                            dr["goods_id"] = goodsId;
                            dr["adj_qty"] = tmpQty;
                            dr["adj_sec_qty"] = tmpWeg;
                            dr["lot_no"] = lotNo;
                            dr["ib_amount"] = tmpIbamount; //調整前數量
                            dr["ib_weight"] = tmpIbweight; //調整前重量
                            dtAdjTemp.Rows.Add(dr);

                            //2.)處理實點重量<電腦重量
                            //--start 20250618 allen 處理電腦重量大于實點重量,要將電腦數中多出來的重量調走(-)
                            adjWeg = adjWeg - stWeg;//差額重量，負數                           
                            for (int ii = 0; ii < aryDrLotNo.Length; ii++)
                            {
                                //調走電腦數中的重量
                                tmpQty = 0;
                                lotNo = aryDrLotNo[ii]["lot_no"].ToString();
                                tmpIbamount = decimal.Parse(aryDrLotNo[ii]["qty"].ToString());//調整前數量
                                tmpIbweight = decimal.Parse(aryDrLotNo[ii]["sec_qty"].ToString());//調整前重量
                                if (decimal.Parse(aryDrLotNo[ii]["sec_qty"].ToString()) >= Math.Abs(adjWeg))
                                {
                                    //當前電腦數中的當前批次足夠扣除重量，直接在當前批次中扣除                                       
                                    tmpWeg = -Math.Abs(adjWeg);//負數
                                    dr = dtAdjTemp.NewRow();
                                    dr["location_id"] = location;
                                    dr["mo_id"] = moId;
                                    dr["goods_id"] = goodsId;
                                    dr["adj_qty"] = tmpQty;
                                    dr["adj_sec_qty"] = tmpWeg;
                                    dr["lot_no"] = lotNo;
                                    dr["ib_amount"] = tmpIbamount; //調整前數量
                                    dr["ib_weight"] = tmpIbweight; //調整前重量
                                    dtAdjTemp.Rows.Add(dr);
                                    break;
                                }
                                else
                                {
                                    //當前電腦數中的當前批次重量不夠扣除，需要在多個批次中扣除
                                    //例如實點重量是3KG,電腦數是兩個批次，一個批次2KG,另一個批次是4                                        
                                    adjWeg = -(Math.Abs(adjWeg) - decimal.Parse(aryDrLotNo[ii]["sec_qty"].ToString()));  //3-2=1 還有-1留到下一個批次中扣減
                                    tmpWeg = -decimal.Parse(aryDrLotNo[ii]["sec_qty"].ToString());        //直接全部扣減當前批次的重量                                       
                                    dr = dtAdjTemp.NewRow();
                                    dr["location_id"] = location;
                                    dr["mo_id"] = moId;
                                    dr["goods_id"] = goodsId;
                                    dr["adj_qty"] = tmpQty;
                                    dr["adj_sec_qty"] = tmpWeg; //負數，例如：-2
                                    dr["lot_no"] = lotNo;
                                    dr["ib_amount"] = tmpIbamount; //調整前數量
                                    dr["ib_weight"] = tmpIbweight; //調整前重量
                                    dtAdjTemp.Rows.Add(dr);
                                }
                            } // end for 循環
                            //--end 20250618 allen處理電腦重量大于實點重量
                        }  //--enf of 3

                        //第4種情況
                        if (adjQty < stQty && adjWeg > stWeg)
                        {
                            //實點數量<電腦數量但實點重量>電腦重量
                            //1.直接調重量(+),在其中的一個批號中增加差額重量
                            tmpWeg = adjWeg - stWeg; //重量差額，大于0
                            tmpQty = 0;
                            tmpIbamount = decimal.Parse(aryDrLotNo[0]["qty"].ToString());     //調整前數量
                            tmpIbweight = decimal.Parse(aryDrLotNo[0]["sec_qty"].ToString()); //調整前重量（正數）
                            lotNo = aryDrLotNo[0]["lot_no"].ToString();
                            dr = dtAdjTemp.NewRow();
                            dr["location_id"] = location;
                            dr["mo_id"] = moId;
                            dr["goods_id"] = goodsId;
                            dr["adj_qty"] = tmpQty;
                            dr["adj_sec_qty"] = tmpWeg;
                            dr["lot_no"] = lotNo;
                            dr["ib_amount"] = tmpIbamount; //調整前數量
                            dr["ib_weight"] = tmpIbweight; //調整前重量
                            dtAdjTemp.Rows.Add(dr);

                            //2.處理實點數量<電腦數量
                            //--start 20250618 allen 處理電腦數量大于實點數量,要將電腦數中多出來的數量調走(-)  
                            //例如實點數量是500,電腦數是兩個批次，一個批次100,另一個批次是700， 數量差額是300要調走                                  
                            adjQty = stQty - adjQty;//差額數量，正數
                            for (int ii = 0; ii < aryDrLotNo.Length; ii++)
                            {
                                //調走電腦數中的數量
                                tmpWeg = 0;
                                lotNo = aryDrLotNo[ii]["lot_no"].ToString();
                                tmpIbamount = decimal.Parse(aryDrLotNo[ii]["qty"].ToString());//調整前數量
                                tmpIbweight = decimal.Parse(aryDrLotNo[ii]["sec_qty"].ToString());//調整前重量
                                if (decimal.Parse(aryDrLotNo[ii]["qty"].ToString()) >= Math.Abs(adjQty))
                                {
                                    //當前電腦數中的當前批次足夠扣除數量，直接在當前批次中扣除                                            
                                    tmpQty = -Math.Abs(adjQty);//負數                                            
                                    dr = dtAdjTemp.NewRow();
                                    dr["location_id"] = location;
                                    dr["mo_id"] = moId;
                                    dr["goods_id"] = goodsId;
                                    dr["adj_qty"] = tmpQty;
                                    dr["adj_sec_qty"] = tmpWeg;
                                    dr["lot_no"] = lotNo;
                                    dr["ib_amount"] = tmpIbamount; //調整前數量
                                    dr["ib_weight"] = tmpIbweight; //調整前重量
                                    dtAdjTemp.Rows.Add(dr);
                                    break;
                                }
                                else
                                {
                                    //當前電腦數中的當前批次數量不夠扣除，需要在多個批次中扣除                                           
                                    adjQty = -(Math.Abs(adjQty) - decimal.Parse(aryDrLotNo[ii]["qty"].ToString())); //300-100=200 還有-200留到下一個批次中扣減
                                    tmpQty = -decimal.Parse(aryDrLotNo[ii]["qty"].ToString());//直接全部扣減當前批次的數量
                                    dr = dtAdjTemp.NewRow();
                                    dr["location_id"] = location;
                                    dr["mo_id"] = moId;
                                    dr["goods_id"] = goodsId;
                                    dr["adj_qty"] = tmpQty; //負數，例如：-100
                                    dr["adj_sec_qty"] = tmpWeg;
                                    dr["lot_no"] = lotNo;
                                    dr["ib_amount"] = tmpIbamount; //調整前數量
                                    dr["ib_weight"] = tmpIbweight; //調整前重量
                                    dtAdjTemp.Rows.Add(dr);
                                }
                            } // end for 循環
                            //--end 20250618 allen處理電腦數量大于實點數量
                        } //--enf of 4

                        //第5種情況
                        if (adjQty > stQty && adjWeg == stWeg)
                        {
                            //實點數量>電腦數量，實點重量=電腦重量
                            tmpQty = adjQty - stQty; //數量差額,大于0
                            tmpWeg = 0;
                            tmpIbamount = decimal.Parse(aryDrLotNo[0]["qty"].ToString());//調整前數量
                            tmpIbweight = decimal.Parse(aryDrLotNo[0]["sec_qty"].ToString());//調整前重量;
                            lotNo = aryDrLotNo[0]["lot_no"].ToString();
                            dr = dtAdjTemp.NewRow();
                            dr["location_id"] = location;
                            dr["mo_id"] = moId;
                            dr["goods_id"] = goodsId;
                            dr["adj_qty"] = tmpQty;
                            dr["adj_sec_qty"] = tmpWeg;
                            dr["lot_no"] = lotNo;
                            dr["ib_amount"] = tmpIbamount; //調整前數量
                            dr["ib_weight"] = tmpIbweight; //調整前重量
                            dtAdjTemp.Rows.Add(dr);
                        } //--enf of 5

                        //第6種情況
                        if (adjQty < stQty && adjWeg == stWeg)
                        {
                            //實點數量<電腦數量，實點重量=電腦重量                           
                            //--start 20250618 allen 處理電腦數量大于實點數量,要將電腦數中多出來的數量調走(-)  
                            //例如實點數量是500,電腦數是兩個批次，一個批次100,另一個批次是700， 數量差額是300要調走
                            adjQty = stQty - adjQty;//差額數量，正數
                            for (int ii = 0; ii < aryDrLotNo.Length; ii++)
                            {
                                //調走電腦數中的數量
                                tmpWeg = 0;
                                lotNo = aryDrLotNo[ii]["lot_no"].ToString();
                                tmpIbamount = decimal.Parse(aryDrLotNo[ii]["qty"].ToString());//調整前數量
                                tmpIbweight = decimal.Parse(aryDrLotNo[ii]["sec_qty"].ToString());//調整前重量
                                if (decimal.Parse(aryDrLotNo[ii]["qty"].ToString()) >= Math.Abs(adjQty))
                                {
                                    //當前電腦數中的當前批次足夠扣除數量，直接在當前批次中扣除                                            
                                    tmpQty = -Math.Abs(adjQty);//負數
                                    dr = dtAdjTemp.NewRow();
                                    dr["location_id"] = location;
                                    dr["mo_id"] = moId;
                                    dr["goods_id"] = goodsId;
                                    dr["adj_qty"] = tmpQty;
                                    dr["adj_sec_qty"] = tmpWeg;
                                    dr["lot_no"] = lotNo;
                                    dr["ib_amount"] = tmpIbamount; //調整前數量
                                    dr["ib_weight"] = tmpIbweight; //調整前重量
                                    dtAdjTemp.Rows.Add(dr);
                                    break;
                                }
                                else
                                {
                                    //當前電腦數中的當前批次數量不夠扣除，需要在多個批次中扣除                                           
                                    adjQty = -(Math.Abs(adjQty) - decimal.Parse(aryDrLotNo[ii]["qty"].ToString())); //300-100=200 還有-200留到下一個批次中扣減
                                    tmpQty = -decimal.Parse(aryDrLotNo[ii]["qty"].ToString());//直接全部扣減當前批次的數量(100)
                                    dr = dtAdjTemp.NewRow();
                                    dr["location_id"] = location;
                                    dr["mo_id"] = moId;
                                    dr["goods_id"] = goodsId;
                                    dr["adj_qty"] = tmpQty; //負數，例如：-100
                                    dr["adj_sec_qty"] = tmpWeg;
                                    dr["lot_no"] = lotNo;
                                    dr["ib_amount"] = tmpIbamount; //調整前數量
                                    dr["ib_weight"] = tmpIbweight; //調整前重量
                                    dtAdjTemp.Rows.Add(dr);
                                }
                            } // end for 循環
                            //--end 20250618 allen處理電腦數量大于實點數量
                        } //--enf of 6

                        //第7種情況
                        if (adjWeg > stWeg && adjQty == stQty)
                        {
                            //實點重量>實點重量,實點數量=電腦數量
                            tmpWeg = adjWeg - stWeg; //重量差額,大于0
                            tmpQty = 0;
                            tmpIbamount = decimal.Parse(aryDrLotNo[0]["qty"].ToString());//調整前數量
                            tmpIbweight = decimal.Parse(aryDrLotNo[0]["sec_qty"].ToString());//調整前重量;
                            lotNo = aryDrLotNo[0]["lot_no"].ToString();
                            dr = dtAdjTemp.NewRow();
                            dr["location_id"] = location;
                            dr["mo_id"] = moId;
                            dr["goods_id"] = goodsId;
                            dr["adj_qty"] = tmpQty;
                            dr["adj_sec_qty"] = tmpWeg;
                            dr["lot_no"] = lotNo;
                            dr["ib_amount"] = tmpIbamount; //調整前數量
                            dr["ib_weight"] = tmpIbweight; //調整前重量
                            dtAdjTemp.Rows.Add(dr);
                        } //--enf of 7

                        //第8種情況
                        if (adjWeg < stWeg && adjQty == stQty)
                        {
                            //實點重量<實點重量,實點數量=電腦數量
                            //--start 20250618 allen 處理電腦重量大于實點重量,要將電腦數中多出來的重量調走(-)
                            adjWeg = adjWeg - stWeg;//差額重量，負數                           
                            for (int ii = 0; ii < aryDrLotNo.Length; ii++)
                            {
                                //調走電腦數中的重量
                                tmpQty = 0;
                                lotNo = aryDrLotNo[ii]["lot_no"].ToString();
                                tmpIbamount = decimal.Parse(aryDrLotNo[ii]["qty"].ToString());//調整前數量
                                tmpIbweight = decimal.Parse(aryDrLotNo[ii]["sec_qty"].ToString());//調整前重量
                                if (decimal.Parse(aryDrLotNo[ii]["sec_qty"].ToString()) >= Math.Abs(adjWeg))
                                {
                                    //當前電腦數中的當前批次足夠扣除重量，直接在當前批次中扣除                                       
                                    tmpWeg = -Math.Abs(adjWeg);//負數                                        
                                    dr = dtAdjTemp.NewRow();
                                    dr["location_id"] = location;
                                    dr["mo_id"] = moId;
                                    dr["goods_id"] = goodsId;
                                    dr["adj_qty"] = tmpQty;
                                    dr["adj_sec_qty"] = tmpWeg;
                                    dr["lot_no"] = lotNo;
                                    dr["ib_amount"] = tmpIbamount; //調整前數量
                                    dr["ib_weight"] = tmpIbweight; //調整前重量
                                    dtAdjTemp.Rows.Add(dr);
                                    break;
                                }
                                else
                                {
                                    //當前電腦數中的當前批次重量不夠扣除，需要在多個批次中扣除
                                    //例如實點重量是3KG,電腦數是兩個批次，一個批次2KG,另一個批次是4                                        
                                    adjWeg = -(Math.Abs(adjWeg) - decimal.Parse(aryDrLotNo[ii]["sec_qty"].ToString())); //3-2=1 還有-1留到下一個批次中扣減
                                    tmpWeg = -decimal.Parse(aryDrLotNo[ii]["sec_qty"].ToString());//直接全部扣減當前批次的重量                                       
                                    dr = dtAdjTemp.NewRow();
                                    dr["location_id"] = location;
                                    dr["mo_id"] = moId;
                                    dr["goods_id"] = goodsId;
                                    dr["adj_qty"] = tmpQty;
                                    dr["adj_sec_qty"] = tmpWeg; //負數，例如：-2
                                    dr["lot_no"] = lotNo;
                                    dr["ib_amount"] = tmpIbamount; //調整前數量
                                    dr["ib_weight"] = tmpIbweight; //調整前重量
                                    dtAdjTemp.Rows.Add(dr);
                                }
                            } // end for 循環
                            //--end 20250618 allen處理電腦重量大于實點重量
                        }//--enf of 8

                    }
                }
                else
                {
                    //無電腦數,則直接調整
                    tmpQty = adjQty;
                    tmpWeg = adjWeg;
                    lotNo = clsPublic.GetDeptLotNo(location, location);//自動生成批號
                    dr = dtAdjTemp.NewRow();
                    dr["location_id"] = location;
                    dr["mo_id"] = moId;
                    dr["goods_id"] = goodsId;
                    dr["adj_qty"] = tmpQty;
                    dr["adj_sec_qty"] = tmpWeg;
                    dr["lot_no"] = lotNo;
                    dr["ib_amount"] = 0;//調整前數量
                    dr["ib_weight"] = 0;//調整前重量
                    dtAdjTemp.Rows.Add(dr);
                }

            } //--end for (int i = 0; i< dtAdj.Rows.Count; i++)

            progressBar1.Enabled = false;
            progressBar1.Visible = false;

            //同一批號既要調數量又要調重量，合拼到成一條記錄
            dtAdjUpdate = dtAdjTemp.Clone();
            DataTable dtAdjCopy = dtAdjTemp.Copy();
            string strFilter = "";
            DataRow drw;
            DataRow[] aryDrw;
            DataRow[] drwExists;
            for (int i = 0; i < dtAdjTemp.Rows.Count; i++)
            {
                if (dtAdjTemp.Rows[i]["flag_del"].ToString() == "Y")
                {
                    //continue;//不需處理
                    drw = dtAdjTemp.Rows[i];
                    dtAdjUpdate.ImportRow(drw);
                }
                else
                {
                    location = dtAdjTemp.Rows[i]["location_id"].ToString().Trim();
                    moId = dtAdjTemp.Rows[i]["mo_id"].ToString().Trim();
                    goodsId = dtAdjTemp.Rows[i]["goods_id"].ToString().Trim();
                    lotNo = dtAdjTemp.Rows[i]["lot_no"].ToString().Trim();
                    strFilter = $"location_id='{location}' And mo_id='{moId}' And goods_id='{goodsId}' And lot_no='{lotNo}'";
                    aryDrw = dtAdjCopy.Select(strFilter);
                    if (aryDrw.Length == 1)
                    {
                        dtAdjUpdate.ImportRow(aryDrw[0]);
                    }
                    else
                    {
                        drwExists = dtAdjUpdate.Select(strFilter);
                        if (drwExists.Length == 0)
                        {
                            decimal adj_qty = 0, adj_sec_qty = 0; //ib_amount = 0, ib_weight = 0;
                            dr = dtAdjUpdate.NewRow();
                            dr["location_id"] = location;
                            dr["mo_id"] = moId;
                            dr["goods_id"] = goodsId;
                            dr["lot_no"] = lotNo;
                            tmpIbamount = decimal.Parse(aryDrw[0]["ib_amount"].ToString());
                            tmpIbweight = decimal.Parse(aryDrw[0]["ib_weight"].ToString());
                            for (int j = 0; j < aryDrw.Length; j++)
                            {
                                adj_qty += decimal.Parse(aryDrw[j]["adj_qty"].ToString());
                                adj_sec_qty += decimal.Parse(aryDrw[j]["adj_sec_qty"].ToString());
                            }
                            dr["adj_qty"] = adj_qty;
                            dr["adj_sec_qty"] = adj_sec_qty;
                            dr["ib_amount"] = tmpIbamount;
                            dr["ib_weight"] = tmpIbweight;
                            dtAdjUpdate.Rows.Add(dr);
                        }
                    }
                }
            }

            //處理GEO系統有庫存，但實點數沒有，則調走GEO中的庫存數
            dtSt.Select();
            string lot_no = "";
            for (int i = 0; i < dtStlotno.Rows.Count; i++)
            {
                location = dtStlotno.Rows[i]["location_id"].ToString().Trim();
                moId = dtStlotno.Rows[i]["mo_id"].ToString().Trim();
                goodsId = dtStlotno.Rows[i]["goods_id"].ToString().Trim();
                lot_no = dtStlotno.Rows[i]["lot_no"].ToString().Trim(); 
                
                strFilter = $"location_id='{location}' And mo_id='{moId}' And goods_id='{goodsId}' And flag_del='Y'";
                dtAdjUpdate.Select();
                aryDrw = dtAdjUpdate.Select(strFilter);
                if (aryDrw.Length > 0)
                {
                    continue;
                }
                else
                {
                    //實點盤點單中不存在
                    strFilter = $"location_id='{location}' And mo_id='{moId}' And goods_id='{goodsId}' And lot_no='{lot_no}'";
                    dtAdjUpdate.Select();
                    aryDrw = dtAdjUpdate.Select(strFilter);
                    if (aryDrw.Length == 0)
                    {
                        dr = dtAdjUpdate.NewRow();
                        dr["location_id"] = location;
                        dr["mo_id"] = moId;
                        dr["goods_id"] = goodsId;
                        dr["lot_no"] = lot_no;
                        adjQty = decimal.Parse(dtStlotno.Rows[i]["qty"].ToString());
                        adjWeg = decimal.Parse(dtStlotno.Rows[i]["sec_qty"].ToString());
                        dr["adj_qty"] = -adjQty;
                        dr["adj_sec_qty"] = -adjWeg;
                        dr["ib_amount"] = adjQty;
                        dr["ib_weight"] = adjWeg;
                        dr["flag_del"] = "N";
                        dtAdjUpdate.Rows.Add(dr);
                    }
                }
                
            }
            MessageBox.Show("生成調整差額臨時數據成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgv1.Visible = false;
            dgv2.Visible = true;
            dtAdjTemp.Clear();
            dgv2.DataSource = dtAdjUpdate;
            this.Refresh();
        } //--end of BTNCHECK_Click

        private void txtDept_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

      
    }
}
