using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using part4.Models;
using Newtonsoft.Json;
using part4.Contexts;

namespace part4.Controllers
{
    public class HomeController : Controller
    {
        public ProductContext context;

        public HomeController(ProductContext context) {
            this.context = context; 
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Productpage(string name, string price, string img)
        {
            ProductItem item = new ProductItem(name, Double.Parse(price), "description needed", img);
            context.Products.Add(item); 
            await context.SaveChangesAsync();

            ViewData["item"] = item;

            return View();
        }

        [HttpPost]
        public ActionResult Computereditpage2(string name, string price, string description, string img, string RAM, string HD, string CPU, string OS, string Display, string SoundCard, string componentname, string componentprice)
        {
            // build/rebuild computer
            ComputerItem item = new ComputerItem(name, Double.Parse(price), description, img);
            if (RAM != "null") {
                item.RAM = JsonConvert.DeserializeObject<ProductItem>(RAM); 
            }
            if (HD != "null") {
                item.HD = JsonConvert.DeserializeObject<ProductItem>(HD);
            }
            if (CPU != "null") {
                item.CPU = JsonConvert.DeserializeObject<ProductItem>(CPU); 
            }
            if (OS != "null") {
                item.OS = JsonConvert.DeserializeObject<ProductItem>(OS); 
            }
            if (Display != "null") {
                item.Display = JsonConvert.DeserializeObject<ProductItem>(Display); 
            }
            if (SoundCard != "null") {
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
