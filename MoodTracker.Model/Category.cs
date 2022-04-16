using MoodTracker.Model.Base;
using MoodTracker.Model.Base.Interfaces;
using MoodTracker.Model.DTO;
using MoodTracker.Model.Interfaces;

namespace MoodTracker.Model {

    public class Category : BaseEntity, INamed, IEntity<CategoryDTO> {
        public string Name { get; set; }
        public HashSet<Activity> Activities { get; set; } = new HashSet<Activity>();

        public Category(CategoryDTO category) : base(category) {
            this.Name = category.Name;
        }

        public Category() : base() {
            this.Name = "Default";
        }

        public CategoryDTO ToDTO() {
            throw new NotImplementedException();
        }
    }
}