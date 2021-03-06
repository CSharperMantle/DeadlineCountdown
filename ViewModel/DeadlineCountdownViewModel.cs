﻿using DeadlineCountdown.Model;
using System;
using System.ComponentModel;
using System.Windows.Threading;

namespace DeadlineCountdown.ViewModel
{
    public class DeadlineCountdownViewModel : INotifyPropertyChanged
    {
        private readonly DeadlineCountdownModel _model;

        private readonly DispatcherTimer _timer = new DispatcherTimer();

        private TimeSpan _lastUpdatedTimeSpan;

        private int _lastUpdatedDays;

        public DeadlineCountdownViewModel(DateTime? deadline = null)
        {
            _model = new DeadlineCountdownModel(deadline);
            SetupTimer();
        }

        public DeadlineCountdownViewModel()
        {
            _model = new DeadlineCountdownModel(null);
            SetupTimer();
        }

        public TimeSpan TimeSpanToDeadline { get => _model.TimeSpanToDeadline; }

        public int DaysToDeadline { get => _model.TimeSpanToDeadline.Days; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void TimerTickEventHandler(object sender, EventArgs e)
        {
            UpdateTimeSpanLazy();
            UpdateDaysLazy();
        }

        private void SetupTimer()
        {
            _timer.Interval = TimeSpan.FromMilliseconds(100);
            _timer.Tick += TimerTickEventHandler;
            _timer.Start();
        }

        private void UpdateTimeSpanLazy()
        {
            if (IsDeadlineTimeSpanChanged())
            {
                OnPropertyChanged(nameof(TimeSpanToDeadline));
                _lastUpdatedTimeSpan = TimeSpanToDeadline;
            }
        }

        private void UpdateDaysLazy()
        {
            if (IsDeadlineDaysChanged())
            {
                OnPropertyChanged(nameof(DaysToDeadline));
                _lastUpdatedDays = TimeSpanToDeadline.Days;
            }
        }

        private bool IsDeadlineTimeSpanChanged() =>
            _lastUpdatedTimeSpan.TotalSeconds != TimeSpanToDeadline.TotalSeconds;

        private bool IsDeadlineDaysChanged() =>
            _lastUpdatedDays != TimeSpanToDeadline.Days;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
