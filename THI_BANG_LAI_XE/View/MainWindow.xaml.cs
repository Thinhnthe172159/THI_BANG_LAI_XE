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
using Microsoft.Identity.Client;
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
        public static User? userLogedIn;
        private Query _context;
        private ThiBangLaiXeContext _db;

        public MainWindow(User user)
        {
            userLogedIn = user;
            InitializeComponent();
            ContentFrame.Navigate(new HomePage());
            selectedButton = new Button();
            _db = new ThiBangLaiXeContext();
            _context = new Query(_db);
            LoadButton();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateButtonSelection((Button)sender);
            ContentFrame.Navigate(new CourseListPage());
        }
        // HomePage
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UpdateButtonSelection((Button)sender);
            ContentFrame.Navigate(new HomePage());
        }

        //User Profile
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            UpdateButtonSelection((Button)sender);
            ContentFrame.Navigate(new UserProfilePage());
        }

        // Exam
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var Registers = _context.registrationDao.getCourseRegistedByUserId(userLogedIn.UserId);
            if (Registers != null)
            {
                UpdateButtonSelection((Button)sender);
                ContentFrame.Navigate(new ExamListPage(Registers.Course));
            }
            else
            {
                MessageBox.Show("Hiện tại chưa có bài thi nào của khóa này");
            }



        }

        // notification
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            UpdateButtonSelection((Button)sender);
            ContentFrame.Navigate(new NotificaitonListPage());
        }


        public void LoadButton()
        {
            if (_context.registrationDao.checkRegistCourseExist(userLogedIn.UserId))
            {
                Button bt = new Button
                {
                    Content = "📃 Exams",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(2),
                    BorderThickness = new Thickness(0),
                    Background = (Brush?)new BrushConverter().ConvertFromString("#614bd4"),
                    Padding = new Thickness(5),
                    Foreground = new SolidColorBrush(Colors.White),
                };
                bt.Click += Button_Click_3;
                buttonList.Children.Add(bt);
            }
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

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();

        }
    }
}
