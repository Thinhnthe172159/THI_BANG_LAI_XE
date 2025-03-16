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

namespace THI_BANG_LAI_XE.View.LectureView.ManagerStudent
{
    /// <summary>
    /// Interaction logic for StudentManagerPage.xaml
    /// </summary>
    public partial class StudentManagerPage : Page
    {
        private User? _user;
        private Query? _context;
        private ThiBangLaiXeContext? _db;
        public StudentManagerPage(User user)
        {
            InitializeComponent();
            _user = user;
            _db = new ThiBangLaiXeContext();
            _context = new Query(_db);
            loadStudentList(user.UserId, string.Empty, string.Empty, 0, 1, 10);
        }

        private void FilterByName(object sender, TextChangedEventArgs e)
        {

        }

        private void FilterByPhoneNumber(object sender, TextChangedEventArgs e)
        {

        }

        private void loadStudentList(long userID, string StudentName, string PhoneNumber, int courseid, int page = 1, int pageSize = 10)
        {
            var studentList = _context.userDao.GetStudentlistRegistCourse(userID, StudentName, PhoneNumber, courseid, page, pageSize);
            DataStudent.ItemsSource = studentList;
            int NumberOfPage = studentList.PageCount;
            for (int i = 1; i <= NumberOfPage; i++)
            {
                Button bt = new Button
                {
                    Content = i,
                    Width = 20,
                    Height = 20,
                    Tag = i.ToString(),
                    Background = Brushes.Black,
                    Foreground = Brushes.White,
                };
                pagingStudent.Children.Add(bt);
            }
        }

        private void LoadLectureCourse()
        {

        }

        private void DataStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
