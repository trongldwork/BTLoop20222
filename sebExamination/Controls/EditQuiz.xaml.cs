﻿using filereader;
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
                    Background = new SolidColorBrush(Color.FromRgb(247, 246, 246)),
                    Name = "Quest",
                    Height = 20,
                    Margin = new Thickness(20, 2, 20, 2)
                };

                Image image1 = new Image()
                {
                    Source = new BitmapImage(new Uri("../Assets/image/move.png", UriKind.Relative)),
                    Margin = new Thickness(0, 1, 5, 1),
                    HorizontalAlignment = HorizontalAlignment.Left
                };

                TextBlock textBlock1 = new TextBlock()
                {
                    Text =( i+1).ToString(),
                    Margin = new Thickness(30, 2, 5, 2),
                    TextAlignment = TextAlignment.Center,
                    Background = Brushes.LightGray,
                    Width = 25,
                    HorizontalAlignment = HorizontalAlignment.Left
                };

                Image image2 = new Image()
                {
                    Source = new BitmapImage(new Uri("../Assets/image/list.png", UriKind.Relative)),
                    Margin = new Thickness(60, 1, 5, 1),
                    HorizontalAlignment = HorizontalAlignment.Left
                };

                Image image3 = new Image()
                {
                    Source = new BitmapImage(new Uri("../Assets/image/settings.png", UriKind.Relative)),
                    Margin = new Thickness(85, 1, 5, 1),
                    HorizontalAlignment = HorizontalAlignment.Left
                };

                TextBlock textBlock2 = new TextBlock()
                {
                    Text = questions[i].Quest,
                    Width = 450,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(110, 0, 0, 0)
                };

                Hyperlink hyperlink = new Hyperlink()
                {
                    Foreground = new SolidColorBrush(Color.FromArgb(51, 51, 51, 1)),
                    FontSize = 16,
                    FontWeight = FontWeights.Bold,
                    TextDecorations = null
                };
                hyperlink.Inlines.Add(textBlock2.Text);

                TextBlock textBlock3 = new TextBlock()
                {
                    Width = 50
                };

                Image image4 = new Image()
                {
                    Source = new BitmapImage(new Uri("../Assets/image/settings.png", UriKind.Relative)),
                    Margin = new Thickness(0),
                    HorizontalAlignment = HorizontalAlignment.Right
                };

                grid.Children.Add(image1);
                grid.Children.Add(textBlock1);
                grid.Children.Add(image2);
                grid.Children.Add(image3);
                grid.Children.Add(textBlock2);
                grid.Children.Add(image4);
                Grid.SetColumn(textBlock3, 1);
                Grid.SetColumn(image4, 1);
                Grid.SetRow(image4, 0);
                Grid.SetRow(textBlock3, 0);
                grid.Children.Add(textBlock3);
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
