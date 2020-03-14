using System;
using System.Windows.Forms;
using System.Xml;

namespace Sql2Excel
{
    public partial class SqlAddForm : Form
    {
        public SqlAddForm()
        {
            InitializeComponent();
        }

        //
        private string command;
        public string Command
        {
            get
            {
                return command;
            }
            set
            {
                command = value;
            }
        }

        //
        private void ok_add_button_Click(object sender, EventArgs e)
        {
            //
            if (name_textbox.Text == "")
            {
                MessageBox.Show("请输入名称");
                return;
            }
            AddCommand();
        }

        //增加
        private void AddCommand()
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load("CommandList.xml");
                var root_element = xml.DocumentElement;//取到根结点
                XmlNode node = xml.CreateNode("element", "Command", command);
                node.InnerText = name_textbox.Text;
                //添加为根元素的第一层子结点
                root_element.AppendChild(node);

                //
                if (!IsExist("CommandList.xml", name_textbox.Text))
                {
                    xml.Save("CommandList.xml");
                    MessageBox.Show("添加成功");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
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
                MessageBox.Show("添加时发生未知错误，信息如下\r\n" + exception);
            }
        }

        //重复检测
        public static bool IsExist(string xml_path, string node)
        {
            try
            {
                //注意XML内容区分大小写
                XmlDocument xml = new XmlDocument();
                xml.Load(xml_path);
                //搜索获取子节点
                XmlNodeList nodelist = xml.SelectSingleNode("//CommandList").ChildNodes;
                foreach (XmlElement nodes in nodelist)
                {
                    //遍历字段
                    if (nodes.InnerText == node)
                    {
                        MessageBox.Show("名称已存在");
                        return true;
                    }
                }
                return false;
                //
            }
            catch (Exception exception)
            {
                MessageBox.Show("检测是否存在语句时发生未知错误，信息如下\r\n" + exception);
                return false;
            }
        }

        private void AddForm_Load(object sender, EventArgs e)
        {

        }
    }
}
