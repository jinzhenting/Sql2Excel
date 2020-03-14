using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Xml;
using Aspose.Cells;

namespace Sql2Excel
{
    /// <summary>
    /// 程序主窗口
    /// </summary>
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗口载入时
        /// </summary>
        private void IndexForm_Load(object sender, EventArgs e)
        {
            this.Text += " " + Application.ProductVersion;// 标题
            IconSetting();
            ListLoad();
        }

        /// <summary>
        /// 程序图标加载
        /// </summary>
        private void IconSetting()
        {
            try
            {
                this.Icon = new Icon("Icon.ico");
            }
            catch (Exception exception)
            {
                MessageBox.Show("程序图标加载失败，程序将自动退出，信息如下\n\r\n\r" + exception, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        /// <summary>
        /// SQL语句列表
        /// </summary>
        private List<string> commandList = new List<string>();

        /// <summary>
        /// 配置列表
        /// </summary>
        private void ListLoad()
        {
            try
            {
                if (listComboBox.Items.Count > 0) listComboBox.Items.Clear();
                if (commandList.Count > 0) commandList.Clear();
                if (commandTextBox.Text != "") commandTextBox.Text = "";
                XmlDocument xmlDocument = new XmlDocument();// 注意编写XML内容区分大小写
                xmlDocument.Load("CommandList.xml");
                XmlNodeList xmlNodeList = xmlDocument.SelectSingleNode("//CommandList").ChildNodes;// 搜索定位子节点CommandList
                foreach (XmlNode xmlNode in xmlNodeList)
                {
                    XmlElement element = (XmlElement)xmlNode;// 遍历字段
                    listComboBox.Items.Add(element.InnerText);
                    commandList.Add(element.GetAttribute("xmlns").ToString());
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("无权限访问配置文件CommandList.xml，请尝试使用管理员权限运行本程序，程序将自动退出，描述如下\r\n\r\n" + ex, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("配置文件CommandList.xml不存在，程序将自动退出，描述如下\r\n\r\n" + ex, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("访问配置文件CommandList.xml时发生错误，程序将自动退出，描述如下\r\n\r\n" + ex, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// 列表选择时
        /// </summary>
        private void listComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            commandTextBox.Text = commandList[listComboBox.SelectedIndex];
        }

        /// <summary>
        /// 生成按钮
        /// </summary>
        private void previewButton_Click(object sender, EventArgs e)
        {
            if (commandTextBox.Text == "")
            {
                MessageBox.Show("请输入语句", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            try
            {
                if (dataGridView.DataSource != null)// 清空表数据
                {
                    dataGridView.DataSource = null;
                    dataGridView.Columns.Clear();
                }
                progressBar.Value = 25;
                progressLabel.Text = progressBar.Value.ToString() + "% 初始化链接";
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);// 获取Configuration对象
                string server = config.AppSettings.Settings["server"].Value;// 根据Key读取元素的Value
                string dataName = config.AppSettings.Settings["data_name"].Value;
                string userID = config.AppSettings.Settings["user_id"].Value;
                string password = config.AppSettings.Settings["password"].Value;
                string connection = "Server=" + server + "; Initial Catalog=" + dataName + "; User ID=" + userID + "; Password=" + password;
                var sql = new object[2];// 装箱
                sql[0] = connection;
                sql[1] = commandTextBox.Text;
                sqlBack.RunWorkerAsync(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化链接错误，描述如下\r\n\r\n" + ex, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBar.Value = 0;
                progressLabel.Text = progressBar.Value.ToString() + "% 等待用户操作";
            }
        }
        
        /// <summary>
        /// 导步查询数据库开始
        /// </summary>
        private void sqlBack_DoWork(object sender, DoWorkEventArgs e)
        {
            if (sqlBack.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            try
            {
                var sql = e.Argument as object[];// 拆箱
                string connection = (string)sql[0];
                string command = (string)sql[1];
                sqlBack.ReportProgress(50, "");// 进度
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();// 链接
                SqlConnection sqlConnection = new SqlConnection(connection);
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = sqlCommand;
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();
                e.Result = dataTable;// 传出
                sqlBack.ReportProgress(100, "");// 进度
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库操作错误，描述如下\r\n\r\n" + ex, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 导步查询数据库进度
        /// </summary>
        private void sqlBack_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            progressLabel.Text = progressBar.Value.ToString() + "% 查询中";
        }

        /// <summary>
        /// 导步查询数据库完成
        /// </summary>>
        private void sqlBack_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                progressBar.Value = 0;
                progressLabel.Text = progressBar.Value.ToString() + "% 查询后台出错";
                return;
            }
            if (e.Cancelled)
            {
                progressBar.Value = 0;
                progressLabel.Text = progressBar.Value.ToString() + "% 查询已取消";
                return;
            }
            if (e.Result != null)// 传出
            {
                progressBar.Value = 100;
                progressLabel.Text = progressBar.Value.ToString() + "% 查询已完成";
                dataGridView.DataSource = e.Result;
            }
            else
            {
                progressBar.Value = 0;
                progressLabel.Text = progressBar.Value.ToString() + "% 查询无数据返回";
                dataGridView.DataSource = e.Result;
            }
        }

        /// <summary>
        /// 导出表格按钮
        /// </summary>
        private void toExcelButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count < 1)
            {
                MessageBox.Show("请先查询并生成数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();// 保存窗口
            saveFileDialog.Filter = "Excel表格(*.xlsx)|*.xlsx";//设置文件类型
            saveFileDialog.FileName = "新建Excel表格";//设置默认文件名
            saveFileDialog.DefaultExt = "xlsx";//设置默认格式（可以不设）
            saveFileDialog.AddExtension = true;//设置自动在文件名中添加扩展名
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                progressBar.Value = 0;
                progressLabel.Text = progressBar.Value.ToString() + "% 导出中";
                var excel = new object[3];// 装箱
                excel[0] = (DataTable)dataGridView.DataSource;
                excel[1] = true;
                excel[2] = saveFileDialog.FileName;
                excelBack.RunWorkerAsync(excel);
            }
        }

        /// <summary>
        /// 导步导出表格开始
        /// </summary>
        private void excelBack_DoWork(object sender, DoWorkEventArgs e)
        {
            if (excelBack.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            try
            {
                var exc = e.Argument as object[];// 拆箱
                DataTable datatable = (DataTable)exc[0];
                bool open = (bool)exc[1];
                string path = (string)exc[2];

                if (datatable.Rows.Count <= 1) return;
                DataTable dataTable = datatable;

                if (dataTable == null)
                {
                    MessageBox.Show("不能导出空白数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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
                cellStyle.HorizontalAlignment = TextAlignmentType.Left;
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
                workbook.Save(path);// workbook.Save(path,SaveFormat.CSV);
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出表格时发生错误，描述如下：\r\n\r\n" + ex, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// 导步导出表格进度
        /// </summary>
        private void excelBack_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            progressLabel.Text = progressBar.Value.ToString() + "% 表格写入中";
        }

        /// <summary>
        /// 导步导出表格完成
        /// </summary>
        private void excelBack_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("表格写入进程错误\r\n\r\n" + e.Error.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressBar.Value = 0;
                progressLabel.Text = "表格写入错误";
                return;
            }
            if (e.Cancelled)
            {
                MessageBox.Show("表格写入已取消", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                progressBar.Value = 0;
                progressLabel.Text = "表格写入已取消";
                return;
            }
            progressBar.Value = 100;
            progressLabel.Text = "表格写入已完成";
        }

        /// <summary>
        /// SQL语句保存按钮
        /// </summary>
        private void saveSqlButton_Click(object sender, EventArgs e)
        {
            if (commandTextBox.Text == "")
            {
                MessageBox.Show("语句不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SqlAddForm addForm = new SqlAddForm();
            addForm.Command = commandTextBox.Text;
            if (addForm.ShowDialog() == DialogResult.OK)ListLoad();
        }

        /// <summary>
        /// SQL语句删除按钮
        /// </summary>
        private void deleteSqlButton_Click(object sender, EventArgs e)
        {
            if (commandTextBox.Text == "")
            {
                MessageBox.Show("列表未选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("删除后将无法恢复", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)ListDelete(listComboBox.Text);
        }

        /// <summary>
        /// 删除SQL语句
        /// </summary>
        /// <param name="sql">Sql语句名</param>
        public void ListDelete(string sql)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();// 注意XML内容区分大小写
                xmlDocument.Load("CommandList.xml");
                var root = xmlDocument.DocumentElement;// 取到根结点
                XmlNode xmlNode = xmlDocument.SelectSingleNode("//CommandList");// 定位到CommandList
                foreach (XmlNode node in xmlNode)// 如果不定位到CommandList，可以全局遍历XmlNode node in root.ChildNodes
                {
                    if (node.InnerText == sql)// 遍历node_list查找
                    {
                        root.RemoveChild(node);
                        xmlDocument.Save("CommandList.xml");
                        MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        ListLoad();
                        return;
                    }
                }
                MessageBox.Show("未找到语句");
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("无权限访问配置文件CommandList.xml，请尝试使用管理员权限运行本程序，程序将自动退出，描述如下\r\n\r\n" + ex, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("配置文件CommandList.xml不存在，程序将自动退出，描述如下\r\n\r\n" + ex, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("访问配置文件CommandList.xml时发生错误，程序将自动退出，描述如下\r\n\r\n" + ex, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// 数据库配置菜单
        /// </summary>
        private void serverMenuItem_Click(object sender, EventArgs e)
        {
            SqlServerForm serverform = new SqlServerForm();
            serverform.ShowDialog();
        }

        /// <summary>
        /// 帮助菜单
        /// </summary>
        private void helpMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请联系IT人员", "帮助", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 程序说明菜单
        /// </summary>
        private void showMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("程序版本：" + Application.ProductVersion + "\r\n更新日期：20191107\r\n开发支持：jinzhenting@aliyun.com", "程序说明", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 程序关闭菜单
        /// </summary>
        private void escMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
