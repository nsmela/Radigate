namespace Radigate.Server.Data {
    public class PatientDataContext : DbContext {
        protected readonly IConfiguration Configuration;

        public PatientDataContext(IConfiguration configuration) {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("SQLLiteConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<TaskBase>().HasKey(t => new { t.PatientId, t.GroupId }); ;
            modelBuilder.Entity<TaskBool>().UseTptMappingStrategy();
                modelBuilder.Entity<TaskBool>().HasData(
                    new TaskBool { PatientId = 1, GroupId = 1, Label = "Check the patient", Value = true},
                    new TaskBool { PatientId = 1, GroupId = 1, Label = "Authorize the patient", Value = false },
                    new TaskBool { PatientId = 1, GroupId = 1, Label = "Ready to treat", Value = false },

                    new TaskBool { PatientId = 1, GroupId = 2, Label = "Check MU", Value = true },
                    new TaskBool { PatientId = 1, GroupId = 2, Label = "QA Performed", Value = true },
                    new TaskBool { PatientId = 1, GroupId = 2, Label = "Ready to treat", Value = true },

                    new TaskBool { PatientId = 2, GroupId = 1, Label = "Check the patient", Value = false },
                    new TaskBool { PatientId = 2, GroupId = 1, Label = "Authorize the patient", Value = true },
                    new TaskBool { PatientId = 2, GroupId = 1, Label = "Ready to treat", Value = true },
                                               
                    new TaskBool { PatientId = 2, GroupId = 2, Label = "Check MU", Value = true },
                    new TaskBool { PatientId = 2, GroupId = 2, Label = "QA Performed", Value = false },
                    new TaskBool { PatientId = 2, GroupId = 2, Label = "Ready to treat", Value = true },
                                        
                    new TaskBool { PatientId = 3, GroupId = 1, Label = "Check the patient", Value = false },
                    new TaskBool { PatientId = 3, GroupId = 1, Label = "Authorize the patient", Value = true },
                    new TaskBool { PatientId = 3, GroupId = 1, Label = "Ready to treat", Value = true },
                                               
                    new TaskBool { PatientId = 3, GroupId = 2, Label = "Check MU", Value = true },
                    new TaskBool { PatientId = 3, GroupId = 2, Label = "QA Performed", Value = false },
                    new TaskBool { PatientId = 3, GroupId = 2, Label = "Ready to treat", Value = true }
            );

            modelBuilder.Entity<TaskText>()
                .UseTptMappingStrategy()
                .HasData(
                    new TaskText { PatientId = 1, GroupId = 1, Label = "Check the patient" },
                    new TaskText { PatientId = 1, GroupId = 1, Label = "Authorize the patient",},
                            
                    new TaskText { PatientId = 1, GroupId = 2, Label = "QA Performed"},
                    new TaskText { PatientId = 1, GroupId = 2, Label = "Ready to treat",},
                            
                    new TaskText { PatientId = 2, GroupId = 1, Label = "Ready to treat"},
                            
                    new TaskText { PatientId = 2, GroupId = 2, Label = "QA Performed"},
                    new TaskText { PatientId = 2, GroupId = 2, Label = "Ready to treat"},
                            
                    new TaskText { PatientId = 3, GroupId = 1, Label = "Check the patient"},
                    new TaskText { PatientId = 3, GroupId = 1, Label = "Authorize the patient",},
                            
                    new TaskText { PatientId = 3, GroupId = 2, Label = "Check MU",},
                    new TaskText { PatientId = 3, GroupId = 2, Label = "Ready to treat"}
            );

            modelBuilder.Entity<TaskDouble>()
                .UseTptMappingStrategy()
                .HasData(
                    new TaskDouble { PatientId = 1, GroupId = 1, Label = "Volume", Value = 10.5f }
            );

            modelBuilder.Entity<TaskGroup>().HasData(
                new TaskGroup { Id = 1, Label = "Standard", PatientId = 1},
                new TaskGroup { Id = 2, Label = "Physics Processes", PatientId = 1 },
                new TaskGroup { Id = 3, Label = "Brachy Processes", PatientId = 1 },
                new TaskGroup { Id = 4, Label = "Standard", PatientId = 2 },
                new TaskGroup { Id = 5, Label = "Chemo Processes", PatientId = 2 },
                new TaskGroup { Id = 6, Label = "Standard", PatientId = 3 },
                new TaskGroup { Id = 7, Label = "Chemo Processes", PatientId = 3 },
                new TaskGroup { Id = 8, Label = "Standard", PatientId = 4 },
                new TaskGroup { Id = 9, Label = "Physics Processes", PatientId = 4 },
                new TaskGroup { Id = 10, Label = "Chemo Process", PatientId = 4 }

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
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<TaskGroup> TaskGroups { get; set; }
        public DbSet<TaskBase> Tasks { get; set; }
    }
}
