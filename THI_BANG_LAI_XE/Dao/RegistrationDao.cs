using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public List<Registration> getCourseListRegistedById(long id)
        {
            return _context.Registrations.Where(r => r.RegistrationId == id).ToList();
        }
        public Registration? getCourseRegistedByUserId(long Userid)
        {
            return _context.Registrations.OrderByDescending(r => r.DateCreated).FirstOrDefault(r => r.UserId == Userid);
        }

        public bool checkRegistCourseExist(long Userid)
        {
            return _context.Registrations.Where(r => r.UserId == Userid).Count() > 0;
        }

        public bool IsCourseRegisted(long UserId, int CourseId)
        {
            return _context.Registrations.FirstOrDefault(r => r.UserId == UserId && r.CourseId == CourseId) == null ? false : true;
        }

        // remove registration
        //public static async void 


    }
}
