namespace Radigate.Server.Users.Data {
    public class UsersContext : DbContext {
        protected readonly IConfiguration Configuration;

        public UsersContext(IConfiguration configuration) {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("SQLLiteConnection"));
        }

        public DbSet<User> Users { get; set; }
    }
}
