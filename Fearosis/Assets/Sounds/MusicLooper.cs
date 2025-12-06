using System;
using UnityEngine;
using UnityEngine.Audio;

public class MusicLooper : MonoBehaviour
{
    public AudioClip introClip;
    public AudioClip mainClip;
    public AudioMixerGroup audioMixerGroup;
    public float transitionTime = 0.1f;

    public event Action<AudioSource> OnMainLoopStarted;

    private AudioSource audioSource;
    private AudioSource mainAudioSource;
    private bool mainStarted = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = audioMixerGroup;
        audioSource.clip = introClip;
        audioSource.loop = false;
        audioSource.Play();
    }

    void Update()
    {
        float timeRemaining = audioSource.clip.length - audioSource.time;
        if (!mainStarted && timeRemaining <= transitionTime)
        {
            mainAudioSource = gameObject.AddComponent<AudioSource>();
            mainAudioSource.volume = audioSource.volume;
            mainAudioSource.outputAudioMixerGroup = audioMixerGroup;
            mainAudioSource.clip = mainClip;
            mainAudioSource.loop = true;
            mainAudioSource.Play();
            mainStarted = true;
            OnMainLoopStarted?.Invoke(mainAudioSource);
        }
    }
}
