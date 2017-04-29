using SQLite;

namespace ShiftPlanner.Repository.Models.Calendar
{
    class CalendarDb
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }

        public string ExternalID { get; set; }

        public bool CanEditCalendar { get; set; }

        public string Color { get; set; }

        public string AccountName { get; set; }

        public bool CanEditEvents { get; set; }

        public CalendarUsage CalendarUsage { get; set; }
    }
}
