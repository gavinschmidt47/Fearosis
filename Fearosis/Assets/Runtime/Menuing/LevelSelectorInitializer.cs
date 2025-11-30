using UnityEngine;
using System.IO;
using MemoryPack;
using System;

public class LevelSelectorInitializer : MonoBehaviour
{
    public GameObject loadGamePanel;

    public ShopItem skinwalkerPanel;
    public ShopItem goodAIPanel;

    public ShopItem halloweenThemePanel;
    public ShopItem christmasThemePanel;

    public ShopItem monsterHardModePanel;

    public ShopItem cultHardModePanel;

    public ShopItem AIHardModePanel;

    public ShopItem skinwalkerHardModePanel;

    public ShopItem goodAIHardModePanel;

    private ShopItem[] infiniteModePanels;
    private string saveFilePath;
    private string shopDataPath;
    private ShopData shopData;
    private SerializeProtection serializeProtection;
    private string encryptionKey = "01142003";

    void Awake()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "savefile.dat");
        shopDataPath = Path.Combine(Application.persistentDataPath, "shopdata.dat");
        serializeProtection =  gameObject.AddComponent<SerializeProtection>();
        infiniteModePanels = FindObjectsByType<ShopItem>(FindObjectsSortMode.None);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (File.Exists(saveFilePath))
            loadGamePanel.SetActive(true);

        if (File.Exists(shopDataPath))
        {
            byte[] shopDataBytes = File.ReadAllBytes(shopDataPath);
            shopData = MemoryPackSerializer.Deserialize<ShopData>(shopDataBytes);

            if (shopData.purchasedMonsters.Contains(serializeProtection.Protect("Skinwalker" + encryptionKey)))
                skinwalkerPanel.Unlock(true);
            else
                skinwalkerPanel.Unlock(false);

            if (shopData.purchasedMonsters.Contains(serializeProtection.Protect("GoodAI" + encryptionKey)))
                goodAIPanel.Unlock(true);
            else
                goodAIPanel.Unlock(false);

            /*if (shopData.purchasedThemes.Contains(serializeProtection.Protect("HalloweenTheme" + encryptionKey)))
                halloweenThemePanel.Unlock(true);
            else
                halloweenThemePanel.Unlock(false);

            if (shopData.purchasedThemes.Contains(serializeProtection.Protect("ChristmasTheme" + encryptionKey)))
                christmasThemePanel.Unlock(true);
            else
                christmasThemePanel.Unlock(false);*/

            if (shopData.purchasedModes.Contains(serializeProtection.Protect("InfiniteMode" + encryptionKey)))
            {
                foreach (ShopItem panel in infiniteModePanels)
                {
                    panel.Unlock(true);
                }
            }
            else
            {
                foreach (ShopItem panel in infiniteModePanels)
                {
                    panel.Unlock(false);
                }
            }

            if (shopData.purchasedModes.Contains(serializeProtection.Protect("MonsterHardMode" + encryptionKey)))
                monsterHardModePanel.Unlock(true);
            else
                monsterHardModePanel.Unlock(false);

            if (shopData.purchasedModes.Contains(serializeProtection.Protect("CultHardMode" + encryptionKey)))
                cultHardModePanel.Unlock(true);
            else
                cultHardModePanel.Unlock(false);

            if (shopData.purchasedModes.Contains(serializeProtection.Protect("AIHardMode" + encryptionKey)))
                AIHardModePanel.Unlock(true);
            else
                AIHardModePanel.Unlock(false);

            if (shopData.purchasedModes.Contains(serializeProtection.Protect("SkinwalkerHardMode" + encryptionKey)))
                skinwalkerHardModePanel.Unlock(true);
            else
                skinwalkerHardModePanel.Unlock(false);

            if (shopData.purchasedModes.Contains(serializeProtection.Protect("GoodAIHardMode" + encryptionKey)))
                goodAIHardModePanel.Unlock(true);
            else
                goodAIHardModePanel.Unlock(false);
        }
        else
        {
            skinwalkerPanel.Unlock(false);
            goodAIPanel.Unlock(false);
            //halloweenThemePanel.Unlock(false);
            //christmasThemePanel.Unlock(false);
            foreach (ShopItem panel in infiniteModePanels)
            {
                panel.Unlock(false);
            }
            monsterHardModePanel.Unlock(false);
            cultHardModePanel.Unlock(false);
            AIHardModePanel.Unlock(false);
            skinwalkerHardModePanel.Unlock(false);
            goodAIHardModePanel.Unlock(false);

            Byte[] bytes = MemoryPackSerializer.Serialize(new ShopData());
            File.WriteAllBytes(shopDataPath, bytes);
        }
    }
}
