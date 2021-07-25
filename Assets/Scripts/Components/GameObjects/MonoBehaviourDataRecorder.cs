using Managers.Data;
using ScriptableObjects.Scenes;
using UnityEngine;

namespace Components.GameObjects
{
    public class MonoBehaviourDataRecorder : MonoBehaviour
    {
        [SerializeField] private GameObjectDataHolder dataHolder;
        
        protected void SetDataValue(object value)
        {
            Debug.Assert(dataHolder != null, $"dataHolder is not assigned for object {gameObject.name}");
            dataHolder.SetObjectValue(value);
        }

        protected object GetDataValue()
        {
            Debug.Assert(dataHolder != null, $"dataHolder is not assigned for object {gameObject.name}");
            return dataHolder.Value();
        }
    }
}