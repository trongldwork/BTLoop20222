
using sebExamination.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public static readonly DependencyProperty MenuContentControlProperty =
        DependencyProperty.Register("MenuContentControl", typeof(Menu_uc), typeof(MainWindow), new PropertyMetadata(null));

        public MainWindow()
        {
            InitializeComponent();
            Iborder_menu.Content = new Course_list();
        }


        public Menu_uc MenuContentControl
        {
            get { return (Menu_uc)GetValue(MenuContentControlProperty); }
            set { SetValue(MenuContentControlProperty, value); }
        }
        public void SwitchViewHome_Click(object sender, RoutedEventArgs e)
        {
            Iborder_menu.Content = new Course_list();
            editBtn.Visibility = Visibility.Visible;
            while(map.Children.Count > 2) map.Children.RemoveAt(map.Children.Count - 1);

        }

        private void SwitchViewCourse_Click(object sender, RoutedEventArgs e)
        {
            goTo(null, null ,new Course_list(), 1);
            editBtn.Visibility = Visibility.Visible;
        }
        
        private void ShowQuestionBank_Click(object sender, RoutedEventArgs e)
        {
            QuestionBank.IsOpen = true;
        }
        private void QuestionBank_Click_question(object sender, RoutedEventArgs e)
        {
            // Gọi hàm trong MainWindow từ UserControl
            AddToMap(new Question(), "Question", 1);
            MenuContentControl = new Menu_uc();
            MenuContentControl.MainContentControl = new Question();
            Iborder_menu.Content = MenuContentControl; // Gán lại Iborder_menu.Content với MenuContentControl
            editBtn.Visibility = Visibility.Collapsed;

        }
        private void QuestionBank_Click_categories(object sender, RoutedEventArgs e)
        {
            AddToMap(new Categories(), "Categories", 1);
            MenuContentControl = new Menu_uc();
            MenuContentControl.MainContentControl = new Categories();
            Iborder_menu.Content = MenuContentControl; // Gán lại Iborder_menu.Content với MenuContentControl
            editBtn.Visibility = Visibility.Collapsed;

        }
        private void QuestionBank_Click_import(object sender, RoutedEventArgs e)
        {
            AddToMap(new Import(), "Import", 1);  
            MenuContentControl = new Menu_uc();
            MenuContentControl.MainContentControl = new Import();
            Iborder_menu.Content = MenuContentControl; // Gán lại Iborder_menu.Content với MenuContentControl
            editBtn.Visibility = Visibility.Collapsed;

        }
        private void QuestionBank_Click_export(object sender, RoutedEventArgs e)
        {
            AddToMap(new Export(), "Export", 1);
            MenuContentControl = new Menu_uc();
            MenuContentControl.MainContentControl = new Export();
            Iborder_menu.Content = MenuContentControl; // Gán lại Iborder_menu.Content với MenuContentControl
            editBtn.Visibility = Visibility.Collapsed;
        }
        public void AddToMap(UserControl userControl, string name, int level)
        {
            for(int i = map.Children.Count-1; i>level; i-- )
            {
                map.Children.RemoveAt(i);
            }

            TextBlock map_course = new TextBlock()
            {
                Margin = new Thickness(10, 0, 0, 0)
            };

            Hyperlink hyperlink = new Hyperlink()
            {
                FontSize = 20,
                TextDecorations = null
            };
            hyperlink.Click += (sender, e) => goTo(sender, e, userControl, level+1); ;
            hyperlink.Inlines.Add('/'+name);

            map_course.Inlines.Add(hyperlink);
            map.Children.Add(map_course);
        }
        private void goTo(object sender, RoutedEventArgs e, UserControl userControl, int level)
        {
            for (int i = map.Children.Count - 1; i > level; i--)
            {
                map.Children.RemoveAt(i);
            }
            if (userControl is Question || userControl is Import || userControl is Categories || userControl is Export)
            {
                MenuContentControl = new Menu_uc();
                MenuContentControl.MainContentControl = userControl;
                Iborder_menu.Content = MenuContentControl;
            }
            else Iborder_menu.Content = userControl;
        }
        private void ClickEditOn(object sender, RoutedEventArgs e)
        {
            Iborder_menu.Content = new AddQuiz();
            editBtn.Visibility = Visibility.Collapsed;
        }

        public class courseSource
        {
            public string courseName { get; set; }

        }
    }
}
