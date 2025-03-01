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
        public async Task<List<Answer>> GetAnswerListAsync() => await _context.Answers.ToListAsync();

        // get answer by id 
        public async Task<Answer?> GetAnswerByIdAsync(long AnswerId) => await _context.Answers.FirstOrDefaultAsync(asw => asw.AnswerId == AnswerId);

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
        public async Task UpdateAnswerAsync(Answer answer)
        {
            try
            {
                var AnswerToUdpate = await GetAnswerByIdAsync(answer.AnswerId);
                if (AnswerToUdpate != null)
                {
                    AnswerToUdpate.QuestionId = answer.QuestionId;
                    AnswerToUdpate.DetailAnswer = answer.DetailAnswer;
                    AnswerToUdpate.IsCorrectOrNot = answer.IsCorrectOrNot;
                    _context.Answers.Update(AnswerToUdpate);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            { }
        }

        //remve Answer
        public async Task RemoveAnswerAsync(long answerId)
        {
            try
            {
                var AnswerToRemove = await GetAnswerByIdAsync(answerId);
                if (AnswerToRemove != null)
                {
                    _context.Answers.Remove(AnswerToRemove);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
