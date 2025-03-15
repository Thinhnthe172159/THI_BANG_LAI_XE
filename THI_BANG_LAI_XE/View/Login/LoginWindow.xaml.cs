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
using THI_BANG_LAI_XE.View;

namespace THI_BANG_LAI_XE
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Password;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            using (var _context = new ThiBangLaiXeContext())
            {
                UserDao userDao = new UserDao(_context);

                var user = userDao.GetUserList().FirstOrDefault(u => u.Email == username);

                if (user == null)
                {
                    MessageBox.Show("Tên đăng nhập không tồn tại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (user.Password != password)
                {
                    MessageBox.Show("Mật khẩu không chính xác.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                //  MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);


                MainWindow mainWindow = new MainWindow(user);
                Application.Current.MainWindow = mainWindow;
                mainWindow.Show();
                this.Close();
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
        private void Register_MouseDown(object sender, MouseButtonEventArgs e)
        {

            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Hide();
        }
    }
}
