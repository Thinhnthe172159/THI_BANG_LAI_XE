using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using System.Windows.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using THI_BANG_LAI_XE.Dao;
using THI_BANG_LAI_XE.Models;
using THI_BANG_LAI_XE.View.CourseView;

namespace THI_BANG_LAI_XE.View.ExamView
{
    /// <summary>
    /// Interaction logic for TakingExamWindow.xaml
    /// </summary>
    public partial class TakingExamWindow : Window
    {
        private Exam Exam;
        private Query _context;
        private ThiBangLaiXeContext _db;
        private Question Quest;
        private User userInfor = MainWindow.userLogedIn;
        private ExamPaper examPaper;

        private TimeSpan examDuration = TimeSpan.FromMinutes(19);
        private DispatcherTimer? examTimer;

        public TakingExamWindow(Exam ex, ExamPaper exp)
        {
            _db = new ThiBangLaiXeContext();
            _context = new Query(_db);
            Exam = ex;
            examPaper = exp;
            InitializeComponent();
            loadQuesttionContent(Quest, examPaper);
            LoadAllQuestion(null);
            StartExamTimer();
        }



        void loadQuesttionContent(Question? quest, ExamPaper? ex)
        {
            if (quest == null)
            {
                var listq = _context.questionDao.GetQuestionListByExamPaper(ex.ExamPaperId);
                quest = listq?.FirstOrDefault();
            }

            if (quest != null)
            {
                txtQuestionDetail.Text = quest.DetailQuestion;
                ImageSource.Source = !string.IsNullOrEmpty(quest.ImageUrl)
                    ? new BitmapImage(new Uri(quest.ImageUrl, UriKind.Absolute))
                    : null;

                var AnswerList = quest.Answers.ToList();
                RadioAnswer.Children.Clear();
                var selectedAnswer = _context.userSelectAnswerDao.GetAnswerOfUserById(quest.QuestionId, userInfor.UserId);

                for (int i = 0; i < AnswerList.Count; i++)
                {
                    RadioButton rd = new RadioButton
                    {
                        Content = $"{i + 1} {AnswerList[i].DetailAnswer}",
                        Margin = new Thickness(2),
                        Tag = AnswerList[i].AnswerId,
                        FontSize = 20
                    };
                    rd.Click += Btn_Click_UpdateAnswer;
                    rd.IsChecked = selectedAnswer?.AnswerId == AnswerList[i].AnswerId;

                    RadioAnswer.Children.Add(rd);
                }
            }
        }

        private void Btn_Click_UpdateAnswer(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            if (button?.Tag == null) return;

            long AnswerId = long.Parse(button.Tag.ToString());
            Question question = _context.answerDao.GetAnswerById(AnswerId).Question;
            if (question != null)
            {
                var AnswerSelected = _context.userSelectAnswerDao.GetAnswerOfUserById(question.QuestionId, userInfor.UserId);
                if (AnswerSelected != null)
                {
                    AnswerSelected.AnswerId = AnswerId;
                    _context.userSelectAnswerDao.UpdateUserAnswer(AnswerSelected);
                }
            }
        }




        void LoadAllQuestion(Question? quest)
        {
            var QuestionList = _context.questionDao.GetQuestionListByExamPaper(examPaper.ExamPaperId);
            QuestionPanel.Children.Clear();
            for (int i = 0; i < QuestionList.Count; i++)
            {
                var selectedAnswer = _context.userSelectAnswerDao.GetAnswerOfUserById(QuestionList[i].QuestionId, userInfor.UserId);
                Button btn = new Button
                {
                    Content = $"{i + 1}",
                    Width = 40,
                    Margin = new Thickness(2),
                    Height = 30,
                    Tag = QuestionList[i]
                };
                btn.Click += Btn_Click;
                if (selectedAnswer != null && selectedAnswer.QuestionId == QuestionList[i].QuestionId && selectedAnswer.Answer != null)
                {
                    btn.Background = Brushes.LightGreen;
                }
                if (quest != null && quest.QuestionId == QuestionList[i].QuestionId)
                {
                    btn.Background = Brushes.BlueViolet;
                }
                QuestionPanel.Children.Add(btn);
            }
        }


        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button?.Tag is Question question)
            {
                loadQuesttionContent(question, examPaper);
                LoadAllQuestion(question);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.ContentFrame.Navigate(new CourseListPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var course = examPaper?.Courses.FirstOrDefault();
            if (course != null)
            {
                MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow?.ContentFrame.Navigate(new CourseDetail(course));
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            examTimer.Stop();

            if (MessageBox.Show("bạn có muốn kết thúc phần thi ngay bây giờ không?", "Nộp bài", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Makr();
                this.Close();
            }
        }

        // tính điểm cho người thi
        void Makr()
        {
            var result = _context.resultDao.GetResult(userInfor.UserId, Exam.ExamId);
            if (result != null)
            {
                List<UserSelectedAnswer> UserAnswerList = _context.userSelectAnswerDao.getListUserAnswer(userInfor.UserId, result.ExamPaperId);
                result.Score = UserAnswerList.Where(u => u.Answer != null && u.Answer.IsCorrectOrNot == 1).Count();
                float PassCondition = (float)result.Score / (float)examPaper.Questions.Count * 100;
                if (PassCondition >= 80)// bài thi có tỉ lệ câu đúng > 80% thì pass
                {
                    result.PassStatus = 1;// pass
                    var officerList = _context.userDao.getListUserByRole(2);
                    foreach (var users in officerList)
                    {
                        var no = new Notification
                        {
                            Sender = userInfor.UserId,
                            Receiver = users.UserId,
                            Title = "Xét chứng chỉ",
                            Content = $"Thí sinh {userInfor.FullName} đã vượt qua kì thi chứng chỉ lái xe và đang chờ nhận được chứng chỉ"
                        };
                        _context.notificationDao.AddNotification(no);
                    }
                }
                else
                {
                    result.PassStatus = 2; // false
                }
                var selectAnswear = _context.userDao.GetUserByIdContainAnswearSelected(userInfor.UserId).UserSelectedAnswers.ToList();
                foreach (var answer in selectAnswear)
                {
                    _context.userSelectAnswerDao.DeleteDataRecored(answer.UserId, answer.QuestionId);
                }
            }
            _context.resultDao.UpdateResultStatus(result);
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            var Ex = _context.examDao.GetExamById(result.ExamId);
            var course = Ex.Course;
            mainWindow.ContentFrame.Navigate(new ExamListPage(course));
        }


        private void StartExamTimer()
        {
            examTimer = new DispatcherTimer();
            examTimer.Interval = TimeSpan.FromSeconds(1);
            examTimer.Tick += ExamTimer_Tick;
            examTimer.Start();
        }

        private void ExamTimer_Tick(object sender, EventArgs e)
        {
            examDuration = examDuration.Subtract(TimeSpan.FromSeconds(1));
            lblTimer.Text = examDuration.ToString(@"hh\:mm\:ss");
            if (examDuration.TotalSeconds <= 0)
            {
                examTimer.Stop();
                Makr();
                MessageBox.Show("Thời gian thi đã hết!");
                this.Close();
            }
        }
    }
}
