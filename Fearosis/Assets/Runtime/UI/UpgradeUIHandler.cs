using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeUIHandler : MonoBehaviour
{
    public GameObject namePanel;
    public GameObject descriptionPanel;
    public GameObject costPanel;
    public GameObject activateButton;

    public int UnavailableAlpha = 0;
    public int AvailableAlpha = 255;
    public int PurchasedAlpha = 90;

    [HideInInspector]
    public Upgrade upgradeScript;

    void OnEnable()
    {
        descriptionPanel.SetActive(false);
        activateButton.SetActive(false);

        namePanel.GetComponent<TextMeshProUGUI>().text = "Select an Upgrade";

        upgradeScript = null;
    }

    public void ChosenUpgrade(Upgrade upgrade)
    {
        descriptionPanel.SetActive(true);
        activateButton.SetActive(true);
        upgradeScript = upgrade;

        namePanel.GetComponent<TextMeshProUGUI>().text = upgradeScript.upgradeName;
        descriptionPanel.GetComponent<TextMeshProUGUI>().text = upgradeScript.upgradeDescription;
        costPanel.GetComponent<TextMeshProUGUI>().text = "Cost: " + upgradeScript.upgradeCost.ToString() + " Influence Points";
    }

    public void PurchaseUpgrade()
    {
        upgradeScript.Purchase();
    }
}
