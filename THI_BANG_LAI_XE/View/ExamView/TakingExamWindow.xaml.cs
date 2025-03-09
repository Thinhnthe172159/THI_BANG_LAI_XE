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
        private Exam? Exam;
        private Query _context;
        private ThiBangLaiXeContext _db;
        private Question? Quest;
        private ExamPaper? exp = new ExamPaper();

        private TimeSpan examDuration = TimeSpan.FromMinutes(1);
        private DispatcherTimer examTimer;

        public TakingExamWindow(Exam ex)
        {
            _db = new ThiBangLaiXeContext();
            _context = new Query(_db);

            InitializeComponent();
            RandomExamPaper(ex);
            loadQuesttionContent(Quest, exp);
            LoadAllQuestion();
            StartExamTimer();
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

                if (!string.IsNullOrEmpty(quest.ImageUrl))
                {
                    ImageSource.Source = new BitmapImage(new Uri(quest.ImageUrl, UriKind.Absolute));
                }
                else
                {
                    ImageSource.Source = null;
                }

                var AnswerList = quest.Answers.ToList();
                RadioAnswer.Children.Clear();
                for (int i = 0; i < AnswerList.Count; i++)
                {
                    RadioButton rd = new RadioButton
                    {
                        Content = $"{i + 1} {AnswerList[i].DetailAnswer}",
                        Margin = new Thickness(2),
                        Tag = AnswerList[i].AnswerId,
                        FontSize = 20
                    };
                    RadioAnswer.Children.Add(rd);
                }
            }
        }

        void LoadAllQuestion()
        {
            var QuestionList = _context.questionDao.GetQuestionListByExamPaper(exp.ExamPaperId);

            for (int i = 0; i < QuestionList.Count; i++)
            {
                Button btn = new Button
                {
                    Content = $"{i + 1}",
                    Width = 40,
                    Margin = new Thickness(2),
                    Height = 30,
                    Tag = QuestionList[i]
                };
                btn.Click += Btn_Click;
                QuestionPanel.Children.Add(btn);
            }
        }


        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button?.Tag is Question question)
            {
                loadQuesttionContent(question, exp);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.ContentFrame.Navigate(new CourseListPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var course = exp?.Courses.FirstOrDefault();
            if (course != null)
            {
                MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow?.ContentFrame.Navigate(new CourseDetail(course));
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
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
                MessageBox.Show("Thời gian thi đã hết. Hệ thống sẽ tự động đóng màn hình thi.");
                this.Close();
            }
        }
    }
}
