﻿// <auto-generated />
using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Domain.Migrations
{
    [DbContext(typeof(RecordConsumptionDbContext))]
    [Migration("20230313195048_Phone")]
    partial class Phone
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LongDesk")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PhotoId")
                        .HasColumnType("int");

                    b.Property<string>("ShortDesk")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PhotoId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Domain.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("FileGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NameFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PolyclinicId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PolyclinicId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Domain.Models.Polyclinic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<int>("TownId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TownId");

                    b.ToTable("Polyclinics");
                });

            modelBuilder.Entity("Domain.Models.Practice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("End")
                        .HasColumnType("datetime2");

                    b.Property<int>("PolyclinicId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("SpecializationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PolyclinicId");

                    b.HasIndex("SpecializationId");

                    b.ToTable("Practices");
                });

            modelBuilder.Entity("Domain.Models.Specialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("Domain.Models.Town", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Towns");
                });

            modelBuilder.Entity("Domain.Models.Doctor", b =>
                {
                    b.HasOne("Domain.Models.Photo", "Photo")
                        .WithMany()
                        .HasForeignKey("PhotoId");

                    b.Navigation("Photo");
                });

            modelBuilder.Entity("Domain.Models.Photo", b =>
                {
                    b.HasOne("Domain.Models.Polyclinic", null)
                        .WithMany("Photos")
                        .HasForeignKey("PolyclinicId");
                });

            modelBuilder.Entity("Domain.Models.Polyclinic", b =>
                {
                    b.HasOne("Domain.Models.Town", "Town")
                        .WithMany("Polyclinics")
                        .HasForeignKey("TownId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Town");
                });

            modelBuilder.Entity("Domain.Models.Practice", b =>
                {
                    b.HasOne("Domain.Models.Doctor", "Doctor")
                        .WithMany("Practices")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Polyclinic", "Polyclinic")
                        .WithMany("Doctors")
                        .HasForeignKey("PolyclinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Specialization", "Specialization")
                        .WithMany("Practices")
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Polyclinic");

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("Domain.Models.Doctor", b =>
                {
                    b.Navigation("Practices");
                });

            modelBuilder.Entity("Domain.Models.Polyclinic", b =>
                {
                    b.Navigation("Doctors");

                    b.Navigation("Photos");
                });

            modelBuilder.Entity("Domain.Models.Specialization", b =>
                {
                    b.Navigation("Practices");
                });

            modelBuilder.Entity("Domain.Models.Town", b =>
                {
                    b.Navigation("Polyclinics");
                });
#pragma warning restore 612, 618
        }
    }
}