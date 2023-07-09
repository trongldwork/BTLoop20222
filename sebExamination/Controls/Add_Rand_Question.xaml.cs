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
        FileImp fileImp = new FileImp();
        List<Questions> questions = new List<Questions>();
        int numberOfQues = 0;
        public Add_Rand_Question(string path)
        {
            fileName = path;
            InitializeComponent();
            create_category_parent_ComboBox();
            for (int i = 1; i <= 50; i++)
            {
                Number_of_Rand_Ques_cb.Items.Add(i.ToString());
            }
        }
        private void create_category_parent_ComboBox()
        {
            // Tạo đường dẫn đến thư mục "Categories"
            string currentDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.FullName;
            string categoriesPath = System.IO.Path.Combine(projectDirectory, "Categories");

            // Tạo ComboBox và thêm tên thư mục vào nó

            ComboBox comboBox = category_parent;
            comboBox.Items.Add("default");
            comboBox.Height = 25;
            comboBox.Width = 200;
            comboBox.HorizontalAlignment = HorizontalAlignment.Left;
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
        private int countLength(string str)
        {
            char tmp = '(';
            int position = str.IndexOf(tmp, str.Length - 6);
            return 1 + str.Length - position;
        }
        private void changeCategory(object sender, EventArgs e)
        {
            num = 0;

            StackPanel questionContainer = (StackPanel)FindName("QuestionContainer");
            if (questionContainer != null)
            {
                questionContainer.Children.Clear();
            }
            string folderPath = GetFilePathFrombox();
            List<Grid> grids = Read_Category(folderPath);
            foreach (Grid grid in grids)
            {
                questionContainer.Children.Add(grid);
            }
            if (Show_subcate.IsChecked == true) { Show_subcate_Checked(sender, null); }
            
            
        }

        public string GetFilePathFrombox()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.FullName;
            string categoriesPath = System.IO.Path.Combine(projectDirectory, "Categories");
            string filePath = "";

            if (category_parent.SelectedIndex != 0)
            {
                int index = category_parent.SelectedIndex;
                List<string> parent = new List<string>();
                parent.Add(category_parent.Items[index].ToString());
                int k = countLevel(parent[0]) - 1;

                int n = countLevel(parent[0]);
                while (parent[0][0] == ' ')
                {
                    parent[0] = parent[0].Substring(1);
                }
                parent[0] = parent[0].Substring(0, parent[0].Length - countLength(parent[0]));

                for (int i = index; i > 0; i--)
                {
                    if (countLevel(category_parent.Items[i].ToString()) == k)
                    {
                        parent.Add(category_parent.Items[i].ToString());
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
            return filePath;
        }
        /// <summary>
        /// đọc categories thành một list chứa các grid câu hỏi từ path (vị trí file chứa câu hỏi)
        /// </summary>
        /// <param name="path"></param>
        int num = 0;
        public List<Grid> Read_Category(string path)
        {
            List<Grid> tmpGrid = new List<Grid>();
            FileImp fileImp = new FileImp();
            List<Questions> tmp = new List<Questions>();

            tmp = fileImp.LoadDataFromFile(path);
            questions.AddRange(tmp);
            numberOfQues = tmp.Count;
            for (int i = 0; i < numberOfQues; i++)
            {
                Grid grid = new Grid()
                {
                    Height = 20,
                    Background = Brushes.White
                };

                Grid innerGrid = new Grid() 
                {
                    Margin = new Thickness(15, 0, 0, 0)
                };
                Image imageList = new Image()
                {
                    Source = new BitmapImage(new Uri("../Assets/image/list.png", UriKind.Relative)),
                    Height = 18,
                    HorizontalAlignment = HorizontalAlignment.Left
                };
                innerGrid.Children.Add(imageList);

                TextBlock textBlock = new TextBlock()
                {
                    Margin = new Thickness(25, 0, 30, 0),
                    Text = questions[num++].Quest,
                    Foreground = Brushes.DimGray,
                    FontWeight = FontWeights.Bold
                };
                innerGrid.Children.Add(textBlock);

                grid.Children.Add(innerGrid);

                Image imageSearch = new Image()
                {
                    Source = new BitmapImage(new Uri("../Assets/image/search.png", UriKind.Relative)),
                    Height = 18,
                    HorizontalAlignment = HorizontalAlignment.Right
                };
                grid.Children.Add(imageSearch);
                //QuestionContainer.Children.Add(grid);
                tmpGrid.Add(grid);
            }
            return tmpGrid;
        }
        /// <summary>
        /// hàm đệ quy trả về list các đường dẫn thư mục con của folderPath
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        public static List<string> GetAllSubdirectories(string folderPath)
        {
            List<string> subdirectories = new List<string>();

            try
            {
                // Lấy tất cả các thư mục con trong thư mục hiện tại
                string[] directories = Directory.GetDirectories(folderPath);

                // Đệ quy lấy thư mục con của từng thư mục con
                foreach (string directory in directories)
                {
                    subdirectories.Add(directory);
                    subdirectories.AddRange(GetAllSubdirectories(directory));
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
            }

            return subdirectories;
        }
        private void Show_subcate_Checked(object sender, RoutedEventArgs e)
        {
            if (Show_subcate.IsChecked == true)
            {
                string filePath = GetFilePathFrombox();
                string folderPath = System.IO.Path.GetDirectoryName(filePath);
                List<string> subfolders = GetAllSubdirectories(folderPath);
                foreach (string subfolder in subfolders)
                {
                    string folderName = System.IO.Path.GetFileName(subfolder);
                    string _filepath = subfolder + "\\" + folderName + ".txt";
                    List<Grid> grids = Read_Category(_filepath);
                    foreach (Grid grid in grids)
                    {
                        QuestionContainer.Children.Add(grid);
                    }
                }
            }
            if (Show_subcate.IsChecked == false)
            {
                GetFilePathFrombox();
                changeCategory(null, null);
            }
        }

        private void AddQuestion_btn_Click(object sender, RoutedEventArgs e)
        {
            if(Number_of_Rand_Ques_cb.SelectedIndex != 0)
            {
                Random random = new Random();
                List<Questions> temp = new List<Questions>();
                List<int> randomNumbers = new List<int>();

                while (randomNumbers.Count < Number_of_Rand_Ques_cb.SelectedIndex)
                {
                    int randomNumber = random.Next(questions.Count+1);
                    if (!randomNumbers.Contains(randomNumber))
                    {
                        randomNumbers.Add(randomNumber);
                    }
                }
                for (int i = 0; i < randomNumbers.Count; i++)
                {
                    temp.Add(questions[randomNumbers[i]]);
                }
                fileImp.SaveDataToFile(fileName, temp);
                if (Window.GetWindow(this) is MainWindow mainWindow)
                {
                    // Truy cập đến thành phần có x:name="Iborder_menu" trong MainWindow và thay đổi giá trị
                    mainWindow.Iborder_menu.Content = new EditQuiz(fileName);
                }
            }
            
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
