using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonHandler : MonoBehaviour
{
    public Upgrade upgradeScript;
    public UpgradeUIHandler upgradeUIHandler;

    private LockIconManager lockIcon;
    private Image image;
    private void Awake()
    {
        // Get the Button component
        Button button = GetComponent<Button>();

        image = GetComponent<Image>();

        lockIcon = GetComponentInChildren<LockIconManager>();

        // Add listener for button click
        button.onClick.AddListener(OnButtonPress);

        lockIcon.SetLockcolor(new Color32(255, 255, 255, 255));
        image.color = new Color32(120, 120, 120, 255);

        upgradeScript.upgradeUnlocked += () =>
        {
            lockIcon.SetLockcolor(new Color32(255, 255, 255, 0));
        };

        upgradeScript.upgradePurchased += () =>
        {
            image.color = new Color32(255, 255, 255, 255);
            lockIcon.SetLockcolor(new Color32(255, 255, 255, 0));
        };

        if (upgradeScript.isFirstUpgrade)
        {
            image.color = new Color32(120, 120, 120, 255);
            lockIcon.SetLockcolor(new Color32(255, 255, 255, 0));
        }
    }

    public void OnButtonPress()
    {
        upgradeUIHandler.ChosenUpgrade(upgradeScript, image.sprite);
    }
}
