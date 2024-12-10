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
        Classes.Rent rent;
        Classes.Club club;
        public Rent_Itm(MainWindow mw, Classes.Rent rent)
        {
            InitializeComponent();
            this.mw = mw;
            this.rent = rent;
            name.Content = "Клуб: " + rent.name;
            datetime.Content = "Дата и время: " + rent.dateandtime;
            fio.Content = "ФИО клиента: " + rent.fio;
        }

        private void Edit_Click(object sender, MouseButtonEventArgs e)
        {
            mw.frame.Navigate(new Pages.Add.Rent_Add(mw, rent));
        }

        private void Del_Click(object sender, MouseButtonEventArgs e)
        {
            string query = "DELETE FROM rents WHERE id=" + rent.id;
            mw.Connection(query);
            mw.LoadRent();
            MessageBox.Show("Запись успешно удалена.");
            mw.frame.Navigate(new Pages.Rent_Main(mw));
        }
    }
}
