using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Diagnostics.Instrumentation.Extensions.Intercept;
using Microsoft.EntityFrameworkCore;
using PoWeeU_Backend.Data;
using PoWeeU_Backend.Data.Entity;
using PoWeeU_Backend.Repository;

namespace PoWeeU_Backend.Repository
{
    public class CustomerRepository
    {
        public PowerUdbContext _dbcontext1;

        public CustomerRepository(PowerUdbContext dbcontext)
        {
            _dbcontext1 = dbcontext;
        }
        public bool Email_exists(string email)
        {
            //Console.WriteLine(_dbcontext1.customers.First(a => a.Cust_Email.Equals(email)).Cust_Email);
             //return _dbcontext1.customers.First(a => EF.Functions.Collate(a.Cust_Email, "SQL_Latin1_General_CP1_CS_AS"), email)) != null;
            return _dbcontext1.customers.Any(a => a.Cust_Email == email);
        }
        public CustomerEntity getByEmail(string email)
        {
            return _dbcontext1.customers.First(s => s.Cust_Email == email);
        }

        public bool verifypassword(string email, string pass)
        {
            return _dbcontext1.customers.Any(s => s.Cust_Email == email && s.Cust_Password == pass);
        }

        public CustomerEntity AddCustomer(CustomerEntity customer)
        {
            _dbcontext1.customers.Add(customer);
            _dbcontext1.SaveChanges();
            return customer;
        }

        public IEnumerable<CustomerEntity> Get_All_Customers()
        {
            return _dbcontext1.customers;
        }

    }
}
