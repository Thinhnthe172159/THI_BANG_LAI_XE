using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using THI_BANG_LAI_XE.Models;

namespace THI_BANG_LAI_XE.Dao
{
    public class RegistrationDao
    {
        private readonly ThiBangLaiXeContext _context;

        public RegistrationDao(ThiBangLaiXeContext context)
        {
            _context = context;
        }



        //add registration
        public void AddRigistration(Registration registration)
        {
            try
            {
                _context.Registrations.Add(registration);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        // filter register
        public List<Registration> FilterRegistration(string? FullName, string? Phone, int courseId)
        {
            var list = _context.Registrations.Include(a => a.Course).Include(a => a.User).AsQueryable();
            if (!string.IsNullOrEmpty(FullName))
            {
                list = list.Where(a => a.User.FullName.ToLower().Contains(FullName.ToLower()));
            }
            if (!string.IsNullOrEmpty(Phone))
            {
                list = list.Where(a => (a.User.Phone + "").Contains(Phone));
            }
            if (courseId != 0)
            {
                list = list.Where(a => a.CourseId == courseId);
            }

            return list.ToList();
        }

        public Registration? getRegistedById(long id)
        {
            return _context.Registrations.FirstOrDefault(r => r.RegistrationId == id);
        }
        public Registration? getCourseRegistedByUserId(long Userid)
        {
            return _context.Registrations.Include(a => a.Course).OrderByDescending(r => r.DateCreated).FirstOrDefault(r => r.UserId == Userid);
        }

        public bool checkRegistCourseExist(long Userid)
        {
            return _context.Registrations.Where(r => r.UserId == Userid).Count() > 0;
        }

        public bool IsCourseRegisted(long UserId, int CourseId)
        {
            return _context.Registrations.FirstOrDefault(r => r.UserId == UserId && r.CourseId == CourseId && r.Status == 1) == null ? false : true;
        }


        public void UpdateRegistration(Registration r)
        {
            var regisrtrationToUpdate = getRegistedById(r.RegistrationId);
            if (regisrtrationToUpdate != null)
            {
                try
                {
                    regisrtrationToUpdate.Status = r.Status;
                    _context.Registrations.Update(regisrtrationToUpdate);
                    _context.SaveChanges();
                }
                catch (Exception) { }
            }
        }

        // remove registration
        //public static async void 


    }
}
