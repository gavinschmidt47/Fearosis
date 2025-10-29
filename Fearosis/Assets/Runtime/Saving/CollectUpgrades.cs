using UnityEngine;
using System.Collections.Generic;

public class CollectUpgrades : MonoBehaviour
{
    private List<Upgrade> allUpgrades;

    private void Start()
    {
        Upgrade[] allUpgradesArray = FindObjectsByType<Upgrade>(FindObjectsSortMode.None);
        allUpgrades = new List<Upgrade>(allUpgradesArray);
    }

    public List<Upgrade> CollectPurchasedUpgrades()
    {
        List<Upgrade> purchasedUpgrades = new List<Upgrade>();
        foreach (var upgrade in allUpgrades)
        {
            if (upgrade.isPurchased)
            {
                purchasedUpgrades.Add(upgrade);
            }
        }
        return purchasedUpgrades;
    }
}
