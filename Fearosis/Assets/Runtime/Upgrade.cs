using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System;

public class Upgrade : MonoBehaviour
{
    [SerializeField]
    private string upgradeName;
    [SerializeField]
    private string upgradeDescription;
    [SerializeField]
    private int upgradeCost;

    [Header("Add prerequisite upgrades (if applicable)")]
    public GameObject[] prerequisiteUpgrades;
    [SerializeField]
    private bool isPurchased = false;
    public event Action upgradePurchased;

    [Header("Add value you wish to buff")]
    [SerializeField]
    private int fearBuff;
    [SerializeField]
    private int notorietyBuff;
    [SerializeField]
    private int prejudiceBuff;
    [SerializeField]
    private int painBuff;

    private enum SourceType
    {
        Blood,
        Physical,
        Behavior,
        Psychological
    };
    [SerializeField]
    private SourceType source;

    private Fear fearScript;
    private Notoriety notorietyScript;
    private Prejudice prejudiceScript;
    private Pain painScript;
    private Influence influenceScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fearScript = FindAnyObjectByType<Fear>();
        notorietyScript = FindAnyObjectByType<Notoriety>();
        prejudiceScript = FindAnyObjectByType<Prejudice>();
        painScript = FindAnyObjectByType<Pain>();
        influenceScript = FindAnyObjectByType<Influence>();

        //note: this will work only if the postrequisite remains enabled, with only the button being disabled and such
        //if the object has prerequisites it will be added as a listener
        if (prerequisiteUpgrades != null)
        {
            foreach (GameObject prereq in prerequisiteUpgrades)
            {
                Upgrade prereqStatus = prereq.GetComponent<Upgrade>();
                prereqStatus.upgradePurchased += this.CheckPrerequisites;
            }
        }//if none it carries on
        else
        {
            //code for button + light up
        }
        
    }

    void OnDisable()
    {
        if (prerequisiteUpgrades != null)
        {
            foreach (GameObject prereq in prerequisiteUpgrades)
            {
                Upgrade prereqStatus = prereq.GetComponent<Upgrade>();
                prereqStatus.upgradePurchased -= this.CheckPrerequisites;
            }
        }
    }

    public void ApplyUpgrade()
    {
        Debug.Log("Applying upgrade: " + upgradeName);
        if (fearBuff > 0)
        {
            Debug.Log("Gaining fear points: " + fearBuff);
            fearScript.GainPoints(fearBuff, source.ToString());
        }
        if (notorietyBuff > 0)
        {
            Debug.Log("Gaining notoriety points: " + notorietyBuff);
            notorietyScript.GainPoints(notorietyBuff, source.ToString());
        }
        if (prejudiceBuff > 0)
        {
            Debug.Log("Gaining prejudice points: " + prejudiceBuff);
            prejudiceScript.GainPoints(prejudiceBuff, source.ToString());
        }
        if (painBuff > 0)
        {
            Debug.Log("Gaining pain points: " + painBuff);
            painScript.GainPoints(painBuff, source.ToString());
        }
    }

    //primary function associated with button
    public void Purchase()
    {
        if (!isPurchased && influenceScript.influencePoints >= upgradeCost)
        {
            influenceScript.influencePoints -= upgradeCost;

            isPurchased = true;
            Debug.Log(upgradeName + " purchased!");
            upgradePurchased?.Invoke();

            ApplyUpgrade();
            //code for button + light up
        }
    }

    //this is the function postrequisite Upgrades will use
    public void CheckPrerequisites() 
    {
        bool unlockable = true; //tracker
        if (prerequisiteUpgrades != null)
        {
            //iteration thru prerequisites
            Debug.Log ("Checking");
            foreach (GameObject prereq in prerequisiteUpgrades) 
            {
                Upgrade prereqStatus = prereq.GetComponent<Upgrade>();
                if (prereqStatus.isPurchased == false)
                    {
                        Debug.Log("Check failed. Remain Locked.");
                        unlockable = false;
                        break;
                    }
            }
        }
        
        //only fully works if all prereqs are enabled
        if(unlockable) 
        {
            Debug.Log("Unlocking");
            //code for button + light up
        }

    }
}

