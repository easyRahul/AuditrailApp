using System.Text.Json;

namespace AuditTrail.Services
{
    public static class JsonElementExtensions
    {
        public static Dictionary<string, JsonElement> ToDictionary(this JsonElement element)
        {
            var dict = new Dictionary<string, JsonElement>();
            if (element.ValueKind != JsonValueKind.Object)
                return dict;

            foreach (var prop in element.EnumerateObject())
            {
                dict[prop.Name] = prop.Value;
            }
            return dict;
        }
    }
}
