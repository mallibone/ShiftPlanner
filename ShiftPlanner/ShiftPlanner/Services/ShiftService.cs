using System;
using System.Collections.Generic;
using System.Linq;
using ShiftPlanner.Models;
using ShiftPlanner.Utils;
using ShiftPlanner.ViewModels;

namespace ShiftPlanner.Services
{
    class ShiftService
    {
        private readonly IRepository _repository;
        private ICollection<ShiftType> _shiftTypes;

        public ShiftService(IRepository repository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            _repository = repository;

            _shiftTypes = new List<ShiftType>
            {
                new ShiftType {Id = 0, Name = "Day Off" },
                new ShiftType {Id = 1, Name = "Early Shift" },
                new ShiftType {Id = 2, Name = "Late Shift" },
                new ShiftType {Id = 3, Name = "Night Shift" },
            };
        }

        public ShiftType DefaultShift => _shiftTypes.ElementAt(index: 0);

        public IEnumerable<ShiftType> GetShiftTypes()
        {
            return _shiftTypes.Clone();
        }

        public IEnumerable<DayViewModel> GetMonth(DateTime monthRequested)
        {
            IEnumerable<Shift> monthShifts = _repository.GetShiftsForMonth(monthRequested);
            return monthShifts.Any() ? monthShifts.Select(m => new DayViewModel(m)).ToList() : StubInit(monthRequested);
        }
        private IEnumerable<DayViewModel> StubInit(DateTime offsetDate)
        {
            var daysInCurrentMonth = DateTime.DaysInMonth(offsetDate.Year, offsetDate.Month);
            var daysInMonth = new DayViewModel[daysInCurrentMonth];

            for (int i = 0; i < daysInCurrentMonth; ++i)
            {
                daysInMonth[i] = new DayViewModel
                {
                    Date = new DateTime(offsetDate.Year, offsetDate.Month, i + 1),
                    SelectedShiftType = DefaultShift,
                };
            }

            return daysInMonth;
        }
    }

    internal interface IRepository
    {
        IEnumerable<Shift> GetShiftsForMonth(DateTime monthRequested);
    }

    internal class Shift
    {
        public int Id { get; set; }
        public DateTime DateChanged { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime Date { get; set; }
        public ShiftType SelectedShiftType { get; set; }
    }

    internal class StubRepository:IRepository
    {
        public IEnumerable<Shift> GetShiftsForMonth(DateTime monthRequested)
        {
            throw new NotImplementedException();
        }
    }
}
