using UnityEngine;
using System.IO;
using MemoryPack;
using System;
using System.Collections.Generic;

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

    private List<ShopItem> infiniteModePanels;
    private string saveFilePath;
    private string shopDataPath;
    private ShopData shopData;
    private string encryptionKey = "01142003";

    void Awake()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "savefile.dat");
        shopDataPath = Path.Combine(Application.persistentDataPath, "shopdata.dat");
        infiniteModePanels = new List<ShopItem>();
        foreach (ShopItem panel in FindObjectsByType<ShopItem>(FindObjectsSortMode.None))
        {
            if (panel.name == "Infinite Mode")
            {
                infiniteModePanels.Add(panel);
            }
        }
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

            if (shopData.purchasedMonsters.Contains("Skinwalker"))
                skinwalkerPanel.Unlock(true);
            else
                skinwalkerPanel.Unlock(false);

            if (shopData.purchasedMonsters.Contains("GoodAI"))
                goodAIPanel.Unlock(true);
            else
                goodAIPanel.Unlock(false);

            if (shopData.purchasedThemes.Contains("HalloweenTheme"))
                halloweenThemePanel.Unlock(true);
            else
                halloweenThemePanel.Unlock(false);

            if (shopData.purchasedThemes.Contains("ChristmasTheme"))
                christmasThemePanel.Unlock(true);
            else
                christmasThemePanel.Unlock(false);

            if (shopData.purchasedModes.Contains("InfiniteMode"))
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

            if (shopData.purchasedModes.Contains("MonsterHardMode"))
                monsterHardModePanel.Unlock(true);
            else
                monsterHardModePanel.Unlock(false);

            if (shopData.purchasedModes.Contains("CultHardMode"))
                cultHardModePanel.Unlock(true);
            else
                cultHardModePanel.Unlock(false);

            if (shopData.purchasedModes.Contains("AIHardMode"))
                AIHardModePanel.Unlock(true);
            else
                AIHardModePanel.Unlock(false);

            if (shopData.purchasedModes.Contains("SkinwalkerHardMode"))
                skinwalkerHardModePanel.Unlock(true);
            else
                skinwalkerHardModePanel.Unlock(false);

            if (shopData.purchasedModes.Contains("GoodAIHardMode"))
                goodAIHardModePanel.Unlock(true);
            else
                goodAIHardModePanel.Unlock(false);
        }
        else
        {
            skinwalkerPanel.Unlock(false);
            goodAIPanel.Unlock(false);
            halloweenThemePanel.Unlock(false);
            christmasThemePanel.Unlock(false);
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
