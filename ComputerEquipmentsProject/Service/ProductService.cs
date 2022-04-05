using ComputerEquipmentsProject.Data;
using ComputerEquipmentsProject.Models;
using ComputerEquipmentsProject.Service.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerEquipmentsProject.Service
{
    public class ProductService : IProduct
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        public Product CreateProduct(Product model)
        {
            _context.Products.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteProduct(int id)
        {
            Models.Product product = _context.Products.Find(id);
            _context.Products.Remove(product);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public Product GetProduct(int id)
        {
            return _context.Products.Find(id);
        }

        public List<Product> GetProducts()
        {
            return _context.Products.Include(x => x.Brand).ToList();
        }

        public Product UpdateProduct(Product model)
        {
            _context.Products.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
