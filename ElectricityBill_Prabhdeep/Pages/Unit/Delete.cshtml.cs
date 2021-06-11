using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ElectricityBill_Prabhdeep.BizzLayer;
using ElectricityBill_Prabhdeep.Data;

namespace ElectricityBill_Prabhdeep.Pages.Unit
{
    public class DeleteModel : PageModel
    {
        private readonly ElectricityBill_Prabhdeep.Data.ApplicationDbContext _context;

        public DeleteModel(ElectricityBill_Prabhdeep.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BizzLayer.Unit Unit { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Unit = await _context.Units.FirstOrDefaultAsync(m => m.ID == id);

            if (Unit == null)
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

            Unit = await _context.Units.FindAsync(id);

            if (Unit != null)
            {
                _context.Units.Remove(Unit);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
