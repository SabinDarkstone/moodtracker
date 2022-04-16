using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoodTracker.Model.Base;
using MoodTracker.Model.Data.Configure;
using MoodTracker.Model.Junction;

namespace MoodTracker.Model.Data {
    public class MoodContext : DbContext {

        private readonly ILogger<MoodContext> _logger;

        public DbSet<JournalEntry> JournalEntries { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Mood> Moods { get; set; } = null!;
        public DbSet<Activity> Activities { get; set; } = null!;
        public DbSet<ActivityCategory> ActivityCategories { get; set; } = null!;
        public DbSet<JournalEntryMood> JournalEntryMoods { get; set; } = null!;

        public MoodContext(DbContextOptions<MoodContext> options, ILogger<MoodContext> logger) : base(options) {
            _logger = logger;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            _logger.LogDebug("Defining model with fluent API...");

            _logger.LogInformation("Configuring User entity");
            new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());

            _logger.LogInformation("Configuring Mood entity");
            new MoodEntityTypeConfiguration().Configure(modelBuilder.Entity<Mood>());

            _logger.LogInformation("Configuring JournalEntry entity");
            new JournalEntryEntityTypeConfiguration().Configure(modelBuilder.Entity<JournalEntry>());

            _logger.LogInformation("Configuring Activity entity");
            new ActivityEntityTypeConfiguration().Configure(modelBuilder.Entity<Activity>());
        }

        private void UpdateFields() {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is TimestampEntity &&
                (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries) {
                ((TimestampEntity)entityEntry.Entity).LastModifedDate = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added) {
                    ((TimestampEntity)entityEntry.Entity).CreatedDate = DateTime.UtcNow;
                    ((BaseEntity)entityEntry.Entity).IsDeleted = false;
                }
            }
        }

        private void UpdateSoftDeletes() {
            foreach (var entityEntry in ChangeTracker.Entries()) {
                if (entityEntry.State == EntityState.Deleted) {
                    ((BaseEntity)entityEntry.Entity).IsDeleted = true;
                    entityEntry.State = EntityState.Modified;
                }
            }
        }

        public override int SaveChanges() {
            UpdateFields();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {
            UpdateFields();
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
