using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Budget.Models;

namespace Budget.Pages.Transactions
{
    public class AccountNamePageModel : PageModel
    {
        public SelectList AccountNameSL { get; set; }

        public void PopulateAccountsDropDownList(BudgetContext _context,
            object selectedAccount = null)
        {
            var accountsQuery = from d in _context.Accounts
                                   orderby d.Name // Sort by name.
                                   select d;

            AccountNameSL = new SelectList(accountsQuery.AsNoTracking(),
                        "ID", "Name", selectedAccount);
        }
    }
}