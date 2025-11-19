using UnityEngine;
using System.Collections.Generic;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;

public class CloudSave : MonoBehaviour
{
    public ShopUIManager shopUI;
    Dictionary<string, string> loadedData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        SetupAndSignIn();
        if(loadedData != null)
        {
            LoadData();
        }
    }

    async void SetupAndSignIn()
    {
        await UnityServices.InitializeAsync();
        if (!AuthenticationService.Instance.SessionTokenExists)
        {
            return;
        }
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    public async void SaveData() 
    {
        var data = new Dictionary<string, object>{
            {"Upgrade1", shopUI.hasUpgrade1},
            {"Upgrade2", shopUI.hasUpgrade2},
            {"Monster1", shopUI.hasMonster1},
            {"Monster2", shopUI.hasMonster2},
            {"Theme1", shopUI.hasTheme1},
            {"Theme2", shopUI.hasTheme2} 
        };
        await CloudSaveService.Instance.Data.ForceSaveAsync(data);
    }
    // Update is called once per frame

    public async void LoadData(){
        var LoadedShopData = new HashSet<string> {
            "Upgrade1",
            "Upgrade2",
            "Monster1",
            "Monster2",
            "Theme1",
            "Theme2"
        };
        loadedData = await CloudSaveService.Instance.Data.LoadAsync(LoadedShopData);
        shopUI.hasUpgrade1 = bool.Parse(loadedData["Upgrade1"]);
        shopUI.hasUpgrade2 = bool.Parse(loadedData["Upgrade2"]);
        shopUI.hasMonster1 = bool.Parse(loadedData["Monster1"]);
        shopUI.hasMonster2 = bool.Parse(loadedData["Monster2"]);
        shopUI.hasTheme1 = bool.Parse(loadedData["Theme1"]);
        shopUI.hasTheme2 = bool.Parse(loadedData["Theme2"]);
    }
}
