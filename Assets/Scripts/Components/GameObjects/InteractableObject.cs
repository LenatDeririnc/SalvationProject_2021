using System;
using Managers.Data;
using ScriptableObjects.Scenes;
using UnityEngine;
using UnityEngine.Events;

namespace Components.GameObjects
{
    [Serializable]
    public class InteractEvent : UnityEvent
    { }

    public class InteractableObject : MonoBehaviourDataRecorder
    {
        [SerializeField] private bool canInteract = true;
        
        public InteractEvent OnInteract;

        public void Interact()
        {
            OnInteract.Invoke();
        }

        public void Start()
        {
            var value = GetDataValue();
            if (value == null)
            {
                SetDataValue(canInteract);
            }
            else
            {
                canInteract = (bool)value;
            }
        }
        
        public bool CanInteract() => canInteract;

        public void SetCanInteract(bool state)
        {
            canInteract = state;
            SetDataValue(canInteract);
        }
    }   
}
