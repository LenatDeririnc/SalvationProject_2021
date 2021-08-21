using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Components.Animation
{
    public class HeadTracking : MonoBehaviour
    {
        private Transform m_tracking;
        [SerializeField] private Transform HeadAim;
        [SerializeField] private float changeTargetSpeed = 0.1f;
        private Rig m_rig;

        public void SetRigWeight(float value)
        {
            m_rig.weight = value;
        }

        public void SetTracking(Transform tracking)
        {
            m_tracking = tracking;
        }

        private void Start()
        {
            m_rig = GetComponent<Rig>();
            Debug.Assert(HeadAim != null, $"Head aim of object {transform.name} is not setted");
        }

        void FixedUpdate()
        {
            if (HeadAim is null)
                return;

            if(m_tracking is null)
                return;

            HeadAim.position = Vector3.Lerp(HeadAim.position, m_tracking.position, changeTargetSpeed);
        }
    }
}