using System;
namespace part3.Models
{
    public class ProductItem
    {
        public string name { get;  }
        public double price { get;  }
        public string description { get;  }

        public ProductItem(string name, double price, string desc)
        {
            this.name = name;
            this.price = price;
            this.description = "this is a v nice -inator."; 
        }
    }
}
