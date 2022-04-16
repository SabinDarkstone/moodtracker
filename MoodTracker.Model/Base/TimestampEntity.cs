using MoodTracker.Model.DTO;

namespace MoodTracker.Model.Base {
    public abstract class TimestampEntity : BaseEntity {

        public DateTime CreatedDate { get; set; }
        public DateTime LastModifedDate { get; set; }

        public TimestampEntity() : base() {
            this.CreatedDate = DateTime.Now - TimeSpan.FromDays(1);
            this.LastModifedDate = DateTime.Now;
        }

        public TimestampEntity(TimestampDTO timestamp) : base(timestamp) {
            this.CreatedDate = timestamp.CreatedDate;
            this.LastModifedDate = timestamp.LastModifiedDate;
        }
    }
}
