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
        private double t; //к-во дней, прошедших с др
        private readonly double pi = 3.14;
        public static DateTime Today { get; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Pvd_Click(object sender, RoutedEventArgs e)
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
            string prog;
            if ((ComDlit.Text == "" && pvd.IsChecked == false) || (ProizvProg.Text == "" && pvd.IsChecked == true))
            {
                MessageBox.Show("Введите длительность прогноза", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            prog = ComDlit.Text != "" && pvd.IsChecked == false ? ComDlit.Text : ProizvProg.Text; //ввод длительности прогноза
            Stata.Text = "Дата рождения:\n" + SelDRCom.Text + "\nДлительность прогноза: " + prog + "\n Период с " + DO.Text + " по " + DateTime.Today.ToString("D");
            int z = int.Parse(ComDlit.Text);
            double[] B1 = new double[z]; //состояние биоритмов в %
            double[] B2 = new double[z]; //состояние биоритмов в %
            double[] B3 = new double[z];  //состояние биоритмов в %
            int[] ID = new int[z];
            for (int i = 0; i < z; i++)
            {
                DateTime a = DateTime.Parse(SelDRCom.Text);  //перевод даты в datetime
                DateTime b = DateTime.Parse(DateTime.Today.ToString()); //перевод даты в datetime
                t = (b - a).TotalDays + i;
                //Console.WriteLine(t);
                ID[i] = i;
                B1[i] = Math.Sin(2 * pi * t / 23) * 100;
                B2[i] = Math.Sin(2 * pi * t / 28) * 100;
                B3[i] = Math.Sin(2 * pi * t / 33) * 100;
                //Console.WriteLine($"{B1} {B2} {B3}\n");

            }
            List<BioTable> result = new List<BioTable>(3);
            for (int i = 0; i < z; i++)
            {
                result.Add(new BioTable(1, B1[i], B2[i], B3[i]));
            }
            BioGrid.ItemsSource = result;
        }
    }
}

