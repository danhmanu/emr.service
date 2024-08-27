using Emr.Domain.AggregatesModel.Patient;
using Emr.Infrastructure.Context;
using Emr.Infrastructure.Repositories;
using Emr.Infrastructure.UniOfWork;
using Microsoft.EntityFrameworkCore;

namespace Emr.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            // Register DI
            services.AddScoped<IUnitOfWork, UnitOfWork_Context>();
            services.AddScoped<IPatientRepository, PatientRepository>();

            return services;
        }
    }
}
