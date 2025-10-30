using UnityEngine;
using System.IO;
using MemoryPack;

public class SaveSystem : MonoBehaviour
{
    private string saveFilePath;

    void Awake()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "savefile.dat");
    }

    public void SaveGame(SaveData saveData)
    {
        byte[] bytes = MemoryPackSerializer.Serialize(saveData);
        File.WriteAllBytes(saveFilePath, bytes);
        Debug.Log("Game saved to " + saveFilePath);
    }

    public SaveData LoadGame()
    {
        if (!File.Exists(saveFilePath))
        {
            Debug.LogWarning("Save file not found at " + saveFilePath);
            return null;
        }

        byte[] bytes = File.ReadAllBytes(saveFilePath);
        SaveData saveData = MemoryPackSerializer.Deserialize<SaveData>(bytes);
        Debug.Log("Game loaded from " + saveFilePath);
        return saveData;
    }
}
