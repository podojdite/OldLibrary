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
    public partial class NewBookExmpl : Form
    {
        SqlConnection connection;
        public NewBookExmpl()
        {
            InitializeComponent();
            string connectionString = @"Data Source=DESKTOP-INCU1KM\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                string str1 = "INSERT INTO [Book] ([Book_name],[Book_author],[Book_theme])VALUES('"
                           + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "')";
                SqlCommand commandAdd = new SqlCommand(str1, connection);
                commandAdd.ExecuteNonQuery();
                connection.Close();
                this.Close();
            }
            else
                label5.Visible = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void NewBookExmpl_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
