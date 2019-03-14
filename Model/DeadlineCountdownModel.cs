using System;

namespace DeadlineCountdown.Model
{
    class DeadlineCountdownModel
    {
        public const int ALERT_DAYS_TO_DEADLINE = 5;
        public const int WARNING_DAYS_TO_DEADLINE = 10;

        private DateTime _startTime;
        private DateTime _deadlineTime;
        private static readonly DateTime _defaultDeadline = new DateTime(2019, 3, 29, 12, 0, 0);

        public TimeSpan TimeSpanToDeadline { get => _deadlineTime - DateTime.Now; }
        public TimeSpan TimeSpanFromStart { get => DateTime.Now - _startTime; }

        public DeadlineCountdownModel(DateTime? deadline = null)
        {
            _startTime = DateTime.Now;
            _deadlineTime = deadline ?? _defaultDeadline;
        }
    }
}
