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

namespace THI_BANG_LAI_XE.View.NotificationView
{
    public partial class NotificaitonListPage : Page
    {
        private ThiBangLaiXeContext _db;
        private Query _context;
        private User? userInfor = MainWindow.userLogedIn;

        public NotificaitonListPage()
        {
            InitializeComponent();
            _db = new ThiBangLaiXeContext();
            _context = new Query(_db);
            LoadNotifications();
        }

        private void LoadNotifications()
        {
            if (userInfor != null)
            {
                List<string> notifications = new List<string>();

                var results = _context.resultDao.GetResultsByUserId(userInfor.UserId);

                if (results != null)
                {
                    foreach (var result in results)
                    {
                        if (result.PassStatus == 1)
                        {
                            // check exam để hiện noti
                            var exam = _context.examDao.GetExamById(result.ExamId);
                            if (exam != null)
                            {
                                notifications.Add($"● Bạn đã được cấp Certificate cho bài thi '{exam.Room}'.");
                            }
                            else
                            {
                                notifications.Add("● Bạn đã được cấp Certificate.");
                            }
                        }
                    }
                }

                // Hiển thị thông báo
                NotificationListBox.ItemsSource = notifications;
            }
        }
    }
}