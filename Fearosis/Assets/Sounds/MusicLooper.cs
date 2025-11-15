using UnityEngine;
using UnityEngine.Audio;

public class MusicLooper : MonoBehaviour
{
    public AudioClip introClip;
    public AudioClip mainClip;
    public AudioMixerGroup audioMixerGroup;

    private AudioSource audioSource;
    private bool mainStarted = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = audioMixerGroup;
        audioSource.clip = introClip;
        audioSource.loop = false;
        audioSource.Play();
    }

    void Update()
    {
        if (!mainStarted && !audioSource.isPlaying)
        {
            audioSource.clip = mainClip;
            audioSource.loop = true;
            audioSource.Play();
            mainStarted = true;
        }
    }
}
