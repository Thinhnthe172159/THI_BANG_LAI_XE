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
using Microsoft.Identity.Client;
using THI_BANG_LAI_XE.Dao;
using THI_BANG_LAI_XE.Models;

namespace THI_BANG_LAI_XE.View.LectureView.ManagerCourse
{
    /// <summary>
    /// Interaction logic for CourseManagerPage.xaml
    /// </summary>
    public partial class CourseManagerPage : Page
    {
        private Query? _context;
        private ThiBangLaiXeContext? _db;
        private User? _user;
        public CourseManagerPage(User user)
        {
            InitializeComponent();
            _db = new ThiBangLaiXeContext();
            _user = user;
            _context = new Query(_db);
            loadCourseList(user.UserId, string.Empty, null, null);
        }

        private void loadCourseList(long userId, string CourseName, DateOnly? dateStart, DateOnly? dateEnd)
        {
            var courseList = _context.courseDao.FilterCourse(userId, CourseName, dateStart, dateEnd);
            DataCourse.ItemsSource = courseList;
        }

        private void FilterByName(object sender, TextChangedEventArgs e)
        {
            DateOnly? dateS = !string.IsNullOrEmpty(txtDateStart.Text) ? DateOnly.FromDateTime(DateTime.Parse(txtDateStart.ToString())) : null;
            DateOnly? dateE = !string.IsNullOrEmpty(txtDateEnd.Text) ? DateOnly.FromDateTime(DateTime.Parse(txtDateEnd.ToString())) : null;
            loadCourseList(_user.UserId, txtCourseName.Text, dateS, dateE);
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateOnly? dateS = !string.IsNullOrEmpty(txtDateStart.Text) ? DateOnly.FromDateTime(DateTime.Parse(txtDateStart.ToString())) : null;
            DateOnly? dateE = !string.IsNullOrEmpty(txtDateEnd.Text) ? DateOnly.FromDateTime(DateTime.Parse(txtDateEnd.ToString())) : null;
            loadCourseList(_user.UserId, txtCourseName.Text, dateS, dateE);
        }

        private void DatePicker_SelectedDateChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DateOnly? dateS = !string.IsNullOrEmpty(txtDateStart.Text) ? DateOnly.FromDateTime(DateTime.Parse(txtDateStart.ToString())) : null;
            DateOnly? dateE = !string.IsNullOrEmpty(txtDateEnd.Text) ? DateOnly.FromDateTime(DateTime.Parse(txtDateEnd.ToString())) : null;
            loadCourseList(_user.UserId, txtCourseName.Text, dateS, dateE);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtCourseName.Text = string.Empty;
            txtDateEnd.Text = string.Empty;
            txtDateStart.Text = string.Empty;
            loadCourseList(_user.UserId, string.Empty, null, null);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Course selectedCourse)
            {
                LectureMainWindow lectureMainWindow = (LectureMainWindow)Application.Current.MainWindow;
                lectureMainWindow.ContentFrame.Navigate(new CourseDetail(_user, selectedCourse));
            }
        }   

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            LectureMainWindow lectureMainWindow = (LectureMainWindow)Application.Current.MainWindow;
            lectureMainWindow.ContentFrame.Navigate(new AddCoursePage(_user));
        }
    }
}
