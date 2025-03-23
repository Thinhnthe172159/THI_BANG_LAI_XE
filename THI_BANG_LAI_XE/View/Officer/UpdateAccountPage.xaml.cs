using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using THI_BANG_LAI_XE.Dao;
using THI_BANG_LAI_XE.Models;

namespace THI_BANG_LAI_XE.View.Officer
{
    public partial class UpdateAccountPage : Page
    {
        private User userToUpdate;
        private UserDao userDao;
        private ThiBangLaiXeContext dbSet;
        private List<Role> roleList;

        public event EventHandler AccountUpdated;

        public UpdateAccountPage(User user)
        {
            InitializeComponent();
            userToUpdate = user;
            dbSet = new ThiBangLaiXeContext();
            userDao = new UserDao(dbSet);
            roleList = dbSet.Roles.ToList();

            txtListRole.ItemsSource = roleList;
            txtListRole.DisplayMemberPath = "RoleName";

            txtFullName.Text = userToUpdate.FullName;
            txtEmail.Text = userToUpdate.Email;
            txtPhone.Text = userToUpdate.Phone;
            txtClass.Text = userToUpdate.Class;
            txtSchool.Text = userToUpdate.School;

            txtListRole.SelectedItem = roleList.FirstOrDefault(r => r.RoleId == userToUpdate.Role);
        }

        private async void Button_Save(object sender, RoutedEventArgs e)
        {
            userToUpdate.FullName = txtFullName.Text;
            userToUpdate.Email = txtEmail.Text;
            userToUpdate.Phone = txtPhone.Text;
            userToUpdate.Class = txtClass.Text;
            userToUpdate.School = txtSchool.Text;

            if (txtListRole.SelectedItem is Role selectedRole)
            {
                userToUpdate.Role = selectedRole.RoleId;
            }

            try
            {
                userDao.UpdateUser(userToUpdate);
                MessageBox.Show("Account updated successfully!");
                AccountUpdated?.Invoke(this, EventArgs.Empty);
                this.NavigationService?.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating account: {ex.Message}");
            }
        }
        private void ListRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtListRole.SelectedItem is Role selectedRole)
            {
                userToUpdate.Role = selectedRole.RoleId;
            }
        }
    }
}