using MoodTracker.Model.Base;
using MoodTracker.Model.Base.Interfaces;
using MoodTracker.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Model {
    public class Activity : TimestampEntity, IEntity<ActivityDTO> {
        public string Name { get; set; }
        public ActivityCategory? Category { get; set; }
        public long ActivityCategoryId { get; set; }
        public DateTime Date { get; set; }

        public Activity() : base() { }

        public Activity(ActivityDTO activity) : base(activity) {
            this.Name = activity.Name;
            this.ActivityCategoryId = activity.CategoryId;
            this.Date = activity.Date;
        }

        public ActivityDTO ToDTO() {
            return new ActivityDTO(this);
        }
    }
}
