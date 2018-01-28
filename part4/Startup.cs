using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using part4.Contexts;

namespace part4
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // var connection = @"server={{servername}};userid={{username}};password={{password}};database={{dbname}};";"

            //localsetup
            var connection = @"server=localhost;userid=root;password=password;database=store;";

            // azure setup (didn't work)
            //var connection = @"Server=tcp:466sdotore.database.windows.net,1433;Initial Catalog=store;Persist Security Info=False;User ID=arjun;Password=Passwor6;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            services.AddDbContext<ProductContext>(options => options.UseMySql(connection));
            services.AddDbContext<CartItemsContext>(options => options.UseMySql(connection));
            services.AddDbContext<ComputerContext>(options => options.UseMySql(connection));
            services.AddDbContext<ComputerCartItemsContext>(options => options.UseMySql(connection));
            services.AddDbContext<UserContext>(options => options.UseMySql(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

