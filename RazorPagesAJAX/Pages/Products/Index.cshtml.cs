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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesAJAX.Models.AdventureworksLT2012Context _context;

        public IndexModel(RazorPagesAJAX.Models.AdventureworksLT2012Context context)
        {
            _context = context;
        }

        public string CategorySort { get; set; }
        public string ModelSort { get; set; }
        public string NameSort { get; set; }

        public PaginatedList<Product> Products { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string sortOrder, int? pageIndex)
        {
            CurrentSort = sortOrder;
            CategorySort = String.IsNullOrEmpty(sortOrder) ? "Category_desc" : "";
            ModelSort = sortOrder == "Model" ? "Model_desc" : "Model";
            NameSort = sortOrder == "Name" ? "Name_desc" : "Name";

            var products = _context.Product
                 .Include(p => p.ProductCategory)
                 .Include(p => p.ProductModel)
                 .Where(p => p.ThumbnailPhotoFileName != "no_image_available_small.gif");

            switch (sortOrder)
            {
                case "Category_desc":
                    products =
                       products.OrderByDescending(p => p.ProductCategory.Name);
                    break;
                case "Model":
                    products = products.OrderBy(p => p.ProductModel.Name);
                    break;
                case "Model_desc":
                    products = products.OrderByDescending(p => p.ProductModel.Name);
                    break;
                case "Name":
                    products = products.OrderBy(p => p.Name);
                    break;
                case "Name_desc":
                    products = products.OrderByDescending(p => p.Name);
                    break;
                default:
                    products = products.OrderBy(p => p.ProductCategory.Name);
                    break;
            }

            int pageSize = 10;
            Products = await PaginatedList<Product>.CreateAsync(products.AsNoTracking(),
                pageIndex ?? 1, pageSize);

            //Products = await _context.Product
            //    .Include(p => p.ProductCategory)
            //    .Include(p => p.ProductModel)
            //    .Where(p => p.ThumbnailPhotoFileName != "no_image_available_small.gif")
            //    .OrderBy(p => p.ProductCategory.Name)
            //    .ThenBy(p => p.ProductModel.Name)
            //    .ThenBy(p => p.Name)
            //    .ToListAsync();
        }
    }
}

