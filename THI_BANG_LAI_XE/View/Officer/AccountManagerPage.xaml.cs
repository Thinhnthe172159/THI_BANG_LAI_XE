using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using THI_BANG_LAI_XE.Dao;
using THI_BANG_LAI_XE.Models;

namespace THI_BANG_LAI_XE.View.Officer
{
    public partial class AccountManagerPage : Page
    {
        private ObservableCollection<User> accountList;
        private UserDao userDao;
        private ThiBangLaiXeContext dbSet;
        private List<Role> roleList;

        public AccountManagerPage()
        {
            InitializeComponent();
            dbSet = new ThiBangLaiXeContext();
            userDao = new UserDao(dbSet);
            accountList = new ObservableCollection<User>();
            roleList = new List<Role>();

            LoadData();
        }

        private void LoadData()
        {
            // Lấy acc trong db
            var users = userDao.GetUserList().ToList();
            accountList = new ObservableCollection<User>(users);
            DataAccount.ItemsSource = accountList;

            // role trong db
            roleList = dbSet.Roles.ToList();
            ListRole.ItemsSource = roleList;
            ListRole.DisplayMemberPath = "RoleName";
        }

        private void FilterByName(object sender, TextChangedEventArgs e)
        {
            var filteredList = accountList.Where(u => u.FullName.Contains(txtFullName.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            DataAccount.ItemsSource = filteredList;
        }

        private void FilterBySchoolName(object sender, TextChangedEventArgs e)
        {
            var filteredList = accountList.Where(u => u.School != null && u.School.Contains(txtSchool.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            DataAccount.ItemsSource = filteredList;
        }
        private void ListRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListRole.SelectedItem is Role selectedRole)
            {
                var filteredList = accountList.Where(u => u.RoleNavigation.RoleName == selectedRole.RoleName).ToList();
                DataAccount.ItemsSource = filteredList;
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            txtFullName.Text = "";
            txtSchool.Text = "";
            ListRole.SelectedItem = null;
            DataAccount.ItemsSource = accountList;
        }

        private void DataAccount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataAccount.SelectedItem is User selectedUser)
            {
                UpdateAccountPage updatePage = new UpdateAccountPage(selectedUser);
                updatePage.AccountUpdated += UpdatePage_AccountUpdated;
                this.NavigationService?.Navigate(updatePage);
            }
        }

        private void UpdatePage_AccountUpdated(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}