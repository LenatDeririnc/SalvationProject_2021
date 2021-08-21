using System.Collections;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    #region Instance
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                if (instance == null)
                {
                    instance = new GameObject("AudioManager", typeof(AudioManager)).GetComponent<AudioManager>();
                }
            }

            return instance;
        }
        set
        {
            instance = value;
        }
    }
    #endregion

    public Audio[] sfx;
    public Audio[] music;
    [Range(0.0f, 1.0f)]
    public float musicVolume;
    [Range(0.0f, 1.0f)]
    public float sfxVolume;
    public float transitionTime = 1.0f;

    private AudioSource musicSource;
    private AudioSource musicSource2;
    private AudioSource sfxSource;
    private bool firstMusicSourceIsActive;

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);

        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource2 = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();

        musicSource.loop = true;
        musicSource2.loop = true;
    }

    public void Update() {
        AudioSource activeSource = (firstMusicSourceIsActive) ? musicSource : musicSource2;

        if (activeSource.volume != musicVolume)
            activeSource.volume = musicVolume;

        if (sfxSource.volume != sfxVolume)
            sfxSource.volume = sfxVolume;
    }

    public void PlayMusic(AudioClip musicClip) {
        musicSource.clip = musicClip;
        musicSource.Play();
    }

    public void PlayMusicWithFade(AudioClip musicClip, float? transitionTimeLocal = 1.0f) {
        AudioSource activeSource = (firstMusicSourceIsActive) ? musicSource : musicSource2;
        StartCoroutine(UpdateMusicWithFade(activeSource, musicClip, transitionTimeLocal ??= transitionTime));
    }

    public void PlayMusicWithCrossFade(AudioClip musicClip, float? transitionTimeLocal = 1.0f) {
        AudioSource activeSource = (firstMusicSourceIsActive) ? musicSource : musicSource2;
        AudioSource newSource = (firstMusicSourceIsActive) ? musicSource2 : musicSource;

        firstMusicSourceIsActive = !firstMusicSourceIsActive;

        newSource.clip = musicClip;
        newSource.Play();
        StartCoroutine(UpdateMusicWithCrossFade(activeSource, newSource, musicClip, transitionTimeLocal ??= transitionTime));
    }

    private IEnumerator UpdateMusicWithFade(AudioSource activeSource, AudioClip music, float transitionTime) {
        if(!activeSource.isPlaying)
            activeSource.Play();

        float t = 0.0f;

        for (t = 0.0f; t <= transitionTime; t += Time.deltaTime)
        {
            activeSource.volume = (musicVolume - ((t/ transitionTime) * musicVolume));
            yield return null;
        }

        activeSource.Stop();
        activeSource.clip = music;
        activeSource.Play();

        for (t = 0.0f; t <= transitionTime; t += Time.deltaTime)
        {
            activeSource.volume = (t / transitionTime) * musicVolume;
            yield return null;
        }

        activeSource.volume = musicVolume;
    }

    private IEnumerator UpdateMusicWithCrossFade(AudioSource original, AudioSource newSource, AudioClip music, float transitionTime) {
        if (!original.isPlaying)
            original.Play();

        newSource.Stop();
        newSource.clip = music;
        newSource.Play();

        float t = 0.0f;

        for (t = 0.0f; t <= transitionTime; t += Time.deltaTime)
        {
            original.volume = (musicVolume - ((t / transitionTime) * musicVolume));
            newSource.volume = (t / transitionTime) * musicVolume;
            yield return null;
        }

        original.volume = 0;
        newSource.volume = musicVolume;

        original.Stop();
    }

    public void PlaySFX(AudioClip clip) {
        sfxSource.PlayOneShot(clip);
    }

    public void PlaySFX(AudioClip clip, float volume) {
        sfxSource.PlayOneShot(clip, volume);
    }

    public void SetMusicVolume(float volume) {
        musicVolume = musicSource.volume = volume;
        musicSource2.volume = volume;
    }

    public void SetSFXVolume(float volume) {
        sfxSource.volume = volume;
    }

    public void playMusic(string name, bool crossfade = false, float? transition = null) {
        Audio? found = Array.Find(music, element => element.name == name);
        if (found != null)
            if (crossfade)
                PlayMusicWithCrossFade(found.clip, transition);
            else 
                PlayMusicWithFade(found.clip, transition);
    }

    public void PlaySFX(string name) {
          Audio? found = Array.Find(sfx, element => element.name == name);
          if (found != null)
            PlaySFX(found.name);
    }

      public void stopPlay() {
        AudioSource activeSource = (firstMusicSourceIsActive) ? musicSource : musicSource2;

        if (activeSource.isPlaying)
            activeSource.Stop();
    }
}