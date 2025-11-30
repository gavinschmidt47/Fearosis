using UnityEngine;
using UnityEngine.UI;

public class SFXTriggerer : MonoBehaviour
{
    public AudioClip buttonClickSFX;
    
    private AudioSource audioSource;
    private Button[] buttons;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        buttons = FindObjectsByType<Button>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        foreach (var button in buttons)
        {
            button.onClick.AddListener(PlayButtonClickSFX);
        }
    }

    void PlayButtonClickSFX()
    {
        audioSource.PlayOneShot(buttonClickSFX);
    }
}
