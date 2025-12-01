using UnityEngine;
using UnityEngine.SceneManagement;


public class ShopSceneManager : MonoBehaviour
{
    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
