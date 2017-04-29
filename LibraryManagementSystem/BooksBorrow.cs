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
    public partial class BooksBorrow : Form
    {
        public maingui main_from_previous;
        static string uid, upw;
        public void Show2(maingui main)
        {
            main_from_previous = main;
            main.Hide();
            this.Show();
            uid = main.login.form1_from_previous.root.GetUID();
            upw = main.login.form1_from_previous.root.GetPW();
        }
        public BooksBorrow()
        {
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string bookno = bookno0.Text;
            string cardno = cardno0.Text;
            if(bookno == "" || cardno == "")
            {
                MessageBox.Show("BookNo and CardNo cannot be left blank!", "Error");
                return;
            }
            dataGridView1.Rows.Clear();
            string M_str_sql = "server=localhost;user=" + uid + ";password=" + upw + ";database=lms;";
            MySqlConnection mycon = new MySqlConnection(M_str_sql);
            mycon.Open();
            int amount=0;
            M_str_sql = "SELECT Storage FROM lms.books WHERE BookNo = '" + bookno + "'";
            MySqlCommand mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            MySqlDataReader mysqlreader = mysqlcom.ExecuteReader(CommandBehavior.CloseConnection);
            if (!mysqlreader.HasRows)
            {
                MessageBox.Show("Couldn't find destinated book", "Error");
                mysqlreader.Close();
                mysqlcom.Dispose();
                mycon.Close();
                mycon.Dispose();
                return;
            }
            while (mysqlreader.Read())
            {
                amount = mysqlreader.GetInt32(0);
            }
            if(amount <= 0)
            {
                MessageBox.Show("借书失败，库存量不足！", "Error");
                mysqlreader.Close();
                mysqlcom.Dispose();
                mycon.Close();
                mycon.Dispose();
                return;
            }
            mysqlreader.Close();
            mycon.Open();
            int fid = 0;
            M_str_sql = "SELECT FID from lms.libraryrecords";
            mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            mysqlreader = mysqlcom.ExecuteReader();
            while (mysqlreader.Read())
            {
                fid = mysqlreader.GetInt32(0);
            }
            fid++;
            mysqlreader.Close();
            M_str_sql = "UPDATE lms.books SET Storage = Storage - 1 WHERE BookNo = '" + bookno + "';";
            mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            M_str_sql = "INSERT INTO lms.libraryrecords VALUES (" + fid + ", '" + cardno + "','" + bookno + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', null,'" + main_from_previous.login.uid + "');";
            mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            M_str_sql = "SELECT * FROM lms.libraryrecords WHERE CardNo = '" + cardno + "';";
            mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
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
            MessageBox.Show("借出成功！");
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
