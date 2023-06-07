﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Radigate.Server.Data;

#nullable disable

namespace Radigate.Server.Migrations
{
    [DbContext(typeof(PatientDataContext))]
    partial class PatientDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Radigate.Shared.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Ryan",
                            LastName = "Stiles"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Greg",
                            LastName = "Proops"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Colin",
                            LastName = "Mocharie"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Wayne",
                            LastName = "Bradey"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Aishia",
                            LastName = "Taylor"
                        },
                        new
                        {
                            Id = 6,
                            FirstName = "Clive",
                            LastName = "Owen"
                        },
                        new
                        {
                            Id = 7,
                            FirstName = "Drew",
                            LastName = "Carey"
                        });
                });

            modelBuilder.Entity("Radigate.Shared.TaskBase", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TaskGroupId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Tasks");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Radigate.Shared.TaskGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PatientId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("TaskGroups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Label = "Standard",
                            PatientId = 1
                        },
                        new
                        {
                            Id = 2,
                            Label = "Standard",
                            PatientId = 2
                        });
                });

            modelBuilder.Entity("Radigate.Shared.TaskBool", b =>
                {
                    b.HasBaseType("Radigate.Shared.TaskBase");

                    b.Property<bool>("Value")
                        .HasColumnType("INTEGER");

                    b.ToTable("TaskBool");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comments = "",
                            Label = "Approved",
                            TaskGroupId = 1,
                            Value = false
                        });
                });

            modelBuilder.Entity("Radigate.Shared.TaskCalculation", b =>
                {
                    b.HasBaseType("Radigate.Shared.TaskBase");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.ToTable("TaskCalculation");
                });

            modelBuilder.Entity("Radigate.Shared.TaskDate", b =>
                {
                    b.HasBaseType("Radigate.Shared.TaskBase");

                    b.Property<DateTime?>("Value")
                        .HasColumnType("TEXT");

                    b.ToTable("TaskDate");
                });

            modelBuilder.Entity("Radigate.Shared.TaskDouble", b =>
                {
                    b.HasBaseType("Radigate.Shared.TaskBase");

                    b.Property<double>("Value")
                        .HasColumnType("REAL");

                    b.ToTable("TaskDouble");
                });

            modelBuilder.Entity("Radigate.Shared.TaskList", b =>
                {
                    b.HasBaseType("Radigate.Shared.TaskBase");

                    b.Property<string>("Options")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SelectedValue")
                        .HasColumnType("INTEGER");

                    b.ToTable("TaskList");
                });

            modelBuilder.Entity("Radigate.Shared.TaskText", b =>
                {
                    b.HasBaseType("Radigate.Shared.TaskBase");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.ToTable("TaskText");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Comments = "",
                            Label = "Assigned RO",
                            TaskGroupId = 2,
                            Value = "None."
                        });
                });

            modelBuilder.Entity("Radigate.Shared.TaskBase", b =>
                {
                    b.HasOne("Radigate.Shared.TaskGroup", "TaskGroup")
                        .WithMany("Tasks")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaskGroup");
                });

            modelBuilder.Entity("Radigate.Shared.TaskGroup", b =>
                {
                    b.HasOne("Radigate.Shared.Patient", "Patient")
                        .WithMany("TaskGroups")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Radigate.Shared.TaskBool", b =>
                {
                    b.HasOne("Radigate.Shared.TaskBase", null)
                        .WithOne()
                        .HasForeignKey("Radigate.Shared.TaskBool", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Radigate.Shared.TaskCalculation", b =>
                {
                    b.HasOne("Radigate.Shared.TaskBase", null)
                        .WithOne()
                        .HasForeignKey("Radigate.Shared.TaskCalculation", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Radigate.Shared.TaskDate", b =>
                {
                    b.HasOne("Radigate.Shared.TaskBase", null)
                        .WithOne()
                        .HasForeignKey("Radigate.Shared.TaskDate", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Radigate.Shared.TaskDouble", b =>
                {
                    b.HasOne("Radigate.Shared.TaskBase", null)
                        .WithOne()
                        .HasForeignKey("Radigate.Shared.TaskDouble", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Radigate.Shared.TaskList", b =>
                {
                    b.HasOne("Radigate.Shared.TaskBase", null)
                        .WithOne()
                        .HasForeignKey("Radigate.Shared.TaskList", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Radigate.Shared.TaskText", b =>
                {
                    b.HasOne("Radigate.Shared.TaskBase", null)
                        .WithOne()
                        .HasForeignKey("Radigate.Shared.TaskText", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Radigate.Shared.Patient", b =>
                {
                    b.Navigation("TaskGroups");
                });

            modelBuilder.Entity("Radigate.Shared.TaskGroup", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
