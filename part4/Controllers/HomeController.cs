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
        public ComputerContext compcontext;
        public ComputerCartItemsContext compcartcontext;
        public UserContext ucontext;

        public HomeController(ProductContext context, CartItemsContext ccontext, ComputerContext compcontext, ComputerCartItemsContext cccontext, UserContext ucontext) {
            this.context = context;
            this.cartcontext = ccontext;
            this.compcontext = compcontext;
            this.compcartcontext = cccontext;
            this.ucontext = ucontext; 
        }

        public IActionResult Index()
        {
            ViewData["ProductsList"] = new ProductsList()
            {
                ProductItem = context.Products
                                   .ToList()
            };
            ViewData["ComputersList"] = new ProductsList()
            {
                ComputerItem = compcontext.Computers.ToList()
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

            // get all cart items 
            ProductsList list = new ProductsList()
            {
                viewablecartitems = cartcontext.CartItems
                                       .Select(cartitem => new cartitemforview()
                                       {
                                           itemname = cartitem.name,
                                           itemimage = cartitem.image,
                                           itemdescription = cartitem.description,
                                           itemprice = cartitem.price,
                                       }).Distinct()
                                       .ToList(),
                viewablecompitems = compcartcontext.ComputerCartItems
                                        .Select(compcartitem => new CartComputer()
                                        {
                                            id = compcartitem.id,
                                            name = compcartitem.name,
                                            image = compcartitem.image,
                                            price = compcartitem.price,
                                            description = compcartitem.description,
                                            RAMid = compcartitem.RAMid,
                                            HDid = compcartitem.HDid,
                                            CPUid = compcartitem.CPUid,
                                            Displayid = compcartitem.Displayid,
                                            OSid = compcartitem.OSid,
                                            SoundCardid = compcartitem.SoundCardid,
                                        }).ToList(),
                ComputerObjs = new List<ComputerObject>()
            };
            // count distinct items
            foreach (cartitemforview vm in list.viewablecartitems)
            {
                vm.itemcount = cartcontext.CartItems
                           .Where(cartitem => cartitem.name == vm.itemname)
                           .Count();
            }
            // get comp objects
            List<ComputerObject> complist = new List<ComputerObject>();
            foreach (CartComputer vm in list.viewablecompitems)
            {
                list.ComputerObjs.Add(new ComputerObject().make((ComputerItem)vm, context));
            }

            ViewData["productitems"] = list;

            return View();
        }

        [HttpPost]
        public ActionResult CompPage(ComputerItem ci)
        {
            ComputerItem c = compcontext.Computers.Where(comp => comp.id == ci.id).First();
            ComputerObject co = new ComputerObject().make(c, context);

            ViewData["item"] = co;

            return View();
        }

        [HttpPost] 
        public ActionResult CompEdit(Guid id, string type, string lvl) {
            ComputerItem c = compcontext.Computers.Where(comp => comp.id == id).First();
            ComputerObject co = new ComputerObject().make(c, context);

            co.Newcomponent(type, lvl, context);

            ViewData["item"] = co;

            return View();
        }

        [HttpPost] 
        public async Task<ActionResult> AddComputerToCart(Guid id) 
        {
            ComputerItem c = compcontext.Computers.Where(comp => comp.id == id).First();
            ComputerObject co = new ComputerObject().make(c, context);

            // add item to cart
            co.addCompToCart(compcartcontext); 
            await compcartcontext.SaveChangesAsync();

            // get all cart items 
            ProductsList list = new ProductsList()
            {
                viewablecartitems = cartcontext.CartItems
                                       .Select(cartitem => new cartitemforview() {
                                           itemname = cartitem.name,
                                           itemimage = cartitem.image,
                                           itemdescription = cartitem.description,
                                           itemprice = cartitem.price,
                                       }).Distinct()
                                       .ToList(), 
                viewablecompitems = compcartcontext.ComputerCartItems
                                        .Select(compcartitem => new CartComputer() {
                                            id = compcartitem.id,
                                            name = compcartitem.name,
                                            image = compcartitem.image,
                                            price = compcartitem.price,
                                            description = compcartitem.description,
                                            RAMid = compcartitem.RAMid,
                                            HDid = compcartitem.HDid,
                                            CPUid = compcartitem.CPUid,
                                            Displayid = compcartitem.Displayid,
                                            OSid = compcartitem.OSid,
                                            SoundCardid = compcartitem.SoundCardid,
                                        }).ToList(), 
                ComputerObjs = new List<ComputerObject>()
            };
            // count distinct items
            foreach (cartitemforview vm in list.viewablecartitems) {
                vm.itemcount = cartcontext.CartItems
                           .Where(cartitem => cartitem.name == vm.itemname)
                           .Count();
            }
            // get comp objects
            List<ComputerObject> complist = new List<ComputerObject>(); 
            foreach (CartComputer vm in list.viewablecompitems) {
                list.ComputerObjs.Add(new ComputerObject().make((ComputerItem) vm, context));
            }

            ViewData["productitems"] = list;

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

        public IActionResult SignIn()
        {
            ViewData["Message"] = "Your contact page.";

            if (Request.Cookies["curruser"] is null)
            {
                return View();
            }
            Response.Cookies.Delete("curruser");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> GetUser(string name, string password)
        {
            // lookup user in the db, else make new user
            user u = null; 
            try {
                u = ucontext.Users.Where(usr => usr.name == name).First(); 
                if (u.password != password) {
                    return RedirectToAction("SignIn");
                }
            } catch (InvalidOperationException e) {
                Console.WriteLine(e); 
                u = new user().Make(name, password);
                ucontext.Users.Add(u);
                await ucontext.SaveChangesAsync();
            }

            // set u as curruser
            Response.Cookies.Delete("curruser"); 
            CookieOptions curruser = new CookieOptions();  
            curruser.Expires = DateTime.Now.AddMinutes(10);  
            Response.Cookies.Append("curruser", u.id.ToString(), curruser);  

            // send home
            return RedirectToAction("Index");
        }

        public IActionResult Indexcopy()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> computeradder(ComputerItem pi)
        {
            //pi.id = Guid.NewGuid();
            //pi.RAM = new ProductItem("Ram1", 9.99, "This is a first level ram", "/images/ram.jpg");
            //context.Products.Add(pi.RAM);
            //pi.HD = new ProductItem("HD1", 9.99, "This is a first level hd", "/images/hd.jpg");
            //context.Products.Add(pi.HD);
            //pi.CPU = new ProductItem("CPU1", 9.99, "This is a first level cpu", "/images/cpu.jpg");
            //context.Products.Add(pi.CPU);
            //pi.Display = new ProductItem("Display1", 9.99, "This is a first level monitor", "/images/display.jpg");
            //context.Products.Add(pi.Display);
            //pi.OS = new ProductItem("OS1", 9.99, "This is a first level os", "/images/os.png");
            //context.Products.Add(pi.OS);
            //pi.SoundCard = new ProductItem("SoundCard1", 9.99, "This is a first level sound card", "/images/scard.jpg");
            //context.Products.Add(pi.SoundCard);

            compcontext.Computers.Add(pi);
            await compcontext.SaveChangesAsync();

            return RedirectToAction("Indexcopy");
        }

        [HttpPost]
        public async Task<ActionResult> productadder(ProductItem pi)
        {
            context.Products.Add(pi);
            await context.SaveChangesAsync();

            return RedirectToAction("Indexcopy"); 
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
