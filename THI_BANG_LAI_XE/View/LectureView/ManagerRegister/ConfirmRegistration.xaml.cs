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
using THI_BANG_LAI_XE.Dao;
using THI_BANG_LAI_XE.Models;

namespace THI_BANG_LAI_XE.View.LectureView.ManagerRegister
{
    /// <summary>
    /// Interaction logic for ConfirmRegistration.xaml
    /// </summary>
    public partial class ConfirmRegistration : Window
    {
        private Registration registration;
        private Query _context;
        private ThiBangLaiXeContext _db;
        public ConfirmRegistration(Registration re)
        {
            _db = new ThiBangLaiXeContext();
            _context = new Query(_db);
            InitializeComponent();
            registration = re;
            LoadContent();
        }

        void LoadContent()
        {
            txtName.Text = registration.User.FullName;
            txtCourse.Text = registration.Course.CourseName;
            txtEmail.Text = registration.User.Email;
            txtPhone.Text = registration.User.Phone;
            txtMessage.Text = registration.Comments;
        }

        private void Accept(object sender, RoutedEventArgs e)
        {
            var regis = _context.registrationDao.getRegistedById(registration.RegistrationId);
            if (regis != null)
            {
                try
                {
                    regis.Status = 1;
                    _context.registrationDao.UpdateRegistration(regis);
                    MessageBox.Show("Đã duyệt yêu cầu đăng ký khóa học!");
                    this.Close();
                    LectureMainWindow lectureMainWindow = (LectureMainWindow)Application.Current.MainWindow;
                    lectureMainWindow.ContentFrame.Navigate(new ManagerRegisterPage());

                }
                catch (Exception)
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình duyệt!");
                }
            }
        }

        private void denine(object sender, RoutedEventArgs e)
        {
            var regis = _context.registrationDao.getRegistedById(registration.RegistrationId);
            if (regis != null)
            {
                try
                {
                    regis.Status = 0;
                    _context.registrationDao.UpdateRegistration(regis);
                    MessageBox.Show("Đã từ chối đăng ký đối với người dùng này!");
                    this.Close();
                    LectureMainWindow lectureMainWindow = (LectureMainWindow)Application.Current.MainWindow;
                    lectureMainWindow.ContentFrame.Navigate(new ManagerRegisterPage());
                }
                catch (Exception)
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình duyệt!");
                }
            }
        }
    }
}
