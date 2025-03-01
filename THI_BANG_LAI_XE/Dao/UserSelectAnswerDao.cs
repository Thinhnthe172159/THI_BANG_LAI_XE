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
    public class UserSelectAnswerDao
    {
        private readonly ThiBangLaiXeContext _context;

        public UserSelectAnswerDao(ThiBangLaiXeContext context)
        {
            _context = context;
        }


        // get all Answer of user by question Id and userId
        public async Task<List<UserSelectedAnswer>> GetAnswerOfUserByExamPaperIdAsync(long QuestID, long userId) => await _context.UserSelectedAnswers.Where(us => us.QuestionId == QuestID && us.UserId == userId).ToListAsync();

        // get Answer by id, 
        public async Task<UserSelectedAnswer?> GetAnswerOfUserByIdAsync(long SelectedID) => await _context.UserSelectedAnswers.FirstOrDefaultAsync(us => us.SelectedId == SelectedID);

        //Add Answer
        public void AddAnswer(UserSelectedAnswer userSelectedAnswer)
        {
            try
            {
                _context.UserSelectedAnswers.Add(userSelectedAnswer);
                 _context.SaveChanges();
            }
            catch (Exception)
            { }
        }

        // Update user Answer
        public async Task UpdateUserAnswerAsync(UserSelectedAnswer userSelectedAnswer)
        {
            try
            {
                var AnswerToUpdate = await GetAnswerOfUserByIdAsync(userSelectedAnswer.SelectedId);
                if (AnswerToUpdate != null)
                {
                    AnswerToUpdate.AnswerId = userSelectedAnswer.AnswerId;
                    _context.UserSelectedAnswers.Update(AnswerToUpdate);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception) { }
        }

        //remove user Answer
        public async Task RemoveUserAnswerAsync(long SelectedId)
        {
            try
            {
                var AnswerToRemove = await GetAnswerOfUserByIdAsync(SelectedId);
                if (AnswerToRemove != null)
                {
                    _context.UserSelectedAnswers.Remove(AnswerToRemove);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception) { }
        }
    }
}