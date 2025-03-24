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
        private User user;

        public NotificaitonListPage(User u)
        {
            InitializeComponent();
            _db = new ThiBangLaiXeContext();
            _context = new Query(_db);
            user = u;
            //LoadNotifications();
            loadListNofiticationByUser();
        }

        void loadListNofiticationByUser()
        {
            DataNofitication.ItemsSource = _context.notificationDao.FilterNotification(txtFilter.Text, user.UserId);
        }

        private void Notification_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selectedNotification = DataNofitication.SelectedValue as Notification;
            if (selectedNotification != null)
            {
                var nofitication = _context.notificationDao.GetNotification(selectedNotification.Id);
                if (nofitication != null)
                {
                    _context.notificationDao.readNofification(nofitication.Id);
                    txtTitle.Text = nofitication.Title;
                    txtContent.Text = nofitication.Content;
                }
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



        //private void LoadNotifications()
        //{
        //    if (userInfor != null)
        //    {
        //        List<string> notifications = new List<string>();

        //        var results = _context.resultDao.GetResultsByUserId(userInfor.UserId);

        //        if (results != null)
        //        {
        //            foreach (var result in results)
        //            {
        //                if (result.PassStatus == 1)
        //                {
        //                    // check exam để hiện noti
        //                    var exam = _context.examDao.GetExamById(result.ExamId);
        //                    if (exam != null)
        //                    {
        //                        notifications.Add($"● Bạn đã được cấp Certificate cho bài thi '{exam.Room}'.");
        //                    }
        //                    else
        //                    {
        //                        notifications.Add("● Bạn đã được cấp Certificate.");
        //                    }
        //                }
        //            }
        //        }

        //        // Hiển thị thông báo
        //        NotificationListBox.ItemsSource = notifications;
        //    }
        //}
    }
}