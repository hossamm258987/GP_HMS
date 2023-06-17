using Microsoft.EntityFrameworkCore;
using Clinic_Management_Service.Models;

namespace Clinic_Management_Service.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<DocMETime> DocMETimes { get; set; }
        public DbSet<DocMExamination> DocMExaminations { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Dose> Doses { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<MExamination> MExaminations { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SectionType> SectionTypes { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Ward> Wards { get; set; }
    }
}
