using System;
using Newtonsoft.Json;
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
            this.description = "thisIsAVNice-inator."; 
            //this.image = 
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this); 
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
            this.RAM = new ProductItem("Ram1", 9.99, "ramlol"); 
            this.HD = new ProductItem("HD1", 9.99, "ramlol"); 
            this.CPU = new ProductItem("CPU1", 9.99, "ramlol"); 
            this.Display = new ProductItem("Display1", 9.99, "ramlol"); 
            this.OS = new ProductItem("OS1", 9.99, "ramlol"); 
            this.SoundCard = new ProductItem("SoundCard1", 9.99, "ramol");
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
            string desc = "ThisComputerFeatures ";
            desc += "the " + this.RAM.name + " RAM module, ";
            desc += "the " + this.HD.name + " HD, ";
            desc += "the " + this.CPU.name + " CPU, ";
            desc += "the " + this.Display.name + " Display, ";
            desc += "the " + this.OS.name + " OS, ";
            desc += "and the " + this.SoundCard.name + " SoundCard. ";

            this.description = desc;
            return desc; 
        }

        public void Newcomponent(string name, double price, string description) {
            if (name.Contains("RAM")) {
                this.RAM = new ProductItem(name, price, "the better ram"); 
            } else if (name.Contains("HD")) {
                this.HD = new ProductItem(name, price, "the better HD"); 
            } else if (name.Contains("CPU")) {
                this.CPU = new ProductItem(name, price, "the better CPU"); 
            } else if (name.Contains("Display")) {
                this.Display = new ProductItem(name, price, "the better display"); 
            } else if (name.Contains("OS")) {
                this.OS = new ProductItem(name, price, "the better OS"); 
            } else if (name.Contains("SoundCard")) {
                this.SoundCard = new ProductItem(name, price, "the better soundcard"); 
            }
            this.calculateprice();
            this.redodescription();
        }
    }
}
