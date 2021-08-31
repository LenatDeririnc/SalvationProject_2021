using System;
using ScriptableObjects.Scenes;
using UnityEngine;
using UnityEngine.UI;

namespace Components.Menu
{
    public class Enable24Fps : MonoBehaviour
    {
        [SerializeField] private GameObjectDataHolder settingHolder;
        [SerializeField] private Toggle m_toggle;
        
        public void Enable(bool enabled)
        {
            settingHolder.SetObjectValueBool(!enabled);
        }

        private void Awake()
        {
            settingHolder.SetObjectValueBool(!m_toggle.isOn);
        }
    }
}