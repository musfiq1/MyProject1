using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerEquipmentsProject.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(15), Required]
        public string Name { get; set; }
        public List<Brand> Brands{ get; set; }
    }
}
