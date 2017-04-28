using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShiftPlanner.Repository.Models;
using ShiftPlanner.Services;
using ShiftPlanner.Utils;
using SQLite;

namespace ShiftPlanner.Repository
{
    internal class ShiftRepository : IRepository
    {
        public async Task<IEnumerable<Shift>> GetShiftsForMonthInYear(DateTime monthAndYear)
        {
            var conn = GetAsyncSQLiteConnection(monthAndYear);

            var query =  conn.Table<ShiftDb>().Where(s => s.Date.Month == monthAndYear.Month);

            List<ShiftDb> result = await query.ToListAsync();

            return result.Clone().Select(s => new Shift());
        }

        public async Task StoreShift(Shift shift)
        {
            if (shift == null) throw new ArgumentNullException(nameof(shift));

            var shiftDb = new ShiftDb(shift);

            var conn = GetAsyncSQLiteConnection(shiftDb.Date);

            await conn.InsertAsync(shiftDb);
        }

        private SQLiteAsyncConnection GetAsyncSQLiteConnection(DateTime currentYear)
        {
            var conn = new SQLiteAsyncConnection(string.Format(Constants.Repository.DbNameTemplate, currentYear.Year));
            return conn;
        }
    }
}
