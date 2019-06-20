using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Budget.Models;

namespace Budget.Pages.Payees
{
    public class CreateModel : PageModel
    {
        private readonly Budget.Models.BudgetContext _context;

        public CreateModel(Budget.Models.BudgetContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Payee Payee { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Payees.Add(Payee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}