using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Identity.Client;
using THI_BANG_LAI_XE.Models;

namespace THI_BANG_LAI_XE.Dao
{
    public class ExamPaperDao
    {
        private readonly ThiBangLaiXeContext _context;

        public ExamPaperDao(ThiBangLaiXeContext context)
        {
            _context = context;
        }


        //get exampaper list
        public async Task<List<ExamPaper>> getExamPaperListAsync() => await _context.ExamPapers.ToListAsync();

        //get Exam paper by Course
        public async Task<List<ExamPaper>> getExamPaperByCourse(int courseId)
        {
            Course? course = await _context.Courses.Include(c=>c.ExamPapers).FirstOrDefaultAsync(c => c.CourseId == courseId);
            return course.ExamPapers.ToList();
        }

        //get exam paper by id
        public async Task<ExamPaper?> getExamPaperByIdAsync(int id) => await _context.ExamPapers.FirstOrDefaultAsync(ex => ex.ExamPaperId == id);

        //add examPaper 
        public void AddExamPaper(ExamPaper examPaper)
        {
            try
            {
                _context.ExamPapers.Add(examPaper);
                _context.SaveChanges();
            }
            catch (Exception)
            {
            }
        }

        // Update Exam paper
        public async Task UpdateExamPaperAsync(ExamPaper examPaper)
        {
            try
            {
                var ExamPaperToUpdate = await getExamPaperByIdAsync(examPaper.ExamPaperId);
                if (ExamPaperToUpdate != null)
                {
                    ExamPaperToUpdate.ExamPaperName = examPaper.ExamPaperName;
                    _context.ExamPapers.Update(ExamPaperToUpdate);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
            }
        }

        //Remove Exampaper
        public async Task RemoveExamPaperAsync(int ExamPaperById)
        {
            try
            {
                var ExamPaperToRemove = await getExamPaperByIdAsync(ExamPaperById);
                if (ExamPaperToRemove != null)
                {
                    _context.ExamPapers.Remove(ExamPaperToRemove);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
