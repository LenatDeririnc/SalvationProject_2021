using UnityEngine;

namespace Helpers
{
    public static class CastObjectHelper
    {
        public enum Type
        {
            String,
            Int,
            Bool
        }

        public static object ConvertValue(Type castType, object obj)
        {
            string strObject = (string) obj;
            
            switch (castType)
            {
                case Type.String:
                    return (string) obj;
                case Type.Int:
                    int.TryParse(strObject, out var intValue);
                    return intValue;
                case Type.Bool:
                    bool.TryParse(strObject, out var boolValue);
                    return boolValue;
                default:
                    Debug.Assert(false, "unexpected type of convertation value");
                    return obj;
            }
        }
    }
}