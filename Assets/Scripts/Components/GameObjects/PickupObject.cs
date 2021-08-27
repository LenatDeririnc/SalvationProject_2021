using System;
using UnityEngine;

namespace Components.GameObjects
{
    public class PickupObject : MonoBehaviourDataRecorder
    {
        private GameObject m_gameObject;
        private bool m_isActive = true;

        [SerializeField] private bool m_reversed;
        [SerializeField] private GameObject m_objectToHide;

        public void Start()
        {
            var dataValue = GetDataValue();

            if (dataValue != null)
            {
                if (m_reversed)
                    m_isActive = !(bool)dataValue;
                else
                    m_isActive = (bool)dataValue;
            }

            m_gameObject ??= gameObject;
            
            if (m_objectToHide != null)
                m_gameObject = m_objectToHide;
            
            m_gameObject.SetActive(m_isActive);
            
            SetDataValue(!(m_isActive ^ !m_reversed));
        }

        public void PickUp()
        {
            m_isActive = false;
            m_gameObject.SetActive(m_isActive);

            SetDataValue(!(m_isActive ^ !m_reversed));
        }
    }
}