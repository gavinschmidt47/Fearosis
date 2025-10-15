using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public bool infiniteModeOn = false;
    public PlayLevel playLevelScript;

    public TMPro.TextMeshProUGUI descriptionBox;

    [Header("Use this to type in scenes to use")]
    [Header("For Normal Mode")]
    public string normalScene;
    [Header("For Infinite Mode")]
    public string infiniteScene;

    [Header("Respective gamemode option buttons")]
    public Button normalMode;
    public Button infiniteMode;

    [Header("All Share the same play button")]
    public Button playButton;
    RectTransform descTransform;

    float currentX;
    float currentY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playButton.interactable = false;
        descTransform = descriptionBox.GetComponent<RectTransform>();
        normalMode.gameObject.SetActive(false);
        infiniteMode.gameObject.SetActive(false);

        currentX = descTransform.anchoredPosition.x;
        currentY = descTransform.anchoredPosition.y;
    }

    public void ShowGamemodes()
    {
        //move description text down
        if (!normalMode.gameObject.activeSelf)
        {
            descTransform.anchoredPosition = new Vector2(currentX, currentY-70.0f);
        }
        else
        {
            descTransform.anchoredPosition = new Vector2(currentX, currentY);
        }

        //reveal the normal mode and infinite mode buttons
        normalMode.gameObject.SetActive(!normalMode.gameObject.activeSelf);
        infiniteMode.gameObject.SetActive(!infiniteMode.gameObject.activeSelf);
        
    }

    public void SelectNormalMode()
    {
        if (infiniteModeOn)
        {
            infiniteModeOn = false;
        }        
        playButton.interactable = true;
        playLevelScript.normalScene = this.normalScene;
    }

    public void SelectInfiniteMode()
    {
        if (!infiniteModeOn)
        {
            infiniteModeOn = true;
        }
        playButton.interactable = true;
        playLevelScript.infiniteScene = this.infiniteScene;
    }

}