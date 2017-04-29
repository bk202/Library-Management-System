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

namespace LibraryManagementSystem
{
    public partial class SignupForm : Form
    {
        public Login login_from_previous;
        string userid, userpw, username, usercontact;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            login_from_previous.Show();
        }

        private void SignupForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                MessageBox.Show("Terms and conditions are not checked!", "Terms and conditions");
                return;
            }
            userid = uid.Text;
            userpw = upw.Text;
            username = uname.Text;
            usercontact = ucontact.Text;
            string rootuser = login_from_previous.form1_from_previous.root.GetUID();
            string rootpw = login_from_previous.form1_from_previous.root.GetPW();
            string M_str_sql = "server=localhost;username=" + rootuser + ";password=" + rootpw + ";database=lms";
            MySqlConnection mycon = new MySqlConnection(M_str_sql);
            mycon.Open();
            MySqlCommand mysqlcom;
            M_str_sql = "INSERT INTO lms.account VALUES (" + "'" + userid + "','" + userpw + "','" + username + "','" + usercontact + "');";
            try
            {
                mysqlcom = new MySqlCommand(M_str_sql, mycon);
                mysqlcom.ExecuteNonQuery();
                mysqlcom.Dispose();
            }
            catch
            {
                MessageBox.Show("Invalid information entered, possibly a used username was entered", "Error");
                return;
            }
            MessageBox.Show("Your account has been created", "Registration succeed");
            mycon.Close();
            mycon.Dispose();
            this.Dispose();
            login_from_previous.Show();
        }

        public SignupForm()
        {
            InitializeComponent();
        }
        public void show2(Login login)
        {
            login_from_previous = login;
            login.Hide();
            this.Show();
        }
    }
}
