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
    public class DetailsModel : PageModel
    {
        private readonly ElectricityBill_Prabhdeep.Data.ApplicationDbContext _context;

        public DetailsModel(ElectricityBill_Prabhdeep.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
