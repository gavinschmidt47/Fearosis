using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayLevel : MonoBehaviour
{
    private bool infiniteModeOn;
    public string normalScene;
    public string infiniteScene;



    public void InfiniteModeOff()
    {
        infiniteModeOn = false;
    }

    public void InfiniteModeOn()
    {
        infiniteModeOn = true;
    }

    public void PlayALevel()
    {
        if (!infiniteModeOn)
        {
            SceneManager.LoadScene(normalScene);
        }
        else
        {
            SceneManager.LoadScene(infiniteScene);
        }
    }
}
