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

namespace THI_BANG_LAI_XE.View.RegistrationView
{
    /// <summary>
    /// Interaction logic for CourseRegistrationPage.xaml
    /// </summary>
    public partial class CourseRegistrationPage : Page
    {
        private ThiBangLaiXeContext _db;
        private Query _context;
        public CourseRegistrationPage()
        {
            InitializeComponent();
            _db = new ThiBangLaiXeContext();
            _context = new Query(_db);
            LoadAllCourse();

        }

        void LoadAllCourse()
        {
            this.DataCourse.ItemsSource = _context.courseDao.FilterCourse(txtCourseName.Text);
        }

        private void RegistCourse(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Course selectedCourse)
            {
                var SelectedCourse = _context.courseDao.GetCourseById(selectedCourse.CourseId);
                if (selectedCourse != null)
                {
                    if (!_context.registrationDao.IsCourseRegisted(MainWindow.userLogedIn.UserId, selectedCourse.CourseId)
                        && selectedCourse.StartDate <= DateOnly.FromDateTime(DateTime.Now)
                        && selectedCourse.EndDate > DateOnly.FromDateTime(DateTime.Now))
                    {
                        CourseRegisForm courseRegisForm = new CourseRegisForm(selectedCourse);
                        courseRegisForm.Show();
                    }
                    else if (selectedCourse.StartDate > DateOnly.FromDateTime(DateTime.Now))
                    {
                        MessageBox.Show("Khóa học chưa bắt đầu!");
                    }
                    else if (selectedCourse.EndDate < DateOnly.FromDateTime(DateTime.Now))
                    {
                        MessageBox.Show("Khóa học đã kết thúc!");
                    }
                    else
                    {
                        MessageBox.Show("Bạn đã đăng ký khóa học này rồi!");
                    }
                }
                if (SelectedCourse == null)
                {
                    MessageBox.Show("Khóa học không tồn tại!");
                }
            }
        }

        private void txtCourseName_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadAllCourse();
        }
    }
}
