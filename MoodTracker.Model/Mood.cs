using MoodTracker.Model.Base;
using MoodTracker.Model.Interfaces;
using MoodTracker.Model.Junction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Model {
    public class Mood : BaseEntity, INamedEntity {
        public string Name { get; set; }
        public MoodType MoodType { get; set; }

        public ICollection<JournalEntry> JournalEntries { get; set; }
        public List<JournalEntryMood> JournalEntryMoods { get; set; }

        public Mood() : base() {

        }
    }
}
