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
using System.IO;

namespace LibraryManagementSystem
{
    public partial class BooksQueryAdmin : Form
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
        }
        public BooksQueryAdmin()
        {
            InitializeComponent();
        }
        private void display_search_results()
        {
            dataGridView1.Rows.Clear();
            string M_str_sql = "server=localhost;user=" + uid + ";password=" + upw + ";database=lms;";
            MySqlConnection mycon = new MySqlConnection(M_str_sql);
            mycon.Open();
            string bookname = bookname0.Text;
            string booktype = booktype0.Text;
            string publisher = publisher0.Text;
            string yearinit = year0.Text;
            string author = author0.Text;
            string priceinit = price0.Text;
            string bookno = bookno0.Text;
            string amount = amount0.Text;
            string where = "";
            bookname0.Text = booktype0.Text = publisher0.Text = year0.Text = author0.Text = price0.Text = bookno0.Text = amount0.Text = "";
            /*
            fetching query
            */
            M_str_sql = "SELECT * FROM lms.books";
            if (bookname != "")
            {
                where += ("BookName = " + "'" + bookname + "'");
                isHead = false;
            }
            if (booktype != "")
            {
                if (!isHead) where += " and";
                where += (" BookType = " + "'" + booktype + "'");
                isHead = false;
            }
            if (publisher != "")
            {
                if (!isHead) where += " and";
                where += (" Publisher = " + "'" + publisher + "'");
                isHead = false;
            }
            if (yearinit != "")
            {
                if (!isHead) where += " and";
                where += (" Year = " + yearinit);
                isHead = false;
            }
            if (author != "")
            {
                if (!isHead) where += " and";
                where += (" Author = " + "'" + author + "'");
                isHead = false;
            }
            if (priceinit != "")
            {
                if (!isHead) where += " and";
                where += (" Price = " + priceinit);
                isHead = false;
            }
            if(bookno != "")
            {
                if (!isHead) where += " and";
                where += (" BookNo = '" + bookno + "'");
                isHead = false;
            }
            if(amount != ""){
                if (!isHead) where += " and";
                where += (" Total = " + amount);
                isHead = false;
            }
            if (where != "")
            {
                M_str_sql += " WHERE " + where + ";";
            }
            MySqlCommand mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            MySqlDataReader mysqlread = mysqlcom.ExecuteReader(CommandBehavior.CloseConnection);
            int i = 0;
            DataGridViewRow row;
            /*
            project query result to data grid
            */
            while (mysqlread.Read())
            {
                row = (DataGridViewRow)dataGridView1.Rows[i++].Clone();
                for (int j = 0; j < 10; j++)
                {
                    row.Cells[j].Value = mysqlread.GetString(j);
                }
                dataGridView1.Rows.Add(row);
            }
            isHead = true;
            mysqlcom.Dispose();
            mycon.Close();
            mycon.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string bookname = bookname0.Text;
            string booktype = booktype0.Text;
            string publisher = publisher0.Text;
            string yearinit = year0.Text;
            string author = author0.Text;
            string priceinit = price0.Text;
            string bookno = bookno0.Text;
            string amount = amount0.Text;
            if(bookno == "" || booktype == "" || publisher == "" || yearinit == "" || author == "" || priceinit == "" || bookno == "" || amount == "")
            {
                MessageBox.Show("Information is missing!", "Error");
                return;
            }
            string M_str_sql = "server=localhost;user=" + uid + ";password=" + upw + ";database=lms;";
            MySqlConnection mycon = new MySqlConnection(M_str_sql);
            mycon.Open();
            /*
            fetching query
            */
            M_str_sql = "INSERT INTO lms.books VALUES ('" + bookno + "','" + booktype + "','" + bookname + "','" + publisher + "'," + yearinit + ",'" + author + "'," + priceinit + "," + amount + "," + amount + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');";
            MySqlCommand mysqlcom;
            try
            {
                mysqlcom = new MySqlCommand(M_str_sql, mycon);
                mysqlcom.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Invalid information entered, may be caused by duplicated Book number", "Error");
                return;
            }
            MessageBox.Show("添加成功！");
            M_str_sql = "SELECT * FROM lms.books";
            mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            MySqlDataReader mysqlread = mysqlcom.ExecuteReader(CommandBehavior.CloseConnection);
            int i = 0;
            DataGridViewRow row;
            /*
            project query result to data grid
            */
            while (mysqlread.Read())
            {
                row = (DataGridViewRow)dataGridView1.Rows[i++].Clone();
                for(int j=0; j<10; j++)
                {
                    row.Cells[j].Value = mysqlread.GetString(j);
                }
                dataGridView1.Rows.Add(row);
            }
            mysqlcom.Dispose();
            mycon.Close();
            mycon.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //dataGridView1.Rows.Remove(dataGridView1.Rows[0]);
            display_search_results();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("请从下列表中选择要删除的书籍", "Non-selected book");
                display_search_results();
                return;
            }
            string bookno = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected book?","Caution", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;
            string M_str_sql = "server=localhost;user=" + uid + ";password=" + upw + ";database=lms;";
            MySqlConnection mycon = new MySqlConnection(M_str_sql);
            mycon.Open();
            M_str_sql = "DELETE FROM lms.books WHERE BookNo = '" + bookno + "'";
            MySqlCommand mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            bookname0.Text = booktype0.Text = publisher0.Text = year0.Text = author0.Text = price0.Text = bookno0.Text = amount0.Text = "";
            display_search_results();
            mysqlcom.Dispose();
            mycon.Close();
            mycon.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string filepath = "";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filepath = openFileDialog1.FileName;
            }
            else if(openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string lines = File.ReadAllText(filepath);
            DialogResult result = MessageBox.Show("Are you sure you want to insert the books from the selected text file?", "Caution", MessageBoxButtons.YesNo);
            if(result == DialogResult.No) return;
            string M_str_sql = "server=localhost; username=" + uid + ";password=" + upw + ";database=lms;";
            MySqlConnection mycon = new MySqlConnection(M_str_sql);
            mycon.Open();
            MySqlCommand mysqlcom;
            string[] data = new string[9];
            for (int i = 0; i < 9; i++) data[i] = "";
            int current = 0;
            for(int i=0; i<lines.Length; i++)
            {
                if(lines[i] == ',')
                {
                    current++; continue;
                }
                if (data[current] == "" && lines[i] == ' ') continue;
                if (lines[i] == '\n')
                {
                    M_str_sql = "INSERT INTO lms.books VALUES ('" + data[0] + "', '" + data[1] + "','" + data[2] + "','" + data[3] + "'," + data[4] + ",'" + data[5] + "'," + data[6] + "," + data[7] + "," + data[8] + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');";
                    mysqlcom = new MySqlCommand(M_str_sql, mycon);
                    try
                    {
                        mysqlcom.ExecuteNonQuery();
                    }
                    catch
                    {
                        mysqlcom.Dispose();
                    }
                    mysqlcom.Dispose();
                    for (int j = 0; j < 9; j++) data[j] = "";
                    current = 0;
                    continue;
                }
                data[current] += lines[i];
            }
            M_str_sql = "INSERT INTO lms.books VALUES ('" + data[0] + "', '" + data[1] + "','" + data[2] + "','" + data[3] + "'," + data[4] + ",'" + data[5] + "'," + data[6] + "," + data[7] + "," + data[8] + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');";
            mysqlcom = new MySqlCommand(M_str_sql, mycon);
            try
            {
                mysqlcom.ExecuteNonQuery();
            }
            catch
            {
                mysqlcom.Dispose();
            }
            MessageBox.Show("添加成功！");
            display_search_results();
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
