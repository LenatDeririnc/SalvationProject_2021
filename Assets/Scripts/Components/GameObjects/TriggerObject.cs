using System;
using UnityEngine;
using UnityEngine.Events;

namespace Components.GameObjects
{
    [Serializable]
    public class TriggerEvent : UnityEvent
    { }
    
    public class TriggerObject : MonoBehaviourDataRecorder
    {
        [SerializeField] private bool canInteract = true;

        [SerializeField] private LayerMask objectMask;

        public bool CanInteract() => canInteract;
        
        public TriggerEvent OnEnter;

        public TriggerEvent OnStay;
        
        public TriggerEvent OnExit;

        private void TriggerAction(Collider other, TriggerEvent @event)
        {
            if (!CanInteract())
                return;
            
            if (((1 << other.gameObject.layer) & objectMask) != 0)
                @event.Invoke();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            TriggerAction(other, OnEnter);
        }

        private void OnTriggerExit(Collider other)
        {
            TriggerAction(other, OnExit);
        }

        private void OnTriggerStay(Collider other)
        {
            TriggerAction(other, OnStay);
        }

    }
}