using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElectricityBill_Prabhdeep.BizzLayer;
using ElectricityBill_Prabhdeep.Data;

namespace ElectricityBill_Prabhdeep.Pages.Customer
{
    public class EditModel : PageModel
    {
        private readonly ElectricityBill_Prabhdeep.Data.ApplicationDbContext _context;

        public EditModel(ElectricityBill_Prabhdeep.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BizzLayer.Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customers
                .Include(c => c.Bill)
                .Include(c => c.Unit).FirstOrDefaultAsync(m => m.ID == id);

            if (Customer == null)
            {
                return NotFound();
            }
            ViewData["BillID"] = new SelectList(_context.Bills, "ID", "BillNo");
            ViewData["UnitID"] = new SelectList(_context.Units, "ID", "TotalUnits");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(Customer.ID))
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

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.ID == id);
        }
    }
}
