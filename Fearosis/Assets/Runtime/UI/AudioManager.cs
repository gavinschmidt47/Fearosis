using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Slider soundEffectsSlider;
    [SerializeField] Slider musicSlider;

    public Action onScreenDisable;

    public void ChangeSoundEffectsVolume()
    {
        AudioListener.volume = soundEffectsSlider.value;
    }

    public void ChangeMusicVolume()
    {
        AudioListener.volume = musicSlider.value;
    }

    private void OnDisable()
    {
        onScreenDisable?.Invoke();
    }

}
