using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Math;
using filereader;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for AddQuestion.xaml
    /// </summary>
    

    public partial class AddQuestion : UserControl
    {
        struct imagepath
        {
            public string Text;
            public string pos;
        };
        List<imagepath> imagepaths = new List<imagepath>();
        List<Questions> questions;
        FileImp fileImp = new FileImp();
        private List<ComboBox> comboboxs = new List<ComboBox>();
        List<TextBox> textBoxes = new List<TextBox>();
        string ques_image_path = "";
        int setter = 0;
        string setterPath = "";
        public AddQuestion(string path, int QuestionNumber, int index)
        {
            setter = QuestionNumber;
            InitializeComponent();
            questions = new List<Questions>();
            create_category_parent_ComboBox();
            textBoxes.Add(text_choice1);
            textBoxes.Add(text_choice2);
            comboboxs.Add(text_choice1_mark);
            comboboxs.Add(text_choice2_mark);
            if(path != null)
            {
                setterPath = path;
                category_parent.SelectedIndex = index;
                Title.Text = "Editting a multipal choice";
                questions = fileImp.LoadDataFromFile(path);

                questionText_addQuestion.Text = questions[QuestionNumber].Quest;
                questionMark_addQuestion.Text = questions[QuestionNumber].Mark.ToString();
                text_choice1.Text = questions[QuestionNumber].Ans[0].Substring(3);
                text_choice2.Text = questions[QuestionNumber].Ans[1].Substring(3);
                for (int i = 2; i< questions[QuestionNumber].Ans.Count; i++)
                {
                    moreChoices_btn_click(null, null);
                    TextBox tmp = textBoxes.FirstOrDefault(tb => tb.Name == $"text_choice{i + 1}");
                    tmp.Text = questions[QuestionNumber].Ans[i].Substring(3);
                }
                char da = questions[QuestionNumber].Answer[8];
                ComboBox tmp1 = comboboxs.FirstOrDefault(tb => tb.Name == $"text_choice{(int)da-65+1}_mark");
                tmp1.SelectedIndex = 1;
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
        private void addQuestion_general_click(object sender, RoutedEventArgs e)
        {

        }
        private void saveChangeAndContinue_addQuestion_btn_click(object sender, RoutedEventArgs e)
        {
            if (category_parent.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng chọn category");
                return;
            }
            if (setter == -1 || category_parent.SelectedIndex != 0)
            {
                questions = new List<Questions>();   
                List<string> answer = new List<string>();

                string ans = "ANSWER: ";
                int tmp = 0;
                foreach (TextBox textBox in textBoxes)
                {
                    string line_choice = textBox.Text;
                    foreach (imagepath tmpImg in imagepaths)
                    {
                        if (tmpImg.pos == (tmp + 1).ToString()) { line_choice += tmpImg.Text; }
                    }
                    answer.Add((char)(65 + tmp++) + ". " + line_choice);
                }
                tmp = 0;
                foreach (ComboBox comboBox in comboboxs)
                {

                    if (comboBox.SelectedIndex == 1)
                    {
                        ans += (char)(65 + tmp);
                        break;
                    }
                    tmp++;

                }
                if (tmp == comboboxs.Count) { MessageBox.Show("Phải có đáp án"); return; }
                string ques = questionName_addQuestion.Text + "\n" + questionText_addQuestion.Text;
                ques += (ques_image_path != "") ? "<image>:" + ques_image_path : ques_image_path;
                Questions tempQ = new Questions(ques,
                    answer,
                    ans,
                    double.Parse(questionMark_addQuestion.Text));
                questions.Add(tempQ);
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
                    parent[0] = parent[0].Substring(0, parent[0].Length - countLength(parent[n - k - 1]));

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
                //string folderPath = System.IO.Path.Combine(categoriesPath, category_parent.SelectedItem.ToString());
                //string filePath = System.IO.Path.Combine(categoriesPath, parent[0] + ".txt");

                fileImp.SaveDataToFile(filePath, questions);
                string countFile = System.IO.Path.Combine(categoriesPath, "count.txt");
                var data = File.ReadAllText(countFile);
                int count = int.Parse(data) + 1;
                File.WriteAllText(countFile, count.ToString());
                ques_image_path = "";
            }
            else
            {
                if (category_parent.SelectedIndex == 0)
                {
                    MessageBox.Show("Vui lòng chọn category");
                    return;
                }
                List<string> answer = new List<string>();

                string ans = "ANSWER: ";
                int tmp = 0;
                foreach (TextBox textBox in textBoxes)
                {
                    string line_choice = textBox.Text;
                    MessageBox.Show(line_choice);
                    foreach (imagepath tmpImg in imagepaths)
                    {
                        if (tmpImg.pos == (tmp + 1).ToString()) { line_choice += tmpImg.Text; }
                    }
                    answer.Add((char)(65 + tmp++) + ". " + line_choice);
                }
                tmp = 0;
                foreach (ComboBox comboBox in comboboxs)
                {

                    if (comboBox.SelectedIndex == 1)
                    {
                        ans += (char)(65 + tmp);
                        break;
                    }
                    tmp++;

                }
                string ques = questionName_addQuestion.Text + "\n"+ questionText_addQuestion.Text;
                ques += (ques_image_path != "") ? "<image>:" + ques_image_path : ques_image_path;
                Questions tempQ = new Questions(ques,
                    answer,
                    ans,
                    double.Parse(questionMark_addQuestion.Text));
                questions[setter] = tempQ;
                var data = File.ReadAllText(setterPath).Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                File.WriteAllText(setterPath, data[0] + "\n" + data[1]+"\n");
                fileImp.SaveDataToFile(setterPath, questions);
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
        private void saveChange_addQuestion_btn_click(object sender, RoutedEventArgs e)
        {
            saveChangeAndContinue_addQuestion_btn_click(sender, e);
            cancel_addQuestion_btn_click(null,null);
        }
        private void cancel_addQuestion_btn_click(object sender, RoutedEventArgs e)
        {
            // Truyền giá trị newValue cho MainWindow
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                mainWindow.AddToMap(new Question(), "Question", 1);
                // Truy cập đến thành phần có x:name="Iborder_menu" trong MainWindow và thay đổi giá trị
                Menu_uc tmpuc = new Menu_uc();
                tmpuc.MainContentControl = new Question();
                mainWindow.Iborder_menu.Content = tmpuc;
            }
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

            Image image = new Image()
            {
                Height = 40,
                Width = 50,
                Margin = new Thickness(0, 0, 0, -5),
                HorizontalAlignment = HorizontalAlignment.Left,
                Source = new BitmapImage(new Uri("../Assets/image/add-image.png", UriKind.Relative)),
            };
            ToggleButton add_choice_img = new ToggleButton();
            add_choice_img.Content = image;
            add_choice_img.Name = "choice_img" + choicesNumber;
            add_choice_img.Height = 40;
            add_choice_img.Width = 50;
            add_choice_img.HorizontalAlignment = HorizontalAlignment.Left;
            add_choice_img.BorderThickness = new Thickness(0);
            add_choice_img.Background = Brushes.Transparent;
            add_choice_img.Click += add_choice_click;
            add_choice_img.Margin = new Thickness(345, 40, 0, 0);
            



            choice_addQuestion.Children.Add(textBlock1);
            choice_addQuestion.Children.Add(textBlock2);
            choice_addQuestion.Children.Add(textBox);
            choice_addQuestion.Children.Add(comboBox);
            choice_addQuestion.Children.Add(add_choice_img);
            textBoxes.Add(textBox);
            comboboxs.Add(comboBox);

            Choices.Children.Add(choice_addQuestion);
        }


        private void add_ques_img_Click(object sender, RoutedEventArgs e)
        {
            add_ques_img.Background = Brushes.Transparent;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Tập tin hình ảnh|*.jpg;*.jpeg;*.png;*.gif;*.mp4;*.avi";
            openFileDialog.Title = "Chọn hình ảnh";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedImagePath = openFileDialog.FileName;

                // Thực hiện xử lý thông tin hình ảnh ở đây
                // Ví dụ: Lấy tên tập tin
                string imageName = System.IO.Path.GetFileName(selectedImagePath);
                string project_path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                string FolderImagePath = project_path + "/categories image/";
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
                    parent[0] = parent[0].Substring(0, parent[0].Length - countLength(parent[n - k - 1]));
                    FolderImagePath += parent[0];
                }
                if (!Directory.Exists(FolderImagePath)) Directory.CreateDirectory(FolderImagePath);
                string outputImagePath = System.IO.Path.Combine(FolderImagePath, imageName);
                int p = 0;
                while (System.IO.File.Exists(outputImagePath))
                {
                    p++;
                    outputImagePath = FolderImagePath + p + imageName;
                }
                File.Copy(selectedImagePath, outputImagePath);
                ques_image_path = outputImagePath;
                // them thong tin anh
                if (ques_img.Children.Count > 1) ques_img.Children.RemoveAt(ques_img.Children.Count - 1);
                TextBox textBox = new TextBox()
                {
                    Name = "qu",
                    Text = imageName,
                    IsReadOnly = true,
                    Height = 30,
                    BorderThickness = new Thickness(0),
                    MaxWidth = 350,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(5)

                };
                ques_img.Children.Add(textBox);
                ques_image_path = selectedImagePath;
            }


        }

        private void add_ques_img_Checked(object sender, RoutedEventArgs e)
        {
            ToggleButton toggle = (ToggleButton)sender;
            toggle.IsChecked = false;
        }
        private void add_choice_click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Tập tin hình ảnh|*.jpg;*.jpeg;*.png;*.gif";
            openFileDialog.Title = "Chọn hình ảnh";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedImagePath = openFileDialog.FileName;

                // Thực hiện xử lý thông tin hình ảnh ở đây
                // Ví dụ: Lấy tên tập tin
                string imageName = System.IO.Path.GetFileName(selectedImagePath);
                string project_path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                string FolderImagePath = project_path + "/categories image/";
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
                    parent[0] = parent[0].Substring(0, parent[0].Length - countLength(parent[n - k - 1]));
                    FolderImagePath += parent[0];
                }
                if (!Directory.Exists(FolderImagePath)) Directory.CreateDirectory(FolderImagePath);
                string outputImagePath = System.IO.Path.Combine(FolderImagePath, imageName);
                int p = 0;
                while (System.IO.File.Exists(outputImagePath))
                {
                    p++;
                    outputImagePath = FolderImagePath + p + imageName;
                }
                File.Copy(selectedImagePath, outputImagePath);

                // luu anh theo choice
                ToggleButton toggle = (ToggleButton)sender;
                imagepath tmp;
                tmp.Text = "<image>:" + outputImagePath;
                tmp.pos = toggle.Name.Substring(10);
                imagepaths.Add(tmp);
            }
        }
    }
}
