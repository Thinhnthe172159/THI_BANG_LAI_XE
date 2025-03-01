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

        // remove registration
        //public static async void 


    }
}
