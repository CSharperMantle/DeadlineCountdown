using System;

namespace DeadlineCountdown.Model
{
    class DeadlineCountdownModel
    {
        private DateTime _startTime;
        private DateTime _deadlineTime;
        private static readonly DateTime DEFAULT_DEADLINE = new DateTime(2019, 3, 29, 12, 0, 0);

        public TimeSpan TimeSpanToDeadline { get => _deadlineTime - DateTime.Now; }
        public TimeSpan TimeSpanFromStart { get => DateTime.Now - _startTime; }

        public DeadlineCountdownModel(DateTime? deadline = null)
        {
            _startTime = DateTime.Now;
            _deadlineTime = deadline ?? DEFAULT_DEADLINE;
        }
    }
}
