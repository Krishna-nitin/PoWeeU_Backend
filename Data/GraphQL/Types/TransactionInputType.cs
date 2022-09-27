using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;

namespace PoWeeU_Backend.Data.GraphQL.Types
{
    public class TransactionInputType : InputObjectGraphType
    {
        public TransactionInputType()
        {
            Name = "TransactionInput";
            Field<NonNullGraphType<StringGraphType>>("Transaction_Id");
            Field<NonNullGraphType<StringGraphType>>("Transaction_Battery_Brand");
            Field<NonNullGraphType<StringGraphType>>("Transaction_Cust_Name");
            Field<NonNullGraphType<IntGraphType>>("Transaction_Battery_Capacity");
            Field<NonNullGraphType<StringGraphType>>("Transaction_Battery_Id");
            Field<NonNullGraphType<StringGraphType>>("Transaction_Cust_Email");
            Field<NonNullGraphType<StringGraphType>>("Transaction_Provider_Email");
        }
        
    }
}
