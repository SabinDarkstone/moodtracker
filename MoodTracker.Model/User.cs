using MoodTracker.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Model {
    public class User : TimestampEntity {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public User() : base() { }
    }
}
