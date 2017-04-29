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
    public partial class BooksReturn : Form
    {
        public maingui main_from_previous;
        static string uid, upw;
        bool isHead = true;
        public void Show2(maingui main)
        {
            main_from_previous = main;
            main.Hide();
            this.Show();
            uid = main.login.form1_from_previous.root.GetUID();
            upw = main.login.form1_from_previous.root.GetPW();
        }
        public BooksReturn()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string cardno = cardno0.Text;
            string bookno = bookno0.Text;
            if(cardno == "" || bookno == "")
            {
                MessageBox.Show("BookNo and CardNo cannot be left blank!", "Error");
                return;
            }
            string M_str_sql = "server=localhost;user=" + uid + ";password=" + upw + ";database=lms;";
            MySqlConnection mycon = new MySqlConnection(M_str_sql);
            mycon.Open();
            M_str_sql = "SELECT FID from lms.libraryrecords WHERE CardNo = '" + cardno + "' and BookNo = '" + bookno + "' and ReturnDate is null;";
            MySqlCommand mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            MySqlDataReader mysqlreader = mysqlcom.ExecuteReader(/*CommandBehavior.CloseConnection*/);
            if (!mysqlreader.HasRows)
            {
                MessageBox.Show("No lending record found, please make sure information is filled correctly", "Error");
                mysqlreader.Close();
                mysqlcom.Dispose();
                mycon.Close();
                mycon.Dispose();
                return;
            }
            string fid = "";
            while (mysqlreader.Read())
            {
                fid = mysqlreader.GetString(0); break;
            }
            mysqlreader.Close();
            //mycon.Open();
            M_str_sql = "UPDATE lms.Books SET Storage = Storage + 1 WHERE BookNo = '" + bookno + "';";
            mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            M_str_sql = "UPDATE lms.libraryrecords SET ReturnDate = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE FID = '" + fid + "';";
            mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            M_str_sql = "SELECT * FROM lms.libraryrecords WHERE CardNo = '" + cardno + "';";
            mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlreader = mysqlcom.ExecuteReader(CommandBehavior.CloseConnection);
            DataGridViewRow row;
            int i = 0;
             while (mysqlreader.Read())
            {
                row = (DataGridViewRow)dataGridView1.Rows[i++].Clone();
                for(int j=0; j<6; j++)
                {
                    if(mysqlreader.IsDBNull(j))
                    {
                        row.Cells[j].Value = "未还书"; continue;
                    }
                    row.Cells[j].Value = mysqlreader.GetString(j);
                }
                dataGridView1.Rows.Add(row);
            }
            MessageBox.Show("还书成功！");
            mysqlreader.Close();
            mysqlcom.Dispose();
            mycon.Close();
            mycon.Dispose();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            main_from_previous.Show();
        }
    }
}
