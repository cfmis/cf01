using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace cf01.CLS
{
    public class clsDataTableTextBoxBinder
    {
        private readonly DataTable _dt;
        private readonly GridView _gridView;
        private readonly Dictionary<TextBox, string> _bindings;

        public clsDataTableTextBoxBinder(DataTable dt, GridView gridView, Dictionary<TextBox, string> bindings)
        {
            _dt = dt;
            _gridView = gridView;
            _bindings = bindings;

            // 行切换时刷新 TextBox
            _gridView.FocusedRowChanged += (s, e) =>
            {
                if (e.FocusedRowHandle >= 0)
                {
                    DataRow row = _gridView.GetDataRow(e.FocusedRowHandle);
                    if (row != null && row.RowState != DataRowState.Detached)
                    {
                        foreach (var kvp in _bindings)
                        {
                            kvp.Key.Text = row[kvp.Value]?.ToString();
                        }
                    }
                }
            };

            // TextBox → DataTable 更新
            foreach (var kvp in _bindings)
            {
                TextBox tb = kvp.Key;
                string columnName = kvp.Value;

                tb.TextChanged += (s, e) =>
                {
                    int rowHandle = _gridView.FocusedRowHandle;
                    if (rowHandle >= 0)
                    {
                        DataRow row = _gridView.GetDataRow(rowHandle);
                        if (row != null && row.RowState != DataRowState.Detached)
                        {
                            row[columnName] = tb.Text;
                        }
                    }
                };
            }
        }

        /// <summary>
        /// 新增一行并自动定位到该行
        /// </summary>
        public void AddNewRow(Dictionary<string, object> defaultValues = null)
        {
            DataRow newRow = _dt.NewRow();

            if (defaultValues != null)
            {
                foreach (var kvp in defaultValues)
                {
                    newRow[kvp.Key] = kvp.Value;
                }
            }

            _dt.Rows.Add(newRow);

            // 定位到新行
            int newRowHandle = _gridView.RowCount - 1;
            _gridView.FocusedRowHandle = newRowHandle;
        }

        /// <summary>
        /// 删除当前选中行，并自动定位到下一行或最后一行
        /// </summary>
        public void DeleteCurrentRow()
        {
            int rowHandle = _gridView.FocusedRowHandle;
            if (rowHandle >= 0)
            {
                DataRow row = _gridView.GetDataRow(rowHandle);
                if (row != null && row.RowState != DataRowState.Detached)
                {
                    _dt.Rows.Remove(row);
                }

                // 删除后自动定位
                if (_gridView.RowCount > 0)
                {
                    int newHandle = Math.Min(rowHandle, _gridView.RowCount - 1);
                    _gridView.FocusedRowHandle = newHandle;
                }
                else
                {
                    // 没有行了，清空 TextBox
                    foreach (var kvp in _bindings)
                    {
                        kvp.Key.Text = string.Empty;
                    }
                }
            }
        }

    }
}
