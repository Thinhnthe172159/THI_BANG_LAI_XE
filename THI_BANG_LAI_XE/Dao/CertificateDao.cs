using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THI_BANG_LAI_XE.Models;

namespace THI_BANG_LAI_XE.Dao
{
    public class CertificateDao
    {
        private ThiBangLaiXeContext _db;

        public CertificateDao(ThiBangLaiXeContext db)
        {
            _db = db;
        }

        public Certificate GetCertificateByUserId(long userId)
        {
            return _db.Certificates.FirstOrDefault(c => c.UserId == userId);
        }

        public void AddCertificate(Certificate certificate)
        {
            _db.Certificates.Add(certificate);
            _db.SaveChanges();
        }

        public void RemoveCertificate(Certificate certificate)
        {
            _db.Certificates.Remove(certificate);
            _db.SaveChanges();
        }
    }
}
