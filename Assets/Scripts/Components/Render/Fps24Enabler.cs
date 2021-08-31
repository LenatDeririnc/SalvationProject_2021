using System;
using Components.GameObjects;
using UnityEngine;

namespace Components.Render
{
    public class Fps24Enabler : MonoBehaviourDataRecorder
    {
        [SerializeField] private bool fps24Enabled;
        [SerializeField] private GameObject fps24GO;
        [SerializeField] private GameObject nofps24GO;

        private void Switch24Fps(bool enabled)
        {
            fps24GO.SetActive(enabled);
            nofps24GO.SetActive(!enabled);
        }

        private void Awake()
        {
            fps24Enabled = GetDataValue<bool>(fps24Enabled);
            Switch24Fps(fps24Enabled);
        }

#if UNITY_EDITOR
        public void FixedUpdate()
        {
            Switch24Fps(fps24Enabled);
        }
#endif
    }
}