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
    public partial class BooksQuery : Form
    {
        public Form1 form1_from_previous;
        public maingui main_from_previous;
        bool isLoggedon = false;
        static string uid, upw;
        bool isHead = true;
        public void Show2(Form1 form1)
        {
            form1_from_previous = form1;
            this.Show();
            form1.Hide();
            uid = form1.root.GetUID();
            upw = form1.root.GetPW();
            init();
        }
        public void Show2(maingui main)
        {
            main_from_previous = main;
            main.Hide();
            this.Show();
            isLoggedon = true;
            uid = main.login.form1_from_previous.root.GetUID();
            upw = main.login.form1_from_previous.root.GetPW();
            init();
        }
        public BooksQuery()
        {
            InitializeComponent();
        }

        private void init()
        {
            string M_str_sql = "server=localhost; user=" + uid + ";password=" + upw + ";database=lms;";
            MySqlConnection mycon = new MySqlConnection(M_str_sql);
            mycon.Open();
            M_str_sql = "SELECT BookType FROM lms.Books GROUP BY BookType";
            MySqlCommand mysqlcom = new MySqlCommand(M_str_sql, mycon);
            MySqlDataReader mysqlreader = mysqlcom.ExecuteReader(CommandBehavior.CloseConnection);
            while (mysqlreader.Read())
            {
                booktype0.Items.Add(mysqlreader.GetString(0));
            }
            for(int i=1900; i<2100; i++)
            {
                year0.Items.Add(i);
                year1.Items.Add(i);
            }
            mysqlcom.Dispose();
            mycon.Close();
            mycon.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string M_str_sql = "server=localhost;user=" + uid + ";password=" + upw + ";database=lms;";
            MySqlConnection mycon = new MySqlConnection(M_str_sql);
            mycon.Open();
            string bookname = bookname0.Text;
            string booktype = booktype0.Text;
            string publisher = publisher0.Text;
            string yearinit = year0.Text;
            string yearfinal = year1.Text;
            string author = author0.Text;
            string priceinit = price0.Text;
            string pricefinal = price1.Text;
            string where = "";
            /*
            fetching query
            */
            M_str_sql = "SELECT * FROM lms.books";
            if (bookname != "")
            {
                where += ("BookName LIKE " + "'%" + bookname + "%'");
                isHead = false;
            }
            if(booktype != "")
            {
                if (!isHead) where += " and";
                where += (" BookType = " + "'" + booktype + "'");
                isHead = false;
            }
            if(publisher != "")
            {
                if (!isHead) where += " and";
                where += (" Publisher = " + "'" + publisher + "'");
                isHead = false;
            }
            if(yearinit != "")
            {
                if (!isHead) where += " and";
                where += (" Year >= " + yearinit);
                isHead = false;
            }
            if(yearfinal != "")
            {
                if (!isHead) where += " and";
                where += (" Year <= " + yearfinal);
                isHead = false;
            }
            if(author != "")
            {
                if (!isHead) where += " and";
                where += (" Author LIKE " + "'%" + author + "%'");
                isHead = false;
            }
            if(priceinit != "")
            {
                if (!isHead) where += " and";
                where += (" Price >= " + priceinit);
                isHead = false;
            }
            if(pricefinal != "")
            {
                if (!isHead) where += " and";
                where += (" Price <= " + pricefinal);
                isHead = false;
            }
            if(where != "")
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
                for(int j=0; j<10; j++)
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

        private void button4_Click(object sender, EventArgs e)
        {
            //dataGridView1.Rows.Remove(dataGridView1.Rows[0]);
            dataGridView1.Rows.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            if (isLoggedon) main_from_previous.Show();
            else form1_from_previous.Show();
        }
    }
}
