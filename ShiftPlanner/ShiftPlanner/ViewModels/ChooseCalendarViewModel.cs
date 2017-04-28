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
using ShiftPlanner.Views;

namespace ShiftPlanner.ViewModels
{
    class ChooseCalendarViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private Calendar _selectedCalendar;

        public ChooseCalendarViewModel(INavigationService navigationService)
        {
            if (navigationService == null) throw new ArgumentNullException(nameof(navigationService));

            _navigationService = navigationService;
            SelectCalendarCommand = new RelayCommand(CalendarSelected, () => SelectedCalendar != null);
        }

        private void CalendarSelected()
        {
            _navigationService.NavigateTo(nameof(MainPage), SelectedCalendar);
        }

        public ObservableCollection<Calendar> Calendars { get; } = new ObservableCollection<Calendar>();

        public ICommand SelectCalendarCommand { get; set; }

        public Calendar SelectedCalendar
        {
            get { return _selectedCalendar; }
            set
            {
                if (value == _selectedCalendar) return;
                _selectedCalendar = value;
                RaisePropertyChanged(nameof(SelectedCalendar));
            }
        }

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
