using MoodTracker.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Model.Base {
    public abstract class TimestampEntity : BaseEntity {

        public DateTime CreatedDate { get; set; }
        public DateTime LastModifedDate { get; set; }

        public TimestampEntity() : base() {
            
        }

        public TimestampEntity(TimestampDTO timestamp) : base(timestamp) {
            this.CreatedDate = timestamp.CreatedDate;
            this.LastModifedDate = timestamp.LastModifiedDate;
        }
    }
}
