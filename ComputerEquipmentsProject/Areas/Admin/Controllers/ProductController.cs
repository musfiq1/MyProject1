using ComputerEquipmentsProject.Data;
using ComputerEquipmentsProject.Models;
using ComputerEquipmentsProject.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerEquipmentsProject.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IProduct _product;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(AppDbContext context, IProduct product, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _product = product;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            ViewBag.Active = "Product";
            List<Product> product = _product.GetProducts();
            return View(_product.GetProducts());
        }


        public IActionResult Create()
        {
            ViewBag.Brands = _context.Brands.ToList();
            return View();
        }


        [HttpPost]
        public IActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile==null)
                {
                    ModelState.AddModelError("", "You must send image!");
                    ViewBag.Brands = _context.Brands.ToList();
                    return View(model);
                }

                if (!(model.ImageFile.ContentType == "image/jpg" || model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/jpeg"))
                {
                    ModelState.AddModelError("", "You must send only: jpg, png & jpeg files!");
                    ViewBag.Brands = _context.Brands.ToList();
                    return View(model);
                }

                if (model.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("", "You must send only 2MB max size!");
                    ViewBag.Brands = _context.Brands.ToList();
                    return View(model);
                }

                string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss-") + model.ImageFile.FileName;
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageFile.CopyTo(stream);
                }

                model.Image = fileName;
                _product.CreateProduct(model);
                return RedirectToAction("Index");
            }
            ViewBag.Brands = _context.Brands.ToList();
            return View(model);
        }



        public IActionResult Update(int productId)
        {
            if (productId == null && productId <= 0)
            {
                return NotFound();
            }
            Product product = _product.GetProduct(productId);
            ViewBag.Brands = _context.Brands.ToList();
            return View(product);
        }



        [HttpPost]
        public IActionResult Update(Product model)
        {
            if (ModelState.IsValid)
            {
                _product.UpdateProduct(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }



        [HttpPost]
        public IActionResult UpdateImage(Product newImage)
        {
            if (newImage.ImageFile != null)
            {

                if (!(newImage.ImageFile.ContentType == "image/jpg" || newImage.ImageFile.ContentType == "image/jpeg" || newImage.ImageFile.ContentType == "image/png"))
                {
                    ModelState.AddModelError("", "You can only upload jpg, jpeg & png files!");
                    ViewBag.Categories = _context.Categories.ToList();
                    return View(newImage);
                }

                if (newImage.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("", "You can upload only max 2MB size images!");
                    ViewBag.Categories = _context.Categories.ToList();
                    return View(newImage);
                }


                //var about = _context.Abouts.FirstOrDefault(x => x.ID == newImage.ID);
                var prod1 = _context.Products.First(x => x.ID == newImage.ID);


                string oldFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads/Images", prod1.Image);
                System.IO.File.Delete(oldFilePath);

                string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss-") + newImage.ImageFile.FileName;
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    newImage.ImageFile.CopyTo(stream);
                }

                prod1.Image = fileName;
                _product.UpdateProduct(prod1);
                //_about.UpdateAbout(about);

            }

            return RedirectToAction("Index", new { productId = newImage.ID });
        }



        public IActionResult Delete(int productId)
        {
            _product.DeleteProduct(productId);
            return RedirectToAction("Index");
        }

    }
}
