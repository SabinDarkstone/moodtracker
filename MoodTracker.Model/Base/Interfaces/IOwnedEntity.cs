using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Model.Base.Interfaces {
    public interface IOwnedEntity {
        public User CreatedBy { get; set; }
        public long UserId { get; set; }
    }
}
