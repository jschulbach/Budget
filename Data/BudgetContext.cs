using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Budget.Models;

namespace Budget.Models
{
    public class BudgetContext : DbContext
    {
        public BudgetContext (DbContextOptions<BudgetContext> options)
            : base(options)
        {
        }

        public DbSet<Budget.Models.Account> Accounts { get; set; }

        public DbSet<Budget.Models.Payee> Payees { get; set; }

        public DbSet<Budget.Models.Transaction> Transactions { get; set; }
    }
}
