using MoodTracker.Model.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Model.Base {
    public abstract class BaseDTO {

        public long Id { get; set; }

        public BaseDTO() { }
        
        public BaseDTO(BaseEntity entity) {
            this.Id = entity.Id;
        }
    }
}
