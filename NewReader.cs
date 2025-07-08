using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Library
{
    public partial class NewReader : Form
    {
        SqlConnection connection;
        public NewReader()
        {
            InitializeComponent();
            string connectionString = @"Data Source=DESKTOP-INCU1KM\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            label5.Visible = false;
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text))
            {
                //проверка на существования такого логина
                string str = "SELECT * from [UserData]";
                bool flag = false;
                SqlCommand command = new SqlCommand(str, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (textBox4.Text == reader[1].ToString())
                        flag = true;
                }
                reader.Close();
                if (flag == false)
                {
                    using (SHA256 sHA256Hash = SHA256.Create())
                    {
                        string pass = GetHash(sHA256Hash, textBox4.Text);

                        //запись нового пользователя
                        string str1 = "INSERT INTO [UserDATA] ([Login],[Password])VALUES('"
                            + textBox4.Text + "','" + pass + "')";
                        SqlCommand commandAdd = new SqlCommand(str1, connection);
                        commandAdd.ExecuteNonQuery();

                        //запись нового читателя
                        string login = "SELECT MAX(User_ID) from [UserDATA]";
                        SqlCommand command1 = new SqlCommand(login, connection);
                        SqlDataReader reader1 = command1.ExecuteReader();
                        reader1.Read();
                        string str2 = "INSERT INTO [Reader] ([Reader_name],[Reader_passport],[Reader_phone_num],[UserID])VALUES('"
                            + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + reader1[0].ToString() + "')";
                        reader1.Close();
                        SqlCommand commandAdd1 = new SqlCommand(str2, connection);
                        commandAdd1.ExecuteNonQuery();
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("Логин занят");
            }
            else
                label5.Visible = true;
            connection.Close();
            
        }

        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
