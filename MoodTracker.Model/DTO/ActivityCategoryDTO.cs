using MoodTracker.Model.Base;
using MoodTracker.Model.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Model.DTO {
    public class ActivityCategoryDTO : TimestampDTO, IDto<ActivityCategory> {

        public string Name { get; set; }

        public List<string>? ActivityNames { get; set; }

        public ActivityCategoryDTO() {

        }

        public ActivityCategoryDTO(ActivityCategory category) : base(category) {
            this.Name = category.Name;
            this.ActivityNames = category.Activities
                .Select(x => x.Name)
                .ToList();
        }
        
        public ActivityCategory ToEntity() {
            return new ActivityCategory(this);
        }
    }
}
