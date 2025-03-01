using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Identity.Client;
using THI_BANG_LAI_XE.Models;

namespace THI_BANG_LAI_XE.Dao
{
    public class ExamDao
    {
        private readonly ThiBangLaiXeContext _context;

        public ExamDao(ThiBangLaiXeContext context)
        {
            _context = context;
        }



        // Add new Exam
        public void AddExam(Exam exam)
        {
            try
            {
                _context.Exams.Add(exam);
                _context.SaveChangesAsync();
            }
            catch (Exception)
            {

            }
        }

        // get exam by id
        public async Task<Exam?> GetExamByIdAsync(int examId) => await _context.Exams.FirstOrDefaultAsync(ex => ex.ExamId == examId);

        // get Exam list
        public async Task<List<Exam>> GetExamListAsync() => await _context.Exams.ToListAsync();

        //Update Exam
        public async Task UpdateExamAsync(Exam exam)
        {
            try
            {
                var ExamToUpdate = await GetExamByIdAsync(exam.ExamId);
                if (ExamToUpdate != null)
                {
                    ExamToUpdate.CourseId = exam.CourseId;
                    ExamToUpdate.Date = exam.Date;
                    ExamToUpdate.Room = exam.Room;
                    _context.Exams.Update(ExamToUpdate);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

            }
        }

        // Remove Exam
        public async Task RemoveExamAsync(int ExamId)
        {
            try
            {
                var ExamToRemove = await GetExamByIdAsync(ExamId);
                if (ExamToRemove != null)
                {
                    _context.Exams.Remove(ExamToRemove);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
