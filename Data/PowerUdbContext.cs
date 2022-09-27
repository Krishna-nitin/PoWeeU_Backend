using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoWeeU_Backend.Data.Entity;

namespace PoWeeU_Backend.Data
{
    public class PowerUdbContext:DbContext
    {
        public PowerUdbContext(DbContextOptions<PowerUdbContext> options):base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<AdminEntity> admins { get; set; }
        public DbSet<CustomerEntity> customers { get; set; }
        public DbSet<ProviderEntity> providers { get; set; }
        public DbSet<BatteryEntity> batteries { get; set; }
        public DbSet<TransactionEntity> transactions{ get; set; }

    }
}
