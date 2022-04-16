using MoodTracker.Model.Base;
using MoodTracker.Model.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Model.Junction {
    public class JournalEntryMood : BaseEntity, IJunctionEntity<JournalEntry, Mood> {

        public JournalEntry JournalEntry { get; set; }
        public long JournalEntryId { get; set; }
        public Mood Mood { get; set; }
        public long MoodId { get; set; }
        public float Percent { get; set; }

        public JournalEntryMood() : base() { }
    }
}
