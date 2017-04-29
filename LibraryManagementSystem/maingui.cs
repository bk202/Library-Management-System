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
    public partial class maingui : Form
    {
        public Login login;
        string uid;
        public maingui()
        {
            InitializeComponent();
        }

        public void Show2(Login login0)
        {
            login = login0;
            uid = login.getUID();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BooksBorrow booksborrow = new BooksBorrow();
            booksborrow.Show2(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BooksQuery bookquery = new BooksQuery();
            bookquery.Show2(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BooksQueryAdmin bookquery = new BooksQueryAdmin();
            bookquery.Show2(this);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LicenseManager licensemanager = new LicenseManager();
            licensemanager.Show2(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BooksReturn booksreturn = new BooksReturn();
            booksreturn.Show2(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
            login.Show();
        }
    }
}
