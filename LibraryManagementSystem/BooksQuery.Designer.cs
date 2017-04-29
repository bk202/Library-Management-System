namespace LibraryManagementSystem
{
    partial class BooksQuery
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BookNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Publisher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PublishedYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stocks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.booktype0 = new System.Windows.Forms.ComboBox();
            this.bookname0 = new System.Windows.Forms.TextBox();
            this.publisher0 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.year1 = new System.Windows.Forms.ComboBox();
            this.year0 = new System.Windows.Forms.ComboBox();
            this.author0 = new System.Windows.Forms.TextBox();
            this.price0 = new System.Windows.Forms.TextBox();
            this.price1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "书名:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "出版社：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "类别：";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(5, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 43);
            this.button1.TabIndex = 1;
            this.button1.TabStop = false;
            this.button1.Text = "返回";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(0, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(100, 413);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(487, 402);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(113, 20);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker2.Location = new System.Drawing.Point(580, 402);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(76, 20);
            this.dateTimePicker2.TabIndex = 11;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BookNo,
            this.BookType,
            this.BookName,
            this.Publisher,
            this.PublishedYear,
            this.Author,
            this.Price,
            this.Total,
            this.Stocks,
            this.UpdateTime});
            this.dataGridView1.Location = new System.Drawing.Point(101, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(592, 320);
            this.dataGridView1.TabIndex = 13;
            // 
            // BookNo
            // 
            this.BookNo.HeaderText = "书号";
            this.BookNo.Name = "BookNo";
            // 
            // BookType
            // 
            this.BookType.HeaderText = "类型";
            this.BookType.Name = "BookType";
            // 
            // BookName
            // 
            this.BookName.HeaderText = "书名";
            this.BookName.Name = "BookName";
            // 
            // Publisher
            // 
            this.Publisher.HeaderText = "出版社";
            this.Publisher.Name = "Publisher";
            // 
            // PublishedYear
            // 
            this.PublishedYear.HeaderText = "出版年份";
            this.PublishedYear.Name = "PublishedYear";
            // 
            // Author
            // 
            this.Author.HeaderText = "作者";
            this.Author.Name = "Author";
            // 
            // Price
            // 
            this.Price.HeaderText = "价钱";
            this.Price.Name = "Price";
            // 
            // Total
            // 
            this.Total.HeaderText = "总藏书量";
            this.Total.Name = "Total";
            // 
            // Stocks
            // 
            this.Stocks.HeaderText = "库存量";
            this.Stocks.Name = "Stocks";
            // 
            // UpdateTime
            // 
            this.UpdateTime.HeaderText = "添加时间";
            this.UpdateTime.Name = "UpdateTime";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(618, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 14;
            this.button3.TabStop = false;
            this.button3.Text = "Search";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(618, 46);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // booktype0
            // 
            this.booktype0.FormattingEnabled = true;
            this.booktype0.Location = new System.Drawing.Point(321, 6);
            this.booktype0.Name = "booktype0";
            this.booktype0.Size = new System.Drawing.Size(117, 21);
            this.booktype0.TabIndex = 2;
            // 
            // bookname0
            // 
            this.bookname0.Location = new System.Drawing.Point(158, 7);
            this.bookname0.Name = "bookname0";
            this.bookname0.Size = new System.Drawing.Size(100, 20);
            this.bookname0.TabIndex = 1;
            // 
            // publisher0
            // 
            this.publisher0.Location = new System.Drawing.Point(158, 48);
            this.publisher0.Name = "publisher0";
            this.publisher0.Size = new System.Drawing.Size(100, 20);
            this.publisher0.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "年份：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(375, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(444, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "作者：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(444, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "价格范围：";
            // 
            // year1
            // 
            this.year1.FormattingEnabled = true;
            this.year1.Location = new System.Drawing.Point(386, 47);
            this.year1.Name = "year1";
            this.year1.Size = new System.Drawing.Size(52, 21);
            this.year1.TabIndex = 6;
            // 
            // year0
            // 
            this.year0.FormattingEnabled = true;
            this.year0.Location = new System.Drawing.Point(321, 46);
            this.year0.Name = "year0";
            this.year0.Size = new System.Drawing.Size(52, 21);
            this.year0.TabIndex = 5;
            // 
            // author0
            // 
            this.author0.Location = new System.Drawing.Point(502, 7);
            this.author0.Name = "author0";
            this.author0.Size = new System.Drawing.Size(98, 20);
            this.author0.TabIndex = 3;
            // 
            // price0
            // 
            this.price0.Location = new System.Drawing.Point(502, 48);
            this.price0.Name = "price0";
            this.price0.Size = new System.Drawing.Size(38, 20);
            this.price0.TabIndex = 7;
            // 
            // price1
            // 
            this.price1.Location = new System.Drawing.Point(562, 48);
            this.price1.Name = "price1";
            this.price1.Size = new System.Drawing.Size(38, 20);
            this.price1.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(546, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "-";
            // 
            // BooksQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(699, 424);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.price1);
            this.Controls.Add(this.price0);
            this.Controls.Add(this.author0);
            this.Controls.Add(this.year0);
            this.Controls.Add(this.year1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.publisher0);
            this.Controls.Add(this.bookname0);
            this.Controls.Add(this.booktype0);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BooksQuery";
            this.Text = "图书查询";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookType;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Publisher;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublishedYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stocks;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateTime;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox booktype0;
        private System.Windows.Forms.TextBox bookname0;
        private System.Windows.Forms.TextBox publisher0;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox year1;
        private System.Windows.Forms.ComboBox year0;
        private System.Windows.Forms.TextBox price1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox price0;
        private System.Windows.Forms.TextBox author0;
    }
}