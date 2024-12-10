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
    /// Логика взаимодействия для Rent_Main.xaml
    /// </summary>
    public partial class Rent_Main : Page
    {
        MainWindow mw;
        public Rent_Main(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
            LoadRent();
        }
        public void LoadRent()
        {
            parent.Children.Clear();
            foreach (Classes.Rent rent in mw.rents)
            {
                parent.Children.Add(new Elements.Rent_Itm(mw, rent));
            }
        }
        private void Exit_Click(object sender, MouseButtonEventArgs e)
        {
            mw.Close();
        }

        private void Add_Click(object sender, MouseButtonEventArgs e)
        {
            mw.frame.Navigate(new Pages.Add.Rent_Add(mw, null));
        }

        private void CompClub_Click(object sender, MouseButtonEventArgs e)
        {
            mw.frame.Navigate(new Pages.Main(mw));
        }

        private void Plus(object sender, MouseButtonEventArgs e)
        {
            mw.rents.Clear();
            MySqlDataReader itemsQuery2 = mw.Connection("SELECT * FROM `rents` ORDER BY name ASC;");
            while (itemsQuery2.Read())
            {
                mw.rents.Add(new Classes.Rent(
                    itemsQuery2.GetInt32(0),
                        itemsQuery2.GetString(1),
                        itemsQuery2.GetDateTime(2),
                        itemsQuery2.GetString(3)
                    ));
                LoadRent();
            }
            itemsQuery2.Close();
        }

        private void Minus(object sender, MouseButtonEventArgs e)
        {
            mw.rents.Clear();
            MySqlDataReader itemsQuery2 = mw.Connection("SELECT * FROM `rents` ORDER BY name DESC;");
            while (itemsQuery2.Read())
            {
                mw.rents.Add(new Classes.Rent(
                    itemsQuery2.GetInt32(0),
                        itemsQuery2.GetString(1),
                        itemsQuery2.GetDateTime(2),
                        itemsQuery2.GetString(3)
                    ));
                LoadRent();
            }
            itemsQuery2.Close();
        }
    }
}
