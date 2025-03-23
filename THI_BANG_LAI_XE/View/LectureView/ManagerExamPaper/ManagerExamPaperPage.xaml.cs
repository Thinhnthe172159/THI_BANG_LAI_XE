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

        private void txtExamPaperName_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadExamPaper();
        }

        //preview examPaper
        private void Preview(object sender, RoutedEventArgs e)
        {
            if (sender is Button bt)
            {
                var ExamPaper = _context.examPaperDao.getExamPaperById(int.Parse(bt.Tag + ""));
                if (ExamPaper != null)
                {
                    LectureMainWindow lectureMain = (LectureMainWindow)Application.Current.MainWindow;
                    lectureMain.AddExamPaper = new AddExamPaper(ExamPaper);
                    lectureMain.AddExamPaper.Show();
                }
            }
        }
        private void Remove(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Bạn có muốn xóa đề thi này không?", "Xóa đề thi", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

                if (sender is Button bt)
                {

                    try
                    {
                        _context.examPaperDao.RemoveAllOldQuestionAndAnswer(int.Parse(bt.Tag.ToString()));
                        MessageBox.Show("Đã xóa bài kiểm tra thành công!");
                        LoadExamPaper();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Không thể xóa đề thi này vì nó đang được sử dụng");
                    }
                }
            }
        }

        private void AddExamPaper(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtExamNewName.Text))
            {
                MessageBox.Show("Tên đề thi không được để trống!");
            }
            else
            {
                var ExamPaper = new ExamPaper
                {
                    ExamPaperName = txtExamNewName.Text
                };
                try
                {
                    _context.examPaperDao.AddExamPaper(ExamPaper);
                    var examPaper = _context.examPaperDao.getNewestExamPaper();
                    if (examPaper != null)
                    {
                        LectureMainWindow lectureMain = (LectureMainWindow)Application.Current.MainWindow;
                        LoadExamPaper();
                        lectureMain.AddExamPaper = new AddExamPaper(examPaper);
                        lectureMain.AddExamPaper.Show();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi thêm đề thi mới!");
                }

            }
        }
    }
}
