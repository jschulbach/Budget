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
    public class DeleteModel : PageModel
    {
        private readonly Budget.Models.BudgetContext _context;

        public DeleteModel(Budget.Models.BudgetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Payee Payee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Payee = await _context.Payees.FirstOrDefaultAsync(m => m.ID == id);

            if (Payee == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Payee = await _context.Payees.FindAsync(id);

            if (Payee != null)
            {
                _context.Payees.Remove(Payee);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
