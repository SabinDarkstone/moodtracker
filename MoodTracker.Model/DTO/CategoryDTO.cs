using MoodTracker.Model.Base;
using MoodTracker.Model.Base.Interfaces;
using MoodTracker.Model.Interfaces;

namespace MoodTracker.Model.DTO {

    public class CategoryDTO : BaseDTO, INamed, IDto<Category> {

        public string Name { get; set; }
        public List<string> ActivityNames { get; set; }

        public CategoryDTO(Category category) : base(category) {
            this.Name = category.Name;
            this.ActivityNames = category.Activities
                .Select(a => a.Name)
                .ToList();
        }

        public CategoryDTO() : base() {
            this.Name = "Default";
            this.ActivityNames = new List<string>();
        }

        public Category ToEntity() {
            throw new NotImplementedException();
        }
    }
}
