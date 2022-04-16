using MoodTracker.Model.Base;

namespace MoodTracker.Model {

    public class User : TimestampEntity {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public User() : base() {
            this.FirstName = "FirstName";
            this.LastName = "LastName";
            this.Email = "Emai@email.com";
        }
    }
}
