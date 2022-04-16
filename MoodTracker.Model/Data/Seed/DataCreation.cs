using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Model.Data.Seed {
    public class DataCreation {

        public static void Initialize(IServiceProvider serviceProvider) {
            using (var context = new MoodContext(
                serviceProvider.GetRequiredService<DbContextOptions<MoodContext>>(),
                serviceProvider.GetRequiredService<ILogger<MoodContext>>())) {

                // TODO: Add seed data

                context.SaveChanges();
            }
        }
    }
}
