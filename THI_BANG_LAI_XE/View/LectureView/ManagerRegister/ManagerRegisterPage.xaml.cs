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

namespace THI_BANG_LAI_XE.View.LectureView.ManagerRegister
{
    /// <summary>
    /// Interaction logic for ManagerRegisterPage.xaml
    /// </summary>
    public partial class ManagerRegisterPage : Page
    {
        private Query _context;
        private ThiBangLaiXeContext _db;
        public ManagerRegisterPage()
        {
            InitializeComponent();
            _db = new ThiBangLaiXeContext();
            _context = new Query(_db);
            loadAllRegister();
            LoadLectureCourse();
        }



        public void loadAllRegister()
        {


            int courseId = int.Parse(ListCourse.SelectedValue == null ? "0" : ListCourse.SelectedValue + "");

            var list = _context.registrationDao.FilterRegistration(txtFUllName.Text, txtPhone.Text, courseId).OrderByDescending(a => a.DateCreated);
            var customList = from a in list
                             select new
                             {
                                 FullName = a.User.FullName,
                                 Email = a.User.Email,
                                 Phone = a.User.Phone,
                                 Date = a.DateCreated.ToString("dd-MMM-yyyy"),
                                 courseName = a.Course.CourseName,
                                 Status = a.Status == 1 ? "Accepted" : "Pendding",
                                 RegistID = a.RegistrationId
                             };
            DataStudent.ItemsSource = customList.ToList();

        }

        private void FilterByName(object sender, TextChangedEventArgs e)
        {
            loadAllRegister();
        }

        private void FilterByPhoneNumber(object sender, TextChangedEventArgs e)
        {
            loadAllRegister();
        }

        private void ListCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadAllRegister();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtFUllName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            ListCourse.SelectedIndex = 0;
            loadAllRegister();
        }

        private void LoadLectureCourse()
        {
            var courseList = _context.courseDao.GetCourseListBylectureId(LectureMainWindow.userLogedIn.UserId);
            courseList.Add(new Course { CourseId = 0, CourseName = "All", TeacherId = LectureMainWindow.userLogedIn.UserId, StartDate = DateOnly.FromDateTime(DateTime.Now), EndDate = DateOnly.FromDateTime(DateTime.Now), CreateDate = DateTime.Now });
            ListCourse.ItemsSource = courseList.OrderBy(c => c.CourseId);
            ListCourse.SelectedValuePath = "CourseId";
            ListCourse.DisplayMemberPath = "CourseName";
            ListCourse.SelectedIndex = 0;
        }

        private void DataStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dynamic registration = DataStudent.SelectedValue;
            if (registration != null)
            {
                var ConfirmRegistration = _context.registrationDao.getRegistedById((long)registration.RegistID);
                if (ConfirmRegistration != null)
                {
                    ConfirmRegistration confirmRegistration = new ConfirmRegistration(ConfirmRegistration);
                    confirmRegistration.Show();
                }
            }
        }
    }
}
