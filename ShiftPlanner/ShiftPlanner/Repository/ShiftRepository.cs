using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Shift>> GetShiftsForMonth(DateTime month)
        {
            var conn = new SQLiteAsyncConnection(string.Format(Constants.Repository.DbNameTemplate, month.Year));

            var query =  conn.Table<Shift>().Where(s => s.Date.Month == month.Month);

            List<Shift> result = await query.ToListAsync();

            return (IEnumerable<Shift>)result.Clone();
        }

        public async Task StoreShift(Shift shift)
        {
            if (shift == null) throw new ArgumentNullException(nameof(shift));

            throw new NotImplementedException();
        }
    }
}
