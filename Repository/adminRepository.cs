using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoWeeU_Backend.Data;
using PoWeeU_Backend.Data.Entity;

namespace PoWeeU_Backend.Repository
{
    public class adminRepository
    {
        public PowerUdbContext _dbcontext;

        public adminRepository(PowerUdbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public bool Email_exists(string email)
        {
            // return _dbcontext.admins.First(s => s.Admin_Email.Equals(email))==null;
            return _dbcontext.admins.Any(s => s.Admin_Email == email);
        }

        public AdminEntity getByEmail(string email)
        {
            return _dbcontext.admins.First(s => s.Admin_Email == email);
        }

        public bool verifypassword(string email,string pass)
        {
            return _dbcontext.admins.Any(s => s.Admin_Email == email && s.Admin_Password == pass);
        }
    }
}
