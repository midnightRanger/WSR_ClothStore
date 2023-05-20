using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ClothStore.Models
{
    public class PickupPoint
    {
        [Key]
        public int PickupPointID { get; set; }
        public string? Index { get; set; }
        public string? City { get; set; }
        public string? Building { get; set; }
        public List<Order> Orders { get; set; }
    }
}
