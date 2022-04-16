using MoodTracker.Model.Base;
using MoodTracker.Model.Base.Interfaces;

namespace MoodTracker.Model.Junction {
    
    public class JournalEntryMood : BaseEntity, IJunctionEntity<JournalEntry, Mood> {

        public JournalEntry JournalEntry { get; set; }
        public long JournalEntryId { get; set; }
        public Mood Mood { get; set; }
        public long MoodId { get; set; }
        public float Percent { get; set; }

        public JournalEntryMood() : base() {
            this.Mood = new Mood();
            this.MoodId = -1;
            this.JournalEntry = new JournalEntry();
            this.JournalEntryId = -1;
            this.Percent = 0.5f;
        }
    }
}
