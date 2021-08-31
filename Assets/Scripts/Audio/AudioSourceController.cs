using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using Managers.Menu;
using UnityEngine;

namespace AudioSettings
{
    public class AudioSourceController : MonoBehaviour
    {
        private AudioSource source;

        [SerializeField] private float fadeSpeed = 1;
        [SerializeField] private float startValue = 0;
        [SerializeField] [Range(0, 1)] private float maxVolume = 1;
        [SerializeField] [Range(0, 1)] private float targetValue;

        private float m_fadeSpeed;
        private float m_startValue;
        private float m_maxVolume;
        private float m_targetValue;

        private float value = 0;
        

        private void Awake()
        {
            m_fadeSpeed = fadeSpeed;
            m_startValue = startValue;
            m_maxVolume = maxVolume;
            m_targetValue = targetValue;
            
            source = GetComponent<AudioSource>();

            value = m_startValue;
            source.volume = value;
            // PauseManager.onGamePaused += PauseMusic;
        }

        public void StartLoop()
        {
            this.source.loop = true;
            this.source.Play();
        }

        public void Stop()
        {
            source.Stop();
        }

        public void PlayOnce()
        {
            source.loop = false;
            source.Play();
        }

        public void PlayOneShot(AudioClip clip)
        {
            source.PlayOneShot(clip);
        }
        
        public void SetChangeSpeed(float value)
        {
            this.fadeSpeed = value;
            this.m_fadeSpeed = value;
        }

        public void SetVolume(float value)
        {
            this.targetValue = value;
            this.m_targetValue = value;
        }
        
        public void SetVolumeDirectly(float value)
        {
            m_targetValue = value;
            this.value = value;
            source.volume = this.value;
        }

        public void PauseMusic(bool state)
        {
            if (state)
            {
                source.volume = 0;
                source.Pause();
            }
            else
            {
                source.UnPause();
            }
        }

        public void FixedUpdate()
        {
            // if (PauseManager.isGamePaused)
            //     return;

            if (Mathf.Abs(value - m_targetValue * m_maxVolume) <= 0.001)
                return;

            value = Mathf.Lerp(value, m_targetValue * m_maxVolume, m_fadeSpeed);

            source.volume = value;
        }
    }
}
