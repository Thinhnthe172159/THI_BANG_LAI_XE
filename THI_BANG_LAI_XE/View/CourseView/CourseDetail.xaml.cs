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
    /// Interaction logic for CourseDetail.xaml
    /// </summary>
    public partial class CourseDetail : Page
    {
        private Query _context;
        private ThiBangLaiXeContext _db;
        private Course course;
        public CourseDetail(Course c)
        {
            _db = new ThiBangLaiXeContext();
            _context = new Query(_db);
            course = c;
            InitializeComponent();
            LoadAllExamPaper();
        }

        void LoadAllExamPaper()
        {
            var Course = _context.courseDao.GetCourseById(course.CourseId);
            if (Course != null)
            {
                ExamPaperList.ItemsSource = Course.ExamPapers.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.ContentFrame.Navigate(new CourseListPage());
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is ExamPaper selectedExam)
            {
                var newExamPaper = _context.examPaperDao.getExamPaperById(selectedExam.ExamPaperId);
                if (newExamPaper != null)
                {
                    MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;
                    mainWindow?.ContentFrame.Navigate(new CourseExamPaper(newExamPaper, null));
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string ExamPaperName = this.txtExamPaperName.Text;
            var Course = _context.courseDao.GetCourseById(course.CourseId);
            if (Course != null)
            {
                ExamPaperList.ItemsSource = Course.ExamPapers.Where(ex => ex.ExamPaperName.ToLower().Contains(ExamPaperName.ToLower())).ToList();
            }
        }
    }
}
