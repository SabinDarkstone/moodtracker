using Microsoft.Extensions.Logging;
using MoodTracker.Model.Base;
using MoodTracker.Model.Junction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Model {
    public class JournalEntry : TimestampEntity {

        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime EntryDate { get; set; }

        public ICollection<Mood> Moods { get; set; }
        public List<JournalEntryMood> JournalEntryMoods { get; set; }

        public JournalEntry() : base() {
            this.EntryDate = DateTime.Now;
        }
    }
}
