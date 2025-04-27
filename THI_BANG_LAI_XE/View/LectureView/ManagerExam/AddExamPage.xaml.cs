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
    /// Interaction logic for AddExamPage.xaml
    /// </summary>
    public partial class AddExamPage : Page
    {
        private Query _context;
        private ThiBangLaiXeContext _db;
        private User _user;
        public AddExamPage(User user)
        {
            InitializeComponent();
            _db = new ThiBangLaiXeContext();
            _user = user;
            _context = new Query(_db);
            loadAllExamPaper();
            LoadCourse();
        }

        private void loadAllExamPaper()
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

        private void LoadCourse()
        {
            var CourseList = _context.courseDao.GetCourseList();
            CourseList.Add(new Course { CourseId = 0, CourseName = "All", TeacherId = _user.UserId, StartDate = DateOnly.FromDateTime(DateTime.Now), EndDate = DateOnly.FromDateTime(DateTime.Now) });
            ListCourse.ItemsSource = CourseList.OrderBy(x => x.CourseId).ToList();
            ListCourse.SelectedValuePath = "CourseId";
            ListCourse.DisplayMemberPath = "CourseName";
            ListCourse.SelectedIndex = 0;
        }

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
                        var studentList = _context.userDao.getStudentListInCourseId(_user.UserId, courseId);
                        foreach (var student in studentList)
                        {
                            var notification = new Notification
                            {
                                Sender = _user.UserId,
                                Receiver = student.UserId,
                                Title = "(QUAN TRỌNG) Lịch thi bằng lái xe!",
                                Content = $"Đã có lịch thi bằng lái xe vào thời điểm {newestExam.Date}, Vui lòng chú ý thời điểm thi."
                            };
                            _context.notificationDao.AddNotification(notification);
                        }
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LectureMainWindow lectureMainWindow = (LectureMainWindow)Application.Current.MainWindow;
            lectureMainWindow.ContentFrame.Navigate(new ExamManagerPage(_user));
        }
    }
}
