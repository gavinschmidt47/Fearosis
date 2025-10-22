using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : MonoBehaviour
{
    public GameObject Upgrade1Panel;
    public GameObject Upgrade2Panel;
    public GameObject Monster1Panel;
    public GameObject Monster2Panel;
    public GameObject Theme1Panel;
    public GameObject Theme2Panel;

    public void ShowUpgrade1Panel()
    {
        Upgrade1Panel.SetActive(true);
    }

    public void ShowUpgrade2Panel()
    {
        Upgrade2Panel.SetActive(true);
    }

    public void ShowMonster1Panel()
    {
        Monster1Panel.SetActive(true);
    }

    public void ShowMonster2Panel()
    {
        Monster2Panel.SetActive(true);
    }

    public void ShowTheme1Panel()
    {
        Theme1Panel.SetActive(true);
    }

    public void ShowTheme2Panel()
    {
        Theme2Panel.SetActive(true);
    }

    public void HideAllPanels()
    {
        Upgrade1Panel.SetActive(false);
        Upgrade2Panel.SetActive(false);
        Monster1Panel.SetActive(false);
        Monster2Panel.SetActive(false);
        Theme1Panel.SetActive(false);
        Theme2Panel.SetActive(false);
    }

}
