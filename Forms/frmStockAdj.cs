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
            if (dgv1.Rows.Count > 0)
            {
                if (MessageBox.Show("確認對以下庫存不足(601倉)的貨品進行庫存調整？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
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
                StockAdj();
                //*********
                wForm.Invoke((EventHandler)delegate { wForm.Close(); });
                this.Close();
            }
        }

        private void StockAdj()
        {          
            st_adjustment_mostly headData = new st_adjustment_mostly();
            headData.id = clsTransferout.GetMaxIDStock("ST02", 4);
            headData.department_id = "601";
            headData.date = DateTime.Now.Date.ToString("yyyy/MM/dd");
            headData.mode = "1";
            headData.state = "0";
            headData.transfers_state = "0";
            headData.update_count = "1";
            headData.create_by = DBUtility._user_id;
            headData.servername = "hkserver.cferp.dbo";
            headData.adjust_reason = "01";
            headData.head_status = "NEW";
            string lotNo = "";
            List<st_a_subordination> lstDetailData1 = new List<st_a_subordination>();
            for (int i = 0; i < dtAdj.Rows.Count; i++)
            {
                st_a_subordination lstMd = new st_a_subordination();
                lstMd.id = headData.id;
                lstMd.sequence_id = dtAdj.Rows[i]["sequence_id"].ToString();
                lstMd.mo_id = dtAdj.Rows[i]["mo_id"].ToString();
                lstMd.goods_id = dtAdj.Rows[i]["goods_id"].ToString();
                lstMd.goods_name = "";
                lstMd.color = "";
                lstMd.location = "601";
                lstMd.carton_code = "601";
                lstMd.unit = "PCS";
                lstMd.qty = decimal.Parse(dtAdj.Rows[i]["adj_qty"].ToString());
                lstMd.sec_qty = decimal.Parse(dtAdj.Rows[i]["adj_sec_qty"].ToString());
                lotNo = dtAdj.Rows[i]["lot_no"].ToString();
                if (string.IsNullOrEmpty(lotNo))
                {
                    lotNo = clsPublic.GetDeptLotNo("601", "601");//自動生成批號
                }
                lstMd.lot_no = lotNo;
                lstMd.ib_amount = 0;
                lstMd.ib_weight = 0;
                lstMd.price = 0;
                lstMd.transfers_state = "0";
                lstMd.sec_unit = "KG";
                lstMd.remark = "";
                lstMd.row_status = "NEW";
                lstDetailData1.Add(lstMd);
            }
            string result = "";
            //保存并批準庫存調整數據,
            result = clsTransferout.SaveAdjData(headData, lstDetailData1, DBUtility._user_id);
            if (result.Substring(0, 2) == "00")
            {
                //批準庫存調整數據及批準成功
                //MessageBox.Show("自動庫存調整成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("自動庫存調整失敗!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void BTNFIND_Click(object sender, EventArgs e)
        {
            if(txtDept.Text.Trim()=="")
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
            @"Select seq As sequence_id,loc_id As location_id,mo_id,goods_id,st_qty As adj_qty,st_weg As adj_sec_qty,
            st_month As ym,'' As lot_no 
            From dgcf_pad.dbo.product_inventory WHERE goods_id <>''";
            if(txtDept.Text.Trim() != "")
            {
                sql += $" And loc_id='{txtDept.Text.Trim()}'";
            }
            if (mskMonth.Text.Trim() != "/")
            {
                sql += $" And st_month='{mskMonth.Text.Trim()}'";
            }
            sql += " Order by id,seq";
            dtAdj = clsPublicOfCF01.GetDataTable(sql);
            dgv1.DataSource = dtAdj;
            if (dtAdj.Rows.Count == 0)
            {
                MessageBox.Show("無符合查找條件的數據!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                return;
            }

            sql = string.Format(
            @"SELECT '' as sequence_id,location_id,mo_id,goods_id,lot_no,qty,sec_qty 
            FROM {0}st_details_lot 
            WHERE within_code='0000' AND location_id='{1}' AND carton_code='{1}' AND (qty>0 OR sec_qty>0) AND LEN(RTRIM(goods_id))=18 AND state<>'2'
            ORDER BY location_id,mo_id,goods_id,update_date,lot_no",DBUtility.remote_db, txtDept.Text.Trim());
            dtStlotno = clsPublicOfCF01.GetDataTable(sql);
            sql = string.Format(
            @"SELECT location_id,mo_id,goods_id,Sum(qty) as qty,Sum(sec_qty) as sec_qty
            FROM {0}st_details_lot 
            WHERE within_code='0000' AND location_id='{1}' AND carton_code='{1}' AND (qty>0 OR sec_qty>0) AND LEN(RTRIM(goods_id))=18 AND state<>'2'
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
            dtAdjTemp = dtAdj.Clone();
            dtAdjTemp.Columns.Add("ib_amount", typeof(decimal));
            dtAdjTemp.Columns.Add("ib_weight", typeof(decimal));
            string filter = string.Empty, location = string.Empty, moId = string.Empty, goodsId = string.Empty, lotNo = string.Empty;           
            decimal adjQty = 0,  adjWeg = 0, tmpWeg = 0, tmpQty = 0,tmpIbamount = 0, tmpIbweight = 0;
            DataRow[] aryDr ;
            DataRow dr ;
            DataRow[] aryDrLotNo;

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
            for (int i = 0; i< dtAdj.Rows.Count; i++)
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

                location = dtAdj.Rows[i]["location_id"].ToString();
                moId = dtAdj.Rows[i]["mo_id"].ToString();
                goodsId = dtAdj.Rows[i]["goods_id"].ToString();
                adjQty = decimal.Parse(dtAdj.Rows[i]["adj_qty"].ToString());
                adjWeg = decimal.Parse(dtAdj.Rows[i]["adj_sec_qty"].ToString());

                dtSt.Select();
                aryDr = dtSt.Select($"location_id='{location}' And mo_id='{moId}' And goods_id='{goodsId}'"); //如有匹配數據，通常只有一條記錄

                if (aryDr.Length > 0)  //實點有數，庫存也有數
                {
                    if(adjQty == decimal.Parse(aryDr[0]["qty"].ToString()) && adjWeg == decimal.Parse(aryDr[0]["sec_qty"].ToString()))
                    {
                        //實點數量、實點重量均等于電腦數量、電腦重量
                        continue;
                    }
                    else
                    {
                        //第1種情況
                        if(adjQty > decimal.Parse(aryDr[0]["qty"].ToString()) && adjWeg > decimal.Parse(aryDr[0]["sec_qty"].ToString()))
                        {
                            //實點數量、實點重量均大于電腦數量、電腦重量
                            tmpQty = adjQty - decimal.Parse(aryDr[0]["qty"].ToString());     //數量差額,大于0
                            tmpWeg = adjWeg - decimal.Parse(aryDr[0]["sec_qty"].ToString()); //重量差額,大于0
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

                        //--start第2~7種情況共用
                        dtStlotno.Select();
                        aryDrLotNo = dtStlotno.Select($"location_id='{location}' And mo_id='{moId}' And goods_id='{goodsId}'");
                        //--end

                        //第2種情況
                        if (adjQty > decimal.Parse(aryDr[0]["qty"].ToString()) && adjWeg < decimal.Parse(aryDr[0]["sec_qty"].ToString()))
                        {
                            //1.)處理實點數量>=電腦數量 
                            //直接調數量(+),在期中的一個批號中增加庫存數量
                            tmpQty = adjQty - decimal.Parse(aryDr[0]["qty"].ToString()); //數量差額,大于0
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
                            adjWeg = adjWeg - decimal.Parse(aryDr[0]["sec_qty"].ToString());//差額重量，負數                           
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
                        }  //--enf of 2

                        //第3種情況
                        if (adjQty < decimal.Parse(aryDr[0]["qty"].ToString()) && adjWeg > decimal.Parse(aryDr[0]["sec_qty"].ToString()))
                        {
                            //實點數量<電腦數量但實點重量>電腦重量
                            //1.直接調重量(+),在其中的一個批號中增加差額重量
                            tmpWeg = adjWeg - decimal.Parse(aryDr[0]["sec_qty"].ToString()); //重量差額，大于0
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
                            adjQty = decimal.Parse(aryDr[0]["qty"].ToString()) - adjQty;//差額數量，正數
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
                        } //--enf of 3

                        //第4種情況
                        if (adjQty > decimal.Parse(aryDr[0]["qty"].ToString()) && adjWeg == decimal.Parse(aryDr[0]["sec_qty"].ToString()))
                        {
                            //實點數量>電腦數量，實點重量=電腦重量
                            tmpQty = adjQty - decimal.Parse(aryDr[0]["qty"].ToString()); //數量差額,大于0
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
                        } //--enf of 4

                        //第5種情況
                        if (adjQty < decimal.Parse(aryDr[0]["qty"].ToString()) && adjWeg == decimal.Parse(aryDr[0]["sec_qty"].ToString()))
                        {
                            //實點數量<電腦數量，實點重量=電腦重量                           
                            //--start 20250618 allen 處理電腦數量大于實點數量,要將電腦數中多出來的數量調走(-)  
                            //例如實點數量是500,電腦數是兩個批次，一個批次100,另一個批次是700， 數量差額是300要調走
                            adjQty = decimal.Parse(aryDr[0]["qty"].ToString()) - adjQty;//差額數量，正數
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
                        } //--enf of 5

                        //第6種情況
                        if (adjWeg > decimal.Parse(aryDr[0]["sec_qty"].ToString()) && adjQty == decimal.Parse(aryDr[0]["qty"].ToString()))
                        {
                            //實點重量>實點重量,實點數量=電腦數量
                            tmpWeg = adjWeg - decimal.Parse(aryDr[0]["sec_qty"].ToString()); //重量差額,大于0
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
                        } //--enf of 6

                        //第7種情況
                        if (adjWeg < decimal.Parse(aryDr[0]["sec_qty"].ToString()) && adjQty == decimal.Parse(aryDr[0]["qty"].ToString()))
                        {
                            //實點重量<實點重量,實點數量=電腦數量
                            //--start 20250618 allen 處理電腦重量大于實點重量,要將電腦數中多出來的重量調走(-)
                            adjWeg = adjWeg - decimal.Parse(aryDr[0]["sec_qty"].ToString());//差額重量，負數                           
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
                        }//--enf of 7

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
            DataRow[] aryDrw;
            DataRow[] drwExists;
            for (int i=0;i< dtAdjTemp.Rows.Count; i++)
            {
                location = dtAdjTemp.Rows[i]["location_id"].ToString();
                moId = dtAdjTemp.Rows[i]["mo_id"].ToString();
                goodsId = dtAdjTemp.Rows[i]["goods_id"].ToString();
                lotNo = dtAdjTemp.Rows[i]["lot_no"].ToString();
                strFilter = $"location_id='{location}' And mo_id='{moId}' And goods_id='{goodsId}' And lot_no='{lotNo}'";
                aryDrw = dtAdjCopy.Select(strFilter);
                if(aryDrw.Length == 1)
                {
                    dtAdjUpdate.ImportRow(aryDrw[0]);
                }
                else
                {
                    drwExists =  dtAdjUpdate.Select(strFilter);
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

            //處理GEO系統有庫存，但實點數沒有，則調走GEO中的庫存數
            dtSt.Select();
            for (int i=0;i< dtSt.Rows.Count; i++)
            {
                location = dtSt.Rows[i]["location_id"].ToString();
                moId = dtSt.Rows[i]["mo_id"].ToString();
                goodsId = dtSt.Rows[i]["goods_id"].ToString();               
                strFilter = $"location_id='{location}' And mo_id='{moId}' And goods_id='{goodsId}'";
                dtAdj.Select();
                aryDrw = dtAdj.Select(strFilter);
                if (aryDrw.Length == 0)
                {
                    dtStlotno.Select();
                    aryDrLotNo = dtStlotno.Select(strFilter);
                    for(int j = 0; j < aryDrLotNo.Length; j++)
                    {
                        dr = dtAdjUpdate.NewRow();
                        dr["location_id"] = location;
                        dr["mo_id"] = moId;
                        dr["goods_id"] = goodsId;
                        dr["lot_no"] = aryDrLotNo[j]["lot_no"].ToString();                        
                        adjQty = decimal.Parse(aryDrLotNo[j]["qty"].ToString());
                        adjWeg = decimal.Parse(aryDrLotNo[j]["sec_qty"].ToString());
                        dr["adj_qty"] = -adjQty;
                        dr["adj_sec_qty"] = -adjWeg;                      
                        dr["ib_amount"] = adjQty;
                        dr["ib_weight"] = adjWeg;
                        dtAdjUpdate.Rows.Add(dr);
                    }
                }
            }

            MessageBox.Show("生成調整差額數據成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
