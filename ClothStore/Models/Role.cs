﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothStore.Models
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        public string? RoleName { get; set; }
        public List<User> Users { get; set; }
    }
}
