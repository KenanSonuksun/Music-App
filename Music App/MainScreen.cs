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
    public partial class MainScreen : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter dataAdapter;
        SqlDataReader dataReader;
        int id;
        public MainScreen(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            getUsers();
            getTop10();
            getAlbum();
            getMusic();
            getPop();
            getClassic();
            getJazz();
            getCountry();
        }
        void getUsers()
        {
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("select Id, userName from users", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            UserDGV.DataSource = dataTable;
            connection.Close();
        }
        void getTop10()
        {
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("select TOP 10 musics.Id ," +
                " musics.musicName," +
                " artists.artistName," +
                " category.categoryName," +
                " musics.musicClicked from musics " +
                "inner join category on category.Id = musics.categoryId " +
                "inner join artists on artists.Id = musics.artistId  " +
                "order by musics.musicClicked desc", connection);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            Top10DGV.DataSource = table;
            connection.Close();
        }
        void getMusic()
        {
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("select * from musics", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            MusicListDGV.DataSource = dataTable;
            connection.Close();
        }
        void getAlbum()
        {
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("select * from albums ", connection);
            DataTable tablo = new DataTable();
            dataAdapter.Fill(tablo);
            AlbumListDGV.DataSource = tablo;
            connection.Close();
        }
        void  getPop()
        {
            //1
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("select musics.Id,musics.musicName,category.categoryName from musicplayer " +
                "inner join musics on musics.Id = musicplayer.musicId " +
                "inner join category on category.Id = musics.categoryId " +
                "inner join users on musicplayer.userId = users.Id " +
                " where category.Id = 1 and users.Id = " + this.id, connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            PopDGV.DataSource = dataTable;
            connection.Close();
        }
        void getClassic()
        {
            //2
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("select musics.Id,musics.musicName,category.categoryName from musicplayer " +
                "inner join musics on musics.Id = musicplayer.musicId " +
                "inner join category on category.Id = musics.categoryId " +
                "inner join users on musicplayer.userId = users.Id " +
                " where category.Id = 2 and users.Id = " + this.id, connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            ClassicDGV.DataSource = dataTable;
            connection.Close();
        }
        void getJazz()
        {
            //3
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("select musics.Id,musics.musicName,category.categoryName from musicplayer " +
                "inner join musics on musics.Id = musicplayer.musicId " +
                "inner join category on category.Id = musics.categoryId " +
                "inner join users on musicplayer.userId = users.Id " +
                " where category.Id = 3 and users.Id = " + this.id, connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            JazzDGV.DataSource = dataTable;
            connection.Close();
        }
        void getCountry()
        {
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("select TOP 10 artists.artistCountry ," +
                " musics.musicName," +
                " artists.artistName," +
                " category.categoryName," +
                " musics.musicClicked from musics " +
                "inner join category on category.Id = musics.categoryId " +
                "inner join artists on artists.Id = musics.artistId " +
                "order by musics.musicClicked desc", connection);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            CountryDGV.DataSource = table;
            connection.Close();
        }
        
        private void button11_Click(object sender, EventArgs e)
        {
            string query = "select * from musicplayer where userId = @id and musicId=@musicId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", this.id);
            command.Parameters.AddWithValue("@musicId", MusicListDGV.CurrentRow.Cells[0].Value);
            connection.Open();
            command.ExecuteNonQuery();
            dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                connection.Close();
                MessageBox.Show("You have already added this music");
            }
            else
            {
                connection.Close();
                string query1 = "insert into musicplayer(userId,musicId) values(@userId,@musicId)";
                command = new SqlCommand(query1, connection);
                command.Parameters.AddWithValue("@userId", this.id);
                command.Parameters.AddWithValue("@musicId", MusicListDGV.CurrentRow.Cells[0].Value);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                getPop();
                getClassic();
                getJazz();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string queryString = "update musics set musicClicked = musicClicked + 1 where Id=@musicId";
            command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@musicId", MusicListDGV.CurrentRow.Cells[0].Value);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            getMusic();
            getCountry();
            getTop10();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int anotherId = (int)UserDGV.CurrentRow.Cells[0].Value;
            string queryString = "select * from premiumUser where userId = @id";
            command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@id", anotherId);
            connection.Open();
            command.ExecuteNonQuery();
            dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                connection.Close();
                string queryString1 = "insert into followers(followerId,followedId) values(@followerId,@followedId)";
                command = new SqlCommand(queryString1, connection);
                command.Parameters.AddWithValue("@followerId", this.id);
                command.Parameters.AddWithValue("@followedId", anotherId);
                connection.Open(); 
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Following is successed");

            }
            else
            {
                connection.Close();
                MessageBox.Show("This user that you wanted to follow is not a premium user");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id2 = (int)UserDGV.CurrentRow.Cells[0].Value;
            string showQuery = "select * from followers where followerId = @followerId and followedId = @followedId";
            command = new SqlCommand(showQuery, connection);
            command.Parameters.AddWithValue("@followerid", this.id);
            command.Parameters.AddWithValue("@followedid", id2);
            connection.Open();
            command.ExecuteNonQuery();
            dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                connection.Close();
                connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                connection.Open();
                dataAdapter = new SqlDataAdapter("select musics.Id , musics.musicName  ," +
                    " artists.artistName," +
                    " category.categoryName from musicplayer " +
                    "inner join musics on musics.Id = musicplayer.musicId " +
                    "inner join category on category.Id = musics.categoryId " +
                    "inner join users on musicplayer.userId = users.Id " +
                    "inner join artists on artists.Id = musics.artistId " +
                    "where category.Id = 1 and users.Id=" + id2, connection);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                PopDGV.DataSource = table;
                connection.Close();
                connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                connection.Open();
                dataAdapter = new SqlDataAdapter("select musics.Id as Id ,musics.musicName, artists.artistName , category.categoryName from musicplayer " +
                    "inner join musics on musics.Id = musicplayer.musicId " +
                    "inner join category on musics.categoryId = category.Id " +
                    "inner join users on musicplayer.userId = users.Id " +
                    "inner join artists on musics.artistId = artists.Id " +
                    "where category.Id = 2 and users.Id=" + id2, connection);
                DataTable table1 = new DataTable();
                dataAdapter.Fill(table1);
                ClassicDGV.DataSource = table1;
                connection.Close();
                connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                connection.Open();
                dataAdapter = new SqlDataAdapter("select musics.Id as Id ,musics.musicName , artists.artistName , category.categoryName from musicPlayer " +
                    "inner join musics on musics.Id = musicplayer.musicId " +
                    "inner join category on musics.categoryId = category.Id " +
                    "inner join users on musicplayer.userId = users.Id " +
                    "inner join artists on musics.artistId = artists.Id " +
                    "WHERE category.Id = 3 and users.Id=" + id2, connection);
                DataTable table2 = new DataTable();
                dataAdapter.Fill(table2);
                JazzDGV.DataSource = table2;
                connection.Close();
            }
            else
            {
                connection.Close();
                MessageBox.Show("You have to follow this user before showing playlist");
                connection.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            string queryString = "select * from musicplayer where userId = @id and musicId=@musicId";
            command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@id", this.id);
            command.Parameters.AddWithValue("@musicId", PopDGV.CurrentRow.Cells[0].Value);
            connection.Open();
            command.ExecuteNonQuery();
            dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                connection.Close();
                MessageBox.Show("You can add music just one time!");
            }
            else
            {
                connection.Close();
                string queryString1 = "insert into musicplayer(userId,musicId) values(@userId,@musicId)";
                command = new SqlCommand(queryString1, connection);
                command.Parameters.AddWithValue("@userId", this.id);
                command.Parameters.AddWithValue("@musicId", PopDGV.CurrentRow.Cells[0].Value);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }

            getPop();
            getJazz();
            getClassic();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in PopDGV.Rows)
                {
                    string queryString = "select * from musicplayer where userId = @id and musicId=@musicId";
                    command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@id", this.id);
                    command.Parameters.AddWithValue("@musicId", row.Cells[0].Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        connection.Close();
                        MessageBox.Show("You can add music just one time!");
                    }
                    else
                    {
                        connection.Close();
                        string queryString1 = "insert into musicplayer(userId,musicId) values(@userId,@musicId)";
                        command = new SqlCommand(queryString1, connection);
                        command.Parameters.AddWithValue("@userId", this.id);
                        command.Parameters.AddWithValue("@musicId", row.Cells[0].Value);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();

                    }
                }
            }
            catch (Exception)
            {

                Console.WriteLine("");
            }
            getPop();
            getJazz();
            getClassic();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("Select musics.Id , musics.musicName ," +
                " artists.artistName ," +
                " category.categoryName from musicplayer " +
                "inner join musics on musics.Id = musicplayer.musicId " +
                "inner join category on category.Id = musics.categoryId " +
                "inner join users on musicplayer.userId = users.Id " +
                "inner join artists on artists.Id = musics.artistId " +
                "where category.Id = 1 and users.Id=" + this.id, connection);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            PopDGV.DataSource = table;
            connection.Close();
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("Select musics.Id ,musics.musicName , artists.artistName , category.categoryName from musicplayer " +
                "inner join musics on musics.Id = musicplayer.musicId " +
                "inner join category on musics.categoryId = category.Id " +
                "inner join users on musicplayer.userId = users.Id " +
                "inner join artists on musics.artistId = artists.Id " +
                "where category.Id = 2 and users.Id=" + this.id, connection);
            DataTable table1 = new DataTable();
            dataAdapter.Fill(table1);
            ClassicDGV.DataSource = table1;
            connection.Close();
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("Select musics.Id ,musics.musicName , artists.artistName , category.categoryName from musicplayer " +
                "inner join musics on musics.Id = musicplayer.musicId " +
                "inner join category on musics.categoryId = category.Id " +
                "inner join users on musicplayer.userId = users.Id " +
                 "inner join artists on musics.artistId = artists.Id " +
                "where category.Id = 3 and users.Id=" + this.id, connection);
            DataTable table2 = new DataTable();
            dataAdapter.Fill(table2);
            JazzDGV.DataSource = table2;
            connection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("Select TOP 10 musics.Id ," +
                " musics.musicName ," +
                " artists.artistName , " +
                " musics.musicClicked ," +
                " category.categoryName from musics " +
                "inner join category on category.Id = musics.categoryId " +
                "inner join artists on artists.Id = musics.artistId " +
                "where category.Id = 1" +
                "order by musics.musicClicked desc", connection);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            PopDGV.DataSource = table;
            connection.Close();
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("Select TOP 10 musics.Id ," +
                " musics.musicName ," +
                " artists.artistName , " +
                " musics.musicClicked ," +
                " category.categoryName from musics " +
                "inner join category on musics.categoryId = category.Id " +
                "inner join artists on musics.artistId = artists.Id " +
                "where category.Id = 2" +
                "order by musics.musicClicked desc", connection);
            DataTable table1 = new DataTable();
            dataAdapter.Fill(table1);
            JazzDGV.DataSource = table1;
            connection.Close();
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("Select TOP 10 musics.Id ," +
                "musics.musicName ," +
                "artists.artistName ," +
                "musics.musicClicked  ," +
                "category.categoryName from musics " +
                "inner join category on musics.categoryId = category.Id " +
                "inner join artists on musics.artistId = artists.Id " +
                "where category.Id = 3" +
                "order by musics.musicClicked desc", connection);
            DataTable table2 = new DataTable();
            dataAdapter.Fill(table2);
            ClassicDGV.DataSource = table2;
            connection.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string queryString = "select * from musicplayer where userId = @id and musicId=@musicId";
            command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@id", this.id);
            command.Parameters.AddWithValue("@musicId", ClassicDGV.CurrentRow.Cells[0].Value);
            connection.Open();
            command.ExecuteNonQuery();
            dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                connection.Close();
                MessageBox.Show("You can add music just one time!");
            }
            else
            {
                connection.Close();
                string queryString1 = "insert into musicplayer(userId,musicId) values(@userId,@musicId)";
                command = new SqlCommand(queryString1, connection);
                command.Parameters.AddWithValue("@userId", this.id);
                command.Parameters.AddWithValue("@musicId", ClassicDGV.CurrentRow.Cells[0].Value);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
               

            }
                getPop();
                getClassic();
                getJazz();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string queryString = "select * from musicplayer where userId = @id and musicId=@musicId";
            command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@id", this.id);
            command.Parameters.AddWithValue("@musicId", JazzDGV.CurrentRow.Cells[0].Value);
            connection.Open();
            command.ExecuteNonQuery();
            dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                connection.Close();
                MessageBox.Show("You can add music just one time!");
            }
            else
            {
                connection.Close();
                string queryString1 = "insert into musicplayer(userId,musicId) values(@userId,@musicId)";
                command = new SqlCommand(queryString1, connection);
                command.Parameters.AddWithValue("@userId", this.id);
                command.Parameters.AddWithValue("@musicId", JazzDGV.CurrentRow.Cells[0].Value);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                
            }
            getPop();
            getClassic();
            getJazz();


        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in ClassicDGV.Rows)
                {
                    string queryString = "select * from musicplayer where userId = @id and musicId=@musicId";
                    command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@id", this.id);
                    command.Parameters.AddWithValue("@musicId", row.Cells[0].Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        connection.Close();
                        MessageBox.Show("You can add music just one time!");
                    }
                    else
                    {
                        connection.Close();
                        string queryString1 = "insert into musicplayer(userId,musicId) values(@userId,@musicId)";
                        command = new SqlCommand(queryString1, connection);
                        command.Parameters.AddWithValue("@userId", this.id);
                        command.Parameters.AddWithValue("@musicId", row.Cells[0].Value);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();

                    }
                }
            }
            catch (Exception)
            {

                Console.WriteLine("");
            }
            getPop();
            getClassic();
            getJazz();
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in JazzDGV.Rows)
                {
                    string queryString = "select * from musicplayer where userId = @id and musicId=@musicId";
                    command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@id", this.id);
                    command.Parameters.AddWithValue("@musicId", row.Cells[0].Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        connection.Close();
                        MessageBox.Show("You can add music just one time!");
                    }
                    else
                    {
                        connection.Close();
                        string queryString1 = "insert into musicplayer(userId,musicId) values(@userId,@musicId)";
                        command = new SqlCommand(queryString1, connection);
                        command.Parameters.AddWithValue("@userId", this.id);
                        command.Parameters.AddWithValue("@musicId", row.Cells[0].Value);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();

                    }
                }
            }
            catch (Exception)
            {

                Console.WriteLine("");
            }
            getPop();
            getClassic();
            getJazz();
            
        }
    }
}
