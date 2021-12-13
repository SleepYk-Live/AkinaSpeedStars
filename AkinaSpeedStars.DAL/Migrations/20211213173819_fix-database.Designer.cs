﻿// <auto-generated />
using System;
using AkinaSpeedStars.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AkinaSpeedStars.DAL.Migrations
{
    [DbContext(typeof(Data.AppContext))]
    [Migration("20211213173819_fix-database")]
    partial class fixdatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AkinaSpeedStars.DAL.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("AkinaSpeedStars.DAL.Entities.Kit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AdditionalDestination")
                        .HasColumnType("int");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Destination")
                        .HasColumnType("int");

                    b.Property<string>("Engine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GearShiftType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsATM")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDriverPositionLeft")
                        .HasColumnType("bit");

                    b.Property<int>("ModelCodeId")
                        .HasColumnType("int");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfDoors")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModelCodeId");

                    b.ToTable("Kits");
                });

            modelBuilder.Entity("AkinaSpeedStars.DAL.Entities.ModelCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ProductionEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ProductionStart")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("ModelCodes");
                });

            modelBuilder.Entity("AkinaSpeedStars.DAL.Entities.Part", b =>
                {
                    b.Property<long>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Code"), 1L, 1);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Info")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartTreeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ProductionEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ProductionStart")
                        .HasColumnType("datetime2");

                    b.HasKey("Code");

                    b.HasIndex("PartTreeId");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("AkinaSpeedStars.DAL.Entities.PartGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PartGroups");
                });

            modelBuilder.Entity("AkinaSpeedStars.DAL.Entities.PartSubgroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartGroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PartGroupId");

                    b.ToTable("PartSubgroups");
                });

            modelBuilder.Entity("AkinaSpeedStars.DAL.Entities.PartTree", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchemeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SchemeId");

                    b.ToTable("PartTrees");
                });

            modelBuilder.Entity("AkinaSpeedStars.DAL.Entities.Scheme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartSubgroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PartSubgroupId")
                        .IsUnique();

                    b.ToTable("Schemes");
                });

            modelBuilder.Entity("KitPartGroup", b =>
                {
                    b.Property<int>("KitsId")
                        .HasColumnType("int");

                    b.Property<int>("PartGroupsId")
                        .HasColumnType("int");

                    b.HasKey("KitsId", "PartGroupsId");

                    b.HasIndex("PartGroupsId");

                    b.ToTable("KitPartGroup");
                });

            modelBuilder.Entity("AkinaSpeedStars.DAL.Entities.Kit", b =>
                {
                    b.HasOne("AkinaSpeedStars.DAL.Entities.ModelCode", "ModelCode")
                        .WithMany("Kits")
                        .HasForeignKey("ModelCodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModelCode");
                });

            modelBuilder.Entity("AkinaSpeedStars.DAL.Entities.ModelCode", b =>
                {
                    b.HasOne("AkinaSpeedStars.DAL.Entities.Car", "Car")
                        .WithMany("ModelCodes")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("AkinaSpeedStars.DAL.Entities.Part", b =>
                {
                    b.HasOne("AkinaSpeedStars.DAL.Entities.PartTree", "PartTree")
                        .WithMany("Parts")
                        .HasForeignKey("PartTreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PartTree");
                });

            modelBuilder.Entity("AkinaSpeedStars.DAL.Entities.PartSubgroup", b =>
                {
                    b.HasOne("AkinaSpeedStars.DAL.Entities.PartGroup", "PartGroup")
                        .WithMany("Subgroups")
                        .HasForeignKey("PartGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PartGroup");
                });

            modelBuilder.Entity("AkinaSpeedStars.DAL.Entities.PartTree", b =>
                {
                    b.HasOne("AkinaSpeedStars.DAL.Entities.Scheme", "Scheme")
                        .WithMany("PartTrees")
                        .HasForeignKey("SchemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Scheme");
                });

            modelBuilder.Entity("AkinaSpeedStars.DAL.Entities.Scheme", b =>
                {
                    b.HasOne("AkinaSpeedStars.DAL.Entities.PartSubgroup", "PartSubgroup")
                        .WithOne("Scheme")
                        .HasForeignKey("AkinaSpeedStars.DAL.Entities.Scheme", "PartSubgroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PartSubgroup");
                });

            modelBuilder.Entity("KitPartGroup", b =>
                {
                    b.HasOne("AkinaSpeedStars.DAL.Entities.Kit", null)
                        .WithMany()
                        .HasForeignKey("KitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AkinaSpeedStars.DAL.Entities.PartGroup", null)
                        .WithMany()
                        .HasForeignKey("PartGroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AkinaSpeedStars.DAL.Entities.Car", b =>
                {
                    b.Navigation("ModelCodes");
                });

            modelBuilder.Entity("AkinaSpeedStars.DAL.Entities.ModelCode", b =>
                {
                    b.Navigation("Kits");
                });

            modelBuilder.Entity("AkinaSpeedStars.DAL.Entities.PartGroup", b =>
                {
                    b.Navigation("Subgroups");
                });

            modelBuilder.Entity("AkinaSpeedStars.DAL.Entities.PartSubgroup", b =>
                {
                    b.Navigation("Scheme")
                        .IsRequired();
                });

            modelBuilder.Entity("AkinaSpeedStars.DAL.Entities.PartTree", b =>
                {
                    b.Navigation("Parts");
                });

            modelBuilder.Entity("AkinaSpeedStars.DAL.Entities.Scheme", b =>
                {
                    b.Navigation("PartTrees");
                });
#pragma warning restore 612, 618
        }
    }
}
