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

namespace THI_BANG_LAI_XE.View.CourseView
{
    /// <summary>
    /// Interaction logic for CourseExamPaper.xaml
    /// </summary>
    public partial class CourseExamPaper : Page
    {
        private Query _context;
        private ThiBangLaiXeContext _db;
        private ExamPaper exp;

        public CourseExamPaper(ExamPaper ep)
        {
            InitializeComponent();
            _db = new ThiBangLaiXeContext();
            _context = new Query(_db);
            exp = ep;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.ContentFrame.Navigate(new CourseListPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var course = exp.Courses.FirstOrDefault();
            if (course != null)
            {
                MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow?.ContentFrame.Navigate(new CourseDetail(course));
            }
        }
    }
}
