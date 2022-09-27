using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using PoWeeU_Backend.Data.Entity;
using PoWeeU_Backend.Data.GraphQL;

namespace PoWeeU_Backend.Data.GraphQL.Types
{
    public class TransactionType : ObjectGraphType<TransactionEntity>
    {
        public TransactionType()
        {
            Field(t => t.Transaction_Id);
            Field(t => t.Transaction_Battery_Brand);
            Field(t => t.Transaction_Cust_Name);
            Field(t => t.Transaction_Battery_Capacity);
            Field(t => t.Transaction_Date);
            Field(t => t.Transaction_Battery_Id);
            Field(t => t.Transaction_Cust_Email);
        }
    }
}
