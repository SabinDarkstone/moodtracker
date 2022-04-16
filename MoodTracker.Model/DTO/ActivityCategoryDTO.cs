using MoodTracker.Model.Base.Interfaces;

namespace MoodTracker.Model.DTO {
    
    public class ActivityCategoryDTO : TimestampDTO, IDto<ActivityCategory> {

        public string Name { get; set; }

        public List<string>? ActivityNames { get; set; } = null;

        public ActivityCategoryDTO() : base() {
            this.Name = "Default";
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
