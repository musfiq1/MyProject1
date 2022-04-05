using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerEquipmentsProject.Models
{
    public class Brand
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(15),Required]
        public string Name { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Product> Products { get; set; }
    }
}
