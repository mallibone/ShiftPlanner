using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using ShiftPlanner.Models;
using ShiftPlanner.Services;
using ShiftPlanner.Utils;

namespace ShiftPlanner.ViewModels
{
    class MainViewModel:ViewModelBase
    {
        private readonly ShiftService _shiftService;
        private readonly INavigationService _navigationService;
        private IEnumerable<DayViewModel> _days;
        private DateTime _offsetDate;

        public MainViewModel(ShiftService shiftService, INavigationService navigationService)
        {
            if (shiftService == null) throw new ArgumentNullException(nameof(shiftService));
            if (navigationService == null) throw new ArgumentNullException(nameof(navigationService));

            _shiftService = shiftService;
            _navigationService = navigationService;

            _offsetDate = DateTime.Today;
            Days = StubInit();
        }

        private IEnumerable<DayViewModel> StubInit()
        {
            var daysInCurrentMonth = DateTime.DaysInMonth(_offsetDate.Year, _offsetDate.Month);
            var daysInMonth = new DayViewModel[daysInCurrentMonth];

            for (int i = 0; i < daysInCurrentMonth; ++i)
            {
                daysInMonth[i] = new DayViewModel
                {
                    Date = new DateTime(_offsetDate.Year, _offsetDate.Month, i + 1),
                    SelectedShiftType = _shiftService.DefaultShift,
                };
            }

            return daysInMonth;
        }

        public string DisplayedMonth => _offsetDate.ToString("MMMM yyyy");

        public IEnumerable<DayViewModel> Days
        {
            get
            {
                return _days;
            }
            set
            {
                if (value == _days) return;
                _days = value;
                if(_days != null) RaisePropertyChanged(nameof(Days));
            }
        }

        public IEnumerable<ShiftType> AvailableShiftTypes()
        {
            return _shiftService.GetShiftTypes();
        }

        public void ItemSelected(DayViewModel selectedItem)
        {
            _navigationService.NavigateTo(PageNavigationConstants.ShiftDetailPage);
        }
    }
}
