using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonHandler : MonoBehaviour
{
    public Upgrade upgradeScript;
    public UpgradeUIHandler upgradeUIHandler;

    private Image image;
    private void Start()
    {
        // Get the Button component
        Button button = GetComponent<Button>();

        image = GetComponent<Image>();

        // Add listener for button click
        button.onClick.AddListener(OnButtonPress);

        image.color = new Color32(255, 255, 255, (byte)upgradeScript.currentAlpha);

        if (upgradeScript.currentAlpha > upgradeScript.unavailableAlpha)
            ToggleButton(true);
        else
            ToggleButton(false);

        upgradeScript.upgradeUnlocked += () =>
        {
            image.color = new Color32(255, 255, 255, (byte)upgradeScript.currentAlpha);
            ToggleButton(true);
        };

        upgradeScript.upgradePurchased += () =>
        {
            image.color = new Color32(255, 255, 255, (byte)upgradeScript.currentAlpha);
            ToggleButton(false);
        };
    }

    public void OnButtonPress()
    {
        upgradeUIHandler.ChosenUpgrade(upgradeScript);
    }
    
    public void ToggleButton(bool state)
    {
        GetComponent<Button>().interactable = state;
    }
}
