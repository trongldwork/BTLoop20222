using System;
using System.Collections.Generic;
using System.IO;
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

namespace sebExamination.Controls
{
    /// <summary>
    /// Interaction logic for Course_list.xaml
    /// </summary>
    public partial class Course_list : UserControl
    {
        string path = "";
        public Course_list()
        {
            InitializeComponent();
            string currentDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.FullName;
            string quizPath = System.IO.Path.Combine(projectDirectory, "Quiz");
            int fileCount = Directory.GetFiles(quizPath).Length;
            string[] files = Directory.GetFiles(quizPath);

            foreach (string file in files)
            {
                StackPanel stackPanel = new StackPanel()
                {
                    Orientation = Orientation.Horizontal,
                    Height = 50,
                    Margin = new Thickness(20, 100, 0, -80)
                };

                Image image = new Image()
                {
                    Source = new BitmapImage(new Uri("../Assets/image/task.png", UriKind.Relative)),
                    Margin = new Thickness(50, 0, 0, 0),
                    Width = 35,
                    Height = 35
                };
                stackPanel.Children.Add(image);

                Button button = new Button()
                {
                    
                    Content = System.IO.Path.GetFileName(file).ToString().Remove(System.IO.Path.GetFileName(file).ToString().Length - 4),
                    Width = 800,
                    FontSize = 22,
                    Background = Brushes.White,
                    BorderThickness = new Thickness(0),
                    Margin = new Thickness(0, 15, 0, 0),
                    HorizontalContentAlignment = HorizontalAlignment.Left
                };
                button.Click += test1_Checked;
                stackPanel.Children.Add(button);
                QuizContainer.Children.Add(stackPanel);
                grid_uc.Height += 50;

            }
        }
        private void test1_Checked(object sender, RoutedEventArgs e)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.FullName;
            string quizPath = System.IO.Path.Combine(projectDirectory, "Quiz");
            path = System.IO.Path.Combine(quizPath, sender.ToString().Substring(32) + ".txt");
            // Truyền giá trị newValue cho MainWindow
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                mainWindow.AddToMap(new Test_Preview(path), sender.ToString().Substring(32), 1);
                // Truy cập đến thành phần có x:name="Iborder_menu" trong MainWindow và thay đổi giá trị
                mainWindow.editBtn.Visibility = Visibility.Collapsed;
                mainWindow.Iborder_menu.Content = new Test_Preview(path);
            }
        }
    }
}
