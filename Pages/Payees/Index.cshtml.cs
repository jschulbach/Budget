using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Budget.Models;

namespace Budget.Pages.Payees
{
    public class IndexModel : PageModel
    {
        private readonly Budget.Models.BudgetContext _context;

        public IndexModel(Budget.Models.BudgetContext context)
        {
            _context = context;
        }

        public IList<Payee> Payee { get;set; }

        public async Task OnGetAsync()
        {
            Payee = await _context.Payees.ToListAsync();
        }
    }
}
