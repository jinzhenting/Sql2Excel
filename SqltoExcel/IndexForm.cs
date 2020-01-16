using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Xml;

namespace SqltoExcel
{
    public partial class IndexForm : Form
    {
        public IndexForm()
        {
            InitializeComponent();
        }

        private void IndexForm_Load(object sender, EventArgs e)
        {
            //标题
            this.Text += " " + Application.ProductVersion;
            //程序图标
            IconSetting();
            //配置列表
            ListLoad();
        }

        //程序图标加载
        private void IconSetting()
        {
            try
            {
                string path = Path.Combine(Application.StartupPath, "Icon.ico");
                Icon icon = new Icon(path);
                this.Icon = icon;
            }
            catch (Exception exception)
            {
                MessageBox.Show("程序图标加载失败，程序将自动退出，信息如下\n\r" + exception);
                this.Close();
            }
        }
        
        //配置列表
        private List<string> command_list = new List<string>();
        private void ListLoad()
        {
            try
            {
                //
                list_combobox.Items.Clear();
                command_list.Clear();
                command_textbox.Text = "";
                //注意XML内容区分大小写
                XmlDocument xml = new XmlDocument();
                xml.Load("CommandList.xml");
                //搜索定位子节点CommandList
                XmlNodeList nodelist = xml.SelectSingleNode("//CommandList").ChildNodes;
                foreach (XmlNode node in nodelist)
                {
                    //遍历字段
                    XmlElement element = (XmlElement)node;
                    list_combobox.Items.Add(element.InnerText);
                    command_list.Add(element.GetAttribute("xmlns").ToString());
                }
                //
            }
            catch (Exception exception)
            {
                //
                if (exception.ToString().Contains("未能找到文件"))
                {
                    MessageBox.Show("列表配置文件不存在，程序将自动退出");
                    this.Close();
                }
                //
                MessageBox.Show("读取列表配置文件时发生未知错误，程序将自动退出，信息如下\r\n" + exception);
                this.Close();
            }
        }

        //选择列表
        private void list_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            command_textbox.Text = command_list[list_combobox.SelectedIndex];
        }

        //生成按钮
        private void preview_button_Click(object sender, EventArgs e)
        {
            //
            if (command_textbox.Text == "")
            {
                MessageBox.Show("请输入语句");
                return;
            }
            //
            try
            {
                //清空表数据
                data_table.DataSource = null;
                data_table.Columns.Clear();
                //初始化链接
                progress_label.Text = "初始化链接";
                progressbar.Value = 25;
                percentage_label.Text = progressbar.Value.ToString() + "%";
                //获取Configuration对象
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //根据Key读取元素的Value
                string server = config.AppSettings.Settings["server"].Value;
                string data_name = config.AppSettings.Settings["data_name"].Value;
                string user_id = config.AppSettings.Settings["user_id"].Value;
                string password = config.AppSettings.Settings["password"].Value;
                string connection = "Server=" + server + "; Initial Catalog=" + data_name + "; User ID=" + user_id + "; Password=" + password;
                //封装传递
                var sql = new object[2];
                sql[0] = connection;
                sql[1] = command_textbox.Text;
                sql_background.RunWorkerAsync(sql);
            }
            catch (Exception exception)
            {
                MessageBox.Show("初始化链接错误\r\n" + exception.ToString());
                progressbar.Value = 0;
                progress_label.Text = "等待操作";
                percentage_label.Text = progressbar.Value.ToString() + "%";
            }
        }
        
        //
        private void sql_background_DoWork(object sender, DoWorkEventArgs e)
        {
            //
            if (sql_background.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            //
            try
            {
                //传入解封
                var in_sql = e.Argument as object[];
                string connection = (string)in_sql[0];
                string command = (string)in_sql[1];
                //进度
                sql_background.ReportProgress(50, "");
                //链接
                SqlDataAdapter sqldataadapter = new SqlDataAdapter();
                SqlConnection sqlconnection = new SqlConnection(connection);
                SqlCommand sqlcommand = new SqlCommand(command, sqlconnection);
                sqlconnection.Open();
                sqldataadapter.SelectCommand = sqlcommand;
                DataTable out_table = new DataTable();
                sqldataadapter.Fill(out_table);
                sqlconnection.Close();
                //传出
                e.Result = out_table;
                //进度
                sql_background.ReportProgress(100, "");
            }
            catch (Exception exception)
            {
                //
                if (exception.ToString().ToLower().Contains("error number:102"))
                {
                    MessageBox.Show("查询语法错误");
                    return;
                }
                //
                if (exception.ToString().ToLower().Contains("error number:53"))
                {
                    MessageBox.Show("无法连接服务器，请检查设置");
                    return;
                }
                //
                if (exception.ToString().ToLower().Contains("error number:4060"))
                {
                    MessageBox.Show("数据库名称不存在，请检查设置");
                    return;
                }
                //
                if (exception.ToString().ToLower().Contains("error number:18456"))
                {
                    MessageBox.Show("数据库用户名或密码错误，请检查设置");
                    return;
                }
                //
                MessageBox.Show("数据查询未知错误\r\n" + exception);
            }
        }

        //
        private void sql_background_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressbar.Value = e.ProgressPercentage;
            progress_label.Text = "查询进度";
            percentage_label.Text = progressbar.Value.ToString() + "%";
        }

        //
        private void sql_background_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                progressbar.Value = 0;
                progress_label.Text = "查询后台出错";
                percentage_label.Text = progressbar.Value.ToString() + "%";
                return;
            }
            if (e.Cancelled)
            {
                progressbar.Value = 0;
                progress_label.Text = "查询已取消";
                percentage_label.Text = progressbar.Value.ToString() + "%";
                return;
            }
            //传出
            if (e.Result != null)
            {
                progressbar.Value = 100;
                progress_label.Text = "查询已完成";
                percentage_label.Text = progressbar.Value.ToString() + "%";
                data_table.DataSource = e.Result;
            }
            else
            {
                progressbar.Value = 0;
                progress_label.Text = "查询无数据返回";
                percentage_label.Text = progressbar.Value.ToString() + "%";
                data_table.DataSource = e.Result;
            }
        }

        //导出按钮
        private void toexcel_button_Click(object sender, EventArgs e)
        {
            //
            if (data_table.DataSource == null)
            {
                MessageBox.Show("表格无数据");
                return;
            }
            //
            try
            {
                progress_label.Text = "表格写入进度";
                percentage_label.Text = progressbar.Value.ToString() + "%";
                //封装传递
                var excel = new object[2];
                excel[0] = (DataTable)data_table.DataSource;
                excel[1] = true;
                excel_background.RunWorkerAsync(excel);
            }
            catch (Exception exception)
            {
                MessageBox.Show("导出表格时发生未知错误，信息如下\r\n" + exception.ToString());
            }
        }

        //异步工作
        private void excel_background_DoWork(object sender, DoWorkEventArgs e)
        {
            if (excel_background.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            //
            try
            {
                //参数解封
                var in_excel = e.Argument as object[];
                DataTable datatable = (DataTable)in_excel[0];
                bool open = (bool)in_excel[1];
                //
                if (datatable.Rows.Count <= 1)
                {
                    return;
                }
                //
                DataTable in_table = datatable;
                int row_count = 1;
                int column_count = 0;
                //建立Excel对象
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Application.Workbooks.Add(true);
                //生成字段名称
                foreach (DataColumn column in in_table.Columns)
                {
                    column_count++;
                    excel.Cells[1, column_count] = column.ColumnName;
                }
                int count = 0;
                //填充数据
                foreach (DataRow row in in_table.Rows)
                {
                    count++;
                    row_count++;
                    column_count = 0;
                    foreach (DataColumn col in in_table.Columns)
                    {
                        column_count++;
                        excel.Cells[row_count, column_count] = row[col.ColumnName];
                        //进度
                        decimal d1 = count;
                        decimal d2 = in_table.Rows.Count;
                        decimal d3 = decimal.Parse((d1 / d2).ToString("0.000")); //保留3位小数
                        var v1 = Math.Round(d3, 2);  //四舍五入精确2位
                        var v2 = v1 * 100;  //乘
                        excel_background.ReportProgress((int)v2, "updata");
                    }
                }
                //是否打开生成的表格
                excel.Visible = open;
                excel.Quit();
            }
            catch
            {
                MessageBox.Show("填写表格时被中断，写入过程中请勿操作表格");
            }
        }

        //导出异步进度
        private void excel_background_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressbar.Value = e.ProgressPercentage;
            progress_label.Text = "表格写入进度";
            percentage_label.Text = progressbar.Value.ToString() + "%";
        }

        //导出异步结束
        private void excel_background_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("表格写入进程错误\r\n" + e.Error.ToString());
                progressbar.Value = 0;
                progress_label.Text = "表格写入错误";
                return;
            }
            if (e.Cancelled)
            {
                MessageBox.Show("表格写入已取消");
                progressbar.Value = 0;
                progress_label.Text = "表格写入已取消";
                return;
            }
            progressbar.Value = 100;
            progress_label.Text = "表格写入已完成";
        }

        //导出保存按钮
        private void save_button_Click(object sender, EventArgs e)
        {
            //
            if (command_textbox.Text == "")
            {
                MessageBox.Show("语句不能为空");
                return;
            }
            //
            AddForm addform = new AddForm();
            addform.Command = command_textbox.Text;
            if (addform.ShowDialog() == DialogResult.OK)
            {
                ListLoad();
            }
        }

        //删除按钮
        private void delete_button_Click(object sender, EventArgs e)
        {
            //
            if (command_textbox.Text == "")
            {
                MessageBox.Show("列表未选择");
                return;
            }
            //
            DialogResult result = MessageBox.Show("删除后将无法恢复", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                ListDelete("CommandList.xml", list_combobox.Text);
            }
        }

        //删除功能
        public void ListDelete(string xml_path, string in_node)
        {
            try
            {
                //注意XML内容区分大小写
                XmlDocument xml = new XmlDocument();
                xml.Load(xml_path);
                //取到根结点
                var root = xml.DocumentElement;
                //定位到CommandList
                XmlNode node_list = xml.SelectSingleNode("//CommandList");
                //如果不定位到CommandList，可以全局遍历XmlNode node in root.ChildNodes
                foreach (XmlNode node in node_list)
                {
                    //遍历node_list查找
                    if (node.InnerText == in_node)
                    {
                        root.RemoveChild(node);
                        xml.Save(xml_path);
                        MessageBox.Show("删除成功");
                        ListLoad();
                        return;
                    }
                }
                MessageBox.Show("未找到语句");
            }
            catch (Exception exception)
            {
                //
                if (exception.ToString().Contains("未能找到文件"))
                {
                    MessageBox.Show("列表配置文件不存在");
                }
                //
                if (exception.ToString().Contains("访问被拒绝"))
                {
                    MessageBox.Show("写入错误，请检查列表配置文件是否已被打开或设置只读");
                }
                //
                MessageBox.Show("删除时发生未知错误，信息如下\r\n" + exception);
            }
        }

        //数据库配置菜单
        private void server_menu_Click(object sender, EventArgs e)
        {
            ServerForm serverform = new ServerForm();
            serverform.ShowDialog();
        }

        private void help_menu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请联系IT人员");
        }

        private void show_menu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("程序版本：" + Application.ProductVersion + "\r\n更新日期：20191107\r\n开发支持：jinzhenting@aliyun.com");
        }

        private void esc_menu_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //
    }
}
