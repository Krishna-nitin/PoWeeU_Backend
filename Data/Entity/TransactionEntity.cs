using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PoWeeU_Backend.Data.Entity
{
    public class TransactionEntity
    {
        [Key]
        public string Transaction_Id { get; set; }
        public string Transaction_Battery_Brand { get; set; }
        public string Transaction_Cust_Name { get; set; }
        public int Transaction_Battery_Capacity { get; set; }
        public DateTime Transaction_Date { get; set; }
        public string Transaction_Battery_Id { get; set; }
        public string Transaction_Cust_Email { get; set; }
    }
}
