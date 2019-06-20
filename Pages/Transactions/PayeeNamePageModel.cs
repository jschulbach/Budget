using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Budget.Models;

namespace Budget.Pages.Transactions
{
    public class PayeeNamePageModel : AccountNamePageModel
    {
        public SelectList PayeeNameSL { get; set; }

        public void PopulatePayeesDropDownList(BudgetContext _context,
            object selectedPayee = null)
        {
            var payeesQuery = from d in _context.Payees
                                   orderby d.Name // Sort by name.
                                   select d;

            PayeeNameSL = new SelectList(payeesQuery.AsNoTracking(),
                        "ID", "Name", selectedPayee);
        }
    }
}