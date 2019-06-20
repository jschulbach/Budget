using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Budget.Models;

namespace Budget.Pages.Transactions
{
    public class EditModel : PayeeNamePageModel
    {
        private readonly Budget.Models.BudgetContext _context;

        public EditModel(Budget.Models.BudgetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Transaction Transaction { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Transaction = await _context.Transactions
                .Include(t => t.Account).FirstOrDefaultAsync(m => m.TransactionID == id);

            if (Transaction == null)
            {
                return NotFound();
            }
            PopulatePayeesDropDownList(_context,Transaction.PayeeID);
            PopulateAccountsDropDownList(_context, Transaction.AccountID);
           ViewData["AccountID"] = new SelectList(_context.Accounts, "ID", "ID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Transaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionExists(Transaction.TransactionID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            PopulatePayeesDropDownList(_context,Transaction.PayeeID);
            PopulateAccountsDropDownList(_context, Transaction.AccountID);
            return RedirectToPage("./Index");
        }

        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.TransactionID == id);
        }
    }
}
