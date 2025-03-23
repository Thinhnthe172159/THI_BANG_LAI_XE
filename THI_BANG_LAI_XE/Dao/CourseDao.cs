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
    public class CourseDao
    {
        private readonly ThiBangLaiXeContext _context;

        public CourseDao(ThiBangLaiXeContext context)
        {
            _context = context;
        }

        // get course list
        public List<Course> GetCourseList() => _context.Courses.Include(c => c.Teacher).Include(c => c.ExamPapers).ToList();

        public List<Course> GetCourseListBylectureId(long userid) => _context.Courses.Include(c => c.Registrations).Include(c => c.Teacher).Where(c => c.TeacherId == userid).ToList();

        //Filter Course by custom field
        public List<Course> FilterCourse(long userId, string courseName, DateOnly? DateStart, DateOnly? DateEnd)
        {
            var courseList = GetCourseListBylectureId(userId);
            if (!string.IsNullOrEmpty(courseName))
            {
                courseList = courseList.Where(c => c.CourseName.ToLower().Contains(courseName.ToLower())).ToList();
            }
            if (DateStart != null)
            {
                courseList = courseList.Where(c => c.StartDate == DateStart).ToList();
            }
            if (DateEnd != null)
            {
                courseList = courseList.Where(c => c.EndDate == DateEnd).ToList();
            }
            return courseList;
        }

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

        //get newest course

        public Course? GetNewestCourse(long lectureId) => _context.Courses.OrderByDescending(c => c.CreateDate).FirstOrDefault(c => c.TeacherId == lectureId);

        //get course by id
        public Course? GetCourseById(int courseId) => _context.Courses.Include(c => c.ExamPapers).Include(c => c.Teacher).FirstOrDefault(c => c.CourseId == courseId);

        //Update course
        public void UpdateCourse(Course course)
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
                    _context.SaveChanges();
                }
            }
            catch (Exception) { }
        }

        public void AddExamPaperToCourse(int CourseId, ExamPaper ep)
        {
            var Course = GetCourseById(CourseId);
            if (Course != null)
            {
                try
                {
                    Course.ExamPapers.Add(ep);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                }
            }
        }


        public void RemoveExamPaperToCourse(int CourseId, ExamPaper ep)
        {
            var Course = GetCourseById(CourseId);
            if (Course != null)
            {
                try
                {
                    Course.ExamPapers.Remove(ep);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                }
            }
        }

        public void removeAllExamPaperOfCourse(int courseid)
        {
            try
            {
                var course = GetCourseById(courseid);
                if (course != null)
                {
                    var list = course.ExamPapers.ToList();
                    foreach (var exp in list)
                    {
                        course.ExamPapers.Remove(exp);
                    }
                    _context.SaveChanges();
                }

            }
            catch (Exception) { }
        }
        //Delete Course
        public void RemoveCourse(int courseId)
        {
            try
            {
                var DeleteCourse = GetCourseById(courseId);
                if (DeleteCourse != null)
                {
                    _context.Courses.Remove(DeleteCourse);
                    _context.SaveChanges();
                }
            }
            catch (Exception) { }
        }
    }
}
