using System;
using UnityEngine;
using UnityEngine.Events;

namespace Components.GameObjects
{
    [Serializable]
    public class ColliderEvent : UnityEvent
    { }

    public class ColliderObject : MonoBehaviourDataRecorder
    {
        [SerializeField] private bool m_doNotHideObject = false;
        [SerializeField] private bool m_canInteract = true;

        [SerializeField] private LayerMask m_objectMask = 0;

        public Action<Collision> SendComponent;

        private void Awake()
        {
            if (!m_doNotHideObject)
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

        public ColliderEvent OnEnter;
        public ColliderEvent OnStay;
        public ColliderEvent OnExit;

        private void CollisionAction(Collision other, ColliderEvent @event)
        {
            if (!CanInteract())
                return;

            if (@event == null)
                return;

            SendComponent?.Invoke(other);

            if (((1 << other.gameObject.layer) & m_objectMask) != 0)
                @event.Invoke();
        }

        private void OnCollisionEnter(Collision other)
        {
            CollisionAction(other, OnEnter);
        }

        private void OnCollisionExit(Collision other)
        {
            CollisionAction(other, OnExit);
        }

        private void OnCollisionStay(Collision other)
        {
            CollisionAction(other, OnStay);
        }

        private void HideRenderMesh()
        {
            var mesh = GetComponent<MeshRenderer>();
            mesh.enabled = false;
        }
    }
}