using MoodTracker.Model.Base;
using MoodTracker.Model.Base.Interfaces;
using MoodTracker.Model.DTO;

namespace MoodTracker.Model {
    
    public class Activity : TimestampEntity, IEntity<ActivityDTO> {
        public string Name { get; set; }
        public Category? Category { get; set; }
        public long ActivityCategoryId { get; set; }
        public DateTime Date { get; set; }

        public Activity() : base() {
            this.Name = "Default";
            this.Category = null;
            this.ActivityCategoryId = -1;
            this.Date = DateTime.Now;
        }

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
