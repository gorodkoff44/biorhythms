﻿using System;
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
<<<<<<< HEAD
        
        int z, zz;
        double B1, B2, B3, SUM, t, pi = 3.14;

        DateTime DATA;

        private void Clean_Click(object sender, RoutedEventArgs e)
        {
            List<BioTable> result = new List<BioTable>(3);
            BioGrid.ItemsSource = result;
        }

        private readonly string prog;
=======
        private double t; //к-во дней, прошедших с др
        private double t1; //к-во дней, прошедших с др
        int z;
        private readonly double pi = 3.14;
>>>>>>> parent of ae3b153 (починил)
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
<<<<<<< HEAD
            List<BioTable> result = new List<BioTable>(3);
=======
            string prog;
>>>>>>> parent of ae3b153 (починил)
            if ((ComDlit.Text == "" && pvd.IsChecked == false) || (ProizvProg.Text == "" && pvd.IsChecked == true)) //проверка на пустое поле
            {
                MessageBox.Show("Введите длительность прогноза", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
<<<<<<< HEAD
            if (pvd.IsChecked == true) //длительность прогноза
                z = int.Parse(ProizvProg.Text);
            else
                z = int.Parse(ComDlit.Text);
            Stata.Text = "Дата рождения:\n" + SelDRCom.Text + "\nДлительность прогноза: " + prog + "\n Период с " + SelDRCom.Text + " по " + DateTime.Today.ToString("D");
            DateTime a = DateTime.Parse(SelDRCom.Text);  //перевод выбранной даты в datetime
            DateTime b = DateTime.Parse(DateTime.Today.ToString()); //перевод даты на сегодня в datetime
            DateTime c = DateTime.Parse(DO.Text);
            
            zz = Convert.ToInt32((b - c).TotalDays); //Дата отчета
            z += zz;
            t = (b - a).TotalDays;//количество дней с др
            for (int i = zz; i < z; i++)
            {
                t += i;
                B1 = Math.Round(Math.Sin(2 * pi * t / 23) * 100, 2);
                B2 = Math.Round(Math.Sin(2 * pi * t / 28) * 100 ,2);
                B3 = Math.Round(Math.Sin(2 * pi * t / 33) * 100, 2);
                SUM = Math.Round(B1 + B2 + B3);
                DATA = a.AddDays(i);
                result.Add(new BioTable(1, B1, B2, B3, SUM, DATA));
=======
            prog = ComDlit.Text != "" && pvd.IsChecked == false ? ComDlit.Text : ProizvProg.Text; //чтение длительности прогноза
            z = int.Parse(ComDlit.Text);
            z = int.Parse(ProizvProg.Text);
            Stata.Text = "Дата рождения:\n" + SelDRCom.Text + "\nДлительность прогноза: " + prog + "\n Период с " + DO.Text + " по " + DateTime.Today.ToString("D");

            double[] B1 = new double[z]; //состояние биоритмов в %
            double[] B2 = new double[z]; //состояние биоритмов в %
            double[] B3 = new double[z];  //состояние биоритмов в %
            double[] SUM = new double[z]; //Суммарное состояние
            DateTime[] DATA = new DateTime[z];
            int[] ID = new int[z]; //временно
            DateTime a = DateTime.Parse(SelDRCom.Text);  //перевод выбранной даты в datetime
            DateTime b = DateTime.Parse(DateTime.Today.ToString()); //перевод даты на сегодня в datetime
            DateTime c = DateTime.Parse(DO.Text); //Дата отчета
            t = (b - a).TotalDays;//количество дней с др

            for (int i = 0; i < z; i++)
            {
                t += i;
                //Console.WriteLine(t);
                ID[i] = i;
                B1[i] = Math.Round(Math.Sin(2 * pi * t / 23) * 100, 2);
                B2[i] = Math.Round(Math.Sin(2 * pi * t / 28) * 100 ,2);
                B3[i] = Math.Round(Math.Sin(2 * pi * t / 33) * 100, 2);
                SUM[i] = Math.Round(B1[i] + B2[i] + B3[i]);
                DATA[i] = a.AddDays(i);
>>>>>>> parent of ae3b153 (починил)
                //Console.WriteLine($"{B1} {B2} {B3}\n");
            }
            List<BioTable> result = new List<BioTable>(3);
            for (int i = 0; i < z; i++)
            {
                result.Add(new BioTable(1, B1[i], B2[i], B3[i], SUM[i], DATA[i]));
            }
            BioGrid.ItemsSource = result;
        }

        private void Graphic_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

