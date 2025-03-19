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

namespace THI_BANG_LAI_XE.View.LectureView.ManagerCourse
{
    /// <summary>
    /// Interaction logic for CourseDetail.xaml
    /// </summary>
    public partial class CourseDetail : Page
    {
        private Query? _context;
        private ThiBangLaiXeContext? _db;
        private User? _user;
        private Course _course;
        public CourseDetail(User user, Course c)
        {
            InitializeComponent();
            _db = new ThiBangLaiXeContext();
            _user = user;
            _context = new Query(_db);
            _course = c;
            LoadCourse(c);
            loadAllDocumentaion();
        }

        private void LoadCourse(Course c)
        {
            txtCourseName.Text = c.CourseName;
            txtDateStart.SelectedDate = DateTime.Parse(c.StartDate.ToString());
            txtDateEnd.SelectedDate = DateTime.Parse(c.EndDate.ToString());
        }

        private void loadAllDocumentaion()
        {
            DataExamPaper.Children.Clear();
            var ExpList = _context.examPaperDao.getExamPaperList();
            var course = _context.courseDao.GetCourseById(_course.CourseId);
            for (int i = 0; i < ExpList.Count; i++)
            {
                CheckBox cb = new CheckBox
                {
                    Tag = ExpList[i],
                    Content = ExpList[i].ExamPaperName + "      " + ExpList[i].CreateDate,
                    FontSize = 16,
                    Height = 16,
                    Background = Brushes.WhiteSmoke
                };
                if (course.ExamPapers.Where(ex => ex.ExamPaperId == ExpList[i].ExamPaperId).Count() == 1)
                {
                    cb.IsChecked = true;
                }
                DataExamPaper.Children.Add(cb);
            }
        }

        // back to course
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LectureMainWindow lectureMainWindow = (LectureMainWindow)Application.Current.MainWindow;
            lectureMainWindow.ContentFrame.Navigate(new CourseManagerPage(_user));
        }

        // save update course
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string StartD = txtDateStart.ToString();
            string EndD = txtDateEnd.ToString();
            string Coursename = txtCourseName.ToString();
            if (string.IsNullOrEmpty(StartD))
            {
                MessageBox.Show("Ngày bắt đầu không được trống");
            }
            else if (string.IsNullOrEmpty(EndD))
            {
                MessageBox.Show("Ngày kết thúc không được trống");
            }
            else if (string.IsNullOrEmpty(txtCourseName.Text))
            {
                MessageBox.Show("Tên khóa không được trống");
            }
            else
            {
                if (DateOnly.FromDateTime(DateTime.Parse(StartD)) >= DateOnly.FromDateTime(DateTime.Parse(EndD)))
                {
                    MessageBox.Show("Ngày bắt đầu không được sau ngày kết thúc");
                }
                else
                {
                    var course = _context.courseDao.GetCourseById(_course.CourseId);
                    course.CourseName = txtCourseName.Text;
                    course.StartDate = DateOnly.FromDateTime(DateTime.Parse(txtDateStart.ToString()));
                    course.EndDate = DateOnly.FromDateTime(DateTime.Parse(txtDateEnd.ToString()));
                    _context.courseDao.UpdateCourse(course);
                    AddDocument(_course.CourseId);
                    LectureMainWindow lectureMainWindow = (LectureMainWindow)Application.Current.MainWindow;
                    MessageBox.Show("đã cập nhật khóa học");
                    lectureMainWindow.ContentFrame.Navigate(new CourseManagerPage(_user));

                }
            }
        }

        private void AddDocument(int courseId)
        {
            foreach (var child in DataExamPaper.Children)
            {
                if (child is CheckBox rb && rb.Tag is ExamPaper selectedExamPaper)
                {
                    if (rb.IsChecked == true)
                    {
                        _context.courseDao.AddExamPaperToCourse(courseId, selectedExamPaper);
                    }
                    else
                    {
                        _context.courseDao.RemoveExamPaperToCourse(courseId, selectedExamPaper);
                    }
                }
            }
        }

        // add new course  
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string StartD = txtDateStart.ToString();
            string EndD = txtDateEnd.ToString();
            string Coursename = txtCourseName.ToString();
            if (string.IsNullOrEmpty(StartD))
            {
                MessageBox.Show("Ngày bắt đầu không được trống");
            }
            else if (string.IsNullOrEmpty(EndD))
            {
                MessageBox.Show("Ngày kết thúc không được trống");
            }
            else if (string.IsNullOrEmpty(txtCourseName.Text))
            {
                MessageBox.Show("Tên khóa không được trống");
            }
            else
            {
                if (DateOnly.FromDateTime(DateTime.Parse(StartD)) >= DateOnly.FromDateTime(DateTime.Parse(EndD)))
                {
                    MessageBox.Show("Ngày bắt đầu không được sau ngày kết thúc");
                }
                else
                {
                    var NewCourse = new Course
                    {
                        CourseName = txtCourseName.Text,
                        StartDate = DateOnly.FromDateTime(DateTime.Parse(StartD)),
                        EndDate = DateOnly.FromDateTime(DateTime.Parse(EndD)),
                        TeacherId = _user.UserId
                    };
                    _context.courseDao.AddCourse(NewCourse);

                    var NewestCourse = _context.courseDao.GetNewestCourse(_user.UserId);
                    AddDocument(NewestCourse.CourseId);
                    LectureMainWindow lectureMainWindow = (LectureMainWindow)Application.Current.MainWindow;
                    MessageBox.Show("đã thêm khóa học thành công!");
                    lectureMainWindow.ContentFrame.Navigate(new CourseManagerPage(_user));
                }
            }
        }

        // remove course
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa khóa học này không?", "Xóa khóa học", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _context.courseDao.removeAllExamPaperOfCourse(_course.CourseId);
                    _context.courseDao.RemoveCourse(_course.CourseId);
                    LectureMainWindow lectureMainWindow = (LectureMainWindow)Application.Current.MainWindow;
                    lectureMainWindow.ContentFrame.Navigate(new CourseManagerPage(_user));
                    MessageBox.Show("đã xóa khóa học!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
