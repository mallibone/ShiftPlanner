using System;
using GalaSoft.MvvmLight;
using ShiftPlanner.Models;

namespace ShiftPlanner.ViewModels
{
    class DayViewModel:ViewModelBase
    {
        public DateTime Date { get; set; }
        public string WeekDay => Date.ToString("dd ddd");
        public ShiftType SelectedShiftType { get; set; }
        public string SelectedShiftTypeText => SelectedShiftType.ToString();
    }
}