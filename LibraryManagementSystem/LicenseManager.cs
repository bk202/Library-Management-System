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
    public partial class LicenseManager : Form
    {
        public maingui main_from_previous;
        static string uid, upw;
        bool isHead = true;
        public void Show2(maingui main)
        {
            main_from_previous = main;
            this.Show();
            main.Hide();
            uid = main.login.form1_from_previous.root.GetUID();
            upw = main.login.form1_from_previous.root.GetPW();
            init();
        }
        public LicenseManager()
        {
            InitializeComponent();
        }

        private void init()
        {
            string M_str_sql = "server=localhost; user=" + uid + ";password=" + upw + ";database=lms;";
            MySqlConnection mycon = new MySqlConnection(M_str_sql);
            mycon.Open();
            M_str_sql = "SELECT Department FROM lms.librarycard GROUP BY Department";
            MySqlCommand mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            MySqlDataReader mysqlreader = mysqlcom.ExecuteReader(CommandBehavior.CloseConnection);
            while (mysqlreader.Read())
            {
                department0.Items.Add(mysqlreader.GetString(0));
            }
            mysqlreader.Close();
            mycon.Open();
            M_str_sql = "SELECT CardType FROM lms.librarycard GROUP BY CardType";
            mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            mysqlreader = mysqlcom.ExecuteReader(CommandBehavior.CloseConnection);
            while (mysqlreader.Read())
            {
                cardtype0.Items.Add(mysqlreader.GetString(0));
            }
            mysqlcom.Dispose();
            mycon.Close();
            mycon.Dispose();
        }

        private void display()
        {
            dataGridView1.Rows.Clear();
            string cardno = cardno0.Text;
            string cardname = cardname0.Text;
            string department = department0.Text;
            string cardtype = cardtype0.Text;
            string M_str_sql = "server=localhost;user=" + uid + ";password=" + upw + ";database=lms;";
            MySqlConnection mycon = new MySqlConnection(M_str_sql);
            mycon.Open();
            M_str_sql = "SELECT * FROM lms.librarycard";
            string where = "";
            if(cardno != "")
            {
                where += (" CardNo = '" + cardno + "'");
                isHead = false;
            }
            if(cardname != "")
            {
                if (!isHead) where += " and";
                where += (" Name = '" + cardname + "'");
                isHead = false;
            }
            if(department != "")
            {
                if (!isHead) where += " and";
                where += (" Department = '" + department + "'");
                isHead = false;
            }
            if(cardtype != "")
            {
                if (!isHead) where += " and";
                where += (" CardType = '" + cardtype + "'");
                isHead = false;
            }
            if(where != "")
            {
                M_str_sql += (" WHERE" + where + ";");
            }
            isHead = true;
            MySqlCommand mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            MySqlDataReader mysqlreader = mysqlcom.ExecuteReader(CommandBehavior.CloseConnection);
            DataGridViewRow row;
            int i = 0;
            while (mysqlreader.Read())
            {
                row = (DataGridViewRow)dataGridView1.Rows[i++].Clone();
                for(int j=0; j<5; j++)
                {
                    row.Cells[j].Value = mysqlreader.GetString(j);
                }
                dataGridView1.Rows.Add(row);
            }
            mysqlcom.Dispose();
            mycon.Close();
            mycon.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string cardno = cardno0.Text;
            string cardname = cardname0.Text;
            string department = department0.Text;
            string cardtype = cardtype0.Text;
            if(cardno == "" || cardname == "" || department == "" || cardtype == "")
            {
                MessageBox.Show("Please make sure no information is left blank!", "Error");
                return;
            }
            string M_str_sql = "server=localhost;username=" + uid + ";password=" + upw + ";database=lms;";
            MySqlConnection mycon = new MySqlConnection(M_str_sql);
            mycon.Open();
            MySqlCommand mysqlcom;
            M_str_sql = "INSERT INTO lms.librarycard VALUES ('" + cardno + "','" + cardname + "','" + department + "','" + cardtype + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');";
            try
            {
                mysqlcom = new MySqlCommand(M_str_sql, mycon);
                mysqlcom.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Update failed, please make sure card no. is not duplicated", "Error");
                return;
            }
            MessageBox.Show("Insertion succeeded!");
            cardno0.Text = cardname0.Text = department0.Text = cardtype0.Text = "";
            mysqlcom.Dispose();
            mycon.Close();
            mycon.Dispose();
            display();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("请从下列表中选择要删除的图书证");
                return;
            }
            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected license?", "Caution", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;
            string cardno = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string M_str_sql = "server=localhost;username=" + uid + ";password=" + upw + ";database=lms;";
            MySqlConnection mycon = new MySqlConnection(M_str_sql);
            mycon.Open();
            M_str_sql = "DELETE FROM lms.librarycard WHERE CardNo = '" + cardno + "';";
            MySqlCommand mysqlcom;
            try
            {
                mysqlcom = new MySqlCommand(M_str_sql, mycon);
                mysqlcom.ExecuteNonQuery();
                mysqlcom.Dispose();
            }
            catch
            {
                MessageBox.Show("Deletion failed, please double check your information entered", "Error");
                mycon.Close();
                mycon.Dispose();
                return;
            }
            MessageBox.Show("Deletion successful");
            cardno0.Text = cardname0.Text = department0.Text = cardtype0.Text = "";
            display();
            mysqlcom.Dispose();
            mycon.Close();
            mycon.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            main_from_previous.Show();
        }
    }
}
