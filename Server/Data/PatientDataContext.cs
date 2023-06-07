﻿using Radigate.Shared;

namespace Radigate.Server.Data {
    public class PatientDataContext : DbContext {
        protected readonly IConfiguration Configuration;

        public PatientDataContext(IConfiguration configuration) {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("SQLLiteConnection"));
            optionsBuilder
                .LogTo(Console.WriteLine)
                .EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //https://learn.microsoft.com/en-us/archive/msdn-magazine/2018/august/data-points-deep-dive-into-ef-core-hasdata-seeding
            //https://learn.microsoft.com/en-us/ef/core/modeling/inheritance
            //https://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx
            //https://learn.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key

            modelBuilder.Entity<Patient>()
                .HasMany(p => p.TaskGroups)
                .WithOne(g => g.Patient)
                .HasForeignKey(g => g.PatientId)
                .HasPrincipalKey(t => t.Id);

            modelBuilder.Entity<TaskGroup>()
                .HasMany(g => g.Tasks)
                .WithOne(t => t.TaskGroup)
                .HasForeignKey(t => t.Id)
                .HasPrincipalKey(g => g.Id);

            modelBuilder.Entity<TaskItem>().ToTable("Tasks");


            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem { Id = 1, Label = "Approved", TaskGroupId = 1, Type=(int)TaskType.Bool, Value = "false"},
                new TaskItem { Id = 2, Label = "Physics Approved", TaskGroupId = 1, Type = (int)TaskType.Bool, Value = "true" });

            modelBuilder.Entity<TaskGroup>().HasData(
                new TaskGroup { PatientId = 1, Id = 1, Label = "Standard"},
                new TaskGroup { PatientId = 2, Id = 2, Label = "Standard" },
                new TaskGroup { PatientId = 2, Id = 3, Label = "Physics Checks" }
            );
                
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, LastName = "Stiles", FirstName = "Ryan" },
                new Patient { Id = 2, LastName = "Proops", FirstName = "Greg" },
                new Patient { Id = 3, LastName = "Mocharie", FirstName = "Colin" },
                new Patient { Id = 4, LastName = "Bradey", FirstName = "Wayne" },
                new Patient { Id = 5, LastName = "Taylor", FirstName = "Aishia" },
                new Patient { Id = 6, LastName = "Owen", FirstName = "Clive" },
                new Patient { Id = 7, LastName = "Carey", FirstName = "Drew" }
            );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<TaskGroup> TaskGroups { get; set; }
        public DbSet<TaskBool> TPCBool { get; set; }
        public DbSet<TaskText> TPCText { get; set; }
        public DbSet<TaskDouble> TPCDouble { get; set; }
    }
}
