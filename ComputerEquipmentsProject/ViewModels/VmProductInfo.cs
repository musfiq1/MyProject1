using ComputerEquipmentsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerEquipmentsProject.ViewModels
{
    public class VmProductInfo
    {
        public IEnumerable<Brand> Brand { get; set; }
        public IEnumerable<Category> Category { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
