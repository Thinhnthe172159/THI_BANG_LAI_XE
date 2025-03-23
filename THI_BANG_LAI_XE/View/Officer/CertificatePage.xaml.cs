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

namespace THI_BANG_LAI_XE.View.Officer
{
    public partial class CertificatePage : Page
    {
        private ThiBangLaiXeContext dbSet;
        private User _user; // Thêm biến User

        // Sửa constructor để nhận User
        public CertificatePage(User user)
        {
            InitializeComponent();
            dbSet = new ThiBangLaiXeContext();
            _user = user;
            LoadName();
        }

        private void LoadName()
        {
            try
            {
                // Sử dụng thông tin User đã được truyền
                if (_user != null)
                {
                    txtName.Text = _user.FullName;
                }
                else
                {
                    MessageBox.Show("Không có thông tin người dùng.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải tên: {ex.Message}");
            }
        }
    }
}
