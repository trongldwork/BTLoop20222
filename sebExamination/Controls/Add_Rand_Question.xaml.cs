using filereader;
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
    /// Interaction logic for Add_Rand_Question.xaml
    /// </summary>
    public partial class Add_Rand_Question : UserControl
    {
        private string fileName = "";
        List<CheckBox> checkBoxes = new List<CheckBox>();
        List<Questions> questions = new List<Questions>();
        int numberOfQues = 0;
        public Add_Rand_Question(string path)
        {
            fileName = path;
            InitializeComponent();
            Add_Ques_Category_ComboBox();
            //Number_of_Rand_Ques_ComboBox();


        }
        private void Add_Ques_Category_ComboBox()
        {
            // Tạo đường dẫn đến thư mục "Categories"
            string currentDirectory = Directory.GetCurrentDirectory();

            string projectDirectory = Directory.GetParent(currentDirectory).Parent.FullName;

            string categoriesPath = System.IO.Path.Combine(projectDirectory, "Categories");

            // Tạo ComboBox và thêm tên thư mục vào nó

            ComboBox comboBox = Add_Ques_Category;
            comboBox.Items.Add("default");
            comboBox.Height = 25;
            comboBox.Width = 200;
            comboBox.HorizontalAlignment = HorizontalAlignment.Center;
            comboBox.SelectedIndex = 0;
            comboBox.Background = Brushes.Transparent;
            comboBox.FontSize = 12;
            comboBox.SelectionChanged += changeCategory;

            // Gọi hàm để lấy tất cả các thư mục trong "Categories" và thư mục con bên trong chúng
            GetAllFolders(categoriesPath, comboBox);

        }

        int elevator = 0;
        private void GetAllFolders(string path, ComboBox comboBox)
        {
            try
            {
                // Lấy danh sách tất cả các thư mục trong đường dẫn cụ thể
                string[] folders = Directory.GetDirectories(path);

                // Duyệt qua từng thư mục
                foreach (string folder in folders)
                {
                    // Lấy tên thư mục từ đường dẫn
                    string folderName = new DirectoryInfo(folder).Name;
                    for (int i = 0; i < elevator; i++)
                    {
                        folderName = "   " + folderName;
                    }
                    elevator++;

                    string dataPath = Directory.GetParent(folder).FullName;

                    dataPath = System.IO.Path.Combine(dataPath, folder);
                    dataPath = System.IO.Path.Combine(dataPath, "Count.txt");
                    string data = File.ReadAllText(dataPath);
                    // Thêm tên thư mục vào ComboBox
                    comboBox.Items.Add(folderName + " (" + data + ")");

                    // Tiếp tục đệ quy để lấy tất cả các thư mục con bên trong thư mục hiện tại
                    GetAllFolders(folder, comboBox);
                    elevator--;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }
        private int countLevel(string str)
        {
            int res = 0;
            while (str[0] == ' ')
            {
                str = str.Substring(1);
                res++;
            }
            res /= 3;
            return res + 1;
        }
        private void changeCategory(object sender, EventArgs e)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.FullName;
            string categoriesPath = System.IO.Path.Combine(projectDirectory, "Categories");
            string filePath = "";
            // clear các box khi thay đổi categories
            StackPanel Random_Question = (StackPanel)FindName("Random_Question");
            if (Random_Question != null)
            {
                Random_Question.Children.Clear();
            }

            ComboBox Number_of_Rand_Ques_cb = (ComboBox)FindName("Number_of_Rand_Ques_cb");
            if (Number_of_Rand_Ques_cb != null)
            {
                Number_of_Rand_Ques_cb.Items.Clear();
            }
            // tính toán đường dẫn đến thư mục chứa câu hỏi của categories
            if (Add_Ques_Category.SelectedIndex != 0)
            {
                int index = Add_Ques_Category.SelectedIndex;
                List<string> parent = new List<string>();
                parent.Add(Add_Ques_Category.Items[index].ToString());
                int k = countLevel(parent[0]) - 1;

                int n = countLevel(parent[0]);
                while (parent[0][0] == ' ')
                {
                    parent[0] = parent[0].Substring(1);
                }
                parent[0] = parent[0].Substring(0, parent[0].Length - countLength(parent[0]));

                for (int i = index; i > 0; i--)
                {
                    if (countLevel(Add_Ques_Category.Items[i].ToString()) == k)
                    {
                        parent.Add(Add_Ques_Category.Items[i].ToString());
                        while (parent[n - k][0] == ' ')
                        {

                            parent[n - k] = parent[n - k].Substring(1);
                        }
                        parent[n - k] = parent[n - k].Substring(0, parent[n - k].Length - countLength(parent[n - k]));
                        k--;
                    }
                }

                for (int i = n - 1; i >= 0; i--)
                {
                    categoriesPath = System.IO.Path.Combine(categoriesPath, parent[i]);
                }
                filePath = System.IO.Path.Combine(categoriesPath, parent[0] + ".txt");

            }
            FileImp fileImp = new FileImp();
            questions = new List<Questions>();

            questions = fileImp.LoadDataFromFile(filePath);
            numberOfQues = questions.Count;
            for (int i = 0; i < numberOfQues; i++)
            {
                Grid grid = new Grid()
                {
                    Height = 40,
                    Background = Brushes.White
                };


                TextBlock textblock = new TextBlock()
                {
                    Name = $"ques{i}",
                    Margin = new Thickness(20, 2, 0, 0),
                    Foreground = Brushes.DarkGray

                };

                Grid innerGrid = new Grid();
                Image imageList = new Image()
                {
                    Source = new BitmapImage(new Uri("../Assets/image/list-black.png", UriKind.Relative)),
                    Height = 22,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(20, 0, 0, 0),

                };
                innerGrid.Children.Add(imageList);

                TextBlock textBlock = new TextBlock()
                {
                    Margin = new Thickness(60, 0, 0, 0),
                    Text = questions[i].Quest,
                    FontFamily = new FontFamily("Times New Roman"),
                    FontSize = 18,
                    VerticalAlignment = VerticalAlignment.Top,
                };
                innerGrid.Children.Add(textBlock);

                grid.Children.Add(innerGrid);
                Random_Question.Children.Add(grid);


            }

            for (int j = 1; j <= numberOfQues; j++)
            {
                Number_of_Rand_Ques_cb.Items.Add(j);
            }
        }

        private int countLength(string str)
        {
            char tmp = '(';
            int position = str.IndexOf(tmp, str.Length - 6);
            return 1 + str.Length - position;
        }
        private void close(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                // Truy cập đến thành phần có x:name="Iborder_menu" trong MainWindow và thay đổi giá trị
                mainWindow.Iborder_menu.Content = new EditQuiz(fileName);
            }
        }
    }
}
