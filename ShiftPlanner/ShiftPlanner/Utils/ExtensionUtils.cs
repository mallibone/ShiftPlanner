using Newtonsoft.Json;

namespace ShiftPlanner.Utils
{
    public static class ExtensionUtils
    {
        public static T Clone<T>(this T toBeCloned)
        {
            var cloneString = JsonConvert.SerializeObject(toBeCloned);
            return JsonConvert.DeserializeObject<T>(cloneString);
        }
    }
}