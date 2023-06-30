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
    /// Interaction logic for AddQuestion.xaml
    /// </summary>
    public partial class AddQuestion : UserControl
    {
        public AddQuestion()
        {
            InitializeComponent();
        }
        private void addQuestion_general_click(object sender, RoutedEventArgs e)
        {

        }
        private void saveChangeAndContinue_addQuestion_btn_click(object sender, RoutedEventArgs e)
        {

        }
        private void saveChange_addQuestion_btn_click(object sender, RoutedEventArgs e)
        {

        }
        private void cancel_addQuestion_btn_click(object sender, RoutedEventArgs e)
        {

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

            choice_addQuestion.Children.Add(textBlock1);
            choice_addQuestion.Children.Add(textBlock2);
            choice_addQuestion.Children.Add(textBox);
            choice_addQuestion.Children.Add(comboBox);

            Choices.Children.Add(choice_addQuestion);
        }
    }
}
