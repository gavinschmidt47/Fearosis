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
        if (button == null)
            button = GetComponent<Button>();

        if (itemImage == null)
            itemImage = GetComponent<Image>();
        // Implementation to unlock the shop item
        if (levelSelector != null)
        {
            Debug.Log("LevelSelector found for shop item: " + name);
            if (unlocked)
            {
                switch (name)
                {
                    case "Hard Mode":
                        itemImage.color = Color.white;
                        button.onClick.RemoveAllListeners();
                        button.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene(button.gameObject.name + "Hard"));
                        break;
                    case "Infinite Mode":
                        itemImage.color = Color.white;
                        Debug.Log("Setting Infinite Mode button for shop item: " + gameObject.transform.parent.parent.name);
                        button.onClick.RemoveAllListeners();
                        button.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene(button.gameObject.transform.parent.parent.name + "Impossible"));
                        break;
                    default:
                        itemImage.color = Color.gray;
                        button.onClick.RemoveAllListeners();
                        button.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene("Shop"));
                        break;
                }
            }
            else
            {
                itemImage.color = Color.gray;
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene("Shop"));
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
            if (!unlocked)
            {
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene("Shop"));
                itemImage.color = Color.gray;
            }
            else
            {
                switch (name)
                {
                    case "Christmas Theme":
                        itemImage.color = Color.white;
                        button.onClick.RemoveAllListeners();
                        button.onClick.AddListener(() =>
                        {
                        playerStartChoice.christmas = !playerStartChoice.christmas;
                        playerStartChoice.halloween = false;
                        });
                        break;
                    case "Halloween Theme":
                        itemImage.color = Color.white;    
                        button.onClick.RemoveAllListeners();
                        button.onClick.AddListener(() =>
                        {
                            playerStartChoice.halloween = !playerStartChoice.halloween;
                            playerStartChoice.christmas = false;
                        });
                        break;
                }
            }
        }
    }
}