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
    public partial class adminControlPage : Form
    {
        SqlConnection connection;
        SqlDataAdapter dataAdapter;
        SqlCommand command;
        private string textId;
        private string textId2;
        private string textId3;
        private string textId4;

        public adminControlPage()
        {
            InitializeComponent();
        }

        private void adminControlPage_Load(object sender, EventArgs e)
        {
            
        }
        void getMusic()
        {
            Console.WriteLine("dasdasdasdas");
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("select * from musics", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            MusicDGV.DataSource = dataTable;
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
        void getCategory()
        {
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("select * from category ", connection);
            DataTable tablo = new DataTable();
            dataAdapter.Fill(tablo);
            CategoryDGV.DataSource = tablo;
            connection.Close();
        }
        void getArtists()
        {
            connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            connection.Open();
            dataAdapter = new SqlDataAdapter("select * from artists ", connection);
            DataTable tablo = new DataTable();
            dataAdapter.Fill(tablo);
            ArtistDGV.DataSource = tablo;
            connection.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TextAlbumId.Text != "")
            {
                string query = "insert into musics(artistId,albumId,categoryId,musicName,musicDate,musicTime) values(@artistId,@albumId,@categoryId,@musicName,@musicDate,@musicTime)";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@artistId", Convert.ToInt32(TextArtistId.Text));
                command.Parameters.AddWithValue("@albumId", Convert.ToInt32(TextAlbumId.Text));
                command.Parameters.AddWithValue("@categoryId", Convert.ToInt32(TextCategoryId.Text));
                command.Parameters.AddWithValue("@musicName", TextMusicName.Text);
                command.Parameters.AddWithValue("@musicDate", MusicDate.Value);
                command.Parameters.AddWithValue("@musicTime", TextMusicTime.Text);
            }
            else
            { 
                string query = "insert into musics(artistId,categoryId,musicName,musicDate,musicTime) values(@artistId,@categoryId,@musicName,@musicDate,@musicTime)";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@artistId", Convert.ToInt32(TextArtistId.Text));
                command.Parameters.AddWithValue("@categoryId", Convert.ToInt32(TextCategoryId.Text));
                command.Parameters.AddWithValue("@musicName", TextMusicName.Text);
                command.Parameters.AddWithValue("@musicDate", MusicDate.Value);
                command.Parameters.AddWithValue("@musicTime", TextMusicTime.Text);
            }
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            getMusic();
        }

        private void MusicList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {   
            textId = MusicDGV.CurrentRow.Cells[0].Value.ToString();
            TextArtistId.Text = MusicDGV.CurrentRow.Cells[1].Value.ToString();
            TextAlbumId.Text = MusicDGV.CurrentRow.Cells[2].Value.ToString();
            TextCategoryId.Text = MusicDGV.CurrentRow.Cells[3].Value.ToString();
            TextMusicName.Text = MusicDGV.CurrentRow.Cells[4].Value.ToString();
            MusicDate.Text = MusicDGV.CurrentRow.Cells[5].Value.ToString();
            TextMusicTime.Text = MusicDGV.CurrentRow.Cells[6].Value.ToString();
        }

        private void MusicList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TextAlbumId.Text != "")
            {
                string query = "update musics set artistId = @artistId,albumId=@albumId,categoryId=@categoryId,musicName=@musicName,musicDate=@musicDate,musicTime=@musicTime where Id = @Id";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", Convert.ToInt32(textId));
                command.Parameters.AddWithValue("@artistId", Convert.ToInt32(TextArtistId.Text));
                command.Parameters.AddWithValue("@albumId", Convert.ToInt32(TextAlbumId.Text));
                command.Parameters.AddWithValue("@categoryId", Convert.ToInt32(TextCategoryId.Text));
                command.Parameters.AddWithValue("@musicName", TextMusicName.Text);
                command.Parameters.AddWithValue("@musicDate", MusicDate.Value);
                command.Parameters.AddWithValue("@musicTime", TextMusicTime.Text);
            }
            else
            {
                string query = "update musics set artistId = @artistId,categoryId=@categoryId,musicName=@musicName,musicDate=@musicDate,musicTime=@musicTime where Id = @Id";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", Convert.ToInt32(textId));
                command.Parameters.AddWithValue("@artistId", Convert.ToInt32(TextArtistId.Text));
                command.Parameters.AddWithValue("@categoryId", Convert.ToInt32(TextCategoryId.Text));
                command.Parameters.AddWithValue("@musicName", TextMusicName.Text);
                command.Parameters.AddWithValue("@musicDate", MusicDate.Value);
                command.Parameters.AddWithValue("@musicTime", TextMusicTime.Text);
            }
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            getMusic();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "delete from musics where Id=@Id";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", Convert.ToInt32(textId));
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            getMusic();
        }

        private void adminControlPage_Load_1(object sender, EventArgs e)
        {
            getMusic();
            getAlbum();
            getCategory();
            getArtists();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sorgu1 = "insert into albums(artistId,categoryId,musicId,albumName,albumDate) values(@artistId,@categoryId,@musicId,@albumName,@albumDate)";
            command = new SqlCommand(sorgu1, connection);
            command.Parameters.AddWithValue("@artistId", Convert.ToInt32(TextArtistId2.Text));
            command.Parameters.AddWithValue("@musicId", Convert.ToInt32(TextMusicId2.Text));
            command.Parameters.AddWithValue("@categoryId", Convert.ToInt32(TextCategoryId2.Text));
            command.Parameters.AddWithValue("@albumName", TextAlbumName2.Text);
            command.Parameters.AddWithValue("@albumDate", MusicDate2.Value);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            getAlbum();
        }

        private void AlbumListDGV_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textId2 = AlbumListDGV.CurrentRow.Cells[0].Value.ToString();

            TextArtistId2.Text = AlbumListDGV.CurrentRow.Cells[1].Value.ToString();
            TextCategoryId2.Text = AlbumListDGV.CurrentRow.Cells[2].Value.ToString();
            TextMusicId2.Text = AlbumListDGV.CurrentRow.Cells[5].Value.ToString();
            TextAlbumName2.Text = AlbumListDGV.CurrentRow.Cells[3].Value.ToString();
            MusicDate2.Text = AlbumListDGV.CurrentRow.Cells[4].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string query1 = "update albums set artistId = @artistId,albumName=@albumName,categoryId=@categoryId,musicId=@musicId,albumDate=@albumDate where Id = @Id";
            command = new SqlCommand(query1, connection);
            command.Parameters.AddWithValue("@Id", Convert.ToInt32(textId2));
            command.Parameters.AddWithValue("@artistId", Convert.ToInt32(TextArtistId2.Text));
            command.Parameters.AddWithValue("@musicId", Convert.ToInt32(TextMusicId2.Text));
            command.Parameters.AddWithValue("@categoryId", Convert.ToInt32(TextCategoryId2.Text));
            command.Parameters.AddWithValue("@albumName", TextAlbumName2.Text);
            command.Parameters.AddWithValue("@albumDate", MusicDate2.Value);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            getAlbum();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string query1 = "delete from albums where Id=@Id";
            command = new SqlCommand(query1, connection);
            command.Parameters.AddWithValue("@Id", Convert.ToInt32(textId2));
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            getAlbum();

        }
        private void button11_Click(object sender, EventArgs e)
        {
            string query3 = "update artists set artistName=@artistName, artistCountry=@artistCountry where Id=@Id";
            command = new SqlCommand(query3, connection);
            command.Parameters.AddWithValue("@Id", Convert.ToInt32(textId4));
            command.Parameters.AddWithValue("@artistName", TextArtistName.Text);
            command.Parameters.AddWithValue("@artistCountry", TextArtistCountry.Text);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            getArtists();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string query2 = "insert into category(categoryName) values(@categoryName)";
            command = new SqlCommand(query2, connection);
            command.Parameters.AddWithValue("@categoryName", TextCategoryName.Text);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            getCategory();
        }


        private void button8_Click(object sender, EventArgs e)
        {
            string query2 = "update category set categoryName=@categoryName where Id=@Id";
            command = new SqlCommand(query2, connection);
            command.Parameters.AddWithValue("@Id", Convert.ToInt32(textId3));
            command.Parameters.AddWithValue("@categoryName", TextCategoryName.Text);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            getCategory();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string query2 = "delete from category where Id=@Id";
            command = new SqlCommand(query2, connection);
            command.Parameters.AddWithValue("@Id", Convert.ToInt32(textId3));
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            getCategory();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string query3 = "insert into artists(artistName,artistCountry) values(@artistName,@artistCountry)";
            command = new SqlCommand(query3, connection);
            command.Parameters.AddWithValue("@artistName", TextArtistName.Text);
            command.Parameters.AddWithValue("@artistCountry", TextArtistCountry.Text);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            getArtists();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string query3 = "delete from artists where Id=@Id";
            command = new SqlCommand(query3, connection);
            command.Parameters.AddWithValue("@Id", Convert.ToInt32(textId4));
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            getArtists();
        }

        private void CategoryList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void CategoryDGV_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textId3 = CategoryDGV.CurrentRow.Cells[0].Value.ToString();
            TextCategoryName.Text = CategoryDGV.CurrentRow.Cells[1].Value.ToString();
        }

        private void ArtistDGV_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textId4 = ArtistDGV.CurrentRow.Cells[0].Value.ToString();
            TextArtistName.Text = ArtistDGV.CurrentRow.Cells[1].Value.ToString();
            TextArtistCountry.Text = ArtistDGV.CurrentRow.Cells[2].Value.ToString();
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }
}
