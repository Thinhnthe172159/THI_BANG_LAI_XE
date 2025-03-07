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
using System.Windows.Shapes;
using THI_BANG_LAI_XE.Dao;
using THI_BANG_LAI_XE.Models;

namespace THI_BANG_LAI_XE.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Query _context;
        private ThiBangLaiXeContext _db;
        public MainWindow()
        {
            InitializeComponent();
            this._db = new ThiBangLaiXeContext();
            this._context = new Query(_db);
            LoadAllCourser();
        }

        private void DataCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = this.DataCourse.SelectedItem as Course;
            if (item != null)
            {
                ContentFrame.Navigate(new CourseDetail(item));
            }
        }

        void LoadAllCourser()
        {
            this.DataCourse.ItemsSource = _context.courseDao.GetCourseList();
        }
    }
}
