namespace Radigate.Server.Templates.Data {
    public class TemplatesDataContext : DbContext {
        protected readonly IConfiguration Configuration;

        public TemplatesDataContext(IConfiguration configuration) {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("SQLLiteConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //https://learn.microsoft.com/en-us/archive/msdn-magazine/2018/august/data-points-deep-dive-into-ef-core-hasdata-seeding
            //https://learn.microsoft.com/en-us/ef/core/modeling/inheritance
            //https://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx
            //https://learn.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key
            //https://learn.microsoft.com/en-us/ef/core/modeling/relationships/many-to-many

            modelBuilder.Entity<PatientTemplate>()
                .HasMany(p => p.GroupTemplates)
                .WithMany(g => g.PatientTemplates);

        }


        public DbSet<PatientTemplate> PatientTemplates { get; set; }
        public DbSet<GroupTemplate> GroupTemplates { get; set; }

    }
}
