using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SqltoExcel
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            InitializeComponent();
        }

        //
        private void ServerForm_Load(object sender, EventArgs e)
        {
            //获取Configuration对象
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //根据Key读取元素的Value
            server_textbox.Text = config.AppSettings.Settings["server"].Value;
            data_name_textbox.Text = config.AppSettings.Settings["data_name"].Value;
            user_id_textbox.Text = config.AppSettings.Settings["user_id"].Value;
            password_textbox.Text = config.AppSettings.Settings["password"].Value;
        }

        //写入
        public void Save()
        {
            try
            {
                //
                if (server_textbox.Text == "")
                {
                    MessageBox.Show("服务器不能为空");
                    return;
                }
                //
                if (data_name_textbox.Text == "")
                {
                    MessageBox.Show("数据库不能为空");
                    return;
                }
                //
                if (user_id_textbox.Text == "")
                {
                    MessageBox.Show("用户不能为空");
                    return;
                }
                //
                if (password_textbox.Text == "")
                {
                    MessageBox.Show("密码不能为空");
                    return;
                }

                //获取Configuration对象
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //写入键值
                config.AppSettings.Settings["server"].Value = server_textbox.Text;
                config.AppSettings.Settings["data_name"].Value = data_name_textbox.Text;
                config.AppSettings.Settings["user_id"].Value = user_id_textbox.Text;
                config.AppSettings.Settings["password"].Value = password_textbox.Text;
                //增加键
                //config.AppSettings.Settings.Add("键名", "键值");
                //删除键
                //config.AppSettings.Settings.Remove("键名");
                //一定要记得保存，写不带参数的config.Save()也可以
                config.Save(ConfigurationSaveMode.Modified);
                //刷新，否则程序读取的还是之前的值（可能已装入内存）
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch
            {
                MessageBox.Show("保存出错，请检查输入内容是否正确");
            }
        }

        //保存按钮
        private void dave_setting_button_Click(object sender, EventArgs e)
        {
            Save();
            Close();
        }

        private void cancel_setting_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        //


    }
}
