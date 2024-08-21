using Emr.Domain.AggregatesModel.Patient;
using Emr.Infrastructure.Repositories;

namespace Emr.API.Extensions
{
    internal static class Extensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            var services = builder.Services;

            // Register 
             services.AddScoped<IPatientRepository, PatientRepository>();
        }

    }
}
