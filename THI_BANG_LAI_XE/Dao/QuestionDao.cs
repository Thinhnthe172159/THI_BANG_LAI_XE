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
        private static ThiBangLaiXeContext _context = new ThiBangLaiXeContext();

        //get list questions
        public static async Task<List<Question>> GetQuestionList() => await _context.Questions.ToListAsync();

        //get question by id
        public static async Task<Question?> GetQuestionById(long QuestionId) => await _context.Questions.FirstOrDefaultAsync(q => q.QuestionId == QuestionId);

        // Add new question
        public static async Task AddQuestion(Question question)
        {
            try
            {
                _context.Questions.Add(question);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
            }
        }

        // Update question
        public static async Task UpdateQuestion(Question question)
        {
            try
            {
                var QuestionToUpdate = await GetQuestionById(question.QuestionId);
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
        public static async Task RemoveQuestion(long questionId)
        {
            try
            {
                var QuestionToRemove = await GetQuestionById(questionId);
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
