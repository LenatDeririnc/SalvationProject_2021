using System;
using System.Collections;
using Components.Player;
using Managers.Player;
using UnityEngine;

namespace Components.Functions
{
    public class PlayerSpeedChanger : MonoBehaviour
    {
        private float defaultSpeed = 0f;
        private float m_currentTime = 0;

        public void SetSpeed(float speed)
        {
            PlayerComponent.setWalkSpeed.Invoke(speed);
        }

        public void SetCurrentTime(float time)
        {
            m_currentTime = time;
        }
        
        public void SetSpeedOnTiming(float speed)
        {
            StartCoroutine(SpeedChangerOnTiming(m_currentTime, speed));
        }
        
        public void SetDefaultSpeedOnTiming()
        {
            StartCoroutine(SpeedChangerOnTiming(m_currentTime, defaultSpeed));
        }

        public void SetDefaultSpeed()
        {
            PlayerComponent.setWalkSpeed.Invoke(defaultSpeed);
        }

        private void Start()
        {
            defaultSpeed = PlayerComponent.walkSpeed.Invoke();
        }

        private IEnumerator SpeedChangerOnTiming(float time, float speed)
        {
            yield return new WaitForSeconds(time);
            SetSpeed(speed);
        }
    }
}