using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace proect5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class Triangle
    {
        public double Side1 { get; set; } //свойства для хранения длин сторон 
        public double Side2 { get; set; }
        public double Side3 { get; set; }

        public Triangle(double side1 = 0, double side2 = 0, double side3 = 0)
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }

        public double Perimeter //свойства для вычесления периметра треугольника 
        {
            get { return Side1 + Side2 + Side3; }
        }

        public void SetParams(double side1, double side2, double side3) //метод для установки параметров треугольника 
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }

        public void SetParams(double scaleFactor)
        {
            Side1 *= scaleFactor;
            Side2 *= scaleFactor;
            Side3 *= scaleFactor;
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculatePerimeter(object sender, RoutedEventArgs e)
        {
            // Получение данных из текстовых полей
            if (double.TryParse(side1TextBox.Text, out double side1) &&
              double.TryParse(side2TextBox.Text, out double side2) &&
              double.TryParse(side3TextBox.Text, out double side3))
            {
                // Создание объекта Triangle
                Triangle triangle = new Triangle(side1, side2, side3);

                // Вывод периметра в текстовое поле
                perimeterTextBlock.Text = $"Периметр: {triangle.Perimeter}";
            }
            else
            {
                MessageBox.Show("Некорректный ввод данных. Введите числа.");
            }
        }

        private void ScaleUp(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(side1TextBox.Text, out double side1) &&
              double.TryParse(side2TextBox.Text, out double side2) &&
              double.TryParse(side3TextBox.Text, out double side3))
            {
                Triangle triangle = new Triangle(side1, side2, side3);
                triangle.SetParams(2);

                // Обновление текстовых полей
                side1TextBox.Text = triangle.Side1.ToString();
                side2TextBox.Text = triangle.Side2.ToString();
                side3TextBox.Text = triangle.Side3.ToString();
            }
            else
            {
                MessageBox.Show("Некорректный ввод данных. Введите числа.");
            }
        }
            private void Exit_click(object sender, RoutedEventArgs e)
            {
                Close();
            }
            private void Open_click(object sender, RoutedEventArgs e)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                {
                    // Получаем путь к файлу
                    string filePath = openFileDialog.FileName;

                    // Открываем файл и считываем данные
                    try
                    {

                        MessageBox.Show($"Содержимое файла:");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка открытия файла: {ex.Message}");
                    }
                }
            }

            private void Button_Click_1(object sender, RoutedEventArgs e)

            {
                MessageBox.Show("Орлов Арсений, \n Использовать класс Triangle (треугольник) с полями-сторонами. Разработать\r\nоперацию для определения возможности существование треугольника с заданными \r\nсторонами true/false. Разработать операции для увеличения/уменьшения сторон на \r\n1.  \n ИСП-34", "О программе");
            }
            private void Save_Click(object sender, RoutedEventArgs e)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == true)
                {
                    // Получаем путь к файлу
                    string filePath = saveFileDialog.FileName;

                    // Сохраняем данные в файл 
                    try
                    {


                        MessageBox.Show("Файл успешно сохранен.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка сохранения файла: {ex.Message}");
                    }
                }
            }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(perimeterTextBlock.Text.Substring(10), out double perimeterValue))
            {
                perimeterTextBlock.Text = $"Периметр: {perimeterValue * 2}";
            }
            else
            {
                MessageBox.Show("Некорректное значение периметра.");
            }
        }
    }
    }


            

         
    
