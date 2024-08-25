using Emr.Domain.AggregatesModel.Patient;
using Emr.Infrastructure.Context;
using Emr.Infrastructure.Repositories;
using Emr.Infrastructure.UniOfWork;
using Microsoft.EntityFrameworkCore;

namespace Emr.API.Extensions
{
    public static class Extensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            var services = builder.Services;

            // Register DI
            services.AddScoped<IUnitOfWork, UnitOfWork_Context>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddDbContext<EmrContext>(options =>
            {
                var ConnectionString = builder.Configuration.GetConnectionString("orderingdb");
                options.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
            });

        }

    }
}
