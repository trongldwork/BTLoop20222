using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
using System.Xml;

namespace sebExamination.Controls
{
    /// <summary>
    /// Interaction logic for Categories.xaml
    /// </summary>
    public partial class Categories : UserControl
    {
        public Categories()
        {
            InitializeComponent();
            create_category_parent_ComboBox();

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
            comboBox.Margin = new Thickness(5);
            comboBox.HorizontalAlignment = HorizontalAlignment.Left;
            comboBox.SelectedIndex = 0;
            comboBox.Background = Brushes.White;
            comboBox.FontSize = 12;


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
                    for(int i = 0; i<elevator; i++)
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
        string path;

        private int countLevel(string str)
        {
            int res = 0;
            while (str[0] == ' ')
            {
                str = str.Substring(1);
                res++;
            }
            res /= 3;
            return res+1;
        }
        private int countLength(string str)
        {
            char tmp = '(';
            int position = str.IndexOf(tmp, str.Length - 6);
            return 1 + str.Length - position;
        }
        private void addCategoryBtn_Click(object sender, RoutedEventArgs e)
        {
            string categoryName = category_name.Text; // Lấy tên thư mục từ TextBox category_name
            string fileName = categoryName + ".txt";
            string currentDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.FullName;
            string categoriesPath = System.IO.Path.Combine(projectDirectory, "Categories");

            if(category_parent.SelectedIndex != 0)
            {
                int index = category_parent.SelectedIndex;
                List<string> parent = new List<string>();
                parent.Add(category_parent.Items[index].ToString());
                int k = countLevel(parent[0])-1;
                
                int n = countLevel(parent[0]);
                while (parent[0][0] == ' ')
                {
                    parent[0] = parent[0].Substring(1);
                }
                parent[0] = parent[0].Substring(0, parent[0].Length - countLength(parent[0]));
                for (int i = index; i>0; i--)
                {
                    if (countLevel(category_parent.Items[i].ToString()) == k)
                    {
                        parent.Add(category_parent.Items[i].ToString());
                        while (parent[n-k][0] == ' ')
                        {
                            parent[n-k] = parent[n-k].Substring(1);
                        }
                        parent[n-k] = parent[n-k].Substring(0, parent[n-k].Length - countLength(parent[n-k]));
                        k--;
                    }
                }
                for(int i = n-1; i>=0; i--)
                {
                    categoriesPath = System.IO.Path.Combine(categoriesPath, parent[i]);
                }
            }

            string folderPath = System.IO.Path.Combine(categoriesPath, categoryName);
            string filePath = System.IO.Path.Combine(folderPath, fileName);
            string countFile = System.IO.Path.Combine(folderPath, "count.txt");
            
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                    
                }
                string categoryContent = "Category name: " + categoryName + "\nthisline support the file reader to read both quizz file and category file\n";
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(categoryContent);
                }
                // Lấy nội dung từ TextBox
                string fileContent = "0";
                // Tạo và ghi nội dung vào file\
                using (StreamWriter writer = new StreamWriter(countFile))
                {
                    writer.Write(fileContent);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                mainWindow.AddToMap(new Course_list(), "My course", 0);
                // Truy cập đến thành phần có x:name="Iborder_menu" trong MainWindow và thay đổi giá trị
                mainWindow.editBtn.Visibility = Visibility.Visible;
                mainWindow.Iborder_menu.Content = new Course_list();
            }
        }
    }
}
