using System.Reflection;

namespace RealmDBSample.Core.Extensions
{
    public static class ReflectionExtensions
    {
        public static object GetPropertyValue(this object obj, string propertyName)
        {
            return obj.GetType().GetRuntimeProperty(propertyName).GetValue(obj);
        }

        public static bool ObjectsEqual(this object value1, object value2)
        {
            return value1 == null && value2 == null || value1 != null && value2 != null && value1.Equals(value2);
        }
    }
}