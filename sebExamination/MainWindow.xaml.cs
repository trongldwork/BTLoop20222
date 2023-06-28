using sebExamination.Controls;
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

namespace sebExamination
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int i = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty MenuContentControlProperty =
        DependencyProperty.Register("MenuContentControl", typeof(Menu_uc), typeof(MainWindow), new PropertyMetadata(null));

        public Menu_uc MenuContentControl
        {
            get { return (Menu_uc)GetValue(MenuContentControlProperty); }
            set { SetValue(MenuContentControlProperty, value); }
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
        private void QuestionBank_Click_question(object sender, RoutedEventArgs e)
        {
            border_menu.Visibility = Visibility.Visible;
            MenuContentControl = new Menu_uc();
            MenuContentControl.MainContentControl = new Question();
            Iborder_menu.Content = MenuContentControl; // Gán lại Iborder_menu.Content với MenuContentControl

        }
        private void QuestionBank_Click_categories(object sender, RoutedEventArgs e)
        {
            border_menu.Visibility = Visibility.Visible;
            MenuContentControl = new Menu_uc();
            MenuContentControl.MainContentControl = new Categories();
            Iborder_menu.Content = MenuContentControl; // Gán lại Iborder_menu.Content với MenuContentControl

        }
        private void QuestionBank_Click_import(object sender, RoutedEventArgs e)
        {
            border_menu.Visibility = Visibility.Visible;
            MenuContentControl = new Menu_uc();
            MenuContentControl.MainContentControl = new Import();
            Iborder_menu.Content = MenuContentControl; // Gán lại Iborder_menu.Content với MenuContentControl

        }
        private void QuestionBank_Click_export(object sender, RoutedEventArgs e)
        {
            border_menu.Visibility = Visibility.Visible;
            MenuContentControl = new Menu_uc();
            MenuContentControl.MainContentControl = new Export();
            Iborder_menu.Content = MenuContentControl; // Gán lại Iborder_menu.Content với MenuContentControl
        }
        private void ClickEditOn(object sender, RoutedEventArgs e)
        {
            border_menu.Visibility = Visibility.Visible;
            Iborder_menu.Content = new AddQuiz();
        }

        public class courseSource
        {
            public string courseName { get; set; }
        }



       
    }

    
}
