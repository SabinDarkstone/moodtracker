namespace MoodTracker.Model.Base {
    
    public abstract class BaseEntity {

        public long Id { get; set; }
        public string? Secret { get; set; }
        public bool IsDeleted { get; set; }

        public BaseEntity() {
            this.IsDeleted = false;
            this.Id = -1;
            this.Secret = "Secret";
        }

        public BaseEntity(BaseDTO dto) {
            this.Id = dto.Id;
            this.IsDeleted = false;
        }
    }
}
