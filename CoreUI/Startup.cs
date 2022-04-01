using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreUI.Identity;
using CoreUI.Models;
using CoreUI.Repositories.Abstract;
using CoreUI.Repositories.CartRepository.Abstract;
using CoreUI.Repositories.CartRepository.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoreUI
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

            services.AddDbContext<CoreIdentityContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MsSqlConnection")));

            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<CoreIdentityContext>().AddDefaultTokenProviders();

            services.AddScoped<ICartRepository,CartRepository>();
            services.AddScoped<ICartService,CartManager>(); 


             services.Configure<IdentityOptions>(options =>
            {
                // password
                // options.Password.RequireDigit = true;
                // options.Password.RequireLowercase = true;
                // options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;

                // Lockout                
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                // options.User.AllowedUserNameCharacters = "";
                // options.User.RequireUniqueEmail = true;
               // options.SignIn.RequireConfirmedEmail = true;
                // options.SignIn.RequireConfirmedPhoneNumber = false;
            });
            //login setting
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";
               // options.LogoutPath = "/account/logout";
               // options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = "Core.Security.Cookie"
                };
            });
            services.AddSession(option =>
            {
                //minute 30
                option.IdleTimeout = TimeSpan.FromMinutes(30);
            });



            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                    
                 endpoints.MapControllerRoute(
                name: "Main",
                pattern: "ana-sehife",
                defaults: new { controller = "Product", action = "SearchProduct" });

            });
        }
    }
}