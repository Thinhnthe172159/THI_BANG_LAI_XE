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

namespace THI_BANG_LAI_XE.View.LectureView.ManagerExamPaper
{
    /// <summary>
    /// Interaction logic for ManagerExamPaperPage.xaml
    /// </summary>
    public partial class ManagerExamPaperPage : Page
    {
        private Query _context;
        private ThiBangLaiXeContext _db;
        private Course? course;
        private User? userInfor = MainWindow.userLogedIn;
        public ManagerExamPaperPage()
        {
            _db = new ThiBangLaiXeContext();
            _context = new Query(_db);
            InitializeComponent();
            LoadExamPaper();
        }

        void LoadExamPaper()
        {
            DataExamPaper.ItemsSource = _context.examPaperDao.getFilterExamPaperList(txtExamPaperName.Text);
        }


    }
}
