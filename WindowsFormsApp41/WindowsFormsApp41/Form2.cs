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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверка на пустое поле 
            // "Пароль" и "повторить пароль" совпадают
            // Данный логин уже занят
            // Вовод сообщение " пользователь добавлен в базу)
            // Закрывалось окно.
                string connectionString =
                    "Server=localhost;" +
                    "Database=testdb;" +
                    "Uid=root;" +
                    "Pwd=root;" +
                    "Port =3306;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                string query = "INSERT INTO logins (user,pass) VALUES ('" + textBox1.Text
                    + "','" + textBox2.Text + "');";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();

        }
    }
}
