using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ElectricityBill_Prabhdeep.BizzLayer;
using ElectricityBill_Prabhdeep.Data;

namespace ElectricityBill_Prabhdeep.Pages.Bill
{
    public class IndexModel : PageModel
    {
        private readonly ElectricityBill_Prabhdeep.Data.ApplicationDbContext _context;

        public IndexModel(ElectricityBill_Prabhdeep.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<BizzLayer.Bill> Bill { get;set; }

        public async Task OnGetAsync()
        {
            Bill = await _context.Bills.ToListAsync();
        }
    }
}
