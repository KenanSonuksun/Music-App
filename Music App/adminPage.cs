using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Proje3
{
    public partial class adminPage : Form
    {
        SqlConnection connection;
        SqlDataReader dataReader;
        SqlCommand command;
        public adminPage()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string adminName = TextAdminName.Text;
            string adminPassword = TextAdminPassword.Text;
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            command = new SqlCommand();
            connection.Open();
            command.Connection = connection;
            command.CommandText = "Select * from users inner join admin on users.Id = admin.userId where userName = '" + adminName + "' and userPassword = '" + adminPassword + "'"; 
            dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                MessageBox.Show("Signing in is successed");
                new adminControlPage().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("signing in is failed");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
