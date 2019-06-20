using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Budget.Models;

namespace Budget.Pages.Transactions
{
    public class IndexModel : PageModel
    {
        private readonly Budget.Models.BudgetContext _context;

        public float total { get; set; }
        public string CurrentFilter { get; set; }
        public IndexModel(Budget.Models.BudgetContext context)
        {
            _context = context;
        }

        public PaginatedList<Transaction> Transaction { get;set; }

        public async Task<IActionResult> OnGetAsync(string searchString, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            IQueryable<Transaction> transactionIQ = from t in _context.Transactions.Include(t => t.Account)
                                            select t;
            
            //if (!String.IsNullOrEmpty(searchString))
            //{
                transactionIQ = transactionIQ.Where(t => t.Account.ID == id
                                    /* || t.Payee.Name.Contains(searchString)*/);
            //}

            int pageSize = 3;
            Transaction = await PaginatedList<Transaction>.CreateAsync(
               transactionIQ.AsNoTracking(), 1, pageSize);
            //Transaction = await _context.Transactions.Include(t => t.Account).ToListAsync();
            foreach(var t in Transaction)
            {
                total += t.Amount;
            }
            return Page();
        }
    }
}
