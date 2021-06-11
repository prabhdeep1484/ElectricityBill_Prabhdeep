using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ElectricityBill_Prabhdeep.BizzLayer;
using ElectricityBill_Prabhdeep.Data;

namespace ElectricityBill_Prabhdeep.Pages.Customer
{
    public class CreateModel : PageModel
    {
        private readonly ElectricityBill_Prabhdeep.Data.ApplicationDbContext _context;

        public CreateModel(ElectricityBill_Prabhdeep.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BillID"] = new SelectList(_context.Bills, "ID", "BillNo");
        ViewData["UnitID"] = new SelectList(_context.Units, "ID", "TotalUnits");
            return Page();
        }

        [BindProperty]
        public BizzLayer.Customer Customer { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
