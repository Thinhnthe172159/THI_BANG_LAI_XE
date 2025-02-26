using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using THI_BANG_LAI_XE.Models;

namespace THI_BANG_LAI_XE.Dao
{
    public class CourseDao
    {
        private static ThiBangLaiXeContext _context = new ThiBangLaiXeContext();

        // get course list
        public static List<Course> GetCourseList() => _context.Courses.ToList();

        // Add course
        public static void AddCourse(Course course)
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
        public static Course? GetCourseById(int courseId) => _context.Courses.FirstOrDefault(c => c.CourseId == courseId);

        //Update course
        public static void UpdateCourse()
        {

        }
    }
}
