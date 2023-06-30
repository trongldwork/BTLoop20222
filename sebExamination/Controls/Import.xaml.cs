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
    /// Interaction logic for Import.xaml
    /// </summary>
    public partial class Import : UserControl
    {
        public Import()
        {
            InitializeComponent();
        }

        public void OnDrop(object sender, DragEventArgs e)
        {

        }
        public void OnDragLeave(object sender, DragEventArgs e)
        {

        }
        public void OnDragEnter(object sender, DragEventArgs e)
        {

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
