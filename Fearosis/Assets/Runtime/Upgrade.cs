using UnityEngine;
using System.Collections.Generic;

public class Upgrade : MonoBehaviour
{
    [SerializeField]
    private string upgradeName;
    [SerializeField]
    private string upgradeDescription;
    [SerializeField]
    private int fearBuff;
    [SerializeField]
    private int notorietyBuff;
    [SerializeField]
    private int prejudiceBuff;
    [SerializeField]
    private int painBuff;
    [SerializeField]
    private string source;

    private Fear fearScript;
    private Notoriety notorietyScript;
    private Prejudice prejudiceScript;
    private Pain painScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fearScript = FindAnyObjectOfType<Fear>();
        notorietyScript = FindAnyObjectOfType<Notoriety>();
        prejudiceScript = FindAnyObjectOfType<Prejudice>();
        painScript = FindAnyObjectOfType<Pain>();
    }

    public void ApplyUpgrade()
    {
        if (fearBuff > 0)
        {
            fearScript.GainPoints(fearBuff, source);
        }
        if (notorietyBuff > 0)
        {
            notorietyScript.GainPoints(notorietyBuff, source);
        }
        if (prejudiceBuff > 0)
        {
            prejudiceScript.GainPoints(prejudiceBuff, source);
        }
        if (painBuff > 0)
        {
            painScript.GainPoints(painBuff, source);
        }
    }
}
