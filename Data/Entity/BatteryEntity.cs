using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PoWeeU_Backend.Data.Entity
{
    public class BatteryEntity
    {
        [Key]
        public string Battery_Id { get; set; }
        public string Battery_Brand { get; set; }
        public int Battery_Capacity { get; set; }
        public int Battery_Price { get; set; }
        public int Battery_Count { get; set; }
        public int Battery_Charge_status { get; set; }
        public string Battery_Provider_Email { get; set; }
    }
}
