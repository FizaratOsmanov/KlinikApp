using BL;
using DATA;
using DATA.Contexts;
using Microsoft.EntityFrameworkCore;
namespace PL;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"));
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        ///////////////////////////////
        builder.Services.AddBLService();
        builder.Services.AddDATAService();
        ///////////////////////////////
        ///

        var app = builder.Build();
        app.UseStaticFiles();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");
        app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
