using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Calendars.Abstractions;
using ShiftPlanner.Repository.Models.Calendar;
using ShiftPlanner.Utils;
using SQLite;

namespace ShiftPlanner.Repository
{
    class CalendarRepository
    {
        public async Task SetCurrentCalendar(Calendar calendar)
        {
            var conn = new SQLiteAsyncConnection(Constants.Repository.CalendarDbName);
            await conn.CreateTableAsync<CalendarDb>();

            // todo: store the item

            return;
        }
    }
}
