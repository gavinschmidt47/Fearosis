using UnityEngine;
using UnityEngine.UI;

public class LockIconManager : MonoBehaviour
{
    private Image lockIcon;

    public void SetLockColor(Color32 newColor)
    {
        try
        {
            lockIcon = GetComponent<Image>();
            lockIcon.color = newColor;
        }
        catch
        {
            Debug.LogError("Image component not found in LockIconManager in " + gameObject.name);
        }
    }
}
