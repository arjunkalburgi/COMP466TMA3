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
        public ActionResult Productpage(string name, string price, string img)
        {

            ProductItem item = new ProductItem(name, Double.Parse(price), "description needed", img); 
            ViewData["item"] = item;

            return View();
        }

        [HttpPost]
        public ActionResult Computereditpage2(string name, string price, string description, string img, string RAM, string HD, string CPU, string OS, string Display, string SoundCard, string componentname, string componentprice)
        {
            // build/rebuild computer
            ComputerItem item = new ComputerItem(name, Double.Parse(price), description, img);
            if (RAM is "null") {
                item.RAM = new ProductItem("Ram1", 9.99, "First level, default, rammmmm", "/images/ram.jpg"); 
            } else {
                item.RAM = JsonConvert.DeserializeObject<ProductItem>(RAM); 
            }
            if (HD is "null") {
                item.HD = new ProductItem("HD1", 9.99, "First level, default, HD", "/images/hd.jpg");
            } else {
                item.HD = JsonConvert.DeserializeObject<ProductItem>(HD);
            }
            if (CPU is "null") {
                item.CPU = new ProductItem("CPU1", 9.99, "First level, default, CPU", "/images/cpu.jpg");
            } else {
                item.CPU = JsonConvert.DeserializeObject<ProductItem>(CPU); 
            }
            if (OS is "null") {
                item.OS = new ProductItem("OS1", 9.99, "First level, default, OS", "/images/display.jpg");
            } else {
                item.OS = JsonConvert.DeserializeObject<ProductItem>(OS); 
            }
            if (Display is "null") {
                item.Display = new ProductItem("Display1", 9.99, "First level, default, Display", "/images/os.png");
            } else {
                item.Display = JsonConvert.DeserializeObject<ProductItem>(Display); 
            }
            if (SoundCard is "null") {
                item.SoundCard = new ProductItem("Soundcard1", 9.99, "First level, default, soundcard", "/images/scard.jpg"); 
            } else {
                item.SoundCard= JsonConvert.DeserializeObject<ProductItem>(SoundCard); 
            }
            if (componentname != "null" && componentprice != "null") {
                item.Newcomponent(componentname, Double.Parse(componentprice));
            }

            ViewData["item"] = item;

            return View();
        }

        [HttpPost]
        public ActionResult AddToCart(string name, string price, string description, string img)
        {
            ProductItem item = new ProductItem(name, Double.Parse(price), description, img);

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
        public ActionResult AddComputerToCart(string name, string price, string description, string img, string RAM, string HD, string CPU, string OS, string Display, string SoundCard) 
        {
            // rebuild computer
            ComputerItem item = new ComputerItem(name, Double.Parse(price), description, img);
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
