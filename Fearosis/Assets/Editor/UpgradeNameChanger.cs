using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class UpgradeNameChanger : Editor
{
    [MenuItem("Tools/Rename All Upgrades To upgradeName")]
    static void RenameAllUpgrades()
    {
        // Find all Upgrade components in the loaded scene(s)
        Upgrade[] upgrades = Resources.FindObjectsOfTypeAll<Upgrade>();
        int count = 0;

        foreach (Upgrade upgrade in upgrades)
        {
            upgrade.gameObject.SetActive(true);
            // Only rename if current name differs
            if (upgrade.gameObject.name  != upgrade.upgradeName + " Upgrade")
            {
                Undo.RecordObject(upgrade.gameObject, "Rename Upgrade GameObject");
                upgrade.gameObject.name = upgrade.upgradeName + " Upgrade";

                EditorUtility.SetDirty(upgrade.gameObject); // Ensure the scene registers the change
                count++;
            }
        }

        UpgradeButtonHandler[] upgradeButtons = Resources.FindObjectsOfTypeAll<UpgradeButtonHandler>();
        foreach (UpgradeButtonHandler button in upgradeButtons)
        {
            button.gameObject.SetActive(true);
            // Only rename if current name differs
            if (button.gameObject.name != button.upgradeScript.upgradeName + " Button")
            {
                Undo.RecordObject(button.gameObject, "Rename Upgrade Button GameObject");
                button.gameObject.name = button.upgradeScript.upgradeName + " Button";

                EditorUtility.SetDirty(button.gameObject); // Ensure the scene registers the change
                count++;
            }

            if (button.gameObject.GetComponent<Image>() != null)
            {
                Undo.RecordObject(button.gameObject.GetComponent<Image>(), "Rename Upgrade Button SpriteRenderer");
                string sceneName = button.gameObject.scene.name;
                string sourceName = button.gameObject.transform.parent.name;
                string spritePath = $"Assets/Sprite/Upgrades/{sceneName}/{sourceName}/{button.upgradeScript.upgradeName}.png";
                Texture2D texture = AssetDatabase.LoadAssetAtPath<Texture2D>(spritePath);
                if (texture == null)
                {
                    // Try without extension as Unity sometimes references sprites this way
                    spritePath = $"Assets/Sprite/Upgrades/{sceneName}/{sourceName}/{button.upgradeScript.upgradeName}";
                    texture = AssetDatabase.LoadAssetAtPath<Texture2D>(spritePath);
                }
                if (texture != null)
                {
                    button.gameObject.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                    EditorUtility.SetDirty(button.gameObject.GetComponent<Image>());
                }
                else
                {
                    Debug.LogWarning($"Sprite not found at path: {spritePath} for {button.gameObject.name}");
                }
            }
        }

        Debug.Log($"Renamed {count} Upgrade GameObjects to their upgradeName property.");
        // Optionally mark entire scene dirty for save
        if (count > 0)
        {
            UnityEditor.SceneManagement.EditorSceneManager.MarkAllScenesDirty();
        }
    }
}
