using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

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

        //public ProductItem(string name, double price, string description, string img)
        //{
        //    this.id = Guid.NewGuid(); 
        //    this.name = name;
        //    this.price = price;
        //    this.description = description;
        //    this.image = img; 
        //}

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this); 
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

    //    public void Newcomponent(string name, double price) {
    //        //if (name.Contains("RAM")) {
    //        //    this.RAM = new ProductItem(name, price, "the better ram", "/images/ram.jpg"); 
    //        //} else if (name.Contains("HD")) {
    //        //    this.HD = new ProductItem(name, price, "the better HD", "/images/hd.jpg"); 
    //        //} else if (name.Contains("CPU")) {
    //        //    this.CPU = new ProductItem(name, price, "the better CPU", "/images/cpu.jpg"); 
    //        //} else if (name.Contains("Display")) {
    //        //    this.Display = new ProductItem(name, price, "the better display", "/images/display.jpg"); 
    //        //} else if (name.Contains("OS")) {
    //        //    this.OS = new ProductItem(name, price, "the better OS", "/images/os.png"); 
    //        //} else if (name.Contains("SoundCard")) {
    //        //    this.SoundCard = new ProductItem(name, price, "the better soundcard", "/images/scard.jpg"); 
    //        //}
    //        this.calculateprice();
    //        this.redodescription();
    //    }
    }


}
