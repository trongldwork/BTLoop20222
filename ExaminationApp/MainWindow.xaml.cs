using System;
using System.Collections.Generic;
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

namespace ExaminationApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SwitchViewHome_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SwitchViewCourse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowQuestionBank_Click(object sender, RoutedEventArgs e)
        {
            QuestionBank.IsOpen = true;
        }
        private void settingQuestions_click(object sender, RoutedEventArgs e)
        {
            Questionbank_box.Visibility = Visibility.Visible;
            Questions.Visibility = Visibility.Visible;
            Categories.Visibility = Visibility.Collapsed;
            Import.Visibility = Visibility.Collapsed;
            Export.Visibility = Visibility.Collapsed;
            blank.Visibility = Visibility.Collapsed;
            QuestionBank_Questions.Foreground = Brushes.Gray;
            QuestionBank_Categories.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#009FE5"));
            QuestionBank_Import.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#009FE5"));
            QuestionBank_Export.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#009FE5"));
        }

        private void settingCategories_click(object sender, RoutedEventArgs e)
        {
            Questionbank_box.Visibility = Visibility.Visible;
            Questions.Visibility = Visibility.Collapsed;
            Categories.Visibility = Visibility.Visible;
            Import.Visibility = Visibility.Collapsed;
            Export.Visibility = Visibility.Collapsed;
            blank.Visibility = Visibility.Collapsed;
            QuestionBank_Questions.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#009FE5"));
            QuestionBank_Categories.Foreground = Brushes.Gray;
            QuestionBank_Import.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#009FE5"));
            QuestionBank_Export.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#009FE5"));
        }

        private void settingImport_click(object sender, RoutedEventArgs e)
        {
            Questionbank_box.Visibility = Visibility.Visible;
            Questions.Visibility = Visibility.Collapsed;
            Categories.Visibility = Visibility.Collapsed;
            Import.Visibility = Visibility.Visible;
            Export.Visibility = Visibility.Collapsed;
            blank.Visibility = Visibility.Collapsed;
            QuestionBank_Questions.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#009FE5"));
            QuestionBank_Categories.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#009FE5"));
            QuestionBank_Import.Foreground = Brushes.Gray;
            QuestionBank_Export.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#009FE5"));
        }

        private void settingExport_click(object sender, RoutedEventArgs e)
        {
            Questionbank_box.Visibility = Visibility.Visible;
            Questions.Visibility = Visibility.Collapsed;
            Categories.Visibility = Visibility.Collapsed;
            Import.Visibility = Visibility.Collapsed;
            Export.Visibility = Visibility.Visible;
            blank.Visibility = Visibility.Collapsed;
            QuestionBank_Questions.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#009FE5"));
            QuestionBank_Categories.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#009FE5"));
            QuestionBank_Import.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#009FE5"));
            QuestionBank_Export.Foreground = Brushes.Gray;
        }
        public class courseSource
        {
            public string courseName { get; set; }
        }

        private void showSubcategoriesQuestions_check(object sender, RoutedEventArgs e)
        {

        }

        private void showOldQuestions_check(object sender, RoutedEventArgs e)
        {

        }
        private void createQuestion_click(object sender, RoutedEventArgs e)
        {
            createQuestion_box.Visibility = Visibility.Visible;
        }
        private void addQuestion_general_click(object sender, RoutedEventArgs e)
        {

        }
        private void saveChangeAndContinue_addQuestion_btn_click(object sender, RoutedEventArgs e)
        {

        }
        private void saveChange_addQuestion_btn_click(object sender, RoutedEventArgs e)
        {
            createQuestion_box.Visibility=Visibility.Collapsed;
        }
        private void cancel_addQuestion_btn_click(object sender, RoutedEventArgs e)
        {

        }
        private void MenuItem_Questions_Click(object sender, RoutedEventArgs e)
        {
            Questions.Visibility = Visibility.Visible;
            Categories.Visibility = Visibility.Collapsed;
            Import.Visibility = Visibility.Collapsed;
            Export.Visibility = Visibility.Collapsed;
            QuestionBank_Questions.Foreground = Brushes.Gray;
            QuestionBank_Categories.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#009FE5"));
            QuestionBank_Import.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#009FE5"));
            QuestionBank_Export.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#009FE5"));
        }

        private void MenuItem_Categories_Click(object sender, RoutedEventArgs e)
        {
            Questions.Visibility = Visibility.Collapsed;
            Categories.Visibility = Visibility.Visible;
            Import.Visibility = Visibility.Collapsed;
            Export.Visibility = Visibility.Collapsed;
            QuestionBank_Questions.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#009FE5"));
            QuestionBank_Categories.Foreground = Brushes.Gray;
            QuestionBank_Import.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#009FE5"));
            QuestionBank_Export.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#009FE5"));
        }

        private void MenuItem_Import_Click(object sender, RoutedEventArgs e)
        {
            Questions.Visibility = Visibility.Collapsed;
            Categories.Visibility = Visibility.Collapsed;
            Import.Visibility = Visibility.Visible;
            Export.Visibility = Visibility.Collapsed;
            QuestionBank_Questions.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#009FE5"));
            QuestionBank_Categories.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#009FE5"));
            QuestionBank_Import.Foreground = Brushes.Gray;
            QuestionBank_Export.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#009FE5"));
        }

        private void MenuItem_Export_Click(object sender, RoutedEventArgs e)
        {
            Questions.Visibility = Visibility.Collapsed;
            Categories.Visibility = Visibility.Collapsed;
            Import.Visibility = Visibility.Collapsed;
            Export.Visibility = Visibility.Visible;
            QuestionBank_Questions.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#009FE5"));
            QuestionBank_Categories.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#009FE5"));
            QuestionBank_Import.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#009FE5"));
            QuestionBank_Export.Foreground = Brushes.Gray;
        }

        private void addCategory_click(object sender, RoutedEventArgs e)
        {

        }

        private void import_fileFormat_click(object sender, RoutedEventArgs e)
        {
            if (import_fileFormat_box.Visibility == Visibility.Visible)
            {
                import_fileFormat_box.Visibility = Visibility.Collapsed;
                fileFomat_status.Source = new BitmapImage(new Uri("/Assets/Images/arrow-right.png", UriKind.Relative));
            }

            else if (import_fileFormat_box.Visibility == Visibility.Collapsed)
            {
                import_fileFormat_box.Visibility = Visibility.Visible;
                fileFomat_status.Source = new BitmapImage(new Uri("/Assets/Images/arrow-down.png", UriKind.Relative));
            }
        }

        private void import_general_click(object sender, RoutedEventArgs e)
        {
            if (import_general_box.Visibility == Visibility.Visible)
            {
                import_general_box.Visibility = Visibility.Collapsed;
                general_status.Source = new BitmapImage(new Uri("/Assets/Images/arrow-right.png", UriKind.Relative));
            }

            else if (import_general_box.Visibility == Visibility.Collapsed)
            {
                import_general_box.Visibility = Visibility.Visible;
                general_status.Source = new BitmapImage(new Uri("/Assets/Images/arrow-down.png", UriKind.Relative));
            }
        }

        private void import_file_click(object sender, RoutedEventArgs e)
        {
            if (import_file_box.Visibility == Visibility.Visible)
            {
                import_file_box.Visibility = Visibility.Collapsed;
                file_status.Source = new BitmapImage(new Uri("/Assets/Images/arrow-right.png", UriKind.Relative));
            }

            else if (import_file_box.Visibility == Visibility.Collapsed)
            {
                import_file_box.Visibility = Visibility.Visible;
                file_status.Source = new BitmapImage(new Uri("/Assets/Images/arrow-down.png", UriKind.Relative));
            }
        }

        private void upload_Btn_click(object sender, RoutedEventArgs e)
        {

        }

        private void OnDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.Copy;
            }
        }

        private void OnDragLeave(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;
        }

        private void OnDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                string filePath = files[0];

                // Upload file to server
                // ...

                // Reset the text in the Border
                ((TextBlock)((Border)sender).Child).Text = "Kéo thả file vào đây để upload";
            }
        }

        private void importQuestion_btn_click(object sender, RoutedEventArgs e)
        {

        }

        List<courseSource> courseL = new List<courseSource> { new courseSource { courseName = "toan" } };


        private void ListBox_Drop(object sender, DragEventArgs e)
        {

        }

        private void import_general_Click(object sender, RoutedEventArgs e)
        {

        }
        private void addNewQuiz_click(object sender, RoutedEventArgs e)
        {
            addQuiz_box.Visibility = Visibility.Visible;
            blank.Visibility = Visibility.Collapsed;
        }
        private void addQuiz_general_click(object sender, RoutedEventArgs e)
        {
            if (addQuiz_general_box.Visibility == Visibility.Visible)
            {
                addQuiz_general_box.Visibility = Visibility.Collapsed;
                addQuiz_general_status.Source = new BitmapImage(new Uri("/Assets/Images/arrow-right.png", UriKind.Relative));
            }

            else if (addQuiz_general_box.Visibility == Visibility.Collapsed)
            {
                addQuiz_general_box.Visibility = Visibility.Visible;
                addQuiz_general_status.Source = new BitmapImage(new Uri("/Assets/Images/arrow-down.png", UriKind.Relative));
            }
        }
        private void addQuiz_timing_click(object sender, RoutedEventArgs e)
        {
            if (addQuiz_timing_box.Visibility == Visibility.Visible)
            {
                addQuiz_timing_box.Visibility = Visibility.Collapsed;
                addQuiz_timing_status.Source = new BitmapImage(new Uri("/Assets/Images/arrow-right.png", UriKind.Relative));
            }

            else if (addQuiz_timing_box.Visibility == Visibility.Collapsed)
            {
                addQuiz_timing_box.Visibility = Visibility.Visible;
                addQuiz_timing_status.Source = new BitmapImage(new Uri("/Assets/Images/arrow-down.png", UriKind.Relative));
            }
        }
        private void displayDes_addquiz_check(object sender, RoutedEventArgs e)
        {

        }

        private void addQuiz_btn_click(object sender, RoutedEventArgs e)
        {
            addQuiz_box.Visibility = Visibility.Collapsed;
            blank.Visibility = Visibility.Visible;
        }
        private void cancel_addQuiz_btn_click(object sender, RoutedEventArgs e)
        {
            addQuiz_box.Visibility = Visibility.Collapsed;
            blank.Visibility = Visibility.Visible;
        }
    }
}
