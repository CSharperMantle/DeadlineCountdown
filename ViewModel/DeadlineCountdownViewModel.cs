using DeadlineCountdown.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DeadlineCountdown.ViewModel
{
    public class DeadlineCountdownViewModel : INotifyPropertyChanged
    {
        private readonly DeadlineCountdownModel _model;

        private readonly DispatcherTimer _timer = new DispatcherTimer();

        private static readonly DateTime DEFAULT_DEADLINE = new DateTime(2019, 3, 29, 12, 0, 0);

        public DeadlineCountdownViewModel(DateTime? deadline = null)
        {
            _model = new DeadlineCountdownModel(deadline ?? DEFAULT_DEADLINE);
            SetupTimer();
        }

        public DeadlineCountdownViewModel()
        {
            _model = new DeadlineCountdownModel(DEFAULT_DEADLINE);
            SetupTimer();
        }

        public TimeSpan TimeSpanToDeadline { get => _model.TimeSpanToDeadline; }

        public int DaysToDeadline { get => _model.TimeSpanToDeadline.Days; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void TimerTickEventHandler(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(TimeSpanToDeadline));
        }

        private void SetupTimer()
        {
            _timer.Interval = TimeSpan.FromMilliseconds(500);
            _timer.Tick += TimerTickEventHandler;
            _timer.Start();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
