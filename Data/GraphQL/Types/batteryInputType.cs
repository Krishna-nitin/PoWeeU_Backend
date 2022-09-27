using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;

namespace PoWeeU_Backend.Data.GraphQL.Types
{
    public class batteryInputType : InputObjectGraphType
    {
        public batteryInputType()
        {
            Name = "batteryInput";
            Field<NonNullGraphType<StringGraphType>>("Battery_Id");
            Field<NonNullGraphType<StringGraphType>>("Battery_Brand");
            Field<NonNullGraphType<IntGraphType>>("Battery_Capacity");
            Field<NonNullGraphType<IntGraphType>>("Battery_Price");
            Field<NonNullGraphType<IntGraphType>>("Battery_Count");
            Field<NonNullGraphType<IntGraphType>>("Battery_Charge_status");
            Field<NonNullGraphType<StringGraphType>>("Battery_Provider_Email");
        }
    }
}
