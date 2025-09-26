using UnityEngine;
using TMPro;

public class InfectedUIHandler : MonoBehaviour
{
    private Influence influenceScript;
    private TextMeshProUGUI influenceText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get reference to Influence script
        influenceScript = FindAnyObjectByType<Influence>();
        // Initialize influence text
        influenceText = GetComponent<TextMeshProUGUI>();

        Upgrade[] upgrades = FindObjectsByType<Upgrade>(FindObjectsSortMode.None);
        if (upgrades != null)
        {
            foreach (Upgrade upgrade in upgrades)
            {
            if (upgrade != null)
                upgrade.upgradePurchased += UpdateInfluenceText;
            }
        }

        influenceText.text = influenceScript.influencePoints.ToString();
    }

    public void UpdateInfluenceText()
    {
        influenceText.text = influenceScript.influencePoints.ToString();
    }
}
