using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuUI : MonoBehaviour
{
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private SoundMixerManager soundMixerManager;

    private void Start()
    {
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);

        // Optionally initialize slider values here
    }

    private void SetMasterVolume(float value)
    {
        // Convert slider value to mixer value if needed
        soundMixerManager.SetMasterVolume(value);
    }

    private void SetSFXVolume(float value)
    {
        soundMixerManager.SetSoundFXVolume(value);
    }

    private void SetMusicVolume(float value)
    {
        soundMixerManager.SetMusicVolume(value);
    }
}