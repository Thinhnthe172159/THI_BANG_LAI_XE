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
                _context.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        // add examPaper to exam
        public void AddExamPaperToExam(int ExamId, ExamPaper ep)
        {
            var exam = GetExamById(ExamId);
            if (exam != null)
            {
                try
                {
                    exam.ExamPapers.Add(ep);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                }
            }
        }

        // remove ExamPaper from Exam
        public void RemoveExamPaperToExam(int ExamId, ExamPaper ep)
        {
            var exam = GetExamById(ExamId);
            if (exam != null)
            {
                try
                {
                    exam.ExamPapers.Remove(ep);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                }
            }
        }

        //re move all ExamPaper from Exam
        public void removeAllExamPaperOfExam(int ExamId)
        {
            //try
            //{
            var exam = GetExamById(ExamId);
            var list = exam.ExamPapers.ToList();
            foreach (var exp in list)
            {
                exam.ExamPapers.Remove(exp);
            }
            _context.SaveChanges();
            //}
            //catch (Exception) { }
        }

        // get newest Exam
        public Exam? getNewestExamByCourseId(int courseId)
        {
            var list = _context.Exams.Include(x => x.ExamPapers).OrderByDescending(x => x.DateCreated).AsQueryable();
            return list.FirstOrDefault(x => x.CourseId == courseId);
        }



        public List<Exam> FilterExam(string? room, int courseId, DateOnly? DateStart)
        {
            var ExamList = _context.Exams.Include(x => x.Course).Include(x => x.ExamPapers).AsQueryable();
            if (!string.IsNullOrEmpty(room))
            {
                ExamList = ExamList.Where(x => x.Room.ToLower().Contains(room.ToLower()));
            }
            if (courseId != 0)
            {
                ExamList = ExamList.Where(x => x.CourseId == courseId);
            }
            if (DateStart != null)
            {
                ExamList = ExamList.Where(x => x.Date == DateStart);
            }
            return ExamList.ToList();
        }



        // get exam by id
        public Exam? GetExamById(int examId) => _context.Exams.Include(ex => ex.ExamPapers).Include(ex => ex.Course).FirstOrDefault(ex => ex.ExamId == examId);

        // get Exam list
        public List<Exam> GetExamList() => _context.Exams.Include(e => e.Course).Include(e => e.Results).ToList();

        //Update Exam
        public void UpdateExam(Exam exam)
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
        public void RemoveExam(int ExamId)
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
