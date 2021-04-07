using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
                "Data Source=localhost;Initial Catalog=BirthClinic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            //Example: Data Source=localhost;Initial Catalog=BirthClinic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            var clinicians = new ObservableCollection<Clinician>
            {
                new Clinician
                {
                    ClinicianID = 1,
                    FirstName = "Camilla",
                    LastName = "Holmstoel"
                },
                new Clinician
                {
                    ClinicianID = 2,
                    FirstName = "Thomas",
                    LastName = "Daugaard"
                },
                new Clinician
                {
                    ClinicianID = 3,
                    FirstName = "Emil",
                    LastName = "Garder"
                }
            };

            foreach (var clin in clinicians)
            {
                modelBuilder.Entity<Clinician>().HasData(clin);
            }

            var childs = new List<Child>
            {
                new Child
                {
                    ChildID = 1,
                    FirstName = "Leif",
                    LastName = "Knudsen",
                    Weight = 3500,
                    Length = 56,
                    BirthDate = new DateTime(2020, 6,6)
                },
                new Child
                {
                    ChildID = 2,
                    FirstName = "Viggo",
                    LastName = "Mortensen",
                    Weight = 3500,
                    Length = 56,
                    BirthDate = new DateTime(2020, 6,7)
                },
                new Child
                {
                    ChildID = 3,
                    FirstName = "Pascal",
                    LastName = "Pedersen",
                    Weight = 3500,
                    Length = 56,
                    BirthDate = new DateTime(2020, 6,8)
                }
            };

            foreach (var kid in childs)
            {
                modelBuilder.Entity<Child>().HasData(kid);
            }

            var parents = new List<Parents>
            {
                new Parents
                {
                    ParentsID = 1,
                    MomCPR="2003928596",
                    MomFirstName = "Camilla",
                    MomLastName = "Thomsen",
                    DadCPR = "2103898569",
                    DadFirstName = "Lars",
                    DadLastName = "Thomsen",
                },
                new Parents
                {
                    ParentsID = 2,
                    MomCPR="2004928596",
                    MomFirstName = "Tove",
                    MomLastName = "Frederiksen",
                    DadCPR = "2104898569",
                    DadFirstName = "Knabe",
                    DadLastName = "Frederiksen"
                },
                new Parents
                {
                    ParentsID = 3,
                    MomCPR="2005928596",
                    MomFirstName = "Hilda",
                    MomLastName = "Gudrundsen",
                    DadCPR = "2105898569",
                    DadFirstName = "Per",
                    DadLastName = "Gudrundsen"
                }
            };

            
            foreach (var parent in parents)
            {
                modelBuilder.Entity<Parents>().HasData(parent);
            }

            var rooms = new ObservableCollection<Room>
            {
                new Room
                {
                    RoomID = 1,
                    RoomNumber = 1,
                    Occupied = false,
                    RoomType = "RestRoom"
                },

                new Room
                {
                    RoomID = 2,
                    RoomNumber = 2,
                    Occupied = false,
                    RoomType = "RestRoom"
                },
                new Room
                {
                    RoomID = 3,
                    RoomNumber = 3,
                    Occupied = false,
                    RoomType = "MaternityRoom"
                }
            };

            foreach (var room in rooms)
            {
                modelBuilder.Entity<Room>().HasData(room);
            }


            var appointments = new ObservableCollection<Appointment>
            {
                new Appointment
                {
                    AppointmentID = 1,
                    StartTime = new DateTime(2021,06,07),
                    EndTime = new DateTime(2021,06,08),
                    BirthInProgess = false
                },

                new Appointment
                {
                AppointmentID = 2,
                StartTime = new DateTime(2021,07,08),
                EndTime = new DateTime(2021,07,09),
                BirthInProgess = false
                }

            };

            foreach (var app in appointments)
            {
                modelBuilder.Entity<Appointment>().HasData(app);
            }

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
