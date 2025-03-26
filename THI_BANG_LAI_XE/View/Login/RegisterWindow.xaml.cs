using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using THI_BANG_LAI_XE.View.Login;

namespace THI_BANG_LAI_XE
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private ThiBangLaiXeContext _db;
        private Query _context;
        public RegisterWindow()
        {
            InitializeComponent();
            _db = new ThiBangLaiXeContext();
            _context = new Query(_db);
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    this.DragMove();
                }
            }
            catch { }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    this.DragMove();
                }
            }
            catch
            {
            }
        }

        private async void Button_Save(object sender, RoutedEventArgs e)
        {
            string fullName = ((MyTextBox)FindName("txtFullName")).Text;
            string email = ((MyTextBox)FindName("txtEmail")).Text;
            string password = ((MyTextBox)FindName("txtPassword")).Text;
            string phone = ((MyTextBox)FindName("txtPhone")).Text;
            string _class = ((MyTextBox)FindName("txtClass")).Text;
            string school = ((MyTextBox)FindName("txtSchool")).Text;
            //string role = ((ComboBoxItem)optionRole.SelectedItem).Content.ToString();
            string role = "";

            if (optionRole.SelectedItem != null && optionRole.SelectedItem is ComboBoxItem selectedItem)
            {
                role = selectedItem.Content.ToString();
            }
            else
            {
                MessageBox.Show("Please select a role.");
                return;
            }

            if (string.IsNullOrEmpty(fullName) && string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password) && string.IsNullOrEmpty(phone) && string.IsNullOrEmpty(_class) && string.IsNullOrEmpty(school))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Invalid email format.");
                return;
            }

            using (var context = new ThiBangLaiXeContext())
            {
                var userDao = new UserDao(context);

                var newUser = new User
                {
                    FullName = fullName,
                    Email = email,
                    Password = password,
                    Role = role == "Student" ? 3 : 1,
                    Class = _class,
                    School = school,
                    Phone = phone,
                    DateCreated = DateTime.Now
                };
                if (userDao.IsEmailExists(email))
                {
                    MessageBox.Show("Email already exists.");
                    return;
                }
                try
                {
                    if (newUser.Role == 1)
                    {
                        newUser.Role = 4;
                    }
                    userDao.AddUser(newUser);
                    if (newUser.Role == 3)
                    {
                        MessageBox.Show("Registration successful!");
                    }
                    else
                    {
                        MessageBox.Show("Your regist is pending,please wait!");
                        var officerList = userDao.getListUserByRole(2);

                        foreach (var officer in officerList)
                        {
                            var notification = new Notification
                            {
                                Sender = userDao.System().UserId,
                                Receiver = officer.UserId,
                                Title = "Xác thực đăng ký giảng viên!",
                                Content = $"Người dùng: {newUser.FullName}\nEmail: {newUser.Email}\nPhone: {newUser.Phone}\nSchool{newUser.School} \nvừa tạo tài khoản giảng viên và đang chờ bạn xét duyệt tài khoản."
                            };
                            _context.notificationDao.AddNotification(notification);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error registering user: " + ex.Message);
                }

                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
            }
        }
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
