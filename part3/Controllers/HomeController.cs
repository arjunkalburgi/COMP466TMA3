﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

            ProductItem item; 
            if (name.Contains("Computer")) {
                item = new ComputerItem(name, Double.Parse(price), "lol"); 
                ViewData["isComp"] = true;
                ViewData["item"] = item;
            } else {
                item = new ProductItem(name, Double.Parse(price), "lol holla");
                ViewData["isComp"] = false;
                ViewData["item"] = item; 
            }

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
