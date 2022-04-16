using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Model.Data.Configure {
    internal class ActivityEntityTypeConfiguration : IEntityTypeConfiguration<Activity> {
        public void Configure(EntityTypeBuilder<Activity> builder) {
            // Define the table
            builder
                .ToTable("Activities")
                .HasKey(a => a.Id);

            // Set up soft delete query filter
            builder.HasQueryFilter(a => a.IsDeleted == false);

            // Set required fields
            builder.Property(a => a.Name).IsRequired();

            // Set up relationships
            builder
                .HasOne(a => a.Category)
                .WithMany(c => c.Activities)
                .HasForeignKey(a => a.ActivityCategoryId);
        }
    }
}
