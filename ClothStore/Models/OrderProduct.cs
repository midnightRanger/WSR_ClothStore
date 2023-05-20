using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothStore.Models
{
    public class OrderProduct
    {
        
        public int OrderID { get; set; }
        public Order Order { get; set; }

        
        public string ProductArticleNumber { get; set; }
        public Product Product { get; set; }
    }
}
