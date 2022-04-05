using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerEquipmentsProject.Models
{
    public class CustomUser: IdentityUser
    {
        [MaxLength(30), Required]
        public string Name { get; set; }
        [MaxLength(30), Required]
        public string SurName { get; set; }
        public byte Age { get; set; }
    }
}
