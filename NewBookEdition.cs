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
    public partial class NewBookEdition : Form
    {
        SqlConnection connection;
        public NewBookEdition()
        {
            InitializeComponent();
            string connectionString = @"Data Source=DESKTOP-INCU1KM\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Visible = false;
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && 
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text))
            {
                bool flag = false;
                string str = "SELECT Book_ID from [Book]";
                SqlCommand command = new SqlCommand(str, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    if (textBox1.Text == reader[0].ToString())
                        flag = true;
                reader.Close();
                if (flag == true)
                {
                    // запись издания
                    string str1 = "INSERT INTO [BookType] ([Book_ID],[BookType_edition_year],[BookType_publishing],[BookType_pgs_num])VALUES('"
                           + textBox1.Text + "','" + textBox3.Text + "','" + textBox2.Text + "','" + textBox4.Text + "')";
                    command = new SqlCommand(str1, connection);
                    command.ExecuteNonQuery();

                    // запись экземпляров
                    command = new SqlCommand("SELECT MAX(BookType_ID) from BookType", connection);
                    reader = command.ExecuteReader();
                    reader.Read();
                    int n = Convert.ToInt32(textBox5.Text);
                    string strComm = "INSERT INTO BookExmpl (BookType_ID,BookExmpl_free,BookExmpl_depriciation)VALUES('" + reader[0].ToString() + "','+','100')";
                    reader.Close();
                    for (int i = 0; i < n; i++) {
                        command = new SqlCommand(strComm, connection);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                    this.Close();
                }
                else
                    MessageBox.Show("Книги с таким ID не существует");
            }
            else
                label6.Visible = true;
        }
    }
}
