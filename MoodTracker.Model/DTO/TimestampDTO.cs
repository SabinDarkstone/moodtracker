using MoodTracker.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Model.DTO {
    public abstract class TimestampDTO : BaseDTO {

        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public TimestampDTO() : base() {
            this.CreatedDate = DateTime.Now;
            this.LastModifiedDate = DateTime.Now;
        }

        public TimestampDTO(TimestampEntity timestamp) : base(timestamp) {
            this.CreatedDate = timestamp.CreatedDate;
            this.LastModifiedDate = timestamp.LastModifedDate;
        }
    }
}
