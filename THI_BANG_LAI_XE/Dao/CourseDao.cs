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
    public class CourseDao
    {
        private readonly ThiBangLaiXeContext _context;

        public CourseDao(ThiBangLaiXeContext context)
        {
            _context = context;
        }

        // get course list
        public async Task<List<Course>> GetCourseList() => await _context.Courses.ToListAsync();

        //Filter Course by custom field


        // Add course
        public void AddCourse(Course course)
        {
            try
            {
                _context.Courses.Add(course);
                _context.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        //get course by id
        public Course? GetCourseById(int courseId) => _context.Courses.Include(c => c.ExamPapers).FirstOrDefault(c => c.CourseId == courseId);

        //Update course
        public async Task UpdateCourse(Course course)
        {
            try
            {
                var UpdateCourse = GetCourseById(course.CourseId);
                if (UpdateCourse != null)
                {
                    UpdateCourse.CourseName = course.CourseName;
                    UpdateCourse.TeacherId = course.TeacherId;
                    UpdateCourse.StartDate = course.StartDate;
                    UpdateCourse.EndDate = course.EndDate;
                    UpdateCourse.ModifiedDate = DateTime.Now;
                    _context.Courses.Update(UpdateCourse);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception) { }
        }

        //Delete Course
        public async Task RemoveCourse(int courseId)
        {
            try
            {
                var DeleteCourse = GetCourseById(courseId);
                if (DeleteCourse != null)
                {
                    _context.Courses.Remove(DeleteCourse);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception) { }
        }
    }
}
