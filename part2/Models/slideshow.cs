using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace part2.Models
{
    public class slideshow
    {
        public static IConfigurationRoot Configuration { get; set; }
        public item[] slideshowitems { get; }
        public string output { get;  }

        public slideshow(IHostingEnvironment env)
        {
            // get json
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.WebRootPath)
                .AddJsonFile("lib/images.txt"); 
            Configuration = builder.Build();

            // read json to array 
            var someArray = Configuration
                .GetSection("itemsarray")
                .GetChildren()
                .Select(x => new item(
                    x.GetChildren().Last().Value,
                    x.GetChildren().First().Value
                    ))
                .ToArray();

            // set slideshowitems
            this.slideshowitems = new item[someArray.Length];
            this.slideshowitems = someArray; 
        }
    }

    public class item 
    {
        public string src { get; }
        public string caption { get; }

        public item(string src, string caption) {
            this.src = src;
            this.caption = caption; 
        }
    }
}
