using ComputerEquipmentsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerEquipmentsProject.Service.IService
{
    public interface IProduct
    {
        List<Product> GetProducts();
        Models.Product GetProduct(int id);
        Models.Product CreateProduct(Models.Product model);
        Models.Product UpdateProduct(Models.Product model);
        bool DeleteProduct(int id);
    }
}
