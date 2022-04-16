using MoodTracker.Model.Base;
using MoodTracker.Model.Junction;

namespace MoodTracker.Model {
    
    public class JournalEntry : TimestampEntity {

        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime EntryDate { get; set; }

        public ICollection<Mood> Moods { get; set; } = new List<Mood>();
        public List<JournalEntryMood> JournalEntryMoods { get; set; } = new List<JournalEntryMood>();

        public JournalEntry() : base() {
            this.EntryDate = DateTime.Now;
            this.Title = "Default";
            this.Content = "No Content";
        }
    }
}
