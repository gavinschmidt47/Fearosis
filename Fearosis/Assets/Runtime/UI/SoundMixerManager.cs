using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundMixerManager : MonoBehaviour
{
    public Sprite[] masterVolumeIcons;
    public Sprite[] soundFXVolumeIcons;
    public Sprite[] musicVolumeIcons;

    private Image masterVolumeIconRenderer;
    private Image soundFXVolumeIconRenderer;
    private Image musicVolumeIconRenderer;

    [SerializeField] private AudioMixer audioMixer;

    private void Awake()
    {
        masterVolumeIconRenderer = GameObject.FindWithTag("Master").GetComponent<Image>();
        soundFXVolumeIconRenderer = GameObject.FindWithTag("SFX").GetComponent<Image>();
        musicVolumeIconRenderer = GameObject.FindWithTag("Music").GetComponent<Image>();
    }

    public void SetMasterVolume(float level)
    {
        audioMixer.SetFloat("masterVolume", level);

        if (level <= -80f)
        {
            masterVolumeIconRenderer.sprite = masterVolumeIcons[1]; // Muted icon
        }
        else
        {
            masterVolumeIconRenderer.sprite = masterVolumeIcons[0]; // Unmuted icon
        }
    }

    public void SetSoundFXVolume(float level)
    {
        audioMixer.SetFloat("soundFXVolume", level);

        if (level <= -80f)
        {
            soundFXVolumeIconRenderer.sprite = soundFXVolumeIcons[1]; // Muted icon
        }
        else
        {
            soundFXVolumeIconRenderer.sprite = soundFXVolumeIcons[0]; // Unmuted icon
        }
    }

    public void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("musicVolume", level);

        if (level <= -80f)
        {
            musicVolumeIconRenderer.sprite = musicVolumeIcons[1]; // Muted icon
        }
        else
        {
            musicVolumeIconRenderer.sprite = musicVolumeIcons[0]; // Unmuted icon
        }
    }
}
