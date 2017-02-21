using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleChatWCF
{
    public partial class Chat : Form
    {
        public Chat()
        {
            InitializeComponent();
        }
        public int UserId =1;
        ServiceReference1.SimpleChatServiceClient client = new ServiceReference1.SimpleChatServiceClient();
        int lastId = 0;
        private void btnSend_Click(object sender, EventArgs e)
        {
            client.SendMessage(new ServiceReference1.Message() { Content = txtMessage.Text, SendTime = DateTime.Now, SenderId = UserId });
            txtMessage.Text = "";
        }
        Timer t = new Timer();
        private void Chat_Load(object sender, EventArgs e)
        {
            t.Interval = 1000; //new TimeSpan(0, 0, 1);
            t.Tick += t_Tick;
            t.Start();
        }

        void t_Tick(object sender, EventArgs e)
        {
            List<ServiceReference1.Message> list = client.GetAllMessagesAfterId(lastId);
            if (list == null || list.Count <= 0)
                return;

            lastId = list.Max(l => l.Id);
            foreach (ServiceReference1.Message m in list)
                txtChat.Text += string.Format("{0}{1} ({2}): {3}", Environment.NewLine, m.SenderId, m.SendTime.ToString("dd/MM/yyyy hh:mm:ss"), m.Content);
        }
    }
}
