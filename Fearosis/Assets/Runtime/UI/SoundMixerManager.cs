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

    public void SetMasterVolume(float level)
    {
        audioMixer.SetFloat("masterVolume", level);
    }

    public void SetSoundFXVolume(float level)
    {
        audioMixer.SetFloat("soundFXVolume", level);
    }

    public void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("musicVolume", level);
    }
}
