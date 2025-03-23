using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using THI_BANG_LAI_XE.Dao;
using THI_BANG_LAI_XE.Models;
using THI_BANG_LAI_XE.View;
using THI_BANG_LAI_XE.View.Officer;

namespace THI_BANG_LAI_XE.View.Officer
{
    public partial class OfficerMainWindow : Window
    {
        private Button selectedButton;
        public static User userLogedIn;
        private Query _context;
        private ThiBangLaiXeContext _db;

        public OfficerMainWindow(User user)
        {
            userLogedIn = user;
            InitializeComponent();
            selectedButton = new Button();
            _db = new ThiBangLaiXeContext();
            _context = new Query(_db);
            selectedButton = new Button();
        }

        private void HomeButton(object sender, RoutedEventArgs e)
        {
            UpdateButtonSelection((Button)sender);
            ContentFrame.Navigate(new HomePage(userLogedIn.FullName));
        }

        private void ProfileButton(object sender, RoutedEventArgs e)
        {
            UpdateButtonSelection((Button)sender);
            ContentFrame.Navigate(new UserProfilePage(userLogedIn));
        }

        private void StudentListButton(object sender, RoutedEventArgs e)
        {
            UpdateButtonSelection((Button)sender);
            ContentFrame.Navigate(new StudentListPage());
        }

        private void AccountManagerButton(object sender, RoutedEventArgs e)
        {
            UpdateButtonSelection((Button)sender);
            ContentFrame.Navigate(new AccountManagerPage());
        }

        private void CertificateButton(object sender, RoutedEventArgs e)
        {
            UpdateButtonSelection((Button)sender);
            ContentFrame.Navigate(new CertificatePage(userLogedIn));
        }

        private void NotificationButton(object sender, RoutedEventArgs e)
        {
            UpdateButtonSelection((Button)sender);
        }

        private void Button_Logout(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void UpdateButtonSelection(Button clickedButton)
        {
            if (selectedButton != null)
            {
                selectedButton.Background = (Brush?)new BrushConverter().ConvertFromString("#614bd4");
            }
            clickedButton.Background = (Brush?)new BrushConverter().ConvertFromString("#816fd4");
            selectedButton = clickedButton;
        }
    }
}