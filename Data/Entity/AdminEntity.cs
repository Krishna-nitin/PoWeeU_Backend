using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PoWeeU_Backend.Data.Entity
{
    public class AdminEntity
    {
        [Key]
        public string Admin_Email { get; set; }
        public string Admin_Name { get; set; }
        public string Admin_Password { get; set; }
    }
}
