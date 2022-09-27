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
        public PowerUMutation(ProviderRepository pdrepo,CustomerRepository custrepo,BatteryRepository btrrepo,TransactionRepository trnrepo)
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

            Field<BatteryType>(
               "Decrement_BatteryCount",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id" }),
               resolve: context =>
               {
                   var id = context.GetArgument<string>("id");
                   return btrrepo.Decrement_Count(id);
               }
           );

            Field<TransactionType>(
                "Add_Transaction",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<TransactionInputType>> { Name = "transaction" }),
                resolve: context =>
                {
                    var transaction = context.GetArgument<TransactionEntity>("transaction");
                    return trnrepo.Add_Transaction(transaction);
                }
            );

            Field<BatteryType>(
               "Increment_BatteryCount",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id" }),
               resolve: context =>
               {
                   var id = context.GetArgument<string>("id");
                   return btrrepo.Increment_Count(id);
               }
           );

            Field<IntGraphType>(
                "Remove_provider",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" }),
                resolve: context =>
               {
                   var email = context.GetArgument<string>("email");
                   pdrepo.DeleteProvider(email);
                   return 1;
               }
                );

            Field<IntGraphType>(
               "Remove_Battery",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id" }),
               resolve: context =>
               {
                   var id = context.GetArgument<string>("id");
                   btrrepo.DeleteBattery(id);
                   return 1;
               }
               );
        }
    }
}
