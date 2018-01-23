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


}
