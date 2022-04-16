using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoodTracker.Model.Junction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Model.Data.Configure {
    internal class MoodEntityTypeConfiguration : IEntityTypeConfiguration<Mood> {

        public void Configure(EntityTypeBuilder<Mood> builder) {
            // Define the table
            builder
                .ToTable("Moods")
                .HasKey(m => m.Id);

            // Set up soft delete query filter
            builder.HasQueryFilter(m => m.IsDeleted == false);

            // Set required fields
            builder.Property(m => m.Name).IsRequired();
            builder.Property(m => m.MoodType).IsRequired();

            // Set up type conversions
            builder.Property(m => m.MoodType)
                .HasConversion(
                    v => v.ToString(),
                    v => (MoodType)Enum.Parse(typeof(MoodType), v));

            // Set up relationships
            builder
                .HasMany(m => m.JournalEntries)
                .WithMany(m => m.Moods)
                .UsingEntity<JournalEntryMood>(
                    jm => jm
                        .HasOne(x => x.JournalEntry)
                        .WithMany(x => x.JournalEntryMoods)
                        .HasForeignKey(x => x.JournalEntryId),
                    jm => jm
                        .HasOne(x => x.Mood)
                        .WithMany(x => x.JournalEntryMoods)
                        .HasForeignKey(x => x.MoodId),

                    // Define JournalEntryMoods table
                    jm => {
                        jm.ToTable("JournalEntryMoods")
                            .HasKey(x => x.Id);
                        jm.HasAlternateKey(x => new {
                            x.JournalEntryId,
                            x.MoodId
                        });
                        jm.HasQueryFilter(x => x.IsDeleted == false);
                    }
                );
        }
    }
}
