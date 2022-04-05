using ComputerEquipmentsProject.Data;
using ComputerEquipmentsProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerEquipmentsProject.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
           _context = context;
        }
        public IActionResult Index()
        {
            VmProductInfo vmProductInfo = new VmProductInfo();
            vmProductInfo.Category = _context.Categories.ToList();
            vmProductInfo.Brand = _context.Brands.ToList();
            vmProductInfo.Products = _context.Products.ToList();
            return View(vmProductInfo);
        }
    }
}
