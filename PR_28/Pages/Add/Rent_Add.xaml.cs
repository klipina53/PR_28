using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PR_28.Pages.Add
{
    /// <summary>
    /// Логика взаимодействия для Rent_Add.xaml
    /// </summary>
    public partial class Rent_Add : Page
    {
        MainWindow mw;
        Classes.Club club;
        Classes.Rent rent;
        public Rent_Add(MainWindow mw, Classes.Rent rent)
        {
            InitializeComponent();
            this.mw = mw;
            foreach (Classes.Club item in mw.clubs)
            {
                name.Items.Add(item.name);
            }
            if (rent != null)
            {
                this.rent = rent;
                name.SelectedItem = mw.clubs.FirstOrDefault(x => x.id == rent.id);
                this.datetime.Text = rent.dateandtime.ToString("yyyy-MM-dd HH:mm");
                this.fio.Text = rent.fio;
                lab.Content = "Изменить аренду игровых компьютеров";
                lb.Content = "Изменить";
            }
        }

        private void Back_Click(object sender, MouseButtonEventArgs e)
        {
            mw.frame.Navigate(new Pages.Rent_Main(mw));
        }

        private void Add_Click(object sender, MouseButtonEventArgs e)
        {
            if (Regex.IsMatch(datetime.Text, "([0-9]{4})-([0-9]{2})-([0-9]{2}) ([0-9]{2}):([0-9]{2})"))
            {
                if (this.rent == null)
                {
                    string query = $"INSERT INTO `rents` (`id`, `name`, `dateandtime`, `fio`) VALUES (NULL, '{name.Text}', '{datetime.Text}', '{fio.Text}');";
                    mw.Connection(query);
                    mw.LoadRent();
                    MessageBox.Show("Успешно добавлено.", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    string query = $"UPDATE `rents` SET `name` = '{name.Text}', `dateandtime` = '{datetime.Text}', `fio` = '{fio.Text}' WHERE `rents`.`id` = {rent.id};";
                    mw.Connection(query);
                    mw.LoadRent();
                    MessageBox.Show("Успешно изменено.", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                mw.frame.Navigate(new Pages.Rent_Main(mw));
            }
            else
            {
                MessageBox.Show("Неверно введены дата и время.");
                return;
            }
        }
    }
}
