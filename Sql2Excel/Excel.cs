using Aspose.Cells;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Sql2Excel
{
    public static class Excel
    {
        /// <summary>
        /// DataTable转Excel文件
        /// </summary>
        /// <param name="dataTable">传入DataTable</param>
        /// <param name="path">保存位置</param>
        public static void ExportExcelWithAspose(DataTable dataTable, string path)
        {
            if (dataTable == null)
            {
                MessageBox.Show("不能导出空白数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Workbook workbook = new Workbook();
                Worksheet cellSheet = workbook.Worksheets[0];
                // 为head添加样式      
                Style headStyle = workbook.Styles[workbook.Styles.Add()];
                // 设置居中  
                headStyle.HorizontalAlignment = TextAlignmentType.Center;
                // 设置背景颜色  
                headStyle.ForegroundColor = System.Drawing.Color.FromArgb(215, 236, 241);
                headStyle.Pattern = BackgroundType.Solid;
                headStyle.Font.Size = 12;
                headStyle.Font.Name = "宋体";
                headStyle.Font.IsBold = true;

                // 为单元格添加样式      
                Style cellStyle = workbook.Styles[workbook.Styles.Add()];
                // 设置居中
                cellStyle.HorizontalAlignment = TextAlignmentType.Center;
                cellStyle.Pattern = BackgroundType.Solid;
                cellStyle.Font.Size = 12;
                cellStyle.Font.Name = "宋体";

                // 设置列宽 从0开始 列宽单位是字符
                cellSheet.Cells.SetColumnWidth(1, 43);
                cellSheet.Cells.SetColumnWidth(5, 12);
                cellSheet.Cells.SetColumnWidth(7, 10);
                cellSheet.Cells.SetColumnWidth(8, 14);
                cellSheet.Cells.SetColumnWidth(9, 14);

                int rowIndex = 0;
                int colIndex = 0;
                int colCount = dataTable.Columns.Count;
                int rowCount = dataTable.Rows.Count;
                // Head 列名处理
                for (int i = 0; i < colCount; i++)
                {
                    cellSheet.Cells[rowIndex, colIndex].PutValue(dataTable.Columns[i].ColumnName);
                    cellSheet.Cells[rowIndex, colIndex].SetStyle(headStyle);
                    colIndex++;
                }
                rowIndex++;
                // Cell 其它单元格处理
                for (int i = 0; i < rowCount; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j < colCount; j++)
                    {
                        cellSheet.Cells[rowIndex, colIndex].PutValue(dataTable.Rows[i][j].ToString());
                        cellSheet.Cells[rowIndex, colIndex].SetStyle(cellStyle);
                        colIndex++;
                    }
                    rowIndex++;
                }
                cellSheet.AutoFitColumns();  // 列宽自动匹配，当列宽过长是收缩
                path = Path.GetFullPath(path);
                // workbook.Save(path,SaveFormat.CSV);
                workbook.Save(path);
            }
            catch (Exception e)
            {
                MessageBox.Show("导出Excel失败\r\n\r\n" + e.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

    }
}
