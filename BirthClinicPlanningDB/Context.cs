using BirthClinicPlanningDB.Domain_objects;
using BirthClinicPlanningDB.Models;
using Microsoft.EntityFrameworkCore;

namespace BirthClinicPlanningDB
{
    class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            ob.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HandIn2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Appointments> appointMents { get; set; }
        public DbSet<Birth> births { get; set; }
        public DbSet<BirthClinic> birthClinics { get; set; }
        public DbSet<BirthRoom> birthRooms { get; set; }
        public DbSet<Child> childs { get; set; }
        public DbSet<Clinician> clinicians { get; set; }
        public DbSet<FourHoursRestRoom> fourhourrestrooms { get; set; }
        public DbSet<MaternityRoom> maternityrooms { get; set; }
        public DbSet<Parents> parents { get; set; }
    }
}
