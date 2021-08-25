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
        [SerializeField] private bool m_canInteract = true;

        [SerializeField] private LayerMask m_objectMask = 0;

        public Action<Collider> SendComponent;

        private void Awake()
        {
            HideRenderMesh();
            SendComponent = null;
            m_canInteract = GetDataValue(m_canInteract);
        }

        public bool CanInteract() => m_canInteract;

        public void SetCanInteract(bool canInteract)
        {
            m_canInteract = canInteract;
            SetDataValue(m_canInteract);
        }
        
        public TriggerEvent OnEnter;
        public TriggerEvent OnStay;
        public TriggerEvent OnExit;

        private void TriggerAction(Collider other, TriggerEvent @event)
        {
            if (!CanInteract())
                return;
            
            if (@event == null)
                return;

            SendComponent?.Invoke(other);

            if (((1 << other.gameObject.layer) & m_objectMask) != 0)
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

        private void HideRenderMesh()
        {
            var mesh = GetComponent<MeshRenderer>();
            mesh.enabled = false;
        }

    }
}