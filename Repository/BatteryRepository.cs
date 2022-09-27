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

        public IEnumerable<BatteryEntity> Get_BatteriesByBrand(string brand)
        {
            return _dbcontext1.batteries.Where(s => s.Battery_Brand == brand);
        }

        public IEnumerable<int> Get_allBatteryCapacities()
        {
            List<int> intermediate = new List<int>();
            foreach (var i in _dbcontext1.batteries)
            {
                intermediate.Add(i.Battery_Capacity);
            }
            var result = intermediate.Distinct();
            return result;
        }

        public IEnumerable<BatteryEntity> Get_BatteriesBycapacity(int cap)
        {
            return _dbcontext1.batteries.Where(s => s.Battery_Capacity == cap);
        }

        public IEnumerable<BatteryEntity> Get_BatteriesBy_Brandcapacity(string brand,int cap)
        {
            return _dbcontext1.batteries.Where(s => s.Battery_Capacity == cap && s.Battery_Brand==brand);
        }

        public int get_BatteryCountById(string Id)
        {
            return _dbcontext1.batteries.First(s => s.Battery_Id == Id).Battery_Count;
        }

        public BatteryEntity get_BatterybyId(string Id)
        {
            return _dbcontext1.batteries.First(s => s.Battery_Id == Id);
        }

        public BatteryEntity Decrement_Count(string Id)
        {
            var cnt =_dbcontext1.batteries.First(s => s.Battery_Id == Id).Battery_Count;
            cnt = cnt - 1;
            _dbcontext1.batteries.First(s => s.Battery_Id == Id).Battery_Count = cnt;
            _dbcontext1.SaveChanges();
            return _dbcontext1.batteries.First(s => s.Battery_Id == Id);
        }

    }
}
