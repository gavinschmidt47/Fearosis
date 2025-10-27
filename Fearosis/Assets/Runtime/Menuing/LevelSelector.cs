using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button mainButton;

    public GameObject buttonsPanel;

    public Button normalMode;
    public Button infiniteMode;
    public GameObject descriptionBox;

    public Sprite InfiniteIcon;
    public Sprite LockedInfiniteIcon;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonsPanel.SetActive(false);

        descriptionBox.SetActive(true);

        mainButton.onClick.AddListener(ShowGamemodes);

        normalMode.onClick.AddListener(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(this.gameObject.name);
        });
        infiniteMode.onClick.AddListener(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(this.gameObject.name + " Infinite");
        });
    }

    public void ShowGamemodes()
    {
        buttonsPanel.SetActive(!buttonsPanel.activeSelf);
        descriptionBox.SetActive(!descriptionBox.activeSelf);
    }
}