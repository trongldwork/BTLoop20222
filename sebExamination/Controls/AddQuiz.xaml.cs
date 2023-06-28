using System;
using System.Collections.Generic;
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
        }
        private void addQuiz_general_click(object sender, RoutedEventArgs e)
        {
            if (addQuiz_general_box.Visibility == Visibility.Visible)
            {
                addQuiz_general_box.Visibility = Visibility.Collapsed;
                addQuiz_general_status.Source = new BitmapImage(new Uri("../image/arrow-right.png", UriKind.Relative));
            }

            else if (addQuiz_general_box.Visibility == Visibility.Collapsed)
            {
                addQuiz_general_box.Visibility = Visibility.Visible;
                addQuiz_general_status.Source = new BitmapImage(new Uri("../image/arrow-down.png", UriKind.Relative));
            }
        }
        private void addQuiz_timing_click(object sender, RoutedEventArgs e)
        {
            if (addQuiz_timing_box.Visibility == Visibility.Visible)
            {
                addQuiz_timing_box.Visibility = Visibility.Collapsed;
                addQuiz_timing_status.Source = new BitmapImage(new Uri("../image/arrow-right.png", UriKind.Relative));
            }

            else if (addQuiz_timing_box.Visibility == Visibility.Collapsed)
            {
                addQuiz_timing_box.Visibility = Visibility.Visible;
                addQuiz_timing_status.Source = new BitmapImage(new Uri("../image/arrow-down.png", UriKind.Relative));
            }
        }
        private void displayDes_addquiz_check(object sender, RoutedEventArgs e)
        {

        }

        private void addQuiz_btn_click(object sender, RoutedEventArgs e)
        {

        }
        private void cancel_addQuiz_btn_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
