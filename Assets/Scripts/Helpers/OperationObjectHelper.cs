using ScriptableObjects.Scenes;
using UnityEngine;

namespace Helpers
{
    public static class OperationObjectHelper
    {
        public enum OperationType
        {
            Set,
            Increase,
            Degrease
        }
        
        public static void SetOperation(OperationType operationType, ref GameObjectDataHolder holder, object obj)
        {
            switch (operationType)
            {
                case OperationType.Set:
                {
                    holder.SetObjectValue(obj);
                    return;
                }

                case OperationType.Increase:
                {
                    object oldValue = holder.Value() ?? 0;
                    oldValue = (int) oldValue + (int) obj;
                    holder.SetObjectValue(oldValue);
                    return;
                }
                
                case OperationType.Degrease:
                {
                    object oldValue = holder.Value() ?? 0;
                    oldValue = (int) oldValue - (int) obj;
                    holder.SetObjectValue(oldValue);
                    return;
                }

                default:
                    Debug.Assert(false, "unexpected type of convertation value");
                    return;
                
            }
        }
    }
}