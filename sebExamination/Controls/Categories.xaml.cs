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
                    // Thêm tên thư mục vào ComboBox
                    comboBox.Items.Add(folderName);

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


        public string find_parent(string path, string parent, int k)
        {
                string[] folders = Directory.GetDirectories(path);
                foreach (string folder in folders)
                {
                    // Lấy tên thư mục từ đường dẫn
                    string folderName = new DirectoryInfo(folder).Name;


                    if (folderName == parent)
                    {
                    if (k != 0) return folderName;
                    else return folder;
                    }
                    // Thêm tên thư mục vào ComboBox


                    // Tiếp tục đệ quy để lấy tất cả các thư mục con bên trong thư mục hiện tại
                    return System.IO.Path.Combine(folder,find_parent(folder, parent, k+1));
                }
            return null;
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
                string parent = category_parent.SelectedItem.ToString();
                while (parent[0] == ' ')
                {
                    parent = parent.Substring(1);
                }
                categoriesPath = find_parent(categoriesPath, parent, 0);
            }

            string folderPath = System.IO.Path.Combine(categoriesPath, categoryName);
            string filePath = System.IO.Path.Combine(folderPath, fileName);

            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Lấy nội dung từ TextBox
                string fileContent = category_info.Text;

                // Tạo và ghi nội dung vào file
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(fileContent);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }

        }
    }
}
