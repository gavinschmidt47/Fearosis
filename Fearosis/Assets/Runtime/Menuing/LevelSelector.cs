using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button mainButton;

    public GameObject buttonsPanel;

    public Button normalMode;
    public Button hardMode;
    public Button infiniteMode;
    public GameObject descriptionBox;

    public delegate void GamemodeDelegate();
    public GamemodeDelegate onHardButtonSelected;
    public GamemodeDelegate onInfiniteButtonSelected;

    [HideInInspector]
    public string hardModeSceneName;
    [HideInInspector]
    public string infiniteModeSceneName;

    void Awake()
    {
        descriptionBox.SetActive(true);

        mainButton.onClick.AddListener(ShowGamemodes);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        normalMode.onClick.AddListener(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(gameObject.name);
        });
        if (hardMode != null)
        {
            hardMode.onClick.AddListener(() =>
            {
                onHardButtonSelected?.Invoke();
            });
        }
        if (infiniteMode != null)
        {
            infiniteMode.onClick.AddListener(() =>
            {
                onInfiniteButtonSelected?.Invoke();
            });
        }
        buttonsPanel.SetActive(false);

        hardModeSceneName = gameObject.name + "Hard";
        infiniteModeSceneName = gameObject.name + "Impossible";
    }

    public void LoadLockedScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void ShowGamemodes()
    {
        buttonsPanel.SetActive(!buttonsPanel.activeSelf);
        descriptionBox.SetActive(!descriptionBox.activeSelf);
    }
}