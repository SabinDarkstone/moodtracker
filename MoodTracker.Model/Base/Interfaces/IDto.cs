using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Model.Base.Interfaces {
    public interface IDto<TEntity> {

        public long Id { get; set; }

        public TEntity ToEntity();
    }
}
