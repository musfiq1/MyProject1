using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerEquipmentsProject.Controllers
{
    public class ComingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
