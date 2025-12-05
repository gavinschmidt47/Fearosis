using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sprite MutedMainIcon;
    public Sprite UnmutedMainIcon;
    public Sprite MutedSFXIcon;
    public Sprite UnmutedSFXIcon;
    public Sprite MutedMusicIcon;
    public Sprite UnmutedMusicIcon;
    [SerializeField] Slider mainSlider;
    [SerializeField] Slider soundEffectsSlider;
    [SerializeField] Slider musicSlider;

    private AudioSource musicAudioSource;
    private AudioSource soundEffectsAudioSource;
    private MusicLooper musicLooper;

    private Image mainIconRenderer;
    private Image sfxIconRenderer;
    private Image musicIconRenderer;

    public Action onScreenDisable;

    private void Start()
    {
        musicAudioSource = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        musicLooper = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicLooper>();
        soundEffectsAudioSource = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();

        Transform mainIconTransform = mainSlider.transform.Find("Master");
        if (mainIconTransform != null)
            mainIconRenderer = mainIconTransform.GetComponent<Image>();
        else
            Debug.LogError("Could not find child object named 'Master' under mainSlider");

        Transform sfxIconTransform = soundEffectsSlider.transform.Find("SFX");
        if (sfxIconTransform != null)
            sfxIconRenderer = sfxIconTransform.GetComponent<Image>();
        else
            Debug.LogError("Could not find child object named 'SFX' under soundEffectsSlider");

        Transform musicIconTransform = musicSlider.transform.Find("Music");
        if (musicIconTransform != null)
            musicIconRenderer = musicIconTransform.GetComponent<Image>();
        else
            Debug.LogError("Could not find child object named 'Music' under musicSlider");


        //Initialize sliders to current volume levels
        soundEffectsSlider.value = soundEffectsAudioSource.volume;
        musicSlider.value = musicAudioSource.volume;
        mainSlider.value = AudioListener.volume;

        musicLooper.OnMainLoopStarted += (AudioSource source) =>
        {
            musicAudioSource = source;
            // Set the music slider value to the new music audio source volume
            musicSlider.value = musicAudioSource.volume;
        };
    }

    public void ChangeMainVolume(float value)
    {
        AudioListener.volume = value;
        if (AudioListener.volume == 0f)
        {
            mainIconRenderer.sprite = MutedMainIcon;
        }
        else
        {
            mainIconRenderer.sprite = UnmutedMainIcon;
        }
    }

    public void ChangeSoundEffectsVolume(float value)
    {
        soundEffectsAudioSource.volume = value;
        if (soundEffectsAudioSource.volume == 0f)
        {
            sfxIconRenderer.sprite = MutedSFXIcon;
        }
        else
        {
            sfxIconRenderer.sprite = UnmutedSFXIcon;
        }
    }

    public void ChangeMusicVolume(float value)
    {
        musicAudioSource.volume = value;
        if (musicAudioSource.volume == 0f)
        {
            musicIconRenderer.sprite = MutedMusicIcon;
        }
        else
        {
            musicIconRenderer.sprite = UnmutedMusicIcon;
        }
    }

    private void OnDisable()
    {
        onScreenDisable?.Invoke();
    }

}
