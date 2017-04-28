using System;
using ShiftPlanner.Models;
using ShiftPlanner.Services;
using SQLite;

namespace ShiftPlanner.Repository.Models
{
    internal class ShiftDb
    {
        public ShiftDb() { }

        public ShiftDb(Shift shift)
        {
            Date = shift.Date;
            ShiftType = shift.SelectedShiftType;
        }

        public DateTime Date { get; set; }
        public ShiftType ShiftType { get; set; }
    }
}
