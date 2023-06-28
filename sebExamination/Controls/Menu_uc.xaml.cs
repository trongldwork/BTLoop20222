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

namespace sebExamination.Controls
{
    /// <summary>
    /// Interaction logic for Menu_uc.xaml
    /// </summary>
    public partial class Menu_uc : UserControl
    {

        public Menu_uc()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty MainContentControlProperty =
        DependencyProperty.Register("MainContentControl", typeof(UserControl), typeof(Menu_uc), new PropertyMetadata(null));

        public UserControl MainContentControl
        {
            get { return (UserControl)GetValue(MainContentControlProperty); }
            set { SetValue(MainContentControlProperty, value); }
        }

        public void Question_click(object sender, RoutedEventArgs e)
        {
            MainContentControl = new Question();
        }
        public void Categories_click(object sender, RoutedEventArgs e)
        {
            MainContentControl = new Categories();
        }
        public void Import_click(object sender, RoutedEventArgs e)
        {
            MainContentControl = new Import();
        }
        public void Export_click(object sender, RoutedEventArgs e)
        {
            MainContentControl = new Export();
        }
    }
}
