using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
//MessageBox.Show("Jerry is a faggot");

namespace LibraryManagementSystem
{
    public partial class Login : Form
    {
        public Form1 form1_from_previous;
        public string uid, pw;
        public string loginid, loginpw;
        public Login()
        {
            InitializeComponent();
        }

        public void Jump_to_login_page(Form1 form1)
        {
            this.Show();
            form1_from_previous = form1;
            form1_from_previous.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            form1_from_previous.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uid = this.textBox1.Text;
            pw = this.textBox2.Text;
            string rootuid = form1_from_previous.root.GetUID();
            string rootpw = form1_from_previous.root.GetPW();
            string M_str_sql = "server=localhost;username=" + rootuid + ";password=" + rootpw + ";database=lms;";
            MySqlConnection myCon = new MySqlConnection(M_str_sql);
            myCon.Open();
            M_str_sql = "SELECT * FROM lms.account WHERE uid=" + "'" + uid + "'" + " and upw=" + "'" + pw + "'";
            MySqlCommand mysqlcom = new MySqlCommand(M_str_sql, myCon);
            mysqlcom.ExecuteNonQuery();
            MySqlDataReader mysqlread = mysqlcom.ExecuteReader(CommandBehavior.CloseConnection);
            if (mysqlread.HasRows)
            {
                MessageBox.Show("login success!");
                maingui main = new maingui();
                main.Show2(this);
                this.Hide();
            }
            else MessageBox.Show("Login failure, Please double check your account or password", "Error");
            mysqlcom.Dispose();
            myCon.Close();
            myCon.Dispose();
        }

        public string getUID()
        {
            return this.uid;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            SignupForm suf = new SignupForm();
            suf.show2(this);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            passwordRetrieve pwretrieve = new passwordRetrieve();
            pwretrieve.Show2(this);
        }
    }
}
