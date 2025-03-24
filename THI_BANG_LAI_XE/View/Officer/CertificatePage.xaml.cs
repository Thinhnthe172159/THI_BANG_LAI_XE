using Microsoft.EntityFrameworkCore;
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
    public partial class CertificatePage : Page
    {
        private ThiBangLaiXeContext dbSet;
        private User _user;
        private Query _context;

        public CertificatePage(User user, Query context)
        {
            InitializeComponent();
            dbSet = new ThiBangLaiXeContext();
            _user = user;
            _context = context; // Khởi tạo Query
            LoadName();
        }

        private void LoadName()
        {
            try
            {
                var certificate = _context.certificateDao.GetCertificateByUserId(_user.UserId);
                // check xem cer duyệt or chưa

                if (_context.certificateDao.GetCertificateByUserId(_user.UserId) != null)
                {
                    txtName.Text = _user.FullName;
                    txtIssue.Text = certificate.IssuedDate.ToString("dd/MM/yyyy");
                    txtExp.Text = certificate.ExpirationDate.ToString("dd/MM/yyyy");
                }
                else
                {
                    MessageBox.Show("Bạn chưa được cấp chứng chỉ.");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin chứng chỉ: {ex.Message}");
            }
        }
    }
}
