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
    /// Interaction logic for AddCoursePage.xaml
    /// </summary>
    public partial class AddCoursePage : Page
    {
        private Query? _context;
        private ThiBangLaiXeContext? _db;
        private User? _user;
        public AddCoursePage(User user)
        {
            InitializeComponent();
            _db = new ThiBangLaiXeContext();
            _user = user;
            _context = new Query(_db);
            loadAllDocumentaion();
        }

        // save course
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string StartD = txtDateStart.ToString();
            string EndD = txtDateEnd.ToString();
            string Coursename = txtCourseName.Text;
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
                        CourseName = Coursename,
                        StartDate = DateOnly.FromDateTime(DateTime.Parse(StartD)),
                        EndDate = DateOnly.FromDateTime(DateTime.Parse(EndD)),
                        TeacherId = _user.UserId
                    };
                    _context.courseDao.AddCourse(NewCourse);

                    var NewestCourse = _context.courseDao.GetNewestCourse();
                    AddDocument(NewestCourse.CourseId);
                    LectureMainWindow lectureMainWindow = (LectureMainWindow)Application.Current.MainWindow;
                    MessageBox.Show("đã thêm khóa học thành công!");
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

        private void loadAllDocumentaion()
        {
            DataExamPaper.Children.Clear();
            var ExpList = _context.examPaperDao.getExamPaperList();
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
                DataExamPaper.Children.Add(cb);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LectureMainWindow lectureMainWindow = (LectureMainWindow)Application.Current.MainWindow;
            lectureMainWindow.ContentFrame.Navigate(new CourseManagerPage(_user));
        }
    }
}
