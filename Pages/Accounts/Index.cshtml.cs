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
    public class IndexModel : PageModel
    {
        private readonly Budget.Models.BudgetContext _context;

        public IndexModel(Budget.Models.BudgetContext context)
        {
            _context = context;
        }

        public IList<Account> Account { get;set; }

        public async Task OnGetAsync()
        {
            Account = await _context.Accounts.ToListAsync();
        }
    }
}
