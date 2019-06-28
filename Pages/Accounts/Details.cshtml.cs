using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Budget.Models;

namespace Budget.Pages.Accounts
{
    public class DetailsModel : PageModel
    {
        private readonly Budget.Models.BudgetContext _context;

        public DetailsModel(Budget.Models.BudgetContext context)
        {
            _context = context;
        }

        public Account Account { get; set; }
        public PaginatedList<Transaction> Transaction { get;set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Account = await _context.Accounts.FirstOrDefaultAsync(m => m.ID == id);

            IQueryable<Transaction> transactionIQ = from t in _context.Transactions select t;
            
            //if (!String.IsNullOrEmpty(searchString))
            //{
                transactionIQ = transactionIQ.Where(t => Account.ID == id
                                    /* || t.Payee.Name.Contains(searchString)*/);
            //}

            int pageSize = 3;
            Transaction = await PaginatedList<Transaction>.CreateAsync(
               transactionIQ.AsNoTracking(), 1, pageSize);

            if (Account == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
