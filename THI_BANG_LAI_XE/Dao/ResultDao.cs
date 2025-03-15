using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THI_BANG_LAI_XE.Models;

namespace THI_BANG_LAI_XE.Dao
{
    public class ResultDao
    {
        private ThiBangLaiXeContext _context;

        public ResultDao(ThiBangLaiXeContext context)
        {
            _context = context;
        }

        //Add result
        public void AddResult(Result result)
        {
            try
            {
                _context.Results.Add(result);
                _context.SaveChanges();
            }
            catch (Exception) { }
        }

        //get result by userid and examId
        public Result? GetResult(long userId, int examId)
        {
            return _context.Results.FirstOrDefault(r => r.UserId == userId && r.ExamId == examId);
        }

        // get result by id
        public Result? GetResultById(long Resultid) => _context.Results.FirstOrDefault(r => r.ResultId == Resultid);

        //update result status
        public void UpdateResultStatus(Result result)
        {
            try
            {
                var resultToUpdate = GetResultById(result.ResultId);
                if (resultToUpdate != null)
                {
                    resultToUpdate.PassStatus = result.PassStatus;
                    resultToUpdate.Score = result.Score;
                    _context.Results.Update(resultToUpdate);
                    _context.SaveChanges(true);
                }
            }
            catch (Exception)
            {

            }
        }

        // check result exist
        public bool ResultExist(long? userId, int? examId)
        {
            return _context.Results.Where(r => r.UserId == userId && r.ExamId == examId).Count() == 1;
        }
    }
}