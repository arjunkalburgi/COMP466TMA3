using System;
namespace part4.Models
{

    [Table("users")]
    public class user
    {
        [Required]
        public Guid id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string password { get; set; }

        public user Make(string n, string p)
        {
            this.id = Guid.NewGuid();
            this.name = n;
            this.password = p;

            return this;
        }
    }
}
