using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
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

        private float value = 0;
        

        private void Awake()
        {
            source = GetComponent<AudioSource>();

            value = startValue;
            source.volume = value;
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
        }

        public void SetVolume(float value)
        {
            this.targetValue = value;
        }
        
        public void SetVolumeDirectly(float value)
        {
            targetValue = value;
            this.value = value;
            source.volume = this.value;
        }

        public void FixedUpdate()
        {
            if (Mathf.Abs(value - targetValue * maxVolume) <= 0.001)
                return;

            value = Mathf.Lerp(value, targetValue * maxVolume, fadeSpeed);

            source.volume = value;
        }
    }
}
