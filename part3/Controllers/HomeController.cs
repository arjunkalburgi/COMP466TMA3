using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using part3.Models;

namespace part3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Productpage(string name, string price)
        {

            ProductItem item = new ProductItem(name, Double.Parse(price), "lol holla"); 
            if (name.Contains("Computer")) {
                ViewData["isComp"] = "isComp";

            } else {
                ViewData["isComp"] = null; 

            }
            ViewData["item"] = item;
            ViewData["itemasstring"] = JsonConvert.SerializeObject(item); 

            Response.Cookies.Delete("selecteditem"); 
            CookieOptions selecteditemcookie = new CookieOptions();  
            selecteditemcookie.Expires = DateTime.Now.AddMinutes(10);  
            Response.Cookies.Append("selecteditem", JsonConvert.SerializeObject(item), selecteditemcookie);  

            return View();
        }

        [HttpPost]
        public ActionResult Computereditpage(string name, string price)
        {
            ComputerItem item = new ComputerItem(name, Double.Parse(price), "lol"); 
            ViewData["item"] = item;

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
