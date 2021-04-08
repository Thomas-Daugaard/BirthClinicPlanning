﻿// <auto-generated />
using System;
using BirthClinicPlanningDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BirthClinicPlanningDB.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BirthClinicPlanningDB.DomainObjects.Appointment", b =>
                {
                    b.Property<int>("AppointmentID")
                        .HasColumnType("int");

                    b.Property<int?>("ChildID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ParentsID")
                        .HasColumnType("int");

                    b.Property<int>("RoomID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("AppointmentID");

                    b.HasIndex("ChildID");

                    b.HasIndex("ParentsID");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            AppointmentID = 1,
                            EndTime = new DateTime(2021, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoomID = 0,
                            StartTime = new DateTime(2021, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AppointmentID = 2,
                            EndTime = new DateTime(2021, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoomID = 0,
                            StartTime = new DateTime(2021, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("BirthClinicPlanningDB.DomainObjects.Child", b =>
                {
                    b.Property<int>("ChildID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("ChildID");

                    b.ToTable("Childs");

                    b.HasData(
                        new
                        {
                            ChildID = 1,
                            BirthDate = new DateTime(2020, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DisplayDate = "06-06-2020",
                            FirstName = "Leif",
                            LastName = "Knudsen",
                            Length = 56,
                            Weight = 3500
                        },
                        new
                        {
                            ChildID = 2,
                            BirthDate = new DateTime(2020, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DisplayDate = "07-06-2020",
                            FirstName = "Viggo",
                            LastName = "Mortensen",
                            Length = 56,
                            Weight = 3500
                        },
                        new
                        {
                            ChildID = 3,
                            BirthDate = new DateTime(2020, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DisplayDate = "08-06-2020",
                            FirstName = "Pascal",
                            LastName = "Pedersen",
                            Length = 56,
                            Weight = 3500
                        });
                });

            modelBuilder.Entity("BirthClinicPlanningDB.DomainObjects.Clinician", b =>
                {
                    b.Property<int>("ClinicianID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AppointmentID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClinicianID");

                    b.HasIndex("AppointmentID");

                    b.ToTable("Clinicians");

                    b.HasData(
                        new
                        {
                            ClinicianID = 1,
                            FirstName = "Camilla",
                            LastName = "Holmstoel",
                            Type = "Doctor"
                        },
                        new
                        {
                            ClinicianID = 2,
                            FirstName = "Thomas",
                            LastName = "Daugaard",
                            Type = "Doctor"
                        },
                        new
                        {
                            ClinicianID = 3,
                            FirstName = "Emil",
                            LastName = "Garder",
                            Type = "Doctor"
                        },
                        new
                        {
                            ClinicianID = 4,
                            FirstName = "Camilla",
                            LastName = "Boesen",
                            Type = "Doctor"
                        },
                        new
                        {
                            ClinicianID = 5,
                            FirstName = "Thomas",
                            LastName = "Boesen",
                            Type = "Doctor"
                        },
                        new
                        {
                            ClinicianID = 6,
                            FirstName = "Emil",
                            LastName = "Boesen",
                            Type = "Secretary"
                        },
                        new
                        {
                            ClinicianID = 7,
                            FirstName = "Camilla",
                            LastName = "Mikkelsen",
                            Type = "Secretary"
                        },
                        new
                        {
                            ClinicianID = 8,
                            FirstName = "Thomas",
                            LastName = "Mikkelsen",
                            Type = "Secretary"
                        },
                        new
                        {
                            ClinicianID = 9,
                            FirstName = "Emil",
                            LastName = "Mikkelsen",
                            Type = "Secretary"
                        },
                        new
                        {
                            ClinicianID = 10,
                            FirstName = "Camilla",
                            LastName = "Overgaard",
                            Type = "SOSU Assistant"
                        },
                        new
                        {
                            ClinicianID = 11,
                            FirstName = "Thomas",
                            LastName = "Overgaard",
                            Type = "SOSU Assistant"
                        },
                        new
                        {
                            ClinicianID = 12,
                            FirstName = "Emil",
                            LastName = "Overgaard",
                            Type = "SOSU Assistant"
                        });
                });

            modelBuilder.Entity("BirthClinicPlanningDB.DomainObjects.Parents", b =>
                {
                    b.Property<int>("ParentsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChildID")
                        .HasColumnType("int");

                    b.Property<string>("DadCPR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DadFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DadLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MomCPR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MomFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MomLastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ParentsID");

                    b.HasIndex("ChildID");

                    b.ToTable("Parents");

                    b.HasData(
                        new
                        {
                            ParentsID = 1,
                            DadCPR = "2103898569",
                            DadFirstName = "Lars",
                            DadLastName = "Thomsen",
                            MomCPR = "2003928596",
                            MomFirstName = "Camilla",
                            MomLastName = "Thomsen"
                        },
                        new
                        {
                            ParentsID = 2,
                            DadCPR = "2104898569",
                            DadFirstName = "Knabe",
                            DadLastName = "Frederiksen",
                            MomCPR = "2004928596",
                            MomFirstName = "Tove",
                            MomLastName = "Frederiksen"
                        },
                        new
                        {
                            ParentsID = 3,
                            DadCPR = "2105898569",
                            DadFirstName = "Per",
                            DadLastName = "Gudrundsen",
                            MomCPR = "2005928596",
                            MomFirstName = "Hilda",
                            MomLastName = "Gudrundsen"
                        });
                });

            modelBuilder.Entity("BirthClinicPlanningDB.DomainObjects.Room", b =>
                {
                    b.Property<int>("RoomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Occupied")
                        .HasColumnType("bit");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<string>("RoomType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomID");

                    b.ToTable("Room");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Room");
                });

            modelBuilder.Entity("BirthClinicPlanningDB.DomainObjects.BirthRoom", b =>
                {
                    b.HasBaseType("BirthClinicPlanningDB.DomainObjects.Room");

                    b.HasDiscriminator().HasValue("BirthRoom");

                    b.HasData(
                        new
                        {
                            RoomID = 4,
                            Occupied = false,
                            RoomNumber = 1,
                            RoomType = "Birth Room"
                        },
                        new
                        {
                            RoomID = 30,
                            Occupied = false,
                            RoomNumber = 2,
                            RoomType = "Birth Room"
                        },
                        new
                        {
                            RoomID = 31,
                            Occupied = false,
                            RoomNumber = 3,
                            RoomType = "Birth Room"
                        },
                        new
                        {
                            RoomID = 32,
                            Occupied = false,
                            RoomNumber = 4,
                            RoomType = "Birth Room"
                        },
                        new
                        {
                            RoomID = 33,
                            Occupied = false,
                            RoomNumber = 5,
                            RoomType = "Birth Room"
                        },
                        new
                        {
                            RoomID = 34,
                            Occupied = false,
                            RoomNumber = 6,
                            RoomType = "Birth Room"
                        },
                        new
                        {
                            RoomID = 35,
                            Occupied = false,
                            RoomNumber = 7,
                            RoomType = "Birth Room"
                        },
                        new
                        {
                            RoomID = 36,
                            Occupied = false,
                            RoomNumber = 8,
                            RoomType = "Birth Room"
                        },
                        new
                        {
                            RoomID = 37,
                            Occupied = false,
                            RoomNumber = 9,
                            RoomType = "Birth Room"
                        },
                        new
                        {
                            RoomID = 38,
                            Occupied = false,
                            RoomNumber = 10,
                            RoomType = "Birth Room"
                        },
                        new
                        {
                            RoomID = 39,
                            Occupied = false,
                            RoomNumber = 11,
                            RoomType = "Birth Room"
                        },
                        new
                        {
                            RoomID = 40,
                            Occupied = false,
                            RoomNumber = 12,
                            RoomType = "Birth Room"
                        },
                        new
                        {
                            RoomID = 41,
                            Occupied = false,
                            RoomNumber = 13,
                            RoomType = "Birth Room"
                        },
                        new
                        {
                            RoomID = 42,
                            Occupied = false,
                            RoomNumber = 14,
                            RoomType = "Birth Room"
                        },
                        new
                        {
                            RoomID = 43,
                            Occupied = false,
                            RoomNumber = 15,
                            RoomType = "Birth Room"
                        });
                });

            modelBuilder.Entity("BirthClinicPlanningDB.DomainObjects.MaternityRoom", b =>
                {
                    b.HasBaseType("BirthClinicPlanningDB.DomainObjects.Room");

                    b.HasDiscriminator().HasValue("MaternityRoom");

                    b.HasData(
                        new
                        {
                            RoomID = 3,
                            Occupied = false,
                            RoomNumber = 1,
                            RoomType = "Maternity Room"
                        },
                        new
                        {
                            RoomID = 8,
                            Occupied = false,
                            RoomNumber = 2,
                            RoomType = "Maternity Room"
                        },
                        new
                        {
                            RoomID = 9,
                            Occupied = false,
                            RoomNumber = 3,
                            RoomType = "Maternity Room"
                        },
                        new
                        {
                            RoomID = 10,
                            Occupied = false,
                            RoomNumber = 4,
                            RoomType = "Maternity Room"
                        },
                        new
                        {
                            RoomID = 11,
                            Occupied = false,
                            RoomNumber = 5,
                            RoomType = "Maternity Room"
                        },
                        new
                        {
                            RoomID = 12,
                            Occupied = false,
                            RoomNumber = 6,
                            RoomType = "Maternity Room"
                        },
                        new
                        {
                            RoomID = 13,
                            Occupied = false,
                            RoomNumber = 7,
                            RoomType = "Maternity Room"
                        },
                        new
                        {
                            RoomID = 14,
                            Occupied = false,
                            RoomNumber = 8,
                            RoomType = "Maternity Room"
                        },
                        new
                        {
                            RoomID = 15,
                            Occupied = false,
                            RoomNumber = 9,
                            RoomType = "Maternity Room"
                        },
                        new
                        {
                            RoomID = 16,
                            Occupied = false,
                            RoomNumber = 10,
                            RoomType = "Maternity Room"
                        },
                        new
                        {
                            RoomID = 17,
                            Occupied = false,
                            RoomNumber = 11,
                            RoomType = "Maternity Room"
                        },
                        new
                        {
                            RoomID = 18,
                            Occupied = false,
                            RoomNumber = 12,
                            RoomType = "Maternity Room"
                        },
                        new
                        {
                            RoomID = 19,
                            Occupied = false,
                            RoomNumber = 13,
                            RoomType = "Maternity Room"
                        },
                        new
                        {
                            RoomID = 20,
                            Occupied = false,
                            RoomNumber = 14,
                            RoomType = "Maternity Room"
                        },
                        new
                        {
                            RoomID = 21,
                            Occupied = false,
                            RoomNumber = 15,
                            RoomType = "Maternity Room"
                        },
                        new
                        {
                            RoomID = 22,
                            Occupied = false,
                            RoomNumber = 16,
                            RoomType = "Maternity Room"
                        },
                        new
                        {
                            RoomID = 23,
                            Occupied = false,
                            RoomNumber = 17,
                            RoomType = "Maternity Room"
                        },
                        new
                        {
                            RoomID = 24,
                            Occupied = false,
                            RoomNumber = 18,
                            RoomType = "Maternity Room"
                        },
                        new
                        {
                            RoomID = 25,
                            Occupied = false,
                            RoomNumber = 19,
                            RoomType = "Maternity Room"
                        },
                        new
                        {
                            RoomID = 27,
                            Occupied = false,
                            RoomNumber = 20,
                            RoomType = "Maternity Room"
                        },
                        new
                        {
                            RoomID = 28,
                            Occupied = false,
                            RoomNumber = 21,
                            RoomType = "Maternity Room"
                        },
                        new
                        {
                            RoomID = 29,
                            Occupied = false,
                            RoomNumber = 22,
                            RoomType = "Maternity Room"
                        });
                });

            modelBuilder.Entity("BirthClinicPlanningDB.DomainObjects.RestRoom", b =>
                {
                    b.HasBaseType("BirthClinicPlanningDB.DomainObjects.Room");

                    b.HasDiscriminator().HasValue("RestRoom");

                    b.HasData(
                        new
                        {
                            RoomID = 1,
                            Occupied = false,
                            RoomNumber = 1,
                            RoomType = "Rest Room"
                        },
                        new
                        {
                            RoomID = 2,
                            Occupied = false,
                            RoomNumber = 2,
                            RoomType = "Rest Room"
                        },
                        new
                        {
                            RoomID = 5,
                            Occupied = false,
                            RoomNumber = 5,
                            RoomType = "Rest Room"
                        },
                        new
                        {
                            RoomID = 6,
                            Occupied = false,
                            RoomNumber = 6,
                            RoomType = "Rest Room"
                        },
                        new
                        {
                            RoomID = 7,
                            Occupied = false,
                            RoomNumber = 7,
                            RoomType = "Rest Room"
                        });
                });

            modelBuilder.Entity("BirthClinicPlanningDB.DomainObjects.Appointment", b =>
                {
                    b.HasOne("BirthClinicPlanningDB.DomainObjects.Room", "Room")
                        .WithMany("Appointments")
                        .HasForeignKey("AppointmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BirthClinicPlanningDB.DomainObjects.Child", "Child")
                        .WithMany()
                        .HasForeignKey("ChildID");

                    b.HasOne("BirthClinicPlanningDB.DomainObjects.Parents", "Parents")
                        .WithMany()
                        .HasForeignKey("ParentsID");

                    b.Navigation("Child");

                    b.Navigation("Parents");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("BirthClinicPlanningDB.DomainObjects.Clinician", b =>
                {
                    b.HasOne("BirthClinicPlanningDB.DomainObjects.Appointment", null)
                        .WithMany("Clinicians")
                        .HasForeignKey("AppointmentID");
                });

            modelBuilder.Entity("BirthClinicPlanningDB.DomainObjects.Parents", b =>
                {
                    b.HasOne("BirthClinicPlanningDB.DomainObjects.Child", "Child")
                        .WithMany()
                        .HasForeignKey("ChildID");

                    b.Navigation("Child");
                });

            modelBuilder.Entity("BirthClinicPlanningDB.DomainObjects.Appointment", b =>
                {
                    b.Navigation("Clinicians");
                });

            modelBuilder.Entity("BirthClinicPlanningDB.DomainObjects.Room", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
