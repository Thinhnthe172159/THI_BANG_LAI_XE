using System;
using System.Windows;
using System.Windows.Controls;
using THI_BANG_LAI_XE.Dao;
using THI_BANG_LAI_XE.Models;

namespace THI_BANG_LAI_XE.View.UserView
{
    public partial class ChangeInformation : Page
    {
        private readonly ThiBangLaiXeContext dbSet;
        private readonly UserDao userDao;
        private readonly User currentUser;

        public ChangeInformation(User user)
        {
            InitializeComponent();
            this.dbSet = new ThiBangLaiXeContext();
            this.userDao = new UserDao(dbSet);
            this.currentUser = user;
            DisplayUserInfo();
        }

        private void DisplayUserInfo()
        {
            if (currentUser != null)
            {
                txtFullName.Text = currentUser.FullName;
                txtPassword.Text = currentUser.Password;
                txtClass.Text = currentUser.Class;
                txtSchool.Text = currentUser.School;
                txtPhone.Text = currentUser.Phone;
            }
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            if (currentUser != null)
            {
                currentUser.FullName = txtFullName.Text;
                currentUser.Password = txtPassword.Text;
                currentUser.Class = txtClass.Text;
                currentUser.School = txtSchool.Text;
                currentUser.Phone = txtPhone.Text;

                try
                {
                    userDao.UpdateUser(currentUser);
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi cập nhật thông tin: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
             NavigationService?.Navigate(new UserProfilePage(currentUser));
        }
    }
}