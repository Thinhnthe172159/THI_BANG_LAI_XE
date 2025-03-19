using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
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
using THI_BANG_LAI_XE.Dao;
using THI_BANG_LAI_XE.Models;

namespace THI_BANG_LAI_XE.View.LectureView.ManagerStudent
{
    /// <summary>
    /// Interaction logic for StudentManagerPage.xaml
    /// </summary>
    public partial class StudentManagerPage : Page
    {
        private User _user;
        private Query _context;
        private ThiBangLaiXeContext _db;
        public StudentManagerPage(User user)
        {
            InitializeComponent();
            _user = user;
            _db = new ThiBangLaiXeContext();
            _context = new Query(_db);
            loadStudentList(user.UserId, string.Empty, string.Empty, 0, 1, 1);
            LoadLectureCourse();
        }

        private void FilterByName(object sender, TextChangedEventArgs e)
        {
            loadStudentList(_user.UserId, txtFUllName.Text, txtPhone.Text, int.Parse(ListCourse.SelectedValue + ""), 1, 1);
        }

        private void FilterByPhoneNumber(object sender, TextChangedEventArgs e)
        {
            loadStudentList(_user.UserId, txtFUllName.Text, txtPhone.Text, int.Parse(ListCourse.SelectedValue + ""), 1, 1);
        }

        private void loadStudentList(long userID, string StudentName, string PhoneNumber, int courseid, int page = 1, int pageSize = 1)
        {
            var studentList = _context.userDao.GetStudentlistRegistCourse(userID, StudentName, PhoneNumber, courseid, page, pageSize);
            DataStudent.ItemsSource = studentList;
            int NumberOfPage = studentList.PageCount;
            pagingStudent.Children.Clear();
            for (int i = 1; i <= NumberOfPage; i++)
            {
                Button bt = new Button
                {
                    Content = i,
                    Width = 20,
                    Height = 20,
                    Tag = i.ToString(),
                };
                if (i == page)
                {
                    bt.Background = Brushes.Black;
                    bt.Foreground = Brushes.White;
                }
                bt.Click += SelectPage;
                pagingStudent.Children.Add(bt);
            }
        }

        private void SelectPage(object sender, RoutedEventArgs e)
        {
            if (sender is Button bt)
            {
                int Page = int.Parse(bt.Tag + "");
                loadStudentList(_user.UserId, txtFUllName.Text, txtPhone.Text, int.Parse(ListCourse.SelectedValue + ""), Page, 1);
            }
        }

        private void LoadLectureCourse()
        {
            var courseList = _context.courseDao.GetCourseListBylectureId(_user.UserId);
            courseList.Add(new Course { CourseId = 0, CourseName = "All", TeacherId = _user.UserId, StartDate = DateOnly.FromDateTime(DateTime.Now), EndDate = DateOnly.FromDateTime(DateTime.Now), CreateDate = DateTime.Now });
            ListCourse.ItemsSource = courseList.OrderBy(c => c.CourseId);
            ListCourse.SelectedValuePath = "CourseId";
            ListCourse.DisplayMemberPath = "CourseName";
            ListCourse.SelectedIndex = 0;
        }

        private void DataStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadStudentList(_user.UserId, txtFUllName.Text, txtPhone.Text, int.Parse(ListCourse.SelectedValue + ""), 1, 1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtFUllName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            ListCourse.SelectedIndex = 0;
            loadStudentList(_user.UserId, string.Empty, string.Empty, 0, 1, 1);
        }
    }
}
