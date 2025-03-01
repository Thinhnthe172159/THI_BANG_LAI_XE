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
        public async Task<List<ExamPaper>> getExamPaperList() => await _context.ExamPapers.ToListAsync();

        //get exam paper by id
        public async Task<ExamPaper?> getExamPaperById(int id) => await _context.ExamPapers.FirstOrDefaultAsync(ex => ex.ExamPaperId == id);

        //add examPaper 
        public async Task AddExamPaper(ExamPaper examPaper)
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
        public async Task UpdateExamPaper(ExamPaper examPaper)
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
        public async Task RemoveExamPaper(int ExamPaperById)
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
