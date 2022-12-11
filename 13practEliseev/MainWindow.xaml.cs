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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibMatrix;

namespace _13practEliseev
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void aboutTask1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Дана матрица размера M * N. \n Найти минимальный среди максимальных элементов ее столбцов.");
        }

        private void whoDeveloper_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик Данила Елисеев группа ИСП-31", "хорошего дня :)" );
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void countOfRows_TextChanged(object sender, TextChangedEventArgs e)
        {
            answer.Text = null;
            table.ItemsSource = null;
        }

        Matrix<int> matrix = new Matrix<int>(0,0);
        private void calculateTask1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Matrix<int> matrix = new Matrix<int>(Int32.Parse(amountOfColumns.Text), Int32.Parse(amountOfRow.Text));
                matrix.Init(Int32.Parse(amountOfColumns.Text), Int32.Parse(amountOfRow.Text));
                table.ItemsSource = matrix.ToDataTable().DefaultView;
                answer.Text = "" + matrix.FindIn();

            }
            catch
            {
                MessageBox.Show("Что-то не так, попробуйте еще раз");
            }
        }
        private void btnClearEx1_Click(object sender, RoutedEventArgs e)
        {
            answer.Text = null;
            table.ItemsSource = null;
        }

        private void countOfColumns_TextChanged(object sender, TextChangedEventArgs e)
        {
            answer.Text = null;
            table.ItemsSource = null;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            matrix.Serialize(@".\matriiiiiix.txt");
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            matrix.Deserialize(@".\matriiiiiix.txt");
            table.ItemsSource = matrix.ToDataTable().DefaultView;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LogIn password = new LogIn();
            password.Owner = this;
            password.ShowDialog();
        }

        private void setting_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
