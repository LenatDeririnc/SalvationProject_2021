using System;
using UnityEngine;
using UnityEngine.Events;

namespace Components.GameObjects
{
    [Serializable]
    public class SwitchEvent<T> : UnityEvent<T>
    { }
    
    [Serializable]
    public class OnSwitchEvent : UnityEvent
    { }
    public class SwitchObject : MonoBehaviourDataRecorder
    {
        [SerializeField] private bool m_isTurnedOn;

        [SerializeField] private SwitchEvent<bool> triggerOn;
        [SerializeField] private SwitchEvent<bool> triggerOff;

        private bool m_ignoreOnTriggers;
        [SerializeField] private OnSwitchEvent onTriggerOn;
        [SerializeField] private OnSwitchEvent onTriggerOff;

        public void SetIgnoreOnTriggers(bool value)
        {
            m_ignoreOnTriggers = value;
        }

        private void SetTurnedOn(bool value)
        {
            m_isTurnedOn = value;

            triggerOn.Invoke(m_isTurnedOn);
            triggerOff.Invoke(!m_isTurnedOn);

            if (!m_ignoreOnTriggers)
            {
                if (m_isTurnedOn)
                {
                    onTriggerOn.Invoke();
                }
                else
                {
                    onTriggerOff.Invoke();
                }
            }

            SetDataValue(m_isTurnedOn);
        }
        
        private void Awake()
        {
            var value = GetDataValue();
            
            if (value != null)
                m_isTurnedOn = (bool) value;
            
            SetTurnedOn(m_isTurnedOn);
        }

        public void Switch()
        {
            SetTurnedOn(!m_isTurnedOn);
        }
    }
}

