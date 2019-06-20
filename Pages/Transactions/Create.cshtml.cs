using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Budget.Models;

namespace Budget.Pages.Transactions
{
    public class CreateModel : PayeeNamePageModel
    {
        private readonly Budget.Models.BudgetContext _context;

        public CreateModel(Budget.Models.BudgetContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AccountID"] = new SelectList(_context.Accounts, "ID", "ID");
            PopulatePayeesDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Transaction Transaction { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Transactions.Add(Transaction);
            await _context.SaveChangesAsync();
            PopulatePayeesDropDownList(_context, Transaction.PayeeID);
            return RedirectToPage("./Index");
        }
    }
}