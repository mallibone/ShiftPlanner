using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using ShiftPlanner.Utils;
using SQLite;

namespace ShiftPlanner
{
    internal class ShiftRepository
    {
        public ShiftRepository()
        {
        }

        public async Task<IEnumerable<Shift>> GetShiftsForMonthInYear(DateTime monthAndYear)
        {
            var conn = GetAsyncSQLiteConnection(monthAndYear);

            var query =  conn.Table<Shift>().Where(s => s.Date.Month == monthAndYear.Month);

            List<Shift> result = await query.ToListAsync();

            return (IEnumerable<Shift>)result.Clone();
        }

        public async Task StoreShift(Shift shift)
        {
            if (shift == null) throw new ArgumentNullException(nameof(shift));

            var conn = GetAsyncSQLiteConnection(shift.Date);

            await conn.InsertAsync(shift);
        }

        private SQLiteAsyncConnection GetAsyncSQLiteConnection(DateTime currentYear)
        {
            var conn = new SQLiteAsyncConnection(string.Format(Constants.Repository.DbNameTemplate, currentYear.Year));
            return conn;
        }
    }
}
