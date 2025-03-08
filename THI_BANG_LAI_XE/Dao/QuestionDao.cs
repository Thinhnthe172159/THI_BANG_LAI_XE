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
        public async Task<List<Question>> GetQuestionListAsync() => await _context.Questions.ToListAsync();

        //get list question by ExamPaper 
        public List<Question> GetQuestionListByExamPaper(int ExamPaperId) => _context.Questions.Include(q=>q.Answers).Where(q => q.ExamPaperId == ExamPaperId).ToList();

        //get question by id
        public async Task<Question?> GetQuestionByIdAsync(long QuestionId) => await _context.Questions.Include(q => q.Answers).FirstOrDefaultAsync(q => q.QuestionId == QuestionId);

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

        // Update question
        public async Task UpdateQuestionAsync(Question question)
        {
            try
            {
                var QuestionToUpdate = await GetQuestionByIdAsync(question.QuestionId);
                if (QuestionToUpdate != null)
                {
                    QuestionToUpdate.ExamPaperId = question.ExamPaperId;
                    QuestionToUpdate.DetailQuestion = question.DetailQuestion;
                    QuestionToUpdate.ImageUrl = question.ImageUrl;
                    _context.Questions.Update(QuestionToUpdate);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
            }
        }

        // remove question
        public async Task RemoveQuestionAsync(long questionId)
        {
            try
            {
                var QuestionToRemove = await GetQuestionByIdAsync(questionId);
                if (QuestionToRemove != null)
                {
                    _context.Questions.Remove(QuestionToRemove);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            { }
        }

    }
}
