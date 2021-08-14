using System;
using System.Collections.Generic;
using Components.GameObjects;
using Fungus;
using UnityEngine;
using UnityEngine.Events;
using Object = System.Object;
using parameters = Components.Scene.LoadExitSceneParameters;

namespace Components.Scene
{
    [Serializable]
    public class SceneEvent : UnityEvent
    { }

    public enum LoadExitSceneParameters
    {
        EnterEnabled,
        ExitEnabled
    }
    
    public class OnLoadExitSceneEvents : MonoBehaviourDataRecorder
    {

        [SerializeField] private bool m_InitLoadInEditor = true;
        
        [Space]

        [SerializeField] private bool m_onEnterEnabled = true;
        public SceneEvent OnSceneLoad;
        
        [SerializeField] private bool m_onExitEnabled = true;
        public SceneEvent OnSceneExit;
        
        
        public bool EnterEnabled() => m_onEnterEnabled;
        public bool ExitEnabled() => m_onExitEnabled;
        public void SetEnterEnabled(bool state) => m_onEnterEnabled = state;
        public void SetExitEnabled(bool state) => m_onExitEnabled = state;

        public void SceneLoad()
        {
            if (m_onEnterEnabled)
                OnSceneLoad.Invoke();
        }
        
        public void SceneExit()
        {
            if (m_onExitEnabled)
                OnSceneExit.Invoke();
        }

        private Dictionary<parameters, bool> LoadData()
        {
            var retVal = GetDataValue();
            Dictionary<parameters, bool> dictionary;
            switch (retVal)
            {
                case null:
                    dictionary = new Dictionary<parameters, bool>
                    {
                        [parameters.EnterEnabled] = m_onEnterEnabled,
                        [parameters.ExitEnabled] = m_onExitEnabled
                    };
                    break;
                
                case Dictionary<parameters, bool> val:
                    dictionary = val;
                    break;
                
                default:
                    dictionary = new Dictionary<LoadExitSceneParameters, bool>();
                    break;
            }

            return dictionary;
        }

        private void SetData(parameters parameter, bool value)
        {
            var retVal = LoadData();
            retVal[parameter] = value;
            SetDataValue(retVal);
        }
        
        void Start()
        {
            #if UNITY_EDITOR
            if (!m_InitLoadInEditor)
                return;
            #endif
            SceneLoad();
        }

    }   
}
