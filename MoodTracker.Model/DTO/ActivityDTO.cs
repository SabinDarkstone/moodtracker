using MoodTracker.Model.Base;
using MoodTracker.Model.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Model.DTO {
    public class ActivityDTO : TimestampDTO, IDto<Activity> {

        public string Name { get; set; }
        public string? CategoryName { get; set; }
        public long CategoryId { get; set; }
        public DateTime Date { get; set; }

        public ActivityDTO() : base() { }

        public ActivityDTO(Activity activity) : base(activity) {
            this.Name = activity.Name;
            if (activity.Category != null) {
                this.CategoryName = activity.Category.Name;
            }
            this.CategoryId = activity.ActivityCategoryId;
            this.Date = activity.Date;
        }

        public Activity ToEntity() {
            return new Activity(this);
        }
    }
}
