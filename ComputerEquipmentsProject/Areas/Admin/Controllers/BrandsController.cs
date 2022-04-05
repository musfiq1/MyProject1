using ComputerEquipmentsProject.Data;
using ComputerEquipmentsProject.Models;
using ComputerEquipmentsProject.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerEquipmentsProject.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles ="Admin")]
    public class BrandsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IBrand _service;

        public BrandsController(AppDbContext context, IBrand service)
        {
            _context = context;
            _service = service;
        }
        
        public IActionResult Index()
        {
            ViewBag.Active = "Brands";
            List<Brand> brands = _service.GetBrands();
            return View(_service.GetBrands());
        }


        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }


        [HttpPost]
        public IActionResult Create(Brand model)
        {
            if (ModelState.IsValid)
            {
                _service.CreateBrand(model);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = _context.Categories.ToList();
            return View(model);
        }


        public IActionResult Update(int brandsId)
        {
            Brand brand = _service.GetBrand(brandsId);
            ViewBag.Categories = _context.Categories.ToList();
            return View(brand);
        }



        [HttpPost]
        public IActionResult Update(Brand model)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateBrand(model);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = _context.Categories.ToList();
            return View(model);
        }


        public IActionResult Delete(int brandsId)
        {
            _service.DeleteBrand(brandsId);
            return RedirectToAction("Index");
        }
    }
}
