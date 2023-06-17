using Hospital_Management_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_Service.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Analyst> Analysts {get; set;}
        public DbSet<Doctor> Doctors {get; set;}
        public DbSet<Hospital> Hospitals {get; set;}
        public DbSet<Nurse> Nurses {get; set;}
        public DbSet<Pharmatist> Pharmatists { get; set;}
        public DbSet<Receptionist> Receptionists { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SectionType> SectionTypes { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Ward> Wards { get; set; }
    }
}
