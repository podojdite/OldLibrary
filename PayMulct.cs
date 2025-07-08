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
    public partial class PayMulct : Form
    {
        SqlConnection connection;
        public PayMulct()
        {
            InitializeComponent();
            string connectionString = @"Data Source=DESKTOP-INCU1KM\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            label5.Visible = false;
            if (!string.IsNullOrEmpty(textBox1.Text)) 
            {
                SqlCommand command = new SqlCommand("DELETE from Mulct WHERE Mulct_ID = '" + textBox1.Text + "'", connection);
                command.ExecuteNonQuery();
                this.Close();
            }
            connection.Close();
        }
    }
}
