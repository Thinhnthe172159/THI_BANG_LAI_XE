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
        public List<ExamPaper> getFilterExamPaperList(string ExamPaperName)
        {
            var list = _context.ExamPapers.AsQueryable();
            if (!string.IsNullOrEmpty(ExamPaperName))
            {
                list = list.Where(xp => xp.ExamPaperName.ToLower().Contains(ExamPaperName));
            }
            return list.ToList();
        }


        public List<ExamPaper> getExamPaperList() => _context.ExamPapers.ToList();
        //get Exam paper by Course
        public List<ExamPaper> getExamPaperByCourse(int courseId)
        {
            Course? course = _context.Courses.Include(c => c.ExamPapers).FirstOrDefault(c => c.CourseId == courseId);
            return course.ExamPapers.ToList();
        }

        //get exam paper by id
        public ExamPaper? getExamPaperById(int id) => _context.ExamPapers.Include(ex => ex.Questions).FirstOrDefault(ex => ex.ExamPaperId == id);

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
        public void UpdateExamPaperAsync(ExamPaper examPaper)
        {
            try
            {
                var ExamPaperToUpdate = getExamPaperById(examPaper.ExamPaperId);
                if (ExamPaperToUpdate != null)
                {
                    ExamPaperToUpdate.ExamPaperName = examPaper.ExamPaperName;
                    _context.ExamPapers.Update(ExamPaperToUpdate);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
            }
        }

        //Remove Exampaper
        public void RemoveExamPaperAsync(int ExamPaperById)
        {
            try
            {
                var ExamPaperToRemove = getExamPaperById(ExamPaperById);
                if (ExamPaperToRemove != null)
                {
                    _context.ExamPapers.Remove(ExamPaperToRemove);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
