using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Slider soundEffectsSlider;
    [SerializeField] Slider musicSlider;

    public void ChangeSoundEffectsVolume()
    {
        AudioListener.volume = soundEffectsSlider.value;
    }

    public void ChangeMusicVolume()
    {
        AudioListener.volume = musicSlider.value;
    }

}
