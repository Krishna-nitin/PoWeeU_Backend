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
    public class BatteryRepository
    {
        public PowerUdbContext _dbcontext1;

        public BatteryRepository(PowerUdbContext dbcontext)
        {
            _dbcontext1 = dbcontext;
        }
        public IEnumerable<BatteryEntity> Get_All_Batteries()
        {
            return _dbcontext1.batteries;
        }

        public bool verify_battery_Id(string btrid)
        {
            return _dbcontext1.batteries.Any(s => s.Battery_Id == btrid);
        }

        public BatteryEntity AddBattery(BatteryEntity btr)
        {
            _dbcontext1.batteries.Add(btr);
            _dbcontext1.SaveChanges();
            return btr;
        }

        public IEnumerable<BatteryEntity> Get_batteryByProviderEmail(string mail)
        {
            return _dbcontext1.batteries.Where(s => s.Battery_Provider_Email == mail);
        }

        public IEnumerable<string> Get_allBatteryBrands()
        {
            List<string> intermediate = new List<string>();
            foreach(var i in _dbcontext1.batteries)
            {
                intermediate.Add(i.Battery_Brand);
            }
            var result = intermediate.Distinct();
            return result;
        }

        //public IEnumerable<BatteryEntity> Get_BatteriesByBrand(str)
             
    }
}
