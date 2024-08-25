using Emr.Domain.AggregatesModel.Patient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace Emr.Infrastructure.Context
{
    public class EmrContext(DbContextOptions<EmrContext> options) : DbContext(options)
    {
        public DbSet<emrpatient> emrpatients { get; set; }
    }
}
