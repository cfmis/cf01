using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cf01.ModuleClass;

namespace cf01.ModuleForm
{
    public partial class BaseFormMaster : Form
    {
        public BaseFormMaster()
        {
            InitializeComponent();
        }

        public virtual void New() { }
        public virtual void Excel() { }
        public virtual void Edit() { }
        public virtual void Remove() { }
        public virtual void Find() { }
        public virtual void Cancel() { }
        public virtual void Save() { }
        public virtual void Print() { }
        public virtual void Refreshed() { }
        //public virtual void Closing() { }
        public virtual void Exit()
        {
            this.Close();
        }
        public virtual void Report() { }
        public virtual void Preview() { }
        public virtual void Lock() { }
        public virtual void Unlock() { }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string strOperationName = e.ClickedItem.Name.ToString();
            switch (strOperationName)
            {
                case "BTNCANCEL":
                    Cancel();
                    break;
                case "BTNCLOSE":
                    //Closing();
                    break;
                case "BTNDELETE":
                    Remove();
                    break;
                case "BTNEDIT":
                    Edit();
                    break;
                case "BTNEXCEL":
                    Excel();
                    break;
                case "BTNEXIT":
                    Exit();
                    break;
                case "BTNExpMo":

                    break;
                case "BTNFIND":
                    Find();
                    break;
                case "BTNNEW":
                    New();
                    break;
                case "BTNPRINT":
                    Print();
                    break;
                case "BTNREFRESH":
                    Refreshed();
                    break;
                case "BTNSAVE":
                    Save();
                    break;
                case "BTNPREVIEW":
                    Preview();
                    break;
                case "BTNREPORT":
                    Report();
                    break;
                case "BTNLOCK":
                    Lock();
                    break;
                case "BTNUNLOCK":
                    Unlock();
                    break;
                default:
                    break;
            }
        }
     
    }
}
