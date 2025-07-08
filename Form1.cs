using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Library
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        public Form1()
        {
            InitializeComponent();
            string connectionString = @"Data Source=DESKTOP-INCU1KM\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            connection.Open();
            //начисление штрафов
            SqlCommand command = new SqlCommand("SELECT * from Form", connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string[] str = new string[Convert.ToInt32(reader[0].ToString())];
            DateTime thisDay = DateTime.Today;
            DateTime date;
            int d, m, y;
            int i = 0;
            string mulct;
            reader.Close();
            //do
            //{
            //    d = ToDay(reader[3].ToString());
            //    m = ToMonth(reader[3].ToString());
            //    y = ToYear(reader[3].ToString());
            //    date = new DateTime(y, m, d);

            //    if (date == thisDay.AddDays(1))
            //    {
            //        str[i] = "INSERT INTO Mulct (Form_ID,Mulct_sum)VALUES('" + reader[0].ToString() + "','10')";
            //        i++;
            //    }
            //    if (date < thisDay)
            //    {
            //        mulct = StringToMulct(thisDay.Subtract(date).ToString()) + "0";
            //        str[i] = "UPDATE Mulct SET Mulct_sum = '" + mulct + "' WHERE Form_ID = '" + reader[0].ToString() + "'";
            //        i++;
            //    }
            //} while (reader.Read());
            //reader.Close();
            //for (int ik = 0; ik < i; ik++) {
            //    command = new SqlCommand(str[ik], connection);
            //    command.ExecuteNonQuery();
            //}
        }

        private string StringToMulct(string str)
        {
            string str1 ="";
            int n = str.IndexOf('.');
            for (int i = 0; i < n; i++)
                str1+= "" + str[i];
            return str1;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str="SELECT * from [UserData]";
            bool flag = false;
                SqlCommand command = new SqlCommand(str, connection);
                SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                using (SHA256 sHA256Hash = SHA256.Create())
                {
                    if (textBox1.Text == reader[1].ToString() && VerifyHash(sHA256Hash, textBox2.Text, reader[2].ToString()))
                    {
                        flag = true;
                        switch (reader[0].ToString())
                        {
                            case "1":
                                Librarian l = new Librarian();
                                this.Hide();
                                l.ShowDialog();
                                this.Show();
                                break;
                            case "2":
                                Librarian l1 = new Librarian();
                                this.Hide();
                                l1.ShowDialog();
                                this.Show();
                                break;
                            case "3":
                                Bibliographer b = new Bibliographer();
                                this.Hide();
                                b.ShowDialog();
                                this.Show();
                                break;
                            default:
                                Reader r = new Reader(reader[1].ToString());
                                this.Hide();
                                r.ShowDialog();
                                this.Show();
                                break;

                        }
                    }
                }
            }
            if (flag == false)
                MessageBox.Show("Неверный пароль");
            reader.Close();
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

        private static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
        {
            var hashOfInput = GetHash(hashAlgorithm, input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0;
        }

        //Show/Hide
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Show")
            {
                textBox2.PasswordChar = '\0';
                button2.Text = "Hide";
            }
            else
            {
                textBox2.PasswordChar = '*';
                button2.Text = "Show";
            }
        }
    }
}
