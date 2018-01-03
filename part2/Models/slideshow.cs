using System;
namespace part2.Models
{
    public class slideshow
    {
        public item[] slideshowitems { get; }

        public slideshow()
        {
            // initiate slideshowitems
            slideshowitems = new item[4];
            slideshowitems[0] = new item("~/images/slideshow(0).jpg", "beginning of spring, snow melted but still looks gross"); 
            slideshowitems[1] = new item("~/images/slideshow(1).jpg", "jumping on rocks in iceland"); 
            slideshowitems[2] = new item("~/images/slideshow(2).jpg", "I think I lost those gloves in Iceland"); 
            slideshowitems[3] = new item("~/images/slideshow(3).jpg", "testing my remote shooter camera feature"); 
    
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
