using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace WindowsFormsApp41
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверить пустые поля
            //  В случае верного ввода логина и пароля открыть форму 3
            string connectionString =
                    "Server=localhost;" +
                    "Database=testdb;" +
                    "Uid=root;" +
                    "Pwd=root;" +
                    "Port =3306;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = "SELECT * FROM logins WHERE user ='" + textBox1.Text
                + "' and pass ='" + textBox2.Text + "';";

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            DataRowCollection row = table.Rows;
            if (row.Count > 0)
            {
                String userID = row[0].ItemArray[0].ToString();
            }
            else
            {
                MessageBox.Show("Не найдено");
            }


            connection.Close();
        }
    }
}
