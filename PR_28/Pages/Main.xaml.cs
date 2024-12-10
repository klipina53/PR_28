using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PR_28.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        MainWindow mw;
        public Main(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
            LoadClub();
        }
        public void LoadClub()
        {
            parent.Children.Clear();
            foreach (Classes.Club club in mw.clubs)
            {
                parent.Children.Add(new Elements.Club_Itm(mw, club));
            }
        }
        private void Exit_Click(object sender, MouseButtonEventArgs e)
        {
            mw.Close();
        }

        private void Add_Click(object sender, MouseButtonEventArgs e)
        {
            mw.frame.Navigate(new Pages.Add.Club_Add(mw, null));
        }

        private void Rent_Click(object sender, MouseButtonEventArgs e)
        {
            mw.frame.Navigate(new Pages.Rent_Main(mw));
        }

        private void Plus(object sender, MouseButtonEventArgs e)
        {
            mw.clubs.Clear();
            MySqlDataReader itemsQuery1 = mw.Connection("SELECT * FROM `clubs` ORDER BY name ASC;");
            while (itemsQuery1.Read())
            {
                mw.clubs.Add(new Classes.Club(
                    itemsQuery1.GetInt32(0),
                        itemsQuery1.GetString(1),
                        itemsQuery1.GetString(2),
                        itemsQuery1.GetString(3),
                        itemsQuery1.GetString(4)
                    ));
                LoadClub();
            }
            itemsQuery1.Close();
        }

        private void Minus(object sender, MouseButtonEventArgs e)
        {
            mw.clubs.Clear();
            MySqlDataReader itemsQuery1 = mw.Connection("SELECT * FROM `clubs` ORDER BY name DESC;");
            while (itemsQuery1.Read())
            {
                mw.clubs.Add(new Classes.Club(
                    itemsQuery1.GetInt32(0),
                        itemsQuery1.GetString(1),
                        itemsQuery1.GetString(2),
                        itemsQuery1.GetString(3),
                        itemsQuery1.GetString(4)
                    ));
                LoadClub();
            }
            itemsQuery1.Close();
        }
    }
}
