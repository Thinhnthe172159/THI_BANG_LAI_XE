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
using Azure.Core;
using THI_BANG_LAI_XE.Dao;
using THI_BANG_LAI_XE.Models;

namespace THI_BANG_LAI_XE.View.LectureView.ManagerExamPaper
{
    /// <summary>
    /// Interaction logic for AddExamPaper.xaml
    /// </summary>
    public partial class AddExamPaper : Window
    {
        private ThiBangLaiXeContext _db;
        private Query _context;
        private ExamPaper examPaper;
        public AddExamPaper(ExamPaper ep)
        {
            InitializeComponent();
            _db = new ThiBangLaiXeContext();
            _context = new Query(_db);
            examPaper = ep;
            loadAllQuestion();
        }

        public void loadAllQuestion()
        {
            var newList = _context.questionDao.GetQuestionListByExamPaper(examPaper.ExamPaperId);
            var cusList = from ep in newList select new { questNo = "Question " + (newList.IndexOf(ep) + 1), questId = ep.QuestionId };

            DataQuest.ItemsSource = null;
            DataQuest.ItemsSource = cusList;
        }

        private void ShowQuestion(object sender, RoutedEventArgs e)
        {
            if (sender is Button bt && bt.Tag is Question q)
            {
                LectureMainWindow lectureMainWindow = (LectureMainWindow)Application.Current.MainWindow;
                lectureMainWindow.AddExamPaper.ContentFrame.Navigate(new DetailQuestion(q, examPaper));
            }
        }



        private void AddQuestion(object sender, RoutedEventArgs e)
        {
            var question = new Question
            {
                ExamPaperId = examPaper.ExamPaperId
            };
            _context.questionDao.AddQuestion(question);
            loadAllQuestion();
        }

        private void DataQuest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dynamic quest = DataQuest.SelectedItem;
            if (quest != null)
            {
                var quest2 = _context.questionDao.GetQuestionById((long)quest.questId);
                if (quest2 != null)
                {
                    LectureMainWindow lectureMainWindow = (LectureMainWindow)Application.Current.MainWindow;
                    lectureMainWindow.AddExamPaper.ContentFrame.Navigate(new DetailQuestion(quest2, examPaper));
                }
            }
        }
    }
}
