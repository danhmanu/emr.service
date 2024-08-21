﻿using Emr.Domain.AggregatesModel.Patient;

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
