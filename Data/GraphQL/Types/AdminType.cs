using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using PoWeeU_Backend.Data.Entity;
using PoWeeU_Backend.Data.GraphQL;

namespace PoWeeU_Backend.Data.GraphQL.Types
{
    public class AdminType : ObjectGraphType<AdminEntity>
    {
        public AdminType()
        {
            Field(t => t.Admin_Email);
            Field(t => t.Admin_Name);
            Field(t => t.Admin_Password);
             
        }
    }
}
