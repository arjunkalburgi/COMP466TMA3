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

            var connection = @"server=localhost;userid=root;password=password;database=store;";
            //var connection = @"User ID=postgres;Password=postgres;Host=192.168.99.100;Port=5432;Database=store;";
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

