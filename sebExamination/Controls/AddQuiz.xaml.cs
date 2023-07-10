using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
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
    /// Interaction logic for AddQuiz.xaml
    /// </summary>
    public partial class AddQuiz : UserControl
    {
        public AddQuiz()
        {
            InitializeComponent();
            Window_Loaded();
        }
        private void addQuiz_general_click(object sender, RoutedEventArgs e)
        {
            if (addQuiz_general_box.Visibility == Visibility.Visible)
            {
                addQuiz_general_box.Visibility = Visibility.Collapsed;
                addQuiz_general_status.Source = new BitmapImage(new Uri("../Assets/image/arrow-right.png", UriKind.Relative));
            }

            else if (addQuiz_general_box.Visibility == Visibility.Collapsed)
            {
                addQuiz_general_box.Visibility = Visibility.Visible;
                addQuiz_general_status.Source = new BitmapImage(new Uri("../Assets/image/arrow-down.png", UriKind.Relative));
            }
        }
        private void addQuiz_timing_click(object sender, RoutedEventArgs e)
        {
            if (addQuiz_timing_box.Visibility == Visibility.Visible)
            {
                addQuiz_timing_box.Visibility = Visibility.Collapsed;
                addQuiz_timing_status.Source = new BitmapImage(new Uri("../Assets/image/arrow-right.png", UriKind.Relative));
            }

            else if (addQuiz_timing_box.Visibility == Visibility.Collapsed)
            {
                addQuiz_timing_box.Visibility = Visibility.Visible;
                addQuiz_timing_status.Source = new BitmapImage(new Uri("../Assets/image/arrow-down.png", UriKind.Relative));
            }
        }

        private void cancel_addQuiz_btn_click(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                mainWindow.AddToMap(new Course_list(), "My course", 0);
                // Truy cập đến thành phần có x:name="Iborder_menu" trong MainWindow và thay đổi giá trị
                mainWindow.Iborder_menu.Content = new Course_list();
                mainWindow.editBtn.Visibility = Visibility.Visible;
            }
        }
        private void ComboBox_Day() //tạo data từ 1 đến 31 cho combo box chỉ ngày
        {
            cb_opentime_day.Items.Add("Day");
            cb_closetime_day.Items.Add("Day");
            for (int i = 1; i <= 31; i++)
            {
                cb_opentime_day.Items.Add(i);
                cb_closetime_day.Items.Add(i);
            }
        }
        private void ComboBox_Month() //tạo data từ 1 đến 31 cho combo box chỉ tháng
        {
            DateTimeFormatInfo dateFormatInfo = new DateTimeFormatInfo();
            cb_opentime_month.Items.Add("Month");
            cb_closetime_month.Items.Add("Month");
            for (int month = 1; month <= 12; month++)
            {
                string monthName = dateFormatInfo.GetMonthName(month);
                cb_opentime_month.Items.Add(monthName);
                cb_closetime_month.Items.Add(monthName);
            }
        }
        private void ComboBox_Year()        //tạo data từ 1 đến 31 cho combo box chỉ năm
        {
            cb_opentime_year.Items.Add("Year");
            cb_closetime_year.Items.Add("Year");
            for (int i = 2020; i <= 2030; i++)
            {
                cb_opentime_year.Items.Add(i);
                cb_closetime_year.Items.Add(i);
            }
        }
        private void ComboBox_Hour()        //tạo data từ 1 đến 31 cho combo box chỉ giờ
        {
            cb_opentime_hour.Items.Add("Hours");
            cb_closetime_hour.Items.Add("Hours");
            for (int i = 1; i <= 24; i++)
            {
                cb_opentime_hour.Items.Add(i);
                cb_closetime_hour.Items.Add(i);
            }
        }
        private void ComboBox_Minute()      //tạo data từ 1 đến 31 cho combo box chỉ phút
        {
            cb_opentime_minute.Items.Add("Mins");
            cb_closetime_minute.Items.Add("Mins");
            cb_timelimit.Items.Add("Time");
            for (int i = 1; i <= 60; i++)
            {
                cb_opentime_minute.Items.Add(i);
                cb_closetime_minute.Items.Add(i);
                cb_timelimit.Items.Add(i);
            }
        }
        private void Window_Loaded()
        {
            ComboBox_Day();
            ComboBox_Month();
            ComboBox_Year();
            ComboBox_Hour();
            ComboBox_Minute();
        }
        private void displayDes_addquiz_check(object sender, RoutedEventArgs e)
        {

        }

        private void addQuiz_btn_click(object sender, RoutedEventArgs e)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.FullName;
            string quizPath = System.IO.Path.Combine(projectDirectory, "Quiz");
            quizPath = System.IO.Path.Combine(quizPath, quizName.Text+".txt");
            string quizContent = "";
            quizContent += "Quizname " + quizName.Text + "\n";
            quizContent += "Time ";
            int time = 0;
            if (cb_timelimit_enable.IsChecked == true)
            {
                time = cb_timelimit.SelectedIndex;
                if (cb_timelimit2.SelectedIndex == 1)
                {
                     time *= 60;
                }
                time *=60;
                quizContent += time.ToString();
            }

            quizContent += "\n";

            using (StreamWriter writer = new StreamWriter(quizPath))
            {
                writer.Write(quizContent);
            }
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                mainWindow.AddToMap(new Course_list(), "My course", 0);
                // Truy cập đến thành phần có x:name="Iborder_menu" trong MainWindow và thay đổi giá trị
                mainWindow.Iborder_menu.Content = new Course_list();
                mainWindow.editBtn.Visibility = Visibility.Visible;
            }

        }

        private void cb_timelimit_enable_Checked(object sender, RoutedEventArgs e)
        {
            cb_timelimit.IsEnabled = true;
            cb_timelimit2.IsEnabled = true;
        }

        private void cb_timelimit_enable_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_timelimit.IsEnabled = false;
            cb_timelimit2.IsEnabled = false;
        }
    }
}
