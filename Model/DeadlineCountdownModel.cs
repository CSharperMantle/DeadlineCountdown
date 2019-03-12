using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadlineCountdown.Model
{
    class DeadlineCountdownModel
    {
        private DateTime _startTime;
        private DateTime _deadlineTime;

        public TimeSpan TimeSpanToDeadline { get => _deadlineTime - DateTime.Now; }
        public TimeSpan TimeSpanFromStart { get => DateTime.Now - _startTime; }

        public DeadlineCountdownModel(DateTime deadline)
        {
            _startTime = DateTime.Now;
            _deadlineTime = deadline;
        }
    }
}
