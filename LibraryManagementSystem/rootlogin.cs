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
    public partial class rootlogin : Form
    {
        string rootuid, rootpw;
        public rootlogin()
        {
            InitializeComponent();
        }
        public string GetUID()
        {
            return rootuid;
        }
        public string GetPW()
        {
            return rootpw;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rootuid = uid.Text;
            rootpw = pw.Text;
            string M_str_sql = "server=localhost;user=" + rootuid + ";password=" + rootpw + ";";
            MySqlConnection mycon = new MySqlConnection(M_str_sql);
            try
            {
                mycon.Open();
            }
            catch
            {
                MessageBox.Show("Login failed");
                return;
            }
            MessageBox.Show("Login success!");
            /*
            initiate library management system databse
            */
            MySqlCommand mysqlcom;
            Form1 form1 = new Form1();
            try
            {
                M_str_sql = "CREATE SCHEMA lms";
                mysqlcom = new MySqlCommand(M_str_sql, mycon);
                mysqlcom.ExecuteNonQuery();
            }
            catch
            {
                form1.Show2(this);
                return;
            }
            M_str_sql = "CREATE TABLE lms.Books (BookNo varchar(50), BookType varchar(50), BookName varchar(50), Publisher varchar(50), Year int, Author varchar(50), Price numeric(8,2), Total int, Storage int, UpdateTime datetime, primary key(BookNo));";
            mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            M_str_sql = "CREATE TABLE lms.LibraryCard (CardNo varchar(50), Name varchar(50), Department varchar(50), CardType varchar(50), UpdateTime datetime, primary key (CardNo));";
            mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            M_str_sql = "CREATE TABLE lms.account (uid varchar(50), upw varchar(50), Name varchar(50), Contact varchar(50), primary key(uid));";
            mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            M_str_sql = "CREATE TABLE lms.LibraryRecords (FID int, CardNo varchar(50), BookNo varchar(50), LentDate datetime, ReturnDate datetime, Operator varchar(50), primary key(FID));";
            mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            /*
            initiate library database data
            */
            M_str_sql = "INSERT INTO lms.account VALUES ('" + rootuid + "','" + rootpw + "',null, null);"; //initiate root account
            mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            int bookno = 1;
            M_str_sql = "INSERT INTO lms.Books VALUES ('" + bookno++ + "', '编程语言', 'C语言 从研发到脱发', 'AcFun', 2006, 'Alan Turing', 99, 30, 30, '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');";
            mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            M_str_sql = "INSERT INTO lms.Books VALUES ('" + bookno++ + "', '编程语言', 'Android 从入行到改行', 'AcFun', 2011, 'John Liu', 159.99, 50, 48, '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');";
            mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            M_str_sql = "insert into lms.Books VALUES ('" + bookno++ + "', '死灵书', 'Linux导论 从装机宕机', 'SFU', 2015, 'John Liu', 201.53, 99, 33, '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');";
            mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            M_str_sql = "insert into lms.Books VALUES ('" + bookno++ + "', '励志', 'UI设计 从第一稿到最后一稿', '浙江大学', 2016, 'David Na', 22.99, 5, 5, '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');";
            mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            M_str_sql = "INSERT INTO lms.Books VALUES ('" + bookno++ + "', '编程语言', 'C++ 从入门到放弃', '三墩职业技术学校', 1999, '陈建宇', 99.99, 20, 20, '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');";
            mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            M_str_sql = "insert into lms.Books VALUES ('" + bookno++ + "', '爱情', '计算机组成 从组装到女装', '老和山职业技术学院', 2015, '那宗伟', 19.99, 20, 19, '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');";
            mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            M_str_sql = "INSERT INTO lms.Books VALUES ('" + bookno++ + "', '灵异', '程序猿的爱情', '本拿比职业技工学院', 1991, 'Jerry Chen', 13.50, 15, 15, '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');";
            mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            int i = 1;
            M_str_sql = "INSERT INTO lms.librarycard VALUES ('" + i++ + "','陈建宇', '西区工地', '工头', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');";
            mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            M_str_sql = "INSERT INTO lms.librarycard VALUES ('" + i++ + "', '那宗伟', '校医院', '保安', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');";
            mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            M_str_sql = "INSERT INTO lms.librarycard VALUES ('" + i++ + "', '刘曦', '计算机学院', '教授', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');";
            mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            M_str_sql = "INSERT INTO lms.librarycard VALUES ('" + i++ + "', '叶陈韬', '搬砖系', '学生', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');";
            mysqlcom = new MySqlCommand(M_str_sql, mycon);
            mysqlcom.ExecuteNonQuery();
            M_str_sql = "INSERT INTO lms.libraryrecord VALUES (0, null, null, null, null, null)";
            mysqlcom.Dispose();
            mycon.Close();
            mycon.Dispose();
            form1.Show2(this);
            return;
        }
    }
}
