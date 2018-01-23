using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using part4.Contexts;
using System.Linq;

namespace part4.Models
{
    [Table("products")]
    public class ProductItem
    {
        [Required]
        public Guid id { get; set; }

        [MaxLength(50)]
        [Required]
        public string name { get; set; }

        [Required]
        public double price { get; set; }

        [MaxLength(700)]
        [Required]
        public string description { get; set; }

        [MaxLength(100)]
        [Required]
        public string image { get; set; }

        public ProductItem() {
            
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this); 
        }

        public ProductItem pi(string name, double price, string description, string img)
        {
            this.id = Guid.NewGuid();
            this.name = name;
            this.price = price;
            this.description = description;
            this.image = img;

            return this; 
        }

    }

    [Table("cartitems")]
    public class CartItem : ProductItem {}

    public class cartitemforview {
        public string itemname { get; set; }
        public string itemdescription { get; set; }
        public double itemprice { get; set; }
        public string itemimage { get; set; }
        public int itemcount { get; set; }
    }

    [Table("computeritems")]
    public class ComputerItem
    {

        [Required]
        public Guid id { get; set; }

        [MaxLength(50)]
        [Required]
        public string name { get; set; }

        [Required]
        public double price { get; set; }

        [MaxLength(700)]
        [Required]
        public string description { get; set; }

        [MaxLength(100)]
        [Required]
        public string image { get; set; }

        public Guid RAMid { get; set; }
        public Guid HDid { get; set; }
        public Guid CPUid { get; set; }
        public Guid Displayid { get; set; }
        public Guid OSid { get; set; }
        public Guid SoundCardid { get; set; }
    }

    [Table("cartcomps")]
    public class CartComputer : ComputerItem { }

    public class ComputerObject {
        [Required]
        public Guid id { get; set; }

        [MaxLength(50)]
        [Required]
        public string name { get; set; }

        [Required]
        public double price { get; set; }

        [MaxLength(700)]
        [Required]
        public string description { get; set; }

        [MaxLength(100)]
        [Required]
        public string image { get; set; }

        public ProductItem RAM { get; set; }
        public ProductItem HD { get; set; }
        public ProductItem CPU { get; set; }
        public ProductItem Display { get; set; }
        public ProductItem OS { get; set; }
        public ProductItem SoundCard { get; set; }

        public ComputerObject make(ComputerItem c, ProductContext context) {
            this.id = c.id;
            this.name = c.name;
            this.image = c.image;
            this.price = c.price;
            this.description = c.description;
            this.RAM = context.Products.Where(p => p.id == c.RAMid).First(); 
            this.HD = context.Products.Where(p => p.id == c.HDid).First(); 
            this.CPU = context.Products.Where(p => p.id == c.CPUid).First(); 
            this.Display = context.Products.Where(p => p.id == c.Displayid).First(); 
            this.OS = context.Products.Where(p => p.id == c.OSid).First(); 
            this.SoundCard = context.Products.Where(p => p.id == c.SoundCardid).First();

            return this; 
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

        public void Newcomponent(string type, string level, ProductContext context) {

            double price = 9.99;
            string adjective = ""; 
            switch (level) {
                case "1":
                    price = 9.99;
                    adjective = "first";
                    break;
                case "2":
                    price = 10.99;
                    adjective = "second";
                    break;
                case "3":
                    price = 11.99;
                    adjective = "third";
                    break;
                case "4":
                    price = 12.99;
                    adjective = "fourth";
                    break;
                case null:
                    price = 9.99;
                    adjective = "first";
                    break;
            }

            switch (type) {
                case "RAM":
                    this.RAM = new ProductItem().pi(type + level, price, adjective + "level ram", "/images/ram.jpg");
                    context.Products.Add(this.RAM);
                    break; 
                case "HD": 
                    this.HD = new ProductItem().pi(type + level, price, adjective + "level HD", "/images/hd.jpg");
                    context.Products.Add((ProductItem)this.HD);
                    break; 
                case "CPU": 
                    this.CPU = new ProductItem().pi(type + level, price, adjective + "level CPU", "/images/cpu.jpg"); 
                    context.Products.Add((ProductItem)this.CPU);
                    break;
                case "Display":
                    this.Display = new ProductItem().pi(type + level, price, adjective + "level display", "/images/display.jpg"); 
                    context.Products.Add((ProductItem)this.Display);
                    break;
                case "OS":
                    this.OS = new ProductItem().pi(type + level, price, adjective + "level OS", "/images/os.png"); 
                    context.Products.Add((ProductItem)this.OS);
                    break;
                case "SoundCard":
                    this.SoundCard = new ProductItem().pi(type + level, price, adjective + "level soundcard", "/images/scard.jpg");
                    context.Products.Add((ProductItem)this.SoundCard);
                    break; 
                case null:
                    break; 
            }

            this.calculateprice();
            this.redodescription();
        }

        public ComputerItem getcompitem() {
            ComputerItem c = new ComputerItem(); 
            c.id = this.id;
            c.name = this.name;
            c.image = this.image;
            c.price = this.price;
            c.description = this.description;
            c.RAMid = this.RAM.id;
            c.HDid = this.HD.id;
            c.CPUid = this.CPU.id;
            c.Displayid = this.Display.id;
            c.OSid = this.OS.id;
            c.SoundCardid = this.SoundCard.id;

            return c; 
        }

        public void addCompToCart(ComputerCartItemsContext c) {
            CartComputer ci = new CartComputer();
            ci.id = this.id; 
            ci.name = this.name; 
            ci.image = this.image; 
            ci.price = this.price; 
            ci.description = this.description; 
            ci.RAMid = this.RAM.id; 
            ci.HDid = this.HD.id; 
            ci.CPUid = this.CPU.id; 
            ci.Displayid = this.Display.id; 
            ci.OSid = this.OS.id; 
            ci.SoundCardid = this.SoundCard.id; 

            c.ComputerCartItems.Add(ci); 
        }
    }


    [Table("users")]
    public class user
    {
        [Required]
        public Guid id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string password { get; set; }

        public user Make(string n, string p) {
            this.id = Guid.NewGuid();
            this.name = n;
            this.password = p; 

            return this; 
        }
    }
}
