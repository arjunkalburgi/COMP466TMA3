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

        //List<ProductItem> carteditems;
        //List<ComputerItem> cartedcomps;

        ComputerItem selectedcomp; 

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

            //Response.Cookies.Delete("selecteditem"); 
            //CookieOptions selecteditemcookie = new CookieOptions();  
            //selecteditemcookie.Expires = DateTime.Now.AddMinutes(10);  
            //Response.Cookies.Append("selecteditem", JsonConvert.SerializeObject(item), selecteditemcookie);  

            return View();
        }

        [HttpPost]
        public ActionResult Computereditpage(string name, string price)
        {
            ComputerItem item = new ComputerItem(name, Double.Parse(price), "lol");
            selectedcomp = item; 
            ViewData["item"] = item;

            return View();
        }

        [HttpPost]
        public ActionResult Computereditpage2(string name, string price, string description, string RAM, string HD, string CPU, string OS, string Display, string SoundCard, string componentname, string componentprice)
        {
            // rebuild computer
            ComputerItem item = new ComputerItem(name, Double.Parse(price), description);
            item.RAM = JsonConvert.DeserializeObject<ProductItem>(RAM); 
            item.HD = JsonConvert.DeserializeObject<ProductItem>(HD); 
            item.CPU = JsonConvert.DeserializeObject<ProductItem>(CPU); 
            item.OS = JsonConvert.DeserializeObject<ProductItem>(OS); 
            item.Display = JsonConvert.DeserializeObject<ProductItem>(Display); 
            item.SoundCard= JsonConvert.DeserializeObject<ProductItem>(SoundCard); 

            item.Newcomponent(componentname, Double.Parse(componentprice), "ugh descriptions");
            ViewData["item"] = item;

            return View();
        }

        [HttpPost]
        public ActionResult AddToCart()
        {
            // add to cart obj

            return View();
        }

        [HttpPost] 
        public ActionResult AddComputerToCart(string name, string price, string description, string RAM, string HD, string CPU, string OS, string Display, string SoundCard) 
        {
            // rebuild computer
            ComputerItem item = new ComputerItem(name, Double.Parse(price), description);
            item.RAM = JsonConvert.DeserializeObject<ProductItem>(RAM); 
            item.HD = JsonConvert.DeserializeObject<ProductItem>(HD); 
            item.CPU = JsonConvert.DeserializeObject<ProductItem>(CPU); 
            item.OS = JsonConvert.DeserializeObject<ProductItem>(OS); 
            item.Display = JsonConvert.DeserializeObject<ProductItem>(Display); 
            item.SoundCard= JsonConvert.DeserializeObject<ProductItem>(SoundCard); 

            // add to cart obj

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
