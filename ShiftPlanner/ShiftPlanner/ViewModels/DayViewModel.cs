using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ShiftPlanner.Models;

namespace ShiftPlanner.ViewModels
{
    class DayViewModel:ViewModelBase
    {
        private bool _freeShiftSelected;
        private bool _earlyShiftSelected;
        private bool _lateShiftSelected;
        private bool _nightShiftSelected;

        public DayViewModel()
        {
            FreeShiftCommand = new RelayCommand(FreeShiftCommandHandler);
            EarlyShiftCommand = new RelayCommand(EarlyShiftCommandHandler);
            LateShiftCommand = new RelayCommand(LateShiftCommandHandler);
            NightShiftCommand = new RelayCommand(NightShiftCommandHandler);
            FreeShiftSelected = true;
        }

        public DateTime Date { get; set; }
        public string WeekDay => Date.ToString("dd ddd");
        public ShiftType SelectedShiftType { get; set; }
        public string SelectedShiftTypeText => SelectedShiftType.ToString();

        public bool FreeShiftSelected
        {
            get { return _freeShiftSelected; }
            set
            {
                if (value == _freeShiftSelected) return;
                _freeShiftSelected = value;
                RaisePropertyChanged(nameof(FreeShiftSelected));
            }
        }

        public bool EarlyShiftSelected
        {
            get { return _earlyShiftSelected; }
            set
            {
                if(value == _earlyShiftSelected) return;
                _earlyShiftSelected = value;
                RaisePropertyChanged(nameof(EarlyShiftSelected));
            }
        }

        public bool LateShiftSelected
        {
            get { return _lateShiftSelected; }
            set
            {
                if (value == _lateShiftSelected) return;
                _lateShiftSelected = value;
                RaisePropertyChanged(nameof(LateShiftSelected));
            }
        }

        public bool NightShiftSelected
        {
            get { return _nightShiftSelected; }
            set
            {
                if (NightShiftSelected == value) return;
                _nightShiftSelected = value;
                RaisePropertyChanged(nameof(NightShiftSelected));
            }
        }

        public RelayCommand FreeShiftCommand { get; set; }
        public RelayCommand EarlyShiftCommand { get; set; }
        public RelayCommand LateShiftCommand { get; set; }
        public RelayCommand NightShiftCommand { get; set; }

        private void FreeShiftCommandHandler()
        {
            ClearAllSelections();
            FreeShiftSelected = true;
        }

        private void EarlyShiftCommandHandler()
        {
            ClearAllSelections();
            EarlyShiftSelected = true;
        }

        private void LateShiftCommandHandler()
        {
            ClearAllSelections();
            LateShiftSelected = true;
        }

        private void NightShiftCommandHandler()
        {
            ClearAllSelections();
            NightShiftSelected = true;
        }

        private void ClearAllSelections()
        {
            FreeShiftSelected = false;
            EarlyShiftSelected = false;
            LateShiftSelected = false;
            NightShiftSelected = false;
        }
    }
}