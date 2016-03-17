using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using System.Timers;

namespace Excel2Mysql
{
    public partial class Main : Form
    {
        private entity.ServerConfig[] _configs;
        private Dictionary<string, string> _files = new Dictionary<string, string>();

        public Main()
        {
            InitializeComponent();
        }

        private void ExeclDragDrop(object sender, DragEventArgs e)
        {
            string[] filePath = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in filePath)
            {
                this.addExeclFile(file);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Text = System.IO.Path.GetFileNameWithoutExtension(Application.ExecutablePath);

            try
            {
                this.loadConfig();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "配置文件不存在！");
            }
        }

        private void loadConfig()
        {
            if (System.IO.File.Exists(this.Text + ".json"))
            {
                this._configs = util.Json.parse<entity.ServerConfig[]>(System.IO.File.ReadAllText(this.Text + ".json"));
            }
            else
            {
                this._configs = util.Json.parse<entity.ServerConfig[]>(System.IO.File.ReadAllText("config.json"));
            }

            for(int i =0;i<this._configs.Length;i++)
            {
                this.configs.Items.Add(this._configs[i].desc);
            }

            this.configs.SelectedIndex = 0;
        }

        private void addExeclFile(string filePath)
        {
            string name = System.IO.Path.GetFileNameWithoutExtension(filePath);
            string ext = System.IO.Path.GetExtension(filePath).ToLower();

            if (ext != ".xls" && ext != ".xlsx")
            {
                MessageBox.Show("只允许.xls .xlsx文件！", name);
                return;
            }

            if (!this._files.ContainsKey(name))
            {
                this.list.Items.Add(name);
                this.list.SetItemChecked(this.list.Items.Count - 1, true);
                this._files.Add(name, filePath);
            }
        }

        private void showError(int interval, string errMsg, ToolTipIcon tipIcon)
        {
            NotifyIcon notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new System.Drawing.Icon(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("Excel2Mysql.myAppIcon.ico"));
            notifyIcon.Visible = true;

            notifyIcon.ShowBalloonTip(interval, "Message", errMsg, tipIcon);
            Thread.Sleep(interval);

            notifyIcon.Dispose();
        }

        private void btImport_Click(object sender, EventArgs e)
        {
            entity.ServerConfig serverConfig = this._configs[this.configs.SelectedIndex];

            for (int i = 0; i < this.list.Items.Count; i++)
            {
                if (this.list.GetItemChecked(i))
                {
                    string errMsg = "";
                    util.Mysql.Instance.UploadExecl(serverConfig, this._files[this.list.Items[i].ToString()], out errMsg);

                    if (errMsg != "")
                    {
                        this.list.SetItemChecked(i, this.list.GetItemChecked(i) != true);

                        MessageBox.Show(errMsg, this.list.Items[i].ToString());
                    }
                }
            }
            
            if (!string.IsNullOrEmpty(serverConfig.hookUrl))
            {
                try
                {
                    System.Net.HttpWebRequest.Create(serverConfig.hookUrl).GetResponse();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "远程执行钩子错误！");
                }
            }

            MessageBox.Show("导表完成！", "结束！");
        }

        private void btSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0 ; i < this.list.Items.Count; i++)
            {
                this.list.SetItemChecked(i, true);
            }
        }

        private void btInverse_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.list.Items.Count; i++)
            {
                this.list.SetItemChecked(i, this.list.GetItemChecked(i) != true);
            }
        }
    }
}
