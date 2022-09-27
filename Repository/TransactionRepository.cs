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
    public class TransactionRepository
    {
        public PowerUdbContext _dbcontext1;

        public TransactionRepository(PowerUdbContext dbcontext)
        {
            _dbcontext1 = dbcontext;
        }
        public IEnumerable<TransactionEntity> Get_All_Transactions()
        {
            return _dbcontext1.transactions;
        }

        public IEnumerable<TransactionEntity> Get_TransactionsbyProviderEmail(string mail)
        {
            return _dbcontext1.transactions.Where(s => s.Transaction_Provider_Email == mail);
        }
    }
}
