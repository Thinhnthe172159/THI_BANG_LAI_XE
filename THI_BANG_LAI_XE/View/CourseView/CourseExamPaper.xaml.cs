using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
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
        private ExamPaper? exp;
        private Question? Quest;

        public CourseExamPaper(ExamPaper? ep, Question? q)
        {
            InitializeComponent();
            _db = new ThiBangLaiXeContext();
            _context = new Query(_db);
            exp = ep;
            Quest = q;
            LoadAllQuestion();
            loadQuesttionContent(q, exp);
            ExamPaperNo.Text = $" >  {exp.ExamPaperName}";
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
                        Tag = AnswerList[i].AnswerId
                    };
                    if (AnswerList[i].IsCorrectOrNot == 1)
                    {
                        rd.IsChecked = true;
                    }
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
    }
}
