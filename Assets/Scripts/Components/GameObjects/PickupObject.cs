using System;
using UnityEngine;

namespace Components.GameObjects
{
    public class PickupObject : MonoBehaviourDataRecorder
    {
        private GameObject m_gameObject;
        private bool m_isActive = true;

        public void Start()
        {
            m_isActive = GetDataValue(m_isActive);
            
            m_gameObject ??= gameObject;
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