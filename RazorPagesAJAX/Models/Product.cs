using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesAJAX.Models
{
    public partial class Product
    {
        public Product()
        {
            SalesOrderDetail = new HashSet<SalesOrderDetail>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; }
        public decimal? Weight { get; set; }
        public int? ProductCategoryId { get; set; }
        public int? ProductModelId { get; set; }
        [DataType(DataType.Date)]
        public DateTime SellStartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? SellEndDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DiscontinuedDate { get; set; }
        public byte[] ThumbNailPhoto { get; set; }
        public string ThumbnailPhotoFileName { get; set; }
        public Guid Rowguid { get; set; }
        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "Category")]
        public virtual ProductCategory ProductCategory { get; set; }
        [Display(Name = "Model")]
        public virtual ProductModel ProductModel { get; set; }
        public virtual ICollection<SalesOrderDetail> SalesOrderDetail { get; set; }
    }
}
