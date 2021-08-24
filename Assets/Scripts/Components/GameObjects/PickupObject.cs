using System;
using UnityEngine;

namespace Components.GameObjects
{
    public class PickupObject : MonoBehaviourDataRecorder
    {
        private GameObject m_gameObject;
        private bool m_isActive = true;

        [SerializeField] private GameObject m_objectToHide;

        public void Start()
        {
            m_isActive = GetDataValue(m_isActive);
            
            m_gameObject ??= gameObject;
            
            if (m_objectToHide != null)
                m_gameObject = m_objectToHide;
            
            m_gameObject.SetActive(m_isActive);
            
            SetDataValue(m_isActive);
        }

        public void PickUp()
        {
            m_isActive = false;
            SetDataValue(m_isActive);
            
            m_gameObject.SetActive(false);
        }
    }
}