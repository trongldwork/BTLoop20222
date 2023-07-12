using filereader;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfAnimatedGif;

namespace sebExamination.Controls
{
    /// <summary>
    /// Interaction logic for Quiz.xaml
    /// </summary>
    public partial class Quiz : UserControl
    {
        public ObservableCollection<object> QuestionBoxes { get; } = new ObservableCollection<object>();
        private List<RadioButton> radioButtons = new List<RadioButton>();
        private List<Button> buttons = new List<Button>();
        private string fileName = "Quizz.txt";
        List<Questions> questions = new List<Questions>();
        FileImp fileImp = new FileImp();
        private DispatcherTimer timer;      //DispatcherTimer để đếm ngược thời gian
        private TimeSpan remainingTime;     // Biến lưu trữ thời gian còn lại
        
        string startTime, endTime;
        public Quiz(string quizPath)
        {
            InitializeComponent();
            DateTime now = DateTime.Now;
            startTime = now.ToString();
            fileName = quizPath;
            questions = fileImp.LoadDataFromFile(fileName);
            DataContext = this;
            for (int i = 0; i < questions.Count; i++)
            {
                AddQuestionToQuiz();
            }

            CreateButtons();

            //Thời gian
            string filePath = quizPath;

            try
            {
                // Đọc dữ liệu từ file txt
                string[] lines = File.ReadAllLines(filePath);

                // Tìm dòng chứa thông tin về thời gian
                string timeLine = Array.Find(lines, line => line.StartsWith("Time"));       //Tìm dòng chứa thông tin về thời gian ( bắt đầu bằng từ Time )

                if (!string.IsNullOrEmpty(timeLine))
                {
                    // Trích xuất giá trị thời gian từ dòng
                    int timeInSeconds;
                    if (int.TryParse(timeLine.Split(' ')[1], out timeInSeconds) && timeInSeconds != 0)
                    {
                        // Khởi tạo đối tượng Timer với khoảng thời gian cập nhật là 1 giây
                        timer = new DispatcherTimer();
                        timer.Interval = TimeSpan.FromSeconds(1);
                        timer.Tick += Timer_Tick;

                        // Khởi tạo biến remainingTime với giá trị ban đầu từ file txt
                        remainingTime = TimeSpan.FromSeconds(timeInSeconds);

                        // Cập nhật giá trị của TextBlock để hiển thị thời gian ban đầu
                        timerText.Text = remainingTime.ToString(@"mm\:ss");

                        // Bắt đầu đồng hồ đếm ngược
                        timer.Start();
                    }
                }
                else
                {
                    MessageBox.Show("Time information not found in the file.");
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error reading the file: " + ex.Message);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Giảm biến remainingTime xuống 1 giây
            remainingTime = remainingTime.Subtract(TimeSpan.FromSeconds(1));

            // Kiểm tra xem thời gian đã hết chưa
            if (remainingTime <= TimeSpan.Zero)
            {
                // Dừng đồng hồ đếm ngược
                timer.Stop();
                // Gọi sự kiện Submit_Click
                Submit_Click(null, null);
            }
            else
            {
                // Cập nhật giá trị của TextBlock để hiển thị thời gian còn lại
                timerText.Text = remainingTime.ToString(@"mm\:ss");
            }
        }
        private int QuizzTime = 1200;
        private int QuestionNumber = 0;
        private double point = 2.0;


        private void AddQuestionToQuiz()
        {
            QuestionNumber++;
            Grid mainGrid = new Grid();

            mainGrid.Name = $"Question_{QuestionNumber}";

            Border border = new Border()
            {
                Background = new SolidColorBrush(Color.FromRgb(248, 249, 250)),
                Height = 200,
                Width = 120,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(20),
                BorderBrush = Brushes.Gray,
                BorderThickness = new Thickness(0.5)
            };

            StackPanel stackPanel = new StackPanel()
            {
                Orientation = Orientation.Vertical
            };

            TextBlock questionTextBlock = new TextBlock()
            {
                Foreground = new SolidColorBrush(Color.FromRgb(192, 36, 36)),
                FontFamily = new FontFamily("Cambria"),
                FontWeight = FontWeights.Medium,
                FontSize = 20,
                Margin = new Thickness(5),
                Text = $"Question {QuestionNumber}"
            };

            TextBlock notAnsweredTextBlock = new TextBlock()
            {
                TextWrapping = TextWrapping.Wrap,
                FontSize = 16,
                Margin = new Thickness(5),
                Text = "Not yet answered"
            };

            TextBlock markedOutOfTextBlock = new TextBlock()
            {
                TextWrapping = TextWrapping.Wrap,
                FontSize = 16,
                Margin = new Thickness(5),
                Text = $"Marked out of {questions[QuestionNumber - 1].Mark}"
            };

            TextBlock flagTextBlock = new TextBlock()
            {
                TextWrapping = TextWrapping.Wrap,
                FontSize = 12,
                Margin = new Thickness(5)
            };

            Image flagImage = new Image()
            {
                Source = new BitmapImage(new Uri("/flag.png", UriKind.Relative)),
                Height = 12
            };

            RadioButton flag = new RadioButton()
            {
                Foreground = Brushes.Black,
                Content = ("Flag question"),
                Name = $"Question{QuestionNumber}_Flag"
            };

            flag.Checked += Flag_Checked;
            flag.PreviewMouseDown += Flag_PreviewMouseDown;


            flagTextBlock.Inlines.Add(flagImage);
            flagTextBlock.Inlines.Add(flag);

            stackPanel.Children.Add(questionTextBlock);
            stackPanel.Children.Add(notAnsweredTextBlock);
            stackPanel.Children.Add(markedOutOfTextBlock);
            stackPanel.Children.Add(flagTextBlock);

            border.Child = stackPanel;

            StackPanel contentStackPanel = new StackPanel()
            {
                Background = new SolidColorBrush(Color.FromRgb(231, 243, 245)),
                MinHeight = 200,
                Margin = new Thickness(160, 20, 20, 0)
            };

            TextBlock Question = new TextBlock()
            {
                Text = fileImp.SplitStringByImage(questions[QuestionNumber - 1].Quest).Item1 ,

                //Text = a,
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(10),
                FontSize = 18
            };

            StackPanel radioButtonStackPanel = new StackPanel()
            {
                Margin = new Thickness(10)
            };

            TextBlock[] tex = new TextBlock[questions[QuestionNumber - 1].Ans.Count];

            RadioButton[] Answer = new RadioButton[questions[QuestionNumber - 1].Ans.Count];
            for (int i = 0; i < questions[QuestionNumber - 1].Ans.Count; i++)
            {
                Answer[i] = new RadioButton();
                Answer[i].Margin = new Thickness(5);
                Answer[i].Name = $"Question{QuestionNumber}_Answer{i}";
                tex[i] = new TextBlock();
                tex[i].Text = fileImp.SplitStringByImage(questions[QuestionNumber - 1].Ans[i]).Item1; 
                tex[i].TextWrapping = TextWrapping.Wrap;
                Answer[i].Content = tex[i];
                radioButtons.Add(Answer[i]); // Thêm RadioButton vào danh 
                Answer[i].Checked += RadioButton_Checked;
                radioButtonStackPanel.Children.Add(Answer[i]);
                string ImgPathAns = fileImp.SplitStringByImage(questions[QuestionNumber - 1].Ans[i]).Item2;
                if (ImgPathAns != string.Empty)
                {
                    Image QuesImg = new Image()
                    {
                        MaxHeight = 200,
                        MaxWidth = 900,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Source = new BitmapImage(new Uri(ImgPathAns, UriKind.Absolute))
                    };
                    radioButtonStackPanel.Children.Add(QuesImg);
                }

            }
            //Answer[0].Margin = new Thickness(5);
            //Answer[0].Name = $"Question{QuestionNumber}_Answer0";
            //tmp0.Text = questions[QuestionNumber - 1].Ans[1];
            //Answer[0].Content = tmp0;
            //radioButtons.Add(Answer[0]); // Thêm RadioButton vào danh 

            //Answer[0].Checked += RadioButton_Checked; // Gán sự kiện Checked cho RadioButton
            //Answer[1].Checked += RadioButton_Checked;
            //Answer[2].Checked += RadioButton_Checked;
            //Answer[3].Checked += RadioButton_Checked;

            if (radioButtonStackPanel.Children.Count > 0)
            {

            }

            contentStackPanel.Children.Add(Question);
            string imgpath = fileImp.SplitStringByImage(questions[QuestionNumber - 1].Quest).Item2;
            if (imgpath != string.Empty)
            {
                if (imgpath.Substring(imgpath.Length - 4) == "gif\n")
                {
                    Image QuesImg = new Image()
                    {
                        MaxHeight = 400,
                        MaxWidth = 900,
                        HorizontalAlignment = HorizontalAlignment.Left,
                    };
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.UriSource = new Uri(imgpath, UriKind.Absolute);
                    image.EndInit();
                    ImageBehavior.SetAnimatedSource(QuesImg, image);

                    // Below it needed to start animation. If not, it is only make visible but animation does not start.
                    ImageBehavior.SetAutoStart(QuesImg, true);
                    ImageBehavior.SetRepeatBehavior(QuesImg, RepeatBehavior.Forever);
                    contentStackPanel.Children.Add(QuesImg);
                }
                else if (imgpath.Substring(imgpath.Length - 4) == "mp4\n" || imgpath.Substring(imgpath.Length - 4) == "avi\n")
                {
                    MediaElement mediaElement = new MediaElement();
                    mediaElement.LoadedBehavior = MediaState.Manual;
                    mediaElement.Source = new Uri(imgpath, UriKind.Absolute);
                    mediaElement.Visibility = Visibility.Visible;
                    mediaElement.MediaEnded += Video_ended;
                    mediaElement.Volume = 0;
                    mediaElement.MaxHeight = 500;
                    contentStackPanel.Children.Add(mediaElement);
                    mediaElement.Play();
                }
                else
                {
                    Image QuesImg = new Image()
                    {
                        MaxHeight = 400,
                        MaxWidth = 900,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Source = new BitmapImage(new Uri(imgpath, UriKind.Absolute))
                    };
                    contentStackPanel.Children.Add(QuesImg);
                }
                
            }
            //radioButtonStackPanel.Children.Add(Answer[0]);
            //radioButtonStackPanel.Children.Add(Answer[1]);
            //radioButtonStackPanel.Children.Add(Answer[2]);
            //radioButtonStackPanel.Children.Add(Answer[3]);
            contentStackPanel.Children.Add(radioButtonStackPanel);

            mainGrid.Children.Add(border);
            mainGrid.Children.Add(contentStackPanel);
            QuestionBoxes.Add(mainGrid);
            Name = "box" + QuestionNumber;
        }

        private void CreateButtons()
        {
            int buttonCount = QuestionNumber;
            int columnCount = 8;

            for (int i = 1; i <= buttonCount; i++)
            {
                Button button = new Button
                {
                    VerticalContentAlignment = VerticalAlignment.Top,
                    Content = $"{i}",
                    Name = $"button{i}",
                    Margin = new Thickness(5),
                };

                button.Click += Button_Click; // Gán sự kiện Click cho Button
                buttons.Add(button); // Thêm Button vào danh sách

                int row = (i - 1) / columnCount;
                int column = (i - 1) % columnCount;

                if (i % 8 == 1)
                {
                    RowDefinition newRow = new RowDefinition();
                    newRow.Height = new GridLength(50, GridUnitType.Pixel);

                    gridContainer.RowDefinitions.Add(newRow);
                }

                gridContainer.Children.Add(button);
                Grid.SetRow(button, row);
                Grid.SetColumn(button, column);
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            string radioButtonName = radioButton.Name;

            // Tìm vị trí của dấu "_" trong tên RadioButton
            int underscoreIndex = radioButtonName.IndexOf('_');
            if (underscoreIndex != -1)
            {
                // Lấy số thứ tự từ tên RadioButton
                string questionNumberStr = radioButtonName.Substring(8, underscoreIndex - 8);
                int questionNumber = int.Parse(questionNumberStr);

                // Tìm Button tương ứng trong danh sách
                Button button = buttons.Find(btn => btn.Name == $"button{questionNumber}");

                // Thay đổi màu nền của Button thành màu vàng
                button.Background = Brushes.DarkGray;
            }
        }

        private void Flag_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            RadioButton flag = (RadioButton)sender;
            string flagName = flag.Name;
            // Tìm vị trí của dấu "_" trong tên RadioButton
            int underscoreIndex = flagName.IndexOf('_');
            if (underscoreIndex != -1)
            {
                // Lấy số thứ tự từ tên RadioButton
                string questionNumberStr = flagName.Substring(8, underscoreIndex - 8);
                int questionNumber = int.Parse(questionNumberStr);

                // Tìm Button tương ứng trong danh sách
                Button button = buttons.Find(btn => btn.Name == $"button{questionNumber}");

                // Thay đổi màu nền của Button thành màu vàng
                if (flag.IsChecked == false)
                {
                    flag.IsChecked = true;
                    // Tạo hình tam giác vuông đỏ
                    Grid grid = new Grid();
                    grid.Width = 25;
                    Polygon triangle = new Polygon()
                    {
                        Fill = Brushes.Red,
                        Points = new PointCollection()
                        {
                            new Point(0, 0),
                            new Point(15, 0),
                            new Point(0, 15)
                        }
                    };
                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = $"{questionNumber}";
                    textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                    grid.Children.Add(triangle);
                    grid.Children.Add((TextBlock)textBlock);
                    // Thêm tam giác vào Grid trong Button
                    button.Content = grid;
                    button.HorizontalContentAlignment = HorizontalAlignment.Left;
                    e.Handled = true;
                }
                else
                {
                    // Xóa nội dung của Button
                    flag.IsChecked = false;
                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = $"{questionNumber}";
                    button.HorizontalContentAlignment = HorizontalAlignment.Center;
                    button.Content = textBlock;
                    e.Handled = true; // Prevent the click event from further handling
                }
            }
        }

        private void Flag_Checked(object sender, RoutedEventArgs e)
        {

            RadioButton flag = (RadioButton)sender;
            string flagName = flag.Name;
            // Tìm vị trí của dấu "_" trong tên RadioButton
            int underscoreIndex = flagName.IndexOf('_');
            if (underscoreIndex != -1)
            {
                // Lấy số thứ tự từ tên RadioButton
                string questionNumberStr = flagName.Substring(8, underscoreIndex - 8);
                int questionNumber = int.Parse(questionNumberStr);

                // Tìm Button tương ứng trong danh sách
                Button button = buttons.Find(btn => btn.Name == $"button{questionNumber}");

                // Thay đổi màu nền của Button thành màu vàng
                if (flag.IsChecked == true)
                {
                    // Tạo hình tam giác vuông đỏ
                    Grid grid = new Grid();
                    grid.Width = button.Width;
                    Polygon triangle = new Polygon()
                    {
                        Fill = Brushes.Red,
                        Points = new PointCollection()
                        {
                            new Point(0, 0),
                            new Point(15, 0),
                            new Point(0, 15)
                        }
                    };
                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = $"{questionNumber}";
                    textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                    grid.Children.Add(triangle);
                    grid.Children.Add((TextBlock)textBlock);
                    // Thêm tam giác vào Grid trong Button
                    button.Content = grid;
                    button.HorizontalContentAlignment = HorizontalAlignment.Left;
                }
                else
                {
                    // Xóa nội dung của Button
                    button.Content = null;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string buttonName = button.Name;

            // Tìm vị trí của dấu "_" trong tên Button
            int underscoreIndex = buttonName.IndexOf('_');
            if (underscoreIndex != -1)
            {
                // Lấy số thứ tự từ tên Button
                string questionNumberStr = buttonName.Substring(6, underscoreIndex - 6);
                int questionNumber = int.Parse(questionNumberStr);

                // Tìm RadioButton tương ứng trong danh sách
                RadioButton radioButton = radioButtons.Find(rb => rb.Name == $"Question{questionNumber}_RadioButton");

                // Kiểm tra và đánh dấu RadioButton đã được chọn
                if (radioButton != null)
                    radioButton.IsChecked = true;
            }
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            DateTime now = DateTime.Now;
            endTime = now.ToString();
            int correctAnswerCount = 0;
            int[] temp;
            temp = new int[300];
            if (timer != null) timer.Stop();
            foreach (var question in QuestionBoxes)
            {
                Grid questionGrid = (Grid)question;

                // Lấy số thứ tự câu hỏi từ tên Grid
                int questionNumber = int.Parse(questionGrid.Name.Substring(9));

                string a = questions[questionNumber - 1].Answer;
                
                char b = a[8];
                temp[questionNumber - 1] = (int)b - 65;

                // Tìm RadioButton tương ứng với câu hỏi
                RadioButton selectedRadioButton = radioButtons.Find(rb => rb.Name == $"Question{questionNumber}_Answer{temp[questionNumber - 1]}");
                
                // Kiểm tra xem RadioButton được chọn có khớp với đáp án đúng hay không
                if (selectedRadioButton.IsChecked == true)
                {
                    correctAnswerCount++;
                    questionGrid.Children.OfType<StackPanel>().FirstOrDefault()?.SetValue(BackgroundProperty, new SolidColorBrush(Color.FromRgb(201, 250, 183)));
                }
                else
                {
                    questionGrid.Children.OfType<StackPanel>().FirstOrDefault()?.SetValue(BackgroundProperty, new SolidColorBrush(Color.FromRgb(250, 175, 175)));
                }
                Grid grid = new Grid()
                {
                    Height = 35,
                    Margin = new Thickness(10),
                    Background = new SolidColorBrush(Color.FromRgb(252, 239, 220))
                };

                TextBlock textBlock = new TextBlock()
                {
                    Foreground = new SolidColorBrush(Color.FromRgb(154, 111, 67)),
                    Margin = new Thickness(10),
                    Text = "The correct answer is: " + fileImp.SplitStringByImage(questions[questionNumber - 1].Ans[temp[questionNumber - 1]]).Item1,

                };

                grid.Children.Add(textBlock);
                questionGrid.Children.OfType<StackPanel>().FirstOrDefault()?.Children.Add(grid);
            }

            //update bảng kết quả

            Grid grid1 = ResultTable;

            AddTextBlock(grid1, 0, 1, "#F7F7F7", startTime);
            AddTextBlock(grid1, 1, 1, "#FAFAFA", "Finished");
            AddTextBlock(grid1, 2, 1, "#F7F7F7", endTime);
            AddTextBlock(grid1, 3, 1, "#FAFAFA", (DateTime.Parse(startTime) - DateTime.Parse(endTime)).ToString(@"hh\:mm\:ss"));
            AddTextBlock(grid1, 4, 1, "#F7F7F7", correctAnswerCount.ToString() +"/" +(QuestionNumber).ToString());
            AddTextBlock(grid1, 5, 1, "#FAFAFA", ((double)correctAnswerCount / (double)(QuestionNumber) *10).ToString("F2"));
            ResultTable.Visibility = Visibility.Visible;

            //update finish review

            Submit_btn.Visibility = Visibility.Collapsed;

            TextBlock text = new TextBlock()
            {
                Margin = new Thickness(20),
            };

            Hyperlink hyperlink = new Hyperlink()
            {
                FontSize = 18,
                Foreground = Brushes.Gray,
                TextDecorations = null
                
            };

            hyperlink.Inlines.Add("Finish review");
            hyperlink.Click += finishReview_Click;

            text.Inlines.Add(hyperlink);

            map.Children.Insert(1, text);
        }

        private void AddTextBlock(Grid grid, int row, int column, string background, string text)
        {
            TextBlock textBlock = new TextBlock()
            {
                Foreground = new SolidColorBrush(Colors.DarkGray),
                Margin = new Thickness(5, 0, 0, 0),
                Text = text
            };

            

            Grid backgroundGrid = new Grid()
            {
                Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(background))
            };
            backgroundGrid.SetValue(Grid.RowProperty, row);
            backgroundGrid.SetValue(Grid.ColumnProperty, column);

            grid.Children.Add(backgroundGrid);
            grid.Children.Add(textBlock);
            Grid.SetRow(textBlock, row);
            Grid.SetColumn(textBlock, column);
        }

        private void Video_ended(object sender, EventArgs e)
        {
            MediaElement mediaElement = (MediaElement)sender;
            mediaElement.Position = TimeSpan.FromSeconds(0);
            mediaElement.Play();
        }
        private void finishReview_Click(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                mainWindow.AddToMap(new Course_list(), "My course", 0);
                // Truy cập đến thành phần có x:name="Iborder_menu" trong MainWindow và thay đổi giá trị
                mainWindow.Iborder_menu.Content = new Course_list();
                mainWindow.editBtn.Visibility = Visibility.Visible;
            }
        }
    }
}