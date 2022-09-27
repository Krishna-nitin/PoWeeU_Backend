using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using PoWeeU_Backend.Data.Entity;
using PoWeeU_Backend.Data.GraphQL;

namespace PoWeeU_Backend.Data.GraphQL.Types
{
    public class CustomerType : ObjectGraphType<CustomerEntity>
    {
        public CustomerType()
        {
            Field(t => t.Cust_Email);
            Field(t => t.Cust_Name);
            Field(t => t.Cust_Password);
        }
    }
}
