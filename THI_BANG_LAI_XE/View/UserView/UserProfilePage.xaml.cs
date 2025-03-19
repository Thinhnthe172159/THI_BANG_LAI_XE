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
using THI_BANG_LAI_XE.View.UserView;


namespace THI_BANG_LAI_XE.View
{
    /// <summary>
    /// Interaction logic for UserProfilePage.xaml
    /// </summary>
    public partial class UserProfilePage : Page
    {
        private readonly Query context;
        private readonly ThiBangLaiXeContext dbSet;
        private readonly User currentUser;

        public UserProfilePage(User user)
        {
            InitializeComponent();
            this.dbSet = new ThiBangLaiXeContext();
            context = new Query(dbSet);
            this.currentUser = user;

            // Hiển thị thông tin người dùng
            DisplayUserInfo();
        }

        private void DisplayUserInfo()
        {
            if (currentUser != null)
            {
                txtName.Text = currentUser.FullName.Trim();
                txtFullName.Text = currentUser.FullName;
                txtEmail.Text = currentUser.Email;
                txtPhone.Text = currentUser.Phone;
                txtClass.Text = currentUser.Class;
                txtSchool.Text = currentUser.School;
                //txtRole.Text = currentUser.Role.ToString;
                if (currentUser.Role == 1)
                {
                    txtRole.Text = "Lecturer";
                }
                else if (currentUser.Role == 2)
                {
                    txtRole.Text = "Officer";
                }
                else if (currentUser.Role == 3)
                {
                    txtRole.Text = "Student";
                }
                else if (currentUser.Role == 4)
                {
                    txtRole.Text = "Admin";
                }


                txtDateCreate.Text = currentUser.DateCreated.ToString("dd/MM/yyyy HH:mm:ss");
            }
        }

        private void Button_ChangeInformation(object sender, RoutedEventArgs e)
        {
            if (currentUser != null)
            {
                ChangeInformation changeInformationPage = new ChangeInformation(currentUser);
                if (this.NavigationService != null)
                {
                    this.NavigationService.Navigate(changeInformationPage);
                }
                else
                {
                    MessageBox.Show("Lỗi điều hướng!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Thông tin người dùng không tồn tại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
