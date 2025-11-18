using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : MonoBehaviour
{
    //Buttons for sake of enable/disable
    public Button Upgrade1Button;
    public Button Upgrade2Button;
    public Button Monster1Button;
    public Button Monster2Button;
    public Button Theme1Button;
    public Button Theme2Button;

    //Information panels
    public GameObject Upgrade1Panel;
    public GameObject Upgrade2Panel;
    public GameObject Monster1Panel;
    public GameObject Monster2Panel;
    public GameObject Theme1Panel;
    public GameObject Theme2Panel;

    //Confirm Panels
    public GameObject Upgrade1Confirm;
    public GameObject Upgrade2Confirm;
    public GameObject Monster1Confirm;
    public GameObject Monster2Confirm;
    public GameObject Theme1Confirm;
    public GameObject Theme2Confirm;

    //Variables for logic and saving
    public bool hasUpgrade1;
    public bool hasUpgrade2;
    public bool hasMonster1;
    public bool hasMonster2;
    public bool hasTheme1;
    public bool hasTheme2;

    void Start()
    {
        //if (no save data){
            hasUpgrade1 = false;
            hasUpgrade2 = false;
            hasMonster1 = false;
            hasMonster2 = false;
            hasTheme1 = false;
            hasTheme2 = false;
        //}
    }
    

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

        Upgrade1Confirm.SetActive(false);
        Upgrade2Confirm.SetActive(false);
        Monster1Confirm.SetActive(false);
        Monster2Confirm.SetActive(false);
        Theme1Confirm.SetActive(false);
        Theme2Confirm.SetActive(false);
    }

    public void OpenUpgrade1ConfirmPanel()
    {
        Upgrade1Confirm.SetActive(true);
    }

    public void FinalizeUpgrade1()
    {
        hasUpgrade1 = true;
        Upgrade1Button.interactable = false;
    }

    public void OpenUpgrade2ConfirmPanel()
    {
        Upgrade2Confirm.SetActive(true);
    }

    public void FinalizeUpgrade2()
    {
        hasUpgrade2 = true;
        Upgrade2Button.interactable = false;
    }

    public void OpenMonster1ConfirmPanel()
    {
        Monster1Confirm.SetActive(true);
    }

    public void FinalizeMonster1()
    {
        hasMonster1 = true;
        Monster1Button.interactable = false;
    }

    public void OpenMonster2ConfirmPanel()
    {
        Monster2Confirm.SetActive(true);
    }

    public void FinalizeMonster2()
    {
        hasMonster2 = true;
        Monster2Button.interactable = false;
    }

    public void OpenTheme1ConfirmPanel()
    {
        Theme1Confirm.SetActive(true);
    }

    public void FinalizeTheme1()
    {
        hasTheme1 = true;
        Theme1Button.interactable = false;
    }

    public void OpenTheme2ConfirmPanel()
    {
        Theme2Confirm.SetActive(true);
    }

    public void FinalizeTheme2()
    {
        hasTheme2 = true;
        Theme2Button.interactable = false;
    }



}
