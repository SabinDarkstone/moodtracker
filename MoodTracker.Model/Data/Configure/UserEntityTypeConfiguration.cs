using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Model.Data.Configure {
    internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<User> {

        public void Configure(EntityTypeBuilder<User> builder) {
            // Define the table
            builder
                .ToTable("Users")
                .HasKey(u => u.Id);

            // Set up soft delete query filter
            builder.HasQueryFilter(u => u.IsDeleted == false);

            // Set required fields
            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.LastName).IsRequired();
        }
    }
}
