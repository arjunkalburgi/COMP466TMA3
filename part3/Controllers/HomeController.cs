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

            return View();
        }

        [HttpPost]
        public ActionResult Computereditpage(string name, string price)
        {
            ComputerItem item = new ComputerItem(name, Double.Parse(price), "lol");
            ViewData["item"] = item;

            return View();
        }

        [HttpPost]
        public ActionResult Computereditpage2(string name, string price, string description, string RAM, string HD, string CPU, string OS, string Display, string SoundCard, string componentname, string componentprice)
        {
            // build/rebuild computer
            ComputerItem item = new ComputerItem(name, Double.Parse(price), description);
            if (RAM is "null") {
                item.RAM = new ProductItem("Ram1", 9.99, "this is rammmmm"); 
            } else {
                item.RAM = JsonConvert.DeserializeObject<ProductItem>(RAM); 
            }
            if (HD is "null") {
                item.HD = new ProductItem("HD1", 9.99, "this is HD");
            } else {
                item.HD = JsonConvert.DeserializeObject<ProductItem>(HD);
            }
            if (CPU is "null") {
                item.CPU = new ProductItem("CPU1", 9.99, "this is CPU");
            } else {
                item.CPU = JsonConvert.DeserializeObject<ProductItem>(CPU); 
            }
            if (OS is "null") {
                item.OS = new ProductItem("OS1", 9.99, "this is OS");
            } else {
                item.OS = JsonConvert.DeserializeObject<ProductItem>(OS); 
            }
            if (Display is "null") {
                item.Display = new ProductItem("Display1", 9.99, "this is Dissplay");
            } else {
                item.Display = JsonConvert.DeserializeObject<ProductItem>(Display); 
            }
            if (Display is "null") {
                item.Display = new ProductItem("Display1", 9.99, "this is Dissplay");
            } else {
                item.Display = JsonConvert.DeserializeObject<ProductItem>(Display); 
            }
            if (SoundCard is "null") {
                item.SoundCard = new ProductItem("Soundcard1", 9.99, "this is soundcard"); 
            } else {
                item.SoundCard= JsonConvert.DeserializeObject<ProductItem>(SoundCard); 
            }
            if (componentname != "null" && componentprice != "null") {
                item.Newcomponent(componentname, Double.Parse(componentprice), "ugh descriptions");
            }

            ViewData["item"] = item;

            return View();
        }

        [HttpPost]
        public ActionResult AddToCart(string name, string price, string description)
        {
            ProductItem item = new ProductItem(name, Double.Parse(price), "lol holla");

            // get selectedproductitems
            List<ProductItem> items = new List<ProductItem>();
            string itemsstring = Request.Cookies["selectedproductitems"];
            if (itemsstring != null) {
                items = JsonConvert.DeserializeObject<List<ProductItem>>(itemsstring);
            }

            // add to cart obj
            items.Add(item);

            // store cookie
            Response.Cookies.Delete("selectedproductitems"); 
            CookieOptions selectedproductitems = new CookieOptions();  
            selectedproductitems.Expires = DateTime.Now.AddMinutes(10);  
            Response.Cookies.Append("selectedproductitems", JsonConvert.SerializeObject(items), selectedproductitems);  

            // set view data
            ViewData["productitems"] = items;

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

            // get selectedproductitems
            List<ProductItem> items = new List<ProductItem>();
            string itemsstring = Request.Cookies["selectedproductitems"];
            if (itemsstring != null)
            {
                items = JsonConvert.DeserializeObject<List<ProductItem>>(itemsstring);
            }

            // add to cart obj
            items.Add(item.RAM);
            items.Add(item.HD);
            items.Add(item.CPU);
            items.Add(item.OS);
            items.Add(item.Display);
            items.Add(item.SoundCard);

            // store cookie
            Response.Cookies.Delete("selectedproductitems");
            CookieOptions selectedproductitems = new CookieOptions();
            selectedproductitems.Expires = DateTime.Now.AddMinutes(10);
            Response.Cookies.Append("selectedproductitems", JsonConvert.SerializeObject(items), selectedproductitems);

            // set view data
            ViewData["productitems"] = items;

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
