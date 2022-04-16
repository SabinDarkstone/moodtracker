using MoodTracker.Model.Base;
using MoodTracker.Model.Base.Interfaces;
using MoodTracker.Model.DTO;
using MoodTracker.Model.Interfaces;

namespace MoodTracker.Model {
    public class ActivityCategory : TimestampEntity, INamedEntity, IEntity<ActivityCategoryDTO> {
        public string Name { get; set; }

        public ICollection<Activity> Activities { get; set; } =
            new List<Activity>();

        public ActivityCategory() : base() { }

        public ActivityCategory(ActivityCategoryDTO category) : base(category) {
            this.Name = category.Name;
        }

        public ActivityCategoryDTO ToDTO() {
            return new ActivityCategoryDTO(this);
        }
    }
}