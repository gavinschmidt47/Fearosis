using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject optionsMenu;
    public void ToLevelSelect()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelSelect");
    }

    public void ToOptionsMenu()
    {
        optionsMenu.SetActive(true);
    }

    public void FromOptionsMenu()
    {
        optionsMenu.SetActive(false);
    }

    public void ToShopMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Shop");
    }
}
