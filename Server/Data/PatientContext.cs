using Radigate.Server.Models;

namespace Radigate.Server.Data {
    public class PatientContext : DbContext {
        public PatientContext(DbContextOptions options) : base(options) {
        }

        public DbSet<PatientModel> Patients { get; set; }
        public DbSet<TaskGroupModel> TaskGroups { get; set; }
        public DbSet<TaskItemModel> TaskItems { get; set; }


    }
}
