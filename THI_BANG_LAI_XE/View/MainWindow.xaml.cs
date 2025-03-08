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
using System.Windows.Shapes;
using THI_BANG_LAI_XE.Dao;
using THI_BANG_LAI_XE.Models;
using THI_BANG_LAI_XE.View.ExamView;
using THI_BANG_LAI_XE.View.NotificationView;

namespace THI_BANG_LAI_XE.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Button selectedButton;

        public MainWindow()
        {
            InitializeComponent();
            ContentFrame.Navigate(new HomePage());
            selectedButton = new Button();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateButtonSelection((Button)sender);
            ContentFrame.Navigate(new CourseListPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UpdateButtonSelection((Button)sender);
            ContentFrame.Navigate(new HomePage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            UpdateButtonSelection((Button)sender);
            ContentFrame.Navigate(new UserProfilePage());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            UpdateButtonSelection((Button)sender);
            ContentFrame.Navigate(new ExamListPage());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            UpdateButtonSelection((Button)sender);
            ContentFrame.Navigate(new NotificaitonListPage());
        }

        private void UpdateButtonSelection(Button clickedButton)
        {
            if (selectedButton != null)
            {
                selectedButton.Background = (Brush?)new BrushConverter().ConvertFromString("#614bd4");
            }
            clickedButton.Background = (Brush?)new BrushConverter().ConvertFromString("#816fd4");
            selectedButton = clickedButton;
        }

    }
}
