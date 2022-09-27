using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using PoWeeU_Backend.Data.Entity;
using PoWeeU_Backend.Data.GraphQL;
using PoWeeU_Backend.Repository;
using PoWeeU_Backend.Data.GraphQL.Types;

namespace PoWeeU_Backend.Data.GraphQL
{
    public class PowerUMutation : ObjectGraphType
    {
        public PowerUMutation(ProviderRepository pdrepo,CustomerRepository custrepo,BatteryRepository btrrepo)
        {
            Field<ProviderType>(
                "Add_provider",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProviderInputType>> { Name = "provider"}),
                resolve : context =>
                {
                    var provider = context.GetArgument<ProviderEntity>("provider");
                    return pdrepo.AddProvider(provider);
                }
             );

            Field<CustomerType>(
                "Add_customer",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CustomerInputType>> { Name = "customer" }),
                resolve: context =>
                {
                    var customer = context.GetArgument<CustomerEntity>("customer");
                    return custrepo.AddCustomer(customer);
                }
            );

            Field<BatteryType>(
                "Add_battery",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<batteryInputType>> { Name = "battery" }),
                resolve: context =>
                {
                    var battery = context.GetArgument<BatteryEntity>("battery");
                    return btrrepo.AddBattery(battery);
                }
            );
        }
    }
}
