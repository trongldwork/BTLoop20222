using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using sebExamination.Model;
using DocumentFormat.OpenXml.ExtendedProperties;

namespace sebExamination.Controls
{
    /// <summary>
    /// Interaction logic for Import.xaml
    /// </summary>
    public partial class Import : UserControl
    {
        public Import()
        {
            InitializeComponent();
        }
        
        static string? _Filename { get; set; }
        static List<Line> _Lines = new List<Line>();
        public void OnDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                List<Line> lines = new List<Line>();
                string filePath = files[0];
                string filename = Path.GetFileNameWithoutExtension(filePath);
                string fileExtension = System.IO.Path.GetExtension(filePath);
                try
                {
                    // Đọc nội dung file
                    if (fileExtension == ".txt")
                    {
                        lines = Readtxt(filePath);
                    }
                    else if (fileExtension == ".docx")
                    {
                        lines = Readdocx(filePath);
                    }
                    else
                    {
                        MessageBox.Show("Không phải file txt hoặc docx");
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Lỗi khi đọc file: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                // neu file chuan aiken format thi luu
                if (ValidInput(lines))
                {
                    input_field.Text = $"đã đọc file từ đường dãn:\n {filePath}";
                    _Filename = filename;
                    _Lines = lines;
                }
            }
        }
        public void OnDragLeave(object sender, DragEventArgs e)
        {

        }
        public void OnDragEnter(object sender, DragEventArgs e)
        {

        }
        public void Choose_file_click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Thiết lập các thuộc tính cho dialog
            openFileDialog.Title = "Chọn file";
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|Word Documents (*.docx)|*.docx";
            openFileDialog.InitialDirectory = "C:\\";
            List<Line> lines = new List<Line>();
            if (openFileDialog.ShowDialog() == true)
            {
                // Lấy đường dẫn tới file đã chọn
                string filePath = openFileDialog.FileName;
                string filename = Path.GetFileNameWithoutExtension(filePath);
                string fileExtension = System.IO.Path.GetExtension(filePath);
                try
                {
                    // Đọc nội dung file
                    if (fileExtension == ".txt")
                    {
                        lines = Readtxt(filePath);
                    }
                    else if (fileExtension == ".docx")
                    {
                        lines = Readdocx(filePath);
                    }
                    else
                    {
                        MessageBox.Show("Không phải file txt hoặc docx");
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Lỗi khi đọc file: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                // neu file chuan aiken format thi luu
                if (ValidInput(lines))
                {
                    input_field.Text = $"đã đọc file từ đường dãn:\n {filePath}";
                    _Filename = filename;
                    _Lines = lines;
                }
            }

        }
        static void Savefileques(string filename, List<Line> lines)
        {
            
            string project_path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            string categoriesPath = System.IO.Path.Combine(project_path, "File question");
            string Filename = filename + ".txt";
            string _filepath = Path.Combine(categoriesPath, Filename);
            // Tạo FileStream và đóng nó ngay sau khi tạo xong
            using (FileStream fs = File.Create(_filepath)) { }
            using (StreamWriter writer = new StreamWriter(_filepath))
            {
                foreach (Line line in lines) { writer.WriteLine(line.LineContent); }
            }
        }
        static List<Line> Readtxt(string filePath)
        {
            List<Line> lines1 = new List<Line>();
            int count = 0;
            try
            {
                // Mở file txt để đọc
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    // Đọc từng dòng cho đến khi kết thúc file

                    while ((line = sr.ReadLine()) != null)
                    {
                        count++;
                        lines1.Add(new Line(line, count));
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + e.Message);
            }
            return lines1;
        }
        static List<Line> Readdocx(string filePath)
        {
            List<Line> lines = new List<Line>();
            using (WordprocessingDocument document = WordprocessingDocument.Open(filePath, false))
            {
                // Get the main document part (i.e. the content)
                var body = document.MainDocumentPart.Document.Body;
                int pos = 0;

                // Loop through all paragraphs in the document
                foreach (var paragraph in body.Descendants<Paragraph>())
                {
                    // Check if the paragraph contains any text
                    if (paragraph.InnerText.Trim().Length > 0)
                    {
                        // Loop through all runs in the paragraph
                        foreach (var run in paragraph.Descendants<Run>())
                        {
                            // Loop through all text elements in the run
                            foreach (var text in run.Descendants<Text>())
                            {
                                // Get the byte array of the text content
                                byte[] bytes = Encoding.UTF8.GetBytes(text.Text);

                                // Decode the byte array to a string using UTF-8
                                string line = Encoding.UTF8.GetString(bytes);

                                // Do something with the line
                                pos++;
                                lines.Add(new Line(line, pos));
                            }
                        }
                    }
                    else
                    {
                        // Handle empty paragraphs (lines)
                        pos++;
                        lines.Add(new Line("", pos));
                    }
                }
            }
            return lines;
        }
        static bool ValidInput(List<Line> input)
        {
            // khong co dong nao duoc ghi la false
            if (input.Count == 0) { return false; }
            // dong dau tien phai la cau hoi
            if (input[0].Type != "question") { MessageBox.Show($"error at 1"); return false; }
            else
            {
                // list de du bao kieu hop le tiep theo
                List<string> next_type = new List<string>();
                next_type.Add("question");
                int num_choice = 0;
                List<char> choice_list = new List<char>();
                for (int i = 0; i < input.Count; i++)
                {
                    if (!next_type.Contains(input[i].Type))
                    {
                        MessageBox.Show($"error at {i + 1}");
                        return false;
                    }
                    if (input[i].Type == "question")
                    {
                        next_type.Remove("question");
                        next_type.Add("choice");
                    }
                    if (input[i].Type == "choice")
                    {
                        choice_list.Add(input[i].LineContent[0]);
                        num_choice++;
                        if (num_choice == 2)
                        {
                            next_type.Add("answer");
                        }
                    }
                    if (input[i].Type == "answer")
                    {
                        //đáp án phải trong các lựa chọn bên trên, sau đáp án là một dòng trống
                        if (!choice_list.Contains(input[i].LineContent[8]))
                        {
                            MessageBox.Show($"error at {i + 1}");
                            return false;
                        }
                        num_choice = 0;
                        next_type.Remove("choice");
                        next_type.Remove("answer");
                        next_type.Add("none");
                    }
                    if (input[i].Type == "none")
                    {
                        next_type.Remove("none");
                        next_type.Add("question");
                    }
                }
                return true;
            }

        }
        
        public void Import_btn_click(object sender, EventArgs e)
        {
            Savefileques(_Filename, _Lines);
        }
        private void import_fileFormat_click(object sender, RoutedEventArgs e)
        {
            if (import_fileFormat_box.Visibility == Visibility.Visible)
            {
                import_fileFormat_box.Visibility = Visibility.Collapsed;
                fileFomat_status.Source = new BitmapImage(new Uri("/Assets/image/arrow-right.png", UriKind.Relative));
            }

            else if (import_fileFormat_box.Visibility == Visibility.Collapsed)
            {
                import_fileFormat_box.Visibility = Visibility.Visible;
                fileFomat_status.Source = new BitmapImage(new Uri("/Assets/image/arrow-down.png", UriKind.Relative));
            }
        }

        private void import_general_click(object sender, RoutedEventArgs e)
        {
            if (import_general_box.Visibility == Visibility.Visible)
            {
                import_general_box.Visibility = Visibility.Collapsed;
                general_status.Source = new BitmapImage(new Uri("/Assets/image/arrow-right.png", UriKind.Relative));
            }

            else if (import_general_box.Visibility == Visibility.Collapsed)
            {
                import_general_box.Visibility = Visibility.Visible;
                general_status.Source = new BitmapImage(new Uri("/Assets/image/arrow-down.png", UriKind.Relative));
            }
        }

        
        private void import_file_click(object sender, RoutedEventArgs e)
        {
            if (import_file_box.Visibility == Visibility.Visible)
            {
                import_file_box.Visibility = Visibility.Collapsed;
                file_status.Source = new BitmapImage(new Uri("/Assets/image/arrow-right.png", UriKind.Relative));
            }

            else if (import_file_box.Visibility == Visibility.Collapsed)
            {
                import_file_box.Visibility = Visibility.Visible;
                file_status.Source = new BitmapImage(new Uri("/Assets/image/arrow-down.png", UriKind.Relative));
            }
        }
    }
}
