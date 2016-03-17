using Newtonsoft.Json;

namespace Excel2Mysql.util
{
    public static class Json
    {
        public static T parse<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static string stringify(object jsonObject)
        {
            return JsonConvert.SerializeObject(jsonObject);
        }
    }
}
