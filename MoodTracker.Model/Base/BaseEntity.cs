using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Model.Base {
    public abstract class BaseEntity {

        public long Id { get; set; }
        public string? Secret { get; set; }
        public bool IsDeleted { get; set; }

        public BaseEntity() {
            this.IsDeleted = false;
        }

        public BaseEntity(BaseDTO dto) {
            this.Id = dto.Id;
            this.IsDeleted = false;
        }
    }
}
