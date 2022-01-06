using cf01.CLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cf01.Forms
{
    public partial class frmPvhFinish : Form
    {
        public string strFinish="";
        public DataTable dtFinish = new DataTable();
        public frmPvhFinish()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            strFinish = "";
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            strFinish = "";
            for (int i = 0; i < dtFinish.Rows.Count;i++){
                if(dtFinish.Rows[i]["flagSelect"].ToString()=="True")
                {
                    if (strFinish != "")
                    {
                        strFinish += ";" + dtFinish.Rows[i]["contents"].ToString();
                    }else
                    {
                        strFinish = dtFinish.Rows[i]["contents"].ToString();
                    }
                }
            }
            this.Close();
        }

        private void frmPvhFinish_Load(object sender, EventArgs e)
        {
            dtFinish = clsDevelopentPvh.GetFinish();            
            dgvFinish.DataSource = dtFinish;
        }

        private void chkAll_MouseUp(object sender, MouseEventArgs e)
        {
            bool status = false;
            if (chkAll.Checked)
            {
                status = true;
            }
            else
            {
                status = false;
            }
            for (int i = 0; i < dtFinish.Rows.Count; i++)
            {
                dtFinish.Rows[i]["flagSelect"] = status;               
            }
        }
    }
}
