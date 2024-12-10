using System;
using System.Collections.Generic;
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

namespace PR_28.Elements
{
    /// <summary>
    /// Логика взаимодействия для Rent_Itm.xaml
    /// </summary>
    public partial class Rent_Itm : UserControl
    {
         MainWindow mw;
        Classes.Club club;
        public Club_Itm(MainWindow mw, Classes.Club club)
        {
            InitializeComponent();
            this.mw = mw;
            this.club = club;
            name.Content = "Наименование: " + club.name;
            address.Content = "Адрес: " + club.address;
            time.Content = "Время работы: " + club.time_start + " - " + club.time_end;
        }

        private void Edit_Click(object sender, MouseButtonEventArgs e)
        {
            mw.frame.Navigate(new Pages.Add.Club_Add(mw, club));
        }

        private void Del_Click(object sender, MouseButtonEventArgs e)
        {
            string query = "DELETE FROM clubs WHERE id=" + club.id;
            mw.Connection(query);
            mw.LoadClub();
            MessageBox.Show("Запись успешно удалена.");
            mw.frame.Navigate(new Pages.Main(mw));
        }
    }
}
