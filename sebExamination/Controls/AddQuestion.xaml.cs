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
    /// Interaction logic for AddQuestion.xaml
    /// </summary>
    

    public partial class AddQuestion : UserControl
    {
        List<Questions> questions;
        FileImp fileImp = new FileImp();
        private List<ComboBox> comboboxs = new List<ComboBox>();
        List<TextBox> textBoxes = new List<TextBox>();
        public AddQuestion()
        {
            InitializeComponent();
            questions = new List<Questions>();
            create_category_parent_ComboBox();
            textBoxes.Add(text_choice1);
            textBoxes.Add(text_choice2);
            comboboxs.Add(text_choice1_mark);
            comboboxs.Add(text_choice2_mark);
        }
        private void create_category_parent_ComboBox()
        {
            // Tạo đường dẫn đến thư mục "Categories"
            string currentDirectory = Directory.GetCurrentDirectory();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.FullName;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            string categoriesPath = System.IO.Path.Combine(projectDirectory, "Categories");

            // Tạo ComboBox và thêm tên thư mục vào nó

            ComboBox comboBox = category_parent;
            comboBox.Items.Add("default");
            comboBox.Height = 25;
            comboBox.Width = 200;
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
                    for (int i = 0; i < elevator; i++)
                    {
                        folderName = "   " + folderName;
                    }
                    elevator++;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    string dataPath = Directory.GetParent(folder).FullName;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
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
        private void addQuestion_general_click(object sender, RoutedEventArgs e)
        {

        }
        private void saveChangeAndContinue_addQuestion_btn_click(object sender, RoutedEventArgs e)
        {

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
        private void saveChange_addQuestion_btn_click(object sender, RoutedEventArgs e)
        {
            
            List<string> answer = new List<string>();
            
            string ans = "ANSWER: ";
            int tmp = 0;
            foreach (TextBox textBox in textBoxes)
            {
                answer.Add((char)(65+tmp++)+". "+textBox.Text);
            }
            tmp =0;
            foreach(ComboBox comboBox in comboboxs)
            {
                
                if(comboBox.SelectedIndex == 1)
                {
                    ans += (char)(65+tmp);
                    break;
                }
                tmp++;

            }
            Questions tempQ = new Questions(questionName_addQuestion.Text, answer, ans, double.Parse(questionMark_addQuestion.Text));
            questions.Add(tempQ);
            string currentDirectory = Directory.GetCurrentDirectory();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.FullName;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            string categoriesPath = System.IO.Path.Combine(projectDirectory, "Categories");
            string filePath = "";

            if (category_parent.SelectedIndex != 0)
            {
                int index = category_parent.SelectedIndex;
                List<string> parent = new List<string>();
#pragma warning disable CS8604 // Possible null reference argument.
                parent.Add(category_parent.Items[index].ToString());
#pragma warning restore CS8604 // Possible null reference argument.
                int k = countLevel(parent[0]) - 1;

                int n = countLevel(parent[0]);
                while (parent[0][0] == ' ')
                {
                    parent[0] = parent[0].Substring(1);
                }
                parent[0] = parent[0].Substring(0, parent[0].Length - 4);

                for (int i = index; i > 0; i--)
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    if (countLevel(category_parent.Items[i].ToString()) == k)
                    {
#pragma warning disable CS8604 // Possible null reference argument.
                        parent.Add(category_parent.Items[i].ToString());
#pragma warning restore CS8604 // Possible null reference argument.
                        while (parent[n - k][0] == ' ')
                        {
                            
                            parent[n - k] = parent[n - k].Substring(1);
                        }
                        parent[n - k] = parent[n - k].Substring(0, parent[n - k].Length - 4);
                        k--;
                    }
#pragma warning restore CS8604 // Possible null reference argument.
                }

                for (int i = n - 1; i >= 0; i--)
                {
                    categoriesPath = System.IO.Path.Combine(categoriesPath, parent[i]);
                }
                filePath = System.IO.Path.Combine(categoriesPath, parent[0] + ".txt");

            }
            //string folderPath = System.IO.Path.Combine(categoriesPath, category_parent.SelectedItem.ToString());
            //string filePath = System.IO.Path.Combine(categoriesPath, parent[0] + ".txt");

            fileImp.SaveDataToFile(filePath, questions);
            string countFile = System.IO.Path.Combine(categoriesPath, "count.txt");
            var data = File.ReadAllText(countFile);
            int count = int.Parse(data) + 1;
            File.WriteAllText(countFile, count.ToString());
            
        }
        private void cancel_addQuestion_btn_click(object sender, RoutedEventArgs e)
        {

        }

        

        int choicesNumber = 2;
        private void moreChoices_btn_click(Object sender, RoutedEventArgs e)
        {
            choicesNumber++;
            Grid choice_addQuestion = new Grid()
            {
                Name = $"choice{choicesNumber}_addQuestion",
                Height = 80,
                Width = 400,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(0, 10, 0, 10),
                Background = Brushes.AntiqueWhite
            };

            TextBlock textBlock1 = new TextBlock()
            {
                Foreground = Brushes.Gray,
                FontSize = 16,
                Text = $"Choice {choicesNumber}",
                Margin = new Thickness(5)
            };

            TextBlock textBlock2 = new TextBlock()
            {
                Foreground = Brushes.Gray,
                FontSize = 16,
                Text = "Grade",
                Margin = new Thickness(5, 45, 0, 0)
            };

            TextBox textBox = new TextBox()
            {
                Name = $"text_choice{choicesNumber}",
                Height = 30,
                Width = 300,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(5)
            };

            ComboBox comboBox = new ComboBox()
            {
                Height = 30,
                Name = $"text_choice{choicesNumber}_mark",
                Width = 100,
                Margin = new Thickness(95, 45, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                SelectedIndex = 0,
                FontSize = 18,
                Foreground = Brushes.Gray
            };

            comboBox.Items.Add(new ComboBoxItem() { Content = "None" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "100%" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "90%" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "83.33333%" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "80%" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "75%" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "70%" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "66.66666%" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "60%" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "50%" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "40%" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "33.33333%" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "30%" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "25%" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "20%" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "16.66667%" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "66.66666%" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "12.5%" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "10%" });

            choice_addQuestion.Children.Add(textBlock1);
            choice_addQuestion.Children.Add(textBlock2);
            choice_addQuestion.Children.Add(textBox);
            choice_addQuestion.Children.Add(comboBox);
            textBoxes.Add(textBox);
            comboboxs.Add(comboBox);

            Choices.Children.Add(choice_addQuestion);
        }
    }
}
