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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        public string _userName = "";
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtUsername.Text)|| string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Must input username and password!");
                return;
            }

            client.RegisterAsync(txtUsername.Text, txtPassword.Text);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Must input username and password!");
                return;
            }

            _userName = client.Login(txtUsername.Text, txtPassword.Text);
            if(_userName.StartsWith("Error: "))
            {
                MessageBox.Show(_userName);
                _userName = "";
                return;
            }
            else
            {
                MessageBox.Show("Login success!");
                this.Close();
            }
        }
    }
}
