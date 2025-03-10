﻿using System;
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
using THI_BANG_LAI_XE.View.CourseView;

namespace THI_BANG_LAI_XE.View
{
    public partial class CourseListPage : Page
    {
        private Query _context;
        private ThiBangLaiXeContext _db;
        public CourseListPage()
        {
            _db = new ThiBangLaiXeContext();
            _context = new Query(_db);
            InitializeComponent();
            LoadAllCourser();
        }

        //private void DataCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var item = this.DataCourse.SelectedItem as Course;
        //    if (item != null)
        //    {
        //        MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;
        //        mainWindow?.ContentFrame.Navigate(new CourseDetail(item));
        //    }
        //}

        private void ViewCourseButton(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Course selectedCourse)
            {
                var SelectedCourse = _context.courseDao.GetCourseById(selectedCourse.CourseId);
                if (SelectedCourse != null && _context.registrationDao.IsCourseRegisted(MainWindow.userLogedIn.UserId, selectedCourse.CourseId))
                {
                    MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;
                    mainWindow?.ContentFrame.Navigate(new CourseDetail(SelectedCourse));
                }
                else
                {
                    MessageBox.Show("Ban chưa đăng ký khóa học !");
                }
            }
        }

        void LoadAllCourser()
        {
            this.DataCourse.ItemsSource = _context.courseDao.GetCourseList();
        }
    }
}
