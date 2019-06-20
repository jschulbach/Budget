using System;
using System.Collections.Generic;

namespace Budget.Models
{
    public class Account
    {
        public int ID { get; set; }
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}