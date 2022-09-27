using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using PoWeeU_Backend.Repository;
using PoWeeU_Backend.Data.GraphQL;
using PoWeeU_Backend.Data.GraphQL.Types;



namespace PoWeeU_Backend.Data.GraphQL
{
    public class PoWerUQuery:ObjectGraphType
    {
        public PoWerUQuery(adminRepository adrepos, CustomerRepository custrepos,ProviderRepository pdrepos,BatteryRepository btrrepo,TransactionRepository tranrepo)
        {
            Field<BooleanGraphType>(
                "admin_email_verify",
                arguments : new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email"}),
                resolve: context =>
                {
                    var email = context.GetArgument<string>("email");
                    return adrepos.Email_exists(email);
                }
            ) ;

            Field<BooleanGraphType>(
                "verify_admin_password",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" },
                                              new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "pass" }),
                resolve : context =>
                {
                    var email = context.GetArgument<string>("email");
                    var pass = context.GetArgument<string>("pass");
                    return adrepos.verifypassword(email,pass);
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
                    return custrepos.Email_exists(email);
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
                    return custrepos.verifypassword(email, pass);
                }
            );

            Field<CustomerType>(
               "get_customerByEmail",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" }),
               resolve: context =>
               {
                   var email = context.GetArgument<string>("email");
                   return custrepos.getByEmail(email);
               }
           );

            Field<BooleanGraphType>(
                "provider_email_verify",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" }),
                resolve: context =>
                {
                    var email = context.GetArgument<string>("email");
                    return pdrepos.Email_exists(email);
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
                    return pdrepos.verifypassword(email, pass);
                }
            );

            Field<ProviderType>(
               "get_providerByEmail",
               arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" }),
               resolve: context =>
               {
                   var email = context.GetArgument<string>("email");
                   return pdrepos.getByEmail(email);
               }
           );

            Field<ListGraphType< ProviderType>>(
               "get_all_providers",
               resolve: context =>
               { 
                   return pdrepos.Get_All_Provider();
               }
           );

            Field<ListGraphType<CustomerType>>(
               "get_all_customers",
               resolve: context =>
               {
                   return custrepos.Get_All_Customers();
               }
           );


            Field<ListGraphType<BatteryType>>(
               "get_all_batteries",
               resolve: context =>
               {
                   return btrrepo.Get_All_Batteries();
               }
           );

            Field<ListGraphType<TransactionType>>(
               "get_all_transactions",
               resolve: context =>
               {
                   return tranrepo.Get_All_Transactions();
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
                   return tranrepo.Get_TransactionsbyProviderEmail(email);
               }
           );

            Field<ListGraphType<StringGraphType>>(
              "Get_allBatteryBrands",
              resolve: context =>
              {
                  return btrrepo.Get_allBatteryBrands();
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

            Field<ListGraphType<IntGraphType>>(
              "Get_allBatteryCapacities",
              resolve: context =>
              {
                  return btrrepo.Get_allBatteryCapacities();
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
                  return btrrepo.Get_BatteriesBy_Brandcapacity(brand,capacity);
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


        }
    }
}
