using Radigate.Shared;

namespace Radigate.Server.Data {
    public class PatientDataContext : DbContext {
        protected readonly IConfiguration Configuration;

        public PatientDataContext(IConfiguration configuration) {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("SQLLiteConnection"));
            //optionsBuilder
                //.LogTo(Console.WriteLine)
                //.EnableDetailedErrors();
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
                .HasForeignKey(t => t.TaskGroupId)
                .HasPrincipalKey(g => g.Id);

            modelBuilder.Entity<TaskItem>().ToTable("Tasks");

            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem { Id = 1, Label = "Assigned RO", TaskGroupId = 1, Type = (int)TaskType.Text, Value = "No one", SortingOrder = 0 },
                new TaskItem { Id = 2, Label = "Approved by RO", TaskGroupId = 1, Type = (int)TaskType.Bool, Value = "false", SortingOrder = 1 },
                new TaskItem { Id = 3, Label = "Mass Volume", TaskGroupId = 1, Type = (int)TaskType.Number, Value = "150.0", SortingOrder = 2 },
                new TaskItem { Id = 4, Label = "Patient Status", TaskGroupId = 1, Type = (int)TaskType.List, Value = "2,Waiting,Assigned,Treating,Finished", SortingOrder = 3 },
                new TaskItem { Id = 5, Label = "Approved by RO", TaskGroupId = 2, Type = (int)TaskType.Bool, Value = "false" },
                new TaskItem { Id = 6, Label = "Assigned Physicist", TaskGroupId = 2, Type = (int)TaskType.Text, Value = "No one" },
                new TaskItem { Id = 7, Label = "Mass Volume", TaskGroupId = 2, Type = (int)TaskType.Number, Value = "12.55" },
                new TaskItem { Id = 8, Label = "Assigned RO", TaskGroupId = 3, Type = (int)TaskType.Text, Value = "No one" },
                new TaskItem { Id = 9, Label = "Approved by RO", TaskGroupId = 3, Type = (int)TaskType.Bool, Value = "false" },
                new TaskItem { Id = 10, Label = "Mass Volume", TaskGroupId = 3, Type = (int)TaskType.Number, Value = "150.0" },
                new TaskItem { Id = 11, Label = "Patient Status", TaskGroupId = 3, Type = (int)TaskType.List, Value = "1,Waiting,Assigned,Treating,Finished" },
                new TaskItem { Id = 12, Label = "Approved by RO", TaskGroupId = 4, Type = (int)TaskType.Bool, Value = "false" },
                new TaskItem { Id = 13, Label = "Assigned Physicist", TaskGroupId = 4, Type = (int)TaskType.Text, Value = "No one" },
                new TaskItem { Id = 14, Label = "Mass Volume", TaskGroupId = 4, Type = (int)TaskType.Number, Value = "12.55" },
                new TaskItem { Id = 15, Label = "Assigned RO", TaskGroupId = 5, Type = (int)TaskType.Text, Value = "No one" },
                new TaskItem { Id = 16, Label = "Approved by RO", TaskGroupId = 5, Type = (int)TaskType.Bool, Value = "false" },
                new TaskItem { Id = 17, Label = "Mass Volume", TaskGroupId = 5, Type = (int)TaskType.Number, Value = "150.0" },
                new TaskItem { Id = 18, Label = "Patient Status", TaskGroupId = 5, Type = (int)TaskType.List, Value = "1,Waiting,Assigned,Treating,Finished" },
                new TaskItem { Id = 19, Label = "Approved by RO", TaskGroupId = 6, Type = (int)TaskType.Bool, Value = "false" },
                new TaskItem { Id = 20, Label = "Assigned Physicist", TaskGroupId = 6, Type = (int)TaskType.Text, Value = "No one" },
                new TaskItem { Id = 21, Label = "Mass Volume", TaskGroupId = 6, Type = (int)TaskType.Number, Value = "12.55" },
                new TaskItem { Id = 22, Label = "Assigned RO", TaskGroupId = 7, Type = (int)TaskType.Text, Value = "No one" },
                new TaskItem { Id = 23, Label = "Approved by RO", TaskGroupId = 7, Type = (int)TaskType.Bool, Value = "false" },
                new TaskItem { Id = 24, Label = "Mass Volume", TaskGroupId = 7, Type = (int)TaskType.Number, Value = "150.0" },
                new TaskItem { Id = 25, Label = "Patient Status", TaskGroupId = 7, Type = (int)TaskType.List, Value = "2,Waiting,Assigned,Treating,Finished" },
                new TaskItem { Id = 26, Label = "Approved by RO", TaskGroupId = 8, Type = (int)TaskType.Bool, Value = "false" },
                new TaskItem { Id = 27, Label = "Assigned Physicist", TaskGroupId = 8, Type = (int)TaskType.Text, Value = "No one" },
                new TaskItem { Id = 28, Label = "Mass Volume", TaskGroupId = 8, Type = (int)TaskType.Number, Value = "12.55" },
                new TaskItem { Id = 29, Label = "Assigned RO", TaskGroupId = 9, Type = (int)TaskType.Text, Value = "No one" },
                new TaskItem { Id = 30, Label = "Approved by RO", TaskGroupId = 9, Type = (int)TaskType.Bool, Value = "false" },
                new TaskItem { Id = 31, Label = "Mass Volume", TaskGroupId = 9, Type = (int)TaskType.Number, Value = "150.0" },
                new TaskItem { Id = 32, Label = "Patient Status", TaskGroupId = 9, Type = (int)TaskType.List, Value = "3,Waiting,Assigned,Treating,Finished" },
                new TaskItem { Id = 33, Label = "Approved by RO", TaskGroupId = 10, Type = (int)TaskType.Bool, Value = "false" },
                new TaskItem { Id = 34, Label = "Assigned Physicist", TaskGroupId = 10, Type = (int)TaskType.Text, Value = "No one" },
                new TaskItem { Id = 35, Label = "Mass Volume", TaskGroupId = 10, Type = (int)TaskType.Number, Value = "12.55" },
                new TaskItem { Id = 36, Label = "Assigned RO", TaskGroupId = 11, Type = (int)TaskType.Text, Value = "No one" },
                new TaskItem { Id = 37, Label = "Approved by RO", TaskGroupId = 11, Type = (int)TaskType.Bool, Value = "false" },
                new TaskItem { Id = 38, Label = "Mass Volume", TaskGroupId = 11, Type = (int)TaskType.Number, Value = "150.0" },
                new TaskItem { Id = 39, Label = "Patient Status", TaskGroupId = 11, Type = (int)TaskType.List, Value = "3,Waiting,Assigned,Treating,Finished" },
                new TaskItem { Id = 40, Label = "Approved by RO", TaskGroupId = 12, Type = (int)TaskType.Bool, Value = "false" },
                new TaskItem { Id = 41, Label = "Assigned Physicist", TaskGroupId = 12, Type = (int)TaskType.Text, Value = "No one" },
                new TaskItem { Id = 42, Label = "Mass Volume", TaskGroupId = 12, Type = (int)TaskType.Number, Value = "12.55" },
                new TaskItem { Id = 43, Label = "Assigned RO", TaskGroupId = 13, Type = (int)TaskType.Text, Value = "No one" },
                new TaskItem { Id = 44, Label = "Approved by RO", TaskGroupId = 13, Type = (int)TaskType.Bool, Value = "false" },
                new TaskItem { Id = 45, Label = "Mass Volume", TaskGroupId = 13, Type = (int)TaskType.Number, Value = "150.0" },
                new TaskItem { Id = 46, Label = "Patient Status", TaskGroupId = 13, Type = (int)TaskType.List, Value = "2,Waiting,Assigned,Treating,Finished" },
                new TaskItem { Id = 47, Label = "Approved by RO", TaskGroupId = 14, Type = (int)TaskType.Bool, Value = "false" },
                new TaskItem { Id = 48, Label = "Assigned Physicist", TaskGroupId = 14, Type = (int)TaskType.Text, Value = "No one" },
                new TaskItem { Id = 49, Label = "Mass Volume", TaskGroupId = 14, Type = (int)TaskType.Number, Value = "1.26" });

            modelBuilder.Entity<TaskGroup>().HasData(
                new TaskGroup { PatientId = 1, Id = 1, Label = "Standard" },
                new TaskGroup { PatientId = 1, Id = 2, Label = "Physics Checks" },
                new TaskGroup { PatientId = 2, Id = 3, Label = "Standard" },
                new TaskGroup { PatientId = 2, Id = 4, Label = "Physics Checks" },
                new TaskGroup { PatientId = 3, Id = 5, Label = "Standard" },
                new TaskGroup { PatientId = 3, Id = 6, Label = "Physics Checks" },
                new TaskGroup { PatientId = 4, Id = 7, Label = "Standard" },
                new TaskGroup { PatientId = 4, Id = 8, Label = "Physics Checks" },
                new TaskGroup { PatientId = 5, Id = 9, Label = "Standard" },
                new TaskGroup { PatientId = 5, Id = 10, Label = "Physics Checks" },
                new TaskGroup { PatientId = 6, Id = 11, Label = "Standard" },
                new TaskGroup { PatientId = 6, Id = 12, Label = "Physics Checks" },
                new TaskGroup { PatientId = 7, Id = 13, Label = "Standard" },
                new TaskGroup { PatientId = 7, Id = 14, Label = "Physics Checks" }

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
        public DbSet<TaskItem> Tasks { get; set; }
    }
}
