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
    public partial class ChangeReader : Form
    {
        SqlConnection connection;
        string idReader;
        public ChangeReader(string id)
        {
            InitializeComponent();
            string connectionString = @"Data Source=DESKTOP-INCU1KM\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            idReader = id;
            string str = "SELECT * FROM [Reader] WHERE Reader_form_ID = ";
            str += "'" + id + "'";
            DataTable table = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(str, connection);
            DA.Fill(table);
            this.textBox1.Text = Convert.ToString(table.Rows[0][1]);
            this.textBox2.Text = Convert.ToString(table.Rows[0][2]);
            this.textBox3.Text = Convert.ToString(table.Rows[0][3]);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                string str = "UPDATE [Reader]";
                str += "SET Reader_name = " + "'" + textBox1.Text + "' ";
                str += ", Reader_passport = " + "'" + textBox2.Text + "' ";
                str += ", Reader_phone_num = " + "'" + textBox3.Text + "' ";
                str += "WHERE Reader_form_ID = " + "'" + idReader + "'";
                DataSet dataSet = new DataSet();
                SqlDataAdapter DA = new SqlDataAdapter(str, connection);
                DA.Fill(dataSet, "Reader");
                this.Close();
            }
            else
                label5.Visible = true;

        }
    }
}
