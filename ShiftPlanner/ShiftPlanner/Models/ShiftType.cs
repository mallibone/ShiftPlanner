namespace ShiftPlanner.Models
{
    internal class ShiftType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}