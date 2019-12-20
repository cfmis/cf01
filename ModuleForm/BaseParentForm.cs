using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cf01
{
	public partial class BaseParentForm : Form
	{
		public virtual void setBtnAdd(bool isEnable)
		{
			btnAdd.Enabled = isEnable;
			
		}
		public virtual void setBtnDel(bool isEnable)
		{
			btnDel.Enabled = isEnable;
		}
		public virtual void setBtnCan(bool isEnable)
		{
			btnCancel.Enabled = isEnable;
		}
		public virtual void setBtnSave(bool isEnable)
		{
			btnSave.Enabled = isEnable;
		}
		public virtual void setBtnEdit(bool isEnable)
		{
			btnEdit.Enabled = isEnable;
		}
		public virtual void setBtnFind(bool isEnable)
		{
			btnFind.Enabled = isEnable;
		}
		public virtual void setBtnPrint(bool isEnable)
		{
			btnPrint.Enabled = isEnable;
		}

		public BaseParentForm()
		{
			InitializeComponent();

			
		}

		private void toolStripButton6_Click(object sender, EventArgs e)
		{
            //if (this.toolStrip1.Tag != "3")
            //{
            //    MessageBox.Show("正在編輯記錄,確定退出嗎?", "系統信息");
            //}
            this.Close();
		}

		public virtual void Add() { }
		private void trbAdd_Click(object sender, EventArgs e)
		{
            this.toolStrip1.Tag = "1";
            this.control_status(this.toolStrip1.Tag.ToString());
            this.textBox_edit_status(this.toolStrip1.Tag.ToString());
            this.textBox_clear(this.toolStrip1.Tag.ToString());
            Add();
		}
        public virtual bool Bef_Edit() { return true; }
		public virtual void Edit() { }
		private void trbEdit_Click(object sender, EventArgs e)
		{
            if (this.Bef_Edit())
            {
                this.toolStrip1.Tag = "2";
                this.control_status(this.toolStrip1.Tag.ToString());
                this.textBox_edit_status(this.toolStrip1.Tag.ToString());
                this.textBox_clear(this.toolStrip1.Tag.ToString());
                Edit();
            }
		}
        public virtual bool Bef_Save() { return true; }
        public virtual bool Save() { return true; }
		private void trbSave_Click(object sender, EventArgs e)
		{
            if (this.Bef_Save())
            {
                if (this.Save())
                {
                    this.toolStrip1.Tag = "3";
                    this.control_status(this.toolStrip1.Tag.ToString());
                    this.textBox_edit_status(this.toolStrip1.Tag.ToString());
                    this.textBox_clear(this.toolStrip1.Tag.ToString());
                    this.Aft_Save();
                }
            }
		}
        public virtual void Aft_Save() { }
		public virtual void Find() { }
		private void trbFind_Click(object sender, EventArgs e)
		{
            this.toolStrip1.Tag = "3";
            Find();
		}
        public virtual bool Bef_Del() { return true; }
        public virtual bool Del() { return true; }
        public virtual void Aft_Del() { }
		private void trbDel_Click(object sender, EventArgs e)
		{
            if (this.Bef_Del())
            {
                if (this.Del())
                {
                    this.toolStrip1.Tag = "3";
                    this.Aft_Del();
                }
            }
		}
		public virtual void Print() { }
		private void trbPrint_Click(object sender, EventArgs e)
		{
            this.toolStrip1.Tag = "3";
            Print();
		}
		public virtual void Cancel() { }
		private void trbCancel_Click(object sender, EventArgs e)
		{
            this.toolStrip1.Tag = "3";
            this.control_status(this.toolStrip1.Tag.ToString());
            this.textBox_edit_status(this.toolStrip1.Tag.ToString());
            this.textBox_clear(this.toolStrip1.Tag.ToString());
            Cancel();
		}
        private void control_status(string flag)
        {
            if (flag == "1")
            {
                this.btnAdd.Enabled = false;
                this.btnDel.Enabled = false;
                this.btnEdit.Enabled = false;
                this.btnCancel.Enabled = true;
                this.btnSave.Enabled = true;
                this.btnFind.Enabled = false;
                this.btnPrint.Enabled = false;
            }
            else if (flag == "2")
            {
                this.btnAdd.Enabled = false;
                this.btnDel.Enabled = false;
                this.btnEdit.Enabled = false;
                this.btnCancel.Enabled = true;
                this.btnSave.Enabled = true;
                this.btnFind.Enabled = false;
                this.btnPrint.Enabled = false;
            }
            else if (flag == "3")
            {
                this.btnAdd.Enabled = true;
                this.btnDel.Enabled = true;
                this.btnEdit.Enabled = true;
                this.btnCancel.Enabled = false;
                this.btnSave.Enabled = false;
                this.btnFind.Enabled = true;
                this.btnPrint.Enabled = true;
            }
        }
        public virtual void textBox_edit_status(string edit_flag) { }
        public virtual void textBox_clear(string edit_flag) { }
	}
}
