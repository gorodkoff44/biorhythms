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
using System.Windows.Threading;

namespace Биоритмы
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DateTime Today { get; }
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void pvd_Click(object sender, RoutedEventArgs e)
        {
            if (pvd.IsChecked == true)
            {
                ProizvProg.Visibility = Visibility.Visible;
                ComDlit.IsEnabled = false;
            }
            else
            {
                ProizvProg.Visibility = Visibility.Hidden;
                ComDlit.IsEnabled = true;
            }

        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            string prog;
            if (ComDlit.Text == ""&&pvd.IsChecked==false)
            {
                MessageBox.Show("Введите длительность прогноза", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ProizvProg.Text == "" && pvd.IsChecked == true)
            {
                MessageBox.Show("Введите длительность прогноза", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ComDlit.Text != "" && pvd.IsChecked == false)
            {
                prog = ComDlit.Text;
            }
            else
                prog = ProizvProg.Text;
                Stata.Text = "Дата рождения:\n" + SelDRCom.Text + "\nДлительность прогноза: " + prog + "\n Период с " + DO.Text + " по " + DateTime.Today.ToString("D");
        }
    }
}
