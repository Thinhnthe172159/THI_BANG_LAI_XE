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
using Microsoft.EntityFrameworkCore;
using THI_BANG_LAI_XE.Dao;
using THI_BANG_LAI_XE.Models;
using THI_BANG_LAI_XE.View.CourseView;

namespace THI_BANG_LAI_XE.View.ExamView
{
    /// <summary>
    /// Interaction logic for ExamListPage.xaml
    /// </summary>
    public partial class ExamListPage : Page
    {

        private Query _context;
        private ThiBangLaiXeContext _db;
        private Course? course;
        public ExamListPage(Course c)
        {
            _db = new ThiBangLaiXeContext();
            _context = new Query(_db);
            course = c;
            InitializeComponent();
            LoadAllExamOfCourseAvailable();
        }

        void LoadAllExamOfCourseAvailable()
        {
            var User = MainWindow.userLogedIn;
            if (User != null)
            {
                ExamAvailable.ItemsSource = _context.examDao.GetExamList();
            }
        }
        private void ViewExamButton(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Exam selectedExam)
            {
                var exam = _context.examDao.GetExamById(selectedExam.ExamId);
                if (exam != null)
                {
                    TakingExamWindow takingExamWindow = new TakingExamWindow(exam);
                    takingExamWindow.Show();
                }
            }
        }

    }
}
