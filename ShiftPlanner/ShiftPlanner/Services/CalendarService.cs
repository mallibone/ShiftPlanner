using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Plugin.Calendars.Abstractions;
using ShiftPlanner.Repository;

namespace ShiftPlanner.Services
{
    class CalendarService
    {
        private readonly ICalendars _crossCalender;
        private readonly CalendarRepository _repository;

        public CalendarService(ICalendars crossCalendar, CalendarRepository repository)
        {
            _crossCalender = crossCalendar;
            _repository = repository;
        }
        public async Task<IEnumerable<Calendar>> GetSystemCalendars()
        {
            var calendars = await _crossCalender.GetCalendarsAsync();
            return calendars.Where(c => c.CanEditEvents).ToList();
        }

        public async Task StoreCurrentCalendar(Calendar calendar)
        {
            if (calendar == null) throw new ArgumentNullException(nameof(calendar));

            CurrentCalender = calendar;
            await _repository.SetCurrentCalendar(calendar);
        }

        private Calendar CurrentCalender { get; set; }

        public async Task<Calendar> GetCurrentCalendar()
        {
            await Task.FromResult(string.Empty);

            return CurrentCalender;
        }
    }
}
