using EmployeeDemoApp.Data;
using EmployeeDemoApp.Interfaces;
using EmployeeDemoApp.Models;
using EmployeeDemoApp.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeDemoApp.Utilities;

namespace EmployeeDemoApp
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
            services.AddAutoMapper(typeof(Startup));

            services.AddSingleton<IFileProvider>(
             new PhysicalFileProvider(
                 Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<User, Role>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultUI()
            .AddDefaultTokenProviders();

            services.AddMvc();
            services.AddControllersWithViews();
            services.AddRazorPages();

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IPositionRepository, PositionRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            #endregion


            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddTransient<IRoleUtility, RoleUtility>();

            services.ConfigureApplicationCookie(o => o.LoginPath = "/Account/Login");


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Employee/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Employee}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            var folderPath = FileLocation.DeleteFileFromFolder;
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
        }

    }
}
