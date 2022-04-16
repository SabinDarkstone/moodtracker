using MoodTracker.Model.Base;
using MoodTracker.Model.Interfaces;
using MoodTracker.Model.Junction;

namespace MoodTracker.Model {
    public class Mood : BaseEntity, INamed {
        
        public string Name { get; set; }
        public MoodType MoodType { get; set; }

        public ICollection<JournalEntry>? JournalEntries { get; set; } = null;
        public List<JournalEntryMood>? JournalEntryMoods { get; set; } = null;

        public Mood() : base() {
            Name = "Default";
            MoodType = MoodType.NEUTRAL;
        }
    }
}
