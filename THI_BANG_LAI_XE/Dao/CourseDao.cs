﻿using System;
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
        private static ThiBangLaiXeContext _context = new ThiBangLaiXeContext();

        // get course list
        public static async Task<List<Course>> GetCourseList() => await _context.Courses.ToListAsync();

        //Filter Course by custom field


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
        public static async Task<Course?> GetCourseById(int courseId) => await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == courseId);

        //Update course
        public static async Task UpdateCourse(Course course)
        {
            try
            {
                var UpdateCourse = await GetCourseById(course.CourseId);
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
                var DeleteCourse = await GetCourseById(courseId);
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
