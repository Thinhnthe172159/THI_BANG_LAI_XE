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
        private static ThiBangLaiXeContext _context = new ThiBangLaiXeContext();

        //add registration
        public static async void AddRigistration(Registration registration)
        {
            try
            {
                _context.Registrations.Add(registration);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        // remove registration
        //public static async void 


    }
}
