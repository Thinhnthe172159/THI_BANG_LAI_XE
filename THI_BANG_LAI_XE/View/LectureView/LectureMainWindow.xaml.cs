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
using THI_BANG_LAI_XE.View.LectureView.ManagerExam;
using THI_BANG_LAI_XE.View.LectureView.ManagerExamPaper;
using THI_BANG_LAI_XE.View.LectureView.ManagerRegister;

namespace THI_BANG_LAI_XE.View.LectureView
{
    /// <summary>
    /// Interaction logic for LectureMainWindow.xaml
    /// </summary>
    public partial class LectureMainWindow : Window
    {
        private Button selectedButton;
        public static User userLogedIn;
        private Query _context;
        private ThiBangLaiXeContext _db;
        public AddExamPaper? AddExamPaper { get; set; }
        public ManagerRegisterPage? managerRegisterPage { get; set; }

        public LectureMainWindow(User user)
        {
            userLogedIn = user;
            InitializeComponent();
            selectedButton = new Button();
            _db = new ThiBangLaiXeContext();
            _context = new Query(_db);
            selectedButton = new Button();
        }


        private void HomeButton(object sender, RoutedEventArgs e)
        {
            UpdateButtonSelection((Button)sender);
            LectureMainWindow lectureMainWindow = (LectureMainWindow)Application.Current.MainWindow;
            lectureMainWindow.ContentFrame.Navigate(new HomePage(userLogedIn.FullName));
        }

        private void ProfileButton(object sender, RoutedEventArgs e)
        {
            UpdateButtonSelection((Button)sender);
            LectureMainWindow lectureMainWindow = (LectureMainWindow)Application.Current.MainWindow;
            lectureMainWindow.ContentFrame.Navigate(new UserProfilePage(userLogedIn));
        }

        private void StudentButton(object sender, RoutedEventArgs e)
        {
            UpdateButtonSelection((Button)sender);
            LectureMainWindow lectureMainWindow = (LectureMainWindow)Application.Current.MainWindow;
            lectureMainWindow.ContentFrame.Navigate(new ManagerStudent.StudentManagerPage(userLogedIn));
        }

        private void CourseButton(object sender, RoutedEventArgs e)
        {
            UpdateButtonSelection((Button)sender);
            LectureMainWindow lectureMainWindow = (LectureMainWindow)Application.Current.MainWindow;
            lectureMainWindow.ContentFrame.Navigate(new ManagerCourse.CourseManagerPage(userLogedIn));
        }

        private void ExamPaperButton(object sender, RoutedEventArgs e)
        {
            UpdateButtonSelection((Button)sender);
            LectureMainWindow lectureMainWindow = (LectureMainWindow)Application.Current.MainWindow;
            lectureMainWindow.ContentFrame.Navigate(new ManagerExamPaper.ManagerExamPaperPage());
        }

        private void ExamButton(object sender, RoutedEventArgs e)
        {
            UpdateButtonSelection((Button)sender);
            LectureMainWindow lectureMainWindow = (LectureMainWindow)Application.Current.MainWindow;
            lectureMainWindow.ContentFrame.Navigate(new ManagerExam.ExamManagerPage(userLogedIn));
        }

        private void NotificationButton(object sender, RoutedEventArgs e)
        {
            UpdateButtonSelection((Button)sender);
            LectureMainWindow lectureMainWindow = (LectureMainWindow)Application.Current.MainWindow;
            lectureMainWindow.ContentFrame.Navigate(new NotificationView.NotificaitonListPage(userLogedIn));
        }

        // log out
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
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

        private void CourseRegistButton(object sender, RoutedEventArgs e)
        {
            LectureMainWindow lectureMainWindow = (LectureMainWindow)Application.Current.MainWindow;
            managerRegisterPage = new ManagerRegisterPage();
            lectureMainWindow.ContentFrame.Navigate(managerRegisterPage);
        }
    }
}
