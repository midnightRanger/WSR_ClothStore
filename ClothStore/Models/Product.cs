using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ClothStore.Models
{
    public class Product
    {
        [Key]
        public string ProductArticleNumber { get; set; }
        public string? ProductName { get; set; }
        public string? UnitOfMeasurement { get; set; }
        public double ProductCost { get; set; }
        public int MaxDiscount { get; set; }
        public string? ProductManufacturer { get; set; }
        public string? ProductSupplier { get; set; }
        public string? ProductCategory { get; set; }
        public int ProductDiscountAmount { get; set; }
        public int ProductQuantityInStock { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductPhoto { get; set; }
        public string? ProductStatus { get; set; }

        public List<OrderProduct>? OrderProducts { get; set; } = new();

    }
}
