using System;
using UnityEngine;

namespace Components.GameObjects
{
    public class ObjectEnabler : MonoBehaviourDataRecorder
    {
        [SerializeField] private Transform m_transform;
        private GameObject m_gameObject;
        [SerializeField] private bool isEnabled;

        private void Awake()
        {
            m_gameObject = gameObject;
            if (m_transform != null)
                m_gameObject = m_transform.gameObject;
            
            isEnabled = GetDataValue(isEnabled);
            UpdateActive();
        }

        public void UpdateActive()
        {
            m_gameObject.SetActive(isEnabled);
            SetDataValue(isEnabled);
        }

        public void SetActive(bool isActive)
        {
            isEnabled = isActive;
            UpdateActive();
        }
        
        public void SetDataActive(bool isActive)
        {
            isEnabled = isActive;
            SetDataValue(isEnabled);
        }
    }
}