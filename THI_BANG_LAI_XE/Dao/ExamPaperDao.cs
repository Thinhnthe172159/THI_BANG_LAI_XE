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
        private static ThiBangLaiXeContext _context = new ThiBangLaiXeContext();

        //get exampaper list
        public static async Task<List<ExamPaper>> getExamPaperList() => await _context.ExamPapers.ToListAsync();

        //get exam paper by id
        public static async Task<ExamPaper?> getExamPaperById(int id) => await _context.ExamPapers.FirstOrDefaultAsync(ex => ex.ExamPaperId == id);

        //add examPaper 
        public static async Task AddExamPaper(ExamPaper examPaper)
        {
            try
            {
                _context.ExamPapers.Add(examPaper);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
            }
        }

        // Update Exam paper
        public static async Task UpdateExamPaper(ExamPaper examPaper)
        {
            try
            {
                var ExamPaperToUpdate = await getExamPaperById(examPaper.ExamPaperId);
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
        public static async Task RemoveExamPaper(int ExamPaperById)
        {
            try
            {
                var ExamPaperToRemove = await getExamPaperById(ExamPaperById);
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
