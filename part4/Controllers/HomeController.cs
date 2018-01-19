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
using part4.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace part4.Controllers
{
    public class HomeController : Controller
    {
        public ProductContext context;
        public CartItemsContext cartcontext;

        public HomeController(ProductContext context, CartItemsContext ccontext) {
            this.context = context;
            this.cartcontext = ccontext;
        }

        public IActionResult Index()
        {
            ViewData["ProductsList"] = new ProductsList()
            {
                ProductItem = context.Products.ToList()
            };

            return View();
        }

        [HttpPost]
        public ActionResult Productpage(ProductItem pi)
        {
            ViewData["item"] = pi;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddToCart(CartItem pi)
        {
            // add item to cart
            cartcontext.CartItems.Add(pi);
            await cartcontext.SaveChangesAsync();

            // gather all distinct items 
            ProductsList list = new ProductsList()
            {
                viewablecartitems = cartcontext.CartItems
                                       .Select(cartitem => new cartitemforview() {
                                           itemname = cartitem.name,
                                           itemimage = cartitem.image,
                                           itemdescription = cartitem.description,
                                           itemprice = cartitem.price,
                                       }).Distinct()
                                       .ToList()
            };
            // count distinct items
            foreach (cartitemforview vm in list.viewablecartitems) {
                vm.itemcount = cartcontext.CartItems
                           .Where(cartitem => cartitem.name == vm.itemname)
                           .Count();
            }

            ViewData["productitems"] = list; 

            return View();
        }

        [HttpPost]
        public ActionResult Computereditpage2(string name, string price, string description, string img, string RAM, string HD, string CPU, string OS, string Display, string SoundCard, string componentname, string componentprice)
        {
            //// build/rebuild computer
            //ComputerItem item = new ComputerItem(name, Double.Parse(price), description, img);
            //if (RAM != "null") {
            //    item.RAM = JsonConvert.DeserializeObject<ProductItem>(RAM); 
            //}
            //if (HD != "null") {
            //    item.HD = JsonConvert.DeserializeObject<ProductItem>(HD);
            //}
            //if (CPU != "null") {
            //    item.CPU = JsonConvert.DeserializeObject<ProductItem>(CPU); 
            //}
            //if (OS != "null") {
            //    item.OS = JsonConvert.DeserializeObject<ProductItem>(OS); 
            //}
            //if (Display != "null") {
            //    item.Display = JsonConvert.DeserializeObject<ProductItem>(Display); 
            //}
            //if (SoundCard != "null") {
            //    item.SoundCard= JsonConvert.DeserializeObject<ProductItem>(SoundCard); 
            //}
            //if (componentname != "null" && componentprice != "null") {
            //    item.Newcomponent(componentname, Double.Parse(componentprice));
            //}

            //ViewData["item"] = item;

            return View();
        }

        [HttpPost] 
        public ActionResult AddComputerToCart(string name, string price, string description, string img, string RAM, string HD, string CPU, string OS, string Display, string SoundCard) 
        {
            //// rebuild computer
            //ComputerItem item = new ComputerItem(name, Double.Parse(price), description, img);
            //item.RAM = JsonConvert.DeserializeObject<ProductItem>(RAM); 
            //item.HD = JsonConvert.DeserializeObject<ProductItem>(HD); 
            //item.CPU = JsonConvert.DeserializeObject<ProductItem>(CPU); 
            //item.OS = JsonConvert.DeserializeObject<ProductItem>(OS); 
            //item.Display = JsonConvert.DeserializeObject<ProductItem>(Display); 
            //item.SoundCard= JsonConvert.DeserializeObject<ProductItem>(SoundCard); 

            //// get selectedproductitems
            //List<ProductItem> items = new List<ProductItem>();
            //string itemsstring = Request.Cookies["selectedproductitems"];
            //if (itemsstring != null)
            //{
            //    items = JsonConvert.DeserializeObject<List<ProductItem>>(itemsstring);
            //}

            //// add to cart obj
            //items.Add(item.RAM);
            //items.Add(item.HD);
            //items.Add(item.CPU);
            //items.Add(item.OS);
            //items.Add(item.Display);
            //items.Add(item.SoundCard);

            //// store cookie
            //Response.Cookies.Delete("selectedproductitems");
            //CookieOptions selectedproductitems = new CookieOptions();
            //selectedproductitems.Expires = DateTime.Now.AddMinutes(10);
            //Response.Cookies.Append("selectedproductitems", JsonConvert.SerializeObject(items), selectedproductitems);

            //// set view data
            //ViewData["productitems"] = items;

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

        public IActionResult Indexcopy()
        {
            //ViewData["Message"] = "Your contact page.";

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> productadder(ProductItem pi)
        {
            context.Products.Add(pi);
            await context.SaveChangesAsync();

            //ViewData["productitems"] = new ProductsList()
            //{
            //    CartItems = context.CartItems.ToList()
            //};
            return RedirectToAction("Indexcopy"); 
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
