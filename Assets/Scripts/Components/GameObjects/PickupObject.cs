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
            var o = gameObject;
            m_gameObject ??= o;

            var value = GetDataValue($"{m_gameObject.name}_m_isActive");
            if (value == null)
                SetDataValue($"{m_gameObject.name}_m_isActive", m_isActive);
            else
                m_isActive = (bool) value;
            
            m_gameObject.SetActive(m_isActive);
        }

        public void PickUp()
        {
            m_isActive = false;
            SetDataValue($"{m_gameObject.name}_m_isActive", m_isActive);
            
            m_gameObject.SetActive(false);
        }
    }
}