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
using THI_BANG_LAI_XE.Models;
using THI_BANG_LAI_XE.Dao;


namespace THI_BANG_LAI_XE.View.Officer
{
    /// <summary>
    /// Interaction logic for CertificateManage.xaml
    /// </summary>
    public partial class CertificateManage : Page
    {
        private ThiBangLaiXeContext _db;
        private Query _context;
        private List<User> eligibleUsers;

        public CertificateManage()
        {
            InitializeComponent();
            _db = new ThiBangLaiXeContext();
            _context = new Query(_db);
            LoadEligibleUsers();
        }

        private void LoadEligibleUsers()
        {
            var userIdsWithPassStatus1 = _db.Results
                .Where(r => r.PassStatus == 1)
                .Select(r => r.UserId)
                .Distinct()
                .ToList();

            eligibleUsers = _context.userDao
                .GetUserList()
                .Where(u => userIdsWithPassStatus1.Contains(u.UserId))
                .ToList();

            DataAccount.ItemsSource = eligibleUsers.Select(u => new
            {
                u.UserId,
                u.FullName,
                u.Email,
                u.Phone,
                IssuedDate =
                    u.Certificates.FirstOrDefault()?.IssuedDate,
                ExpirationDate =
                    u.Certificates.FirstOrDefault()?.ExpirationDate,
                CertificateCode =
                    u.Certificates.FirstOrDefault()?.CertificateCode
            }).ToList();
        }

        private void IssueCertificateButton_Click(object sender,
            RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is long userId)
            {
                // check user có cer
                var existingCertificate = _context.certificateDao.GetCertificateByUserId(userId);
                if (existingCertificate != null)
                {
                    MessageBox.Show("Người dùng này đã có chứng chỉ.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                // tạo cer
                Certificate newCertificate = new Certificate
                {
                    UserId = userId,
                    IssuedDate = DateTime.Now.Date,
                    ExpirationDate = DateTime.Now.Date.AddYears(10),
                    CertificateCode = GenerateCertificateCode()
                };

                // add cer vào db
                _context.certificateDao.AddCertificate(newCertificate);

                MessageBox.Show("Cấp chứng chỉ thành công!",
                    "Thông báo",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            LoadEligibleUsers();
        }

        private void RejectCertificateButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is long userId)
            {
                // check cer of user
                var existingCertificate = _context.certificateDao.GetCertificateByUserId(userId);
                if (existingCertificate == null)
                {
                    MessageBox.Show("Người dùng này chưa có chứng chỉ.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                // del cer
                _context.certificateDao.RemoveCertificate(existingCertificate);

                MessageBox.Show("Từ chối chứng chỉ thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadEligibleUsers();
            }
        }

        private string GenerateCertificateCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(
                Enumerable.Repeat(chars, 10)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray());
        }

        private void FilterByName(object sender, TextChangedEventArgs e)
        {
            FilterDataGrid();
        }

        private void FilterByEmail(object sender, TextChangedEventArgs e)
        {
            FilterDataGrid();
        }

        private void FilterByPhone(object sender, TextChangedEventArgs e)
        {
            FilterDataGrid();
        }

        private void FilterDataGrid()
        {
            if (eligibleUsers == null)
            {
                return;
            }

            var filteredUsers = eligibleUsers.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                filteredUsers = filteredUsers.Where(u =>
                    u.FullName.ToLower().Contains(txtFullName.Text.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                filteredUsers = filteredUsers.Where(u =>
                    u.Email.ToLower().Contains(txtEmail.Text.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                filteredUsers = filteredUsers.Where(u =>
                    u.Phone.Contains(txtPhone.Text));
            }

            DataAccount.ItemsSource = filteredUsers.Select(u => new
            {
                u.UserId,
                u.FullName,
                u.Email,
                u.Phone,
                IssuedDate =
                    u.Certificates.FirstOrDefault()?.IssuedDate,
                ExpirationDate =
                    u.Certificates.FirstOrDefault()?.ExpirationDate,
                CertificateCode =
                    u.Certificates.FirstOrDefault()?.CertificateCode
            }).ToList();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            txtFullName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            LoadEligibleUsers();
        }

        private void DataAccount_SelectionChanged(object sender,
            SelectionChangedEventArgs e)
        { }
    }
}
