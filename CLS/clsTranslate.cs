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
    public class clsTranslate
    {
        private string m_strFrmName;
        private Control.ControlCollection m_controlCollectin;
        private string m_language;
        DataTable dtControlInfo = new DataTable();
        public clsTranslate(string frmName, Control.ControlCollection controlCollection, string lang)
        {
            m_strFrmName = frmName;
            m_controlCollectin = controlCollection;
            m_language = lang;
        }

        public void Translate()
        {
            try
            {
                dtControlInfo = clsRoleManage.GetAllControlInfo(m_strFrmName, m_language);
                if (dtControlInfo.Rows.Count > 0)
                {
                    setValue(m_controlCollectin);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 表單控件翻譯
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
                            string strBtn = "BTN";
                            if (ts.Items.Count <= 0)
                            {
                                for (int i = 0; i < dtControlInfo.Rows.Count; i++)
                                {
                                    if (dtControlInfo.Rows[i]["obj_type"].ToString().Trim() == strBtn)
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
                                    }
                                }
                            }
                        }
                        break;
                    case "Label":  //文本標簽
                        {
                            Label lab = (Label)ct;
                            string strName = "label";
                            for (int i = 0; i < dtControlInfo.Rows.Count; i++)
                            {
                                if (dtControlInfo.Rows[i]["obj_type"].ToString().Trim() == strName)
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
                                                DataGridViewMaskedTextBoxColumn dgvMtxt = new DataGridViewMaskedTextBoxColumn();
                                                dgvMtxt.Name = strObjName;
                                                dgvMtxt.HeaderText = dtControlInfo.Rows[i]["show_name"].ToString();
                                                if (strObjName == "valid_date")
                                                {
                                                    dgvMtxt.Mask = "0000/00/00";
                                                }
                                                dgv.Columns.Add(dgvMtxt);
                                            }
                                            break;
                                        case "DataGridViewComboBoxColumn":
                                            {
                                                DataGridViewComboBoxColumn dgvCmbox = new DataGridViewComboBoxColumn();
                                                dgvCmbox.Name = strObjName;
                                                dgvCmbox.HeaderText = dtControlInfo.Rows[i]["show_name"].ToString();
                                                dgvCmbox.Items.Clear();
                                                if (strObjName == "goods_unit")
                                                {
                                                    // GenerateGoodsUnit(dgvCmbox, null);
                                                }
                                                if (strObjName == "m_id")
                                                {
                                                    // GenerateCurrency(dgvCmbox, null);
                                                }
                                                dgvCmbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                                                dgvCmbox.DisplayStyleForCurrentCellOnly = true;
                                                dgv.Columns.Add(dgvCmbox);
                                            }
                                            break;
                                        case "DataGridViewCheckBoxColumn":
                                            {
                                                DataGridViewCheckBoxColumn dgvCheckbox = new DataGridViewCheckBoxColumn();
                                                dgvCheckbox.HeaderText = dtControlInfo.Rows[i]["show_name"].ToString();
                                                dgvCheckbox.Name = strObjName;
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
                    case "CheckEdit":
                        {
                            DevExpress.XtraEditors.CheckEdit btn = (DevExpress.XtraEditors.CheckEdit)ct;
                            for (int i = 0; i < dtControlInfo.Rows.Count; i++)
                            {
                                if (dtControlInfo.Rows[i]["obj_type"].ToString().Trim() == "CheckEdit")
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
    }
}
