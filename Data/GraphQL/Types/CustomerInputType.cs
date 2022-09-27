using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;

namespace PoWeeU_Backend.Data.GraphQL.Types
{
    public class CustomerInputType : InputObjectGraphType
    {
        public CustomerInputType()
        {
            Name = "customerInput";
            Field<NonNullGraphType<StringGraphType>>("Cust_Email");
            Field<NonNullGraphType<StringGraphType>>("Cust_Name");
            Field<NonNullGraphType<StringGraphType>>("cust_Password");
        }
    }
}
