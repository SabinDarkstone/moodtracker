using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Model.Data.Configure {
    internal class JournalEntryEntityTypeConfiguration : IEntityTypeConfiguration<JournalEntry> {
        public void Configure(EntityTypeBuilder<JournalEntry> builder) {
            // Define the table
            builder
                .ToTable("JournalEntries")
                .HasKey(j => j.Id);

            // Set up soft delete query filter
            builder.HasQueryFilter(j => j.IsDeleted == false);

            // Set required fields
            builder.Property(j => j.Title).IsRequired();
            builder.Property(j => j.EntryDate).IsRequired();
        }
    }
}
