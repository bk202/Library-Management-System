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
    public partial class passwordRetrieve : Form
    {
        public Login login_from_previous;
        public string uid, upw;
        public passwordRetrieve()
        {
            InitializeComponent();
        }

        public void Show2(Login login)
        {
            login_from_previous = login;
            this.Show();
            login.Hide();
            uid = login.form1_from_previous.root.GetUID();
            upw = login.form1_from_previous.root.GetPW();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            login_from_previous.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(name0.Text == "" || contact0.Text == "")
            {
                MessageBox.Show("Information is missing!", "Error");
                return;
            }
            string name = name0.Text;
            string contact = contact0.Text;
            string M_str_sql = "server=localhost; username=" + uid + ";password=" + upw + ";database=lms";
            MySqlConnection mycon = new MySqlConnection(M_str_sql);
            mycon.Open();
            M_str_sql = "SELECT uid, upw FROM lms.account WHERE Name = '" + name + "' and Contact = '" + contact + "';";
            MySqlCommand mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            MySqlDataReader mysqlreader = mysqlcom.ExecuteReader(CommandBehavior.CloseConnection);
            if (!mysqlreader.HasRows)
            {
                MessageBox.Show("No relevant account found, please ensure information is filled correctly");
                return;
            }
            while (mysqlreader.Read())
            {
                MessageBox.Show("Username:" + mysqlreader.GetString(0) + "\nPassword:" + mysqlreader.GetString(1));
            }
            mysqlcom.Dispose();
            mycon.Close();
            mycon.Dispose();
            this.Dispose();
            login_from_previous.Show();
        }
    }
}
