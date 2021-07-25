using UnityEngine;

namespace Helpers
{
    public static class TransformHelper
    {
        public static void CopyTransform(ref Transform transform, Transform copyTransform)
        {
            transform.position = copyTransform.position;
            transform.rotation = copyTransform.rotation;
        }
    }
}