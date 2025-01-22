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
                

                new IdentityRole { Id= "7d6ec704-60f2-44bc-9485-e5b2516ee13a", Name="Admin",NormalizedName="ADMIN" },
                new IdentityRole{ Id= "bab987a2-4188-4b33-b47f-d2efaa11e7d9", Name="User" ,NormalizedName="USER"}
                );


            IdentityUser admin = new()
            {
                Id = "67bfb8c6-031c-4a06-aaf0-526592f96798",
                UserName="admin",
                NormalizedUserName="ADMIN"
            };

            PasswordHasher<IdentityUser> hasher=new PasswordHasher<IdentityUser>();
            admin.PasswordHash = hasher.HashPassword(admin, "admin1234");
            builder.Entity<IdentityUser>().HasData(admin);
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { UserId = admin.Id, RoleId = "7d6ec704-60f2-44bc-9485-e5b2516ee13a" });
      
                
            base.OnModelCreating(builder);
        }
    }
}
