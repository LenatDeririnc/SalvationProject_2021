using System;
using System.Collections;
using System.Collections.Generic;
using Components.UI;
using Managers.UI;
using UnityEngine;

namespace Components.Functions
{
    public enum FadeType
    {
        In,
        Out
    }
    
    public class FadeInOutEnabler : MonoBehaviour
    {
        private float m_time = 0;

        public void SetTime(float time)
        {
            m_time = time;
        }
        
        public void FadeIn(float speed)
        {
            FadeInOutManager.FadeIn(this, speed);
        }
        
        public void FadeInOnTiming(float speed)
        {
            StartCoroutine(FadeInOutOnTiming(m_time, speed, FadeType.In));
        }
        
        public void FadeOutOnTiming(float speed)
        {
            StartCoroutine(FadeInOutOnTiming(m_time, speed, FadeType.Out));
        }

        public void FadeOut(float speed)
        {
            FadeInOutManager.FadeOut(this, speed);
        }
        
        private IEnumerator FadeInOutOnTiming(float time, float speed, FadeType type)
        {
            yield return new WaitForSeconds(time);
            switch (type)
            {
                case FadeType.In:
                    FadeIn(speed);
                    break;
                case FadeType.Out:
                    FadeOut(speed);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}