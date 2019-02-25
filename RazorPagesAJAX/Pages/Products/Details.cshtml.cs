using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesAJAX.Models;

namespace RazorPagesAJAX.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesAJAX.Models.AdventureworksLT2012Context _context;

        public DetailsModel(RazorPagesAJAX.Models.AdventureworksLT2012Context context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductModel).FirstOrDefaultAsync(m => m.ProductId == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
