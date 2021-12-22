using System.Text.Json;

namespace Enalyzer.ATM.Common.ExtensionMethods
{
    public static class StringExtensions
    {
        public static string AsJsonString(this object obj)
        {
            return JsonSerializer.Serialize(obj, new JsonSerializerOptions() { WriteIndented = true });
        }
    }
}