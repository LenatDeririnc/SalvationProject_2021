using UnityEngine;

namespace Helpers
{
    public static class Vector2Helper
    {
        public static Vector2 Vector2Pow(Vector2 vector2, int pow)
        {
            Vector2 resultVector = vector2;
            
            for (int i = 1; i < pow; ++i)
            {
                resultVector *= vector2;
            }

            return resultVector;
        }
    }
}