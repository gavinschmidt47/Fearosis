using UnityEngine;

public class LoadSave : MonoBehaviour
{
    public PlayerStartChoice playerStartChoice;

    private string saveDataPath;
    private SaveSystem saveSystem;

    void Awake()
    {
        saveDataPath = System.IO.Path.Combine(Application.persistentDataPath, "savefile.dat");

        saveSystem = gameObject.AddComponent<SaveSystem>();
    }

    public void LoadGameLevel()
    {
        playerStartChoice.loading = true;
        SaveData saveData = saveSystem.LoadGame();
        if (saveData != null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(saveData.sceneName);
        }
    }
}
