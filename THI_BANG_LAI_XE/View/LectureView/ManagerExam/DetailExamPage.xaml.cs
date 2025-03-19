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
    /// Interaction logic for DetailExamPage.xaml
    /// </summary>
    public partial class DetailExamPage : Page
    {

        private Query _context;
        private ThiBangLaiXeContext _db;
        private User _user;
        private Exam _exam;
        public DetailExamPage(User user, Exam ex)
        {
            InitializeComponent();
            _db = new ThiBangLaiXeContext();
            _user = user;
            _context = new Query(_db);
            _exam = ex;
            LoadExam(ex);
            loadAllExamPaper();
        }

        //load all Exampaper signed


        private void loadAllExamPaper()
        {
            DataExamPaper.Children.Clear();
            var ExpList = _context.examPaperDao.getExamPaperList();
            var Exam = _context.examDao.GetExamById(_exam.ExamId);
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
                if (Exam.ExamPapers.Where(ex => ex.ExamPaperId == ExpList[i].ExamPaperId).Count() == 1)
                {
                    cb.IsChecked = true;
                }
                DataExamPaper.Children.Add(cb);
            }
        }

        private void LoadExam(Exam c)
        {
            txtRoomName.Text = c.Room;
            txtDateStart.SelectedDate = DateTime.Parse(c.Date + "");

            var CourseList = _context.courseDao.GetCourseList();
            CourseList.Add(new Course { CourseId = 0, CourseName = "All", TeacherId = _user.UserId, StartDate = DateOnly.FromDateTime(DateTime.Now), EndDate = DateOnly.FromDateTime(DateTime.Now) });
            List<Course> listc = CourseList.OrderBy(x => x.CourseId).ToList();
            ListCourse.ItemsSource = listc;
            ListCourse.SelectedValuePath = "CourseId";
            ListCourse.DisplayMemberPath = "CourseName";
            var courseSelected = _context.courseDao.GetCourseById(c.CourseId);
            if (courseSelected != null)
            {
                ListCourse.SelectedIndex = listc.IndexOf(courseSelected);
            }
        }

        private void AddExamPaper(int examId)
        {
            foreach (var child in DataExamPaper.Children)
            {
                if (child is CheckBox rb && rb.Tag is ExamPaper selectedExamPaper)
                {
                    if (rb.IsChecked == true)
                    {
                        _context.examDao.AddExamPaperToExam(examId, selectedExamPaper);
                    }
                    else
                    {
                        _context.examDao.RemoveExamPaperToExam(examId, selectedExamPaper);
                    }
                }
            }
        }


        //Add as new
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string StartD = txtDateStart.ToString();
            int courseId = int.Parse(ListCourse.SelectedValue.ToString());
            if (string.IsNullOrEmpty(StartD))
            {
                MessageBox.Show("Ngày bắt đầu không được trống");
            }
            else if (courseId == 0)
            {
                MessageBox.Show("Cân gán khóa học cụ thể cho bài kiểm tra này!");
            }
            else if (string.IsNullOrEmpty(txtRoomName.Text))
            {
                MessageBox.Show("Tên phòng không được trống");
            }
            else
            {
                try
                {
                    var Exam = new Exam { CourseId = courseId, Room = txtRoomName.Text, Date = DateOnly.FromDateTime(DateTime.Parse(StartD)) };
                    _context.examDao.AddExam(Exam);
                    var newestExam = _context.examDao.getNewestExamByCourseId(courseId);
                    if (newestExam != null)
                    {
                        AddExamPaper(newestExam.ExamId);
                        MessageBox.Show("Đã thêm bài kiểm tra");
                        LectureMainWindow lectureMainWindow = (LectureMainWindow)Application.Current.MainWindow;
                        lectureMainWindow.ContentFrame.Navigate(new ExamManagerPage(_user));

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Đã xảy ra sự cố khi thêm mới bài kiểm tra");
                }
            }
        }

        // remove
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            try
            {
                if (MessageBox.Show("Bạn có muốn bài kiểm tra này không?", "Xóa bài kiểm tra", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _context.examDao.removeAllExamPaperOfExam(_exam.ExamId);
                    _context.examDao.RemoveExam(_exam.ExamId);
                    LectureMainWindow lectureMainWindow = (LectureMainWindow)Application.Current.MainWindow;
                    lectureMainWindow.ContentFrame.Navigate(new ExamManagerPage(_user));
                    MessageBox.Show("Đã xóa bài kiểm tra!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("KHông thể xóa bài kiểm tra tại thời điểm này");
            }
        }

        //save
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string StartD = txtDateStart.ToString();
            int courseId = int.Parse(ListCourse.SelectedValue.ToString());
            if (string.IsNullOrEmpty(StartD))
            {
                MessageBox.Show("Ngày bắt đầu không được trống");
            }
            else if (courseId == 0)
            {
                MessageBox.Show("Cân gán khóa học cụ thể cho bài kiểm tra này!");
            }
            else if (string.IsNullOrEmpty(txtRoomName.Text))
            {
                MessageBox.Show("Tên phòng không được trống");
            }
            else
            {
                try
                {
                    _exam.CourseId = courseId;
                    _exam.Room = txtRoomName.Text;
                    _exam.Date = DateOnly.FromDateTime(DateTime.Parse(StartD));
                    _context.examDao.UpdateExam(_exam);
                    AddExamPaper(_exam.ExamId);
                    MessageBox.Show("Đã cập nhật bài kiểm tra");
                    LectureMainWindow lectureMainWindow = (LectureMainWindow)Application.Current.MainWindow;
                    lectureMainWindow.ContentFrame.Navigate(new ExamManagerPage(_user));
                }
                catch (Exception)
                {
                    MessageBox.Show("Đã xảy ra sự cố khi cập nhật bài kiểm tra");
                }
            }
        }
        // back page
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LectureMainWindow lectureMainWindow = (LectureMainWindow)Application.Current.MainWindow;
            lectureMainWindow.ContentFrame.Navigate(new ExamManagerPage(_user));
        }
    }
}
