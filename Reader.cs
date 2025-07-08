using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library
{
    public partial class Reader : Form
    {
        SqlConnection connection;
        string reader;
        public Reader(string reader_user)
        {
            InitializeComponent();
            string connectionString = @"Data Source=DESKTOP-INCU1KM\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            connection.Open();
            reader = reader_user;
        }

        private void Out_AllBookExmpl_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter("SELECT Book_name AS Имя_книги, Book_author as Автор, Book_theme as Жанр from Book", connection);
            DA.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void NewBooks_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter("EXEC YourBooks '" + reader + "'", connection);
            DA.Fill(table);
            dataGridView1.DataSource = table;

            int day, month, year, n = dataGridView1.RowCount;
            string str_date;
            DateTime date;
            DateTime today = DateTime.Today;
            for (int i = 0; i < n-1; i++) {
                str_date = dataGridView1.Rows[i].Cells[4].Value.ToString();
                day = ToDay(str_date);
                month = ToMonth(str_date);
                year = ToYear(str_date);
                date = new DateTime(year, month, day);
                if (date < today)
                {
                    dataGridView1["Date_Refund",i].Style.BackColor = Color.Red;
                    dataGridView1["Date_Refund",i].Style.ForeColor = Color.White;
                }
            }
        }


        private int ToDay(string str)
        {
            int day;
            str = "" + str[0] + str[1];
            day = Convert.ToInt32(str);
            return day;
        }

        private int ToMonth(string str)
        {
            int month;
            str = "" + str[3] + str[4];
            month = Convert.ToInt32(str);
            return month;
        }

        private int ToYear(string str)
        {
            int year;
            str = "" + str[6] + str[7] + str[8] + str[9];
            year = Convert.ToInt32(str);
            return year;
        }


        private void SearchBook1_Click(object sender, EventArgs e)
        {
            string str = "SELECT Book_name,Book_author,Book_theme from Book";
            switch(comboBox1.Text)
            {
                case "Название":
                    str += " WHERE Book_name LIKE '" + textBox1.Text + "'";
                    break;
                case "Автор":
                    str += " WHERE Book_author LIKE '" + textBox1.Text + "'";
                    break;
                case "Жанр":
                    str += " WHERE Book_theme LIKE '" + textBox1.Text + "'";
                    break;
                default:
                    break;
            }
            DataTable table = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(str, connection);
            DA.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void SearchBook2_Click(object sender, EventArgs e)
        {
            string str = "";
            if(comboBox2.Text == "Экземпляры")
                str = "SELECT * from AllBookExmpl WHERE Name_of_book LIKE '" + textBox2.Text + "'";
            if(comboBox2.Text == "Издания")
                str = "SELECT * from EditionsforReaders WHERE Book_name LIKE '" + textBox2.Text + "'";
            DataTable table = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(str, connection);
            DA.Fill(table);
            dataGridView1.DataSource = table;
        }

        //просмотр списка своих штрафов
        private void Popular_Click(object sender, EventArgs e)
        {
            string str = "EXEC ShowMulct '" + reader + "'";
            DataTable table = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(str, connection);
            DA.Fill(table);
            dataGridView1.DataSource = table;
        }

        //оплата штрафа
        private void NotPopular_Click(object sender, EventArgs e)
        {
            string str = "EXEC ExistsMulct '" + reader + "'";
            SqlCommand command = new SqlCommand(str, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            dataReader.Read();
            if (dataReader[0].ToString() == "0")
                MessageBox.Show("Поздравляем! У вас нет штрафов!");
            else
            {
                PayMulct f2 = new PayMulct();
                f2.Show();
            }
            dataReader.Close();
        }
    }
}
