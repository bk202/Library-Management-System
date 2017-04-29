using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class Form1 : Form
    {
        public rootlogin root = new rootlogin();
        public Form1()
        {
            InitializeComponent();
        }
        public void Show2(rootlogin rlogin)
        {
            root = rlogin;
            this.Show();
            root.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Jump_to_login_page (this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BooksQuery booksquery = new BooksQuery();
            booksquery.Show2(this);
        }
    }
}
