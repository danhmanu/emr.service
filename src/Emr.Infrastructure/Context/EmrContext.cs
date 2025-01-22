using Emr.Domain.AggregatesModel.Patient;
using Emr.Infrastructure.UniOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace Emr.Infrastructure.Context
{
    public class EmrContext(DbContextOptions<EmrContext> options) : DbContext(options)
    {
        public DbSet<emrpatient> emrpatients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<emrpatient>().HasKey(m => new { m.siterf, m.patid });
        }
    }
}
