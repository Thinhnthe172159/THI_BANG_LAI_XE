using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using THI_BANG_LAI_XE.Models;

namespace THI_BANG_LAI_XE.Dao
{
    public class AnswerDao
    {
        private readonly ThiBangLaiXeContext _context;

        public AnswerDao(ThiBangLaiXeContext context)
        {
            _context = context;
        }



        // get list of answer
        public List<Answer> GetAnswerList() => _context.Answers.ToList();

        // get answer by id 
        public Answer? GetAnswerById(long AnswerId) => _context.Answers.Include(asw => asw.Question).FirstOrDefault(asw => asw.AnswerId == AnswerId);

        //Add Answer 
        public void AddAnswer(Answer answer)
        {
            try
            {
                _context.Answers.Add(answer);
                _context.SaveChangesAsync();
            }
            catch (Exception)
            {
            }
        }

        // Update Answer
        public void UpdateAnswerAsync(Answer answer)
        {
            try
            {
                var AnswerToUdpate = GetAnswerById(answer.AnswerId);
                if (AnswerToUdpate != null)
                {
                    AnswerToUdpate.QuestionId = answer.QuestionId;
                    AnswerToUdpate.DetailAnswer = answer.DetailAnswer;
                    AnswerToUdpate.IsCorrectOrNot = answer.IsCorrectOrNot;
                    _context.Answers.Update(AnswerToUdpate);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            { }
        }

        //remve Answer
        public void RemoveAnswer(long answerId)
        {
            try
            {
                var AnswerToRemove = GetAnswerById(answerId);
                if (AnswerToRemove != null)
                {
                    _context.Answers.Remove(AnswerToRemove);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
