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
        private ExamPaper? exp = new ExamPaper();
        private Query _context;
        private ThiBangLaiXeContext _db;
        private Course? course;
        private User? userInfor = MainWindow.userLogedIn;
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
                var list = _context.examDao.GetExamList();
                var listCustom = from ex in list
                                 select new
                                 {
                                     Room = ex.Room,
                                     CourseName = ex.Course.CourseName,
                                     Date = ex.Date,
                                     Status = getScore(ex.ExamId),
                                     exam = ex
                                 };
                ExamAvailable.ItemsSource = listCustom;
            }
        }

        private string getScore(int exmId)
        {
            var result = _context.resultDao.GetResult(userInfor.UserId, exmId);
            if (result != null)
            {
                string PassedScore = result.PassStatus == 1 ? "Passed" : "Not Passed";
                return $"your result :{(int)result.Score + "/25"} --> {PassedScore}";
            }
            return "No result recorded";
        }


        private void ViewExamButton(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is Exam selectedExam)
            {
                var exam = _context.examDao.GetExamById(selectedExam.ExamId);
                if (exam != null)
                {
                    var Result = _context.resultDao.GetResult(userInfor.UserId, exam.ExamId);
                    if (Result != null)
                    {
                        exp = _context.examPaperDao.getExamPaperById(Result.ExamPaperId);
                    }
                    else
                    {
                        RandomExamPaper(exam);
                        Result = new Result
                        {
                            ExamId = exam.ExamId,
                            UserId = userInfor.UserId,
                            Score = 0,
                            PassStatus = 0,
                            ExamPaperId = exp.ExamPaperId
                        };
                        _context.resultDao.AddResult(Result);
                        List<Question> questionOfExam = _context.questionDao.GetQuestionListByExamPaper(exp.ExamPaperId);
                        foreach (var quest in questionOfExam)
                        {
                            _context.userSelectAnswerDao.AddAnswer(new UserSelectedAnswer { UserId = userInfor.UserId, QuestionId = quest.QuestionId });
                        }
                    }

                    if (exp != null && _context.resultDao.ResultExist(userInfor.UserId, exam.ExamId))
                    {
                        if (exam.Date == DateOnly.FromDateTime(DateTime.Now))
                        {
                            if (_context.resultDao.GetResult(userInfor.UserId, exam.ExamId).PassStatus < 1)
                            {
                                TakingExamWindow takingExamWindow = new TakingExamWindow(exam, exp);
                                takingExamWindow.Show();
                            }
                            else
                            {
                                MessageBox.Show("Bài thi không khả dụng lúc này!");
                            }
                        }
                        else if (exam.Date < DateOnly.FromDateTime(DateTime.Now))
                        {
                            MessageBox.Show("Đã quá ngày làm bài thi");
                        }
                        else
                        {
                            MessageBox.Show("Chưa đến ngày làm bài thi");
                        }
                    }
                }
            }
        }

        void RandomExamPaper(Exam ex)
        {
            Random random = new Random();
            int selectItem = random.Next(0, ex.ExamPapers.Count());
            List<ExamPaper> list = ex.ExamPapers.ToList();
            if (selectItem != 0)
            {
                for (int i = 0; i < ex.ExamPapers.Count; i++)
                {
                    if (selectItem == i)
                    {
                        exp = list[i];
                        break;
                    }
                }
            }
            else
            {
                exp = list[0];
            }
        }


    }
}
