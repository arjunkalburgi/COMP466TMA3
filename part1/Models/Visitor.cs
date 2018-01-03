using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using Microsoft.AspNetCore.Mvc; 


namespace part1.Models
{
    public class Visitor
    {
        public string Name { get; set; }
        public int visitCount { get; set; }
        public string ipaddress { get;  }

        public Visitor()
        {
            visitCount = 0; 
        }
    }
}
