using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for EditQuiz.xaml
    /// </summary>
    public partial class EditQuiz : UserControl
    {
        public EditQuiz()
        {
            InitializeComponent();
        }
        private void Add_Ques_MouseEnter(object sender, MouseEventArgs e)
        {
            ToggleButton toggleButton = (ToggleButton)sender;
            StackPanel stackPanel = (StackPanel)toggleButton.Content;
            System.Windows.Controls.Image image = (System.Windows.Controls.Image)stackPanel.Children[0];
            TextBlock textBlock = (TextBlock)stackPanel.Children[1];

            image.Source = new BitmapImage(new Uri("../Assets/image/white-plus-small.png", UriKind.Relative)); // Đường dẫn đến hình ảnh dấu cộng màu trắng
            textBlock.Foreground = Brushes.WhiteSmoke;
        }

        private void Add_Ques_MouseLeave(object sender, MouseEventArgs e)
        {
            ToggleButton toggleButton = (ToggleButton)sender;
            StackPanel stackPanel = (StackPanel)toggleButton.Content;
            System.Windows.Controls.Image image = (System.Windows.Controls.Image)stackPanel.Children[0];
            TextBlock textBlock = (TextBlock)stackPanel.Children[1];

            image.Source = new BitmapImage(new Uri("../Assets/image/plus-small.png", UriKind.Relative)); // Đường dẫn đến hình ảnh dấu cộng màu xanh
            textBlock.Foreground = Brushes.Black;
        }
        private void Add_QuestionBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Add_Ques_Grid.Visibility == Visibility.Collapsed)
            {
                Add_Ques_Grid.Visibility = Visibility.Visible;
            }
            else
            {
                Add_Ques_Grid.Visibility = Visibility.Collapsed;
            }
        }
        private void settingTestBtn_Click(object sender, RoutedEventArgs e)
        {
            // Truyền giá trị newValue cho MainWindow
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                // Truy cập đến thành phần có x:name="Iborder_menu" trong MainWindow và thay đổi giá trị
                mainWindow.Iborder_menu.Content = new Test_Preview();
            }
        }
    }
}
