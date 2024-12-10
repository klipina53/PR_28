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

namespace PR_28.Pages.Add
{
    /// <summary>
    /// Логика взаимодействия для Club_Add.xaml
    /// </summary>
    public partial class Club_Add : Page
    {
        MainWindow mw;
        Classes.Club club;
        public Club_Add(MainWindow mw, Classes.Club club)
        {
            InitializeComponent();
            this.mw = mw;
            if (club != null)
            {
                this.club = club;
                this.name.Text = club.name;
                this.address.Text = club.address;
                this.timestart.Text = club.time_start;
                this.timeend.Text = club.time_end;
                lab.Content = "Изменить компьютерный клуб";
                lb.Content = "Изменить";
            }
        }

        private void Add_Click(object sender, MouseButtonEventArgs e)
        {
            if (this.club == null)
            {
                string query = $"INSERT INTO `clubs` (`id`, `name`, `address`, `time_start`, `time_end`) VALUES(NULL, '{name.Text}', '{address.Text}', '{timestart.Text}', '{timeend.Text}')";
                mw.Connection(query);
                mw.LoadClub();
                MessageBox.Show("Успешно добавлено.", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                string query = $"UPDATE `clubs` SET `name` = '{name.Text}', `address` = '{address.Text}', `time_start` = '{timestart.Text}', `time_end` = '{timeend.Text}' WHERE `clubs`.`id` = {club.id};";
                mw.Connection(query);
                mw.LoadClub();
                MessageBox.Show("Успешно изменено.", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            mw.frame.Navigate(new Pages.Main(mw));
        }

        private void Back_Click(object sender, MouseButtonEventArgs e)
        {
            mw.frame.Navigate(new Pages.Main(mw));
        }
    }
