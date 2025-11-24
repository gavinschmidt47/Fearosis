using UnityEngine;
using UnityEditor;

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
            Debug.Log($"Processing Upgrade on GameObject: {upgrade.upgradeName}");
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
            button.gameObject.SetActive(false);
        }

        Debug.Log($"Renamed {count} Upgrade GameObjects to their upgradeName property.");
        // Optionally mark entire scene dirty for save
        if (count > 0)
        {
            UnityEditor.SceneManagement.EditorSceneManager.MarkAllScenesDirty();
        }
    }
}
