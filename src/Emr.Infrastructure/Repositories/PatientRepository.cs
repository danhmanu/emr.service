using Emr.Domain.AggregatesModel.Patient;
using Emr.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly EmrContext contextDb;
        public PatientRepository(EmrContext context) {
            contextDb = context;
        }
        public DbSet<emrpatient> emrpatients { get; set; }

    }
}
