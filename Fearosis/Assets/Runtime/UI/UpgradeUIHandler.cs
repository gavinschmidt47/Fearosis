using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeUIHandler : MonoBehaviour
{
    public GameObject namePanel;
    public GameObject descriptionPanel;
    public GameObject costPanel;
    public GameObject activateButton;
    public GameObject iconPanel;

    [HideInInspector]
    public Upgrade upgradeScript;

    private Sprite icon;

    void OnEnable()
    {
        descriptionPanel.SetActive(false);
        activateButton.SetActive(false);

        namePanel.GetComponent<TextMeshProUGUI>().text = "Select an Upgrade";

        upgradeScript = null;
    }

    public void ChosenUpgrade(Upgrade upgrade, Sprite icon)
    {
        descriptionPanel.SetActive(true);
        upgradeScript = upgrade;
        this.icon = icon;

        namePanel.GetComponent<TextMeshProUGUI>().text = upgradeScript.upgradeName;
        descriptionPanel.GetComponent<TextMeshProUGUI>().text = upgradeScript.upgradeDescription;
        
        if (upgradeScript.isPurchased)
        {
            activateButton.SetActive(false);
            iconPanel.GetComponent<Image>().sprite = icon;
            iconPanel.SetActive(true);
            costPanel.GetComponent<TextMeshProUGUI>().text = "Upgrade Purchased";
        }
        else
        {
            activateButton.SetActive(true);
            iconPanel.SetActive(false);
            costPanel.GetComponent<TextMeshProUGUI>().text = "Cost: " + upgradeScript.upgradeCost.ToString() + " Influence Points";
        }
        
    }

    public void PurchaseUpgrade()
    {
        upgradeScript.Purchase();

        if (upgradeScript.isPurchased)
        {
            activateButton.SetActive(false);
            iconPanel.GetComponent<Image>().sprite = icon;
            iconPanel.SetActive(true);
            costPanel.GetComponent<TextMeshProUGUI>().text = "Upgrade Purchased";
        }
    }
}
