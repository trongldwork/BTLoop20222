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
using Word = Microsoft.Office.Interop.Word;
using Aspose.Words;
using DocumentFormat.OpenXml.ExtendedProperties;
using Microsoft.Office.Core;



namespace sebExamination.Controls
{
    /// <summary>
    /// Interaction logic for Test_Preview.xaml
    /// </summary>
    public partial class Test_Preview : UserControl
    {
        string path = "";
        public Test_Preview(string QuizPath)
        {
            InitializeComponent();
            path = QuizPath;
            TestName.Text = System.IO.Path.GetFileName(path).Remove(System.IO.Path.GetFileName(path).Length - 4);
        }

        private void settingTestBtn_Click(object sender, RoutedEventArgs e)
        {
            // Truyền giá trị newValue cho MainWindow
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                mainWindow.AddToMap(new EditQuiz(path), "Edit quiz", 2);
                // Truy cập đến thành phần có x:name="Iborder_menu" trong MainWindow và thay đổi giá trị
                mainWindow.Iborder_menu.Content = new EditQuiz(path);
            }
        }

        private void PreviewQuiz_Click(object sender, RoutedEventArgs e)
        {
            confirmation_box.Visibility = Visibility.Visible;
        }

        private void closeConfirmationBox_btn_Click(object sender, RoutedEventArgs e)
        {
            confirmation_box.Visibility = Visibility.Collapsed;
        }

        private void startAttempt_Click(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                mainWindow.AddToMap(new Quiz(path), System.IO.Path.GetFileName(path).Remove(System.IO.Path.GetFileName(path).Length - 4) , 1);
                // Truy cập đến thành phần có x:name="Iborder_menu" trong MainWindow và thay đổi giá trị
                mainWindow.Iborder_menu.Content = new Quiz(path);
            }
        }
        private void Export_Click(object sender, RoutedEventArgs e)
        {
            FileImp fileImp = new FileImp(); 
            string outputpath = fileImp.ReplaceImageTags(path);
            fileImp.ConvertTextToPdf(outputpath , "pdfxx.pdf");
        }
    }
}
