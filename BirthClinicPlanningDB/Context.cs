using System.Collections.Generic;
using BirthClinicPlanningDB.DomainObjects;
using Microsoft.EntityFrameworkCore;

namespace BirthClinicPlanningDB
{
    public class Context : DbContext
    {
        public Context()
        { }

        public Context(DbContextOptions<Context> options): base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            ob.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HandIn2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed(modelBuilder);
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Child> Childs { get; set; }
        public DbSet<Clinician> Clinicians { get; set; }
        public DbSet<RestRoom> Restrooms { get; set; }
        public DbSet<MaternityRoom> maternityrooms { get; set; }
        public DbSet<BirthRoom> BirthRooms { get; set; }
        public DbSet<Parents> Parents { get; set; }
    }
}
