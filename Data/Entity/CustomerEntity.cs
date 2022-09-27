using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;    

namespace PoWeeU_Backend.Data.Entity
{
    public class CustomerEntity
    {
        [Key]
        public string Cust_Email { get; set; }
        public string Cust_Name { get; set; }
        public string Cust_Password { get; set; }
    }
}
