using HW2.Data.Context;
using HW2.Data.Domain;
using HW2.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Data.Repository.TransactionRepository
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        private readonly HW2Context _dbContext;
        public TransactionRepository(HW2Context dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
