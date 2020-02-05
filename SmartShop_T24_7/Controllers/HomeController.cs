using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop_T24_7.Controllers
{
    public class HomeController:Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }

        
    }
}
