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
    /// 
    public partial class MainWindow : Window
    {
        int z; //длительность прогноза
        private double B1, B2, B3, SUM, t, pi = 3.14; //Из формулы
        private DateTime DATA; //дата в таблицу

        private void Clean_Click(object sender, RoutedEventArgs e) //очистка таблицы
        {
            List<BioTable> result = new List<BioTable>(3);
            BioGrid.ItemsSource = result;
        }

        public static DateTime Today { get; }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Pvd_Click(object sender, RoutedEventArgs e) //Для чекбокса длительность прогноза
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
        public void Ok_Click(object sender, RoutedEventArgs e)
        {
            List<BioTable> result = new List<BioTable>(3); //хранит данные
            if ((ComDlit.Text == "" && pvd.IsChecked == false) || (ProizvProg.Text == "" && pvd.IsChecked == true)) //проверка на пустое поле
            {
                MessageBox.Show("Введите длительность прогноза", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (pvd.IsChecked == true)
                z = int.Parse(ProizvProg.Text);
            else
                z = int.Parse(ComDlit.Text);
            Stata.Text = "Дата рождения:\n" + SelDRCom.Text + "\nДлительность прогноза: " + z + "\nПериод с " + DO.Text + " по " + DateTime.Today.ToString("D");
            DateTime a = DateTime.Parse(SelDRCom.Text);  //перевод выбранной даты в datetime
            DateTime b = DateTime.Parse(DateTime.Today.ToString()); //перевод даты на сегодня в datetime
            t = (b - a).TotalDays;//количество дней с др
            for (int i = 0; i < z; i++)
            {
                t += i;
                //Console.WriteLine(t);
                B1 = Math.Round(Math.Sin(2 * pi * t / 23) * 100, 2);
                B2 = Math.Round(Math.Sin(2 * pi * t / 28) * 100 ,2);
                B3 = Math.Round(Math.Sin(2 * pi * t / 33) * 100, 2);
                SUM = Math.Round(B1 + B2 + B3);
                DATA = a.AddDays(i);
                result.Add(new BioTable(1, B1, B2, B3, SUM, DATA));
                //Console.WriteLine($"{B1} {B2} {B3}\n");
            }
            BioGrid.ItemsSource = result;
        }
    }
}

