using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using cf01.ModuleClass;
using cf01.CLS;

namespace cf01.ReportForm
{
    public partial class frmArtworkShow : Form
    {
        DataTable dtbDetails;
        public frmArtworkShow()
        {
            InitializeComponent();
            dtbDetails = frmArtworkSearch.dtTemp_details;
            gridControl1.DataSource = dtbDetails;
            gridView1.BestFitColumns(); //列寬自適應

            this.gridView1.IndicatorWidth = 40;

            clsControlInfoHelper oMutilang = new clsControlInfoHelper(this.Name, this.Controls);
            oMutilang.GenerateContorl();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dtbDetails.Rows.Count > 0)
            {
                PrintingSystem printingSystem1 = new PrintingSystem();
                PrintableComponentLink printableComponentLink1 = new PrintableComponentLink();

                // Add the link to the printing system's collection of links.
                printingSystem1.Links.AddRange(new object[] { printableComponentLink1 });

                // Assign a control to be printed by this link.
                printableComponentLink1.Component = gridControl1;
               
                // Set the paper orientation to Landscape.
                printableComponentLink1.Landscape = true;//橫向縱向設置

                //显示打印预览
                printableComponentLink1.ShowPreview();
                
                //直接送至打印機
                //printableComponentLink1.PrintDlg();
            }
        }

        private void frmArtworkShow_FormClosed(object sender, FormClosedEventArgs e)
        {
            dtbDetails.Dispose();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export To Excel";
            saveFileDialog.Filter = "Excel files (*.xls)|*.xls";
            DialogResult dialogResult = saveFileDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {                
                gridControl1.ExportToXls(saveFileDialog.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("Successfully saved.", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //顯示行號
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }
    }
}
