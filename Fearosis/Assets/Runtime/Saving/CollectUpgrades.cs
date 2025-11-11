using UnityEngine;
using System.Collections.Generic;

public class CollectUpgrades : MonoBehaviour
{
    private List<Upgrade> allUpgrades;
    private List<Upgrade> purchasedUpgrades;

    private void Start()
    {
        Upgrade[] allUpgradesArray = FindObjectsByType<Upgrade>(FindObjectsSortMode.None);
        allUpgrades = new List<Upgrade>(allUpgradesArray);
    }

    public List<Upgrade> CollectPurchasedUpgrades()
    {
        if (purchasedUpgrades == null)
        {
            purchasedUpgrades = new List<Upgrade>();
        }
        else
        {
            purchasedUpgrades.Clear();
        }
        
        foreach (var upgrade in allUpgrades)
        {
            if (upgrade.isPurchased)
            {
                purchasedUpgrades.Add(upgrade);
            }
        }
        return purchasedUpgrades;
    }

    public void ReUpgrade()
    {
        if (purchasedUpgrades != null)
        {
            foreach (var upgrade in allUpgrades)
            {
                if (purchasedUpgrades.Contains(upgrade))
                {
                    upgrade.isPurchased = true;
                }
            }
        }
    }
}