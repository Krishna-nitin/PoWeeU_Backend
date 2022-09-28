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
        public PowerUMutation(ProviderRepository pdrepo,CustomerRepository custrepo,BatteryRepository btrrepo,TransactionRepository trnrepo,adminRepository adrepos)
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

            Field<BooleanGraphType>(
                "admin_email_verify",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" }),
                resolve: context =>
                {
                    var email = context.GetArgument<string>("email");
                    return adrepos.Email_exists(email);
                }
            );

            Field<BooleanGraphType>(
                "verify_admin_password",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" },
                                              new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "pass" }),
                resolve: context =>
                {
                    var email = context.GetArgument<string>("email");
                    var pass = context.GetArgument<string>("pass");
                    return adrepos.verifypassword(email, pass);
                }
            );

            Field<AdminType>(
               "get_adminByEmail",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" }),
               resolve: context =>
               {
                   var email = context.GetArgument<string>("email");
                   return adrepos.getByEmail(email);
               }
           );

            Field<BooleanGraphType>(
                "customer_email_verify",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" }),
                resolve: context =>
                {
                    var email = context.GetArgument<string>("email");
                    //Console.WriteLine(email);
                    return custrepo.Email_exists(email);
                }
            );

            Field<BooleanGraphType>(
                "verify_customer_password",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" },
                                              new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "pass" }),
                resolve: context =>
                {
                    var email = context.GetArgument<string>("email");
                    var pass = context.GetArgument<string>("pass");
                    return custrepo.verifypassword(email, pass);
                }
            );

            Field<CustomerType>(
               "get_customerByEmail",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" }),
               resolve: context =>
               {
                   var email = context.GetArgument<string>("email");
                   return custrepo.getByEmail(email);
               }
           );

            Field<BooleanGraphType>(
              "provider_email_verify",
              arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" }),
              resolve: context =>
              {
                  var email = context.GetArgument<string>("email");
                  return pdrepo.Email_exists(email);
              }
          );

            Field<BooleanGraphType>(
                "verify_provider_password",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" },
                                              new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "pass" }),
                resolve: context =>
                {
                    var email = context.GetArgument<string>("email");
                    var pass = context.GetArgument<string>("pass");
                    return pdrepo.verifypassword(email, pass);
                }
            );

            Field<ProviderType>(
               "get_providerByEmail",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" }),
               resolve: context =>
               {
                   var email = context.GetArgument<string>("email");
                   return pdrepo.getByEmail(email);
               }
           );

            Field<BooleanGraphType>(
                "verify_battery_id",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");
                    return btrrepo.verify_battery_Id(id);
                }
            );

            Field<ListGraphType<BatteryType>>(
               "get_batteriesByProviderEmail",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" }),
               resolve: context =>
               {
                   var email = context.GetArgument<string>("email");
                   return btrrepo.Get_batteryByProviderEmail(email);
               }
           );

            Field<ListGraphType<TransactionType>>(
               "get_transactionsByProviderEmail",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" }),
               resolve: context =>
               {
                   var email = context.GetArgument<string>("email");
                   return trnrepo.Get_TransactionsbyProviderEmail(email);
               }
           );


            Field<ListGraphType<BatteryType>>(
               "get_BatteriesbyBrand",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "brand" }),
               resolve: context =>
               {
                   var brand = context.GetArgument<string>("brand");
                   return btrrepo.Get_BatteriesByBrand(brand);
               }
           );

            Field<ListGraphType<BatteryType>>(
            "get_BatteriesbyCapacity",
             arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "capacity" }),
            resolve: context =>
            {
                int capacity = context.GetArgument<int>("capacity");
                return btrrepo.Get_BatteriesBycapacity(capacity);
            }
            );

            Field<ListGraphType<BatteryType>>(
              "get_Batteriesby_BrandCapacity",
              arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "brand" },
                                            new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "capacity" }),
              resolve: context =>
              {
                  int capacity = context.GetArgument<int>("capacity");
                  var brand = context.GetArgument<String>("brand");
                  return btrrepo.Get_BatteriesBy_Brandcapacity(brand, capacity);
              }
          );


            Field<IntGraphType>(
                 "get_BatteryCountById",
                 arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id" }),
                 resolve: context =>
                 {
                     var id = context.GetArgument<String>("id");
                     return btrrepo.get_BatteryCountById(id);
                 }
             );

            Field<BatteryType>(
                 "get_BatterybyId",
                 arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id" }),
                 resolve: context =>
                 {
                     var id = context.GetArgument<String>("id");
                     return btrrepo.get_BatterybyId(id);
                 }
             );

            Field<BooleanGraphType>(
               "verify_BatterystatusByBrandCapacity",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "brand" },
                                             new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "cap" }),
               resolve: context =>
               {
                   var brand = context.GetArgument<string>("brand");
                   var cap = context.GetArgument<int>("cap");
                   return btrrepo.verify_status(brand, cap);
               }
           );
        }
    }
}
