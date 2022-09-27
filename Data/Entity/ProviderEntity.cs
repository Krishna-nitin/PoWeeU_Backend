using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PoWeeU_Backend.Data.Entity
{
    public class ProviderEntity
    {
        [Key]
        public string Provider_Email { get; set; }
        public string Provider_Name { get; set; }
        public string Provider_Password { get; set; }
    }
}
