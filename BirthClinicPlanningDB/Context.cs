using BirthClinicPlanningDB.Domain_objects;
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

        private DbSet<BirthClinic> birthClinics { get; set; }
    }
}
