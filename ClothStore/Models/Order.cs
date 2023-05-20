using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothStore.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? OrderDeliveryDate { get; set; }
        public int? OrderPickupPointID { get; set; }
        public PickupPoint? OrderPickupPoint { get; set; }

        public int? ClientID { get; set; }
        public User? Client { get; set; }

        public int? Code { get; set; }
        public string? Status { get; set; }
        public List<OrderProduct>? OrderProducts { get; set; } = new();
    }
}
