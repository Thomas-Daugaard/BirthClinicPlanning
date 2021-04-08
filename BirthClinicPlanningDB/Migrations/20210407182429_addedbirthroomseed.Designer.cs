﻿// <auto-generated />
using System;
using BirthClinicPlanningDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BirthClinicPlanningDB.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210407182429_addedbirthroomseed")]
    partial class addedbirthroomseed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<bool>("BirthInProgess")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RoomID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("AppointmentID");

                    b.HasIndex("RoomID");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            AppointmentID = 1,
                            BirthInProgess = false,
                            EndTime = new DateTime(2021, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2021, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            AppointmentID = 2,
                            BirthInProgess = false,
                            EndTime = new DateTime(2021, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
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

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoomID")
                        .HasColumnType("int");

                    b.HasKey("ClinicianID");

                    b.HasIndex("RoomID");

                    b.ToTable("Clinicians");

                    b.HasData(
                        new
                        {
                            ClinicianID = 1,
                            FirstName = "Camilla",
                            LastName = "Holmstoel"
                        },
                        new
                        {
                            ClinicianID = 2,
                            FirstName = "Thomas",
                            LastName = "Daugaard"
                        },
                        new
                        {
                            ClinicianID = 3,
                            FirstName = "Emil",
                            LastName = "Garder"
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

                    b.Property<int?>("ChildID")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Occupied")
                        .HasColumnType("bit");

                    b.Property<int?>("ParentsID")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<string>("RoomType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomID");

                    b.HasIndex("ChildID");

                    b.HasIndex("ParentsID");

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
                            Occupied = true,
                            RoomNumber = 5,
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
                            RoomNumber = 3,
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
                        });
                });

            modelBuilder.Entity("BirthClinicPlanningDB.DomainObjects.Appointment", b =>
                {
                    b.HasOne("BirthClinicPlanningDB.DomainObjects.Room", null)
                        .WithMany("Appointments")
                        .HasForeignKey("AppointmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BirthClinicPlanningDB.DomainObjects.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomID");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("BirthClinicPlanningDB.DomainObjects.Clinician", b =>
                {
                    b.HasOne("BirthClinicPlanningDB.DomainObjects.Room", null)
                        .WithMany("Clinicians")
                        .HasForeignKey("RoomID");
                });

            modelBuilder.Entity("BirthClinicPlanningDB.DomainObjects.Parents", b =>
                {
                    b.HasOne("BirthClinicPlanningDB.DomainObjects.Child", "Child")
                        .WithMany()
                        .HasForeignKey("ChildID");

                    b.Navigation("Child");
                });

            modelBuilder.Entity("BirthClinicPlanningDB.DomainObjects.Room", b =>
                {
                    b.HasOne("BirthClinicPlanningDB.DomainObjects.Child", "Child")
                        .WithMany()
                        .HasForeignKey("ChildID");

                    b.HasOne("BirthClinicPlanningDB.DomainObjects.Parents", "Parents")
                        .WithMany()
                        .HasForeignKey("ParentsID");

                    b.Navigation("Child");

                    b.Navigation("Parents");
                });

            modelBuilder.Entity("BirthClinicPlanningDB.DomainObjects.Room", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Clinicians");
                });
#pragma warning restore 612, 618
        }
    }
}