using System;
using ScriptableObjects.Scenes;
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

    public struct SwitchData
    {
        public bool isUserTurnedOn;
        public bool isGeneratorTurnedOn;
    }
    
    public class SwitchObject : MonoBehaviourDataRecorder
    {
        [SerializeField] private bool m_isTurnedOn;
        private SwitchData m_currentSwitchData;

        [SerializeField] private GameObjectDataHolder subparent;

        // Эвенты, которые выполняются одновременно при свиче объектов
        [SerializeField] private SwitchEvent<bool> triggerOn;
        [SerializeField] private SwitchEvent<bool> triggerOff;

        // Эвенты, которые выполняются при включении, и другие эвенты, выполняющиеся при выключении объекта
        private bool m_ignoreOnTriggers;
        [SerializeField] private OnSwitchEvent onTriggerOn;
        [SerializeField] private OnSwitchEvent onTriggerOff;

        private static Action updateChild;

        public void SetIgnoreOnTriggers(bool value)
        {
            m_ignoreOnTriggers = value;
        }

        private bool CheckParentState()
        {
            if (subparent == null) 
                return true;
            
            var parent = subparent.Value();
            if (parent == null) 
                return true;
            
            var parentData = (bool) parent;
            
            return parentData;
        }

        private void SetTurnedOn(bool value)
        {
            triggerOn.Invoke(value);
            triggerOff.Invoke(!value);

            if (m_ignoreOnTriggers) 
                return;
            
            if (value)
                onTriggerOn.Invoke();
            else
                onTriggerOff.Invoke();
        }

        public void UpdateData(bool needLoadData)
        {
            if (needLoadData)
            {
                var value = GetDataValue();

                if (value != null)
                {
                    m_isTurnedOn = (bool) value;
                }
            }

            SetTurnedOn(CheckParentState() && m_isTurnedOn);

            SetDataValue(m_isTurnedOn);
        }

        private void Awake()
        {
            UpdateData(true);
        }

        public void Switch()
        {
            m_isTurnedOn = !m_isTurnedOn;
            UpdateData(false);
        }

        public void SwitchOn()
        {
            m_isTurnedOn = true;
            UpdateData(false);
        }

        public void SwitchOff()
        {
            m_isTurnedOn = false;
            UpdateData(false);
        }
    }
}

