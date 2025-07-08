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
    public partial class ChangeBookEdition : Form
    {
        SqlConnection connection;
        string idBookType;
        public ChangeBookEdition(string BookType_id)
        {
            InitializeComponent();
            string substr;
            string connectionString = @"Data Source=DESKTOP-INCU1KM\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            idBookType = BookType_id;
            string str = "SELECT * FROM [BookType] WHERE BookType_ID = ";
            str += "'" + BookType_id + "'";
            DataTable table = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(str, connection);
            DA.Fill(table);
            substr = Convert.ToString(table.Rows[0][2]);
            this.textBox1.Text = Convert.ToString(table.Rows[0][3]);
            this.textBox2.Text = substr.Substring(0, 10);
            this.textBox3.Text = Convert.ToString(table.Rows[0][4]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                string str = "UPDATE [BookType]";
                str += "SET BookType_publishing = " + "'" + textBox1.Text + "' ";
                str += ", BookType_edition_year = " + "'" + textBox2.Text + "' ";
                str += ", BookType_pgs_num = " + "'" + textBox3.Text + "' ";
                str += "WHERE BookType_ID = " + "'" + idBookType + "'";
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
