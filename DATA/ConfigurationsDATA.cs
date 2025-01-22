using CORE.Models;
using DATA.Contexts;
using DATA.Repositories.Abstractions;
using DATA.Repositories.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
    public static class ConfigurationsDATA
    {

        public static void AddDATAService(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Doctor>,Repository<Doctor>>();   
            services.AddScoped<IRepository<Department>,Repository<Department>>();
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(10);
                options.Lockout.MaxFailedAccessAttempts = 10;
            })
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<AppDbContext>();
            services.ConfigureApplicationCookie(opt=>
            {
                opt.LoginPath = "/Admin/Account/Login";
                opt.AccessDeniedPath = "/";
            });
        }
    }
}
