using System;
using UnityEngine;

namespace Components.GameObjects
{
    public class ObjectEnabler : MonoBehaviourDataRecorder
    {
        [SerializeField] private bool isEnabled;
        private GameObject m_gameObject;

        private void Awake()
        {
            m_gameObject = gameObject;
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