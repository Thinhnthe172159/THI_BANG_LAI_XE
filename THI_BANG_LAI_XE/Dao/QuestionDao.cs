using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Identity.Client;
using THI_BANG_LAI_XE.Models;

namespace THI_BANG_LAI_XE.Dao
{
    public class QuestionDao
    {
        private readonly ThiBangLaiXeContext _context;

        public QuestionDao(ThiBangLaiXeContext context)
        {
            _context = context;
        }

        //get list questions
        public List<Question> GetQuestionList() => _context.Questions.ToList();

        //get list question by ExamPaper 
        public List<Question> GetQuestionListByExamPaper(int ExamPaperId) => _context.Questions.Include(q => q.Answers).Where(q => q.ExamPaperId == ExamPaperId).ToList();

        //get question by id
        public Question? GetQuestionById(long QuestionId) => _context.Questions.Include(q => q.Answers).FirstOrDefault(q => q.QuestionId == QuestionId);

        // Add new question
        public void AddQuestion(Question question)
        {
            try
            {
                _context.Questions.Add(question);
                _context.SaveChanges();
            }
            catch (Exception)
            {
            }
        }

        //get newest Question by examid
        public Question? GetNewestQuestion(int examPaperId) => _context.Questions.OrderBy(a => a.QuestionId).FirstOrDefault(ex => ex.ExamPaperId == examPaperId);

        // Update question
        public void UpdateQuestion(Question question)
        {
            try
            {
                var QuestionToUpdate = GetQuestionById(question.QuestionId);
                if (QuestionToUpdate != null)
                {
                    QuestionToUpdate.ExamPaperId = question.ExamPaperId;
                    QuestionToUpdate.DetailQuestion = question.DetailQuestion;
                    QuestionToUpdate.ImageUrl = question.ImageUrl;
                    _context.Questions.Update(QuestionToUpdate);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
        }

        // remove question
        public void RemoveQuestion(long questionId)
        {
            try
            {
                var QuestionToRemove = GetQuestionById(questionId);
                if (QuestionToRemove != null)
                {
                    _context.Questions.Remove(QuestionToRemove);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            { }
        }

    }
}
