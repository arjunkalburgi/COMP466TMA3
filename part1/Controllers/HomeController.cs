using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; 
using part1.Models;

namespace part1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // visit num
            String number = Request.Cookies["CookieCount"];
            int countnumber; 
            if (number != null) {
                countnumber = Int32.Parse(number);
                countnumber++; 

                Response.Cookies.Delete("CookieCount"); 
                CookieOptions count = new CookieOptions();  
                count.Expires = DateTime.Now.AddMinutes(10);  
                Response.Cookies.Append("CookieCount", (countnumber).ToString(), count);  
            } else {
                countnumber = 1; 
                Response.Cookies.Delete("CookieCount"); 
                CookieOptions count = new CookieOptions();  
                count.Expires = DateTime.Now.AddMinutes(10);  
                Response.Cookies.Append("CookieCount", (countnumber).ToString(), count);  
            }
            ViewData["Count"] = countnumber;

            // ipaddy 
            ViewData["IP"] = Request.HttpContext.Connection.LocalIpAddress; 

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
