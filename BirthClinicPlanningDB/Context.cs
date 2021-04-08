using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using BirthClinicPlanningDB.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BirthClinicPlanningDB
{
    public class Context : DbContext
    {
        public Context()
        { }

        public Context(DbContextOptions<Context> options): base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            ob.LogTo(message => Debug.WriteLine(message));

            ob.UseSqlServer(
                "Data Source=localhost;Initial Catalog=BirthClinic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            //Example: Data Source=localhost;Initial Catalog=BirthClinic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
            // Thomas Conn string: Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BirthClinic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Seed(modelBuilder);
        }

        private static void Seed(ModelBuilder modelBuilder)
        {
            SeedClinicians(modelBuilder);

            SeedChilds(modelBuilder);

            SeedParents(modelBuilder);

            SeedRooms(modelBuilder);

            SeedAppointments(modelBuilder);
        }

        private static void SeedAppointments(ModelBuilder modelBuilder)
        {
            var appointments = new ObservableCollection<Appointment>
            {
                new Appointment
                {
                    AppointmentID = 1,
                    StartTime = new DateTime(2021,06,07),
                    EndTime = new DateTime(2021,06,08),
                },

                new Appointment
                {
                    AppointmentID = 2,
                    StartTime = new DateTime(2021,07,08),
                    EndTime = new DateTime(2021,07,09),
                }

            };

            foreach (var app in appointments)
            {
                modelBuilder.Entity<Appointment>().HasData(app);
            }
        }

        private static void SeedClinicians(ModelBuilder modelBuilder)
        {
            var clinicians = new ObservableCollection<Clinician>
            {
                new Clinician
                {
                    ClinicianID = 1,
                    FirstName = "Camilla",
                    LastName = "Holmstoel",
                    Type = "Doctor"
                },
                new Clinician
                {
                    ClinicianID = 2,
                    FirstName = "Thomas",
                    LastName = "Daugaard",
                    Type = "Doctor"
                },
                new Clinician
                {
                    ClinicianID = 3,
                    FirstName = "Emil",
                    LastName = "Garder",
                    Type = "Doctor"
                },
                new Clinician
                {
                    ClinicianID = 4,
                    FirstName = "Camilla",
                    LastName = "Boesen",
                    Type = "Doctor"
                },
                new Clinician
                {
                    ClinicianID = 5,
                    FirstName = "Thomas",
                    LastName = "Boesen",
                    Type = "Doctor"
                },
                new Clinician
                {
                  ClinicianID = 6,
                  FirstName = "Emil",
                  LastName = "Boesen",
                  Type = "Secretary"
                },
                new Clinician
                {
                    ClinicianID = 7,
                    FirstName = "Camilla",
                    LastName = "Mikkelsen",
                    Type = "Secretary"
                },
                new Clinician
                {
                    ClinicianID = 8,
                    FirstName = "Thomas",
                    LastName = "Mikkelsen",
                    Type = "Secretary"
                },
                new Clinician
                {
                    ClinicianID = 9,
                    FirstName = "Emil",
                    LastName = "Mikkelsen",
                    Type = "Secretary"
                },
                new Clinician
                {
                    ClinicianID = 10,
                    FirstName = "Camilla",
                    LastName = "Overgaard",
                    Type = "SOSU Assistant"
                },
                new Clinician
                {
                    ClinicianID = 11,
                    FirstName = "Thomas",
                    LastName = "Overgaard",
                    Type = "SOSU Assistant"
                },
                new Clinician
                {
                    ClinicianID = 12,
                    FirstName = "Emil",
                    LastName = "Overgaard",
                    Type = "SOSU Assistant"
                }
            };

            foreach (var clin in clinicians)
            {
                modelBuilder.Entity<Clinician>().HasData(clin);
            }
        }

        private static void SeedChilds(ModelBuilder modelBuilder)
        {
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
        }

        private static void SeedParents(ModelBuilder modelBuilder)
        {
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
        }

        private static void SeedRooms(ModelBuilder modelBuilder)
        {
            var rooms = new ObservableCollection<RestRoom>
            {
                new RestRoom()
                {
                    RoomID = 1,
                    RoomNumber = 1,
                    Occupied = false
                },

                new RestRoom()
                {
                    RoomID = 2,
                    RoomNumber = 2,
                    Occupied = false
                },
                new RestRoom()
                {
                    RoomID = 5,
                    RoomNumber = 5,
                    Occupied = false
                },
                new RestRoom()
                {
                    RoomID = 6,
                    RoomNumber = 6,
                    Occupied = false
                },
                new RestRoom()
                {
                    RoomID = 7,
                    RoomNumber = 7,
                    Occupied = false
                }
            };

            foreach (var room in rooms)
            {
                modelBuilder.Entity<RestRoom>().HasData(room);
            }

            var matrooms = new ObservableCollection<MaternityRoom>
            {
                new MaternityRoom()
                {
                    RoomID = 3,
                    RoomNumber = 1,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = 8,
                    RoomNumber = 2,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = 9,
                    RoomNumber = 3,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = 10,
                    RoomNumber = 4,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = 11,
                    RoomNumber = 5,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = 12,
                    RoomNumber = 6,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = 13,
                    RoomNumber = 7,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = 14,
                    RoomNumber = 8,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = 15,
                    RoomNumber = 9,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = 16,
                    RoomNumber = 10,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = 17,
                    RoomNumber = 11,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = 18,
                    RoomNumber = 12,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = 19,
                    RoomNumber = 13,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = 20,
                    RoomNumber = 14,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = 21,
                    RoomNumber = 15,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = 22,
                    RoomNumber = 16,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = 23,
                    RoomNumber = 17,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = 24,
                    RoomNumber = 18,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = 25,
                    RoomNumber = 19,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = 27,
                    RoomNumber = 20,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = 28,
                    RoomNumber = 21,
                    Occupied = false
                },
                new MaternityRoom()
                {
                    RoomID = 29,
                    RoomNumber = 22,
                    Occupied = false
                }
            };

            foreach (var room in matrooms)
            {
                modelBuilder.Entity<MaternityRoom>().HasData(room);
            }


            var birthrooms = new ObservableCollection<BirthRoom>
            {
                new BirthRoom()
                {
                    RoomID = 4,
                    RoomNumber = 1,
                    Occupied = false
                },
                new BirthRoom()
                {
                    RoomID = 30,
                    RoomNumber = 2,
                    Occupied = false
                },
                new BirthRoom()
                {
                    RoomID = 31,
                    RoomNumber = 3,
                    Occupied = false
                },
                new BirthRoom()
                {
                    RoomID = 32,
                    RoomNumber = 4,
                    Occupied = false
                },
                new BirthRoom()
                {
                    RoomID = 33,
                    RoomNumber = 5,
                    Occupied = false
                },
                new BirthRoom()
                {
                    RoomID = 34,
                    RoomNumber = 6,
                    Occupied = false
                },
                new BirthRoom()
                {
                    RoomID = 35,
                    RoomNumber = 7,
                    Occupied = false
                },
                new BirthRoom()
                {
                    RoomID = 36,
                    RoomNumber = 8,
                    Occupied = false
                },
                new BirthRoom()
                {
                    RoomID = 37,
                    RoomNumber = 9,
                    Occupied = false
                },
                new BirthRoom()
                {
                    RoomID = 38,
                    RoomNumber = 10,
                    Occupied = false
                },
                new BirthRoom()
                {
                    RoomID = 39,
                    RoomNumber = 11,
                    Occupied = false
                },
                new BirthRoom()
                {
                    RoomID = 40,
                    RoomNumber = 12,
                    Occupied = false
                },
                new BirthRoom()
                {
                    RoomID = 41,
                    RoomNumber = 13,
                    Occupied = false
                },
                new BirthRoom()
                {
                    RoomID = 42,
                    RoomNumber = 14,
                    Occupied = false
                },
                new BirthRoom()
                {
                    RoomID = 43,
                    RoomNumber = 15,
                    Occupied = false
                }
            };

            foreach (var room in birthrooms)
            {
                modelBuilder.Entity<BirthRoom>().HasData(room);
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
