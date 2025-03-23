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
using Microsoft.Identity.Client;
using THI_BANG_LAI_XE.Dao;
using THI_BANG_LAI_XE.Models;

namespace THI_BANG_LAI_XE.View.LectureView.ManagerExamPaper
{
    /// <summary>
    /// Interaction logic for DetailQuestion.xaml
    /// </summary>
    public partial class DetailQuestion : Page
    {
        private ThiBangLaiXeContext _db;
        private Query _context;
        private Question quest;
        private ExamPaper examPaper;
        private bool isUpdatingUI = false;
        public DetailQuestion(Question _question, ExamPaper exp)
        {
            _db = new ThiBangLaiXeContext();
            _context = new Query(_db);
            InitializeComponent();
            quest = _question;
            examPaper = exp;
            LoadQuestionContent();
        }

        void LoadQuestionContent()
        {
            var ques = _context.questionDao.GetQuestionById(quest.QuestionId);
            if (ques != null)
            {
                txtQuestionDetail.Text = ques.DetailQuestion;
                if (!string.IsNullOrEmpty(quest.ImageUrl))
                {
                    txtImageUrl.Source = new BitmapImage(new Uri(ques.ImageUrl, UriKind.Absolute));
                }
                LoadAnswer();
            }
        }

        void LoadAnswer()
        {
            var quests = _context.questionDao.GetQuestionById(quest.QuestionId);
            if (quests != null)
            {
                var listAnswer = _context.questionDao.GetQuestionById(quest.QuestionId).Answers.ToList();
                DataAnswer.ItemsSource = listAnswer;
            }
        }

        private void DataAnswer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtIsCorrectAnswer.IsChecked = false;
            var AnswerSelected = DataAnswer.SelectedItem as Answer;
            if (AnswerSelected != null)
            {
                isUpdatingUI = true;
                txtAnswerId.Text = AnswerSelected.AnswerId.ToString();
                txtAnswer.Text = AnswerSelected.DetailAnswer;
                txtIsCorrectAnswer.IsChecked = AnswerSelected.IsCorrectOrNot == 1 ? true : false;
                DetailAnswerEdit.Visibility = Visibility.Visible;
                isUpdatingUI = false;
            }
        }

        // add Answer
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Answer = new Answer
            {
                IsCorrectOrNot = 0 // false
                ,
                DetailAnswer = "Select to edit"
                ,
                QuestionId = quest.QuestionId
            };

            _context.answerDao.AddAnswer(Answer);
            LoadAnswer();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAnswer.Text))
            {
                MessageBox.Show("Bạn chưa chọn câu trả lời!");
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa câu trả lời này!", "Xóa câu trả lời", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _context.answerDao.RemoveAnswer(long.Parse(txtAnswerId.Text));
                    txtAnswer.Text = string.Empty;
                    txtIsCorrectAnswer.IsChecked = false;
                    txtAnswerId.Text = string.Empty;
                    DetailAnswerEdit.Visibility = Visibility.Hidden;
                    LoadAnswer();
                }
            }
        }


        private void txtAnswer_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAnswerId.Text))
            {
                var answerToUpdate = _context.answerDao.GetAnswerById(long.Parse(txtAnswerId.Text));
                if (answerToUpdate != null)
                {
                    answerToUpdate.DetailAnswer = txtAnswer.Text;
                    _context.answerDao.UpdateAnswer(answerToUpdate);
                    LoadAnswer();
                }
            }
        }

        private void txtIsCorrectAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (isUpdatingUI) return;

            if (!string.IsNullOrEmpty(txtAnswerId.Text))
            {
                var answerToUpdate = _context.answerDao.GetAnswerById(long.Parse(txtAnswerId.Text));
                if (answerToUpdate != null)
                {
                    answerToUpdate.IsCorrectOrNot = txtIsCorrectAnswer.IsChecked == true ? 1 : 0;
                    _context.answerDao.UpdateAnswer(answerToUpdate);
                    LoadAnswer();
                }
            }
        }

        //Remove question
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var questdelete = _context.questionDao.GetQuestionById(quest.QuestionId);
            if (questdelete != null)
            {

                foreach (var answear in questdelete.Answers.ToList())
                {
                    _context.answerDao.RemoveAnswer(answear.AnswerId);
                }
                _context.questionDao.RemoveQuestion(questdelete.QuestionId);
                LectureMainWindow lectureMainWindow = (LectureMainWindow)Application.Current.MainWindow;
                lectureMainWindow.AddExamPaper.loadAllQuestion();
                lectureMainWindow.AddExamPaper.ContentFrame.Navigate(new PageBlank());
            }
        }

        private void txtQuestionDetail_TextChanged(object sender, TextChangedEventArgs e)
        {
            var questUpdate = _context.questionDao.GetQuestionById(quest.QuestionId);
            if (questUpdate != null)
            {
                questUpdate.DetailQuestion = txtQuestionDetail.Text;
                _context.questionDao.UpdateQuestion(questUpdate);
                LoadQuestionContent();
            }
        }
    }
}