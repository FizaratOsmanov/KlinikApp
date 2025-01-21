using CORE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Contexts
{
    public class AppDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt):base(opt) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<IdentityRole>().HasData(
                

                new IdentityRole { Id= "a599db25-d050-4126-a00e-df56f0b6a05a" ,Name="Admin",NormalizedName="ADMIN" },
                new IdentityRole{ Id= "bab987a2-4188-4b33-b47f-d2efaa11e7d9", Name="User" ,NormalizedName="USER"}
                );


            IdentityUser admin = new()
            {
                Id = "f890173b-f88f-4c04-98d7-81e0b9244131",
                UserName="admin",
                NormalizedUserName="ADMIN"
            };

            PasswordHasher<IdentityUser> hasher=new PasswordHasher<IdentityUser>();
            admin.PasswordHash = hasher.HashPassword(admin, "admin123");
            builder.Entity<IdentityUser>().HasData(admin);
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { UserId = admin.Id, RoleId = "a599db25-d050-4126-a00e-df56f0b6a05a" });
      
                
            base.OnModelCreating(builder);
        }
    }
}
