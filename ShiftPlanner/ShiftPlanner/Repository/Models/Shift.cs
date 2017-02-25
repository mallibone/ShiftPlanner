using System;
using ShiftPlanner.Models;
using SQLite;

namespace ShiftPlanner
{
    internal class Shift
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public ShiftType ShiftType { get; set; }
    }
}
