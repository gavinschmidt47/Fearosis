using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public PlayerStartChoice playerStartChoice;

    private Button button;
    private Image itemImage;
    private LevelSelector levelSelector;

    private void Start()
    {
        button = GetComponent<Button>();
        itemImage = GetComponent<Image>();
        levelSelector = GetComponentInParent<LevelSelector>();
    }

    public void Unlock(bool unlocked)
    {
        // Implementation to unlock the shop item
        if (levelSelector != null)
        {
            if(unlocked)
            {
                if (name == levelSelector.gameObject.name + "Hard Mode")
                {
                    levelSelector.onHardButtonSelected = null;
                    levelSelector.onHardButtonSelected += () => levelSelector.LoadLockedScene(levelSelector.hardModeSceneName);
                }
                else if (name == "Infinite Mode")
                {
                    levelSelector.onInfiniteButtonSelected = null;
                    levelSelector.onInfiniteButtonSelected += () => levelSelector.LoadLockedScene(levelSelector.infiniteModeSceneName);
                    return;
                }
            }
            else
            {
                levelSelector.onHardButtonSelected = null;
                levelSelector.onInfiniteButtonSelected = null;
                levelSelector.onHardButtonSelected += () => UnityEngine.SceneManagement.SceneManager.LoadScene("Shop");
                levelSelector.onInfiniteButtonSelected += () => UnityEngine.SceneManagement.SceneManager.LoadScene("Shop");
            }
        }
        else if (GetComponent<LevelSelector>() != null)
        {
            levelSelector = GetComponent<LevelSelector>();
            if (!unlocked)
            {
                levelSelector.mainButton.onClick.RemoveAllListeners();
                levelSelector.mainButton.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene("Shop"));
                levelSelector.mainButton.GetComponent<Image>().color = Color.gray;
            }
        }
        else
        {
            if (unlocked)
            {
                switch (name)
                {
                    case "Hard Mode":
                        button.onClick.RemoveAllListeners();
                        button.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene(button.gameObject.name + "Hard"));
                        break;
                    case "Infinite Mode":
                        button.onClick.RemoveAllListeners();
                        button.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene(button.gameObject.name + "Impossible"));
                        break;
                    case "Christmas Theme":
                        button.onClick.RemoveAllListeners();
                        button.onClick.AddListener(() =>
                        {
                            playerStartChoice.christmas = true;
                            playerStartChoice.halloween = false;
                        });
                        break;
                    case "Halloween Theme":
                        button.onClick.RemoveAllListeners();
                        button.onClick.AddListener(() =>
                        {
                            playerStartChoice.halloween = true;
                            playerStartChoice.christmas = false;
                        });
                        break;
                    default:
                        button.onClick.RemoveAllListeners();
                        button.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene(button.gameObject.name + "Hard"));
                        break;
                }
            }
            else
            {
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene("Shop"));
            }
        }
    }
}
