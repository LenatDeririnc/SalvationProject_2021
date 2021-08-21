using System;
using System.Collections.Generic;
using Components.Animation;
using UnityEngine;

namespace Components.Functions.Animations
{
    public class HeadTrackingSetter : MonoBehaviour
    {
        public List<HeadTracking> headTracks;
        public float speedToSet = 1;
        public float currentSet = 1;
        private float m_targetToSet = 0;

        private Action<float> onRigWeightChange;
        private Action<Transform> onTargetChange;
        
        private void Awake()
        {
            foreach (var track in headTracks)
            {
                onTargetChange += track.SetTracking;
                onRigWeightChange += track.SetRigWeight;
            }
        }

        public void SetTarget(Transform target)
        {
            onTargetChange.Invoke(target);
        }

        public void SetRigWeight(float value)
        {
            m_targetToSet = value;
        }

        public void Start()
        {
            m_targetToSet = currentSet;
        }

        private void FixedUpdate()
        {
            currentSet = Mathf.Lerp(this.currentSet, m_targetToSet, speedToSet);
            
            onRigWeightChange.Invoke(currentSet);
        }
    }
}