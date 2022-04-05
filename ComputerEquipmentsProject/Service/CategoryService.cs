using ComputerEquipmentsProject.Data;
using ComputerEquipmentsProject.Models;
using ComputerEquipmentsProject.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerEquipmentsProject.Service
{
    public class CategoryService : ICategory
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }
        public Category CreateCategory(Category model)
        {
            _context.Categories.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteCategory(int id)
        {
            Models.Category category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Find(id);
        }

        public Category UpdateCategory(Category model)
        {
            _context.Categories.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
