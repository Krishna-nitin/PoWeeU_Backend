using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using PoWeeU_Backend.Data.Entity;
using PoWeeU_Backend.Data.GraphQL;

namespace PoWeeU_Backend.Data.GraphQL.Types
{
    public class BatteryType : ObjectGraphType<BatteryEntity>
    {
        public BatteryType()
        {
            Field(t => t.Battery_Id);
            Field(t => t.Battery_Brand);
            Field(t => t.Battery_Capacity);
            Field(t => t.Battery_Price);
            Field(t => t.Battery_Count);
            Field(t => t.Battery_Charge_status);
            Field(t => t.Battery_Provider_Email);

        }
    }
}
