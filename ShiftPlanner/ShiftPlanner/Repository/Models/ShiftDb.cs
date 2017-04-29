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

        public DateTime DateChanged { get; set; }
        public DateTime DateCreated { get; set; }
        [PrimaryKey]
        public DateTime Date { get; set; }
        public ShiftType ShiftType { get; set; }
    }
}
