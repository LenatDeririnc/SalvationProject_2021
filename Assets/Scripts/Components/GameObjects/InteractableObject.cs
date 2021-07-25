using System;
using Managers.Data;
using UnityEngine;
using UnityEngine.Events;

namespace Components.GameObjects
{
    [Serializable]
    public class InteractEvent : UnityEvent
    { }

    public class InteractableObject : MonoBehaviourDataRecorder
    {
        private string m_canInteractName = "canInteract";
        [SerializeField] private bool canInteract = true;
        
        public InteractEvent OnInteract;

        public void Interact()
        {
            OnInteract.Invoke();
        }

        public void Start()
        {
            var value = GetDataValue($"{gameObject.name}_{m_canInteractName}");
            if (value == null)
            {
                SetDataValue($"{gameObject.name}_{m_canInteractName}", canInteract);
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
            SetDataValue($"{gameObject.name}_{m_canInteractName}", state);
        }
    }   
}
