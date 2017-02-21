using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        private void btnSend_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtMessage.Text))
            {
                t.Stop();
                client.InsertMessageAsync(new ServiceReference1.TextMessage() { Content = txtMessage.Text, Sender = UsrName, SentTime = DateTime.Now });
                txtMessage.Text = "";
                t.Start();
            }
            else
            {
                MessageBox.Show("YOu must input your message before sending!");
                return;
            }
        }

        void LoadData()
        {
            List<ServiceReference1.TextMessage> list = client.GetAfterId(lastId);
            foreach(ServiceReference1.TextMessage m in list)
                txtChat.Text += string.Format("{0}{1}({2}): {3}", Environment.NewLine, m.Sender, m.SentTime, m.Content);
            if(list.Count>0)
                lastId = list.Max(tm => tm.Id);
        }
        string UsrName = "";
        int lastId = 0;
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Hide();
            Login frm = new Login();
            frm.ShowDialog();
            if(string.IsNullOrEmpty(frm._userName))
            {
                Application.Exit();
                return;
            }

            UsrName = frm._userName;
            LoadData();
            
            t.Interval = 3000;
            t.Tick += t_Tick;
            t.Start();
        }
        Timer t = new Timer();
        void t_Tick(object sender, EventArgs e)
        {
            t.Stop();
            LoadData();
            t.Start();
        }
    }
}
