using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Plugin.Calendars;
using Plugin.Calendars.Abstractions;
using ShiftPlanner.Services;
using ShiftPlanner.Views;

namespace ShiftPlanner.ViewModels
{
    class ChooseCalendarViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly CalendarService _calendarService;
        private Calendar _selectedCalendar;
        private bool _isBusy;

        public ChooseCalendarViewModel(INavigationService navigationService, CalendarService calendarService)
        {
            if (navigationService == null) throw new ArgumentNullException(nameof(navigationService));
            if (calendarService == null) throw new ArgumentNullException(nameof(calendarService));

            _navigationService = navigationService;
            _calendarService = calendarService;
            SelectCalendarCommand = new RelayCommand(CalendarSelected, () => HasSelectedCalendar && !IsBusy);
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if(value == _isBusy) return;
                _isBusy = value;
                RaisePropertyChanged(nameof(IsBusy));
            }
        }

        private async void CalendarSelected()
        {
            IsBusy = true;
            SelectCalendarCommand.RaiseCanExecuteChanged();

            await _calendarService.StoreCurrentCalendar(SelectedCalendar);
            _navigationService.NavigateTo(nameof(MainPage));

            IsBusy = false;
            SelectCalendarCommand.RaiseCanExecuteChanged();
        }

        public ObservableCollection<Calendar> Calendars { get; } = new ObservableCollection<Calendar>();

        public RelayCommand SelectCalendarCommand { get; set; }

        public Calendar SelectedCalendar
        {
            get { return _selectedCalendar; }
            set
            {
                if (value == _selectedCalendar) return;
                _selectedCalendar = value;
				HasSelectedCalendar = value != null;
                RaisePropertyChanged(nameof(SelectedCalendar));
				RaisePropertyChanged(nameof(HasSelectedCalendar));
                SelectCalendarCommand.RaiseCanExecuteChanged();
            }
        }

		public bool HasSelectedCalendar { get; set;}

        public async Task Init()
        {
            var calendars = (await CrossCalendars.Current.GetCalendarsAsync()).Where(c => c.CanEditEvents).ToList();
            Calendars.Clear();
            foreach (var calendar in calendars)
            {
                Calendars.Add(calendar);
            }
        }
    }
}
