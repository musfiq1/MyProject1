using ComputerEquipmentsProject.Data;
using ComputerEquipmentsProject.Models;
using ComputerEquipmentsProject.Service;
using ComputerEquipmentsProject.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerEquipmentsProject.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize(Roles ="Admin, Manager")]
    public class CategoriesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICategory _service;

        public CategoriesController(AppDbContext context, ICategory service)
        {
            _context = context;
           _service = service;
        }
        public IActionResult Index()
        {
            ViewBag.Active = "Categories";
            List<Category> categories = _service.GetCategories();
            return View(_service.GetCategories());
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                _service.CreateCategory(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public IActionResult Update(int categoryId)
        {
            Category category = _service.GetCategory(categoryId);       
            return View(category);
        }


        [HttpPost]
        public IActionResult Update(Category model)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateCategory(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int categoryId)
        {
            _service.DeleteCategory(categoryId);
            return RedirectToAction("Index");
        }
    }
}
