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
    public class BrandService : IBrand
    {
        private readonly AppDbContext _context;

        public BrandService(AppDbContext context)
        {
            _context = context;
        }
        public Brand CreateBrand(Brand model)
        {
            _context.Brands.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteBrand(int id)
        {
            Models.Brand brand = _context.Brands.Find(id);
            _context.Brands.Remove(brand);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public Brand GetBrand(int id)
        {
            return _context.Brands.Find(id);
        }

        public List<Brand> GetBrands()
        {
            return _context.Brands.Include(x => x.Category).ToList();
        }

        public Brand UpdateBrand(Brand model)
        {
            _context.Brands.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
