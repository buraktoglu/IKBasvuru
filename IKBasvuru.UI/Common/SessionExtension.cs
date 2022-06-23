using Newtonsoft.Json;

namespace IKBasvuru.UI.Common
{
    public static class SessionExtension
    {
        public static void MySessionSet(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T? MySessionGet<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null
                ? default(T)
                : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
