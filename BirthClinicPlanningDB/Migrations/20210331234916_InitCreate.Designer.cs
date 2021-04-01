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
    [Migration("20210331234916_InitCreate")]
    partial class InitCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BirthClinicPlanningDB.DomainObjects.Appointment", b =>
                {
                    b.Property<int>("AppointmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BirthInProgess")
                        .HasColumnType("bit");

                    b.Property<int?>("ChildID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentsID")
                        .HasColumnType("int");

                    b.Property<int>("RoomID")
                        .HasColumnType("int");

                    b.HasKey("AppointmentID");

                    b.HasIndex("ChildID");

                    b.HasIndex("ParentsID");

                    b.ToTable("Appointments");
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
                });

            modelBuilder.Entity("BirthClinicPlanningDB.DomainObjects.Clinician", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AppointmentID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AppointmentID");

                    b.ToTable("Clinicians");
                });

            modelBuilder.Entity("BirthClinicPlanningDB.DomainObjects.MaternityRoom", b =>
                {
                    b.Property<int>("MaternityRoomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChildID")
                        .HasColumnType("int");

                    b.Property<bool>("Occupied")
                        .HasColumnType("bit");

                    b.Property<int?>("ParentsID")
                        .HasColumnType("int");

                    b.Property<int>("RoomID")
                        .HasColumnType("int");

                    b.HasKey("MaternityRoomID");

                    b.HasIndex("ChildID");

                    b.HasIndex("ParentsID");

                    b.ToTable("maternityrooms");
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
                });

            modelBuilder.Entity("BirthClinicPlanningDB.DomainObjects.RestRoom", b =>
                {
                    b.Property<int>("RestRoomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChildID")
                        .HasColumnType("int");

                    b.Property<bool>("Occupied")
                        .HasColumnType("bit");

                    b.Property<int?>("ParentsID")
                        .HasColumnType("int");

                    b.Property<int>("RoomID")
                        .HasColumnType("int");

                    b.HasKey("RestRoomID");

                    b.HasIndex("ChildID");

                    b.HasIndex("ParentsID");

                    b.ToTable("Restrooms");
                });

            modelBuilder.Entity("BirthClinicPlanningDB.DomainObjects.Appointment", b =>
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

            modelBuilder.Entity("BirthClinicPlanningDB.DomainObjects.Clinician", b =>
                {
                    b.HasOne("BirthClinicPlanningDB.DomainObjects.Appointment", null)
                        .WithMany("Clinicians")
                        .HasForeignKey("AppointmentID");
                });

            modelBuilder.Entity("BirthClinicPlanningDB.DomainObjects.MaternityRoom", b =>
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

            modelBuilder.Entity("BirthClinicPlanningDB.DomainObjects.Parents", b =>
                {
                    b.HasOne("BirthClinicPlanningDB.DomainObjects.Child", "Child")
                        .WithMany()
                        .HasForeignKey("ChildID");

                    b.Navigation("Child");
                });

            modelBuilder.Entity("BirthClinicPlanningDB.DomainObjects.RestRoom", b =>
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

            modelBuilder.Entity("BirthClinicPlanningDB.DomainObjects.Appointment", b =>
                {
                    b.Navigation("Clinicians");
                });
#pragma warning restore 612, 618
        }
    }
}
