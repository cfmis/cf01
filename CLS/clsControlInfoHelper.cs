using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using cf01.ModuleClass;
using System.IO;

namespace cf01.CLS
{
    public class clsControlInfoHelper
    {
        private string _strFrmName;
        private Control.ControlCollection _controlCollectin;

        DataTable dtTSBtnRole = new DataTable();
        DataTable dtControlInfo = new DataTable();
        public clsControlInfoHelper(string frmName, Control.ControlCollection controlCollection)
        {
            _strFrmName = frmName;
            _controlCollectin = controlCollection;
        }

        public void GenerateContorl()
        {
            try
            {
                DataTable dtBtnInfo = clsRoleManage.GetAllUserPopedom(DBUtility._user_id, _strFrmName);
                dtControlInfo = clsRoleManage.GetAllControlInfo(_strFrmName, DBUtility._language);
                if (dtBtnInfo.Rows.Count > 0 || dtControlInfo.Rows.Count > 0)
                {
                    GetToolbarGrant(dtBtnInfo);
                    setValue(_controlCollectin);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 表單控件翻譯及工具欄按鈕權限
        /// </summary>
        /// <param name="objectname">控件集</param>
        /// <param name="cts">表單控件對象</param>
        private void setValue(Control.ControlCollection cts)
        {
            foreach (Control ct in cts)
            {
                switch (ct.GetType().Name)
                {
                    case "ToolStrip": //工具欄按鈕
                        {
                            ToolStrip ts = (ToolStrip)ct;
                            if (ts.Items.Count <= 0)
                            {
                                for (int i = 0; i < dtControlInfo.Rows.Count; i++)
                                {
                                    if (dtControlInfo.Rows[i]["obj_type"].ToString().Trim() == "BTN")
                                    {
                                        string strObjName = dtControlInfo.Rows[i]["obj_name"].ToString().Trim();
                                        string strShowName = dtControlInfo.Rows[i]["show_name"].ToString();

                                        ToolStripButton tsBtn = new ToolStripButton();
                                        string strImgPath = AppDomain.CurrentDomain.BaseDirectory + dtControlInfo.Rows[i]["img_path"];
                                        if (File.Exists(strImgPath))
                                        {
                                            tsBtn.Image = Bitmap.FromFile(strImgPath);   //設置ToolStripButton 的Image
                                        }
                                        tsBtn.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                                        tsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                                        tsBtn.Name = strObjName;
                                        tsBtn.Text = strShowName;
                                        tsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                                        //設置工具欄按鈕可否操作
                                        DataRow[] dr = dtTSBtnRole.Select(String.Format("id = '{0}'", strObjName));
                                        if (dr.Length > 0)
                                        {
                                            //20180522 ADD BY ALLEN 將"BTNSAVE","BTNCANCEL"這個按鈕初始貨為灰色狀態
                                            if (tsBtn.Name == "BTNSAVE" || tsBtn.Name == "BTNCANCEL")
                                                tsBtn.Enabled = false;
                                            else
                                                tsBtn.Enabled = (Boolean)dr[0][1]; //舊代碼
                                        }

                                        ts.Items.Add(tsBtn);
                                    }
                                }
                            }
                            else
                            {
                                for (int j = 0; j < ts.Items.Count; j++)
                                {
                                    string objName = ts.Items[j].Name.ToUpper();

                                    DataRow[] dr = dtControlInfo.Select(String.Format("obj_name= '{0}'", objName));
                                    if (dr.Length > 0)
                                    {
                                        string strImgPath = AppDomain.CurrentDomain.BaseDirectory + dr[0]["img_path"];
                                        if (File.Exists(strImgPath))
                                        {
                                            ts.Items[j].Image = Bitmap.FromFile(strImgPath);
                                        }
                                        ts.Items[j].Text = dr[0]["show_name"].ToString().Trim();
                                        ts.Items[j].ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;

                                        if (dtTSBtnRole.Rows.Count > 0)
                                        {
                                            DataRow[] drButtonRole = dtTSBtnRole.Select(String.Format("id = '{0}'", objName));
                                            if (drButtonRole.Length > 0)
                                            {
                                                ts.Items[j].Enabled = (Boolean)drButtonRole[0][1];
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case "Label":  //文本標簽
                        {
                            Label lab = (Label)ct;
                            for (int i = 0; i < dtControlInfo.Rows.Count; i++)
                            {
                                if (dtControlInfo.Rows[i]["obj_type"].ToString().Trim() == "label")
                                {
                                    if (lab.Name == dtControlInfo.Rows[i]["obj_name"].ToString().Trim())
                                    {
                                        lab.Text = dtControlInfo.Rows[i]["show_name"].ToString();
                                    }
                                }
                            }
                        }
                        break;
                    case "DataGridView": //DataGridView列表
                        {
                            DataGridView dgv = (DataGridView)ct;
                            string strName = dgv.Name;
                            dgv.AutoGenerateColumns = false;
                            dgv.AllowUserToAddRows = false;
                            //dgv.RowHeadersVisible = false;
                            //dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;

                            for (int i = 0; i < dtControlInfo.Rows.Count; i++)
                            {
                                if (dtControlInfo.Rows[i]["obj_type"].ToString().Trim() == strName)
                                {
                                    string strObjName = dtControlInfo.Rows[i]["obj_name"].ToString().Trim();
                                    switch (dtControlInfo.Rows[i]["col_type"].ToString().Trim())
                                    {
                                        case "DataGridViewTextBoxColumn":
                                            {
                                                dgv.Columns.Add(strObjName, dtControlInfo.Rows[i]["show_name"].ToString());
                                                dgv.Columns[strObjName].DataPropertyName = dtControlInfo.Rows[i]["col_field"].ToString().Trim();
                                                dgv.Columns[strObjName].Width = Convert.ToInt32(dtControlInfo.Rows[i]["col_width"]);
                                                if (dtControlInfo.Rows[i]["col_visible"].ToString() == "Y")
                                                {
                                                    dgv.Columns[strObjName].Visible = true;
                                                }
                                                else
                                                {
                                                    dgv.Columns[strObjName].Visible = false;
                                                }

                                                if (dtControlInfo.Rows[i]["col_readonly"].ToString() == "Y")
                                                {
                                                    dgv.Columns[strObjName].ReadOnly = true;
                                                }
                                                else
                                                {
                                                    dgv.Columns[strObjName].ReadOnly = false;
                                                }
                                            }
                                            break;
                                        case "DataGridViewMaskedTextBoxColumn":
                                            {
                                                DataGridViewMaskedTextBoxColumn dgvMtxt = new DataGridViewMaskedTextBoxColumn() { 
                                                    Name = strObjName, 
                                                    HeaderText = dtControlInfo.Rows[i]["show_name"].ToString() 
                                                };
                                                if (strObjName == "valid_date")
                                                {
                                                    dgvMtxt.Mask = "0000/00/00";
                                                }
                                                dgv.Columns.Add(dgvMtxt);
                                            }
                                            break;
                                        case "DataGridViewComboBoxColumn":
                                            {
                                                DataGridViewComboBoxColumn dgvCmbox = new DataGridViewComboBoxColumn() { 
                                                    Name = strObjName, 
                                                    HeaderText = dtControlInfo.Rows[i]["show_name"].ToString() 
                                                };
                                                dgvCmbox.Items.Clear();
                                                if (strObjName == "goods_unit")
                                                {
                                                    GenerateGoodsUnit(dgvCmbox, null);
                                                }

                                                if (strObjName == "m_id")
                                                {
                                                    GenerateCurrency(dgvCmbox, null);
                                                }

                                                dgvCmbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                                                dgvCmbox.DisplayStyleForCurrentCellOnly = true;
                                                dgv.Columns.Add(dgvCmbox);
                                            }
                                            break;
                                        case "DataGridViewCheckBoxColumn":
                                            {
                                                DataGridViewCheckBoxColumn dgvCheckbox = new DataGridViewCheckBoxColumn() { 
                                                    HeaderText = dtControlInfo.Rows[i]["show_name"].ToString(), 
                                                    Name = strObjName 
                                                };
                                                dgv.Columns.Add(dgvCheckbox);
                                                if (dtControlInfo.Rows[i]["col_visible"].ToString() == "Y")
                                                {
                                                    dgv.Columns[strObjName].Visible = true;
                                                }
                                                else
                                                {
                                                    dgv.Columns[strObjName].Visible = false;
                                                }
                                                dgv.Columns[strObjName].Width = Convert.ToInt32(dtControlInfo.Rows[i]["col_width"]);
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                        }
                        break;
                    case "Button":
                        {
                            Button btn = (Button)ct;
                            for (int i = 0; i < dtControlInfo.Rows.Count; i++)
                            {
                                if (dtControlInfo.Rows[i]["obj_type"].ToString().Trim() == "Button")
                                {
                                    if (dtControlInfo.Rows[i]["obj_name"].ToString().Trim() == btn.Name)
                                    {
                                        btn.Text = dtControlInfo.Rows[i]["show_name"].ToString();
                                    }
                                }
                            }
                        }
                        break;
                    case "SimpleButton":
                        {
                            DevExpress.XtraEditors.SimpleButton btn = (DevExpress.XtraEditors.SimpleButton)ct;
                            for (int i = 0; i < dtControlInfo.Rows.Count; i++)
                            {
                                if (dtControlInfo.Rows[i]["obj_type"].ToString().Trim() == "SimpleButton")
                                {
                                    if (dtControlInfo.Rows[i]["obj_name"].ToString().Trim() == btn.Name)
                                    {
                                        btn.Text = dtControlInfo.Rows[i]["show_name"].ToString();
                                    }
                                }
                            }
                        }
                        break;

                    default:
                        break;
                }
                if (ct.HasChildren) //容器對象時繼續遞規查找
                {
                    setValue(ct.Controls);
                }
            }
        }

        /// <summary>
        /// 取得工具欄按鈕權限臨時表
        /// </summary>
        private void GetToolbarGrant(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                int location = 0;
                string strtmp = "";
                string strLeft = "";
                string column_name = "";
                string field_Name = "";
                string field_state = "";
                DataRow[] dr = dt.Select();
                DataColumn dc = dtTSBtnRole.Columns.Add("id", Type.GetType("System.String"));
                dc = dtTSBtnRole.Columns.Add("state", Type.GetType("System.Boolean"));


                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    column_name = dt.Columns[i].ToString();
                    location = column_name.IndexOf("_");
                    strtmp = column_name.Substring(location + 1, 2);

                    if (strtmp == "ID" && column_name.Length <= 6)
                    {
                        strLeft = column_name.Substring(0, location);
                        field_Name = String.Format("{0}_ID", strLeft);
                        field_state = String.Format("{0}_STATE", strLeft);
                        if (dr[0][field_Name].ToString() != "")
                        {
                            DataRow newRow = dtTSBtnRole.NewRow();
                            newRow["id"] = dr[0][field_Name].ToString();
                            newRow["state"] = dr[0][field_state];
                            dtTSBtnRole.Rows.Add(newRow);
                        }
                    }
                }
            }
        }

        //生成數量單位Table
        public static void GenerateGoodsUnit(DataGridViewComboBoxColumn dgvcmbox, ComboBox cmbox)
        {
            DataTable dtGoodsUnit = new DataTable();
            dtGoodsUnit.Columns.Add(new DataColumn("Id", typeof(int)));
            dtGoodsUnit.Columns.Add(new DataColumn("Goods_Unit", typeof(string)));
            DataRow dr = dtGoodsUnit.NewRow();
            dr["Id"] = 0;
            dr["Goods_Unit"] = "PCS";
            dtGoodsUnit.Rows.Add(dr);

            dr = dtGoodsUnit.NewRow();
            dr["Id"] = 1;
            dr["Goods_Unit"] = "KG";
            dtGoodsUnit.Rows.Add(dr);

            dr = dtGoodsUnit.NewRow();
            dr["Id"] = 2;
            dr["Goods_Unit"] = "GRS";
            dtGoodsUnit.Rows.Add(dr);

            dr = dtGoodsUnit.NewRow();
            dr["Id"] = 3;
            dr["Goods_Unit"] = "SET";
            dtGoodsUnit.Rows.Add(dr);

            dr = dtGoodsUnit.NewRow();
            dr["Id"] = 4;
            dr["Goods_Unit"] = "G";
            dtGoodsUnit.Rows.Add(dr);

            //return dtGoodsUnit;
            if (dgvcmbox == null)
            {
                cmbox.DataSource = dtGoodsUnit;
                cmbox.DisplayMember = "Goods_Unit";
                cmbox.ValueMember = "Id";
            }
            else
            {
                dgvcmbox.DataSource = dtGoodsUnit;
                dgvcmbox.DisplayMember = "Goods_Unit";
                dgvcmbox.ValueMember = "Id";
            }
        }

        //生成貨幣Table
        public static void GenerateCurrency(DataGridViewComboBoxColumn dgvcmbox, ComboBox cmbox)
        {
            DataTable dtCurrency = new DataTable();
            dtCurrency.Columns.Add(new DataColumn("Id", typeof(int)));
            dtCurrency.Columns.Add(new DataColumn("Currency", typeof(string)));
            DataRow dr = dtCurrency.NewRow();
            dr["Id"] = 0;
            dr["Currency"] = "USD";
            dtCurrency.Rows.Add(dr);

            dr = dtCurrency.NewRow();
            dr["Id"] = 1;
            dr["Currency"] = "HKD";
            dtCurrency.Rows.Add(dr);

            dr = dtCurrency.NewRow();
            dr["Id"] = 2;
            dr["Currency"] = "RMB";
            dtCurrency.Rows.Add(dr);

            if (dgvcmbox == null)
            {
                cmbox.DataSource = dtCurrency;
                cmbox.DisplayMember = "Currency";
                cmbox.ValueMember = "Id";
            }
            else
            {
                dgvcmbox.DataSource = dtCurrency;
                dgvcmbox.DisplayMember = "Currency";
                dgvcmbox.ValueMember = "Id";
            }

        }

    }
}
