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
    public partial class registerPage : Form
    {
        static string connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection connect = new SqlConnection(connection);
        public registerPage()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                string query = "insert into users(userName,userMail,userPassword,userCountry) values(@userName,@userMail,@userPassword,@userCountry)";
                SqlCommand command = new SqlCommand(query,connect);
                command.Parameters.AddWithValue("@userName",TextUserName.Text);
                command.Parameters.AddWithValue("@userMail", TextUserMail.Text);
                command.Parameters.AddWithValue("@userPassword", TextUserPassword.Text);
                command.Parameters.AddWithValue("@userCountry", TextUserCountryCode.Text);
                command.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Signin up is failed");
                new Form1().Show();
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("System Error");

                throw;
            }
        }
    }
}
