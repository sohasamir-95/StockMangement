using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockMangementversion1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (NametextBox1.Text == "")
            {
                MessageBox.Show("Please Enter your Name");
                Login lg = new Login();
                lg.Show();
                Hide();
            }
            else
            {
                Start st = new Start();
                st.Show();
                Hide();
            }

        }
    }
}
