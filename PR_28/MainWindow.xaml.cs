using System.Collections.Generic;
using System.Windows;
using MySql.Data.MySqlClient;

namespace PR_28
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Classes.Club> clubs = new List<Classes.Club>();
        public List<Classes.Rent> rents = new List<Classes.Rent>();
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                LoadClub();
                LoadRent();
            }
            catch
            {
                MessageBox.Show("Нет подключения к базе данных.");
            }
            frame.Navigate(new Pages.Main(this));
        }
        public MySqlDataReader Connection(string query)
        {
            string connect = "server=127.0.0.1;port=3306;database=ComputerClub;uid=root";
            MySqlConnection mySqlConnection = new MySqlConnection(connect);
            mySqlConnection.Open();
            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
            return mySqlCommand.ExecuteReader();
        }
        public void LoadClub()
        {
            clubs.Clear();
            MySqlDataReader itemsQuery1 = Connection("SELECT * FROM `clubs`");
            while (itemsQuery1.Read())
            {
                clubs.Add(new Classes.Club(
                    itemsQuery1.GetInt32(0),
                        itemsQuery1.GetString(1),
                        itemsQuery1.GetString(2),
                        itemsQuery1.GetString(3),
                        itemsQuery1.GetString(4)
                    ));
            }
            itemsQuery1.Close();
        }
        public void LoadRent()
        {
            rents.Clear();
            MySqlDataReader itemsQuery2 = Connection("SELECT * FROM `rents`");
            while (itemsQuery2.Read())
            {
                rents.Add(new Classes.Rent(
                    itemsQuery2.GetInt32(0),
                        itemsQuery2.GetString(1),
                        itemsQuery2.GetDateTime(2),
                        itemsQuery2.GetString(3)
                    ));
            }
            itemsQuery2.Close();
        }
    }
}
