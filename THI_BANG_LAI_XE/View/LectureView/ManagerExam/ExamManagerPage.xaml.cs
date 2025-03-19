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
using THI_BANG_LAI_XE.Dao;
using THI_BANG_LAI_XE.Models;

namespace THI_BANG_LAI_XE.View.LectureView.ManagerExam
{
    /// <summary>
    /// Interaction logic for ExamManagerPage.xaml
    /// </summary>
    public partial class ExamManagerPage : Page
    {

        private Query _context;
        private ThiBangLaiXeContext _db;
        private User _user;
        public ExamManagerPage(User user)
        {
            InitializeComponent();
            _user = user;
            _db = new ThiBangLaiXeContext();
            _context = new Query(_db);
            loadAllExam(string.Empty, 0, null);
            LoadAllCourse();
        }

        void loadAllExam(string Room, int courseId, DateOnly? DateStart)
        {
            DataExam.ItemsSource = _context.examDao.FilterExam(Room, courseId, DateStart);
        }

        private void LoadAllCourse()
        {
            var CourseList = _context.courseDao.GetCourseList();
            CourseList.Add(new Course { CourseId = 0, CourseName = "All", TeacherId = _user.UserId, StartDate = DateOnly.FromDateTime(DateTime.Now), EndDate = DateOnly.FromDateTime(DateTime.Now) });
            ListCourse.ItemsSource = CourseList.OrderBy(x => x.CourseId);
            ListCourse.SelectedValuePath = "CourseId";
            ListCourse.DisplayMemberPath = "CourseName";
            ListCourse.SelectedIndex = 0;

        }

        private void FilterByName(object sender, TextChangedEventArgs e)
        {
            DateOnly? dateS = !string.IsNullOrEmpty(txtDateStart.Text) ? DateOnly.FromDateTime(DateTime.Parse(txtDateStart.ToString())) : null;
            loadAllExam(txtRoomName.Text, int.Parse(ListCourse.SelectedValue + ""), dateS);
        }

        private void txtDateStart_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateOnly? dateS = !string.IsNullOrEmpty(txtDateStart.Text) ? DateOnly.FromDateTime(DateTime.Parse(txtDateStart.ToString())) : null;
            loadAllExam(txtRoomName.Text, int.Parse(ListCourse.SelectedValue + ""), dateS);
        }

        private void ListCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DateOnly? dateS = !string.IsNullOrEmpty(txtDateStart.Text) ? DateOnly.FromDateTime(DateTime.Parse(txtDateStart.ToString())) : null;
            loadAllExam(txtRoomName.Text, int.Parse(ListCourse.SelectedValue + ""), dateS);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            LectureMainWindow lectureMainWindow = (LectureMainWindow)Application.Current.MainWindow;
            lectureMainWindow.ContentFrame.Navigate(new AddExamPage(_user));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtRoomName.Text = string.Empty;
            txtDateStart.SelectedDate = null;
            ListCourse.SelectedIndex = 0;
            loadAllExam(string.Empty, 0, null);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (sender is Button bt && bt.DataContext is Exam exam)
            {
                LectureMainWindow lectureMainWindow = (LectureMainWindow)Application.Current.MainWindow;
                lectureMainWindow.ContentFrame.Navigate(new DetailExamPage(_user, exam));
            }
        }
    }
}
