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
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using THI_BANG_LAI_XE.Dao;
using THI_BANG_LAI_XE.Models;

namespace THI_BANG_LAI_XE.View.RegistrationView
{
    /// <summary>
    /// Interaction logic for CourseRegisForm.xaml
    /// </summary>
    public partial class CourseRegisForm : Window
    {
        private ThiBangLaiXeContext _db;
        private Query _context;
        private Course course;
        public CourseRegisForm(Course c)
        {
            InitializeComponent();
            _db = new ThiBangLaiXeContext();
            _context = new Query(_db);
            course = c;
            loadInforForm();
        }

        void loadInforForm()
        {
            txtName.Text = MainWindow.userLogedIn.FullName;
            txtPhone.Text = MainWindow.userLogedIn.Phone;
            txtEmail.Text = MainWindow.userLogedIn.Email;
            txtCourse.Text = course.CourseName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var register = new Registration
            {
                CourseId = course.CourseId,
                UserId = MainWindow.userLogedIn.UserId,
                Comments = txtMessage.Text,
                Status = 0
            };
            try
            {
                _context.registrationDao.AddRigistration(register);
                MessageBox.Show("Hệ thống đã nhận được đăng ký của bạn, vui lòng chờ duyệt đăng ký.");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Hệ thống đã xảy ra lỗi khi đăng ký khóa học cho bạn, vui lòng thử lại sau!");
            }
        }
    }
}
