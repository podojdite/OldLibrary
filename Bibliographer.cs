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
    public partial class Bibliographer : Form
    {
        SqlConnection connection;
        public Bibliographer()
        {
            InitializeComponent();
            string connectionString = @"Data Source=DESKTOP-INCU1KM\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        private void Add_BookExmpl_Click(object sender, EventArgs e)
        {
            NewBookExmpl bookExmpl = new NewBookExmpl();
            bookExmpl.Show();
        }

        private void Add_edition_Click(object sender, EventArgs e)
        {
            NewBookEdition bookType = new NewBookEdition();
            bookType.Show();
        }

        private void output_AllEdition_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter("SELECT * FROM Editions", connection);
            DA.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void Delete_edition_Click(object sender, EventArgs e)
        {
            bool flag = false;
            SqlCommand comm = new SqlCommand("SELECT BookType_ID,BookExmpl_free from BookExmpl", connection);
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
                if (textBox1.Text == reader[0].ToString() && reader[1].ToString() == "-")
                    flag = true;
            reader.Close();
            if (flag == true)
                MessageBox.Show("Невозможно удалить!\nНекоторые читатели еще не вернули книги этого издания.");
            else
            {
                string str = "DELETE from BookType WHERE BookType_ID = '" + textBox1.Text + "'";
                SqlCommand command = new SqlCommand(str, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Вы удалили издание номер: " + textBox1.Text);
            }
        }

        private void Books_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter("EXEC Out_Books", connection);
            DA.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void View1_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter("SELECT * from CountOfBookExmplByEdition", connection);
            DA.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void Update_edition_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string BookType_ID;
            SqlCommand command = new SqlCommand("SELECT BookType_ID from [BookType]", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader[0].ToString() == textBox1.Text)
                {
                    BookType_ID = reader[0].ToString();
                    ChangeBookEdition f2 = new ChangeBookEdition(BookType_ID);
                    f2.Show();
                    flag = true;
                }
            }
            if (flag == false)
                MessageBox.Show("Издания с таким ID не существует!");
            reader.Close();
        }
    }
}
