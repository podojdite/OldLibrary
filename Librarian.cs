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
    public partial class Librarian : Form
    {
        SqlConnection connection;
        public Librarian()
        {
            InitializeComponent();
            string connectionString = @"Data Source=DESKTOP-INCU1KM\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }
        //Все читатели библиотеки
        private void button1_Click(object sender, EventArgs e)
        {
            string str = "SELECT * FROM [Reader] ORDER BY Reader_name";
            DataTable table = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(str, connection);
            DA.Fill(table);
            dataGridView1.DataSource = table;
            textBox2.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        //читатели с просрочкой
        private void button6_Click(object sender, EventArgs e)
        {
            string str = "SELECT Reader_name,Reader_passport,Reader_phone_num,Form_date_rfnd,BookExmpl_ID from [Form],[Reader] WHERE Reader_form_ID = Form_Reader_ID AND Form_date_rfnd< '";
            DateTime thisDay = DateTime.Today;
            str += thisDay.ToString("d");
            str += "'";
            DataTable table = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(str, connection);
            DA.Fill(table);
            dataGridView1.DataSource = table;
        }
        //добавить читателя пароль по умолчанию: логин
        private void button4_Click(object sender, EventArgs e)
        {
            NewReader reader = new NewReader();
            reader.Show();
        }

        //взятые книги
        private void button2_Click(object sender, EventArgs e)
        {
            string str = "SELECT Book_name, Book_author, Book_theme,BookType_publishing,BookType_pgs_num,BookType_edition_year, BookExmpl.BookExmpl_ID  from [Book],[BookType],[BookExmpl],[Form]" +
                         " WHERE Book.Book_ID = BookType.Book_ID AND BookType.BookType_ID = BookExmpl.BookType_ID AND Form.BookExmpl_ID = BookExmpl.BookExmpl_ID AND Form_Reader_ID = Reader_form_ID " +
                         "AND Reader_form_ID = ";
            str +="'" + textBox1.Text + "'";
            DataTable table = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(str, connection);
            DA.Fill(table);
            dataGridView1.DataSource = table;
        }
        //изменить читателя
        private void button3_Click(object sender, EventArgs e)
        {
            bool flag = false;
            SqlCommand command = new SqlCommand("SELECT Reader_form_ID from [Reader]", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader[0].ToString() == textBox1.Text)
                {
                    ChangeReader f2 = new ChangeReader(textBox1.Text);
                    f2.Show();
                    flag = true;
                }
            }
            if (flag == false)
                MessageBox.Show("Читателя с таким ID не существует!");
            reader.Close();
        }

        //удаление читателя
        private void button5_Click(object sender, EventArgs e)
        {
            bool flag = false;
            SqlCommand command = new SqlCommand("SELECT DISTINCT Form_Reader_ID from [Form]", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                if (reader[0].ToString() == textBox1.Text) {
                    MessageBox.Show("Нельзя удалить читателя с задолженностями!");
                    flag = true;
                }
            reader.Close();
            if (flag == false) {
                string str = "DELETE from [Reader] WHERE Reader_form_ID =";
                str += "'" + textBox1.Text + "'";
                command = new SqlCommand(str,connection);
                reader = command.ExecuteReader();
                    }
            reader.Close();

        }

        //Выдать книгу
        private void button7_Click(object sender, EventArgs e)
        {
            bool flag = false, flag2 = false;
            if (!(textBox4.TextLength == 10 && textBox4.Text[2] == '/' && textBox4.Text[5] == '/' &&
                textBox6.TextLength == 10 && textBox6.Text[2] == '/' && textBox6.Text[5] == '/')) {
                MessageBox.Show("Дата введена не в формате ДД/ММ/ГГГГ");
                flag2 = true;
            }
            SqlCommand command = new SqlCommand("SELECT BookExmpl_ID, BookExmpl_free from [BookExmpl]", connection);
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
                if (reader[0].ToString() == textBox3.Text && reader[1].ToString() == "+")
                    flag = true;
            reader.Close();
            if (flag == false && flag2 == false)
                MessageBox.Show("Книги нет в нашей библиотеке");
            if (flag == true && flag2 == false)
            {
                string str = "INSERT INTO [Form] (Form_Reader_ID,Form_date_extr,Form_date_rfnd,BookExmpl_ID)VALUES(";
                str += "'" + textBox2.Text + "', ";
                str += "'" + textBox4.Text + "', ";
                str += "'" + textBox6.Text + "', ";
                str += "'" + textBox3.Text + "')";
                command = new SqlCommand(str, connection);
                reader = command.ExecuteReader();
                reader.Close();
                str = "UPDATE BookExmpl SET BookExmpl_free = '-' WHERE BookExmpl_ID = '" + textBox3.Text + "'";
                command = new SqlCommand(str, connection);
                reader = command.ExecuteReader();
                reader.Close();
            }
        }

        //вернуть книгу
        private void button8_Click(object sender, EventArgs e)
        {
            bool flag = false;
            SqlCommand command = new SqlCommand("SELECT * from Form, Mulct WHERE Form.Form_ID=Mulct.Form_ID",connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                if (textBox3.Text == reader[4].ToString())
                    flag = true;
            reader.Close();
            if (flag == false)
            {
                string str = "UPDATE BookExmpl SET BookExmpl_free = '+' WHERE BookExmpl_ID = '" + textBox3.Text + "'";
                command = new SqlCommand(str, connection);
                reader = command.ExecuteReader();
                reader.Close();

                str = "DELETE from [Form] WHERE BookExmpl_ID = '" + textBox3.Text + "'";
                command = new SqlCommand(str, connection);
                reader = command.ExecuteReader();
                reader.Close();
            }
            else
                MessageBox.Show("Читатель не оплатил штраф");
        }

        // читатель данной книги
        private void button9_Click(object sender, EventArgs e)
        {
            string str = "SELECT Reader_name, Reader_passport, Reader_phone_num, Reader_form_ID from [Reader],[Form] WHERE Reader_form_ID = Form_Reader_ID AND BookExmpl_ID = ";
            str += "'" + textBox5.Text + "'";
            DataTable table = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(str, connection);
            DA.Fill(table);
            dataGridView1.DataSource = table;
        }

        //книги не на руках
        private void button11_Click(object sender, EventArgs e)
        {
            string str = "SELECT * from OnHandBooks ";
            DataTable table = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(str, connection);
            DA.Fill(table);
            dataGridView1.DataSource = table;
        }

        //изменить информацию об издании книге
        private void button10_Click(object sender, EventArgs e)
        {
            
        }
    }
}
