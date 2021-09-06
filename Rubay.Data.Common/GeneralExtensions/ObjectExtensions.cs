using Newtonsoft.Json;

namespace Rubay.Data.Common.GeneralExtensions
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object obj) => JsonConvert.SerializeObject(obj);
        public static T ToObj<T>(this string json) => JsonConvert.DeserializeObject<T>(json);
    }
}
