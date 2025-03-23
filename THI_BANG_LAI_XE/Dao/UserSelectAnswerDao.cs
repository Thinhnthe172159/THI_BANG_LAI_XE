using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        //Update user Answer
        public void UpdateUserAnswer(UserSelectedAnswer userSelectedAnswer)
        {
            try
            {
                var AnswerToUpdate = GetAnswerOfUserById(userSelectedAnswer.QuestionId, userSelectedAnswer.UserId);
                if (AnswerToUpdate != null)
                {
                    AnswerToUpdate.AnswerId = userSelectedAnswer.AnswerId;
                    _context.UserSelectedAnswers.Update(AnswerToUpdate);
                    _context.SaveChanges();
                }
            }
            catch (Exception) { }
        }

        //check answer selected
        public bool checkAnswerSelect(long questId, long UserId, long answerId)
        {
            return _context.UserSelectedAnswers.Where(a => a.QuestionId == questId && a.UserId == UserId && a.AnswerId == answerId).Count() == 1;
        }

        public UserSelectedAnswer? GetAnswerOfUserById(long questId, long UserId) => _context.UserSelectedAnswers.Include(a => a.Answer).FirstOrDefault(a => a.QuestionId == questId && a.UserId == UserId);

        // get answer of user by exam paper id
        public List<UserSelectedAnswer> GetAnserOfUserByExamPaperId(int ExamPaperId)
        {
            return _context.UserSelectedAnswers.Include(a => a.Question).Include(a => a.Answer).Where(a => a.Question.ExamPaperId == ExamPaperId).ToList();
        }

        public List<UserSelectedAnswer> getListUserAnswer(long userId, int examPaperId)
        {
            return _context.UserSelectedAnswers.Include(a => a.Question).Include(a => a.Answer).Where(a => a.UserId == userId && a.Question.ExamPaperId == examPaperId).ToList();
        }

        public void DeleteDataRecored(long userId, long QuestionID)
        {
            try
            {
                var AnswearSelected = GetAnswerOfUserById(QuestionID, userId);
                if (AnswearSelected != null)
                {
                    _context.UserSelectedAnswers.Remove(AnswearSelected);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
            }

        }
    }
}