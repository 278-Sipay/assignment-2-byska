using HW2.Base.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Data.Domain
{
    public class Account : BaseModel
    {
        //PK
        public int AccountNumber { get; set; }

        public decimal Balance { get; set; }
        public string Name { get; set; }
        public DateTime OpenDate { get; set; }
        public string CurrencyCode { get; set; }
        public bool IsActive { get; set; }


        public virtual List<Transaction> Transactions { get; set; }
    }
}
