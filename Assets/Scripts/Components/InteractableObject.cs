using System;
using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    [Serializable]
    public class InteractEvent : UnityEvent
    { }

    public class InteractableObject : MonoBehaviour
    {
        public InteractEvent OnInteract;

        public void Interact()
        {
            OnInteract.Invoke();
        }
    }   
}
