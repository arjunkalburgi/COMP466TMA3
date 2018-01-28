ASSIGNMENT REPORT  
=======

(Note: I found the required documentation formatting a little redundant so I formated it in my own way between this file and the tma3a.htm file. Sorry!)


# PART 1 
The most difficult thing here was project setup, Visual Studio on Mac isn't perfect by any means. 

### APPLICATION INTERFACE 
Wanting to keep consistent with the materializecss library used in TMA1 and TMA2, I chose to hack materializecss on top of the already existing Bootstrap library. The design of TMA3 is slightly less perfected than that of TMA1 and TMA2 because of this. 

### DOCUMENTATION
After initializing Part 1 using Visual Studio's default app, most of the work was done for the Index page, this is because Part 1 only requires one page.

The app has an MVC structure, but Part 1 doesn't have any Models - only a View and Controller. The logic for calculating viewcounts and finding the IPAddress is kept in the controller (see HomeController), using a cookie to calculate view counts. The View contains the HTML for what the user will see, and shows the variables passed from the controller. 

Timezone could not be calculated from the Controller as it must be client side. The Visual Studio project has its own JS file, wwwroot/js/site.js, where this was calculated and dynamically added to the View file. 

### ALGORITHMS 
I used some tutorials to help me calculate the variables in the controller and javascript files. I got the timezone calculation from [MDN](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/DateTimeFormat), help with cookies from [Binary Intellect](http://www.binaryintellect.net/articles/abdd3209-f1a5-4799-b5e1-3dacec0931ef.aspx) and finding the client's IP from [StackOverflow](https://stackoverflow.com/questions/28664686/how-do-i-get-client-ip-address-in-asp-net-core)


# PART 2 

### APPLICATION INTERFACE
This is where hacking Bootstrap and materializecss together was a great idea! I can keep consistency in my assignments with materializecss and also utilize Bootstraps much more extensive list of premade elements. Since we weren't required to use the canvas, I just used Bootstrap's slideshow in the View. 

### DOCUMENTATION
The logic of the app is minimum since Bootstrap handles so much in the view, but the slideshow element still requires logic for which images to present. Instead of putting this in the controller, this logic is put into a model (slideshow.cs) to read the content file and build the object to be passed to the View/slideshow element.

That slideshow.cs actually contains two models, slideshow and item. The slideshow class holds an array of the item class. Breaking it up like this makes it really easy to hook up Bootstrap's slideshow element. 

The final step here was to add the control functionality to the element, copied mostly from canvas.js from TMA1Part3. This code can be found in wwwroot/js/canvas.js.


# PART 3

### STORE DESIGN
After looking at BestBuy, Amazon and others, there were a few design elements that seemed to be standard. It seems that bombarding viewers with options to view, click and search for items. The idea behind this would be to get users looking for something to buy as quickly as possible. The feature of these sites are that there are so many options, by having a layout where the user will be picky will decrease sales. Filling the layout creates a chaos which leads users to get off the page and look at specific items. 

### APPLICATION INTERFACE
I chose to not go with this bombarding approach since there are far less options in my app, instead I go with something a lot cleaner. But I do keep some of the elements those other shops have, like the slideshow banners to help capture attention and the rows of items. I took out the links along the top, the search bar, the links along the left side and the different types of content views along the page. I think my tradeoff is quite good, especially looking at other specialty stores like [John Elliot](https://www.johnelliott.co/?gclid=CjwKCAiAnabTBRA6EiwAemvBd3a4LIgO1eO9RNIdJzLLPncqfusKbvLIyVsO4BTLVnOdWXQqvTW6NhoChvsQAvD_BwE) (fashion store) which also opts for a cleaner interface.

### APPLICATION STRUCTURE 
The app works a lot like that aformentioned John Elliot store. You see the long list of clickable items (computers first as they are more desireable), clicking on one gives you an expanded view and more information, then they can be added to your cart. 

### DOCUMENTATION
The app is all done using MVC, forms and cookies to store the data. The data starts in the Index.cshtml file, where the button is actually a form to get the data into the HomeController. From there, the data is converted into a Model and then is passed to the next page. Products (non-computer items) were incredibally easy with this structure but computers were complicated due to .NET's restrictions on converting objects from strings and the design of HTML to force form elements to be strings. I had to introduce a lot more logic and making of new products for the computer. I often wonder if my design of the classes were any good to know if there were better ways to do that. 

From the item view page, users can "Add to Cart". And for computer items they can edit the contents of the computer. The logic for editing the computer was quite bad, again because of .NET's JSON.deserialize had issues with converting objects <=> strings. I kept thinking how much better this would be with a database. My workaround was to replace all spaces ( ) with astriks (** ), this avoided the JSON.deserialize error. 


Problems continued for adding computers to the cart, to make it easier I chose not to distinguish between computer items and product items. The resulting cart list is just a list of all product items that have been added (including those in the computers) but does not mention any comptuers those products could be attached to. 

### UNFINISHED REQUIREMENT 
I didn't make an Orders button for the application. But effectively it would be a button on the two cart pages that would empty the cart cookies and send the user to an order summary page. 


# PART 4 

### DATABASE DESIGN
ASP.NET database tables are created with DbContext's. These can be found in the part4/Contexts/ProductContext file. There are 5 contexts for this application and thus 5 tables. One for each of: product items, computer items, product items in the cart, computer items in the cart and finally users. 

The database design mirrors the models found in the part4/Models folder. They're in three different files separated by type, Product items, Computer items and users. Looking at the models shows how the tables are made since I used migrations to create the tables from the models. For example in the ProductItem.cs file, you can see that the CartItem class has a property which is of the class User. This means that in the table, the userid will be a Foriegn Key, thus binding the two tables. We cannot have an item with a userid in the CartItem table if that userid is not an id in the Users table. This binding is found in the computer items table for product items associated with the computer and the computer cart items table for the same thing and for userid. It makes for a lot more reliable app. 

### DATABASE SET UP
In the Startup.cs file, line 25 contains the connection information passed to the application. The line above (24) has the information of how to modify it for your use. Note, this application uses mysql. To change to Postgres or another db, modify the "useMySql" in lines 27-31 to the db type of your choice. See [here](https://docs.microsoft.com/en-us/ef/core/api/microsoft.entityframeworkcore.dbcontextoptionsbuilder) for a more comprehensive list of options. 

Also note that the Azure connection string is commented out. This is because I couldn't get it working online. It only worked locally. 

### APPLICATION INTERFACE AND STRUCTURE 
Same as Part 3.

### DOCUMENTATION
The database tables didn't solve the application's messy HomeController, in fact it made it even more messy. I introduced ViewModels to help make it slightly cleaner, but retrieving from the databases isn't a very clean process. I wish it was more like creating a SQL script than it is currently - but I totally understand why it has to be that way. C# needs to be told explicitly what is what when making objects.

Another reason to introduce ViewModels is that ASP.NET can only use one @model variable per Razor page. This was also a difficulty with Part 3. Having a ViewModel being the one @model variable allowed me to keep multiple lists of objects separated, instead of being forced to combine them into one.

I still faced issues with the Computer Item class since the database also can't hold ran into difficulties with Computer Items again due to the descrepency between strings and objects. But instead of using astriks I have two models for the computer, one that holds IDs and the other that holds full Products. Then using the database I made a function that converts between them. 

### UNFINISHED REQUIREMENT 
I again skipped out on the Orders requirement. For this I would make another table called Orders with a coupled userid and another column in the two cart tables called orderid. Originally, this orderid would be null. When the Make Order button is pressed, a new order would be made with a new id, userid, the time of the order and the price of the order. All the cart items currently without an orderid (ie the current cart) would get the order's id as its orderid. This allows for the complete minimum redundancy in the tables and all the flexibility required for the app. 

