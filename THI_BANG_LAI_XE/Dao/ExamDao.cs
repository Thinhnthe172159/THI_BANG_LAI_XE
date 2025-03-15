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
        public Exam? GetExamById(int examId) => _context.Exams.Include(ex => ex.ExamPapers).Include(ex => ex.Course).FirstOrDefault(ex => ex.ExamId == examId);

        // get Exam list
        public List<Exam> GetExamList() => _context.Exams.Include(e => e.Course).Include(e => e.Results).ToList();

        //Update Exam
        public void UpdateExamAsync(Exam exam)
        {
            try
            {
                var ExamToUpdate = GetExamById(exam.ExamId);
                if (ExamToUpdate != null)
                {
                    ExamToUpdate.CourseId = exam.CourseId;
                    ExamToUpdate.Date = exam.Date;
                    ExamToUpdate.Room = exam.Room;
                    _context.Exams.Update(ExamToUpdate);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }

        // Remove Exam
        public void RemoveExamAsync(int ExamId)
        {
            try
            {
                var ExamToRemove = GetExamById(ExamId);
                if (ExamToRemove != null)
                {
                    _context.Exams.Remove(ExamToRemove);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
