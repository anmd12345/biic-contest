using Newtonsoft.Json;

namespace BIIC_Contest.Helpers
{
    public class JsonHelper
    {
        public static string ConfiguratingJson<T>(T obj)
        {
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            return JsonConvert.SerializeObject(obj, settings);
        }

    }
}