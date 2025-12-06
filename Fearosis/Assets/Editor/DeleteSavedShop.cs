using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(ShopData))]
public class DeleteSavedShop : Editor
{
    private static string shopDataPath = Path.Combine(Application.persistentDataPath, "shopdata.dat");
    [MenuItem("Tools/DeleteShop")]
    private static void DeleteCache()
    {
        if (File.Exists(shopDataPath))
        {
            File.Delete(shopDataPath);
            Debug.Log("Deleted shop data file at: " + shopDataPath);
        }
        else
        {
            Debug.Log("No shop data file found at: " + shopDataPath);
        }
    }
}
