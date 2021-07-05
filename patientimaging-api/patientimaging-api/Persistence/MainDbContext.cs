using System;
using Microsoft.EntityFrameworkCore;

namespace patientimaging_api.Persistence
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {

        }

        public DbSet<PatientDataModel> Patients { get; set; }
    }
}
