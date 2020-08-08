using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using newmvccore.Models;

namespace newmvccore
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
            services.AddDbContextPool<AppDbContext>(option => option.UseSqlServer(@"server=.;database=EmployeeDB;Trusted_Connection=true"));
            //services.AddDbContextPool<AppDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("EmployeeCEmployeeDBConnectiononnection")));

            //services.AddControllersWithViews(option=> {
            //    var policy = new AuthorizationPolicyBuilder()
            //                .RequireAuthenticatedUser()
            //                .Build();
            //    option.Filters.Add(new AuthorizeFilter(policy));
            //});
            services.AddControllersWithViews();
            services.AddScoped<IEmployeeRepo,SQLEmpRepo>();
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            //services.Configure<IdentityOptions>(option =>
            //{
            //    option.Password.RequiredLength = 10;
            //    option.Password.RequiredUniqueChars = 3;
            //    option.Password.RequireNonAlphanumeric = false;
            //});
            services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = "1013465630295-e8gbuia0orua6l38lvu5ag6u6b4lgm94.apps.googleusercontent.com";
                options.ClientSecret = "ooUFlQ3oJqqgKzCHaJ25RyAm";
            });
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
                //app.UseExceptionHandler("/Home/Error");
                //The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                //app.UseStatusCodePages();
                //app.UseExceptionHandler("/Error/Exception");
                app.UseStatusCodePagesWithRedirects("Error/{0}");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            //app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
