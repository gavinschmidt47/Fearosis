using UnityEngine;
using UnityEngine.UI;

public class MasterButtonHandler : MonoBehaviour
{
    //Monster Buttons
    [SerializeField]
    private GameObject expandedMonsterButton;

    //Upgrade Buttons
    [SerializeField]
    private GameObject bloodScreen;
    [SerializeField]
    private GameObject physicalScreen;
    [SerializeField]
    private GameObject behaviorScreen;
    [SerializeField]
    private GameObject psychologicalScreen;

    //Stats Buttons
    [SerializeField]
    private GameObject statsScreen;

    //Options Buttons
    [SerializeField]
    private GameObject optionsScreen;

    public void ExpandMonsterButton()
    {
        expandedMonsterButton.SetActive(!expandedMonsterButton.activeSelf);
    }

    public void OpenBloodScreen()
    {
        bloodScreen.SetActive(true);
        physicalScreen.SetActive(false);
        behaviorScreen.SetActive(false);
        psychologicalScreen.SetActive(false);
        statsScreen.SetActive(false);
        optionsScreen.SetActive(false);
    }
    public void OpenPhysicalScreen()
    {
        bloodScreen.SetActive(false);
        physicalScreen.SetActive(true);
        behaviorScreen.SetActive(false);
        psychologicalScreen.SetActive(false);
        statsScreen.SetActive(false);
        optionsScreen.SetActive(false);
    }
    public void OpenBehaviorScreen()
    {
        bloodScreen.SetActive(false);
        physicalScreen.SetActive(false);
        behaviorScreen.SetActive(true);
        psychologicalScreen.SetActive(false);
        statsScreen.SetActive(false);
        optionsScreen.SetActive(false);
    }
    public void OpenPsychologicalScreen()
    {
        bloodScreen.SetActive(false);
        physicalScreen.SetActive(false);
        behaviorScreen.SetActive(false);
        psychologicalScreen.SetActive(true);
        statsScreen.SetActive(false);
        optionsScreen.SetActive(false);
    }

    public void OpenStatsScreen()
    {
        bloodScreen.SetActive(false);
        physicalScreen.SetActive(false);
        behaviorScreen.SetActive(false);
        psychologicalScreen.SetActive(false);
        statsScreen.SetActive(true);
        optionsScreen.SetActive(false);
    }

    public void OpenOptionsScreen()
    {
        bloodScreen.SetActive(false);
        physicalScreen.SetActive(false);
        behaviorScreen.SetActive(false);
        psychologicalScreen.SetActive(false);
        statsScreen.SetActive(false);
        optionsScreen.SetActive(true);
    }
}
