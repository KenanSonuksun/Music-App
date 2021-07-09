using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje3
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlDataReader dataReader;
        SqlCommand command;
        int userId;
        bool checkMoney = true; 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            new adminPage().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = TextUserName.Text;
                string userPassword = TextPassword.Text;
                connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                command = new SqlCommand();
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from users where userName = '" + userName + "' and userPassword = '" + userPassword + "'";
                userId = (int)command.ExecuteScalar();
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    MessageBox.Show("Signing in is successed");
                    new MainScreen(userId).Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Signing in is failed");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("System Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new registerPage().Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void TextUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
