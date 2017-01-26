using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftPlanner.Models;
using ShiftPlanner.Utils;

namespace ShiftPlanner.Services
{
    class ShiftService
    {
        private ICollection<ShiftType> _shiftTypes;

        public ShiftService()
        {
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
    }
}
