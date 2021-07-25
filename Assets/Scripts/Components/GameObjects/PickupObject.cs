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
            var value = GetDataValue();
            if (value == null)
                SetDataValue(m_isActive);
            else
                m_isActive = (bool) value;
         
            var o = gameObject;
            m_gameObject ??= o;
            m_gameObject.SetActive(m_isActive);
        }

        public void PickUp()
        {
            m_isActive = false;
            SetDataValue(m_isActive);
            
            m_gameObject.SetActive(false);
        }
    }
}