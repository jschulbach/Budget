using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Budget.Models;

namespace Budget.Pages.Payees
{
    public class EditModel : PageModel
    {
        private readonly Budget.Models.BudgetContext _context;

        public EditModel(Budget.Models.BudgetContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Payee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PayeeExists(Payee.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PayeeExists(int id)
        {
            return _context.Payees.Any(e => e.ID == id);
        }
    }
}
