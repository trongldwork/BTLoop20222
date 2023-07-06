using filereader;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<object> QuestionBoxes { get; } = new ObservableCollection<object>();
        private List<RadioButton> radioButtons = new List<RadioButton>();
        private List<Button> buttons = new List<Button>();
        private string fileName = "Quizz.txt";
        List<Questions> questions = new List<Questions>();
        public EditQuiz(string QuizPath)
        {
            InitializeComponent();
            fileName = QuizPath;
            editTitle.Text = "Editing quiz: " + System.IO.Path.GetFileName(QuizPath).Remove(System.IO.Path.GetFileName(QuizPath).Length - 4);
            FileImp fileImp = new FileImp();
            questions = fileImp.LoadDataFromFile(fileName);
            questNum.Text = "Questions: " + questions.Count;
            totalMark.Text = questions.Count.ToString();
            for (int i = 0; i < questions.Count; i++)
            {
                Grid grid = new Grid()
                {
                    Background = new SolidColorBrush(Color.FromArgb(255, 247, 246, 246)),
                    Name = "Quest",
                    Height = 20,
                    Margin = new Thickness(20, 2, 20, 2)
                };

                Image moveImage = new Image()
                {
                    Source = new BitmapImage(new Uri("../Assets/image/move.png", UriKind.Relative)),
                    Margin = new Thickness(0, 1, 5, 1),
                    HorizontalAlignment = HorizontalAlignment.Left
                };

                TextBlock indexTextBlock = new TextBlock()
                {
                    Text = (i+1).ToString(),
                    Margin = new Thickness(30, 2, 5, 2),
                    TextAlignment = TextAlignment.Center,
                    Background = Brushes.LightGray,
                    Width = 25,
                    HorizontalAlignment = HorizontalAlignment.Left
                };

                Image listImage = new Image()
                {
                    Source = new BitmapImage(new Uri("../Assets/image/list.png", UriKind.Relative)),
                    Margin = new Thickness(60, 1, 5, 1),
                    HorizontalAlignment = HorizontalAlignment.Left
                };

                Image settingsImage = new Image()
                {
                    Source = new BitmapImage(new Uri("../Assets/image/settings.png", UriKind.Relative)),
                    Margin = new Thickness(85, 1, 5, 1),
                    HorizontalAlignment = HorizontalAlignment.Left
                };

                TextBlock textBlock = new TextBlock()
                {
                    Width = 450,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(110, 0, 0, 0),
                    FontSize = 16,
                    FontWeight = FontWeights.DemiBold,
                    TextDecorations = null
                };

                Hyperlink hyperlink = new Hyperlink()
                {
                    Foreground = new SolidColorBrush(Color.FromArgb(255, 51, 51, 51)),
                    FontSize = 16,
                    FontWeight = FontWeights.DemiBold,
                    TextDecorations = null
                };
                hyperlink.Inlines.Add(questions[i].Quest);
                textBlock.Inlines.Add(hyperlink);

                Image searchImage = new Image()
                {
                    Source = new BitmapImage(new Uri("../Assets/image/search.png", UriKind.Relative)),
                    Margin = new Thickness(5, 1, 100, 1),
                    HorizontalAlignment = HorizontalAlignment.Right
                };

                Image binImage = new Image()
                {
                    Source = new BitmapImage(new Uri("../Assets/image/bin.png", UriKind.Relative)),
                    Margin = new Thickness(5, 1, 70, 1),
                    HorizontalAlignment = HorizontalAlignment.Right
                };

                Grid settingsGrid = new Grid()
                {
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Margin = new Thickness(10, 1, 10, 1)
                };

                TextBox textBox = new TextBox()
                {
                    Width = 50,
                    Text = "1.0"
                };

                Image settingsImage2 = new Image()
                {
                    Source = new BitmapImage(new Uri("../Assets/image/settings.png", UriKind.Relative)),
                    Margin = new Thickness(0),
                    HorizontalAlignment = HorizontalAlignment.Right
                };

                settingsGrid.Children.Add(textBox);
                settingsGrid.Children.Add(settingsImage2);

                grid.Children.Add(moveImage);
                grid.Children.Add(indexTextBlock);
                grid.Children.Add(listImage);
                grid.Children.Add(settingsImage);
                grid.Children.Add(textBlock);
                grid.Children.Add(searchImage);
                grid.Children.Add(binImage);
                grid.Children.Add(settingsGrid);
                quesContainer.Children.Add(grid);
            }
        }
        private void AddQuestionToContainer()
        {

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
                mainWindow.Iborder_menu.Content = new Test_Preview(fileName);
            }
        }
    }
}
