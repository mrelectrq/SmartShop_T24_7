using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Providers.Entities;
using BusinessLayer;
using BusinessLayer.Interfaces;
using BusinessLayer.Level;
using DataLayer.Entities;
using Google;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartShop_T24_7.Providers;

namespace SmartShop_T24_7
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<Lake_ShopContext>(optionsAction => optionsAction.UseSqlServer("T24_Runtime_Connection"));
            services.AddTransient<ILogging, UserBL>();
            services.AddScoped<BusinessManager>();
            services.AddIdentity<User, IdentityRole>().AddRoles<RoleProvider>();


            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "_credential";
                options.Cookie.Expiration = TimeSpan.FromHours(2);
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthorization();

            app.UseEndpoints(endoint =>
            {
                endoint.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}
