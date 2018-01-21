using System;
using System.Collections.Generic;
using System.Linq;
using part4.Models;

namespace part4.ViewModels
{
    public class ProductsList
    {
        public List<ProductItem> ProductItem { get; set; }
        public List<CartItem> CartItems { get; set; }
        public List<cartitemforview> viewablecartitems { get; set; }
        public List<ComputerItem> ComputerItem { get; set; }
    }
}
