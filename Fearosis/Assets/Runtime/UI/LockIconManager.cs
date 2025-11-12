using UnityEngine;
using UnityEngine.UI;

public class LockIconManager : MonoBehaviour
{
    private Image lockIcon;

    void Awake()
    {
        lockIcon = GetComponent<Image>();
    }

    public void SetLockcolor(Color32 color)
    {
        lockIcon.color = color;
    }
}
