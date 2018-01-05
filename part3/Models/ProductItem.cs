using System;
namespace part3.Models
{
    public class ProductItem
    {
        public string name { get;  }
        public double price { get; set; }
        public string description { get; set; }
        public string image { get; }

        public ProductItem(string name, double price, string desc)
        {
            this.name = name;
            this.price = price;
            this.description = "this is a v nice -inator."; 
            //this.image = 
        }
    }

    public class ComputerItem : ProductItem
    {
        public ProductItem RAM { get; set; }
        public ProductItem HD { get; set; }
        public ProductItem CPU { get; set; }
        public ProductItem Display { get; set; }
        public ProductItem OS { get; set; }
        public ProductItem SoundCard { get; set; }

        public ComputerItem(string name, double price, string desc) : base(name, price, desc)
        {
            this.RAM = new ProductItem("Ram 1", 9.99, "ram lol"); 
            this.HD = new ProductItem("HD 1", 9.99, "ram lol"); 
            this.CPU = new ProductItem("CPU 1", 9.99, "ram lol"); 
            this.Display = new ProductItem("Display 1", 9.99, "ram lol"); 
            this.OS = new ProductItem("OS 1", 9.99, "ram lol"); 
            this.SoundCard = new ProductItem("SoundCard 1", 9.99, "ram lol");
            calculateprice();
            redodescription();
        }

        public double calculateprice() {
            double price = 0;
            price += this.RAM.price; 
            price += this.HD.price; 
            price += this.CPU.price; 
            price += this.Display.price; 
            price += this.OS.price; 
            price += this.SoundCard.price;

            this.price = price;
            return price; 
        }

        public string redodescription() {
            string desc = "This computer features ";
            desc += "the " + this.RAM.name + " RAM module, ";
            desc += "the " + this.HD.name + " HD, ";
            desc += "the " + this.CPU.name + " CPU, ";
            desc += "the " + this.Display.name + " Display, ";
            desc += "the " + this.OS.name + " OS, ";
            desc += "and the " + this.SoundCard.name + " SoundCard. ";

            this.description = desc;
            return desc; 
        }
    }
}
