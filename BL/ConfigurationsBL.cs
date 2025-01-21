using BL.Profiles;
using BL.Services.Abstractions;
using BL.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace BL
{
    public static  class ConfigurationsBL
    {
        public static void AddBLService(this IServiceCollection services)
        {
            services.AddScoped<IDoctorService,DoctorService>();
            services.AddScoped<IDepartmentService,DepartmentService>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddAutoMapper(typeof(UserProfiles));
            services.AddAutoMapper(typeof(DepartmentProfiles));
            services.AddAutoMapper(typeof(DoctorProfiles));
        }
    }
}
