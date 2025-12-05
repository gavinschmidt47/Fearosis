using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(ShopData))]
public class DeleteSavedGames : Editor
{
    private static string shopDataPath = Path.Combine(Application.persistentDataPath, "savefile.dat");
    [MenuItem("Tools/DeleteGame")]
    private static void DeleteCache()
    {
        if (File.Exists(shopDataPath))
        {
            File.Delete(shopDataPath);
            Debug.Log("Deleted game data file at: " + shopDataPath);
        }
        else
        {
            Debug.Log("No game data file found at: " + shopDataPath);
        }
    }
}
