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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ServiceReference1.SimpleChatServiceClient client = new ServiceReference1.SimpleChatServiceClient();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Nhap Username & Password!");
                return;
            }
            int userID = client.Login(txtUserName.Text, txtPassword.Text);
            if(userID<=0)
            {
                MessageBox.Show("Sai dang nhap!");
                return;
            }
            else
            {
                Chat frm = new Chat();
                frm.UserId = userID;
                frm.ShowDialog();
                Application.Exit();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Nhap Username & Password!");
                return;
            }
            client.Register(new ServiceReference1.User() { UserName = txtUserName.Text, Password = txtPassword.Text });
            MessageBox.Show("Dang ky thanh cong!");
        }
    }
}
