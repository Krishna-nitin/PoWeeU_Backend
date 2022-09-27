using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Diagnostics.Instrumentation.Extensions.Intercept;
using Microsoft.EntityFrameworkCore;
using PoWeeU_Backend.Data;
using PoWeeU_Backend.Data.Entity;
using PoWeeU_Backend.Repository;

namespace PoWeeU_Backend.Repository
{
    public class ProviderRepository
    {
        public PowerUdbContext _dbcontext1;

        public ProviderRepository(PowerUdbContext dbcontext)
        {
            _dbcontext1 = dbcontext;
        }
        public bool Email_exists(string email)
        {
            return _dbcontext1.providers.Any(a => a.Provider_Email == email);
        }
        public ProviderEntity getByEmail(string email)
        {
            return _dbcontext1.providers.First(s => s.Provider_Email == email);
        }

        public bool verifypassword(string email, string pass)
        {
            return _dbcontext1.providers.Any(s => s.Provider_Email == email && s.Provider_Password == pass);
        }

        public ProviderEntity AddProvider(ProviderEntity provider)
        {
            _dbcontext1.providers.Add(provider);
            _dbcontext1.SaveChanges();
            return provider;
        }

        public IEnumerable<ProviderEntity> Get_All_Provider()
        {
            return _dbcontext1.providers;
        }
    }
}
